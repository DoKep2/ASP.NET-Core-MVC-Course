using System.Collections.Generic;
using ASP.NET_Core_course.Data.Models;

namespace ASP.NET_Core_course.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}