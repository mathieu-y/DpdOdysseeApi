// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YardConsulting.DpdOdyssee.JSON.PickupOrders
{
    /// <summary>
    /// 3.1.2 Acquired data
    /// </summary>
    public class ResponseProgramPickupOrder
    {
        /// <summary>
        /// Pickup order ID
        /// </summary>
        [Description("Pickup order ID"), Api(MaxLen = 8)]
        public long? callId { get; set; }

        /// <summary>
        /// Information message text
        /// </summary>
        [Description("Information message text"), Api(MaxLen = 256)]
        public string responseMessage { get; set; }

        /// <summary>
        /// Information message ID
        /// </summary>
        [Description("Information message ID"), Api(MaxLen = 5)]
        public long? coreInfoMessage { get; set; }
    }
}
