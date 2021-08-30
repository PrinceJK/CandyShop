using System.Collections.Generic;

namespace CandyShop.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Candies { get; set; }
    }
}