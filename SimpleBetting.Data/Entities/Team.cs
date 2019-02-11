namespace SimpleBetting.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SportId { get; set; }

        public int MatchId { get; set; }
    }
}