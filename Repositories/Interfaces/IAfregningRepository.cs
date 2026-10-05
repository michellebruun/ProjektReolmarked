using ProjektReolmarked.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Repositories.Interfaces
{
    internal interface IAfregningRepository
    {
        public void SaveAfregning(Afregning inputAfregning);
        public Afregning GetAfregningById(int afregningId);
        public Afregning[] GetAllAfregninger(); 
        
    }
}
