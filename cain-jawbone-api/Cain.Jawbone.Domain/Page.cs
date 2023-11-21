namespace Cain.Jawbone.Domain
{
    public class Page : ModelBase
    {
        public int PageNumber { get; set; }
        public string? Title { get; set; }
        public IList<string>? Characters { get; set; }
        public IList<string>? Tags { get; set; }
    }
}
