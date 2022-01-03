using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ASP.NET_Core_course.Data.Interfaces;
using ASP.NET_Core_course.Data.Models;
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
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            IEnumerable<Car> carsToShow;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                carsToShow = _allCars.GetAll.OrderBy(car => car.Id);
            }
            else
            {
                carsToShow = _allCars.GetAll
                    .Where(car => car.Category.name.Equals(category, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(car => car.Id);
                currentCategory = category;
            }
            ViewBag.Title = "Page with cars";
            CarListViewModel model = new CarListViewModel();
            model.AllCars = carsToShow;
            model.CurrentCategory = currentCategory;
            return View(model);
        }
    }
}