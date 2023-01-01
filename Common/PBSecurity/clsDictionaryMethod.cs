using System;
using System.Collections.Generic;
using System.Text;

namespace PBSecurity
{
    class clsDictionaryMethod
    {
        private static IDictionary<String, dynamic> objProductDictionary = new Dictionary<String, dynamic>();
        private static readonly object _sync = new object();

        public static Boolean SecurityProductContainsKey(String key)
        {
            return objProductDictionary.ContainsKey(key);
        }
        public static dynamic SecurityProductGetValue(String key)
        {
            if (objProductDictionary.ContainsKey(key))
            {
                lock (_sync)
                {
                    return objProductDictionary[key];
                }
            }
            return null;
        }

        public static Boolean SecurityProductAdd(String key, dynamic value)
        {
            try 
            {
                if (!objProductDictionary.ContainsKey(key))
                {
                    lock (_sync)
                    {
                        objProductDictionary.Add(key, value);
                    }
                    return true;
                }
                return false;
            }
            finally
            {
                value = null;
            }
        }
    }
}
