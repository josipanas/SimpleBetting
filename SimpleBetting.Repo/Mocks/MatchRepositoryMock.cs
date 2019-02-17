using System;
using System.Collections.Generic;
using System.Linq;
using SimpleBetting.Data.Entities;
using SimpleBetting.Repo.Interfaces;
using SimpleBetting.Repo.Repositories;

namespace SimpleBetting.Repo.Mocks
{
    public class MatchRepositoryMock : GenericRepository<Match>, IMatchRepository
    {
        private readonly List<Match> _matches;

        public MatchRepositoryMock() : base(null)
        {
            _matches = new List<Match>
            {
                new Match
                {
                    Id = 1,
                    Teams = new List<Team>
                    {
                        new Team
                        {
                            Id = 1,
                            Name = "MockTeam1",
                            SportId = 1,
                            MatchId = 1
                        },
                        new Team
                        {
                            Id = 2,
                            Name = "MockTeam2",
                            SportId = 1,
                            MatchId = 1
                        }
                    },
                    Offers = new List<Offer>
                    {
                        new Offer
                        {
                            Id = 1,
                            HomeWin = 1.1,
                            AwayWin = 2,
                            HomeOrAwayWin = 3.3,
                            IsTopOffer = false,
                            MatchId = 1
                        },
                        new Offer
                        {
                            Id = 2,
                            HomeWin = 2.2,
                            AwayWin = 3,
                            HomeOrAwayWin = 4.4,
                            IsTopOffer = true,
                            MatchId = 1
                        }
                    },
                    Time = DateTime.Now
                },
                new Match
                {
                    Id = 2,
                    Teams = new List<Team>
                    {
                        new Team
                        {
                            Id = 3,
                            Name = "MockTeam3",
                            SportId = 2,
                            MatchId = 2
                        },
                        new Team
                        {
                            Id = 4,
                            Name = "MockTeam4",
                            SportId = 2,
                            MatchId = 2
                        }
                    },
                    Offers = new List<Offer>
                    {
                        new Offer
                        {
                            Id = 3,
                            HomeWin = 1.1,
                            AwayWin = 2,
                            HomeOrAwayWin = 3.3,
                            IsTopOffer = false,
                            MatchId = 2
                        }
                    },
                    Time = DateTime.Now
                }
            };
        }

        public List<Match> GetAllMatchesWithOffers()
        {
            return _matches;
        }

        public Match GetMatchById(int id)
        {
            return _matches.FirstOrDefault(m => m.Id.Equals(id));
        }

        public List<Match> GetMatchesBySportId(int sportId)
        {
            return _matches.Where(m => m.Teams.Any(t => t.SportId.Equals(sportId))).ToList();
        }
    }
}