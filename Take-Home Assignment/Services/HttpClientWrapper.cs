using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Take_Home_Assignment.Models.Exceptions;

namespace Take_Home_Assignment.Controllers
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public async Task<string> GetAsync(string request)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (IsTransientError(response))
                {
                    // TODO Implement retry policy.
                    // throw "TransientErrorException" here and catch in method responsible for making request
                }
                throw new BadGatewayException();
            }
            return await response.Content.ReadAsStringAsync();
        }

        private bool IsTransientError(HttpResponseMessage response)
        {
            // TODO
            // check if transient error
            // and maybe put in a "helper class" for re-useability
            return true;
        }
    }
}

