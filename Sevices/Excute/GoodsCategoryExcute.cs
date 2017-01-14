using EFModel;
using Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Sevices
{
    public partial class GoodsCategoryService : ServiceBase
    {

        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        [Log("商品分类", Operate.添加)]
        public int Add(GoodsCategory item)
        {
            item.ID = Guid.NewGuid();
            item.dInsertTime = DateTime.Now;
            item.bIsDeleted = false;
            if (string.IsNullOrEmpty(item.sPath))
                item.sPath = string.Empty;
            excute.Add<GoodsCategory>(item);
            return excute.SaveChange(this,"Add");      
        }

        /// <summary>
        /// 编辑商品分类
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Log("商品分类", Operate.编辑)]
        public int Edit(GoodsCategory item)
        {
            if (string.IsNullOrEmpty(item.sPath))
                item.sPath = string.Empty;
            excute.Edit<GoodsCategory>(item);
             return excute.SaveChange(this, "Edit");
        }

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="Ids"></param>
        [Log("商品分类", Operate.删除)]
        public int Cancel(string Ids)
        {
            return excute.Cancel<GoodsCategory>(Ids,this, "Cancel");
        }
    }
}
