using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electronic_Store_Web_Online.Models;
namespace Electronic_Store_Web_Online.Areas.PrivatePage.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: PrivatePage/DashBoard
        public ActionResult Index()
        {          
            return View();
        }
    }
}