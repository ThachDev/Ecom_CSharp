using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store_Web_Online.Models;

namespace Electronic_Store_Web_Online.Controllers
{
    public class SingleController : Controller
    {
        // GET: Single
        public ActionResult Index(string MaSanPham)
        {
            //--Gọi chi tiết nội dung của sản phẩm dựa trên maSP 
            //--Tạo db context
            ShopOnlineConnection db = new ShopOnlineConnection();
            SanPham x = db.SanPhams.Where(sp => sp.maSP.Equals(MaSanPham)).First<SanPham>();
            //-- Truyền sản phẩm chi tiết cần xem dựa trên View Data
            ViewData["SPChiTietCanXem"] = x;
            return View();
        }
         
    }
}