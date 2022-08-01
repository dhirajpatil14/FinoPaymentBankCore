using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class SequencesMobile
    {
        [JsonPropertyName("version")]
        public long? Version { get; set; }

        [JsonPropertyName("objSeqList")]
        public IEnumerable<SequenceMapping> SequenceMappings { get; set; } = null;

    }
}
