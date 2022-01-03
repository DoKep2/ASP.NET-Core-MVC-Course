using ASP.NET_Core_course.Data.Interfaces;
using ASP.NET_Core_course.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_course.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRepository;
        public HomeController(IAllCars carRepository)
        {
            _carRepository = carRepository;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel()
            {
                FavouriteCars = _carRepository.GetFavourite
            };
            return View(homeCars);
        }
    }
}