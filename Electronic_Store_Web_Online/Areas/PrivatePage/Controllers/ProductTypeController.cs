using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store_Web_Online.Models;
namespace Electronic_Store_Web_Online.Areas.PrivatePage.Controllers
{
    public class ProductTypeController : Controller
    {
        //--- Khai báo đối tượng chỉ hiển thị trong ProductType
        private static ShopOnlineConnection db = new ShopOnlineConnection();
        private static bool daDuyet;

        
        [HttpGet]
        public ActionResult Index(string IsActiveSP)
        {
            daDuyet = IsActiveSP != null && IsActiveSP.Equals("1");
            //---- Truyền ra ngoài View
            CapNhatDLGiaoDienSP(); 
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string maSanPham)
        {
            //--- Bước 1: Dùng lệnh để xóa sản phẩm dựa theo mã sản phẩm
            SanPham x = db.SanPhams.Find(maSanPham);
            db.SanPhams.Remove(x);
            //--- Bước 2: Cập nhật Database
            db.SaveChanges();
            //--- Bước 3: Hiển thị lại danh sách sau khi xóa
            //---- Truyền ra ngoài View
            CapNhatDLGiaoDienSP();
            return View("Index");
        }
        [HttpPost]
        public ActionResult Active(string maSanPham)
        {
            //--- Bước 1: Dùng lệnh để cấm sản phẩm dựa theo mã sản phẩm
            SanPham x = db.SanPhams.Find(maSanPham);
            x.daDuyet = !daDuyet;
            //--- Bước 2: Cập nhật Database
            db.SaveChanges();
            //--- Bước 3: Hiển thị lại danh sách sau khi xóa
            //---- Truyền ra ngoài View
            CapNhatDLGiaoDienSP();
            return View("Index");
        }
        /// <summary>
        /// Hàm phục vụ cho mục tiêu cập nhật dữ liệu View của Controllers này thông qua  đối tượng ViewData. 
        /// </summary>
        private void CapNhatDLGiaoDienSP()
        {
            List<SanPham> l = db.SanPhams.Where(x => x.daDuyet == daDuyet).ToList<SanPham>();
            ViewData["DanhSachSP"] = l;
            ViewBag.TDungCuaNut = daDuyet ? "Cấm hiển thị " : "Kiểm duyệt bài ";
            ViewBag.TdTile = daDuyet ? "Cấm hiển thị ..." : "Duyệt bài viết...";
        }
    }
}