using System;
using ASP.NET_Core_course.Data.Interfaces;
using ASP.NET_Core_course.Data.Models;

namespace ASP.NET_Core_course.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent _appDbContent;
        private readonly ShopCart _shopCart;

        public OrdersRepository(AppDBContent appDbContent, ShopCart shopCart)
        {
            _appDbContent = appDbContent;
            _shopCart = shopCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _appDbContent.Orders.Add(order);
            _appDbContent.SaveChanges();
            var items = _shopCart.CartItems;
            foreach (var item in items)
            {
                var orderDetails = new OrderDetails()
                {
                    CarId = item.Car.Id,
                    OrderId = order.Id,
                    Price = item.Car.Price
                };
                _appDbContent.OrderDetails.Add(orderDetails);
            }

            _appDbContent.SaveChanges();
        }
    }
}