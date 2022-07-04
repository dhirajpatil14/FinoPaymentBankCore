using System;

namespace Utility.Common
{
    public static class SessionExpireTime
    {
        public static string GetSessionExpireTime(int sessionTime)
        {
            return DateTime.Now.AddMinutes(sessionTime).ToString();
        }
    }
}
