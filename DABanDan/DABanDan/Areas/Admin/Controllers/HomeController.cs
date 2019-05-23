using DABanDan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DABanDan.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        Database db = new Database();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var kq = db.NguoiDungs.ToList().OrderBy(s => s.TenUser);
            return View(kq);
        }
    }
}