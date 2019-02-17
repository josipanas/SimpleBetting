using System;
using System.Collections.Generic;
using System.Linq;
using SimpleBetting.Data.Entities;
using SimpleBetting.Repo.Interfaces;
using SimpleBetting.Repo.Repositories;

namespace SimpleBetting.Repo.Mocks
{
    public class TransactionRepositoryMock : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly List<Transaction> _transactions;

        public TransactionRepositoryMock() : base(null)
        {
            _transactions = new List<Transaction>
            {
                new Transaction
                {
                    Id = 1,
                    Type = Transaction.TransactionType.Payment,
                    Amount = 100,
                    Time = DateTime.Today,
                    Balance = 100
                },
                new Transaction
                {
                    Id = 2,
                    Type = Transaction.TransactionType.Payout,
                    Amount = 9.50,
                    Time = DateTime.Today,
                    Balance = 90.50,
                    TicketId = 1
                }
            };
        }

        public double GetWalletBalance()
        {
            return _transactions.Last().Balance;
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactions;
        }

        public Transaction AddTransaction(Transaction.TransactionType transactionType, double amount)
        {
            var balance = GetWalletBalance();
            var transaction = new Transaction
            {
                Id = _transactions.Last().Id++,
                Type = transactionType,
                Amount = amount,
                Time = DateTime.Today,
                Balance = balance + amount
            };
            _transactions.Add(transaction);

            return _transactions.Last();
        }

        public void UpdateTicketId(Transaction transaction, int ticketId)
        {
        }
    }
}