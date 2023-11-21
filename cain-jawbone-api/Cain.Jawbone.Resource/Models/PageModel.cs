using Cain.Jawbone.Domain;
using Newtonsoft.Json;

namespace Cain.Jawbone.Resource.Models
{
    public class PageModel
    {
        public PageModel() { }

        public PageModel(Page page) 
        {
            id = page.Id;
            PageNumber = page.PageNumber;
            Title = page.Title;
            Characters = page.Characters;
            Tags = page.Tags;
            Order = page.Order;
        }

        [JsonProperty("id")]
        public Guid id { get; set; }
        public int PageNumber { get; set; }
        public string? Title { get; set; }
        public List<string>? Characters { get; set; }
        public List<string>? Tags { get; set; }
        public int Order { get; set; }
    }
}
