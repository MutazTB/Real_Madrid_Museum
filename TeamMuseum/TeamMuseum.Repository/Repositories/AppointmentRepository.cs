using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TeamMuseum.Domain;
using TeamMuseum.Repository.Data;

namespace TeamMuseum.Repository.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly TeamMuseumDBContext _Context;
        public AppointmentRepository(TeamMuseumDBContext context)
        {
            _Context = context;
        }

        public async Task<int> Delete(Appointment appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return 0;
                }
                _Context.Entry(appointment).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
                return appointment.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<Appointment> Get(int Id)
        {
            return await _Context.Appointments.Where(C => C.Id == Id && C.IsDeleted != true).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _Context.Appointments.Where(c => c.IsDeleted != true).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllVisitorAppointments(string visitorId)
        {
            return await _Context.Appointments.Where(c => c.VisitorId == visitorId && c.IsDeleted != true).ToListAsync();
        }

        public async Task<int> Insert(Appointment appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return 0;
                }
                _Context.Entry(appointment).State = EntityState.Added;
                await _Context.SaveChangesAsync();
                return appointment.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> Update(Appointment appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return 0;
                }
                _Context.Entry(appointment).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
                return appointment.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
