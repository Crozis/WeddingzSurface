using System;
using System.Windows.Controls;
using Microsoft.Surface.Presentation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows;
using System.Collections.ObjectModel;

namespace WeddingzSurface
{
    public enum ProviderItemState
    {
        overview,
        detailed
    }

    public partial class ProviderTemplate : UserControl, ICloneable
    {
        public Provider provider;
        private ProviderItemState currentState;

        private ProviderScatterViewItem parent;

        public void setParent(ProviderScatterViewItem p)
        {
            this.parent = p;
        }
        public ProviderScatterViewItem getParent()
        {
            return this.parent;
        }

        // Animation manager
        private Storyboard _opener,
                           _closer;

        public ProviderTemplate(Provider p)
        {
            InitializeComponent();
            this.provider = p;
            this.currentState = ProviderItemState.overview;
            this.fillWithData();
        }

        private void fillWithData()
        {
            this.ProviderImage.Source = BitmapFrame.Create(new Uri(this.provider.front_picture));
            this.ProviderName.Content = this.provider.name;
            this.ProviderNameDetail.Content = this.provider.name;
            this.ProviderDescription.Text = this.provider.description;
            this.ProviderFares.Text = this.provider.price;

            
            ObservableCollection<ImageThumbnailTemplate> dataTemplate = new ObservableCollection<ImageThumbnailTemplate>();
            foreach (string url in this.provider.pictures_url) {
                ImageThumbnailTemplate itt = new ImageThumbnailTemplate(url);
                dataTemplate.Add(itt);
            }
            ImageThumbnailTemplate it = new ImageThumbnailTemplate(this.provider.front_picture);
            dataTemplate.Add(it);
            
            this.PhotoLibrary.ItemsSource = dataTemplate;
        }

        public void toggle(object sender, ContactEventArgs args)
        {
            if (currentState == ProviderItemState.overview)
            {
                this.ProviderName.Content = "toggled";
                this.setState(ProviderItemState.detailed);
            }
            else
            {
                this.ProviderName.Content = this.provider.name;
                this.setState(ProviderItemState.overview);
            }
        }

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="future">The future state</param>
        public void setState(ProviderItemState future)
        {
            if (this._opener == null || this._closer == null) //lazy init
            {
                this.initMorphers();
            }

            switch (future)
            {
                case ProviderItemState.detailed:
                    this.onStoryboardStarted();
                    this._closer.Stop();
                    this._opener.Begin();
                    break;

                case ProviderItemState.overview:
                    this.onStoryboardStarted();
                    this._opener.Stop();
                    this._closer.Begin();
                    break;
            }

            this.currentState = future;
        }

        /// <summary>
        /// Creates a scale animator.
        /// </summary>
        /// <param name="showBack">true if the back should be shown, false if front should be shown</param>
        /// <returns>a Storyboard instance that allows you to do the animations</returns>
        private Storyboard generateMorpher(bool showBack)
        {
            Storyboard result = new Storyboard();
            Duration duration = TimeSpan.FromMilliseconds(500);

            double x = 0;
            if (!showBack)
            {
                x = ProviderOverview.Width;
            }
            else
            {
                x = ProviderDetail.Width;
            }
            double y = 0;
            if (!showBack)
            {
                y = ProviderOverview.Height;
            }
            else
            {
                y = ProviderDetail.Height;
            }

            DoubleAnimation wModifier = new DoubleAnimation()
            {
                To = x,
                Duration = duration
            };

            Storyboard.SetTarget(wModifier, this.parent);
            Storyboard.SetTargetProperty(wModifier, new PropertyPath(ProviderScatterViewItem.WidthProperty));

            DoubleAnimation hModifier = new DoubleAnimation()
            {
                To = y,
                Duration = duration
            };

            Storyboard.SetTarget(hModifier, this.parent);
            Storyboard.SetTargetProperty(hModifier, new PropertyPath(ProviderScatterViewItem.HeightProperty));

            //result.Completed += new EventHandler(onStoryboardCompleted);

            result.Children.Add(wModifier);
            result.Children.Add(hModifier);

            return result;
        }

        public void onStoryboardCompleted(object sender, EventArgs e)
        {
            if (this.ProviderDetail.Visibility == Visibility.Hidden)
            {
                this.ProviderOverview.Visibility = Visibility.Hidden;
                this.ProviderDetail.Visibility = Visibility.Visible;
            }
            else
            {
                this.ProviderOverview.Visibility = Visibility.Visible;
                this.ProviderDetail.Visibility = Visibility.Hidden;
            }
        }

        public void onStoryboardStarted()
        {
            if (this.ProviderDetail.Visibility == Visibility.Hidden)
            {
                this.ProviderOverview.Visibility = Visibility.Hidden;
                this.ProviderDetail.Visibility = Visibility.Visible;
            }
            else
            {
                this.ProviderOverview.Visibility = Visibility.Visible;
                this.ProviderDetail.Visibility = Visibility.Hidden;
            }
        }


        /// <summary>
        /// Inits the animation managers
        /// </summary>
        private void initMorphers()
        {
            this._opener = this.generateMorpher(true);
            this._closer = this.generateMorpher(false);
        }

        #region ICloneable Membres

        public object Clone()
        {
            ProviderTemplate pt = new ProviderTemplate(this.provider);
            return pt;
        }

        #endregion

        private void ProviderImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
