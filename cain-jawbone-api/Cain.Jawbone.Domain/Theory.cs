namespace Cain.Jawbone.Domain
{
    public class Theory : ModelBase
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string>? Notes { get; set; }
        public List<int>? RelatedPages { get; set; }
        public List<string>? RelatedCharacters { get; set; }
        public List<string>? RelatedEvidences { get; set; }
    }
}
