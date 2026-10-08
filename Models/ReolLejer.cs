using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Models
{
    public class ReolLejer
    {
        public int ReolLejerId { get; set; }
        public string Navn { get; set; } = "";
        public string Telefon { get; set; } = "";
        public string Email { get; set; } = "";

        public override string ToString()
        {
            return Navn;
        }
    }
}
