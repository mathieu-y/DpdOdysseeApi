using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YardConsulting.DpdOdyssee.JSON.PickupOrders
{
    /// <summary>
    /// 3.1.2
    /// </summary>
    public class ResponseProgramPickupOrder
    {
        [Description("Pickup order ID"), Api(MaxLen = 8)]
        public string callId { get; set; }

        [Description("Information message text"), Api(MaxLen = 256)]
        public string responseMessage { get; set; }

        [Description("Information message ID"), Api(MaxLen = 5)]
        public string coreInfoMessage { get; set; }
    }
}
