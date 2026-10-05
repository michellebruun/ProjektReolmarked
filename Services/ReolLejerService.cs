using ProjektReolmarked.Models;
using ProjektReolmarked.Repositories;
using ProjektReolmarked.Repositories.Interfaces;
using ProjektReolmarked.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Services
{
    internal class ReolLejerService : IReolLejerService
    {
        private IReolLejerRepository reolLejerRepository;

        public ReolLejerService()
        {
            reolLejerRepository = new ReolLejerRepository();
        }

        public ReolLejer? GetReolLejerById(int reolLejerId)
        {
            return reolLejerRepository.GetReolLejerById(reolLejerId);
        }

        public IEnumerable<ReolLejer> GetAll()
        {
            return reolLejerRepository.GetAll();
        }

        public void SaveReolLejer(ReolLejer inputReolLejer)
        {
            reolLejerRepository.SaveReolLejer(inputReolLejer);
        }

        public void UpdateReolLejer(ReolLejer inputReolLejer)
        {
            reolLejerRepository.UpdateReolLejer(inputReolLejer);
        }

        public void DeleteReolLejer(int reolLejerId)
        {
            reolLejerRepository.DeleteReolLejer(reolLejerId);
        }
    }
}
//I hate everything about this project. I hate the way it makes me feel. I hate the way it makes me think. I hate the way it makes me act. I hate the way it makes me want to give up. I hate the way it makes me want to scream. REEEEEEEE