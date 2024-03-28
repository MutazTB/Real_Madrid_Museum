using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamMuseum.Domain;
using TeamMuseum.Services.Dtos;

namespace TeamMuseum.Services.Mapper
{
    public class AppointmentMapper : Profile
    {
        public AppointmentMapper() 
        {
            CreateMap<Appointment , AppointmentDto>();
            CreateMap<AppointmentDto , Appointment>();
        }
    }
}
