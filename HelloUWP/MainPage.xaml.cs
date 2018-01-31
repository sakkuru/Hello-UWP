﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace HelloUWP
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public string DeviceFamily = "Device Family: " + AnalyticsInfo.VersionInfo.DeviceFamily;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Dimensions { get; set; } = "Initial Value";
        private double _currentWidth;
        private double _currentHeight;
        public MainPage()
        {
            this.InitializeComponent();
            this.SizeChanged += MainPage_SizeChanged;
        }

        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _currentWidth = Window.Current.Bounds.Width;
            _currentHeight = Window.Current.Bounds.Height;
            Dimensions = string.Format("Current Window Size: {0} x {1}", (int)_currentWidth, (int)_currentHeight);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Dimensions)));
            }
        }
    }
}
