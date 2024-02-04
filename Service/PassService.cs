using airyan.Models;
using airyan.Repository;

namespace airyan.Service
{
    public class PassServ : IPassServ<AryanPassenger>
    {
        private readonly IPassenger<AryanPassenger> passrepo;
        // public PassServ(){}
        public PassServ(IPassenger<AryanPassenger> _passrepo)
        {
            passrepo = _passrepo;
        }
        public async Task AddPassenger(AryanPassenger passenger)
        {
            await passrepo.AddPassenger(passenger);
        }

        public async Task DeletePassenger(int id)
        {
           await  passrepo.DeletePassenger(id);
        }

        public async Task<List<AryanPassenger>> GetAllPassengers()
        {
            return await passrepo.GetAllPassengers();
        }

        public async Task<AryanPassenger> GetPassengerbyId(int id)
        {
            return await passrepo.GetPassengerbyId(id);
        }

        public async Task UpdatePassenger(int id, AryanPassenger passenger)
        {
            await passrepo.UpdatePassenger(id, passenger);
        }
    }
}