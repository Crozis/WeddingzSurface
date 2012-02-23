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
using WeddingzSurface.Models;
using Newtonsoft.Json;
using System.Net;
using System.IO;
namespace WeddingzSurface
{
    /// <summary>
    /// Interaction logic for Basket.xaml
    /// </summary>
    public partial class Basket : TagVisualization
    {
        Wedding wedding;
        public Basket()
        {
            InitializeComponent();
        }
        private void Basket_Loaded(object sender, RoutedEventArgs e)
        {
            HttpWebRequest request = WebRequest.Create("http://weddingz.heroku.com/weddings/activated.json") as HttpWebRequest;

            // Get response
            String jsonResponse = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonResponse = reader.ReadToEnd();
            }
            if (jsonResponse == "Aucun wedding n'est activé")
            {
                Console.WriteLine("Aucun wedding n'est activé");
            }
            else
            {
                wedding = JsonConvert.DeserializeObject<Wedding>(jsonResponse);
            }
        }
        private void Basket_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void florist_click(object sender, RoutedEventArgs e)  { loadServices("Fleuristes"); }
        private void place_click(object sender, RoutedEventArgs e)  { loadServices("Lieux"); }
        private void photograph_click(object sender, RoutedEventArgs e) { loadServices("Photographes"); }
        private void caterer_click(object sender, RoutedEventArgs e) { loadServices("Traiteurs"); }
        private void animation_click(object sender, RoutedEventArgs e) { loadServices("Animations"); }

        private void loadServices(String service_name)
        {
            foreach (ProviderType provider_type in wedding.service_types)
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
    }
}
