﻿using System;
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
        public ActionResult Detail()
        {
            return View();
        }


        /// <summary>
        /// 文件流
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns></returns>
        public FileResult FileStream()
        {
            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory+ "Images\\2017-01\\20170111170029783.gif",FileMode.Open,FileAccess.Read);

            return File(fs, "image/gif");
        }
    }
}
