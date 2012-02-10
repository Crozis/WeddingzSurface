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
    /// Interaction logic for ImageThumbnailTemplate.xaml
    /// </summary>
    public partial class ImageThumbnailTemplate : SurfaceUserControl
    {

        public Image principalImage{get; set;}

        public ImageThumbnailTemplate(string src, Image principal)
        {
            InitializeComponent();

            // attributes
            this.Thumbnail.Source = BitmapFrame.Create(new Uri(src));
            this.principalImage = principal;

            // touch event
            this.ContactTapGesture += new ContactEventHandler(ImageThumbnailTemplate_ContactTapGesture);
        }

        void ImageThumbnailTemplate_ContactTapGesture(object sender, ContactEventArgs e)
        {
            /*LibraryBarItem self = sender as LibraryBarItem;
            Image i = pouet.Content as Image;
            if (i != null) Console.WriteLine(i.Source);
            e.Handled = true;
             */
            Console.WriteLine("Fap");
            e.Handled = true;
        }
    }
}
