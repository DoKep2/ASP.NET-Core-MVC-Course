using System.Collections.Generic;
using System.Linq;
using ASP.NET_Core_course.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NET_Core_course.Data
{
    public class DBObjects
    {
        private static Dictionary<string, Category> Category;
        public static void Initial(AppDBContent content)
        {
            

            if (!content.Categories.Any())
            {
                content.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Cars.Any())
            {
                content.AddRange(
                    new List<Car>
                    {
                        new Car
                        {
                            Name = "Tesla Model S",
                            ShortDescription = "Fast car",
                            LongDescription = "Cool, fast and quiet car Tesla company",
                            Img = "/img/Tesla Model S.jpg",
                            Price = 45000,
                            IsFavourite = true,
                            IsAvailable = true,
                            Category = Categories["Electro"]
                        },
                        new Car
                        {
                            Name = "Ford Fiesta",
                            ShortDescription = "Quiet and calm",
                            LongDescription = "Comfortable car for city life",
                            Img = "/img/Ford Fiesta.jpg",
                            Price = 11000,
                            IsFavourite = false,
                            IsAvailable = true,
                            Category = Categories["Petrol"]
                        },
                        new Car
                        {
                            Name = "BMW M3",
                            ShortDescription = "Cool and stylish",
                            LongDescription = "Comfortable car for city life",
                            Img = "/img/BMW M3.jpg",
                            Price = 65000,
                            IsFavourite = true,
                            IsAvailable = true,
                            Category = Categories["Petrol"]
                        },
                    });
            }

            content.SaveChanges();
        }

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (Category == null)
                {
                    var list = new Category[]
                    {
                        new Category {name = "Electro", description = "Electro desc"},
                        new Category {name = "Petrol", description = "Petrol desc"},
                    };
                    Category = new Dictionary<string, Category>();
                    foreach (Category category in list)
                    {
                        Category.Add(category.name, category);
                    }
                }

                return Category;    
            }
        }
    }
}