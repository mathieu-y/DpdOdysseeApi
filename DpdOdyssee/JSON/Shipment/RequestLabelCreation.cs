// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using YardConsulting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YardConsulting.DpdOdyssee.JSON.Shipment
{
    /// <summary>
    /// 2.1.1 Unitary shipment label creation
    /// </summary>
    public class RequestLabelCreation
    {
        string GetPath(string action) => $"shipment/save/{action}";

        #region ** FIELDS **
        #region Address
        public class Address
        {
            /// <summary>
            /// Company name
            /// </summary>
            [Description("Company name"), Api(MaxLen = 35)]
            public string name { get; set; }

            /// <summary>
            /// House number
            /// </summary>
            [Description("House number"), Api(MaxLen = 8)]
            public string buildingNo { get; set; }

            /// <summary>
            /// Street
            /// </summary>
            [Description("Street"), Api(MaxLen = 35)]
            public string street { get; set; }

            /// <summary>
            /// Second line of address
            /// </summary>
            [Description("Second line of address"), Api(MaxLen = 35)]
            public string streetInfo { get; set; }

            /// <summary>
            /// Zip code
            /// </summary>
            [Description("Zip code"), Api(MaxLen = 10)]
            public string zipCode { get; set; }

            /// <summary>
            /// City
            /// </summary>
            [Description("City"), Api(MaxLen = 35)]
            public string cityName { get; set; }

            /// <summary>
            /// Country code
            /// </summary>
            [Description("Country code"), Api(MaxLen = 2)]
            public string countryCode { get; set; }

            /// <summary>
            /// Telephone number
            /// </summary>
            [Description("Telephone number"), Api(MaxLen = 20)]
            public string telNo { get; set; }
        }
        #endregion

        #region DATE
        /// <summary>
        /// Shipment date (format YYYYMMDD)
        /// </summary>
        [Description("Shipment date (format YYYYMMDD)"), Api(MaxLen = 8)]
        public DateTime shipmentDate { get; set; } = DateTime.Now;
        #endregion

        #region IDENTIFICATION
        /// <summary>
        /// Payer customer ID
        /// </summary>
        [Description("Payer customer ID")]
        public long? payerId { get; set; }

        /// <summary>
        /// Payer customer address ID
        /// </summary>
        [Description("Payer customer address ID")]
        public long? payerAddressId { get; set; }

        /// <summary>
        /// Sender customer ID
        /// </summary>
        [Description("Sender customer ID")]
        public long? senderId { get; set; }

        /// <summary>
        /// Sender customer address ID
        /// </summary>
        [Description("Sender customer address ID")]
        public long? senderAddressId { get; set; }

        /// <summary>
        /// Origin DPD depot code – refer to §2.6.1
        /// </summary>
        [Description("Origin DPD depot code – refer to §2.6.1"), Api(MaxLen = 4)]
        public string departureUnitId { get; set; }

        /// <summary>
        /// Sender zip code
        /// </summary>
        [Description("Sender zip code"), Api(MaxLen = 10)]
        public string senderZipCode { get; set; }

        /// <summary>
        /// Sender country code – Code ISO-2
        /// </summary>
        [Description("Sender country code – Code ISO-2"), Api(MaxLen = 2)]
        public string senderCountryCode { get; set; }
        #endregion

        #region CONSIGNEE
        /// <summary>
        /// Company name, mandatory if receiverLastName is empty
        /// </summary>
        [Description("Company name, mandatory if receiverLastName is empty"), Api(MaxLen = 35)]
        public string receiverFirmName { get; set; }

        /// <summary>
        /// First name, mandatory if DPD Relais delivery
        /// </summary>
        [Description("First name, mandatory if DPD Relais delivery"), Api(MaxLen = 35)]
        public string receiverFirstName { get; set; }

        /// <summary>
        /// Last name, mandatory if receiverFirmName is empty
        /// </summary>
        [Description("Last name, mandatory if receiverFirmName is empty"), Api(MaxLen = 35)]
        public string receiverLastName { get; set; }

        /// <summary>
        /// House number
        /// </summary>
        [Description("House number"), Api(MaxLen = 8)]
        public string receiverHouseNo { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        [Description("Street"), Api(MaxLen = 35)]
        public string receiverStreet { get; set; }

        /// <summary>
        /// Second line of address
        /// </summary>
        [Description("Second line of address"), Api(MaxLen = 35)]
        public string receiverStreetInfo { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        [Description("Zip code"), Api(MaxLen = 10)]
        public string receiverZipCode { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Description("City"), Api(MaxLen = 35)]
        public string receiverCity { get; set; }

        /// <summary>
        /// CountryCode
        /// </summary>
        [Description("CountryCode"), Api(MaxLen = 2)]
        public string receiverCountryCode { get; set; }

        /// <summary>
        /// Telephone number
        /// </summary>
        [Description("Telephone number"), Api(MaxLen = 20)]
        public string receiverLandlineNumber { get; set; }

        /// <summary>
        /// Mobile number
        /// </summary>
        [Description("Mobile number"), Api(MaxLen = 20)]
        public string receiverMobileNumber { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Description("Email address"), Api(MaxLen = 35)]
        public string receiverEmailAdress { get; set; }

        /// <summary>
        /// Door code 1
        /// </summary>
        [Description("Door code 1"), Api(MaxLen = 8)]
        public string receiverCode1 { get; set; }

        /// <summary>
        /// Door code 2
        /// </summary>
        [Description("Door code 2"), Api(MaxLen = 8)]
        public string receiverCode2 { get; set; }

        /// <summary>
        /// Intercom
        /// </summary>
        [Description("Intercom"), Api(MaxLen = 35)]
        public string receiverIntercom { get; set; }

        /// <summary>
        /// Delivery instructions, additional address information
        /// </summary>
        [Description("Delivery instructions, additional address information"), Api(MaxLen = 70)]
        public string receiverAdditionalAdrInfo { get; set; }
        #endregion

        #region SENDER
        /// <summary>
        /// « true » if the sender address must be replaced
        /// </summary>
        [Description("« true » if the sender address must be replaced")]
        public bool? replaceSender { get; set; }

        /// <summary>
        /// List of <Address>
        /// </summary>
        [Description("List of <Address>")]
        public List<Address> replaceSenderAddress { get; set; }
        #endregion

        #region PUDO
        /// <summary>
        /// Pickup PUDO shop ID – refer to §2.6.2
        /// </summary>
        [Description("Pickup PUDO shop ID – refer to §2.6.2"), Api(MaxLen = 6)]
        public string parcelShopId { get; set; }
        #endregion

        #region RETURNS
        /// <summary>
        /// Returns service – refer to §2.6.3
        /// </summary>
        [Description("Returns service – refer to §2.6.3"), Api(MaxLen = 10)]
        public RODType? returnType { get; set; }

        /// <summary>
        /// « true » if the return address is equal to the sender’s
        /// </summary>
        [Description("« true » if the return address is equal to the sender’s")]
        public bool? sameReturnAddress { get; set; }

        /// <summary>
        /// List of <Address>
        /// </summary>
        [Description("List of <Address>")]
        public List<Address> returnAddress { get; set; }
        #endregion

        #region GROUP
        /// <summary>
        /// Grouping service – refer to §2.6.4
        /// </summary>
        [Description("Grouping service – refer to §2.6.4")]
        public bool? mps { get; set; }
        #endregion

        #region PARCELS
        /// <summary>
        /// List of <Parcel>
        /// </summary>
        [Description("List of <Parcel>")]
        public List<Parcel> parcels { get; set; }
        public class Parcel
        {
            /// <summary>
            /// Reference 1
            /// </summary>
            [Description("Reference 1"), Api(MaxLen = 35)]
            public string cref1 { get; set; }

            /// <summary>
            /// Reference 2
            /// </summary>
            [Description("Reference 2"), Api(MaxLen = 35)]
            public string cref2 { get; set; }

            /// <summary>
            /// Reference 3
            /// </summary>
            [Description("Reference 3"), Api(MaxLen = 35)]
            public string cref3 { get; set; }

            /// <summary>
            /// Reference 4
            /// </summary>
            [Description("Reference 4"), Api(MaxLen = 35)]
            public string cref4 { get; set; }

            /// <summary>
            /// Declared goods value for insurance – refer to §2.6.5
            /// </summary>
            [Description("Declared goods value for insurance – refer to §2.6.5"), Api(MaxLen = 10)]
            public string hinsAmount { get; set; }

            /// <summary>
            /// Parcel weight – in kg
            /// </summary>
            [Description("Parcel weight – in kg"), Api(MaxLen = 10)]
            public decimal weight { get; set; } // decimal is better than float to avoid rounding
        }
        #endregion

        #region SERVICE
        /// <summary>
        /// List of <Product>
        /// </summary>
        [Description("List of <Product>")]

        //public List<Product> products { get; set; }  (actually not a list, documentation seems to be wrong ?)
        public Product products { get; set; }


        public class Product
        {
            [Description("DPD delivery service ID – refer to §2.6.6")]
            public DPDProduct productId { get; set; }

            public static implicit operator Product(DPDProduct product) => new Product { productId = product };
        }
        #endregion

        #region LABELS
        /// <summary>
        /// List of <ManifestItem> (actually not a list, documentation seems to be wrong ?)
        /// </summary>
        [Description("List of <ManifestItem>")]
        //public List<ManifestItem> manifest { get; set; } 
        public ManifestItem manifest { get; set; } // Documentation seems to be wrong ?
        public class ManifestItem
        {
            /// <summary>
            /// Always 'fr'
            /// </summary>
            [Description("Always 'fr'"), Api(MaxLen = 2)]
            public string language { get; set; } = "fr";

            /// <summary>
            /// 'A4' or 'A6'
            /// </summary>
            [Description("'A4' or 'A6'"), Api(MaxLen = 2)]
            [JsonConverter(typeof(StringEnumConverter))]
            public LabelFormat labelFormat { get; set; }

            /// <summary>
            /// Print References 1 and 2 as CODE128 barcodes 
            /// </summary>
            [Description("Print References 1 & 2 as CODE128 barcodes")]
            public bool referenceAsBarcode { get; set; }

            /// <summary>
            /// Print flow : PDF, ZPL, EPL - PDF by default
            /// </summary>
            [Description("Print flow : PDF, ZPL, EPL - PDF by default"), Api(MaxLen = 3)]
            [JsonConverter(typeof(StringEnumConverter))]
            public FileType fileType { get; set; } = FileType.PDF;

            /// <summary>
            /// ZPL / EPL definition in dpi: 203, 300, or 600
            /// </summary>
            [Description("ZPL / EPL definition in dpi: 203, 300, or 600"), Api(MaxLen = 3)]
            public LabelDPI dpi { get; set; }
        }
        #endregion
        #endregion

        void FillFrom(DpdOdysseeCredentials credentials)
        {
            payerId = credentials.payerId;
            payerAddressId = credentials.payerAddressId;
            senderId = credentials.senderId;
            senderAddressId = credentials.senderAddressId;
            departureUnitId = credentials.departureUnitId;
            senderZipCode = credentials.senderZipCode;
            senderCountryCode = credentials.senderCountryCode;
        }

        /// <summary>
        /// Unitary shipment label creation
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public async Task<ResponseGetLabels> PrintAsync(DpdOdysseeCredentials credentials)
        {
            FillFrom(credentials);
            var req = new DpdOdysseeRequest(credentials, GetPath("print"), this);
            return await req.GetResponseAsync<ResponseGetLabels>();
        }

        /// <summary>
        /// Shipment registering for future label generation
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public async Task<ResponseTempShipArray> SaveAsync(DpdOdysseeCredentials credentials)
        {
            FillFrom(credentials);
            var req = new DpdOdysseeRequest(credentials, GetPath("ext"), this);
            return await req.GetResponseAsync<ResponseTempShipArray>();
        }
    }
}
