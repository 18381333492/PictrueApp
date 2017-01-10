using EFModel;
using EFModel.MyModels;
using Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.App_Start;

namespace Web.Areas.Admin.Controllers
{
    public class GoodsCategoryController : AdminBaseController<GoodsCategoryService>
    {

        // GET: /Admin/GoodsCategory/

        #region 商品分类相关视图
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 编辑商品分类
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult Edit(Guid ID)
        {  
            return View(_server.Get(ID));
        }

        #endregion


        /// <summary>
        /// 获取商品分类列表
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public ActionResult List(PageInfo Info)
        {
            return Content(_server.GetList(Info, null));
        }

        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Insert(GoodsCategory item)
        {
            int res = _server.Add(item);
            if (res > 0)
            {
                result.success = true;
            }
            else
            {
                result.info = "添加失败!";
            }
        }

        /// <summary>
        /// 编辑商品分类
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Update(GoodsCategory item)
        {
            int res = _server.Edit(item);
            if (res > 0)
                result.success = true;
            else
                result.info = "编辑失败!";
        }

        /// <summary>
        /// 逻辑删除商品分类
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public void Cancel(string Ids)
        {
            int res = _server.Cancel(Ids);
            if (res > 0)
                result.success = true;
            else
                result.info = "删除失败!";
        }


        /// <summary>
        /// 获取所有的分类的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllGoodsCategory(int bIsAdd=1)
        {
            return Content(_server.GetAllGoodsCategory(bIsAdd));
        }
    }
}
