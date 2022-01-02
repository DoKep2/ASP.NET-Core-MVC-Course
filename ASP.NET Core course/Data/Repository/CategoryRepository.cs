using System.Collections.Generic;
using ASP.NET_Core_course.Data.Interfaces;
using ASP.NET_Core_course.Data.Models;

namespace ASP.NET_Core_course.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent _appDbContent;

        public CategoryRepository(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Category> AllCategories => _appDbContent.Categories;
    }
}