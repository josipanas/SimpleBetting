using System;
using System.Collections.Generic;
using System.Linq;
using SimpleBetting.Data;
using SimpleBetting.Data.Entities;
using SimpleBetting.Repo.Interfaces;

namespace SimpleBetting.Repo.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly SimpleBettingContext _context;

        public TransactionRepository(SimpleBettingContext context) : base(context)
        {
            _context = context;
        }

        public double GetWalletBalance()
        {
            return _context.Transactions.Last().Balance;
        }

        public List<Transaction> GetAllTransactions()
        {
            return GetAll().ToList();
        }

        public Transaction AddTransaction(Transaction.TransactionType transactionType, double amount)
        {
            var balance = GetWalletBalance();

            if (transactionType == Transaction.TransactionType.Payment)
                balance += amount;
            else
                balance -= amount;

            if (balance < 0) return null;

            var transaction = new Transaction
            {
                Type = transactionType,
                Amount = Math.Round(amount, 2),
                Time = DateTime.Now,
                Balance = Math.Round(balance, 2)
            };

            Create(transaction);
            Save();
            return transaction;
        }

        public void UpdateTicketId(Transaction transaction, int ticketId)
        {
            transaction.TicketId = ticketId;
            _context.Entry(transaction).Property("TicketId").IsModified = true;
            Save();
        }
    }
}