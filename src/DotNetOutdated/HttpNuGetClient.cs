using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DotNetOutdated
{
    public class HttpNuGetClient : NuGetClient
    {
        private readonly string _source;
        public HttpNuGetClient(string source)
        {
            _source = source.TrimEnd('/');
        }
        protected override async Task<JObject> GetResource(string name)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{_source}/registration3/{name}");

                if (response.IsSuccessStatusCode)
                {
                    return JObject.Parse(await response.Content.ReadAsStringAsync());
                }
                return null;
            }
        }
    }
}