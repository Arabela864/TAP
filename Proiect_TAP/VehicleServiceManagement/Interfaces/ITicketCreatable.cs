using VehicleServiceManagement.Models;

namespace VehicleServiceManagement.Interfaces
{
    public interface ITicketCreatable
    {
        Ticket CreateTicket(string vehicleModel, string issueDescription);
    }
}