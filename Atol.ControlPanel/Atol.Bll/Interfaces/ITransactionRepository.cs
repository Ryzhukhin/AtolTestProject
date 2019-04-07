using System;
using System.Collections.Generic;
using Project.Bll.Core.Dto;
using Project.Bll.Core.StoredItems;

namespace Project.Bll.Core.Interfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<TransactionsStoredItem> GetAll(Filter filter, int skip, int take);
        void AddNew(TransactionsStoredItem transactions);
        TransactionsStoredItem GetById(Guid id);
    }
}