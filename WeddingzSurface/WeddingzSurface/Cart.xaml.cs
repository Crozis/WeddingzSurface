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

        }

        private void Cart_Loaded(object sender, RoutedEventArgs e)
        {
            Label label1 = ((Label)MainView.GetWindow(this).FindName("WeddingName1"));
            Label label2 = ((Label)MainView.GetWindow(this).FindName("WeddingName2"));
            label1.Content = "";
            label2.Content = "";
            

            /*Image on buttons*/
            /*
            Image logoImage = new Image();
            BitmapImage logoBitmap = new BitmapImage();
            logoBitmap.BeginInit();
            logoBitmap.UriSource = new Uri("http://img594.imageshack.us/img594/8813/hebergement.png");
            logoBitmap.EndInit();
            logoImage.Source = logoBitmap;
            florist.Content = logoImage;
            Console.WriteLine("???");
            */
            HttpWebRequest request = WebRequest.Create("http://weddingz.heroku.com/weddings/activated.json") as HttpWebRequest;
            String jsonResponse = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonResponse = reader.ReadToEnd();
                StaticField.wedding = JsonConvert.DeserializeObject<Wedding>(jsonResponse);
            }
            
            foreach (ProviderType provider_type in StaticField.wedding.service_types) 
            {
                switch(provider_type.name) 
                {
                    case "Fleuristes": break; //florist.Content = "Fleuristes\n           " + count_activated_services(provider_type.services);  break;
                    case "Lieux": break;//place.Content = "Lieux\n            " + count_activated_services(provider_type.services); break;
                    case "Animations": break; //animation.Content = "Animation\n            " + count_activated_services(provider_type.services); break;
                    case "Traiteurs": break; //caterer.Content = "Décorations\n            " + count_activated_services(provider_type.services); break;
                    case "Photographes": break;//photograph.Content = "Photographes\n            " + count_activated_services(provider_type.services); break;
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
            foreach (ProviderType provider_type in StaticField.wedding.service_types)
            {
                if (provider_type.name == service_name)
                {
                    ScatterView sv = ((ScatterView)MainView.GetWindow(this).FindName("MainScatterView"));
                    sv.Items.Clear();

                    foreach (Provider pr in provider_type.services)
                    {
                        sv.Items.Add(new ProviderScatterViewItem(new ProviderTemplate(pr)));
                    }
                }
            }
        }
        private void TagVisualization_Unloaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
