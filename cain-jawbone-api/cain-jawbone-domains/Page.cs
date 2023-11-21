namespace cain_jawbone_domains
{
    public class Page : ModelBase
    {
        public int PageNumber { get; set; }
        public string? Title { get; set; }
        public IList<string>? Characters { get; set; }
        public IList<string>? Tags { get; set; }
    }
}
