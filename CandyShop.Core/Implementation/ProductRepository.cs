using CandyShop.Core.Interface;
using CandyShop.Data;
using CandyShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyShop.Core.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Product> GetAllProducts
        {
            get
            {
                return _appDbContext.Products.Include(b => b.Category);
            }
        }

        public IEnumerable<Product> GetProductOnSale
        {
            get
            {
                return _appDbContext.Products.Include(b => b.Category)
                    .Where(p => p.IsOnSale);
            }
        }

        public Product GetProductById(string Id)
        {
            return _appDbContext.Products.FirstOrDefault(b => b.Id == Id);
        }
    }
}
