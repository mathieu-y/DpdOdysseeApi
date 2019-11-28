// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace YardConsulting.DpdOdyssee.JSON.CollectionRequests
{
    /// <summary>
    /// 4.2.2
    /// </summary>
    public class ResponseCancelCollection
    {
        [Description("Pickup order ID"), Api(MaxLen = 8)]
        public string callId { get; set; }

        [Description("Information message text"), Api(MaxLen = 256)]
        public string responseMessage { get; set; }

        [Description("Information message ID"), Api(MaxLen = 5)]
        public string coreInfoMessage { get; set; }
    }
}
