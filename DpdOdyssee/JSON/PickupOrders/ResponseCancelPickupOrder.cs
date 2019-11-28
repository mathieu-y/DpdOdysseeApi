using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YardConsulting.DpdOdyssee.JSON.PickupOrders
{
    /// <summary>
    /// 3.2.2 Acquired data
    /// </summary>
    public class ResponseCancelPickupOrder
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
