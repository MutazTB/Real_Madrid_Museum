using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamMuseum.Domain;
using TeamMuseum.Repository.Data;

namespace TeamMuseum.Repository.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TeamMuseumDBContext _Context;
        public TicketRepository(TeamMuseumDBContext context ) 
        {
            _Context = context;
        }
        public async Task<int> Delete(Ticket ticket)
        {
            try
            {
                if (ticket == null)
                {
                    return 0;
                }
                _Context.Entry(ticket).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
                return ticket.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<Ticket> Get(int Id)
        {
            return await _Context.Tickets.Where(C => C.Id == Id && C.IsDeleted != true).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _Context.Tickets.Where(c => c.IsDeleted != true).ToListAsync();
        }

        public async Task<int> Insert(Ticket ticket)
        {
            try
            {
                if (ticket == null)
                {
                    return 0;
                }
                _Context.Entry(ticket).State = EntityState.Added;
                await _Context.SaveChangesAsync();
                return ticket.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> Update(Ticket ticket)
        {
            try
            {
                if (ticket == null)
                {
                    return 0;
                }
                _Context.Entry(ticket).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
                return ticket.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
