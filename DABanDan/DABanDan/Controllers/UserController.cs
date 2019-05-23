using DABanDan.Common;
using DABanDan.DAO;
using DABanDan.InputModels.DangKy;
using DABanDan.InputModels.DangNhap;
using DABanDan.Models;
using System.Web.Mvc;

namespace DABanDan.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(DangKyModel model)
        {

            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.KTraEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email này đã tồn tại");
                }
                else if (dao.KTraUserName(model.TenUser))
                {
                    ModelState.AddModelError("", "Tên đăng nhập này đã tồn tại");
                }
                else
                {
                    var user = new NguoiDung();
                    user.TenUser = model.TenUser;
                    user.Ho = model.Ho;
                    user.Ten = model.Ten;
                    user.Email = model.Email;
                    user.SDT = model.SDT;
                    user.MatKhau = model.MatKhau;
                    user.DiaChi = model.DiaChi;

                    var dem = dao.Insert(user);
                    if (dem.Length > 0)
                    {
                        ViewBag.Success = "Đăng Ký thành công";
                        model = new DangKyModel();
                    }
                    else
                    {
                        ViewBag.Success = "Đăng Ký không thành công";
                    }
                }
            }
            return View(model);
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(DangNhapModel model)
        {
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDao();
                    var kq = dao.Login(model.TenUser, model.MatKhau);
                    if (kq)
                    {
                        var user = dao.GetById(model.TenUser);
                        UserLogin userSesion = new UserLogin();
                        Session.Add(CommonConstans.User, userSesion);
                            userSesion.UserName = user.TenUser;
                            userSesion.UserID = user.MaND;
                            userSesion.DiaChi = user.DiaChi;

                        Session.Add(CommonConstans.USER_SESSION, userSesion);
                        return RedirectToAction("Index", "Default");
                    }
                    else
                    {
                        ViewBag.Error = "Tài khoản hoặc Mật khẩu không chính xác";
                    }

                }
                else
                {
                    ModelState.AddModelError("Error", "Lỗi !");
                }
                return View(model);
            }
        }

        public ActionResult DangXuat()
        {
            Session[CommonConstans.USER_SESSION] = null;
            return Redirect("/");
        }


    }
}