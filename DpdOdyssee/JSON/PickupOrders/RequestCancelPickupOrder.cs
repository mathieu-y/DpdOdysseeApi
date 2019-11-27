using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace YardConsulting.DpdOdyssee.JSON.PickupOrders
{
    public class RequestCancelPickupOrder
    {
        const string path = "deletion-shipments/pickup-orders-with-related-shipments";

        [Description("Pickup order ID"), Api(MaxLen = 10)]
        public List<long> callId { get; set; }

        public async Task<ResponseProgramPickupOrder> CancelAsync(DpdOdysseeCredentials credentials)
        {
            var req = new DpdRequest(credentials, path, this);
            return await req.GetResponseAsync<ResponseProgramPickupOrder>();
        }
    }
}
