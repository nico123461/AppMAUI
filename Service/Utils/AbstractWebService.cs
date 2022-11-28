using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utils
{
    public abstract class AbstractWebService: IStopTaskWEB
    {
        private static string URL = "http://10.0.2.2:5218/api/redarbor";

        private CancellationTokenSource cancellationToken;

        /// <summary>
        /// Metodo para realizar peticiones GET
        /// </summary>
        /// <typeparam name="TOBject"></typeparam>
        /// <param name="UriEndPoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected Task<TOBject> ExecURI<TOBject>(string UriEndPoint)
        {
            cancellationToken = new CancellationTokenSource();
            return Task.Run(async () => 
            {
                try
                {
                    HttpClient client = new HttpClient();
                    //client.DefaultRequestHeaders.Add("Accept", "application/json");
                    if (!UriEndPoint.StartsWith("/"))
                    {
                        UriEndPoint = "/" + UriEndPoint;
                    }
                    string url_complete = URL + UriEndPoint;
                    HttpResponseMessage response = await client.GetAsync(url_complete, cancellationToken.Token);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return JSONUtil.DeserialiceObject<TOBject>(content);
                    }
                    return default(TOBject);
                }
                finally
                {
                    //StopTask();
                }
            });
        }

        public void StopTask()
        {
            cancellationToken?.Cancel();
        }
    }
}
