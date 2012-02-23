using System;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation;

using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using WeddingzSurface.Models;

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
            this.MaxWidth = 400;
            Console.WriteLine("New PSVI");
            this.providerTemplate = pt;
            pt.setParent(this);
            this.initUI();
            this.initEvents();
            this.ContactLeave += new ContactEventHandler(ProviderScatterViewItem_ContactUp);
        }

        void ProviderScatterViewItem_ContactUp(object sender, ContactEventArgs e)
        {
            TrashBin t = StaticField.trashSVI.trashBin;

            ProviderScatterViewItem s = sender as ProviderScatterViewItem;
            ScatterViewItem trashSVI = StaticField.trashSVI;

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

                ObservableCollection<Trash> dataTemplate = (ObservableCollection<Trash>) t.ItemsSource;

                if (dataTemplate == null)
                {
                    dataTemplate = new ObservableCollection<Trash>();
                }


                Trash trash = new Trash(s.providerTemplate, s.providerTemplate.ProviderImage.Source);
                dataTemplate.Add(trash);

                t.ItemsSource = dataTemplate;

                // loop over all scattersView to delete
                ScatterView sv = ((ScatterView)MainView.GetWindow(this).FindName("MainScatterView"));
                ItemCollection tmp = (ItemCollection) sv.Items;
                tmp.Remove(s);
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
