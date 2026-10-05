using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Models
{
    internal class Afregning
    {
        public int AfregningID { get; set; }

        public int Aar { get; set; }

        public int Maaned { get; set; }
        public decimal SamletSalg { get; set; }
        public decimal KomminsionProcent { get; set; }

        //SamletSalg x KommissionProcent
        public decimal KomminsionBeloeb { get; set; }

        //Leje gybyr
        public decimal LejeBeloeb { get; set; }

        //Final beloeb som lejer skal betale
        public decimal BeloebTilUdbetaling { get; set; }

        // OM betaling er faerdid eller ej
        public bool Status { get; set; }
}
}
