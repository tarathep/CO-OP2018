using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorSyntax
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int RoleId { get; set; }
        public int ProvinceId { get; set; }
    }
}