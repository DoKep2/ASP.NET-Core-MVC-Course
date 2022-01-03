using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASP.NET_Core_course.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Enter name")]
        [MinLength(3)]
        [Required(ErrorMessage = "Lenght should be not less than 3")]
        public string Name { get; set; }
        [Display(Name = "Enter surname")]
        [MinLength(3)]
        [Required(ErrorMessage = "Lenght should be not less than 3")]
        public string SurName { get; set; }
        [Display(Name = "Enter address")]
        public string Address { get; set; }
        [Display(Name = "Enter Phone number")]
        [MinLength(11)]
        [Required(ErrorMessage = "Lenght should be not less than 11")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}