using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Electronic_Store_Web_Online.Controllers
{
    public class PaySucessfullController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();  
        }
    }
}