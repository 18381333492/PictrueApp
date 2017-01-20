using EFModel;
using EFModel.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sevices
{
    public partial class LikePictureService : ServiceBase
    {

        /// <summary>
        /// 分页获取猜你喜欢数据列表
        /// </summary>
        /// <param name="Info">分页参数</param>
        /// <param name="Params">查询参数</param>
        /// <returns></returns>
        public string GetList(PageInfo Info, Dictionary<string, object> Params)
        {
            return query.QueryPage(@"SELECT * FROM [LikePicture]", Info, null);
        }


        /// <summary>
        /// 获取单个猜你喜欢
        /// </summary>
        /// <param name="ID">主键ID</param>
        /// <returns></returns>
        public LikePicture Get(Guid ID)
        {
            return query.db.LikePicture.Find(ID);
        }

        /// <summary>
        /// 获取随机的猜你喜欢三张图片
        /// </summary>
        /// <returns></returns>
        public List<LikePicture> GetRandmThree()
        {
            var data = query.db.LikePicture.ToList();
            if (data.Count <= 3)
            {
                return data;
            }
            else
            {
                var res = new List<LikePicture>();
                if (data.Count % 3 == 0)
                {//整出
                    Random rand = new Random();
                    var m = data.Count / 3;
                    var one = rand.Next(0, m);
                    var two = rand.Next(m + 1, 2 * m);
                    var three = rand.Next(2 * m + 1, 3 * m);
                    res.Add(data[one]);
                    res.Add(data[two]);
                    res.Add(data[three]);
                }
                else
                {//不能整出
                    Random rand = new Random();
                    var num = data.Count % 3;//余数
                    var m = (data.Count - num) / 3;
                    var one = rand.Next(0, m);
                    var two = rand.Next(m + 1, 2 * m);
                    var three = rand.Next(2 * m + 1, 3 * m + num);
                    res.Add(data[one]);
                    res.Add(data[two]);
                    res.Add(data[three]);
                }
                return res;
            }
        }
    }
}
