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
                        Name = "Tesla",
                        ShortDescription = "",
                        LongDescription = "",
                        Img = "",
                        Price = 5555,
                        IsFavourite = true,
                        IsAvailable = true,
                        Category = _carsCategory.AllCategories.First()
                    }
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