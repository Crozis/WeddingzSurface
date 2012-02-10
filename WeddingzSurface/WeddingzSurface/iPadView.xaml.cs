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

        private void iPadView_Loaded(object sender, RoutedEventArgs e)
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
            //String jsonResponse = "[{'budget':1000,'client_id':null,'created_at':'2012-01-20T18:12:14Z','id':1,'nb_child':null,'nb_person':null,'organizer_id':null,'place':null,'updated_at':'2012-01-20T18:12:14Z'}]";
            //fastJSON.JSON.Instance.ToObject<List<Test>>("[{'name':'lala'}]");
            //jsonResponse = jsonResponse.Remove('\\');
            Wedding wedding = JsonConvert.DeserializeObject<Wedding>(jsonResponse);
            
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
        private void iPadView_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void progressBar2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

    }
}
