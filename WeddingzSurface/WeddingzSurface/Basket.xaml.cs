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
        //Wedding wedding;
        public Basket()
        {
            InitializeComponent();
        }
        private void Basket_Loaded(object sender, RoutedEventArgs e) 
        {
            Label label1 = ((Label)MainView.GetWindow(this).FindName("WeddingName1"));
            Label label2 = ((Label)MainView.GetWindow(this).FindName("WeddingName2"));
            label1.Content = "";
            label2.Content = "";
        }
        private void Basket_Unloaded(object sender, RoutedEventArgs e) {}

        public void florist_click(object sender, RoutedEventArgs e) { loadServices("Fleuristes"); }
        public void place_click(object sender, RoutedEventArgs e) { loadServices("Lieux"); }
        public void photograph_click(object sender, RoutedEventArgs e) { loadServices("Photographes"); }
        public void caterer_click(object sender, RoutedEventArgs e) { loadServices("Traiteurs"); }
        public void animation_click(object sender, RoutedEventArgs e) { loadServices("Animations"); }

        public void loadServices(String service_name)
        {
            ScatterView sv = ((ScatterView)MainView.GetWindow(this).FindName("MainScatterView"));

            foreach (ProviderType provider_type in StaticField.wedding.service_types)
            {
                if (provider_type.name == service_name) 
                {
                    sv.Items.Clear();

                    foreach (Provider pr in provider_type.services)
                    {
                        sv.Items.Add(new ProviderScatterViewItem(new ProviderTemplate(pr)));
                    }   
                }
            }
            // init trashbin
            StaticField.trashSVI = new TrashBinScatterViewItem(new TrashBin());
            sv.Items.Add(StaticField.trashSVI);
        }
    }
}
