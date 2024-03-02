using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithAspNet5UdemayErudio.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);

    }
}
