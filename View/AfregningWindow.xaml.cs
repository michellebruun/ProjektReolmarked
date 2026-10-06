using ProjektReolmarked.Models;
using ProjektReolmarked.Services;
using ProjektReolmarked.Services.Interfaces;
using ProjektReolmarked.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektReolmarked.View
{
    /// <summary>
    /// Interaction logic for AfregningWindow.xaml
    /// </summary>
    public partial class AfregningWindow : Window
    {
        public AfregningWindow()
        {
            InitializeComponent();
            DataContext = new AfregningViewModel();
        }
    }
}
