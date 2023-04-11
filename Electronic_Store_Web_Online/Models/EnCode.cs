using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;
namespace Electronic_Store_Web_Online.Models
{
    //--- Dùng để mã hóa mật khẩu 
    public class EnCode
    {
        /// <summary>
        /// Hàm phục vụ cho mục đích mã hóa một chuỗi văn bản gốc dựa vào việc bấm dữ liệu bởi SHA256
        /// </summary>
        /// <param name="PlaninText">Chuỗi văn bản muốn mã hóa</param>
        /// <returns></returns>
        public static string encryptSHA256(string PlaninText)
        {
            string result = " ";
            //--- Tạo 1 đối tượng SHA256
            using(SHA256 sha256 = SHA256.Create())
            {
                //--- Chuyển đổi mã hóa thành kiểu Byte
                byte[] sourceData = Encoding.UTF8.GetBytes(PlaninText);
                //---Tính toán và trả về kiểu Byte
                byte[] data = sha256.ComputeHash(sourceData);
                result = BitConverter.ToString(data);
            }    
            return result;
        }

    }
}