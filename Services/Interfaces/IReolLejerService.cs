using ProjektReolmarked.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Services.Interfaces
{
    internal interface IReolLejerService
    {
        public void SaveReolLejer(ReolLejer inputReolLejer);
        public ReolLejer? GetReolLejerById(int reolLejerId);
        public IEnumerable<ReolLejer> GetAll();
        public void UpdateReolLejer(ReolLejer inputReolLejer);
        public void DeleteReolLejer(int reolLejerId);
    }
}
