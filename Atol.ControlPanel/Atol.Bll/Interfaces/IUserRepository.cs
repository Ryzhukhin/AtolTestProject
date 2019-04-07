using System;
using System.Collections.Generic;
using Project.Bll.Core.StoredItems;

namespace Project.Bll.Core.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserStoredItem> GetAll(Filter filter, int skip, int take);
        void AddNew(UserStoredItem user);
        UserStoredItem GetById(Guid id);
        void DeleteById(Guid id);
    }
}