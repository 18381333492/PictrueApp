using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.App_Start;
using Sevices;
using EFModel.MyModels;
using System.IO;
using Common;
using System.Net;

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

        /// <summary>
        /// 发起支付请求
        /// </summary>
        /// <param name="money">单位(元)</param>
        public void PayRequest(string money)
        {
            //商户订单号
            string out_order_no =DateTime.Now.ToString("yyyyMMddhhmmssfff");
            //商品名称
            string subject = "图片APP";
            //金额
            string total_fee = money;
            //订单描述
            string body = "图片APP的订单";

            //商户号（6位数字）
            string user_seller = C_Config.ReadAppSetting("user_seller");

            //合作身份者PID，签约账号，由16位纯数字组成的字符串，请登录商户后台查看
            string partner = C_Config.ReadAppSetting("partner");

            // MD5密钥，安全检验码，由数字和字母组成的32位字符串，请登录商户后台查看
            string key = C_Config.ReadAppSetting("key");

            // 服务器异步通知页面路径  需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
            string notify_url = C_Config.ReadAppSetting("notify_url");
            // 页面跳转同步通知页面路径 需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
            string return_url = C_Config.ReadAppSetting("return_url");
            string UrlParm = GetUrlParm(partner, user_seller, out_order_no, subject, total_fee, body, notify_url, return_url, key);

            //发起请求的url
            string sUrl = "http://www.passpay.net/PayOrder/payorder;";
            sUrl = sUrl + "?" + UrlParm;

            HttpWebRequest request = HttpWebRequest.Create(sUrl) as HttpWebRequest;
            request.Method = "GET";
            request.Timeout = 3000 * 1000;
            request.GetResponse();

        }


     

        /// <summary>
        /// 获取URL参数
        /// </summary>
        /// <param name="partner">云通付PID(必填)</param>
        /// <param name="user_seller">云通付商户号(必填)</param>
        /// <param name="out_order_no">商户网站订单号（唯一）(必填)</param>
        /// <param name="subject">订单名称(必填)</param>
        /// <param name="total_fee">订单价格（整元）(必填)</param>
        /// <param name="body">订单描述(选填)</param>
        /// <param name="notify_url">异步回调地址(必填)</param>
        /// <param name="return_url">同步回调地址(必填)</param>
        /// <param name="key">密钥(必填)</param>
        /// <returns></returns>
        private string GetUrlParm(string partner, string user_seller, string out_order_no, string subject, string total_fee, string body, string notify_url, string return_url, string key)
        {

            string prestr = string.Empty;
            if (!string.IsNullOrEmpty(body))
            {
                prestr += "body=" + body + "&";
            }
            prestr += "notify_url=" + notify_url + "&";
            prestr += "out_order_no=" + out_order_no + "&";
            prestr += "partner=" + partner + "&";
            prestr += "return_url=" + return_url + "&";
            prestr += "subject=" + subject + "&";
            prestr += "total_fee=" + total_fee + "&";
            prestr += "user_seller=" + user_seller;
            string sign =  (prestr + key);
            return prestr + "&sign=" + sign;
        }


        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private String md5(String s)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            string ret = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0');
            }

            return ret.PadLeft(32, '0');
        }



    }
}
