using ProjektReolmarked.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Repositories.Interfaces
{
    internal interface IReolRepository
    {
        public void SaveReol(Reol inputReol);
        public Reol GetReolById(int ReolId);
        public Reol[] GetAllReoler();
    }
}
