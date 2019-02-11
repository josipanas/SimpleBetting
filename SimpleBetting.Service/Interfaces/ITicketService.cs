using SimpleBetting.Data.Entities;
using SimpleBetting.Service.Models;

namespace SimpleBetting.Service.Interfaces
{
    public interface ITicketService
    {
        bool ValidateTicketInput(TicketForCreationDto ticketInput);

        Ticket CreateTicket(TicketForCreationDto ticketInput);
    }
}