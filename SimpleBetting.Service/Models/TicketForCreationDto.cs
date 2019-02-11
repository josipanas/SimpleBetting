using System.Collections.Generic;

namespace SimpleBetting.Service.Models
{
    public class TicketForCreationDto
    {
        public List<MatchForTicketCreationDto> SelectedMatches { get; set; }

        public double Stake { get; set; }
    }
}