using ProjektReolmarked.Models;
using ProjektReolmarked.Repositories;
using ProjektReolmarked.Repositories.Interfaces;
using ProjektReolmarked.Services.Interfaces;

namespace ProjektReolmarked.Services
{
    internal class SalgService : ISalgService
    {
        private ISalgRepository salgRepository;

        public SalgService()
        {
            salgRepository = new SalgRepository();
        }

        public void SaveSalg(Salg inputSalg)
        {
            salgRepository.SaveSalg(inputSalg);
        }

        public Salg GetSalgById(int salgId)
        {
            return salgRepository.GetSalgById(salgId);
        }

        public Salg[] GetAllSalg()
        {
            return salgRepository.GetAllSalg();
        }
    }
}
