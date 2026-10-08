using ProjektReolmarked.Models;
using ProjektReolmarked.Services;
using ProjektReolmarked.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ProjektReolmarked.ViewModel
{
    public class AfregningViewModel : ViewModelBase
    {
        private IReolLejerService reolLejerService;
        private IAfregningService afregningService;

        // The list shown in the window. ObservableCollection tells the View when items are added or removed.
        public ObservableCollection<ReolLejer> ReolLejere { get; set; } = new ObservableCollection<ReolLejer>();

        // The list of afregninger shown in the list
        public ObservableCollection<Afregning> Afregninger { get; set; } = new ObservableCollection<Afregning>();

        // The buttons in the window
        public ICommand OpretCommand { get; set; }

        public AfregningViewModel()
        {
            reolLejerService = new ReolLejerService();
            afregningService = new AfregningService();

            OpretCommand = new RelayCommand(OpretAfregning);

            try
            {
                HentReolLejere();
            }
            catch (Exception ex)
            {
                Besked = "Kunne ikke hente reollejere: " + ex.Message;
            }

            try
            {
                HentAfregninger();
            }
            catch (Exception ex)
            {
                Besked = "Kunne ikke hente afregninger: " + ex.Message;
            }
        }

        // The reollejer selected in the list
        private ReolLejer? valgtReolLejer;
        public ReolLejer? ValgtReolLejer
        {
            get { return valgtReolLejer; }
            set
            {
                valgtReolLejer = value;
                OnPropertyChanged();
            }
        }

        // The three text boxes
        private string aar = "";
        public string Aar
        {
            get { return aar; }
            set { aar = value; OnPropertyChanged(); }
        }

        private string maaned = "";
        public string Maaned
        {
            get { return maaned; }
            set { maaned = value; OnPropertyChanged(); }
        }

        private string samletSalg = "";
        public string SamletSalg
        {
            get { return samletSalg; }
            set { samletSalg = value; OnPropertyChanged(); }
        }

        private string besked = "";
        public string Besked
        {
            get { return besked; }
            set { besked = value; OnPropertyChanged(); }
        }

        private int lejerReolAntal = 1;
        public int LejerReolAntal
        {
            get { return lejerReolAntal; }
            set { lejerReolAntal = value; OnPropertyChanged(); }
        }

        // Gets all reollejere from the database and puts them in the list
        private void HentReolLejere()
        {
            ReolLejere.Clear();
            foreach (ReolLejer reolLejer in reolLejerService.GetAll())
            {
                ReolLejere.Add(reolLejer);
            }
        }

        private void HentAfregninger()
        {
            Afregninger.Clear();
            foreach (Afregning afregning in afregningService.GetAll())
            {
                Afregninger.Add(afregning);
            }
        }

        // Checks that all text boxes are filled in
        private bool FelterErUdfyldt()
        {
            if(ValgtReolLejer == null)
            {
                Besked = "Du skal vælge en reollejer for at kunne fortsætte";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Aar) || string.IsNullOrWhiteSpace(Maaned) || string.IsNullOrWhiteSpace(SamletSalg))
            {
                Besked = "År, måned og samlet beløb skal udfyldes for at kunne fortsætte";
                return false;
            }
            return true;
        }

        // Create
        private void OpretAfregning()
        {
            if (!FelterErUdfyldt())
            {
                return;
            }
            decimal samletSalgTotal = decimal.Parse(samletSalg);
            decimal kommision = 0.1M;
            int lejebeloeb = 850;
            if (lejerReolAntal >= 2 && lejerReolAntal <= 3)
            {
                lejebeloeb = 825;
            }
            else if (lejerReolAntal > 3)
            {
                lejebeloeb = 800;
            }

            decimal komissionsbeloeb = (samletSalgTotal * kommision);
            Afregning nyAfregning = new Afregning
            {
                Aar = int.Parse(Aar),
                Maaned = int.Parse(Maaned),
                SamletSalg = samletSalgTotal,
                KommissionProcent = kommision,
                KommissionBeloeb = komissionsbeloeb,
                LejeBeloeb = lejebeloeb,
                BeloebTilUdbetaling = samletSalgTotal - komissionsbeloeb - lejebeloeb,
                Status = true,
            };

            try
            {
                afregningService.SaveAfregning(nyAfregning);
                HentAfregninger();
            }
            catch (Exception ex)
            {
                Besked = "Kunne ikke oprette afregning: " + ex.Message;
            }
        }
    }
}
