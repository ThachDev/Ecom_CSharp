using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Dùng DbContext thì phải Using thư viện
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace Electronic_Store_Web_Online.Models
{
    /// <summary>
    /// Tạo ra 1 class Common để lấy dữ liệu từ Models ra.
    /// 
    /// </summary>
    public class Common
    {
        //---Khai báo 1 đối tượng đại diện cho Database
        static DbContext cn = new DbContext("name = ShopOnlineConnection");
        ///Dùng kiểu List để lấy ra chuỗi dữ liệu.(Kiểu 1)
        public static List<SanPham> getProducts()
        {
            List<SanPham> products = new List<SanPham>();
            //Khai báo 1 đối tượng đại diện cho database
            DbContext dl = new DbContext("name=ShopOnlineConnection");
            //Lấy dữ liệu từ Model
            products = dl.Set<SanPham>().ToList<SanPham>();
            return products;
        }

        //public static List<SanPham> getProducts()
        //{
        //    return new ShopOnlineConnection().SanPhams.ToList();
        //}

        
        //---Dùng kiểu List để lấy ra chuỗi dữ liệu(Kiểu 2)
        //return new DbContext("Tên biến").Set<LoaiSP>().ToList<LoaiSP>();

        //---Dùng kiểu List để lấy ra chuỗi dữ liệu(Kiểu 1)
        public static List<LoaiSP> getCateogories()
        {
            List<LoaiSP> cateogories = new List<LoaiSP>();
            //Khai báo 1 đối tượng đại diện cho Database
            DbContext dl = new DbContext("name=ShopOnlineConnection");
            // Lấy dữ liệu từ Model
            cateogories = dl.Set<LoaiSP>().ToList<LoaiSP>();
            return cateogories;
            
        }

        //--Khởi tạo danh sách Products
        private ShopOnlineConnection db;
        public Common()
        {
            this.db = new ShopOnlineConnection();
        }
        //--Khai báo 1 thuộc tính NhomHang.
        public IEnumerable<LoaiSP> NhomHang
        {
            get
            {
                return this.db.LoaiSPs;
            }
        }
        //--Khai báo thuộc tính Brands.
        public List<string> ThuongHieu
        {
            get
            {
                List<string> result = new List<string>();
                foreach (SanPham i in this.db.SanPhams)
                    if (!result.Contains(i.nhaSanXuat.Trim()))
                        result.Add(i.nhaSanXuat.Trim());
                return result;
            }
        }
        //-- Lấy ra danh sách sản phẩm.
        public IEnumerable<SanPham> SanPhamMoi(int n )
        {
            return db.SanPhams.OrderByDescending(i => i.ngayDang).Take(n);
        }



        //Lấy ra n bài viết mới nhất từ Db
        public static List<BaiViet> getArticles(int n)
        {
            List<BaiViet> l = new List<BaiViet>();
            ShopOnlineConnection db = new ShopOnlineConnection();
            l = db.BaiViets.Where(m => m.daDuyet == true).OrderByDescending(bv => bv.ngayDang).Take(n).ToList<BaiViet>();
            return l;
        }
        //Lấy ra n ds khách hàng mới nhất từ Db
        public static List<KhachHang> getCustomer(int n)
        {
            ShopOnlineConnection db = new ShopOnlineConnection();
            List<KhachHang> l = new List<KhachHang>();
            l = db.KhachHangs.Take(n).ToList<KhachHang>();
            return l;
        }
        //Lấy ra n ds CTDonHang mới nhất từ Db
        public static List<CtDonHang> getCTDonHang(int n)
        {
            List<CtDonHang> l = new List<CtDonHang>();
            ShopOnlineConnection db = new ShopOnlineConnection();
            l = db.CtDonHangs.Take(n).ToList<CtDonHang>();
            return l;
         //Lấy ra n ds DonHang mới nhất từ Db
        }
        public static List<DonHang> getDonHang(int n)
        {
            List<DonHang> l = new List<DonHang>();
            ShopOnlineConnection db = new ShopOnlineConnection();
            l = db.DonHangs.Take(n).ToList<DonHang>();
            return l;

        }
        //New Product
        public static List<SanPham> getNewSanPham(int n)
        {
            List<SanPham> l = new List<SanPham>();
            ShopOnlineConnection db = new ShopOnlineConnection();
            l = db.SanPhams.Where(m => m.daDuyet == true).OrderByDescending(bv => bv.ngayDang).Take(n).ToList<SanPham>();
            return l;
        }
        //Lấy ra n sản phẩm mới nhất từ Db
        public static List<SanPham> getProductSP(int maLoai)
        {
            List<SanPham> l = new List<SanPham>();
            ShopOnlineConnection db = new ShopOnlineConnection();
            //Lấy dữ liệu từ PrivateLogin
            l = db.Set<SanPham>().Where(x => x.maLoai == maLoai && x.daDuyet == true).ToList<SanPham>();
            return l;
        }
        public static List<SanPham> getProductsByLoaiSP(int maLoai)
        {
            //Lấy những danh sách thuộc từng maLoai riêng biệt 
            List<SanPham> products = new List<SanPham>();
            //Khai báo 1 đối tượng đại diện cho database
            DbContext dl = new DbContext("name=ShopOnlineConnection");
            //Lấy dữ liệu từ Model
            products = dl.Set<SanPham>().Where(x => x.maLoai == maLoai).ToList<SanPham>();
            return products;
        }
        /// <summary>
        /// Phương thức cho phép lấy thông tin của 
        /// </summary>
        /// <param name="maSP"> Mã sản phẩm </param>
        /// <returns>Đối tượng sản phẩm lấy được từ Data</returns>
        public static SanPham  GetProductById(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP);
        }
        /// <summary>
        /// Lấy tên của sản phẩm dựa vào mã sản phẩm 
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        public static string getNameOfProductById(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).tenSP;
        }
        /// <summary>
        /// Lấy đường dẫn HinhDD dựa vào mã sản phẩm
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        public static string getImagesOfProductById(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).hinhDD;
        }

    }
}