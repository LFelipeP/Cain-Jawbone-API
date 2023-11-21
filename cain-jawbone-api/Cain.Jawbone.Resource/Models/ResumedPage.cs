using Newtonsoft.Json;

namespace Cain.Jawbone.Resource.Models
{
    public class ResumedPage
    {
        [JsonProperty("id")]
        public Guid id { get; set; }
        public int PageNumber { get; set; }
        public string? Title { get; set; }
        public int Order { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
