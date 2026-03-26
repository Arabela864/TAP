using System;

namespace VehicleServiceManagement.Models
{
    public class Ticket
    {
        private decimal _serviceCost;
        private bool _isPaid;

        public int TicketId { get; set; }
        public string? VehicleModel { get; set; }
        public string? IssueDescription { get; set; }
        public string? Diagnosis { get; private set; }
        public int CreatedByUserId { get; set; }
        public int? AssignedOperatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DiagnosedDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public TicketStatus Status { get; set; }

        public decimal ServiceCost
        {
            get => _serviceCost;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Cost cannot be negative");
                _serviceCost = value;
            }
        }

        public bool IsPaid
        {
            get => _isPaid;
            set
            {
                if (value && !_isPaid)
                    Console.WriteLine($"Ticket #{TicketId} marked as paid");
                _isPaid = value;
            }
        }

        public void SetDiagnosis(string diagnosis, decimal cost, int operatorId)
        {
            if (string.IsNullOrWhiteSpace(diagnosis))
                throw new ArgumentException("Diagnosis cannot be empty");
                
            Diagnosis = diagnosis;
            ServiceCost = cost;
            AssignedOperatorId = operatorId;
            DiagnosedDate = DateTime.Now;
            Status = TicketStatus.Diagnosed;
        }
    }
}