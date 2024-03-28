using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamMuseum.Domain;
using TeamMuseum.Services.Dtos;
using TeamMuseum.Services.Services;

namespace TeamMuseum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ITicketDetailsService _ticketDetailsService;

        public TicketController(ITicketService ticketService, ITicketDetailsService ticketDetailsService)
        {
            _ticketService = ticketService;
            _ticketDetailsService = ticketDetailsService;
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _ticketService.Get(id));
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ticketService.GetAll());
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(TicketDto ticket)
        {
            if (ticket == null)
            {
                return BadRequest();
            }
            return Ok(await _ticketService.Insert(ticket));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update(TicketDto ticket)
        {
            if (ticket == null)
            {
                return BadRequest();
            }
            return Ok(await _ticketService.Insert(ticket));
        }

        [HttpDelete]
        [Route("/{ticketId}")]
        public async Task<IActionResult> Delete(int ticketId)
        {
            var ticketToBeDeleted = await _ticketService.Get(ticketId);
            if (ticketToBeDeleted == null)
            {
                return BadRequest();
            }
            return Ok(await _ticketService.Delete(ticketToBeDeleted));
        }
    }
}
