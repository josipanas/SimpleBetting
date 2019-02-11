namespace SimpleBetting.Data.Entities
{
    public class MatchTicket
    {
        public int MatchId { get; set; }

        public Match Match { get; set; }

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }
    }
}