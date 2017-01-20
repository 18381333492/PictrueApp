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
    public partial class LikePictureService : ServiceBase
    {

        /// <summary>
        /// 添加猜你喜欢
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        [Log("猜你喜欢", Operate.添加)]
        public int Add(LikePicture item)
        {
            item.ID = Guid.NewGuid();
            if (string.IsNullOrEmpty(item.sPicture))
                item.sPicture = string.Empty;
            excute.Add<LikePicture>(item);
            return excute.SaveChange(this,"Add");      
        }

        /// <summary>
        /// 编辑猜你喜欢
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Log("猜你喜欢", Operate.编辑)]
        public int Edit(LikePicture item)
        {
            if (string.IsNullOrEmpty(item.sPicture))
                item.sPicture = string.Empty;
            excute.Edit<LikePicture>(item);
             return excute.SaveChange(this, "Edit");
        }
    }
}
