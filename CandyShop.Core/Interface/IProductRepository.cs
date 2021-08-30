using CandyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyShop.Core.Interface
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts { get; }
        public IEnumerable<Product> GetProductOnSale { get; }
        public Product GetProductById(string Id);
    }
}
