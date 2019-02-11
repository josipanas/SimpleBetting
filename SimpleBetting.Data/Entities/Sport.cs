using System.Collections.Generic;

namespace SimpleBetting.Data.Entities
{
    public class Sport
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Team> Teams { get; set; }
    }
}