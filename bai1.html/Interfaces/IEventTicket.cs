using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketManagement.Interfaces
{
    public interface IEventTicket
    {
        float CalculateTotalCost();
        void DisplayTicketDetails();
    }
}