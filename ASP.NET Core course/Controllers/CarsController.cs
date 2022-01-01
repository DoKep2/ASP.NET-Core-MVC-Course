using ASP.NET_Core_course.Data.Interfaces;
using ASP.NET_Core_course.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_course.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _carsCategory;

        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _carsCategory = carsCategory;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Page with cars";
            CarListViewModel model = new CarListViewModel();
            model.AllCars = _allCars.GetAll;
            model.CurrentCategory = "Cars";
            return View(model);
        }
    }
}