using System.Collections.Generic;

namespace ASP.NET_Core_course.Data.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Car> Cars { get; set; }
    }
}