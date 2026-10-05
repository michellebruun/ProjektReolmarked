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
    public class ReolLejerViewModel : ViewModelBase
    {
        private IReolLejerService reolLejerService;

        // The list shown in the window. ObservableCollection tells the View when items are added or removed.
        public ObservableCollection<ReolLejer> ReolLejere { get; set; } = new ObservableCollection<ReolLejer>();

        // The buttons in the window
        public ICommand OpretCommand { get; set; }
        public ICommand GemCommand { get; set; }
        public ICommand SletCommand { get; set; }

        public ReolLejerViewModel()
        {
            reolLejerService = new ReolLejerService();

            OpretCommand = new RelayCommand(Opret);
            GemCommand = new RelayCommand(Gem);
            SletCommand = new RelayCommand(Slet);

            try
            {
                HentReolLejere();
            }
            catch (Exception ex)
            {
                Besked = "Kunne ikke hente reollejere: " + ex.Message;
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

                // Show the selected reollejer in the text boxes
                if (valgtReolLejer != null)
                {
                    Navn = valgtReolLejer.Navn;
                    Telefon = valgtReolLejer.Telefon;
                    Email = valgtReolLejer.Email;
                }
            }
        }

        // The three text boxes
        private string navn = "";
        public string Navn
        {
            get { return navn; }
            set { navn = value; OnPropertyChanged(); }
        }

        private string telefon = "";
        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; OnPropertyChanged(); }
        }

        private string email = "";
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }

        // Message to the user, e.g. "Anna er oprettet."
        private string besked = "";
        public string Besked
        {
            get { return besked; }
            set { besked = value; OnPropertyChanged(); }
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

        // Checks that all text boxes are filled in
        private bool FelterErUdfyldt()
        {
            if (string.IsNullOrWhiteSpace(Navn) || string.IsNullOrWhiteSpace(Telefon) || string.IsNullOrWhiteSpace(Email))
            {
                Besked = "Udfyld navn, telefon og e-mail.";
                return false;
            }
            return true;
        }

        // Create
        private void Opret()
        {
            if (!FelterErUdfyldt())
            {
                return;
            }

            ReolLejer nyReolLejer = new ReolLejer
            {
                Navn = Navn,
                Telefon = Telefon,
                Email = Email
            };

            try
            {
                reolLejerService.SaveReolLejer(nyReolLejer);
                HentReolLejere();
                Besked = nyReolLejer.Navn + " er oprettet.";
            }
            catch (Exception ex)
            {
                // E.g. the e-mail is already used by another reollejer
                Besked = "Kunne ikke oprette: " + ex.Message;
            }
        }

        // Update
        private void Gem()
        {
            if (ValgtReolLejer == null)
            {
                Besked = "Vælg en reollejer i listen først.";
                return;
            }
            if (!FelterErUdfyldt())
            {
                return;
            }

            // Same id as the selected reollejer, but with the new values from the text boxes
            ReolLejer opdateretReolLejer = new ReolLejer
            {
                ReolLejerId = ValgtReolLejer.ReolLejerId,
                Navn = Navn,
                Telefon = Telefon,
                Email = Email
            };

            try
            {
                reolLejerService.UpdateReolLejer(opdateretReolLejer);
                HentReolLejere();
                Besked = opdateretReolLejer.Navn + " er gemt.";
            }
            catch (Exception ex)
            {
                Besked = "Kunne ikke gemme: " + ex.Message;
            }
        }

        // Delete
        private void Slet()
        {
            if (ValgtReolLejer == null)
            {
                Besked = "Vælg en reollejer i listen først.";
                return;
            }

            ReolLejer slettetReolLejer = ValgtReolLejer;

            try
            {
                reolLejerService.DeleteReolLejer(slettetReolLejer.ReolLejerId);
                HentReolLejere();
                Navn = "";
                Telefon = "";
                Email = "";
                Besked = slettetReolLejer.Navn + " er slettet.";
            }
            catch (Exception ex)
            {
                Besked = "Kunne ikke slette: " + ex.Message;
            }
        }
    }
}
