using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMuseum.Domain
{
    public class TicketDetails : Entity
    {
        public int TicketId { get; set; }
        public string Description { get; set; }
        public Ticket Ticket { get; set; }
    }
}
