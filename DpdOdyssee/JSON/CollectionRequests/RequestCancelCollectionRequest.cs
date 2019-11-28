// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace YardConsulting.DpdOdyssee.JSON.CollectionRequests
{
    /// <summary>
    /// 4.2.1 Cancel a Collection Request / Input parameters
    /// </summary> 
    public class RequestCancelCollectionRequest
    {
        const string path = "collection-request/cancel";

        /// <summary>
        /// Collection Request ID
        /// </summary>
        [Description("Collection Request ID"), Api(MaxLen = 10)]
        public long? callId { get; set; }

        /// <summary>
        /// Collection Request parcel number
        /// </summary>
        [Description("Collection Request parcel number"), Api(MaxLen = 14)]
        public long? parcelNumber { get; set; }

        /// <summary>
        /// Please note that it is not possible to cancel a Collection Request programmed on the current day.
        /// You can cancel a Collection Request by passing in the request the DPD France parcel number
        /// (parcelNumber parameter), as well as by passing the request ID if the Collection Request is
        /// programmed abroad(callId parameter).
        /// </summary>
        /// <param name="credentials">Credentials</param>
        /// <returns></returns>
        public async Task<ResponseCancelCollectionRequest> CancelAsync(DpdOdysseeCredentials credentials)
        {
            var req = new DpdOdysseeRequest(credentials, path, this);
            return await req.GetResponseAsync<ResponseCancelCollectionRequest>();
        }
    }
}
