using System;
using VehicleServiceManagement.Interfaces;

namespace VehicleServiceManagement.Models
{
    public abstract class User
    {
        private int _userId;
        private string _name;
        private string _email;
        private UserRole _role;

        public int UserId 
        { 
            get => _userId; 
            private set => _userId = value; 
        }
        
        public string Name 
        { 
            get => _name; 
            set => _name = value; 
        }
        
        public string Email 
        { 
            get => _email; 
            set => _email = value; 
        }
        
        public UserRole Role 
        { 
            get => _role; 
            protected set => _role = value; 
        }

        protected User(int userId, string name, string email, UserRole role)
{
    UserId = userId;
  
    _name = name ?? throw new ArgumentNullException(nameof(name));
    _email = email ?? throw new ArgumentNullException(nameof(email)); 
    Role = role;
}

        public abstract void DisplayPermissions();
    }

    public class RegularUser : User, ITicketCreatable, IDiagnosisAcceptable, IPayable
    {
        public RegularUser(int userId, string name, string email) 
            : base(userId, name, email, UserRole.Regular)
        {
        }

        public Ticket CreateTicket(string vehicleModel, string issueDescription)
        {
            var ticket = new Ticket
            {
                TicketId = new Random().Next(1000, 9999),
                VehicleModel = vehicleModel,
                IssueDescription = issueDescription,
                CreatedByUserId = this.UserId,
                CreatedDate = DateTime.Now,
                Status = TicketStatus.Open
            };
            
            Console.WriteLine($"Ticket #{ticket.TicketId} created successfully!");
            return ticket;
        }

        public void AcceptDiagnosis(int ticketId)
        {
            Console.WriteLine($"User {Name} accepted diagnosis for ticket #{ticketId}");
        }

        public void PayServices(int ticketId, decimal amount)
        {
            Console.WriteLine($"User {Name} paid ${amount} for ticket #{ticketId}");
        }

        public override void DisplayPermissions()
        {
            Console.WriteLine("Regular User Permissions: Create Ticket, Accept Diagnosis, Pay Services");
        }
    }

    public class OperatorUser : User, ITicketAssignable, IDiagnosable, ITicketClosable
    {
        public string Department { get; set; }
        
        public OperatorUser(int userId, string name, string email, string department) 
            : base(userId, name, email, UserRole.Operator)
        {
            Department = department;
        }

        public void AssignTicket(int ticketId, int operatorId)
        {
            Console.WriteLine($"Ticket #{ticketId} assigned to operator #{operatorId}");
        }

        public void ProvideDiagnosis(int ticketId, string diagnosis, decimal cost)
        {
            Console.WriteLine($"Operator {Name} provided diagnosis for ticket #{ticketId}: {diagnosis}, Cost: ${cost}");
        }

        public void CloseTicket(int ticketId)
        {
            Console.WriteLine($"Operator {Name} closed ticket #{ticketId}");
        }

        public override void DisplayPermissions()
        {
            Console.WriteLine("Operator Permissions: Assign Ticket, Provide Diagnosis, Close Ticket");
        }
    }
}