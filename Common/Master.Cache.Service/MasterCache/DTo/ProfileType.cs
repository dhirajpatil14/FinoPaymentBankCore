using System;
using System.Collections.Generic;
using System.Text;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class ProfileType
    {
        public string UserTypeID { get; set; }
        public string UserTypeName { get; set; }

        public string ChannelID { get; set; }

        public IEnumerable<ProfileTransaction> ProfileTransaction { get; set; }
    }
}
