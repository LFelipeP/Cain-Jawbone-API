namespace Cain.Jawbone.Domain
{
    public class Page : ModelBase
    {
        public int PageNumber { get; set; }
        public string? Title { get; set; }
        public List<string>? Characters { get; set; }
        public List<string>? Tags { get; set; }
        public int Order { get; set; }
    }
}
