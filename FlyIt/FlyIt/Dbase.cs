using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FlyIt
{
    public sealed class Dbase
    {
        public static async Task<T> GetAPiData<T>(string url, string urlparams = "")
        {
            var data = default(T);

            HttpResponseMessage response = GetAsync(url, urlparams).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                try
                {
                    data = JsonConvert.DeserializeObject<T>(jsonString);
                }
                catch
                {
                }
                //data = response.Content.ReadAsAsync<T>().Result;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var ex = new Exception("Unauthorized to access data.  Please restart the program and log in.");
                ex.Data["ErrorNumber"] = HttpStatusCode.Unauthorized.ToString();
                throw ex;
            }

            return data;
        }

        public static T SetAPiData<TP, T>(string url, TP urlparams)
        {
            var data = default(T);

            HttpResponseMessage response = PostAsync<TP>(url, urlparams).Result;

            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsAsync<T>().Result;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var ex = new Exception("Unauthorized to access data.  Please restart the program and log in.");
                ex.Data["ErrorNumber"] = HttpStatusCode.Unauthorized.ToString();
                throw ex;
            }

            return data;
        }

        public static async Task<HttpResponseMessage> GetAsync(string url, string urlparams = "")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppSettings._AccessToken);

                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    if (!string.IsNullOrEmpty(urlparams))
                    {
                        urlparams = "&" + urlparams;
                    }
                    string path = string.Format(@"?apikey={0}{1}", "6d1bf15a-9ee0-4f95-beb7-8ceda7e9c718", urlparams);
                    // HTTP GET
                    response = await client.GetAsync(path).ConfigureAwait(continueOnCapturedContext:false);
                }
                catch (Exception ex)
                {

                    throw;
                }

                return response;
            }
        }

        public static async Task<HttpResponseMessage> PostAsync<P>(string url, P urlparams)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppSettings._AccessToken);

                var response = new HttpResponseMessage();
                try
                {
                    response = await client.PostAsJsonAsync<P>(url, urlparams).ConfigureAwait(continueOnCapturedContext: false);
                }
                catch (Exception ex)
                {

                    throw;
                }

                return response;
            }
        }
    }
}
