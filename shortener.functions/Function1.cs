using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace shortener.functions
{
    public static class Function1
    {
        [FunctionName("shortener")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");


            //ShortenerRedirector redirector = new ShortenerRedirector(null);


            //var redirectTourl = redirector.Get("");
            //var response = req.CreateResponse(HttpStatusCode.RedirectKeepVerb);
            //response.Headers.Location = new System.Uri(redirectTourl);

            //return response;
            return null;

        }
    }
}
