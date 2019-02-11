using System.Collections.Generic;
using SimpleBetting.Data.Entities;

namespace SimpleBetting.Repo.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        double GetWalletBalance();

        List<Transaction> GetAllTransactions();

        Transaction AddTransaction(Transaction.TransactionType transactionType, double amount);

        void UpdateTicketId(Transaction transaction, int ticketId);
    }
}