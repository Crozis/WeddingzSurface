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
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;

namespace WeddingzSurface
{

    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : SurfaceWindow
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainView()
        {
            InitializeComponent();

            // Add handlers for Application activation events
            AddActivationHandlers();

            // Load images
            // this.loadProviders();
        }


        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for Application activation events
            RemoveActivationHandlers();
        }

        /// <summary>
        /// Adds handlers for Application activation events.
        /// </summary>
        private void AddActivationHandlers()
        {
            // Subscribe to surface application activation events
            ApplicationLauncher.ApplicationActivated += OnApplicationActivated;
            ApplicationLauncher.ApplicationPreviewed += OnApplicationPreviewed;
            ApplicationLauncher.ApplicationDeactivated += OnApplicationDeactivated;
        }

        /// <summary>
        /// Removes handlers for Application activation events.
        /// </summary>
        private void RemoveActivationHandlers()
        {
            // Unsubscribe from surface application activation events
            ApplicationLauncher.ApplicationActivated -= OnApplicationActivated;
            ApplicationLauncher.ApplicationPreviewed -= OnApplicationPreviewed;
            ApplicationLauncher.ApplicationDeactivated -= OnApplicationDeactivated;
        }

        /// <summary>
        /// This is called when application has been activated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationActivated(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when application is in preview mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationPreviewed(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        ///  This is called when application has been deactivated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationDeactivated(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }


        private void loadProviders()
        {
            Provider p = new Provider();
            p.front_picture = "http://d24w6bsrhbeh9d.cloudfront.net/photo/2165142_460s_v1.jpg";
            p.name = "Provider n°1";
            p.pictures_url = new List<string>();
            p.price = "tarifs";
            p.pictures_url.Add("http://d24w6bsrhbeh9d.cloudfront.net/photo/2165142_460s_v1.jpg");
            p.pictures_url.Add("http://d24w6bsrhbeh9d.cloudfront.net/photo/2165142_460s_v1.jpg");
            p.pictures_url.Add("http://d24w6bsrhbeh9d.cloudfront.net/photo/2165142_460s_v1.jpg");

            Provider p2 = new Provider();
            p2.front_picture = "http://d24w6bsrhbeh9d.cloudfront.net/photo/2149770_460s_v1.jpg";
            p2.name = "Provider n°2";
            p.pictures_url = new List<string>();
            p.pictures_url.Add("http://d24w6bsrhbeh9d.cloudfront.net/photo/2165142_460s_v1.jpg");
            p.pictures_url.Add("http://d24w6bsrhbeh9d.cloudfront.net/photo/2165142_460s_v1.jpg");
            p.pictures_url.Add("http://d24w6bsrhbeh9d.cloudfront.net/photo/2165142_460s_v1.jpg");

            Provider p3 = new Provider();
            p3.front_picture = "http://d24w6bsrhbeh9d.cloudfront.net/photo/2158212_460s.jpg";
            p3.name = "Provider n°3";

            List<Provider> providers = new List<Provider>();
            providers.Add(p);
            providers.Add(p2);
            providers.Add(p3);
            
            // MainScatterView.ItemsSource = providers.ToArray();

            foreach (Provider pr in providers)
            {
                MainScatterView.Items.Add(new ProviderScatterViewItem(new ProviderTemplate(pr)));
            }

        }

    }
}