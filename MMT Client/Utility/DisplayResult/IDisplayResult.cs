using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Client.Utility
{
    public interface IDisplayResult
    {
        Task<HttpResponseMessage> GetResponse(HttpClient client);
        void Display(HttpResponseMessage response);
    }
}
