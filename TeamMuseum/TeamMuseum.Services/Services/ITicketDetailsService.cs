using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamMuseum.Domain;
using TeamMuseum.Services.Dtos;

namespace TeamMuseum.Services.Services
{
    public interface ITicketDetailsService : IBaseService<TicketDetailsDto>
    {
        Task<int> AddRange(IEnumerable<TicketDetailsDto> list);
    }
}
