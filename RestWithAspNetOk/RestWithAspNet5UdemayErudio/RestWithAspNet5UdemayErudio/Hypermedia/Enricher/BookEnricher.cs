using Microsoft.AspNetCore.Mvc;
using RestWithAspNet5UdemayErudio.Data.Vo;
using RestWithAspNet5UdemayErudio.Hypermedia.Constants;
using System.Text;

namespace RestWithAspNet5UdemayErudio.Hypermedia.Enricher
{
    public class BookEnricher : ContentResponseEnricher<BookVo>
    {
        

        protected override Task EnrichModel(BookVo content, IUrlHelper urlHelper)
        {
            var path = "api/book";
            string link = GetLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.Self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.Self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.Self,
                Type = ResponseTypeFormat.Defaultput
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.Self,
                Type = "int"
            });
            return Task.CompletedTask;


        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (this)
            {
                var url = new { controller = path, id };
                var teste = new StringBuilder(urlHelper.Link("DefaultApi", url))
                    .Replace("%2F", "/").ToString();
                return teste;

            };
        }
    }
}
