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
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketDetailsService _ticketDetailsService;
        private IMapper _Mapper;
        public TicketService(ITicketRepository ticketRepository, IMapper mapper, ITicketDetailsService ticketDetailsService) 
        {
            _ticketRepository = ticketRepository;
            _Mapper = mapper;
            _ticketDetailsService = ticketDetailsService;
        }
        public async Task<int> Delete(TicketDto ticketDto)
        {
            var ticketToBeDeleted = _Mapper.Map<Ticket>(ticketDto);
            return await _ticketRepository.Delete(ticketToBeDeleted);
        }

        public async Task<TicketDto> Get(int id)
        {
            var result = await _ticketRepository.Get(id);
            return _Mapper.Map<TicketDto>(result);
        }

        public async Task<IEnumerable<TicketDto>> GetAll()
        {
            var result = await _ticketRepository.GetAll();
            return _Mapper.Map<IEnumerable<TicketDto>>(result);
        }

        public async Task<int> Insert(TicketDto ticketDto)
        {
            var ticketToBeAdded = _Mapper.Map<Ticket>(ticketDto);
            var result = await _ticketRepository.Insert(ticketToBeAdded);
            foreach (var item in ticketDto.TicketDetails)
            {
                await _ticketDetailsService.Insert(_Mapper.Map<TicketDetailsDto>(item));
            }
            return result;
        }

        public async Task<int> Update(TicketDto ticketDto)
        {
            var ticketToBeUpdated = _Mapper.Map<Ticket>(ticketDto);
            return await _ticketRepository.Update(ticketToBeUpdated);
        }
    }
}
