using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Electronic_Store_Web_Online.Models;
namespace Electronic_Store_Web_Online.Areas.PrivatePage.Controllers
{
    public class ArticleListController : Controller
    {
        //--- Khai báo đối tượng để khi cần có thể tự sinh ra. 
        private static ShopOnlineConnection db = new ShopOnlineConnection();
        private static bool daDuyet;
        [HttpGet]
        public ActionResult Index(string IsActive)
        {
            daDuyet = IsActive !=null && IsActive.Equals("1");
            CapNhatDuLieu();
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string maBV)
        {
            //---Dùng lệnh để xóa bài viết dựa vào mã bài viết
            BaiViet x = db.BaiViets.Find(maBV);
            db.BaiViets.Remove(x);
            //---Cập nhật Database
            db.SaveChanges();
            //---Hiển thị lại danh sách với các danh sách sau cập nhật            
            CapNhatDuLieu();
            return View("Index");

        }
        [HttpPost]
        public ActionResult Active(string maBaiViet)
        {
            //---Dùng lệnh để cấm bài viết dựa vào mã bài viết
            BaiViet x = db.BaiViets.Find(maBaiViet);
            x.daDuyet = !daDuyet;
            //---Cập nhật Database
            db.SaveChanges();
            //---Hiển thị lại danh sách với các danh sách sau cập nhật
            CapNhatDuLieu();
            return View("Index");
        }
        /// <summary>
        /// Hàm phục vụ cho mục tiêu cập nhật dữ liệu View của Controllers này thông qua  đối tượng ViewData. 
        /// </summary>
        private void CapNhatDuLieu()
        {
            List<BaiViet> l = db.BaiViets.Where(x => x.daDuyet == daDuyet).ToList<BaiViet>();
            ViewData["DanhSachBV"] = l;
            ViewBag.TacDungCuaNut = daDuyet ? "Cấm hiển thị " : "Kiểm duyệt bài ";
            ViewBag.TdTile = daDuyet ? "Cấm hiển thị ..." : "Duyệt bài viết...";
        }
    }
}