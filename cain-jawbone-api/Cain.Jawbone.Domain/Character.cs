namespace Cain.Jawbone.Domain
{
    public class Character : ModelBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<int>? RelatedPages { get; set; }
        public List<string>? RelatedTheories { get; set; }
        public List<string>? RelatedEvidences { get; set; }
    }
}
