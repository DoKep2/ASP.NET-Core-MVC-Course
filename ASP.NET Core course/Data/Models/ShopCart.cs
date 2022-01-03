using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NET_Core_course.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent _appDbContent;

        public ShopCart(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> CartItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context)
            {
                ShopCartId = shopCartId
            };
        }

        public void AddCartItem(Car car)
        {
            _appDbContent.ShopCartItems.Add(new ShopCartItem()
            {
                ShopCartId = this.ShopCartId,
                Car = car,
                Price = car.Price
            });
            _appDbContent.SaveChanges();
        }

        public List<ShopCartItem> GetCartItems()
        {
            return _appDbContent.ShopCartItems
                .Where(c => c.ShopCartId == this.ShopCartId)
                .Include(s => s.Car)
                .ToList();
        }
    }
}