using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleBetting.Repo.Interfaces;
using SimpleBetting.Service.Interfaces;
using SimpleBetting.Service.Models;

namespace SimpleBetting.WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketRepository ticketRepository, ITicketService ticketService, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _ticketService = ticketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllTickets()
        {
            var tickets = _ticketRepository.GetAllTickets();
            if (tickets.Count == 0) return NotFound();

            return Ok(_mapper.Map<List<TicketDto>>(tickets));
        }

        [HttpPost("create")]
        public IActionResult CreateTicket(TicketForCreationDto ticket)
        {
            if (ticket == null) return BadRequest();

            if (!_ticketService.ValidateTicketInput(ticket))
                return BadRequest();

            var createdTicket = _ticketService.CreateTicket(ticket);
            if (createdTicket == null) return BadRequest();

            return Created($"create/{createdTicket.Id}",
                _mapper.Map<TicketDto>(createdTicket));
        }
    }
}