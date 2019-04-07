using System;
using System.Collections.Generic;
using System.Text;
using Project.Bll.Core.Dto;
using Project.Bll.Core.StoredItems;

namespace Project.Bll.Core.Helpers
{
    public static class StoredItemHelper
    {
        public static UserStoredItem ToStoredItem(this UserModel user) =>
            new UserStoredItem()
            {
                Id = Guid.NewGuid(),
                DateAdded = DateTime.Now,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Phone = user.Phone,
                Note = user.Note
            };

        public static ProductsStoredItem ToStoredItem(this ProductModel product) =>
            new ProductsStoredItem()
            {
                Id = Guid.NewGuid(),
                DateAdded = DateTime.Now,
                Title = product.Title,
                Description = product.Description,
                Note = product.Note,
                Price = product.Price
            };

        public static TransactionsStoredItem ToStoredItem(this TransactionModel transactions) =>
            new TransactionsStoredItem()
            {
                Id = Guid.NewGuid(),
                DateAdded = DateTime.Now,
                Product = transactions.Product,
                User = transactions.User,
                Note = transactions.Note
            };

    }
}
