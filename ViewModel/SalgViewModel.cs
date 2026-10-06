using ProjektReolmarked.Models;
using ProjektReolmarked.Services;
using ProjektReolmarked.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjektReolmarked.ViewModel
{
    internal class SalgViewModel : ViewModelBase
    {
        private ISalgService salgService;

        public ObservableCollection<Salg> SalgListe { get; set; } = new ObservableCollection<Salg>();

        public ICommand GemCommand { get; set; }

        public SalgViewModel()
        {
            salgService = new SalgService();

            GemCommand = new RelayCommand(Gem);

            HentSalg();
        }

        private DateTime dato = DateTime.Now;
        public DateTime Dato
        {
            get => dato;
            set
            {
                dato = value;
                OnPropertyChanged();
            }
        }

        private decimal belob;
        public decimal Belob
        {
            get => belob;
            set
            {
                belob = value;
                OnPropertyChanged();
            }
        }

        private string? bemaerkning;
        public string? Bemaerkning
        {
            get => bemaerkning;
            set
            {
                bemaerkning = value;
                OnPropertyChanged();
            }
        }

        private string besked = "";
        public string Besked
        {
            get => besked;
            set
            {
                besked = value;
                OnPropertyChanged();
            }
        }

        private void HentSalg()
        {
            SalgListe.Clear();

            foreach (Salg salg in salgService.GetAllSalg())
            {
                SalgListe.Add(salg);
            }
        }

        private void Gem()
        {
            Salg nytSalg = new Salg
            {
                Dato = Dato,
                Belob = Belob,
                Bemaerkning = Bemaerkning
            };

            salgService.SaveSalg(nytSalg);

            HentSalg();

            Besked = "Salg gemt.";
        }
    }
}
