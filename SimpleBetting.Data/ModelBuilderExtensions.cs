using System;
using Microsoft.EntityFrameworkCore;
using SimpleBetting.Data.Entities;

namespace SimpleBetting.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>().HasData(
                new Sport
                {
                    Id = 1,
                    Name = "Volleyball"
                },
                new Sport
                {
                    Id = 2,
                    Name = "Basketball"
                },
                new Sport
                {
                    Id = 3,
                    Name = "Waterpolo"
                });

            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = 1,
                    Name = "Mladost Ribola Kaštela",
                    SportId = 1,
                    MatchId = 1
                },
                new Team
                {
                    Id = 2,
                    Name = "Split",
                    SportId = 1,
                    MatchId = 1
                },
                new Team
                {
                    Id = 3,
                    Name = "Rovinj",
                    SportId = 1,
                    MatchId = 2
                },
                new Team
                {
                    Id = 4,
                    Name = "Mladost",
                    SportId = 1,
                    MatchId = 2
                },
                new Team
                {
                    Id = 5,
                    Name = "Cedevita",
                    SportId = 2,
                    MatchId = 3
                },
                new Team
                {
                    Id = 6,
                    Name = "Adria Oil Škrljevo",
                    SportId = 2,
                    MatchId = 3
                },
                new Team
                {
                    Id = 7,
                    Name = "Alkar",
                    SportId = 2,
                    MatchId = 4
                },
                new Team
                {
                    Id = 8,
                    Name = "Split",
                    SportId = 2,
                    MatchId = 4
                },
                new Team
                {
                    Id = 9,
                    Name = "Jadran",
                    SportId = 3,
                    MatchId = 5
                },
                new Team
                {
                    Id = 10,
                    Name = "Jug",
                    SportId = 3,
                    MatchId = 5
                },
                new Team
                {
                    Id = 11,
                    Name = "POŠK",
                    SportId = 3,
                    MatchId = 6
                },
                new Team
                {
                    Id = 12,
                    Name = "Mornar",
                    SportId = 3,
                    MatchId = 6
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 1,
                    Time = Convert.ToDateTime("2/10/2019 12:00:00 AM")
                },
                new Match
                {
                    Id = 2,
                    Time = Convert.ToDateTime("2/11/2019 02:00:00 PM")
                },
                new Match
                {
                    Id = 3,
                    Time = Convert.ToDateTime("2/12/2019 08:00:00 PM")
                },
                new Match
                {
                    Id = 4,
                    Time = Convert.ToDateTime("2/10/2019 08:00:00 PM")
                },
                new Match
                {
                    Id = 5,
                    Time = Convert.ToDateTime("2/9/2019 07:00:00 PM")
                },
                new Match
                {
                    Id = 6,
                    Time = Convert.ToDateTime("2/11/2019 05:00:00 PM")
                }
            );

            modelBuilder.Entity<Offer>().HasData(
                new Offer
                {
                    Id = 1,
                    HomeWin = 1.5,
                    AwayWin = 3,
                    HomeOrAwayWin = 1.1,
                    IsTopOffer = false,
                    MatchId = 1
                },
                new Offer
                {
                    Id = 2,
                    HomeWin = 5.5,
                    AwayWin = 18.3,
                    HomeOrAwayWin = 4.1,
                    IsTopOffer = true,
                    MatchId = 1
                },
                new Offer
                {
                    Id = 3,
                    HomeWin = 5.5,
                    AwayWin = 1.3,
                    HomeOrAwayWin = 1.1,
                    IsTopOffer = false,
                    MatchId = 2
                },
                new Offer
                {
                    Id = 4,
                    HomeWin = 1.44,
                    Draw = 13.5,
                    AwayWin = 15,
                    HomeWinOrDraw = 2.13,
                    DrawOrAwayWin = 7.15,
                    IsTopOffer = false,
                    MatchId = 3
                },
                new Offer
                {
                    Id = 5,
                    HomeWin = 4.44,
                    Draw = 21.5,
                    AwayWin = 20,
                    HomeWinOrDraw = 5.13,
                    DrawOrAwayWin = 10.15,
                    IsTopOffer = true,
                    MatchId = 3
                },
                new Offer
                {
                    Id = 6,
                    HomeWin = 4,
                    Draw = 7.5,
                    AwayWin = 2.22,
                    HomeWinOrDraw = 3.13,
                    DrawOrAwayWin = 2.15,
                    IsTopOffer = false,
                    MatchId = 4
                },
                new Offer
                {
                    Id = 7,
                    HomeWin = 9.8,
                    Draw = 10,
                    AwayWin = 1.1,
                    HomeWinOrDraw = 4.95,
                    IsTopOffer = false,
                    MatchId = 5
                },
                new Offer
                {
                    Id = 8,
                    HomeWin = 15.5,
                    Draw = 13,
                    AwayWin = 4.1,
                    HomeWinOrDraw = 8.1,
                    IsTopOffer = true,
                    MatchId = 5
                },
                new Offer
                {
                    Id = 9,
                    HomeWin = 3.3,
                    Draw = 7,
                    AwayWin = 1.5,
                    HomeWinOrDraw = 2.24,
                    DrawOrAwayWin = 1.24,
                    IsTopOffer = false,
                    MatchId = 6
                }
            );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = 1,
                    Type = Transaction.TransactionType.Payment,
                    Amount = 100,
                    Time = DateTime.Now,
                    Balance = 100
                });
        }
    }
}