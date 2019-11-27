using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YardConsulting.DpdOdyssee
{
    public static class Diagnostics
    {
        public static string ToFormattedJson(this object o, JsonSerializerSettings settings = null) 
            => JsonConvert.SerializeObject(o, Formatting.Indented, settings ?? new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });            

    }
}
