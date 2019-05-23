using System.Linq;
using System.Web.Mvc;
using DABanDan.Models;
using DABanDan.InputModels.Product;
using DABanDan.DAO;
using System;

namespace DABanDan.Controllers
{
    public class DefaultController : Controller
    {
        Database db = new Database();
        // GET: Index
        public ActionResult Index(string tk)
        {
            var kq = new ProductDao().DanhSachSP(tk).Select(p => new ProductViewModel
            {
                Id = p.MaSP,
                Title = p.TenSP,
                ImageUrl = p.IMG,
                Point = p.DonGia.ToString(),
                Description = p.MoTa,
                Color = p.MauSac,
            });
            var ds = db.SanPhams.OrderByDescending(s => s.MaSP).Select(p => new ProductViewModel
            {
                Id = p.MaSP,
                Title = p.TenSP,
                ImageUrl = p.IMG,
                Point = p.DonGia.ToString(),
                Description = p.MoTa,
                Color = p.MauSac,
                Level = p.Lv
            });
            var results = new ProductIndexModel()
            {
                TimKiem = kq,
                Products = ds
            };
            return View(results);
        }

        public ActionResult Detail(int id)
        {
            var sp = new ProductDao().ViewDetail(id);
            return View( new ProductViewModel()
            {
                Id = sp.MaSP,
                Title = sp.TenSP,
                Color = sp.MauSac,
                Point = sp.DonGia.ToString(),
                ImageUrl = sp.IMG,
                Description = sp.MoTa
       
            });
        }
    }
}