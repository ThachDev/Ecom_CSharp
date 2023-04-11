using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Electronic_Store_Web_Online.Models;
namespace Electronic_Store_Web_Online.Areas.PrivatePage.Models
{
    public class Alway
    {
        /// <summary>
        ///Phương thức cho phép đọc thông tin của tài khoản đã nhập từ trong session 
        /// </summary>
        /// <returns></returns>
        public static TaiKhoan GetTaiKhoanHienHanh()
        {

            TaiKhoan kq = new TaiKhoan();
            //--- Chỉ ra đối tượng current để lấy session từ bên ngoài.
            kq = HttpContext.Current.Session["ttDangNhap"] as TaiKhoan;
            return kq;
        }
        /// <summary>
        /// Lấy tên của tài khoản đã đăng nhập trong hệ thống
        /// </summary>
        /// <returns></returns>
        public static string GetTenTaiKhoan()
        {
            return GetTaiKhoanHienHanh().taiKhoan1;
        }
    }
}