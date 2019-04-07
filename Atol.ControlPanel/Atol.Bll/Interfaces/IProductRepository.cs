using System;
using System.Collections.Generic;
using Project.Bll.Core.StoredItems;

namespace Project.Bll.Core.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductsStoredItem> GetAll(Filter filter, int skip, int take);
        void AddNew(ProductsStoredItem product);
        ProductsStoredItem GetById(Guid id);
        void DeleteById(Guid id);
    }
}
