using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Models
{
    public class Afregning
    {
        public int AfregningID { get; set; }

        public int Aar { get; set; }

        public int Maaned { get; set; }
        public decimal SamletSalg { get; set; }
        public decimal KommissionProcent { get; set; }

        //SamletSalg x KommissionProcent
        public decimal KommissionBeloeb { get; set; }

        //Leje gybyr
        public decimal LejeBeloeb { get; set; }

        //Final beloeb som lejer skal betale
        public decimal BeloebTilUdbetaling { get; set; }

        // OM betaling er faerdid eller ej
        public bool Status { get; set; }
}
}
