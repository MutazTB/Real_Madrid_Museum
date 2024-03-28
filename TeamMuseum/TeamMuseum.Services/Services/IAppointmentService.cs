using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamMuseum.Services.Dtos;

namespace TeamMuseum.Services.Services
{
    public interface IAppointmentService : IBaseService<AppointmentDto>
    {
        Task<IEnumerable<AppointmentDto>> GetAllVisitorAppointments(string visitorId);
    }
}
