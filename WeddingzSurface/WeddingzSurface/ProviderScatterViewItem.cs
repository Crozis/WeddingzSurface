using System;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation;

using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace WeddingzSurface
{
    /// <summary>
    /// Interaction logic for ProviderScatterViewItem.xaml
    /// </summary>
    public partial class ProviderScatterViewItem : ScatterViewItem
    {
        private ProviderTemplate providerTemplate;

        public ProviderScatterViewItem(ProviderTemplate pt)
        {
            Console.WriteLine("Ici");
            this.providerTemplate = pt;
            pt.setParent(this);
            this.initUI();
            this.initEvents();
            this.ContactLeave += new ContactEventHandler(ProviderScatterViewItem_ContactUp);
        }

        void ProviderScatterViewItem_ContactUp(object sender, ContactEventArgs e)
        {
            TrashBin t = (TrashBin)MainView.GetWindow(this).FindName("trashbin");

            ScatterViewItem s = sender as ScatterViewItem;
            ScatterViewItem trashSVI = MainView.GetWindow(this).FindName("trashbin_svi") as ScatterViewItem;

            Point centerS = s.ActualCenter;
            Point centerTrashSVI = trashSVI.ActualCenter;

            double trashSVIWidth = trashSVI.ActualWidth;
            double trashSVIHeight = trashSVI.ActualHeight;

            double max = Math.Min(trashSVIHeight, trashSVIWidth);

            if ((centerS.X <= centerTrashSVI.X + max / 2) &&
                (centerS.X >= centerTrashSVI.X - max / 2) &&
                (centerS.Y <= centerTrashSVI.Y + max / 2) &&
                (centerS.Y >= centerTrashSVI.Y - max / 2))
            {
                s = null;

                ObservableCollection<Image> dataTemplate = (ObservableCollection<Image>)t.ItemsSource;

                if (dataTemplate == null)
                {
                    dataTemplate = new ObservableCollection<Image>();
                }

                Image i = new Image();
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri("http://d24w6bsrhbeh9d.cloudfront.net/photo/2165142_460s_v1.jpg");
                bi.EndInit();
                i.Source = bi;

                dataTemplate.Add(i);

                t.ItemsSource = dataTemplate;
            }
        }

        private void initEvents()
        {
            this.ContactTapGesture += new ContactEventHandler(this.providerTemplate.toggle);
        }


        private void initUI()
        {
            this.Content = this.providerTemplate;
        }
    }
}
