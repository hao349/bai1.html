using EventTicketManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketManagement.Services
{
    public class TicketManager
    {
        private List<EventTicket> tickets = new();

        public void AddTicket(EventTicket ticket)
        {
            tickets.Add(ticket);
            Console.WriteLine("Ticket added successfully!");
        }

        public void ViewTickets()
        {
            if (tickets.Count == 0)
            {
                Console.WriteLine("No tickets available.");
                return;
            }

            foreach (var ticket in tickets)
            {
                ticket.DisplayTicketDetails();
            }
        }

        public void UpdateTicket(int ticketId, float newPrice, int newQuantity)
        {
            var ticket = tickets.FirstOrDefault(t => t.TicketId == ticketId);
            if (ticket == null)
            {
                Console.WriteLine("Ticket ID not found.");
                return;
            }

            ticket.UpdateTicket(newPrice, newQuantity);
            Console.WriteLine("Ticket updated successfully.");
        }

        public void DeleteTicket(int ticketId)
        {
            var ticket = tickets.FirstOrDefault(t => t.TicketId == ticketId);
            if (ticket == null)
            {
                Console.WriteLine("Ticket ID not found.");
                return;
            }

            tickets.Remove(ticket);
            Console.WriteLine("Ticket deleted successfully.");
        }

        public void CalculateTotalCost(int ticketId)
        {
            var ticket = tickets.FirstOrDefault(t => t.TicketId == ticketId);
            if (ticket == null)
            {
                Console.WriteLine("Ticket ID not found.");
                return;
            }

            Console.WriteLine($"Total cost for ticket ID {ticketId}: ${ticket.CalculateTotalCost()}");
        }
    }
}
