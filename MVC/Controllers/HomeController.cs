using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SignalR()
        {
            Session["ss"] = "ss";
            string userId = Request.Cookies["userId"] == null ? "" : Request.Cookies["userId"].Value;
            string userName = "";
            if (userId != null && userId != "")
            {
                userName = UserStaticInfoModel.UserInfo.Where(d => d.UserId == userId).FirstOrDefault().UserName;
            }
            ViewBag.userId = userId;
            ViewBag.userName = userName;
            return View();
        }

        public string Login(string userId,string password)
        {
             UserInfoModel model = UserStaticInfoModel.UserInfo.Where(d => d.UserId == userId && d.Password == password).FirstOrDefault();
             if (model != null)
             {
                 Response.Cookies["userId"].Value = userId;
                 return JsonConvert.SerializeObject(model);
             }
             else
             {
                 return "";
             }
        }
        public string GetUserInfo()
        {
            return JsonConvert.SerializeObject(UserStaticInfoModel.UserInfo);
        }
    }
}