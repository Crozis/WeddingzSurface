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
    /// Interaction logic for Trash.xaml
    /// </summary>
    public partial class Trash : SurfaceUserControl
    {
        public ProviderTemplate template;

        public Trash(ProviderTemplate template, ImageSource source)
        {
            InitializeComponent();

            this.template = (ProviderTemplate) template.Clone();
            TrashImage.Source = source;
        }
    }
}
