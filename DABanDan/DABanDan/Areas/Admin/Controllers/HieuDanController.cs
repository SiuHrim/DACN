using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DABanDan.Models;
using PagedList;
namespace DABanDan.Areas.Admin.Controllers
{
    public class HieuDanController : BaseController
    {
        Database dl = new Database();
        // GET: Admin/HieuDan
        public ActionResult Index(int? Page)
        {
            int PageN = (Page ?? 1);
            int PageZ = 5;
            return View(dl.HieuDans.ToList().OrderBy(s => s.MaHieu).ToPagedList(PageN, PageZ));
        }
        //------------------------------------------------------------------------------------
        public ActionResult CreateHD()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHD(HieuDan hd)
        {
            if (ModelState.IsValid)
            {
                dl.HieuDans.Add(hd);
                dl.SaveChanges();
                return RedirectToAction("Index", "HieuDan");
            }
            return View(hd);
        }
        // -------------------------------------------------------------------------------
        public ActionResult EditHD(String idhd)
        {
            HieuDan hd = dl.HieuDans.SingleOrDefault(s => s.MaHieu == idhd);
            return View(hd);
        }
        [HttpPost]
        public ActionResult EditHD(HieuDan hd, FormCollection form)
        {
            if (ModelState.IsValid)
            {
               dl.Entry(hd).State = System.Data.Entity.EntityState.Modified;
                dl.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        // -------------------------------------------------------------------------------
        public ActionResult DeleteHD(String idhd)
        {
            HieuDan hd = dl.HieuDans.SingleOrDefault(s => s.MaHieu == idhd);
            return View(hd);
        }
        [HttpPost, ActionName("DeleteQH")]
        public ActionResult DeleteHDs(String idhd)
        {
            HieuDan hd = dl.HieuDans.SingleOrDefault(s => s.MaHieu == idhd);
            dl.HieuDans.Remove(hd);
            dl.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}