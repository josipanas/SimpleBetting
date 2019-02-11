using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleBetting.Data.Entities
{
    public class Transaction
    {
        public enum TransactionType
        {
            Payment,
            Payout
        }

        public int Id { get; set; }

        public TransactionType Type { get; set; }

        public double Amount { get; set; }

        public DateTime Time { get; set; }

        [Range(0, double.MaxValue)] public double Balance { get; set; }

        public int? TicketId { get; set; }
    }
}