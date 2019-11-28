// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace YardConsulting.DpdOdyssee.JSON.CollectionRequests
{
    /// <summary>
    /// 4.2.1
    /// </summary>
    public class RequestCancelCollection
    {
        const string path = "collection-request/cancel";

        [Description("Collection Request ID"), Api(MaxLen = 10)]
        public string callId { get; set; }

        [Description("Collection Request parcel number"), Api(MaxLen = 14)]
        public string parcelNumber { get; set; }

        public async Task<ResponseCancelCollection> CancelAsync(DpdOdysseeCredentials credentials)
        {
            var req = new DpdRequest(credentials, path, this);
            return await req.GetResponseAsync<ResponseCancelCollection>();
        }
    }
}
