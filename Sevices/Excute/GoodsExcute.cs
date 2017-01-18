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
    public partial class GoodsService : ServiceBase
    {

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        [Log("商品", Operate.添加)]
        public int Add(Goods item)
        {
            item.ID = Guid.NewGuid();
            item.dInsertTime = DateTime.Now;
            item.bIsDeleted = false;
            if (string.IsNullOrEmpty(item.sGifPicturePath))
                item.sGifPicturePath = string.Empty;
            if (string.IsNullOrEmpty(item.sGoodsDetail))
                item.sGoodsDetail = string.Empty;
            excute.Add<Goods>(item);
            return excute.SaveChange(this,"Add");      
        }

        /// <summary>
        /// 编辑商品
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Log("商品", Operate.编辑)]
        public int Edit(Goods item)
        {
            if (string.IsNullOrEmpty(item.sGifPicturePath))
                item.sGifPicturePath = string.Empty;
            if (string.IsNullOrEmpty(item.sGoodsDetail))
                item.sGoodsDetail = string.Empty;
            excute.Edit<Goods>(item);
             return excute.SaveChange(this, "Edit");
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="Ids"></param>
        [Log("商品", Operate.删除)]
        public int Cancel(string Ids)
        {
            return excute.Cancel<Goods>(Ids,this, "Cancel");
        }
    }
}
