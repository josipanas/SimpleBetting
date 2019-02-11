namespace SimpleBetting.Service.Models
{
    public class OfferDto
    {
        public int Id { get; set; }

        public double? HomeWin { get; set; }

        public double? Draw { get; set; }

        public double? AwayWin { get; set; }

        public double? HomeWinOrDraw { get; set; }

        public double? DrawOrAwayWin { get; set; }

        public double? HomeOrAwayWin { get; set; }

        public bool IsTopOffer { get; set; }
    }
}