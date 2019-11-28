// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace YardConsulting.DpdOdyssee.JSON.CollectionRequests
{
    /// <summary>
    /// 4.2.2 Cancel a Collection Request / Acquired data
    /// </summary>
    public class ResponseCancelCollectionRequest
    {
        /// <summary>
        /// Pickup order ID
        /// </summary>
        [Description("Pickup order ID"), Api(MaxLen = 8)]
        public string callId { get; set; }

        /// <summary>
        /// Information message text
        /// </summary>
        [Description("Information message text"), Api(MaxLen = 256)]
        public string responseMessage { get; set; }

        /// <summary>
        /// Information message ID
        /// </summary>
        [Description("Information message ID"), Api(MaxLen = 5)]
        public string coreInfoMessage { get; set; }
    }
}
