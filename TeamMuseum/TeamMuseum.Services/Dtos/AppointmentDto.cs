using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMuseum.Services.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int VisitorId { get; set; }
        public string VisitorName { get; set; }
        public int TicketId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
