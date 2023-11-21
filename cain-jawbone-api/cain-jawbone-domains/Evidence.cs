namespace cain_jawbone_domains
{
    public class Evidence : ModelBase
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IList<int>? RelatedPage { get; set; }
        public IList<string>? Characters { get; set; }

    }
}
