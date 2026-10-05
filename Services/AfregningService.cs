using ProjektReolmarked.Models;
using ProjektReolmarked.Repositories;
using ProjektReolmarked.Repositories.Interfaces;
using ProjektReolmarked.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Services
{
    internal class AfregningService : IAfregningService
    {
        private IAfregningRepository afregningRepository;

        public AfregningService()
        {
            //Need connection string -> add in repository
            afregningRepository = new AfregningRepository();
        }

        public Afregning GetAfregningById(int afregningId)
        {
            return afregningRepository.GetAfregningById(afregningId);
        }

        public IEnumerable<Afregning> GetAll()
        {
            return afregningRepository.GetAll();
        }

        public void SaveAfregning(Afregning inputAfregning)
        {
            afregningRepository.SaveAfregning(inputAfregning);
        }
    }
}
