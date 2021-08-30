using CandyShop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CandyShop.Data
{
    public class Seeder
    {
        public static async Task SeedData(AppDbContext context)
        {
            try
            {
                var dirDb = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                context.Database.EnsureCreated();

                if (!context.Categories.Any())
                {
                    var categories = File.ReadAllText(dirDb + @"/JSONfiles/Category.json");
                    var allCategories = JsonConvert.DeserializeObject<List<Category>>(categories);

                    await context.Categories.AddRangeAsync(allCategories);
                }

                if (!context.Products.Any())
                {
                    var products = File.ReadAllText(dirDb + @"/JSONfiles/Product.json");
                    var allProducts = JsonConvert.DeserializeObject<List<Product>>(products);

                    await context.Products.AddRangeAsync(allProducts);
                }


                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

    }
}
