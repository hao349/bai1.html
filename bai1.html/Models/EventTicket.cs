using EventTicketManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketManagement.Models
{
    public class EventTicket : IEventTicket
    {
        public int TicketId { get; }
        public string EventName { get; }
        public float TicketPrice { get; private set; }
        public int Quantity { get; private set; }
        public DateTime EventDate { get; }

        public EventTicket(int ticketId, string eventName, float ticketPrice, int quantity, DateTime eventDate)
        {
            if (string.IsNullOrWhiteSpace(eventName) || eventName.Length < 3 || eventName.Length > 100)
                throw new ArgumentException("Event name must be between 3 and 100 characters.");
            if (ticketPrice <= 0)
                throw new ArgumentException("Ticket price must be greater than 0.");
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0.");
            if (eventDate <= DateTime.Now)
                throw new ArgumentException("Event date must be in the future.");

            TicketId = ticketId;
            EventName = eventName;
            TicketPrice = ticketPrice;
            Quantity = quantity;
            EventDate = eventDate;
        }

        public virtual float CalculateTotalCost()
        {
            return TicketPrice * Quantity;
        }

        public virtual void DisplayTicketDetails()
        {
            Console.WriteLine($"Event \"{EventName}\" on {EventDate:yyyy-MM-dd}: {Quantity} tickets at ${TicketPrice} each, total = ${CalculateTotalCost()}");
        }

        public void UpdateTicket(float newPrice, int newQuantity)
        {
            if (newPrice <= 0 || newQuantity <= 0)
                throw new ArgumentException("Ticket price and quantity must be greater than 0.");
            TicketPrice = newPrice;
            Quantity = newQuantity;
        }
    }
}