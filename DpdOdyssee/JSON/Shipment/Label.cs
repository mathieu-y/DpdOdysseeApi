using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YardConsulting.DpdOdyssee.JSON.Shipment
{
    public class Label
    {
        [Description("document, base64 encoded")]
        [JsonConverter(typeof(Base64Converter))]
        public byte[] fileContent { get; set; }

        [Description("default file name"), Api(MaxLen = 256)]
        public string fileName { get; set; }

        [Description("Print flow : PDF, ZPL, or EPL"), Api(MaxLen = 3)]
        public string fileType { get; set; }
    }
}
