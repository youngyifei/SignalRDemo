using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfoModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string connectionId { get; set; }
    }

    public static class UserStaticInfoModel
    {
        public static List<UserInfoModel> UserInfo = new List<UserInfoModel>(){
           new UserInfoModel(){UserId="1",UserName="张三",Password="1",connectionId=""},
           new UserInfoModel(){UserId="2",UserName="李四",Password="2",connectionId=""},
           new UserInfoModel(){UserId="3",UserName="王五",Password="3",connectionId=""},
           new UserInfoModel(){UserId="4",UserName="赵六",Password="4",connectionId=""}
        };

    }
}
