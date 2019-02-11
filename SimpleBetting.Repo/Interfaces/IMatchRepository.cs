using System.Collections.Generic;
using SimpleBetting.Data.Entities;

namespace SimpleBetting.Repo.Interfaces
{
    public interface IMatchRepository : IGenericRepository<Match>
    {
        List<Match> GetAllMatchesWithOffers();

        Match GetMatchById(int id);

        List<Match> GetMatchesBySportId(int sportId);
    }
}