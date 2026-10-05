using ProjektReolmarked.Models;
using ProjektReolmarked.Services;
using ProjektReolmarked.Services.Interfaces;
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
        private IAfregningService _afregningService;
        public AfregningWindow()
        {
            InitializeComponent();
            _afregningService = new AfregningService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Afregning afregning = new Afregning()
            {
                Aar = 2026,
                Maaned = 10,
                SamletSalg = 10000,
                KomminsionProcent = 0.1M,
                KomminsionBeloeb = 1000,
                LejeBeloeb = 800,
                BeloebTilUdbetaling = 8200,
                Status = true,
            };
            _afregningService.SaveAfregning(afregning);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Afregning> afregninger = _afregningService.GetAll().ToList();
        }
    }
}
