using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.App_Start;
using Sevices;
using EFModel.MyModels;
using System.IO;

namespace Web.Areas.Mobile.Controllers
{
    /// <summary>
    /// 支付页面
    /// </summary>
    public class PayController : MobileBaseController<GoodsService>
    {
        //
        // GET: /Mobile/Pay/

        /// <summary>
        /// 商品列表展示页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        
    }
}
