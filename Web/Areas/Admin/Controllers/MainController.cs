using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Admin/Main/

        public ActionResult Index()
        {
            return Redirect("http://www.chengjue123.com/index.html");
        }

    }
}
