using ProjektReolmarked.ViewModel;
using System.Windows;

namespace ProjektReolmarked.View
{
    public partial class UdlejWindow : Window
    {
        public UdlejWindow()
        {
            InitializeComponent();

            DataContext = new UdlejViewModel();
        }
    }
}