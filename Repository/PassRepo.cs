using airyan.Models;
using Microsoft.EntityFrameworkCore;
namespace airyan.Repository{
    public class PassRepository : IPassenger<AryanPassenger>
    {
        private readonly Ace52024Context db;
        // public PassRepository(){}
        public PassRepository(Ace52024Context _db)
        {
            db =_db;
        }
        public async Task AddPassenger(AryanPassenger passenger)
        {
            db.AryanPassengers.Add(passenger);
            await db.SaveChangesAsync();
        }

        public async Task DeletePassenger(int id)
        {
            AryanPassenger? passenger =await db.AryanPassengers.FindAsync(id);
            db.AryanPassengers.Remove(passenger);
            await db.SaveChangesAsync();
        }

        public async Task<List<AryanPassenger>> GetAllPassengers()
        {
            return await db.AryanPassengers.ToListAsync();
        }

        public async Task<AryanPassenger> GetPassengerbyId(int id)
        {
            return await db.AryanPassengers.FindAsync(id);
        }

        public async Task UpdatePassenger(int id, AryanPassenger passenger)
        {
            db.AryanPassengers.Update(passenger);
            await db.SaveChangesAsync();
        }
    }
}