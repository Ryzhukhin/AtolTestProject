using System;
using System.Collections.Generic;
using System.Linq;
using Project.Bll.Core;
using Project.Bll.Core.Interfaces;
using Project.Bll.Core.StoredItems;

namespace Project.Dal.Ef.Repositories
{
    public class TransactionRepository:ITransactionRepository
    {
        public IEnumerable<TransactionsStoredItem> GetAll(Filter filter, int skip, int take)
        {
            EfUnitOfWork.ThrowIfNoContext();

            return EfUnitOfWork.Context.Transactions
                .Skip(skip)
                .Take(take)
                .OrderByDescending(p => p.DateAdded);
        }

        public void AddNew(TransactionsStoredItem transaction)
        {
            EfUnitOfWork.ThrowIfNoContext();
            EfUnitOfWork.Context.Transactions.Add(transaction);
        }

        public TransactionsStoredItem GetById(Guid id)
        {
            EfUnitOfWork.ThrowIfNoContext();
            return EfUnitOfWork.Context.Transactions.FirstOrDefault(t => t.Id == id);
        }
    }
}