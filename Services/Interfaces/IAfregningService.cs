using ProjektReolmarked.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Services.Interfaces
{
    internal interface IAfregningService
    {

            public void SaveAfregning(Afregning inputAfregning);
            public Afregning GetAfregningById(int afregningId);
            public IEnumerable<Afregning> GetAll();
 
    }
}
