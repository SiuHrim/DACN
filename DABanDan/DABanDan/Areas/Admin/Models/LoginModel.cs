using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DABanDan.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời Nhập UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời Nhập PassWord")]
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}