using System.Net.Http;
using System.Threading.Tasks;

namespace Take_Home_Assignment.Controllers
{
    public interface IHttpClientWrapper
    {
        Task<string> GetAsync(string s);
    }
}

