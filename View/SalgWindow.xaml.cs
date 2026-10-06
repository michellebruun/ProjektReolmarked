using ProjektReolmarked.Models;
using ProjektReolmarked.Services;
using ProjektReolmarked.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ProjektReolmarked.View
{
    public partial class SalgWindow : Window
    {
        private ISalgService _salgService;

        public SalgWindow()
        {
            InitializeComponent();
            _salgService = new SalgService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Salg salg = new Salg()
            {
                Dato = DateTime.Now,
                Belob = 100,
                Bemaerkning = "Test salg"
            };

            _salgService.SaveSalg(salg);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Salg[] salg = _salgService.GetAllSalg();
        }
    }
}
