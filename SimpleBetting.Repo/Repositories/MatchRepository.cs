using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleBetting.Data;
using SimpleBetting.Data.Entities;
using SimpleBetting.Repo.Interfaces;

namespace SimpleBetting.Repo.Repositories
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        private readonly SimpleBettingContext _context;

        public MatchRepository(SimpleBettingContext context) : base(context)
        {
            _context = context;
        }

        public List<Match> GetAllMatchesWithOffers()
        {
            return _context.Matches.Include(m => m.Teams).Include(m => m.Offers).ToList();
        }

        public Match GetMatchById(int id)
        {
            return _context.Matches.Include(m => m.Teams).Include(m => m.Offers)
                .FirstOrDefault(m => m.Id.Equals(id));
        }

        public List<Match> GetMatchesBySportId(int sportId)
        {
            return _context.Matches.Include(m => m.Teams).Include(m => m.Offers)
                .Where(m => m.Teams.Any(t => t.SportId.Equals(sportId))).ToList();
        }
    }
}