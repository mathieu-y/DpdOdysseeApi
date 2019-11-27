using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace YardConsulting.DpdOdyssee.JSON.CollectionRequests
{
    /// <summary>
    /// 4.1.2
    /// </summary>
    public class ResponseProgramCollection
    {
        [Description("Information message ID"), Api(MaxLen = 5)]
        public long coreInfoMessageId { get; set; }

        [Description("Unused"), Api(MaxLen = 8)]
        public long colReqId { get; set; }

        [Description("Collection Request ID"), Api(MaxLen = 8)]
        public long callId { get; set; }

        [Description("Unused"), Api(MaxLen = 5)]
        public long ordernr { get; set; }

        [Description("Unused"), Api(MaxLen = 16)]
        public string oid { get; set; }

        [Description("Creation time (hhmmss)"), Api(MaxLen = 6)]
        public string timeCreate { get; set; }

        [Description("Creation date (YYYYMMDD)"), Api(MaxLen = 8)]
        public string dateCreate { get; set; }

        [Description("API credentials used"), Api(MaxLen = 35)]
        public string userCreate { get; set; }

        [Description("DPD depot code of payer"), Api(MaxLen = 4)]
        public string odepot { get; set; }

        [Description("DPD depot code of consignee"), Api(MaxLen = 4)]
        public string rdepot { get; set; }

        [Description("DPD depot code of pickup place"), Api(MaxLen = 4)]
        public string cdepot { get; set; }

        [Description("Collection Request parcel number"), Api(MaxLen = 14)]
        public string parcelNo { get; set; }

        [Description("Collection Request ID in case parcelCount > 1"), Api(MaxLen = 8)]
        public long masterCallId { get; set; }
    }
}
