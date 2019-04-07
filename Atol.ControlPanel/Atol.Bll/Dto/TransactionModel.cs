using System;
using Project.Bll.Core.StoredItems;

namespace Project.Bll.Core.Dto
{
    public class TransactionModel
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public UserStoredItem User { get; set; }
        public ProductsStoredItem Product { get; set; }
        public string Note { get; set; }
    }
}