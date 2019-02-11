using Microsoft.EntityFrameworkCore;
using SimpleBetting.Data.Entities;

namespace SimpleBetting.Data
{
    public class SimpleBettingContext : DbContext
    {
        public SimpleBettingContext(DbContextOptions<SimpleBettingContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Sport> Sports { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<MatchTicket> MatchTickets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchTicket>().HasKey(mt => new {mt.MatchId, mt.TicketId});

            modelBuilder.Entity<MatchTicket>().HasOne(mt => mt.Match).WithMany(m => m.MatchTickets)
                .HasForeignKey(mt => mt.MatchId);

            modelBuilder.Entity<MatchTicket>().HasOne(mt => mt.Ticket).WithMany(t => t.MatchTickets)
                .HasForeignKey(mt => mt.TicketId);

            modelBuilder.Seed();
        }
    }
}