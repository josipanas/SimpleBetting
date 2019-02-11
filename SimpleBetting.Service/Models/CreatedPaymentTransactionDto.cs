using System;
using SimpleBetting.Data.Entities;

namespace SimpleBetting.Service.Models
{
    public class CreatedPaymentTransactionDto
    {
        public int Id { get; set; }

        public string Type { get; set; } = Transaction.TransactionType.Payment.ToString();

        public double Amount { get; set; }

        public DateTime Time { get; set; }

        public double Balance { get; set; }
    }
}