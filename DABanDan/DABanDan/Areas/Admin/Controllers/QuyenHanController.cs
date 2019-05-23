using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DABanDan.Models;
using PagedList;
namespace DABanDan.Areas.Admin.Controllers
{
    public class QuyenHanController : BaseController
    {
        private Database db = new Database();
        // GET: Admin/QuyenHan
        public ActionResult Index(int? Page)
        {
            int PageN =( Page ?? 1);
             int PageZ = 5;
            return View(db.QuyenHans.ToList().OrderBy(s => s.ID).ToPagedList(PageN,PageZ));
        }
        //------------------------------------------------------------------------------------
        public ActionResult CreateQH()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQH(QuyenHan qh)
        {
            if (ModelState.IsValid)
            {
                db.QuyenHans.Add(qh);
                db.SaveChanges();
            return RedirectToAction("Index","QuyenHan");
            }
            return View(qh);
        }
        // -------------------------------------------------------------------------------
        public ActionResult EditQH(int idqh)
        {
            QuyenHan qh = db.QuyenHans.SingleOrDefault(s => s.ID == idqh);
            return View(qh);
        }
        [HttpPost]
        public ActionResult EditQH(QuyenHan qh, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        // -------------------------------------------------------------------------------
        public ActionResult DeleteQH(int idqh)
        {
            QuyenHan qh = db.QuyenHans.SingleOrDefault(s => s.ID == idqh);
            return View(qh);
        }
        [HttpPost,ActionName("DeleteQH")]
        public ActionResult DeleteQHs(int idqh)
         {
            QuyenHan qh = db.QuyenHans.SingleOrDefault(s => s.ID == idqh);
            db.QuyenHans.Remove(qh);
            db.SaveChanges(); 
            return RedirectToAction("Index");
         }
            
        }
    }
