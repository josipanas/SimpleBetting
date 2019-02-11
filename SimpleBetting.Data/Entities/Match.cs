using System;
using System.Collections.Generic;

namespace SimpleBetting.Data.Entities
{
    public class Match
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public List<Team> Teams { get; set; }

        public List<Offer> Offers { get; set; }

        public List<MatchTicket> MatchTickets { get; set; }
    }
}