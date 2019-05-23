using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DABanDan
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //----------------------------------------------------Hiển thị sp theo loại--------------------------------------------------
            routes.MapRoute(
                name: "Loai Dan",
                url: "san-pham/{ml}",
                defaults: new { controller = "Product", action = "TTLoaiSP", id = UrlParameter.Optional },
                namespaces: new[] { "DABanDan.Controllers" }
            );
           
            routes.MapRoute(
                name: "Add Cart",
                url: "Them-Gio-Hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "DABanDan.Controllers" }
            );

            routes.MapRoute(
               name: "Thanh Toán Thành Công",
               url: "hoan-thanh",
               defaults: new { controller = "Cart", action = "ThanhCong", id = UrlParameter.Optional },
               namespaces: new[] { "DABanDan.Controllers" }
           );

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "DABanDan.Controllers" }
            );

            routes.MapRoute(
               name: "DangKy",
               url: "dang-ky",
               defaults: new { controller = "User", action = "DangKy", id = UrlParameter.Optional },
               namespaces: new[] { "DABanDan.Controllers" }
           );

            routes.MapRoute(
             name: "DangNhap",
             url: "dang-nhap",
             defaults: new { controller = "User", action = "DangNhap", id = UrlParameter.Optional },
             namespaces: new[] { "DABanDan.Controllers" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
