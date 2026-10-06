using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Models
{
    internal class Leje
    {
        public int LejeId { get; set; }
        public DateOnly StartDato { get; set; }
        public DateOnly SlutDato { get; set; }
        public float MaanedligLeje { get; set; }
        public bool Status { get; set; }
    }
}
