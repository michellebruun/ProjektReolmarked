using ProjektReolmarked.Models;
using ProjektReolmarked.Repositories;
using ProjektReolmarked.Repositories.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;

namespace ProjektReolmarked.ViewModel
{
    internal class UdlejViewModel : INotifyPropertyChanged
    {
        private readonly IReolRepository _reolRepository;
        private readonly IReolLejerRepository _reolLejerRepository;

        private Reol? _valgtReol;

        public ObservableCollection<Reol> Reoler { get; set; }

        public ObservableCollection<ReolLejer> ReolLejere { get; set; }

        public bool VisUdlejetInfo => ValgtReol?.Status == true;

        public Reol? ValgtReol
        {
            get => _valgtReol;
            set
            {
                _valgtReol = value;

                OnPropertyChanged(nameof(ValgtReol));
                OnPropertyChanged(nameof(VisForm));
                OnPropertyChanged(nameof(VisUdlejetInfo));
                OnPropertyChanged(nameof(ValgtReolLejerInfo));
            }
        }

        public bool VisForm => ValgtReol != null;

        public string[] ReolTyper { get; } =
        {
            "Reol med 6 hylder",
            "Reol med 3 hylder + bøjlestang"
        };

        public ICommand VaelgReolCommand { get; }

        public ICommand UdlejCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public UdlejViewModel()
        {
            _reolRepository = new ReolRepository();
            _reolLejerRepository = new ReolLejerRepository();

            Reoler = new ObservableCollection<Reol>(
                _reolRepository.GetAllReoler()
            );

            ReolLejere = new ObservableCollection<ReolLejer>(
                _reolLejerRepository.GetAll()
            );

            VaelgReolCommand = new RelayCommand(parameter =>
            {
                if (parameter is Reol reol)
                {
                    if (!reol.Status && reol.Type == null)
                    {
                        reol.Type = "Reol med 6 hylder";
                    }

                    ValgtReol = reol;
                }
            });

            UdlejCommand = new RelayCommand(Udlej);
        }

        private void Udlej()
        {
            if (ValgtReol == null)
            {
                return;
            }

            if (ValgtReol.ReolLejerId == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(ValgtReol.Type))
            {
                return;
            }

            ValgtReol.Status = true;

            _reolRepository.UpdateReol(ValgtReol);
            ValgtReol = null;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }

        public string ValgtReolLejerInfo
        {
            get
            {
                if (ValgtReol?.ReolLejerId == null)
                {
                    return "";
                }

                ReolLejer? reolLejer = ReolLejere
                    .FirstOrDefault(r => r.ReolLejerId == ValgtReol.ReolLejerId);

                if (reolLejer == null)
                {
                    return ValgtReol.ReolLejerId.ToString();
                }

                return $"{reolLejer.ReolLejerId} - {reolLejer.Navn}";
            }
        }

    }
}