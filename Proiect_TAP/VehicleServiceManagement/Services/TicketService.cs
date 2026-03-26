using System;
using System.Collections.Generic;
using System.Linq;
using VehicleServiceManagement.Models;

namespace VehicleServiceManagement.Services
{
    public class TicketService
    {
        private List<Ticket> _tickets = new List<Ticket>();
        private List<User> _users = new List<User>();

        public TicketService()
        {
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            _users.Add(new RegularUser(1, "John Doe", "john@email.com"));
            _users.Add(new OperatorUser(2, "Jane Smith", "jane@email.com", "Mechanical"));
            _users.Add(new OperatorUser(3, "Bob Wilson", "bob@email.com", "Electrical"));
        }

        public void AddTicket(Ticket ticket)
        {
            _tickets.Add(ticket);
            Console.WriteLine($"Ticket #{ticket.TicketId} added to system");
        }

        public Ticket? GetTicket(int ticketId)
        {
            return _tickets.FirstOrDefault(t => t.TicketId == ticketId);
        }

        public void ListAllTickets()
        {
            Console.WriteLine("\n=== All Tickets ===");
            foreach (var ticket in _tickets)
            {
                Console.WriteLine($"#{ticket.TicketId} - {ticket.VehicleModel} - Status: {ticket.Status}");
            }
        }

        public User? GetUser(int userId)
        {
            return _users.FirstOrDefault(u => u.UserId == userId);
        }

        public void DisplayAllUsers()
        {
            Console.WriteLine("\n=== System Users ===");
            foreach (var user in _users)
            {
                Console.WriteLine($"#{user.UserId} - {user.Name} ({user.Role})");
                user.DisplayPermissions();
                Console.WriteLine("---");
            }
        }
    }
}