// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace YardConsulting.DpdOdyssee.JSON.PickupOrders
{
    /// <summary>
    /// 3.2 Cancel a pickup order
    /// Please note that it is not possible to cancel a pickup order programmed on the current day
    /// </summary>
    public class RequestCancelPickupOrder
    {
        const string path = "deletion-shipments/pickup-orders-with-related-shipments";

        /// <summary>
        /// Pickup order ID
        /// </summary>
        [Description("Pickup order ID"), Api(MaxLen = 10)]
        //public List<long> callId { get; set; }
        public long callId { get; set; } // Documentation is wrong, it's not a list.

        /// <summary>
        /// Please note that it is not possible to cancel a pickup order programmed on the current day
        /// </summary>
        /// <param name="credentials">Credentials</param>
        /// <returns></returns>
        public async Task<ResponseProgramPickupOrder> CancelAsync(DpdOdysseeCredentials credentials)
        {
            var req = new DpdRequest(credentials, path, this);
            return await req.GetResponseAsync<ResponseProgramPickupOrder>();
        }
    }
}
