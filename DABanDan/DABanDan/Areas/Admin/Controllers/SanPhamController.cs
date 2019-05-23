using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DABanDan.Models;
using PagedList;
using DABanDan.InputModels.Product;
using DABanDan.DAO;

namespace DABanDan.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
       private Database db = new Database();
        // GET: Admin/SanPham
        public ActionResult Index(string searchString,int page = 1, int pageSize =3)
        {
            var dao = new UserDao();
            var model = dao.ListAllPagingsp(searchString, page, pageSize);
            return View(model);
        }

        //--------------------------------------------------CreateSP---------------------------------------------
        public ActionResult CreateSP()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiDans.ToList(),"MaLoai","TenLoai");
            ViewBag.MaHieu = new SelectList(db.HieuDans.ToList(), "MaHieu", "TenHieu");
           // ViewBag.MaIMG = new SelectList(db.HinhAnhs.ToList(), "MaIMG", "Link");
             return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSP(SanPham sp)
        {
            ViewBag.MaLoai = new SelectList(db.LoaiDans.ToList(), "MaLoai", "TenLoai");
            ViewBag.MaHieu = new SelectList(db.HieuDans.ToList(), "MaHieu", "TenHieu");
            //ViewBag.MaImg = new SelectList(db.HinhAnhs.ToList(), "MaImg", "Link");
            if (ModelState.IsValid)
             {
                
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index","SanPham");
             }
            return View(sp);
        }
        //--------------------------------------------------EditSP---------------------------------------------
        public ActionResult EditSP(int idsp)
        {
            ViewBag.MaLoai = new SelectList(db.LoaiDans.ToList(), "MaLoai", "TenLoai");
            ViewBag.MaHieu = new SelectList(db.HieuDans.ToList(), "MaHieu", "TenHieu");
            SanPham sp = db.SanPhams.SingleOrDefault(s => s.MaSP == idsp);
            return View(sp);
        }
        [HttpPost]
        public ActionResult EditSP(SanPham sp,FormCollection form)
        {
            ViewBag.MaLoai = new SelectList(db.LoaiDans.ToList(), "MaLoai", "TenLoai");
            ViewBag.MaHieu = new SelectList(db.HieuDans.ToList(), "MaHieu", "TenHieu");
            if (ModelState.IsValid)
            { 
                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                 db.SaveChanges(); 
            return RedirectToAction("InDex");
             }
            return View();
        }

        //--------------------------------------------------DeleteSP---------------------------------------------
        public ActionResult DeleteSP(int idsp)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(s => s.MaSP == idsp);
            return View(sp);
        }
        [HttpPost,ActionName("DeleteSP")]
        public ActionResult DeleteSPs(int idsp)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(s => s.MaSP == idsp);
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }   
    }
}