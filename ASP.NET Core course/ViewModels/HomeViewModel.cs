using System.Collections;
using System.Collections.Generic;
using ASP.NET_Core_course.Data.Models;

namespace ASP.NET_Core_course.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> FavouriteCars { get; set; }
    }
}