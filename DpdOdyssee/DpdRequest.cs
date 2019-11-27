using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;

using Newtonsoft.Json;

namespace YardConsulting.DpdOdyssee
{
    public class DpdRequest
    {
        private static JsonSerializer serializerStrict = new JsonSerializer {
             MissingMemberHandling = MissingMemberHandling.Error
            ,DateFormatString = "yyyyMMdd"
            ,NullValueHandling = NullValueHandling.Ignore
#if DEBUG
            ,Formatting = Formatting.Indented
#endif
        };

        private static JsonSerializer serializer = new JsonSerializer {
             DateFormatString = "yyyyMMdd"
            ,NullValueHandling = NullValueHandling.Ignore
        };

        const string apiUri = "https://ws.dpd.fr/backend/api/integration/public/";

        object jsonRequest;

        HttpWebRequest webRequest;

        public DpdRequest(DpdOdysseeCredentials credentials, string path, object jsonRequest)
        {
            webRequest = (HttpWebRequest) WebRequest.Create(apiUri + path);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.Headers[HttpRequestHeader.Authorization] = credentials.ToString();

            this.jsonRequest = jsonRequest;
        }      

        public async Task<T> GetResponseAsync<T>()
        {
            var json = serializerStrict.SerializeToMemory(jsonRequest);
#if DEBUG
            Debug.WriteLine("*** REQUEST **********************");
            Debug.WriteLine(Encoding.UTF8.GetString(json.ToArray()));
            Debug.WriteLine("**********************************");
#endif
            await json.CopyToAsync(await webRequest.GetRequestStreamAsync());

            using (var webResponse = (HttpWebResponse)await webRequest.GetResponseAsync())
            {
                var stream = await webResponse.GetResponseCopyAsync();

#if DEBUG
                object response = stream.GetDeserializedResponse<object>(serializer);
                Debug.WriteLine("*** RESPONSE *********************");
                Debug.WriteLine(response.ToFormattedJson());
                Debug.WriteLine("**********************************");
#endif

                try { return stream.GetDeserializedResponse<T>(serializerStrict); }
                catch (JsonSerializationException jex)
                {
                    var error = stream.GetDeserializedResponse<JSON.Error>(serializer);
                    throw new DpdOdysseeException(error);
                }            
            }
        }
    }
}
