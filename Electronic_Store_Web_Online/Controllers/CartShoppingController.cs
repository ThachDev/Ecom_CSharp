using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store_Web_Online.Models;
namespace Electronic_Store_Web_Online.Controllers
{
    public class CartShoppingController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //---Lấy giỏ hàng từ session
            CartShop shop = Session["gioHang"] as CartShop;
            //---Truyền ra ngoài View
            ViewData["Cart"] = shop;
            return View();
        }
        //--Nút +
        public ActionResult Increase(string maSP)
        {
            //---Lấy giỏ hàng từ session
            CartShop shop = Session["gioHang"] as CartShop;
            shop.addItem(maSP);
            Session["gioHang"] = shop; 
            return RedirectToAction("Index");
        }
        //----Nút - 
        public ActionResult Decrease(string maSP)
        {
            CartShop shop = Session["gioHang"] as CartShop;
            shop.Decrease(maSP);
            Session["gioHang"] = shop;
            return RedirectToAction("Index");
        }
        //---Nút X
        public ActionResult RemoveItem(string maSP)
        {
            CartShop shop = Session["gioHang"] as CartShop;
            shop.deleteItem(maSP);
            Session["gioHang"] = shop;
            return RedirectToAction("Index");
        }
    }
}