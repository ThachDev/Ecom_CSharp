using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electronic_Store_Web_Online.Models
{
    public class CartShop
    {
        public string MaKH { get; set; }
        public string TaiKhoan { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public string DiaChi { get; set; }
        //----
        //---- Cấu trúc dữ liệu : (List, HashMap, Array List) : Nếu dùng phương thức này thì sẽ bị trùng sản phẩm. Nhưng nếu đặt điều kiện thì vẫn có thể dùng được. Nói nom na là "hơi dài dòng" 
        //--- Thay vì dùng phương thức trên thì ta dùng SortedList<key> - <value> thì nó sẽ gọn gàn hơn.        
        //---Key trong SortedList<key> - <value> này là maSp , dùng để phân loại sản phẩm để không bị trùng khi thêm 2 lần mà thay vào đó thì nó sẽ tăng số lượng lên cho mình.
        public SortedList<string, CtDonHang> SPDaChon { get; set; }
        //--Khởi tạo Constructor
        public CartShop ()
        {
            this.MaKH = "";
            this.TaiKhoan = "";
            this.NgayDat = DateTime.Now;
            this.NgayGiao = DateTime.Now.AddDays(2);
            this.DiaChi = "";
            this.SPDaChon = new SortedList<string, CtDonHang> ();
        }
        /// <summary>
        /// Phương thức trả về  True nếu không có sản phẩm nào đã chọn mua trong hệ thống
        /// </summary>
        /// <returns></returns>
        public bool ISEmpty()
        {
           return (SPDaChon.Keys.Count == 0);
        }
        /// <summary>
        /// Phương thức thêm một sản phẩm đã chọn mua vào giỏ hàng
        /// Có 2 tình huống : 
        /// 1 là nếu sản phẩm đã có thì chỉ cập nhật số lượng.
        /// 2 là tạo ra 1 chi tiết đơn hàng mới cho sản phẩm rồi bỏ vào giỏ hàng
        /// </summary>
        /// <param name="maSP"></param>
        //---Thêm phần tử mới vào SortedList<string, CtDonHang>
        public void addItem(string maSP)
        {
            if(SPDaChon.Keys.Contains(maSP))
            {
                //---Trỏ đến sản phẩm cần thay đổi số lượng từ trong giỏ hàng  "IndexOfKey: là vị trí của masp"
                CtDonHang x = SPDaChon.Values[SPDaChon.IndexOfKey(maSP)];
                //---Tăng số lượng lên 1
                x.soLuong++ ;
            }    
            else
            {
                //--Tạo 1 đối tượng chi tiết đơn hàng mới
                CtDonHang i = new CtDonHang();
                //-- Cập nhật thông tin hiện hành từ hệ thống cho đối tượng 
                i.maSP = maSP;
                i.soLuong = 1;
                //--- Lấy giá bán, lấy giảm giá từ Tables SanPham
                SanPham k = Common.GetProductById(maSP);
                i.giaBan = k.giaBan;
                i.giamGia = k.giamGia;
                //--- Bỏ vào danh sách các sản phẩm đã chọn mua trong giỏ hàng của mình
                SPDaChon.Add(maSP, i);
            }    
        }       
        //---Xóa đơn hàng đã thêm vào giỏ hàng
        public void deleteItem(string maSp)
        {
            if(SPDaChon.Keys.Contains(maSp))
            {
                SPDaChon.Remove(maSp);
            }    
        }
        //---Giảm đơn hàng || xóa sản phẩm đã thêm vào giỏ hàng
        public void Decrease(string maSp)
        {
            if(SPDaChon.Keys.Contains(maSp))
                //---Nếu tồn tại sản phẩm thì lấy ra
            {
                //--- Trỏ đến sản phẩm cần thay đổi số lượng mua trong giỏ hàng.
                CtDonHang x = SPDaChon.Values[SPDaChon.IndexOfKey(maSp)];
                if (x.soLuong >1 )                
                    x.soLuong--;                                    
                else
                {
                    //---Sản phẩm <= 1 thì xóa luôn sản phẩm
                    deleteItem(maSp);
                } 
                    
            }    
        }
        //--- Tính giá trị thành tiền của sản phẩm
        public long moneyOfOneItem(CtDonHang x)
        {
            //--ép kiểu thành kiểu long
            return (long)(x.giaBan * x.soLuong - (x.giaBan * x.soLuong * x.giamGia/100)); 
        }
        //--Tổng tiền cuối cùng của hóa đơn
        public long totalOfCartShop()
        {
            long total = 0;
            //--TÍnh tổng trị giá
            foreach (CtDonHang i in SPDaChon.Values)
                total += moneyOfOneItem(i);
            return total;
        }

    }
}