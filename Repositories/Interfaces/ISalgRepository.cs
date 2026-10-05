using ProjektReolmarked.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Repositories.Interfaces
{
    internal interface ISalgRepository
    {
        public void SaveSalg(Salg inputSalg);
        public Salg GetSalgById(int salgId);
        public Salg[] GetAllSalg();
    }
}
