namespace SimpleBetting.Service.Models
{
    public class MatchForTicketCreationDto
    {
        public enum OddType
        {
            HomeWin,
            Draw,
            AwayWin,
            HomeWinOrDraw,
            DrawOrAwayWin,
            HomeOrAwayWin
        }

        public int Id { get; set; }

        public OddType SelectedOddType { get; set; }

        public double SelectedOddValue { get; set; }

        public bool IsTopOffer { get; set; }
    }
}