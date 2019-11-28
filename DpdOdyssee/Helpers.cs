// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace YardConsulting.DpdOdyssee
{
    public static class Helpers
    {
        public static async Task<MemoryStream> GetResponseCopyAsync(this WebResponse webResponse)
        {
            MemoryStream ms = new MemoryStream();
            using (var stream = webResponse.GetResponseStream())
                await stream.CopyToAsync(ms);

            return ms;
        }

        public static T GetDeserializedResponse<T>(this MemoryStream stream, JsonSerializer serializer)
        {
            stream.Position = 0;
            var streamReader = new StreamReader(stream);
            var jsonReader = new JsonTextReader(streamReader);
            return serializer.Deserialize<T>(jsonReader);
        }

        public static MemoryStream SerializeToMemory(this JsonSerializer serializer, object obj)
        {
            MemoryStream stream = new MemoryStream();
            var jsonWriter = new JsonTextWriter(new StreamWriter(stream));
            serializer.Serialize(jsonWriter, obj);
            jsonWriter.Flush();
            stream.Position = 0;
            return stream;
        }

        
    }
}
