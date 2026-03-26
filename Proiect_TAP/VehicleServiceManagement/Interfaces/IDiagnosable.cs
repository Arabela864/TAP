namespace VehicleServiceManagement.Interfaces
{
    public interface IDiagnosable
    {
        void ProvideDiagnosis(int ticketId, string diagnosis, decimal cost);
    }
}