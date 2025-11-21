using System;

namespace BLL.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
    }
}
