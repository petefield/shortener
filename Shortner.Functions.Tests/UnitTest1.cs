using System;
using Xunit;
using Shortener.Data;
using System.Net.Http;
using Moq;
using System.Net;
using Shortener;

namespace Shortner.Functions.Tests
{
    public class RedirectionTest
    {
        Mock<IShortLinksRepo> repo;

        public RedirectionTest()
        {
            repo = new Mock<IShortLinksRepo>();
        }

        [Fact]
        public void GetRedirectShouldThrowExceptionIfNullRepo()
        {
            var r = new Redirection(null);

            Assert.Throws<ArgumentNullException>(() => {
                r.Execute(null, "");
            });


        }

        [Fact]
        public void GetRedirectShouldThrowExceptionIfNullShortURL()
        {

            var r = new Redirection(null);
            
            Assert.Throws<ArgumentNullException>(() => {
                r.Execute(new System.Net.Http.HttpRequestMessage(HttpMethod.Post,"") , null);
            });

        }

        [Fact]
        public void ShouldReturn404IfNotFound()
        {

            this.repo.Setup(x => x.Get(It.IsAny<string>())).Returns<String>(null);

            var r = new Redirection(this.repo.Object);

            var response = r.Execute(new HttpRequestMessage(HttpMethod.Post, "test"), null);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }

        [Fact]
        public void ShouldReturn307IfFound()
        {

            this.repo.Setup(x => x.Get(It.IsAny<string>())).Returns("www.google.com");

            var r = new Redirection(this.repo.Object);

            var response = r.Execute(new HttpRequestMessage(HttpMethod.Post, "test"), null);

            Assert.Equal(HttpStatusCode.RedirectKeepVerb, response.StatusCode);

        }

        [Fact]
        public void ShouldSetResponseLocationHeader()
        {
            var redirectTo = "https://www.google.com";

            this.repo.Setup(x => x.Get(It.IsAny<string>())).Returns(redirectTo);

            var r = new Redirection(this.repo.Object);

            var response = r.Execute(new HttpRequestMessage(HttpMethod.Post, "test"), null);

            Assert.Equal(redirectTo, response.Headers.Location.ToString());

        }

        [Fact]
        public void ShouldRaiseOnRedirectFound()
        {
            var redirectTo = "https://www.google.com";
            var shortLink = "shortLink";

            this.repo.Setup(x => x.Get(It.IsAny<string>())).Returns(redirectTo);

            var r = new Redirection(this.repo.Object);

            string eventArgs = null;

            r.RedirectionTriggered += (from, to) => eventArgs = to;

            r.Execute(new HttpRequestMessage(HttpMethod.Post, shortLink), null);

            Assert.Equal(shortLink, eventArgs);
        }

        
    }
}
