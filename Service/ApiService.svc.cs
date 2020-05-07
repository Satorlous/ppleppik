using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ApiService : IApiService
    {
        public async Task<string> GetResponseAsync()
        {
            var address = "http://www.mocky.io/v2/5c7db5e13100005a00375fda";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(address);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
