// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YardConsulting.DpdOdyssee.JSON.Shipment
{
    /// <summary>
    /// Document that contains the transport labels
    /// </summary>
    public class Label
    {
        /// <summary>
        /// Document content (decoded by this library)
        /// </summary>
        [Description("document, base64 encoded")]
        [JsonConverter(typeof(Base64Converter))]
        public byte[] fileContent { get; set; }

        /// <summary>
        /// Default file name
        /// </summary>
        [Description("default file name"), Api(MaxLen = 256)]
        public string fileName { get; set; }

        /// <summary>
        /// Print flow : PDF, ZPL, or EPL
        /// </summary>
        [Description("Print flow : PDF, ZPL, or EPL"), Api(MaxLen = 3)]
        public string fileType { get; set; }
    }
}
