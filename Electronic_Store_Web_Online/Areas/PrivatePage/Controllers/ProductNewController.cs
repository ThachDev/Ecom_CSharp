using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store_Web_Online.Areas.PrivatePage.Models;
using Electronic_Store_Web_Online.Models;
using System.IO;
namespace Electronic_Store_Web_Online.Areas.PrivatePage.Controllers
{
    [ValidateInput(false)]
    public class ProductNewController : Controller
    {

        // GET: PrivatePage/ProductNew
        [HttpGet]
        public ActionResult Index()
        {
            //--- Thiết lập một số thông tin mặc định.
            //--- Truyền dữ liệu ra cho View
            SanPham x = new SanPham();
            x.ngayDang = DateTime.Now;
            x.taiKhoan = Alway.GetTenTaiKhoan();
            //---Đưa đường dẫn ra ngoài hiển thị trên Image ở trang Private
            ViewBag.ddHinh = "/images/24.jpg";
            return View(x); ;
        }
        //--- Lưu trữ dữ liệu vào Database(SQL) khi người dùng đăng sản phẩm 
        [HttpPost]

        public ActionResult Index(SanPham x, HttpPostedFileBase HinhDaiDienSP) 
        {
            try
            {
                //---B0:
                //---B1: Xử lý thông tin nhận về từ View.
                x.maSP = string.Format("{0:yyMMddhhmm}", DateTime.Now);
                x.daDuyet = false;
                //--- Xác thực 1 lần nữa để không thể sửa được từ bên ngoài
                x.ngayDang = DateTime.Now;
                x.taiKhoan = Alway.GetTenTaiKhoan();
                //----------------------------------------------
                if (HinhDaiDienSP != null)
                {
                    //--- Lưu hình vào thư mục chứa sản phẩm.
                    string duongDan = "/images/SanPham/";
                    string luuSP = Server.MapPath("" + duongDan);   //--Xác định vị  trí hình sau khi upLoad
                    string pmr = Path.GetExtension(HinhDaiDienSP.FileName); //--- Phần đuôi
                    string tenSP = "HDD" + x.maSP + pmr;
                    HinhDaiDienSP.SaveAs(luuSP + tenSP);             //---Lưu thì phải dựa vào đường dẫn vật lý [drive][path][filename]
                                                                     //--Ghi nhận đường dẫn truy cập tới hình đã dựa vào Domain
                    x.hinhDD = duongDan + tenSP;                     //---Đường ảo theo domain
                                                                     //------ Đăng hình của sản phẩm lên View
                    ViewBag.ddHinh = x.hinhDD;
                }
                else
                {
                    x.hinhDD = " ";
                }

                //---B2: Cập nhật đối tượng sản phẩm vào Data Model
                ShopOnlineConnection db = new ShopOnlineConnection();
                db.SanPhams.Add(x);
                //---B3: Lưu thông tin vào DataBase
                db.SaveChanges();
                //----- Nếu thành công sẽ chuyển đến 
                return RedirectToAction("Index","ProductType", new {IsActiveSP = 0});

            }
            catch
            {

            }
            return View(x);
        } 
    }
}