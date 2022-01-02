using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ASP.NET_Core_course.Data.Interfaces;
using ASP.NET_Core_course.Data.Models;

namespace ASP.NET_Core_course.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent _appDbContent;

        public CarRepository(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Car> GetAll => _appDbContent.Cars.Include(car => car.Category);
        public IEnumerable<Car> GetFavourite => _appDbContent.Cars.Where(car => car.IsFavourite).Include(car => car.Category);
        public Car GetById(int carId) => _appDbContent.Cars.FirstOrDefault(car => car.Id == carId);
    }
}