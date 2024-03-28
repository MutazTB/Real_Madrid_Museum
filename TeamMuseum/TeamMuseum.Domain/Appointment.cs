using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMuseum.Domain
{
    public class Appointment : Entity
    {
        public string VisitorId { get; set; }
        public string VisitorName { get; set; }
        public int TicketId { get; set; }
        public DateTime AppointmentDate { get; set; }

    }
}
