using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWebApi
{
    public class AccountServiceWebApi02
    {
        private WebApiAccess _webApiAccess;

        public AccountServiceWebApi02(WebApiAccess webApiAccess)
        {
            _webApiAccess = webApiAccess;
        }
        public async Task<UserInfo> GetUserInfo(string username)

        {
            try
            {
                WebApiGet<UserInfo> webApiGet = new WebApiGet<UserInfo>(_webApiAccess);
                UserInfo user = await webApiGet.GetAsync($"api/account/GetUserInfo/{username}");
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}
