using Electronic_Store_Web_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Electronic_Store_Web_Online.Controllers
{
    
    public class PayController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {            
            //--- Tạo một đói tượng khách hàng
            KhachHang x = new KhachHang();
            //--- Lấy thông tin đã mua hàng từ session & truyền cho View thông qua ViewData
            //---Lấy giỏ hàng từ session
            CartShop shop = Session["gioHang"] as CartShop;
            //---Truyền ra ngoài View
            ViewData["Cart"] = shop;
            return View(x);

        }
        [HttpPost]
        public ActionResult SaveToDataBase(KhachHang x)
        {
            //---Sử dụng trasaction để lưu đồng thời dữ liệu trên 3 table khác nhau
            //--- Tạo ra đối tượng giám sát toàn bộ ngữ cảnh của ShopOnlineConnection
            using (var context = new ShopOnlineConnection())
            {
                //---Bắt đầu một ngữ cảnh transaction
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                { //---Nếu thành công đặt trong try
                    try
                    {
                        //---1. Bảng Khách Hàng
                        //---B1: Tạo ra một đối tượng khách hàng mới( không cần tạo thêm đối tượng vì ở trên đã tạo sẵn r)
                        //---B2: Cập nhật những thông tin của khách hàng
                        x.maKH = x.soDT;
                        //---B3: Thêm thông tin khách hàng vào DataModels
                        context.KhachHangs.Add(x);
                        //---B4: Lưu thông tin khách hàng vào DataBase
                        context.SaveChanges();
                        //---2. Bảng Đơn hàng
                        //---B1: Tạo ra một đối tượng đơn hàng mới
                        DonHang d = new DonHang();
                        //---B2: Cập nhật những thông tin của đơn hàng
                        d.soDH = String.Format("{0:yyMMddhhmm}", DateTime.Now);
                        d.maKH = x.maKH;
                        d.ngayGH = DateTime.Now; d.ngayGH = DateTime.Now.AddDays(2);
                        d.taiKhoan = "admin"; d.diaChiGH = x.diaChi;
                        //---B3: Thêm thông tin khách hàng vào DataModels
                        context.DonHangs.Add(d);
                        //---B4: Lưu thông tin khách hàng vào DataBase
                        context.SaveChanges();
                        //---3. Bảng Chi Tiết Đơn hàng
                        //---B1: Tạo ra một đối tượng chi tiết đơn hàng mới
                        CartShop shop = Session["gioHang"] as CartShop;
                        //---B2: Cập nhật những thông tin của  chi tiết đơn hàng
                        foreach (CtDonHang i in shop.SPDaChon.Values)
                        {
                            context.CtDonHangs.Add(i);
                            i.soDH = d.soDH;
                        }    
                            
                        //---B3: Lưu thông tin chi tiết đơn hàng vào DataBase
                        context.SaveChanges();
                        //---4.Kết thúc và cập nhật tất cả sản phẩm                        
                        transaction.Commit();
                        //---Chuyển đến trang thông báo đã đặt hàng thành công[Chuyển về HomePage] 
                        return RedirectToAction("Index", "PaySucessfull");
                    }
                    //---Nếu bị lỗi đặt trong Catch
                    catch (Exception ex)
                    {
                        //---Trả lại tất cả thông tin vì lưu không đủ sản phẩm
                        transaction.Rollback();
                        string s = ex.Message;
                    }
                }
            }

            //--- Nếu bị lỗi sẽ chuyển về Pay
            return RedirectToAction("Index", "Pay");
        }
    }
}
