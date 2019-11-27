using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace YardConsulting.DpdOdyssee.JSON.PickupOrders
{
    /// <summary>
    /// 3.1.1
    /// </summary>
    public class RequestProgramPickupOrder
    {
        const string path = "call-pools/save";

        [Description("Payer customer ID"), Api(MaxLen = 8)]
        public long payerId { get; set; }

        [Description("Payer customer address ID"), Api(MaxLen = 8)]
        public long payerAddressId { get; set; }

        [Description("Sender customer ID"), Api(MaxLen = 8)]
        public long senderId { get; set; }

        [Description("Sender customer address ID"), Api(MaxLen = 8)]
        public long senderAddressId { get; set; }

        [Description("Sender zip code"), Api(MaxLen = 10)]
        public string senderZipCode { get; set; }

        [Description("Sender country code – ISO-2"), Api(MaxLen = 2)]
        public string senderCountryCode { get; set; }

        [Description("Request channel – always « E »"), Api(MaxLen = 1)]
        public string reqChannel { get; set; }

        [Description("Request type – always « 01 »"), Api(MaxLen = 2)]
        public string callType { get; set; }

        [Description("Contact name at pickup place"), Api(MaxLen = 35)]
        public string contactPerson { get; set; }

        [Description("Pickup date – format YYYYMMDD"), Api(MaxLen = 8)]
        public string desiredPickUpDate { get; set; }

        [Description("Pickup start time - format HHMMSS"), Api(MaxLen = 6)]
        public string desiredPickUpTime1 { get; set; }

        [Description("Pickup end time – format HHMMSS"), Api(MaxLen = 6)]
        public string desiredPickUpTime2 { get; set; }

        public async Task<ResponseProgramPickupOrder> ProgramAsync(DpdOdysseeCredentials credentials)
        {
            var req = new DpdRequest(credentials, path, this);
            return await req.GetResponseAsync<ResponseProgramPickupOrder>();
        }
    }
}
