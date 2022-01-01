using System.Collections.Generic;
using ASP.NET_Core_course.Data.Models;

namespace ASP.NET_Core_course.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> GetAll { get; }
        IEnumerable<Car> GetFavourite { get; }
        Car GetById(int carId);
    }
}