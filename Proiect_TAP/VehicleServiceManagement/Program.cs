using System;
using VehicleServiceManagement.Models;
using VehicleServiceManagement.Services;

namespace VehicleServiceManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Vehicle Service Ticket Management System ===\n");
            
            var ticketService = new TicketService();
            
            ticketService.DisplayAllUsers();
            
            Console.WriteLine("\n=== Regular User Actions ===");
            var regularUser = (RegularUser)ticketService.GetUser(1)!;
            var newTicket = regularUser.CreateTicket("Toyota Camry 2020", "Engine making strange noise");
            ticketService.AddTicket(newTicket);
            
            Console.WriteLine("\n=== Operator Actions ===");
            var operator1 = (OperatorUser)ticketService.GetUser(2)!;
            operator1.AssignTicket(newTicket.TicketId, operator1.UserId);
            operator1.ProvideDiagnosis(newTicket.TicketId, "Faulty spark plugs", 250.00m);
            
            var ticket = ticketService.GetTicket(newTicket.TicketId);
            ticket?.SetDiagnosis("Faulty spark plugs", 250.00m, operator1.UserId);
            
            Console.WriteLine("\n=== Regular User Final Actions ===");
            regularUser.AcceptDiagnosis(newTicket.TicketId);
            regularUser.PayServices(newTicket.TicketId, 250.00m);
            
            ticket?.IsPaid = true;
            
            Console.WriteLine("\n=== Operator Closing Ticket ===");
            operator1.CloseTicket(newTicket.TicketId);
            ticket?.Status = TicketStatus.Closed;
            ticket?.ClosedDate = DateTime.Now;
            
            ticketService.ListAllTickets();
            
            Console.WriteLine("\n=== System Demonstration Complete ===");
        }
    }
}