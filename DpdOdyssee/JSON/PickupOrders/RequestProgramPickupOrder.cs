// Mathieu Yard, 2019 - mathieu.yard at gmail.com

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
    /// If there isn’t already a scheduled parcel pickup at your company, you can trigger a one-off pickup order.
    /// Please note that it is not possible to trigger a pickup order for the current day, and the pickup times are
    /// subject to approval upon DPD France operational services.
    /// </summary>
    public class RequestProgramPickupOrder
    {
        const string path = "call-pools/save";

        /// <summary>
        /// Payer customer ID
        /// </summary>
        [Description("Payer customer ID"), Api(MaxLen = 8)]
        public long? payerId { get; set; }

        /// <summary>
        /// Payer customer address ID
        /// </summary>
        [Description("Payer customer address ID"), Api(MaxLen = 8)]
        public long? payerAddressId { get; set; }

        /// <summary>
        /// Sender customer ID
        /// </summary>
        [Description("Sender customer ID"), Api(MaxLen = 8)]
        public long? senderId { get; set; }

        /// <summary>
        /// Sender customer address ID
        /// </summary>
        [Description("Sender customer address ID"), Api(MaxLen = 8)]
        public long? senderAddressId { get; set; }

        /// <summary>
        /// Sender zip code
        /// </summary>
        [Description("Sender zip code"), Api(MaxLen = 10)]
        public string senderZipCode { get; set; }

        /// <summary>
        /// Sender country code – ISO-2
        /// </summary>
        [Description("Sender country code – ISO-2"), Api(MaxLen = 2)]
        public string senderCountryCode { get; set; }

        /// <summary>
        /// Request channel – always « E »
        /// </summary>
        [Description("Request channel – always « E »"), Api(MaxLen = 1)]
        public string reqChannel { get; set; } = "E";

        /// <summary>
        /// Request type – always « 01 »
        /// </summary>
        [Description("Request type – always « 01 »"), Api(MaxLen = 2)]
        public string callType { get; set; } = "01";

        /// <summary>
        /// Contact name at pickup place
        /// </summary>
        [Description("Contact name at pickup place"), Api(MaxLen = 35)]
        public string contactPerson { get; set; }

        /// <summary>
        /// Pickup date – format YYYYMMDD
        /// </summary>
        [Description("Pickup date – format YYYYMMDD"), Api(MaxLen = 8)]
        public DateTime desiredPickUpDate { get; set; }

        /// <summary>
        /// Pickup start time - format HHMMSS
        /// </summary>
        [Description("Pickup start time - format HHMMSS"), Api(MaxLen = 6)]
        public string desiredPickUpTime1 { get; set; }

        /// <summary>
        /// Pickup end time – format HHMMSS
        /// </summary>
        [Description("Pickup end time – format HHMMSS"), Api(MaxLen = 6)]
        public string desiredPickUpTime2 { get; set; }

        void FillFrom(DpdOdysseeCredentials credentials)
        {
            payerId = credentials.payerId;
            payerAddressId = credentials.payerAddressId;
            senderId = credentials.senderId;
            senderAddressId = credentials.senderAddressId;
            senderZipCode = credentials.senderZipCode;
            senderCountryCode = credentials.senderCountryCode;
        }

        /// <summary>
        /// If there isn’t already a scheduled parcel pickup at your company, you can trigger a one-off pickup order.
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public async Task<ResponseProgramPickupOrder> ProgramAsync(DpdOdysseeCredentials credentials)
        {
            FillFrom(credentials);
            var req = new DpdRequest(credentials, path, this);
            return await req.GetResponseAsync<ResponseProgramPickupOrder>();
        }
    }
}
