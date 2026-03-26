namespace VehicleServiceManagement.Interfaces
{
    public interface IPayable
    {
        void PayServices(int ticketId, decimal amount);
    }
}