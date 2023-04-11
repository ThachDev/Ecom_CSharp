using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store_Web_Online.Models;
using Electronic_Store_Web_Online.Areas.PrivatePage.Models;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Security.Cryptography;

namespace Electronic_Store_Web_Online.Areas.PrivatePage.Controllers
{
    //---Thêm  [ValidateInput(false)] sẽ fix được lỗi A potentially dangerous Request.Form value was detected from the client
    [ValidateInput(false)]

    public class IntroductPostController : Controller
    {
        [HttpGet]
        
        public ActionResult Index()
        {
            BaiViet x = new BaiViet();
            //---Thiết lập một số thông tin mặc định cần gán cho đối tượng bài viết [Khách quan]
            //--- Truyền dữ liệu ra View.
            x.ngayDang = DateTime.Now;
            x.soLanDoc = 0;
            x.taiKhoan = Alway.GetTenTaiKhoan();
            //---Đưa đường dẫn ra ngoài hiển thị trên Image 
            ViewBag.ddHinh = "/images/baiviettt.jpg";
            return View(x);
        }
        [HttpPost]
        //---Cập nhật dữ liệu từ người dùng về DataBase
        public ActionResult Index(BaiViet x, HttpPostedFileBase hinhDaiDien)
        {
            try
            {
                //--- Xử lý thông tin nhận từ View
                x.maBV = string.Format("{0:yyMMddhhmm}", DateTime.Now);
                x.daDuyet = false;
                x.ngayDang = DateTime.Now;
                x.taiKhoan = Alway.GetTenTaiKhoan();
                x.soLanDoc = 0;
                x.loaiTin = "QC";
                //----------------------------------------------------------
                if (hinhDaiDien != null)
                {
                    //--Lưu hình vào thư mục chứa bài viết 
                    string virPath = "/images/BaiViet/";
                    string PhyPath = Server.MapPath("" + virPath); //--Xác định vị  trí hình sau khi upLoad
                    string ext = Path.GetExtension(hinhDaiDien.FileName); //--- Phần mở trộng 
                    string tenF = "HDD" + x.maBV + ext;
                    hinhDaiDien.SaveAs(PhyPath + tenF);             //---Lưu thì phải dựa vào đường dẫn vật lý [drive][path][filename]
                                                                    //--Ghi nhận đường dẫn truy cập tới hình đã dựa vào Domain
                    x.hinhDD = virPath + tenF;                     //---Đường ảo theo domain
                                                                   //---Sẽ cập nhật hình vừa đăng cho giao diện    
                    ViewBag.ddHinh = x.hinhDD;
                }
                else
                    x.hinhDD = " ";
                //----------------------------------------------------------
                //--- Cập nhật đối tượng bài viết vừa đăng vào DataModels
                ShopOnlineConnection db = new ShopOnlineConnection();
                db.BaiViets.Add(x);
                //--- Lưu thông tin xuống DataBase
                db.SaveChanges();
                //----- Nếu thành công sẽ chuyển đến 
                return RedirectToAction("Index", "ArticleList", new { IsActive = 0 });
            }
            catch 
            {

            }
            return View (x);
        }
    }
}
