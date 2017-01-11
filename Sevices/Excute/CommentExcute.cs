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
    public partial class CommentService : ServiceBase
    {

        /// <summary>
        /// 添加评价
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        [Log("评价", Operate.添加)]
        public int Add(Comment item)
        {
            item.ID = Guid.NewGuid();
            item.dInserTime = DateTime.Now;
            item.bIsDeleted = false;
            if (string.IsNullOrEmpty(item.sCommentHeadPic))
                item.sCommentHeadPic = string.Empty;
            excute.Add<Comment>(item);
            return excute.SaveChange(this,"Add");      
        }

        /// <summary>
        /// 编辑评价
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Log("评价", Operate.编辑)]
        public int Edit(Comment item)
        {
            if (string.IsNullOrEmpty(item.sCommentHeadPic))
                item.sCommentHeadPic = string.Empty;
            excute.Edit<Comment>(item);
             return excute.SaveChange(this, "Edit");
        }

        /// <summary>
        /// 删除评价
        /// </summary>
        /// <param name="Ids"></param>
        [Log("评价", Operate.删除)]
        public int Cancel(string Ids)
        {
            return excute.Cancel<Comment>(Ids,this, "Cancel");
        }
    }
}
