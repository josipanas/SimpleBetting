using System.ComponentModel.DataAnnotations;

namespace SimpleBetting.Data.Entities
{
    public class Offer
    {
        public int Id { get; set; }

        [Range(1.0, double.MaxValue)] public double? HomeWin { get; set; }

        [Range(1.0, double.MaxValue)] public double? Draw { get; set; }

        [Range(1.0, double.MaxValue)] public double? AwayWin { get; set; }

        [Range(1.0, double.MaxValue)] public double? HomeWinOrDraw { get; set; }

        [Range(1.0, double.MaxValue)] public double? DrawOrAwayWin { get; set; }

        [Range(1.0, double.MaxValue)] public double? HomeOrAwayWin { get; set; }

        public bool IsTopOffer { get; set; }

        public int MatchId { get; set; }
    }
}