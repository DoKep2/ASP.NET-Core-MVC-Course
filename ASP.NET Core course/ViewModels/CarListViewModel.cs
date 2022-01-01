using System.Collections;
using System.Collections.Generic;
using ASP.NET_Core_course.Data.Models;

namespace ASP.NET_Core_course.ViewModels
{
    public class CarListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }
        public string CurrentCategory { get; set; } 
    }
}