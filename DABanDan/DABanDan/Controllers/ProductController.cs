using DABanDan.DAO;
using DABanDan.InputModels.Product;
using DABanDan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DABanDan.Controllers
{
    public class ProductController : Controller
    {
        Database db = new Database();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult LoaiSP()
        {
            var model = new ProductCategoryDao().ListALL();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult HieuSP()
        {
            var model = new ProductCategoryDao().ListALLs();
            return PartialView(model);
        }

        public ActionResult TTLoaiSP(string ml , int page = 1, int pageSize = 4)
        {
            var kq = new CategoryDao().ViewDetail(ml);
            ViewBag.TTLoaiSP = kq;
            int totalRecord = 0;
            var model = new ProductDao().DSLoaiSP(ml,ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        public ActionResult TTHieuSP(string mh, int page = 1, int pageSize = 6)
        {
           
         
            int totalRecord = 0;
            var model = new ProductDao().DSHieuSP(mh, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        //-------------------------Tìm Kiếm------------------------------------------------------------
        //public ActionResult TimKiem(string keyword, int page = 1, int pageSize = 4)
        //{
           
        //    int totalRecord = 0;
        //    var model = new ProductDao().Search(keyword, ref totalRecord, page, pageSize);

        //    ViewBag.Total = totalRecord;
        //    ViewBag.Page = page;
        //    ViewBag.Keyword = keyword;
        //    int maxPage = 5;
        //    int totalPage = 0;

        //    totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
        //    ViewBag.TotalPage = totalPage;
        //    ViewBag.MaxPage = maxPage;
        //    ViewBag.First = 1;
        //    ViewBag.Last = totalPage;
        //    ViewBag.Next = page + 1;
        //    ViewBag.Prev = page - 1;
        //    return View(model);
        //}

        //-------------------------Tìm Kiếm DS Liên Quan------------------------------------------------------------
        public ActionResult ResultSearch(string q)
        {
            if (q == null)
            {
                return ViewBag.Result = "Ko có";
            }
            var result = new ProductDao().DanhSachSP(q);
            return View(result);
        }

    }
}