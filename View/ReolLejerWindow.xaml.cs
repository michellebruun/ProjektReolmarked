using ProjektReolmarked.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjektReolmarked.View
{
    /// <summary>
    /// Interaction logic for ReolLejerWindow.xaml
    /// </summary>
    public partial class ReolLejerWindow : Window
    {
        public ReolLejerWindow()
        {
            InitializeComponent();

            // Connects the window to the ViewModel, so {Binding ...} in the XAML can find its properties
            DataContext = new ReolLejerViewModel();
        }
    }
}
