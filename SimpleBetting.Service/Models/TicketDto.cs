namespace SimpleBetting.Service.Models
{
    public class TicketDto
    {
        public int Id { get; set; }

        public double Stake { get; set; }

        public double TotalOdd { get; set; }

        public double PossiblePayout { get; set; }
    }
}