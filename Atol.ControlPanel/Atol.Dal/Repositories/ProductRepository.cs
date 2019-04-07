using System;
using System.Collections.Generic;
using System.Linq;
using Project.Bll.Core;
using Project.Bll.Core.Interfaces;
using Project.Bll.Core.StoredItems;

namespace Project.Dal.Ef.Repositories
{
    public class ProductRepository:IProductRepository
    {
        public IEnumerable<ProductsStoredItem> GetAll(Filter filter, int skip, int take)
        {
            EfUnitOfWork.ThrowIfNoContext();

            //todo фильтр можно припилить на что угодно, это пример
            return EfUnitOfWork.Context.Products
                .Where(p => p.Title.Contains(filter.AnythingContains)
                         || p.Description.Contains(filter.AnythingContains)
                         || p.Note.Contains(filter.AnythingContains))
                .Skip(skip)
                .Take(take)
                .OrderByDescending(p => p.Title);
        }

        public void AddNew(ProductsStoredItem product)
        {
            EfUnitOfWork.ThrowIfNoContext();
            EfUnitOfWork.Context.Products.Add(product);
        }

        public ProductsStoredItem GetById(Guid id)
        {
            EfUnitOfWork.ThrowIfNoContext();

            return EfUnitOfWork.Context.Products.FirstOrDefault(p => p.Id==id);
        }

        public void DeleteById(Guid id)
        {
            EfUnitOfWork.ThrowIfNoContext();

            var product = GetById(id) ?? throw new ArgumentNullException($"Продукта с id: {id} нет в базе");
            EfUnitOfWork.Context.Products.Remove(product);
        }

    }
}