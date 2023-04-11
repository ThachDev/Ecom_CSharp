using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store_Web_Online.Models;
namespace Electronic_Store_Web_Online.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(int ma)
        {
            List<SanPham> list;
            if (ma== 0) { list = Common.getProducts(); } 
            else { list = Common.getProductsByLoaiSP(ma); }
            ViewData["list"] = list;
            return View();
        }
    }
}