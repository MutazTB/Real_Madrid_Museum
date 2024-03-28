using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamMuseum.Domain;
using TeamMuseum.Repository.Repositories;
using TeamMuseum.Services.Dtos;

namespace TeamMuseum.Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _AppointmentRepository;
        private IMapper _Mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _AppointmentRepository = appointmentRepository;
            _Mapper = mapper;
        }

        public async Task<int> Delete(AppointmentDto appointmentDto)
        {
            var AppointmentToBeDeleted = _Mapper.Map<Appointment>(appointmentDto);
            return await _AppointmentRepository.Delete(AppointmentToBeDeleted);
        }

        public async Task<AppointmentDto> Get(int id)
        {
            var result = await _AppointmentRepository.Get(id);
            return _Mapper.Map<AppointmentDto>(result);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAll()
        {
            var result = await _AppointmentRepository.GetAll();
            return _Mapper.Map<List<AppointmentDto>>(result);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllVisitorAppointments(string visitorId)
        {
            var result = await _AppointmentRepository.GetAllVisitorAppointments(visitorId);
            return _Mapper.Map<List<AppointmentDto>>(result);
        }

        public async Task<int> Insert(AppointmentDto appointmentDto)
        {
            var appointmentToBeAdded = _Mapper.Map<Appointment>(appointmentDto);
            return await _AppointmentRepository.Insert(appointmentToBeAdded);
        }

        public async Task<int> Update(AppointmentDto appointmentDto)
        {
            var appointmentToBeUpdated = _Mapper.Map<Appointment>(appointmentDto);
            return await _AppointmentRepository.Update(appointmentToBeUpdated);
        }
    }
}
