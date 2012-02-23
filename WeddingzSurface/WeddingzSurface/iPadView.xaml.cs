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
using System.Windows.Media.Animation;
using Newtonsoft.Json;
using WeddingzSurface.Models;

namespace WeddingzSurface
{
    /// <summary>
    /// Interaction logic for iPadView.xaml
    /// </summary>
    public partial class iPadView : TagVisualization
    {
        public iPadView()
        {
            InitializeComponent();
        }

        public void iPadView_Loaded(object sender, RoutedEventArgs e)
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
                Console.WriteLine("Aucun wedding n'est activé.");
            }
            else
            {
                StaticField.wedding = JsonConvert.DeserializeObject<Wedding>(jsonResponse);
                
                rectangle2.Width = 0;
                DoubleAnimation da = new DoubleAnimation();
                da.From = 0;
                da.To = 380;
                da.Duration = new Duration(TimeSpan.FromSeconds(1.5));
                rectangle2.BeginAnimation(Rectangle.WidthProperty, da);
                Label label1 = ((Label)MainView.GetWindow(this).FindName("WeddingName1"));
                Label label2 = ((Label)MainView.GetWindow(this).FindName("WeddingName2"));
                String content = "Mariage de " + StaticField.wedding.bride_first_name + " et " + StaticField.wedding.groom_first_name;
                label1.Content = content;
                label2.Content = content;
            }
        }
        private void iPadView_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void progressBar2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

    }
}
