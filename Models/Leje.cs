using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Models
{
    public class Leje
    {
        public int LejeId { get; set; }

        public int ReolId { get; set; }

        public int ReolLejerId { get; set; }

        public DateOnly StartDato { get; set; }

        public DateOnly SlutDato { get; set; }

        public decimal MaanedligLeje { get; set; }

        public bool Status { get; set; }
    }
}
