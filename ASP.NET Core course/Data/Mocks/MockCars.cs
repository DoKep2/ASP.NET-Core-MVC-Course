using System.Collections.Generic;
using System.Linq;
using ASP.NET_Core_course.Data.Interfaces;
using ASP.NET_Core_course.Data.Models;

namespace ASP.NET_Core_course.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _carsCategory = new MockCategory();
        public IEnumerable<Car> GetAll
        {
            get
            {
                return new List<Car>
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
                        Category = _carsCategory.AllCategories.First()
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
                        Category = _carsCategory.AllCategories.Last()
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
                        Category = _carsCategory.AllCategories.Last()
                    },
                };
            }
        }
        public IEnumerable<Car> GetFavourite { get; }
        public Car GetById(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}