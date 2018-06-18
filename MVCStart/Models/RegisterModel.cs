using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCStart.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="โปรดระบุชื่อ")]
        //[StringLength(50, MinimumLength = 6)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{6,40}$",ErrorMessage ="ชื่อต้องเป็นภาษาอังกฤษ 6-40 ตัวอักษร")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage ="รูปแบบอีเมล์ไม่ถูกต้อง")]
        [Required]
        [Display(Name ="E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string Gender { get; set; }
        public bool Newsletter { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        public string Province { get; set; }
    }
}