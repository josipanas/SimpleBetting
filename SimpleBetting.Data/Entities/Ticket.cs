using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleBetting.Data.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public double TotalOdd { get; set; }

        [Required] public double Stake { get; set; }

        public double PossiblePayout { get; set; }

        public List<MatchTicket> MatchTickets { get; set; }

        public int TransactionId { get; set; }
    }
}