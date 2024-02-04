namespace airyan.Service
{
    public interface IPassServ<AryanPassenger>
    {
        Task<List<AryanPassenger>> GetAllPassengers();
        Task AddPassenger(AryanPassenger passenger);
        Task UpdatePassenger(int id, AryanPassenger passenger);
        Task<AryanPassenger> GetPassengerbyId(int id);
        Task DeletePassenger(int id);

        string Message(string name)
        {
            return "Hello" + name;
        }
    }
}