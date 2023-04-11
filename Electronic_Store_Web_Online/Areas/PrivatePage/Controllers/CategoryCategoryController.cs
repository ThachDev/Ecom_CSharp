using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store_Web_Online.Models;
namespace Electronic_Store_Web_Online.Areas.PrivatePage.Controllers
{
    public class CategoryCategoryController : Controller
    {
        private static bool isUpdate = false;
        [HttpGet]
        // GET: PrivatePage/CategoryCategory
        public ActionResult Index()
        {
            List<LoaiSP> l = new ShopOnlineConnection().LoaiSPs.OrderBy(x => x.tenLoai).ToList<LoaiSP>();
            ViewData["DanhSachLoai"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoaiSP x)
        {
            ShopOnlineConnection db = new ShopOnlineConnection();
            //---B1: Thêm  LoaiSP tới dữ liệu
            if(!isUpdate)
                db.LoaiSPs.Add(x);
            else
            {
                LoaiSP y = db.LoaiSPs.Find(x.maLoai);
                y.tenLoai = x.tenLoai;
                y.ghiChu = x.ghiChu;
                isUpdate = false;
            }           
            //----Lưu vào DBatse
            db.SaveChanges();
            // Cập nhật list trên view
            if (ModelState.IsValid)
                ModelState.Clear();
            List<LoaiSP> l = db.LoaiSPs.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            ViewData["DanhSachLoai"] = l;
            return View(x);
        }
        [HttpPost]
        public ActionResult Delete(string maLoai)
        {
            ShopOnlineConnection db = new ShopOnlineConnection();
            int ma = int.Parse(maLoai);
            //---Tìm đối tượng loại sản phẩm trong dữ liệu
            LoaiSP x = db.LoaiSPs.Find(ma);
            //--- Xóa Loại sản phẩm trong danh sách 
            isUpdate = true;
            db.LoaiSPs.Remove(x);
            //---Cập nhật list trên View DBase
            db.SaveChanges();
            //-- Đọc danh sách dữ liệu từ DBase
            ViewData["DanhSachLoai"] = db.LoaiSPs.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View("Index");

        }
        public ActionResult Update(string maLoaiChinhSua)
        {
            ShopOnlineConnection db = new ShopOnlineConnection();
            int ma = int.Parse(maLoaiChinhSua);
            //---Tìm đối tượng loại sản phẩm trong dữ liệu
            LoaiSP x = db.LoaiSPs.Find(ma);
            isUpdate = true;
            //---
            ViewData["DanhSachLoai"] = db.LoaiSPs.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View("Index", x);
        }
    }
}