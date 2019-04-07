using System;

namespace Project.Bll.Core.StoredItems
{
    public class TransactionsStoredItem
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public UserStoredItem User { get; set; }
        public ProductsStoredItem Product { get; set; }
        public string Note { get; set; }
    }
}