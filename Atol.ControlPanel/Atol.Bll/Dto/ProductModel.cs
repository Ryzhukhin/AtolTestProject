using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Bll.Core.Dto
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Note { get; set; }
    }
}
