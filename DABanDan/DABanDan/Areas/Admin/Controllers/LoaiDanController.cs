using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DABanDan.Models;
using PagedList;
namespace DABanDan.Areas.Admin.Controllers
{
    public class LoaiDanController : BaseController
    {
        Database dl = new Database();
        // GET: Admin/LoaiDan
        public ActionResult Index(int? Page)
        {
            int PageN = (Page ?? 1);
            int PageZ = 5;
             return View(dl.LoaiDans.ToList().OrderBy(s => s.MaLoai).ToPagedList(PageN, PageZ));
        }
    //------------------------------------------------------------------------------------
    public ActionResult CreateLD()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateLD(LoaiDan ld)
    {
        if (ModelState.IsValid)
        {
            dl.LoaiDans.Add(ld);
            dl.SaveChanges();
            return RedirectToAction("Index", "LoaiDan");
        }
        return View(ld);
    }
    // -------------------------------------------------------------------------------
    public ActionResult EditLD(String idld)
    {
        LoaiDan ld = dl.LoaiDans.SingleOrDefault(s => s.MaLoai == idld);
        return View(ld);
    }
    [HttpPost]
    public ActionResult EditLD(LoaiDan ld, FormCollection form)
    {
        if (ModelState.IsValid)
        {
            dl.Entry(ld).State = System.Data.Entity.EntityState.Modified;
            dl.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }
    // -------------------------------------------------------------------------------
    public ActionResult DeleteLD(String idld)
    {
            LoaiDan ld = dl.LoaiDans.SingleOrDefault(s => s.MaLoai == idld);
            return View(ld);
    }
    [HttpPost, ActionName("DeleteLD")]
    public ActionResult DeleteLDs(String idld)
    {
            LoaiDan ld = dl.LoaiDans.SingleOrDefault(s => s.MaLoai == idld);
        dl.LoaiDans.Remove(ld);
        dl.SaveChanges();
        return RedirectToAction("Index");
    }
}
}