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
            this.loadImages();
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


        private void loadImages()
        {
            // MainScatterView.ItemsSource = System.IO.Directory.GetFiles(@"C:\Users\Public\pictures\Sample Pictures", "*.jpg");
            String[] items = new String[3];
            items[0] = "http://s3.amazonaws.com/photos.500px.net/132342/7d68f306e7171f8602a41af7da80b3cb17726373/5.jpg?AWSAccessKeyId=AKIAJD7S52E7WX7K465A&Expires=1327673389&Signature=c75%2FHnx2UzNn8sTCaV3aNO7wtWc%3D";
            items[1] = "http://s3.amazonaws.com/photos.500px.net/132342/7d68f306e7171f8602a41af7da80b3cb17726373/5.jpg?AWSAccessKeyId=AKIAJD7S52E7WX7K465A&Expires=1327673389&Signature=c75%2FHnx2UzNn8sTCaV3aNO7wtWc%3D";
            items[2] = "http://s3.amazonaws.com/photos.500px.net/132342/7d68f306e7171f8602a41af7da80b3cb17726373/5.jpg?AWSAccessKeyId=AKIAJD7S52E7WX7K465A&Expires=1327673389&Signature=c75%2FHnx2UzNn8sTCaV3aNO7wtWc%3D";
            MainScatterView.ItemsSource = items;
        }

    }
}