using Newtonsoft.Json;

namespace Cain.Jawbone.Domain
{
    public abstract class ModelBase
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreationUser { get; set; }
        public string? UpdateUser { get; set; }
    }
}
