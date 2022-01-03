using ASP.NET_Core_course.Data.Models;

namespace ASP.NET_Core_course.Data.Interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
}