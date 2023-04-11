using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store_Web_Online.Models;
namespace Electronic_Store_Web_Online.Controllers
{
    public class BlogsContentController : Controller
    {
        // GET: BlogsContent
        public ActionResult Index(string maBV)
        {
            ShopOnlineConnection db = new ShopOnlineConnection();
            BaiViet x = db.BaiViets.Where(z => z.maBV == maBV).First<BaiViet>();
            ViewData["BCX"] = x;
            return View();
        }
    }
}