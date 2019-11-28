// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace YardConsulting.DpdOdyssee.JSON.CollectionRequests
{
    /// <summary>
    /// 4.1.1 Program a Collection Request / Input parameters
    /// A Collection Request represents a request for picking goods from a third party, to return at your
    /// warehouses or to be delivered to another third party.
    /// This service is subject to availability according to the country of removal and delivery.
    /// Please note that it is not possible to program a Collection Request for the current day
    /// </summary>
    public class RequestProgramCollectionRequest
    {
        const string path = "collection-request/save/ext";

        #region IDENTIFICATION

        /// <summary>
        /// Always 'E'
        /// </summary>
        [Description("Always 'E'"), Api(MaxLen = 1)]
        public string reqChannel { get; set; } = "E";

        /// <summary>
        /// Your reference
        /// </summary>
        [Description("Your reference"), Api(MaxLen = 8)]
        public string custref { get; set; }

        /// <summary>
        /// Parcel weight - in kg
        /// </summary>
        [Description("Parcel weight - in kg"), Api(MaxLen = 8)]
        public long? weight { get; set; } // Why long ? shoud it be rounded ? truncated ?

        /// <summary>
        /// Number of parcels to pick up
        /// </summary>
        [Description("Number of parcels to pick up"), Api(MaxLen = 8)]
        public long? parcelCount { get; set; }

        /// <summary>
        /// Desired pickup date (YYYYMMDD)
        /// </summary>
        [Description("Desired pickup date (YYYYMMDD)"), Api(MaxLen = 8)]
        public DateTime? desiredPickupDate { get; set; }

        #endregion

        #region PICKUP ADDRESS
        /// <summary>
        /// Company name
        /// </summary>
        [Description("Company name"), Api(MaxLen = 35)]
        public string cname { get; set; }

        /// <summary>
        /// Name line 2
        /// </summary>
        [Description("Name line 2"), Api(MaxLen = 35)]
        public string cname2 { get; set; } // TODO: DPD: should be optional (doc), but is mandatory

        /// <summary>
        /// Name line 3
        /// </summary>
        [Description("Name line 3"), Api(MaxLen = 35)]
        public string cname3 { get; set; }

        /// <summary>
        /// House number
        /// </summary>
        [Description("House number"), Api(MaxLen = 8)]
        public string chouseNo { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        [Description("Street"), Api(MaxLen = 35)]
        public string cstreet { get; set; }

        /// <summary>
        /// Second line of address
        /// </summary>
        [Description("Second line of address"), Api(MaxLen = 35)]
        public string cstreetInfo { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        [Description("Zip code"), Api(MaxLen = 10)]
        public string cpostal { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Description("City"), Api(MaxLen = 35)]
        public string ccity { get; set; }

        /// <summary>
        /// Country code
        /// </summary>
        [Description("Country code"), Api(MaxLen = 2)]
        public string ccountry { get; set; }

        /// <summary>
        /// Telephone number
        /// </summary>
        [Description("Telephone number"), Api(MaxLen = 20)]
        public string cphone { get; set; }

        /// <summary>
        /// Telephone number
        /// </summary>
        [Description("Mobile number"), Api(MaxLen = 20)]
        public string cphone2 { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Description("Email address"), Api(MaxLen = 20)]
        public string cemail { get; set; }

        /// <summary>
        /// Door code 1
        /// </summary>
        [Description("Door code 1"), Api(MaxLen = 8)]
        public string ccode1 { get; set; }

        /// <summary>
        /// Door code 2
        /// </summary>
        [Description("Door code 2"), Api(MaxLen = 8)]
        public string ccode2 { get; set; }

        /// <summary>
        /// Intercom
        /// </summary>
        [Description("Intercom"), Api(MaxLen = 8)]
        public string cintercom { get; set; }

        /// <summary>
        /// Pickup instructions
        /// </summary>
        [Description("Pickup instructions"), Api(MaxLen = 35)]
        public string cadditionalAddressText { get; set; }

        #endregion

        #region DELIVERY ADDRESS
        /// <summary>
        /// Company name
        /// </summary>
        [Description("Company name"), Api(MaxLen = 35)]
        public string rname { get; set; }

        /// <summary>
        /// Name line 2
        /// </summary>
        [Description("Name line 2"), Api(MaxLen = 35)]
        public string rname2 { get; set; } // TODO: DPD: should be optional (doc), but is mandatory

        /// <summary>
        /// House number
        /// </summary>
        [Description("House number"), Api(MaxLen = 8)]
        public string rhouseNo { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        [Description("Street"), Api(MaxLen = 35)]
        public string rstreet { get; set; }

        /// <summary>
        /// Second line of address
        /// </summary>
        [Description("Second line of address"), Api(MaxLen = 35)]
        public string rstreetInfo { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        [Description("Zip code"), Api(MaxLen = 10)]
        public string rpostal { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Description("City"), Api(MaxLen = 35)]
        public string rcity { get; set; }

        /// <summary>
        /// Country code
        /// </summary>
        [Description("Country code"), Api(MaxLen = 2)]
        public string rcountry { get; set; }

        /// <summary>
        /// Telephone number
        /// </summary>
        [Description("Telephone number"), Api(MaxLen = 20)]
        public string rphone { get; set; }

        /// <summary>
        /// Mobile number
        /// </summary>
        [Description("Mobile number"), Api(MaxLen = 20)]
        public string rphone2 { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Description("Email address"), Api(MaxLen = 20)]
        public string remail { get; set; }

        /// <summary>
        /// Door code 1
        /// </summary>
        [Description("Door code 1"), Api(MaxLen = 8)]
        public string rcode1 { get; set; }

        /// <summary>
        /// Door code 2
        /// </summary>
        [Description("Door code 2"), Api(MaxLen = 8)]
        public string rcode2 { get; set; }

        /// <summary>
        /// Intercom
        /// </summary>
        [Description("Intercom"), Api(MaxLen = 8)]
        public string rintercom { get; set; }

        /// <summary>
        /// Delivery instructions
        /// </summary>
        [Description("Delivery instructions"), Api(MaxLen = 35)]
        public string radditionalAddressText { get; set; }
        #endregion

        /// <summary>
        /// Program a Collection Request
        /// </summary>
        /// <param name="credentials">Credentials</param>
        /// <returns></returns>
        public async Task<ResponseProgramCollectionRequest[]> ProgramAsync(DpdOdysseeCredentials credentials)
        {
            var req = new DpdOdysseeRequest(credentials, path, this);
            return await req.GetResponseAsync<ResponseProgramCollectionRequest[]>();
        }
    }
}
