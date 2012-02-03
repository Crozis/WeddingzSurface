using System;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation;

using System.Windows.Media.Animation;
using System.Windows;

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
            this.providerTemplate = pt;
            pt.setParent(this);
            this.initUI();
            this.initEvents();
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
