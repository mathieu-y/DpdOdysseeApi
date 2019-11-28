// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YardConsulting.DpdOdyssee.JSON.Shipment
{
    /// <summary>
    /// 2.3.1 & 2.4.1 & 2.5.1
    /// </summary>
    public class RequestGetLabels
    {
        const string downloadPath = "manifest/label4web/print/close/download";
        const string reprintPath = "manifest/label4web/reprint/download";
        const string rodPath = "shipment/print/return-on-demand";

        /// <summary>
        /// First label position – always 1
        /// </summary>
        [Description("First label position – always 1")]        
        public long labelStartPosition { get; set; } = 1;

        /// <summary>
        /// Label format : A4 or A6
        /// </summary>
        [Description("Label format : A4 or A6")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LabelFormat labelFormat { get; set; }

        [Description("Print references as CODE128 barcodes")]
        public bool? referenceAsBarcode { get; set; }

        [Description("Label language - always 'fr'")]
        public string language { get; set; } = "fr";

        [Description("Temporary shipment IDs (tempShpId)")] // 2.3.1 only
        public List<long> shpIdList { get; set; }

        [Description("Parcel label number to reprint"), Api(MaxLen = 14)] // 2.4.1 & 2.5.1 only
        public string parcelNumber { get; set; } // Documentation is saying it's a string. Why not long ?

        [Description("Print flow : PDF, ZPL, or EPL"), Api(MaxLen = 3)]
        [JsonConverter(typeof(StringEnumConverter))]
        public FileType fileType { get; set; }

        [Description("ZPL / EPL definition in dpi: 203, 300, or 600"), Api(MaxLen = 3)]
        public LabelDPI dpi { get; set; }


        /// <summary>
        /// <b>2.3</b>
        /// This method will confirm shipment creation and start multiple label generation, merged inside a single file.
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public async Task<ResponseGetLabels> DownloadAsync(DpdOdysseeCredentials credentials)
        {
            var req = new DpdOdysseeRequest(credentials, downloadPath, this);
            return await req.GetResponseAsync<ResponseGetLabels>();
        }

        /// <summary>
        /// <b>2.4</b>
        /// This method allows you to reprint a previously generated label
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public async Task<Label> ReprintAsync(DpdOdysseeCredentials credentials)
        {
            var req = new DpdOdysseeRequest(credentials, reprintPath, this);
            return await req.GetResponseAsync<Label>();
        }

        /// <summary>
        /// <b>2.5</b>
        /// Print a “Return on demand” label
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public async Task<ResponseReturnOnDemandLabel> PrintReturnOnDemandAsync(DpdOdysseeCredentials credentials)
        {
            var req = new DpdOdysseeRequest(credentials, rodPath, this);
            return await req.GetResponseAsync<ResponseReturnOnDemandLabel>();
        }
    }
}
