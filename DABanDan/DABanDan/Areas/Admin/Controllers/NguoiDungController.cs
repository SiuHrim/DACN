using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DABanDan.Models;
using PagedList;
using DABanDan.DAO;

namespace DABanDan.Areas.Admin.Controllers
{
    public class NguoiDungController : BaseController
    {
        private Database db = new Database();
        // GET: Admin/NguoiDung
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }
#region Tao nguoi dung
        public ActionResult CreateND()
        {
            ViewBag.ID = new SelectList(db.QuyenHans.ToList(),"ID","TenQH","Levels");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateND(NguoiDung nd)
        {
            ViewBag.ID = new SelectList(db.QuyenHans.ToList(), "ID", "TenQH", "Levels");
            if (ModelState.IsValid)
            {
                //nd.MaND = "";
                db.NguoiDungs.Add(nd);
                db.SaveChanges();
                return RedirectToAction("Index", "NguoiDung");
            }
            return View(nd);
        }
#endregion
        //----------------------------------------Edit Người Dùng------------------------------------------------------

        public ActionResult EditND(int idnd)
        {
            ViewBag.ID = new SelectList(db.QuyenHans.ToList(), "ID", "TenQH", "Levels");
            NguoiDung nd = db.NguoiDungs.SingleOrDefault(s => s.MaND == idnd);
            return View(nd);
        }
        [HttpPost]
        public ActionResult EditND(NguoiDung nd, FormCollection f)
        {
            ViewBag.ID = new SelectList(db.QuyenHans.ToList(), "ID", "TenQH", "Levels");
            if (ModelState.IsValid)
            {
                db.Entry(nd).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nd);
        }
        //----------------------------------------Delete Người Dùng------------------------------------------------------
        public ActionResult DeleteND(int idnd)
        {
            NguoiDung nd = db.NguoiDungs.SingleOrDefault(s => s.MaND == idnd);
            return View(nd);
        }
        [HttpPost,ActionName("DeleteND")]
        public ActionResult DeleteNDs(int idnd)
        {
            NguoiDung nd = db.NguoiDungs.SingleOrDefault(s => s.MaND == idnd);
            db.NguoiDungs.Remove(nd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}       