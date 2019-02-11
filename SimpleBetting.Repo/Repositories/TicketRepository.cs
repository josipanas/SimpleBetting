using System.Collections.Generic;
using System.Linq;
using SimpleBetting.Data;
using SimpleBetting.Data.Entities;
using SimpleBetting.Repo.Interfaces;

namespace SimpleBetting.Repo.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        private readonly SimpleBettingContext _context;

        public TicketRepository(SimpleBettingContext context) :
            base(context)
        {
            _context = context;
        }

        public List<Ticket> GetAllTickets()
        {
            return GetAll().ToList();
        }

        public Ticket AddTicket(Ticket ticket)
        {
            Create(ticket);
            Save();
            return ticket;
        }
    }
}