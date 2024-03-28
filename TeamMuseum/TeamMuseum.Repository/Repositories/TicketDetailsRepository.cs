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
    public class TicketDetailsRepository : ITicketDetailsRepository
    {
        private readonly TeamMuseumDBContext _Context;
        public TicketDetailsRepository(TeamMuseumDBContext context)
        {
            _Context = context;
        }
        public async Task<int> Delete(TicketDetails ticketDetails)
        {
            int result = 0;
            try
            {
                if (ticketDetails == null)
                {
                    return result;
                }
                _Context.Entry(ticketDetails).State = EntityState.Modified;
                result = await _Context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public async Task<TicketDetails> Get(int Id)
        {
            return await _Context.TicketDetails.Where(C => C.Id == Id && C.IsDeleted != true).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TicketDetails>> GetAll()
        {
            return await _Context.TicketDetails.Where(c => c.IsDeleted != true).ToListAsync();
        }

        public async Task<int> Insert(TicketDetails ticketDetails)
        {
            int result = 0;
            try
            {
                if (ticketDetails == null)
                {
                    return result;
                }
                _Context.Entry(ticketDetails).State = EntityState.Added;
                result = await _Context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public async Task<int> Update(TicketDetails ticketDetails)
        {
            int result = 0;
            try
            {
                if (ticketDetails == null)
                {
                    return result;
                }
                _Context.Entry(ticketDetails).State = EntityState.Modified;
                result = await _Context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public async Task<int> AddRange(IEnumerable<TicketDetails> list)
        {
            await _Context.AddRangeAsync(list);
            var result = await _Context.SaveChangesAsync();
            return result;
        }
        
    }
}
