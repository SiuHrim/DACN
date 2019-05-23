using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DABanDan.InputModels.DangNhap
{
    public class DangNhapModel
    {
        [Key]
        [Display(Name = "Tên Đăng Nhập")]
        [Required(ErrorMessage = "Vui Lòng Nhập Tên Tài Khoản")]
        public string TenUser { set; get; }

        [Display(Name ="Mật Khẩu")]
        [Required(ErrorMessage ="Vui Lòng Nhập Mật Khẩu")]
        public string MatKhau { set; get; }
    }
}