using System;
using System.Windows.Controls;
using Microsoft.Surface.Presentation;

namespace WeddingzSurface
{
    public enum ProviderItemState
    {
        overview,
        detailed
    }

    public partial class ProviderTemplate : UserControl
    {
        private Provider provider;
        private ProviderItemState currentState;

        public ProviderTemplate(Provider p)
        {
            InitializeComponent();
            this.provider = p;
            this.currentState = ProviderItemState.overview;
            this.fillWithData();
        }

        private void fillWithData()
        {
            // this.ProviderImage.Source = BitmapFrame.Create(new Uri(this.provider.frontPicture));
            this.ProviderName.Content = this.provider.name;
        }

        public void toggle(object sender, ContactEventArgs args)
        {
            if (currentState == ProviderItemState.overview)
            {
                this.ProviderName.Content = this.provider.name;
            }
            else
            {
                this.ProviderName.Content = "toggled";
            }
        }
    }
}
