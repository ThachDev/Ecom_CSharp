using Electronic_Store_Web_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Electronic_Store_Web_Online.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {            
            List<SanPham> dl = Common.getProductsByLoaiSP(1);
            return View();
        }
        public ActionResult AddToCart (string maSP)
        {
            //---Lấy giỏ hàng từ Session ra.
            CartShop shop = Session["gioHang"] as CartShop;
            //---Thêm sản phẩm vừa chọn mua vào giỏ hàng
            shop.addItem(maSP);
            //-- Cập nhật lại giỏ hàng vào trong Session.
            Session["gioHang"] = shop;
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}