using System.Collections.Generic;
using SimpleBetting.Data.Entities;

namespace SimpleBetting.Repo.Interfaces
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        List<Ticket> GetAllTickets();

        Ticket AddTicket(Ticket ticketInput);
    }
}