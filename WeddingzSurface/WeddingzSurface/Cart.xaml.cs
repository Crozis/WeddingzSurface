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
            /*
            HttpWebRequest request = WebRequest.Create("http://weddingz.heroku.com/weddings/activated.json") as HttpWebRequest;
            String jsonResponse = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonResponse = reader.ReadToEnd();
                StaticField.wedding = JsonConvert.DeserializeObject<Wedding>(jsonResponse);
            }
            */
            foreach (ProviderType provider_type in StaticField.wedding.service_types) 
            {
                switch(provider_type.name) 
                {
                    case "Fleuristes": florist.Content = "Fleuristes : " + count_activated_services(provider_type.services);  break;
                    case "Lieux": place.Content = "Lieux : " + count_activated_services(provider_type.services); break;
                    case "Animations": animation.Content = "Animation : " + count_activated_services(provider_type.services); break;
                    case "Traiteurs": caterer.Content = "Décorations : " + count_activated_services(provider_type.services); break;
                    case "Photographes": photograph.Content = "Photographes : " + count_activated_services(provider_type.services); break;
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

        private void TagVisualization_Unloaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
