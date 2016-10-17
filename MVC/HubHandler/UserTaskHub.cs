using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Model;

namespace MVC.HubHandler
{
    public class UserTaskHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        public void Login(string userId)
        {
            UserInfoModel model = UserStaticInfoModel.UserInfo.Where(d => d.UserId == userId).FirstOrDefault();
            model.connectionId = Context.ConnectionId;
            Clients.User(userId).helloMyFriend(model.UserId, model.UserName, Context.ConnectionId + "登录成功");
            Clients.User(userId).helloMyFriend(model.UserId, model.UserName, Context.ConnectionId + "谈话开始");
        }

        /// <summary>
        /// 发送给userId用户
        /// </summary>
        /// <param name="userId">发送给此用户:接受者</param>
        /// <param name="userName">发送者用户Id</param>
        /// <param name="str">发送消息</param>
        public void SendMessage(string userId, string userName,string str)
        {
            UserInfoModel model = UserStaticInfoModel.UserInfo.Where(d => d.UserId == userId).FirstOrDefault();
            UserInfoModel model1 = UserStaticInfoModel.UserInfo.Where(d => d.connectionId==Context.ConnectionId).FirstOrDefault();
            Clients.User(model.UserId).helloMyFriend(model1.UserId, userName, str);
        }
    }
}