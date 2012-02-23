﻿using System;
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

namespace WeddingzSurface
{
    /// <summary>
    /// Interaction logic for Basket.xaml
    /// </summary>
    public partial class Basket : SurfaceUserControl
    {
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
                Console.WriteLine("HAHAHAHAHHA");
            }
            else
            {
                Wedding wedding = JsonConvert.DeserializeObject<Wedding>(jsonResponse);

                ScatterView sv = ((ScatterView)MainView.GetWindow(this).FindName("MainScatterView"));
                //sv.Items.Clear();
                foreach (Provider pr in wedding.services)
                {
                    sv.Items.Add(new ProviderScatterViewItem(new ProviderTemplate(pr)));
                }


                //progressBar1.Value = 0;
                rectangle2.Width = 0;
                DoubleAnimation da = new DoubleAnimation();
                da.From = 0;
                da.To = 380;
                da.Duration = new Duration(TimeSpan.FromSeconds(1.5));

                rectangle2.BeginAnimation(Rectangle.WidthProperty, da);
                //progressBar1.BeginAnimation(ProgressBar.ValueProperty, da);
                //progressBar2.BeginAnimation(ProgressBar.ValueProperty, da);
            }
        }
        private void Basket_Unloaded(object sender, RoutedEventArgs e)
        {
        }
    }
}