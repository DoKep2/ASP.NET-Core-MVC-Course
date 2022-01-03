using ASP.NET_Core_course.Data.Interfaces;
using ASP.NET_Core_course.Data.Models;
using ASP.NET_Core_course.Data.Repository;
using ASP.NET_Core_course.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_course.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            _carRepository = carRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetCartItems();
            _shopCart.CartItems = items;
            var obj = new ShopCartViewModel()
            {
                ShopCart = _shopCart
            };
            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _carRepository.GetById(id);
            if (item != null)
            {
                _shopCart.AddCartItem(item);
            }

            return RedirectToAction("Index");
        }
    }
}