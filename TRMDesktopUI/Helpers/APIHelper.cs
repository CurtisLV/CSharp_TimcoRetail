using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Helpers
{
    public class APIHelper
    {
        public HttpClient ApiClient { get; set; }

        private void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
        }
    }
}
