using Shortener.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shortener
{
    public class Redirection
    {
        private readonly IShortLinksRepo repo;

        public event Action<string, string> RedirectionTriggered;

        public Redirection(IShortLinksRepo repo)
        {
            this.repo = repo;
        }

        public HttpResponseMessage Execute(HttpRequestMessage req,  string shortLink)
        {
            
            throw new NotImplementedException();
        }
    }
}
