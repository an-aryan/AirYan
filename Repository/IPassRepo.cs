using airyan.Models;
namespace airyan.Repository
{
    public interface IPassenger<AryanPassenger>
    {
        Task<List<AryanPassenger>> GetAllPassengers();
        Task AddPassenger(AryanPassenger passenger);
        Task UpdatePassenger(int id, AryanPassenger passenger);
        Task<AryanPassenger> GetPassengerbyId(int id);
        Task DeletePassenger(int id);
    }
}