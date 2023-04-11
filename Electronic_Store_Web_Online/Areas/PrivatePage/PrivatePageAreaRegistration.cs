using System.Web.Mvc;

namespace Electronic_Store_Web_Online.Areas.PrivatePage
{
    public class PrivatePageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PrivatePage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PrivatePage_default",
                "PrivatePage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}