using HappyGrocery.Data;
using Microsoft.EntityFrameworkCore;

namespace HappyGrocery.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HappyGroceryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HappyGroceryContext>>()))
            {
                // Look for any products.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }
                context.Product.AddRange(
                    new Product
                    {
                       
                        ProductName = "Carrot",
                        Price = 1.50M,
                        Description = "Carrot from Galway",
                        Qty = 15,
                        CategoryId = 1
                        
                    },
                    new Product
                    {
                        
                        ProductName = "Onion",
                        Price = 0.90M,
                        Description = "Onion from Dublin farm",
                        Qty = 20,
                        CategoryId = 1
                    },
                    new Product
                    {
                        
                        ProductName = "Apple",
                        Price = 2.00M,
                        Description = "Rose apple from Germany",
                        Qty = 15,
                        CategoryId = 2
                    },
                    new Product
                    {
                       
                        ProductName = "Grape",
                        Price = 2.50M,
                        Description = "Seedless green crispy grape",
                        Qty = 10,
                        CategoryId = 2
                    },
                    new Product
                    {
                       
                        ProductName = "Banana",
                        Price = 2.30M,
                        Description = "Banana from Cork",
                        Qty = 10,
                        CategoryId = 2
                    }

                );
               context.SaveChanges();

                if (context.Category.Any())
                {
                    return;
                }
                context.Category.AddRange(
                  new Category 
                  { 
                     
                      CategoryName = "Vegetable"
                  },

                  new Category
                  {
                     
                      CategoryName = "Fruit"
                  }

                    );
                context.SaveChanges();

                if(context.User.Any()) 
                { 
                    return; 
                }
                context.User.AddRange(
                    new User
                    {
                        
                        Username = "Marry",
                        Email = "Marry@gmail.com",
                        Password = "passWord123!",
                        Firstname = "Marry",
                        Lastname = "White",
                        Usertype = 1
                    },
                    new User
                    {
                        
                        Username = "Elisha",
                        Email = "Elisha@gmail.com",
                        Password = "elishA123!",
                        Firstname = "Elisha",
                        Lastname = "Smith",
                        Usertype = 1
                    },
                    new User
                    {
                       
                        Username = "Amanda",
                        Email = "Amanda@gmail.com",
                        Password = "0Amanda0!",
                        Firstname = "Amanda",
                        Lastname = "Ryan",
                        Usertype = 2
                    }

                    );
                context.SaveChanges();
            };
        }
    }
}
