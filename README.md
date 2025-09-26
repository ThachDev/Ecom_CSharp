# Electronic_CSharp  
**E-commerce Platform** được xây dựng bằng **C# / .NET MVC**  
Một ứng dụng thương mại điện tử mẫu, hỗ trợ các tính năng cơ bản như quản lý sản phẩm, giỏ hàng, đơn hàng, người dùng, v.v.

---

## Mục lục

1. [Giới thiệu](#giới-thiệu)  
2. [Tính năng](#tính-năng)  
3. [Kiến trúc & Công nghệ](#kiến-trúc--công-nghệ)  
4. [Cài đặt & Chạy ứng dụng](#cài-đặt--chạy-ứng-dụng)  
5. [Cấu hình](#cấu-hình)  
6. [Hướng dẫn phát triển & Mở rộng](#hướng-dẫn-phát-triển--mở-rộng)  
7. [License](#license)  
8. [Liên hệ](#liên-hệ)

---

## Giới thiệu

Dự án **Ecom_CSharp** là một nền tảng thương mại điện tử mẫu viết bằng C# và ASP.NET. Mục đích chính:

- Là mẫu để học hoặc làm nền tảng để phát triển thêm.  
- Hiển thị cách cấu trúc dự án, quản lý dữ liệu, xử lý nghiệp vụ thương mại điện tử.  
- Cho phép người dùng thực hành thêm, tuỳ chỉnh và mở rộng cho các tính năng phức tạp hơn sau này.

---

## Tính năng

- Quản lý người dùng (Đăng ký, đăng nhập)  
- Quản lý sản phẩm (CRUD sản phẩm, danh mục, hình ảnh)  
- Giỏ hàng (thêm sản phẩm, cập nhật số lượng, xoá)  
- Đặt hàng / xử lý đơn hàng  
- Theo dõi trạng thái đơn hàng  
- Giao diện người dùng (Frontend) & Backoffice / Admin  
- Tìm kiếm, lọc sản phẩm  
- Tích hợp thanh toán (Stripe)    
---

## Kiến trúc & Công nghệ

### Công nghệ sử dụng

- **Ngôn ngữ**: C#  
- **Framework**: .NET (ASP.NET MVC)  
- **Cơ sở dữ liệu**: SQL Server 
- **Frontend**: MVC Views / JavaScript / CSS / Bootstrap  
- **Khác**: Logging, Dependency Injection, Authentication  

### Kiến trúc

- Phân tầng (Presentation, Business Logic, Data Access)   
- Dependency Injection  
- Logging & Exception Handling  
- Bảo mật: xác thực, chống SQL injection, validate input  

---

## Cài đặt & Chạy ứng dụng

### Yêu cầu môi trường

- .NET SDK
- IDE: Visual Studio / VS Code / Rider  
- SQL Server  

### Hướng dẫn

```bash
git clone https://github.com/ThachDev/Ecom_CSharp.git
cd Ecom_CSharp
```
1. Mở solution (.sln) trong Visual Studio hoặc VS Code

2. Cấu hình connection string (xem phần Cấu hình)

3. Chạy ứng dụng

### Cấu hình
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EcomDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "your-very-strong-secret-key",
    "Issuer": "YourSite",
    "Audience": "YourSiteUsers"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

### Hướng dẫn phát triển & Mở rộng

- Thêm tính năng: khuyến mãi, đánh giá sản phẩm, wishlist, so sánh sản phẩm

- Tối ưu hiệu năng: caching, pagination, lazy loading

- Viết unit test / integration test

- CI/CD (GitHub Actions, Azure DevOps)

- Bảo mật nâng cao theo OWASP

### License

MIT License 
© 2022 [ThachDev]

### Liên hệ
- GitHub: https://github.com/ThachDev
- Email: thachhuynh.dev@gmail.com
