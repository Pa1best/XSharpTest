﻿using System;
using System.Windows;
using System.Windows.Controls;
using XRSharpSamplesGallery.Menu;

namespace XRSharpSamplesGallery
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            var menuViewModel = new MenuViewModel();
            menuViewModel.SelectionChanged += OnSelectionChanged;
            DataContext = menuViewModel;

            Loaded += (s, e) =>
            {
                menuViewModel.SelectedMenuItem = menuViewModel.MenuItems[2];
            };
        }

        private void OnSelectionChanged(object sender, Menu.MenuItem menuItem)
        {
            // Hide the panel that shows the Source Code when navigating:
            ViewSourcePane.Collapse();

            // Hide the menu when navigating if we are on mobile:
            MenuResponsivePane.CollapseIfMobile();
        }

        private void OnEnterXR(object sender, EventArgs e)
        {
            Menu3DInstance.Visibility = Visibility.Visible;
        }

        private void OnExitXR(object sender, EventArgs e)
        {
            Menu3DInstance.Visibility = Visibility.Collapsed;
        }
    }
}
