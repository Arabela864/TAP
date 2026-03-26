namespace VehicleServiceManagement.Interfaces
{
    public interface ITicketAssignable
    {
        void AssignTicket(int ticketId, int operatorId);
    }
}