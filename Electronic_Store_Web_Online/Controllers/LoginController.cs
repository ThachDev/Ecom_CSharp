using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store_Web_Online.Models;
namespace Electronic_Store_Web_Online.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //---Dùng để chứng thực Token khi đăng nhập vào Page
        
        //---Nếu không nhập đúng sẽ tự trả về Index/Login
        [ValidateAntiForgeryToken]
        public ActionResult Index(string tk, string mk)
        {
            string Pass = EnCode.encryptSHA256(mk);
            //--Đọc thông tin tài khoản từ Database Thông qua Data Models để kiểm tra thông tin đăng nhập.
            TaiKhoan ttdn = new ShopOnlineConnection().TaiKhoans.Where(x => x.taiKhoan1.Equals(tk.ToLower().Trim()) && x.matKhau.Equals(Pass)).First<TaiKhoan>();
            //--Lấy được thông tin từ Database và đúng thì cho phép vào PrivatePage
            bool isAuthenic = ttdn !=null && ttdn.taiKhoan1.Equals(tk.ToLower().Trim()) && ttdn.matKhau.Equals(Pass);
            if (isAuthenic)
            {
                Session["ttDangNhap"] = ttdn;
            return  RedirectToAction("Index","DashBoard", new {Area = "PrivatePage"});
            }

            //---Nếu không nhập đúng sẽ tự trả về Index/Login
            return View();
        }
    }
}       