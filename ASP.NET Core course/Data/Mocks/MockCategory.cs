using System.Collections.Generic;
using System.Security.AccessControl;
using ASP.NET_Core_course.Data.Interfaces;
using ASP.NET_Core_course.Data.Models;

namespace ASP.NET_Core_course.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {name = "Electro", description = "Electro desc"},
                    new Category {name = "Petrol", description = "Petrol desc"},
                };
            }
        }
    }
}