using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketManagement.Models
{
    public class VIPEventTicket : EventTicket
    {
        private const float DefaultVipChargeRate = 20f;
        public float VipChargeRate { get; }

        public VIPEventTicket(int ticketId, string eventName, float ticketPrice, int quantity, DateTime eventDate, float vipChargeRate = DefaultVipChargeRate)
            : base(ticketId, eventName, ticketPrice, quantity, eventDate)
        {
            if (vipChargeRate < 0)
                throw new ArgumentException("VIP charge rate cannot be negative.");
            VipChargeRate = vipChargeRate;
        }

        public override float CalculateTotalCost()
        {
            return base.CalculateTotalCost() * (1 + VipChargeRate / 100);
        }

        public override void DisplayTicketDetails()
        {
            Console.WriteLine($"VIP Event \"{EventName}\" on {EventDate:yyyy-MM-dd}: {Quantity} tickets at ${TicketPrice} each, total = ${CalculateTotalCost()}");
        }
    }
}