﻿#pragma checksum "..\..\ProviderTemplate.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8A4A791DCC9ECCC1D4EFF9EDB8E2B996"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :2.0.50727.4927
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Controls.ContactVisualizations;
using Microsoft.Surface.Presentation.Controls.Primitives;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WeddingzSurface {
    
    
    /// <summary>
    /// ProviderTemplate
    /// </summary>
    public partial class ProviderTemplate : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 4 "..\..\ProviderTemplate.xaml"
        internal WeddingzSurface.ProviderTemplate ProviderUserControl;
        
        #line default
        #line hidden
        
        
        #line 5 "..\..\ProviderTemplate.xaml"
        internal System.Windows.Controls.Grid ProviderGride;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\ProviderTemplate.xaml"
        internal System.Windows.Controls.Grid ProviderOverview;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\ProviderTemplate.xaml"
        internal System.Windows.Controls.Image ProviderImage;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\ProviderTemplate.xaml"
        internal System.Windows.Controls.Label ProviderName;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\ProviderTemplate.xaml"
        internal System.Windows.Controls.Grid ProviderDetail;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ProviderTemplate.xaml"
        internal System.Windows.Controls.Label ProviderNameDetail;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ProviderTemplate.xaml"
        internal System.Windows.Controls.TextBlock ProviderDescription;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ProviderTemplate.xaml"
        internal System.Windows.Controls.Label ProviderFares;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ProviderTemplate.xaml"
        internal System.Windows.Controls.Image ProviderPrincipalImage;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ProviderTemplate.xaml"
        internal Microsoft.Surface.Presentation.Controls.LibraryBar PhotoLibrary;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WeddingzSurface;component/providertemplate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProviderTemplate.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ProviderUserControl = ((WeddingzSurface.ProviderTemplate)(target));
            return;
            case 2:
            this.ProviderGride = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.ProviderOverview = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.ProviderImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.ProviderName = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.ProviderDetail = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.ProviderNameDetail = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.ProviderDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.ProviderFares = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.ProviderPrincipalImage = ((System.Windows.Controls.Image)(target));
            return;
            case 11:
            this.PhotoLibrary = ((Microsoft.Surface.Presentation.Controls.LibraryBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
