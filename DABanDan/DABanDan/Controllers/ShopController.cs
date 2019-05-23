using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DABanDan.Models;
using DABanDan.DAO;
using DABanDan.InputModels.Category;
using DABanDan.InputModels.Product;
using System.Web.UI;
using PagedList;

namespace DABanDan.Controllers
{
    public class ShopController : Controller
    {
        Database db = new Database();
        // GET: Shop
        public ActionResult Index()
        {
            var prDao = new ProductDao();
            ViewBag.lvsp = prDao.ListLVSanPham();
            ViewBag.dongiasp = prDao.ListDonGiaSanPham();    
            return View();
        }
    }
}