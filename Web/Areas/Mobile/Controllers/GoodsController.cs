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
    public class GoodsController : MobileBaseController<GoodsService>
    {
        //
        // GET: /Mobile/Goods/

        /// <summary>
        /// 商品列表展示页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有的商品列表
        /// </summary>
        public ActionResult List(PageInfo Info)
        {
            return Content(_server.GetList(Info, null, null));
        }


        /// <summary>
        /// 商品详情页面
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid ID)
        {
            ViewBag.GoodsList = _server.GetTopThree(ID);
            return View(_server.Get(ID));
        }


        /// <summary>
        /// 文件流
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns></returns>
        [NoLogin]
        public FileResult FileStream()
        {
            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory+ "H531C8625_0118092413.ipa", FileMode.Open,FileAccess.Read);

            return File(fs, "application/octet-stream");
        }


        /// <summary>
        /// 根据商品ID获取评论数据
        /// </summary>
        /// <param name="sGoodsId"></param>
        /// <returns></returns>
        public ActionResult GetCommentListBysGoodsId(PageInfo info, Guid sGoodsId)
        {
            var domin = Resolve<CommentService>();
            return  Content(domin.GetList(info, sGoodsId));
        }


        /// <summary>
        /// 分类列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CateGoryList()
        {
            return View(_server.GetAllCategory());
        }
    }
}
