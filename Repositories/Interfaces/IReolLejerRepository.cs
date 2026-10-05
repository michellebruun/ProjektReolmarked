using ProjektReolmarked.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Repositories.Interfaces
{
    internal interface IReolLejerRepository
    {
        public void SaveReollejerIdg(Reol inputReol);
        public Reol GetReollejerById(int ReolId);
        public Reol[] GetAllReollejer();
    }
}
