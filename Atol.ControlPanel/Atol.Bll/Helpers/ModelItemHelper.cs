using System.Collections.Generic;
using Project.Bll.Core.Dto;
using Project.Bll.Core.StoredItems;

namespace Project.Bll.Core.Helpers
{
    public static class ModelItemHelper
    {
        public static List<ProductModel> ToModelsList(this IEnumerable<ProductsStoredItem> storedItems)
        {
            var list = new List<ProductModel>();
            foreach (var item in storedItems)
            {
                list.Add(new ProductModel()
                {
                    DateAdded = item.DateAdded,
                    Description = item.Description,
                    Id = item.Id,
                    Note = item.Note,
                    Price = item.Price,
                    Title = item.Title
                });
            }

            return list;
        }

        public static List<TransactionModel> ToModelsList(this IEnumerable<TransactionsStoredItem> storedItems)
        {
            var list = new List<TransactionModel>();
            foreach (var item in storedItems)
            {
                list.Add(new TransactionModel()
                {
                    Id = item.Id,
                    DateAdded = item.DateAdded,
                    Note = item.Note,
                    Product = item.Product,
                    User = item.User
                });
            }

            return list;
        }

        public static List<UserModel> ToModelsList(this IEnumerable<UserStoredItem> storedItems)
        {
            var list = new List<UserModel>();
            foreach (var item in storedItems)
            {
                list.Add(new UserModel()
                {
                    Id = item.Id,
                    DateAdded = item.DateAdded,
                    Note = item.Note,
                    Phone = item.Phone,
                    Name = item.Name,
                    Patronymic = item.Patronymic,
                    Surname = item.Surname
                });
            }

            return list;
        }

        public static UserModel ToModel(this UserStoredItem storedItem)=>
        new UserModel()
        {
            DateAdded = storedItem.DateAdded,
            Id = storedItem.Id,
            Name = storedItem.Name,
            Note = storedItem.Note,
            Patronymic = storedItem.Patronymic,
            Phone = storedItem.Phone,
            Surname = storedItem.Surname
        };

        public static TransactionModel ToModel(this TransactionsStoredItem transactionModel) 
            => new TransactionModel()
            {
                Id = transactionModel.Id,
                DateAdded = transactionModel.DateAdded,
                Note = transactionModel.Note,
                Product = transactionModel.Product,
                User = transactionModel.User
            };

        public static  ProductModel ToModel(this ProductsStoredItem product)
            => new ProductModel()
            {
                DateAdded = product.DateAdded,
                Description = product.Description,
                Id = product.Id,
                Note = product.Note,
                Price = product.Price,
                Title = product.Title
            };
    }
}
