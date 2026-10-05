using ProjektReolmarked.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Repositories.Interfaces
{
    internal interface ILejeRepository
    {
       public void SaveLeje(Leje inputLeje);
       public Leje GetLejeById(int lejeId);
       public Leje[] GetAllLeje();

    }
}
