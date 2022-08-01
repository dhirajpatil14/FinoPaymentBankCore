using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Cache.Service.MasterCache
{
    public class MasterCacheDictionary
    {
        private readonly Dictionary<string, IEnumerable<dynamic>> _cacheMaster;

        public MasterCacheDictionary()
        {
            _cacheMaster = new Dictionary<string, IEnumerable<dynamic>>();
        }

        public Task<dynamic> GetMasterCacheAsync(string KEY)
        {
            var data = CheckNullAsync(KEY);

            if (!data.Any())
                return Task.FromResult<dynamic>(null);
            else
                return Task.FromResult<dynamic>(data);
        }

        public Task<int> SetMasterCacheAsync(string KEY, dynamic data)
        {
            lock (_cacheMaster)
            {
                _cacheMaster[KEY] = data;
            }
            return Task.FromResult<int>(1);
        }

        protected virtual IEnumerable<dynamic> CheckNullAsync(string KEY)
        {
            lock (_cacheMaster)
            {
                if (_cacheMaster.TryGetValue(KEY, out var value))
                {
                    return value;
                }
            }
            return Enumerable.Empty<dynamic>();
        }

        public virtual void ClearAll()
        {
            lock (_cacheMaster)
            {
                _cacheMaster.Clear();
            }
        }

        public virtual void Clear(string KEY)
        {
            lock (_cacheMaster)
            {
                _cacheMaster.Remove(KEY);
            }
        }

    }
}
