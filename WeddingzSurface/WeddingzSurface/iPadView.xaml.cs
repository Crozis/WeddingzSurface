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
            /*HttpWebRequest request = WebRequest.Create("http://weddingz.heroku.com/current_app") as HttpWebRequest;
            // Get response  
            string jsonResponse = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonResponse = reader.ReadToEnd();
            }*/
            String jsonResponse = "[{'budget':1000,'client_id':null,'created_at':'2012-01-20T18:12:14Z','id':1,'nb_child':null,'nb_person':null,'organizer_id':null,'place':null,'updated_at':'2012-01-20T18:12:14Z'}]";
            fastJSON.JSON.Instance.ToObject(jsonResponse);
            
        }
        private void iPadView_Unloaded(object sender, RoutedEventArgs e)
        {
        }

    }
}
