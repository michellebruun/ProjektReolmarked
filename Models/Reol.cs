using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ProjektReolmarked.Models
{
    public class Reol
    {
        public int ReolID { get; set; }

        public int Placering { get; set; }

        public bool Status { get; set; }

        public string ToFileString()
        {
            return $"{ReolID};{Placering};{Status}";
        }

        public static Reol FromFileString(string line)
        {
            string[] values = line.Split(';');
            return new Reol
            {
                ReolID = int.Parse(values[0]),
                Placering = int.Parse(values[1]),
                Status = bool.Parse(values[2])
            };
        }
    }
}
