using Niusys.WebAPI.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niusys.WebAPI.Models
{
    public class SessionObject
    {
        public string SessionKey { get; set; }
        public User LogonUser { get; set; }
    }

    public class User : IUser<int>
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }
        public bool IsActive { get; internal set; }
    }

    public class UserDevice
    {
        public int UserId { get; internal set; }
        public DateTime ActiveTime { get; internal set; }
        public DateTime ExpiredTime { get; internal set; }
        public DateTime CreateTime { get; internal set; }
        public int DeviceType { get; internal set; }
        public string SessionKey { get; internal set; }
    }
}