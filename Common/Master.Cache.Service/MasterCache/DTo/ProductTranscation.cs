using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class ProductTranscation
    {
        [JsonPropertyName("pTy")]
        public string Pty { get; set; }
        [JsonPropertyName("objTList")]
        public IEnumerable<Transcation> Transcations { get; set; }
    }
}
