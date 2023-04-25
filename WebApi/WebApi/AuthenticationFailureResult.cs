using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace WebApi
{
  public class AuthenticationFailureResult : IHttpActionResult
  {
    public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
    {
      ReasonPhrase = reasonPhrase;
      Request = request;
    }

    public string ReasonPhrase { get; private set; }

    public HttpRequestMessage Request { get; private set; }

    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
      return Task.FromResult(Execute());
    }

    private HttpResponseMessage Execute()
    {
      HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
      response.RequestMessage = Request;
      response.ReasonPhrase = ReasonPhrase;
      return response;
    }
  }
}
