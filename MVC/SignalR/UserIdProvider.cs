using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.SignalR
{
    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            if (request.GetHttpContext().Request.Cookies["userId"] != null)
            {
                return request.GetHttpContext().Request.Cookies["userId"].Value;
            }
            return "";
        }
    }
}
