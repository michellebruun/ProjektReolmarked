using ProjektReolmarked.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektReolmarked
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AfregningWindow afregningWindow = new AfregningWindow();
            afregningWindow.ShowDialog();
        }

        private void ReolLejerButton_Click(object sender, RoutedEventArgs e)
        {
            ReolLejerWindow reolLejerWindow = new ReolLejerWindow();
            reolLejerWindow.ShowDialog();
        }
    }
}