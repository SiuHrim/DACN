using DABanDan.Common;
using DABanDan.DAO;
using DABanDan.InputModels.GioHang;
using DABanDan.Models;
using DABanDan.OutPutModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DABanDan.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            List<GioHang> cart = Session[CommonConstans.CartSession] as List<GioHang>;
  
            return View(cart);
        }
        //view indẽ gio hang
        //-------------------------------Xóa tat ca Gio Hàng--------------------------------------------------
        //public RedirectToRouteResult DeleteAll()
        //{
        //    List<GioHang> giohang = Session[CommonConstans.CartSession] as List<GioHang>;
        //    GioHang itemXoa = giohang.FirstOrDefault(m => m.MaSP == SanPhamID);
        //    if (itemXoa != null)
        //    {
        //        giohang.Remove(itemXoa);
        //    }
        //    return RedirectToAction("Index");
        //}
        //-------------------------------Xóa 1 sp--------------------------------------------------
        public RedirectToRouteResult Delete(int SanPhamID)
        {
            List<GioHang> giohang = Session[CommonConstans.CartSession] as List<GioHang>;
            GioHang itemXoa = giohang.FirstOrDefault(m => m.MaSP == SanPhamID);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }
        //-------------------------------Cập nhật Gio Hàng--------------------------------------------------
        public RedirectToRouteResult Update(int SanPhamID, int soluongmoi)
        {
            // tìm carditem muon sua
            List<GioHang> giohang = Session[CommonConstans.CartSession] as List<GioHang>;
            GioHang itemSua = giohang.FirstOrDefault(m => m.MaSP == SanPhamID);
            if (itemSua != null)
            {
                itemSua.SoLuong = soluongmoi;
            }
            return RedirectToAction(nameof(Index));
        }
        //-------------------------------Thêm sp vào Giỏ Hàng--------------------------------------------------
        public RedirectToRouteResult AddItem(int maSP)
        {
            if (Session[CommonConstans.CartSession] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session[CommonConstans.CartSession] = new List<GioHang>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }

            List<GioHang> giohang = Session[CommonConstans.CartSession] as List<GioHang>;  // Gán qua biến giohang dễ code

            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa

            if (giohang.FirstOrDefault(m => m.MaSP == maSP) == null) // ko co sp nay trong gio hang
            {
                SanPham sp = new ProductDao().ViewDetail(maSP); // tim sp theo sanPhamID// gọi hàm lấy id

                GioHang newItem = new GioHang()
                {
                    MaSP = maSP,
                    TenSP = sp.TenSP,
                    SoLuong = 1,
                    HinhAnh = sp.IMG,
                    DonGia = sp.DonGia

                };  // Tạo ra 1 CartItem mới

                giohang.Add(newItem);  // Thêm CartItem vào giỏ 
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                GioHang cardItem = giohang.FirstOrDefault(m => m.MaSP == maSP);
                cardItem.SoLuong++;
            }

            // Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public PartialViewResult CtGioHang()
        {
            var giohang = Session[CommonConstans.CartSession];
            var list = new List<GioHang>();
            if(giohang != null)
            {
                list = (List<GioHang>)giohang;
            }
            return PartialView(list);
        }

        //[HttpGet]
        //public ActionResult ThanhToan()
        //{
        //    var giohang = Session[CommonConstans.CartSession];
        //    var list = new List<GioHang>();
        //    if (giohang != null)
        //    {
        //        list = (List<GioHang>)giohang;
        //    }
        //    return View(list);
        //}

        //[HttpPost]
        //public ActionResult ThanhToan(HoaDon hoadon)
        //{
        //    var user = Session[CommonConstans.User];
        //    if (user == null)
        //    {
        //       return RedirectToAction("DangNhap", "User");
        //    }
        //    //var cart =(GioHang)Session[CommonConstans.CartSession];
        //    hoadon = new HoaDon();
        //        hoadon.NgayLHD = DateTime.Now;
        //        hoadon.NgayGiao = DateTime.Now.AddDays(3);
        //        hoadon.VAT = "10";
        //        hoadon.TinhTrang = "N";
        //        hoadon.TongTien = 10000;

        //    try
        //    {
        //        var id = new DonHangDAO().Insert(hoadon);
        //        var giohang = (List<GioHang>)Session[CommonConstans.CartSession];
        //        var chitietDAO = new ChiTietDonHangDAO();
        //        foreach (var item in giohang)
        //        {
        //            var chitiethoadon = new CTHoaDon();
        //            chitiethoadon.MaSP = item.SanPham.MaSP;
        //            chitiethoadon.MaHD = id;
        //            chitiethoadon.SoLuong = item.SanPham.SoLuong;
        //            chitiethoadon.ThanhTien = item.SanPham.DonGia;

        //            chitietDAO.Insert(chitiethoadon);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return Redirect("/Loi-thanh-toan");
        //    }
        //    return Redirect("/hoan-thanh");
        //}

        public ActionResult ThanhCong()
        {
            return View();
        }
    }
}