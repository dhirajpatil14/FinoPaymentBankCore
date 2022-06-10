namespace HotRod.Cache.Settings
{
    public class CacheSettings
    {
        public int ByCache { get; set; }
        public int TimeOut { get; set; }
        public int PostURLTime { get; set; }
        public int Session { get; set; }
        public string CacheServerName { get; set; }
        public int CacheServerPort { get; set; }
        public string CacheSessionContainerName { get; set; }
        public string CacheMasterContainerName { get; set; }
        public string CacheTransactionContainerName { get; set; }
        public int SessionExpiryTime { get; set; }
    }
}
