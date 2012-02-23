using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using WeddingzSurface.Models;
using System.Collections.ObjectModel;
namespace WeddingzSurface
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : TagVisualization
    {
        public Cart()
        {
            InitializeComponent();
        }

        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            String activated_services = "";
            String disabled_services = "";
            foreach (ProviderType provider_type in StaticField.wedding.service_types) 
            {
                foreach (Provider service in provider_type.services) 
                {
                    if (service.activated == true)
                    {
                        activated_services += service.id + ";" ;
                    }
                    else
                    {
                        disabled_services += service.id + ";";
                    }
                }
            }
            HttpWebRequest request1 = WebRequest.Create("http://weddingz.heroku.com/weddings/" + StaticField.wedding.id + "/activate_services/" + activated_services) as HttpWebRequest;
            request1.GetResponse();

            HttpWebRequest request2 = WebRequest.Create("http://weddingz.heroku.com/weddings/" + StaticField.wedding.id + "/disabled_services/" + disabled_services) as HttpWebRequest;
            request2.GetResponse();
            ScatterView sv = ((ScatterView)MainView.GetWindow(this).FindName("MainScatterView"));
            sv.Items.Clear();
            
        }

        private void Cart_Loaded(object sender, RoutedEventArgs e)
        {
            Label label1 = ((Label)MainView.GetWindow(this).FindName("WeddingName1"));
            Label label2 = ((Label)MainView.GetWindow(this).FindName("WeddingName2"));
            label1.Content = "";
            label2.Content = "";
            
            if (StaticField.wedding == null)
            {
                HttpWebRequest request = WebRequest.Create("http://weddingz.heroku.com/weddings/activated.json") as HttpWebRequest;
                String jsonResponse = "";
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    jsonResponse = reader.ReadToEnd();
                    StaticField.wedding = JsonConvert.DeserializeObject<Wedding>(jsonResponse);
                }
            }
            
            foreach (ProviderType provider_type in StaticField.wedding.service_types) 
            {
                switch(provider_type.name) 
                {
                    case "Fleuristes":   FloristNumber.Content    = count_activated_services(provider_type.services); break;
                    case "Lieux":        PlaceNumber.Content      = count_activated_services(provider_type.services); break;
                    case "Animations":   AnimationNumber.Content  = count_activated_services(provider_type.services); break;
                    case "Traiteurs":    CatererNumber.Content    = count_activated_services(provider_type.services); break;
                    case "Photographes": PhotographNumber.Content = count_activated_services(provider_type.services); break;
                }
            }
        }
        private int count_activated_services(List<Provider> providers)
        {
            int i = 0;
            foreach (Provider p in providers)
            {
                if (p.activated == true)
                {
                    i += 1;
                }
            }
            return i;

        }
        public void florist_click(object sender, RoutedEventArgs e) { loadServices("Fleuristes"); }
        public void place_click(object sender, RoutedEventArgs e) { loadServices("Lieux"); }
        public void photograph_click(object sender, RoutedEventArgs e) { loadServices("Photographes"); }
        public void caterer_click(object sender, RoutedEventArgs e) { loadServices("Traiteurs"); }
        public void animation_click(object sender, RoutedEventArgs e) { loadServices("Animations"); }

        public void loadServices(String service_name)
        {
            ScatterView sv = ((ScatterView)MainView.GetWindow(this).FindName("MainScatterView"));
            sv.Items.Clear();

            // init trashbin
            StaticField.trashSVI = new TrashBinScatterViewItem(new TrashBin());
            sv.Items.Add(StaticField.trashSVI);
            
            var dataTemplate = new ObservableCollection<Trash>();

            foreach (ProviderType provider_type in StaticField.wedding.service_types)
            {
                if (provider_type.name == service_name)
                {

                    foreach (Provider pr in provider_type.services)
                    {
                        ProviderTemplate pt = new ProviderTemplate(pr);
                        if (pr.activated)
                        {
                            sv.Items.Add(new ProviderScatterViewItem(pt));
                        }
                        else
                        {
                            Trash trash = new Trash(pt, pt.ProviderImage.Source);
                            dataTemplate.Add(trash);
                        }
                    }
                    StaticField.trashSVI.trashBin.ItemsSource = dataTemplate;
                }
            }
        }
        private void TagVisualization_Unloaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
