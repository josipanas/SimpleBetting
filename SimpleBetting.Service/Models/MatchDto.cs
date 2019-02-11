using System;
using System.Collections.Generic;

namespace SimpleBetting.Service.Models
{
    public class MatchDto
    {
        public int Id { get; set; }

        public TeamDto HomeTeam { get; set; }

        public TeamDto AwayTeam { get; set; }

        public DateTime Time { get; set; }

        public List<OfferDto> Offers { get; set; }
    }
}