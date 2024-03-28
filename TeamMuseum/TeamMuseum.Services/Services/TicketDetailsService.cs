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
    public class TicketDetailsService : ITicketDetailsService
    {
        private readonly ITicketDetailsRepository _ticketDetailsRepository;
        private IMapper _mapper;

        public TicketDetailsService(ITicketDetailsRepository ticketDetailsRepository, IMapper mapper)
        {
            _ticketDetailsRepository = ticketDetailsRepository;
            _mapper = mapper;
        }

        public async Task<int> AddRange(IEnumerable<TicketDetailsDto> list)
        {
            var tickectDetailsListToBeAdded = _mapper.Map<IEnumerable<TicketDetails>>(list);
            return await _ticketDetailsRepository.AddRange(tickectDetailsListToBeAdded);
        }

        public async Task<int> Delete(TicketDetailsDto ticketDetailsDto)
        {
            var ticketDetailsToBeDeleted = _mapper.Map<TicketDetails>(ticketDetailsDto);
            return await _ticketDetailsRepository.Delete(ticketDetailsToBeDeleted);
        }

        public async Task<TicketDetailsDto> Get(int Id)
        {
            var result = await _ticketDetailsRepository.Get(Id);
            return _mapper.Map<TicketDetailsDto>(result);
        }

        public async Task<IEnumerable<TicketDetailsDto>> GetAll()
        {
            var result = await _ticketDetailsRepository.GetAll();
            return _mapper.Map<IEnumerable<TicketDetailsDto>>(result);
        }

        public async Task<int> Insert(TicketDetailsDto ticketDetailsDto)
        {
            var ticketDetailsToBeAdded = _mapper.Map<TicketDetails>(ticketDetailsDto);
            return await _ticketDetailsRepository.Insert(ticketDetailsToBeAdded);
        }

        public async Task<int> Update(TicketDetailsDto ticketDetailsDto)
        {
            var ticketDetailsToBeUpdated = _mapper.Map<TicketDetails>(ticketDetailsDto);
            return await _ticketDetailsRepository.Update(ticketDetailsToBeUpdated);
        }
    }
}
