using ProjektReolmarked.Models;

namespace ProjektReolmarked.Services.Interfaces
{
    internal interface ISalgService
    {
        public void SaveSalg(Salg inputSalg);
        public Salg GetSalgById(int salgId);
        public Salg[] GetAllSalg();
    }
}
