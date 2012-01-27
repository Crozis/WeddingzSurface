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

namespace WeddingzSurface
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : TagVisualization
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void MenuView_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: customize MenuView's UI based on this.VisualizedTag here
        }
    }
}
