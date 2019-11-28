// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace YardConsulting.DpdOdyssee.JSON.CollectionRequests
{
    /// <summary>
    /// 4.1.2 Program a Collection Request / Acquired data
    /// </summary>
    public class ResponseProgramCollectionRequest
    {
        /// <summary>
        /// Information message ID
        /// </summary>
        [Description("Information message ID"), Api(MaxLen = 5)]
        public long? coreInfoMessageId { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        [Description("Unused"), Api(MaxLen = 8)]
        public long? colReqId { get; set; }

        /// <summary>
        /// Collection Request ID
        /// </summary>
        [Description("Collection Request ID"), Api(MaxLen = 8)]
        public long? callId { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        [Description("Unused"), Api(MaxLen = 5)]
        public long? ordernr { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        [Description("Unused"), Api(MaxLen = 16)]
        public string oid { get; set; }

        /// <summary>
        /// Creation time (hhmmss)
        /// </summary>
        [Description("Creation time (hhmmss)"), Api(MaxLen = 6)]
        public string timeCreate { get; set; }

        /// <summary>
        /// Creation date (YYYYMMDD)
        /// </summary>
        [Description("Creation date (YYYYMMDD)"), Api(MaxLen = 8)]
        public string dateCreate { get; set; }

        /// <summary>
        /// API credentials used
        /// </summary>
        [Description("API credentials used"), Api(MaxLen = 35)]
        public string userCreate { get; set; }

        /// <summary>
        /// DPD depot code of payer
        /// </summary>
        [Description("DPD depot code of payer"), Api(MaxLen = 4)]
        public string odepot { get; set; }

        /// <summary>
        /// DPD depot code of consignee
        /// </summary>
        [Description("DPD depot code of consignee"), Api(MaxLen = 4)]
        public string rdepot { get; set; }

        /// <summary>
        /// DPD depot code of pickup place
        /// </summary>
        [Description("DPD depot code of pickup place"), Api(MaxLen = 4)]
        public string cdepot { get; set; }

        /// <summary>
        /// Collection Request parcel number
        /// </summary>
        [Description("Collection Request parcel number"), Api(MaxLen = 14)]
        public string parcelNo { get; set; }

        /// <summary>
        /// Collection Request ID in case parcelCount > 1
        /// </summary>
        [Description("Collection Request ID in case parcelCount > 1"), Api(MaxLen = 8)]
        public long? masterCallId { get; set; }
    }
}
