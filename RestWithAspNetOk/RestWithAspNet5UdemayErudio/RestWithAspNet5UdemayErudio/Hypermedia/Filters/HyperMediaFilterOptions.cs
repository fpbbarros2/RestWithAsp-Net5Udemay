using RestWithAspNet5UdemayErudio.Hypermedia.Abstract;

namespace RestWithAspNet5UdemayErudio.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
