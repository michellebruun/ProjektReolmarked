using System;
using System.ComponentModel.DataAnnotations;

namespace ProjektReolmarked.Models
{
    public class Salg
    {
        public int SalgId { get; set; }

        [Required]
        public DateTime Dato { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Belob { get; set; }

        public string? Bemaerkning { get; set; }
    }
}
``
