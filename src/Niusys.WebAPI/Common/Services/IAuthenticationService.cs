using Niusys.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niusys.WebAPI.Common.Services
{
    public interface IAuthenticationService
    {
        UserDevice GetUserDevice(string sessionKey);
        User GetUser(int userId);
        void UpdateUserDevice(UserDevice userSession);
        User GetUserByLoginId(string loginId);
        UserDevice GetUserDevice(int userId, int deviceType);
        void AddUserDevice(UserDevice existsDevice);
    }
}
