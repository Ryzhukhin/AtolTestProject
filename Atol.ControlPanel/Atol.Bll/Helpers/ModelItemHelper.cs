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
