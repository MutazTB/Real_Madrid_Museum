using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMuseum.Services.Dtos
{
    public class TicketDetailsDto
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Description { get; set; }
    }
}
