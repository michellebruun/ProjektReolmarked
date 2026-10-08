using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

using System.ComponentModel;

namespace ProjektReolmarked.Models
{
    public class Reol : INotifyPropertyChanged
    {
        private bool _status;
        private int? _reolLejerId;
        private string? _type;

        public int ReolId { get; set; }

        public int Placering { get; set; }

        public bool Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public int? ReolLejerId
        {
            get => _reolLejerId;
            set
            {
                _reolLejerId = value;
                OnPropertyChanged(nameof(ReolLejerId));
            }
        }

        public string? Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }
    }
}