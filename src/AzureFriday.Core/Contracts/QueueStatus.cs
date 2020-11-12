using Newtonsoft.Json;

namespace AzureFriday.Core.Contracts
{
    public class QueueStatus
    {
        [JsonProperty]
        public long MessageCount { get; set; }
    }
}
