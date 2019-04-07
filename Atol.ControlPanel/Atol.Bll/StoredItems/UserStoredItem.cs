using System;

namespace Project.Bll.Core.StoredItems
{
    public class UserStoredItem
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
    }

    public class ProductsStoredItem
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Note { get; set; }
    }

    public class TransactionsStoredItem
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public UserStoredItem UserId { get; set; }
        public ProductsStoredItem ProductId { get; set; }
        public string Note { get; set; }
    }
}
