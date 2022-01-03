using ASP.NET_Core_course.Data;
using ASP.NET_Core_course.Data.Interfaces;
using ASP.NET_Core_course.Data.Models;
using ASP.NET_Core_course.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP.NET_Core_course.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            _allOrders = allOrders;
            _shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.CartItems = _shopCart.GetCartItems();
            if (_shopCart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Cart is empty");
            }

            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Order successfully completed";
            return View();
        }
            
    }
}