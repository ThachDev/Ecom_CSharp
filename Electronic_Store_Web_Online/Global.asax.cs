using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Electronic_Store_Web_Online.Models;
namespace Electronic_Store_Web_Online
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //--Tạo ra 1 đối tượng Application Object để chứa Common.
            Application["dc"] = new Common();
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["ttDangNhap"] = null;
            //--Phát cho ngta 1 giỏ hàng rỗng 
            Session["gioHang"] = new CartShop();
        }

    }
}
