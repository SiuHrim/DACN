using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DABanDan.Models;
using DABanDan.DAO;
using DABanDan.Areas.Admin.Models;
using DABanDan.Common;

namespace DABanDan.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Admin/LoginAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginAdmin(LoginModel lg)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var kq = dao.Login(lg.UserName, lg.PassWord);
                if (kq)
                {
                    var user = dao.GetById(lg.UserName);
                    var userSesion = new UserLogin();
                    userSesion.UserName = user.TenUser;
                    userSesion.UserID = user.MaND;

                    Session.Add(CommonConstans.USER_SESSION, userSesion);
                    return RedirectToAction("Index", "Home");
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
            return View("Index");
        }

    }
}
