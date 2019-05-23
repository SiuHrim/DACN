using System.ComponentModel.DataAnnotations;

namespace DABanDan.InputModels.DangKy
{
    public class DangKyModel
    {

        [Key]
        public long ID { set; get; }
        [Required(ErrorMessage ="Bạn cần nhập vào ô này")]
        public string TenUser { set; get; }

        [Required(ErrorMessage = "Bạn cần nhập vào ô này")]
        [StringLength(20,MinimumLength =4,ErrorMessage ="Mật khẩu ít nhất 6 kí tự")]
        public string MatKhau { set; get; }

        [Required(ErrorMessage = "Bạn cần nhập vào ô này")]
        public string Ho { set; get; }

        [Required(ErrorMessage = "Bạn cần nhập vào ô này")]
        public string Ten { set; get; }

        [Required(ErrorMessage = "Bạn cần nhập vào ô này")]
        public string DiaChi { set; get; }

        [Required(ErrorMessage = "Bạn cần nhập vào ô này")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Bạn cần nhập vào ô này")]
        public string SDT { set; get; }



    }
}