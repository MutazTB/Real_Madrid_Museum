using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamMuseum.Domain;

namespace TeamMuseum.Repository.Repositories
{
    public interface ITicketDetailsRepository : IBaseRepository<TicketDetails>
    {
        Task<int> AddRange(IEnumerable<TicketDetails> list);
    }
}
