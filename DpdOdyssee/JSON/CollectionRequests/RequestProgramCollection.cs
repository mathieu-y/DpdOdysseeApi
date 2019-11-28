// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace YardConsulting.DpdOdyssee.JSON.CollectionRequests
{
    /// <summary>
    /// 4.1.1
    /// </summary>
    public class RequestProgramCollection
    {
        const string path = "collection-request/save/ext";

        #region IDENTIFICATION

        [Description("Always 'E'"), Api(MaxLen = 1)]
        public string reqChannel { get; set; }

        [Description("Your reference"), Api(MaxLen = 8)]
        public long custref { get; set; }

        [Description("Parcel weight - in kg"), Api(MaxLen = 8)]
        public long weight { get; set; }

        [Description("Number of parcels to pick up"), Api(MaxLen = 8)]
        public long parcelCount { get; set; }

        [Description("Desired pickup date (YYYYMMDD)"), Api(MaxLen = 8)]
        public string desiredPickupDate { get; set; }

        #endregion

        #region PICKUP ADDRESS

        [Description("Company name"), Api(MaxLen = 35)]
        public string cname { get; set; }

        [Description("Name line 2"), Api(MaxLen = 35)]
        public string cname2 { get; set; }

        [Description("Name line 3"), Api(MaxLen = 35)]
        public string cname3 { get; set; }

        [Description("House number"), Api(MaxLen = 8)]
        public string chouseNo { get; set; }

        [Description("Street"), Api(MaxLen = 35)]
        public string cstreet { get; set; }

        [Description("Second line of address"), Api(MaxLen = 35)]
        public string cstreetInfo { get; set; }

        [Description("Zip code"), Api(MaxLen = 10)]
        public string cpostal { get; set; }

        [Description("City"), Api(MaxLen = 35)]
        public string ccity { get; set; }

        [Description("Country code"), Api(MaxLen = 2)]
        public string ccountry { get; set; }

        [Description("Telephone number"), Api(MaxLen = 20)]
        public string cphone { get; set; }

        [Description("Mobile number"), Api(MaxLen = 20)]
        public string cphone2 { get; set; }

        [Description("Email address"), Api(MaxLen = 20)]
        public string cemail { get; set; }

        [Description("Door code 1"), Api(MaxLen = 8)]
        public string ccode1 { get; set; }

        [Description("Door code 2"), Api(MaxLen = 8)]
        public string ccode2 { get; set; }

        [Description("Intercom"), Api(MaxLen = 8)]
        public string cintercom { get; set; }

        [Description("Pickup instructions"), Api(MaxLen = 35)]
        public string cadditionalAddressText { get; set; }

        #endregion

        #region DELIVERY ADDRESS

        [Description("Company name"), Api(MaxLen = 35)]
        public string rname { get; set; }

        [Description("Name line 2"), Api(MaxLen = 35)]
        public string rname2 { get; set; }

        [Description("House number"), Api(MaxLen = 8)]
        public string rhouseNo { get; set; }

        [Description("Street"), Api(MaxLen = 35)]
        public string rstreet { get; set; }

        [Description("Second line of address"), Api(MaxLen = 35)]
        public string rstreetInfo { get; set; }

        [Description("Zip code"), Api(MaxLen = 10)]
        public string rpostal { get; set; }

        [Description("City"), Api(MaxLen = 35)]
        public string rcity { get; set; }

        [Description("Country code"), Api(MaxLen = 2)]
        public string rcountry { get; set; }

        [Description("Telephone number"), Api(MaxLen = 20)]
        public string rphone { get; set; }

        [Description("Mobile number"), Api(MaxLen = 20)]
        public string rphone2 { get; set; }

        [Description("Email address"), Api(MaxLen = 20)]
        public string remail { get; set; }

        [Description("Door code 1"), Api(MaxLen = 8)]
        public string rcode1 { get; set; }

        [Description("Door code 2"), Api(MaxLen = 8)]
        public string rcode2 { get; set; }

        [Description("Intercom"), Api(MaxLen = 8)]
        public string rintercom { get; set; }

        [Description("Delivery instructions"), Api(MaxLen = 35)]
        public string radditionalAddressText { get; set; }
        #endregion

        public async Task<ResponseProgramCollection> ProgramAsync(DpdOdysseeCredentials credentials)
        {
            var req = new DpdRequest(credentials, path, this);
            return await req.GetResponseAsync<ResponseProgramCollection>();
        }
    }
}
