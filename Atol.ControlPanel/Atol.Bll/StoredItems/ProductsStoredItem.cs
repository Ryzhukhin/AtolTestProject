using System;

namespace Project.Bll.Core.StoredItems
{
    public class ProductsStoredItem
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Note { get; set; }
    }
}