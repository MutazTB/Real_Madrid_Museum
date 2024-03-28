using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMuseum.Services.Dtos
{
    public class TicketDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public double Price { get; set; }
        
        public string Description { get; set; }

        public List<TicketDetailsDto> TicketDetails { get; set; }

    }
}
