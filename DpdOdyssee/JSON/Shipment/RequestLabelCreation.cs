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
            [Description("Company name"), Api(MaxLen = 35)]
            public string name { get; set; }

            [Description("House number"), Api(MaxLen = 8)]
            public string buildingNo { get; set; }

            [Description("Street"), Api(MaxLen = 35)]
            public string street { get; set; }

            [Description("Second line of address"), Api(MaxLen = 35)]
            public string streetInfo { get; set; }

            [Description("Zip code"), Api(MaxLen = 10)]
            public string zipCode { get; set; }

            [Description("City "), Api(MaxLen = 35)]
            public string cityName { get; set; }

            [Description("Country code"), Api(MaxLen = 2)]
            public string countryCode { get; set; }

            [Description("Telephone number"), Api(MaxLen = 20)]
            public string telNo { get; set; }
        }
        #endregion

        #region DATE
        [Description("Shipment date (format YYYYMMDD)"), Api(MaxLen = 8)]
        public DateTime shipmentDate { get; set; } = DateTime.Now;
        #endregion

        #region IDENTIFICATION
        [Description("Payer customer ID")]
        public long? payerId { get; set; }

        [Description("Payer customer address ID")]
        public long? payerAddressId { get; set; }

        [Description("Sender customer ID")]
        public long? senderId { get; set; }

        [Description("Sender customer address ID")]
        public long? senderAddressId { get; set; }

        [Description("Origin DPD depot code – refer to §2.6.1"), Api(MaxLen = 4)]
        public string departureUnitId { get; set; }

        [Description("Sender zip code"), Api(MaxLen = 10)]
        public string senderZipCode { get; set; }

        [Description("Sender country code – Code ISO-2"), Api(MaxLen = 2)]
        public string senderCountryCode { get; set; }
        #endregion

        #region CONSIGNEE
        [Description("Company name, mandatory if receiverLastName is empty"), Api(MaxLen = 35)]
        public string receiverFirmName { get; set; }

        [Description("First name, mandatory if DPD Relais delivery"), Api(MaxLen = 35)]
        public string receiverFirstName { get; set; }

        [Description("Last name, mandatory if receiverFirmName is empty"), Api(MaxLen = 35)]
        public string receiverLastName { get; set; }

        [Description("House number"), Api(MaxLen = 8)]
        public string receiverHouseNo { get; set; }

        [Description("Street"), Api(MaxLen = 35)]
        public string receiverStreet { get; set; }

        [Description("Second line of address"), Api(MaxLen = 35)]
        public string receiverStreetInfo { get; set; }

        [Description("Zip code"), Api(MaxLen = 10)]
        public string receiverZipCode { get; set; }

        [Description("City"), Api(MaxLen = 35)]
        public string receiverCity { get; set; }

        [Description("CountryCode"), Api(MaxLen = 2)]
        public string receiverCountryCode { get; set; }

        [Description("Telephone number"), Api(MaxLen = 20)]
        public string receiverLandlineNumber { get; set; }

        [Description("Mobile number"), Api(MaxLen = 20)]
        public string receiverMobileNumber { get; set; }

        [Description("Email address"), Api(MaxLen = 35)]
        public string receiverEmailAdress { get; set; }

        [Description("Door code 1"), Api(MaxLen = 8)]
        public string receiverCode1 { get; set; }

        [Description("Door code 2"), Api(MaxLen = 8)]
        public string receiverCode2 { get; set; }

        [Description("Intercom"), Api(MaxLen = 35)]
        public string receiverIntercom { get; set; }

        [Description("Delivery instructions, additional address information"), Api(MaxLen = 70)]
        public string receiverAdditionalAdrInfo { get; set; }
        #endregion

        #region SENDER
        [Description("« true » if the sender address must be replaced")]
        public bool? replaceSender { get; set; }

        [Description("List of <Address>")]
        public List<Address> replaceSenderAddress { get; set; }
        #endregion

        #region PUDO
        [Description("Pickup PUDO shop ID – refer to §2.6.2"), Api(MaxLen = 6)]
        public string parcelShopId { get; set; }
        #endregion

        #region RETURNS
        [Description("Returns service – refer to §2.6.3"), Api(MaxLen = 10)]
        public long? returnType { get; set; }
        [Description("« true » if the return address is equal to the sender’s")]
        public bool? sameReturnAddress { get; set; }
        [Description("List of <Address>")]
        public List<Address> returnAddress { get; set; }
        #endregion

        #region GROUP
        [Description("Grouping service – refer to §2.6.4")]
        public bool? mps { get; set; }
        #endregion

        #region PARCELS
        [Description("List of <Parcel>")]
        public List<Parcel> parcels { get; set; }
        public class Parcel
        {
            [Description("Reference 1"), Api(MaxLen = 35)]
            public string cref1 { get; set; }

            [Description("Reference 2"), Api(MaxLen = 35)]
            public string cref2 { get; set; }

            [Description("Reference 3"), Api(MaxLen = 35)]
            public string cref3 { get; set; }

            [Description("Reference 4"), Api(MaxLen = 35)]
            public string cref4 { get; set; }

            [Description("Declared goods value for insurance – refer to §2.6.5"), Api(MaxLen = 10)]
            public string hinsAmount { get; set; }

            [Description("Parcel weight – in kg"), Api(MaxLen = 10)]
            public float weight { get; set; }
        }
        #endregion

        #region SERVICE
        [Description("List of <Product>")]

        //public List<Product> products { get; set; }  Documentation seems to be wrong ?
        public Product products { get; set; }

        public class Product
        {
            [Description("DPD delivery service ID – refer to §2.6.6")]
            public DPDProduct productId { get; set; }

            public static implicit operator Product(DPDProduct product) => new Product { productId = product };
        }
        #endregion

        #region LABELS
        [Description("List of <ManifestItem>")]
        //public List<ManifestItem> manifest { get; set; } Documentation seems to be wrong ?
        public ManifestItem manifest { get; set; } // Documentation seems to be wrong ?
        public class ManifestItem
        {
            [Description("Always 'fr'"), Api(MaxLen = 2)]
            public string language { get; set; } = "fr";

            [Description("'A4' or 'A6'"), Api(MaxLen = 2)]
            [JsonConverter(typeof(StringEnumConverter))]
            public LabelFormat labelFormat { get; set; }

            [Description("Print References 1 & 2 as CODE128 barcodes")]
            public bool referenceAsBarcode { get; set; }

            [Description("Print flow : PDF, ZPL, EPL - PDF by default"), Api(MaxLen = 3)]
            [JsonConverter(typeof(StringEnumConverter))]
            public FileType fileType { get; set; } = FileType.PDF;

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

        public async Task<ResponseGetLabels> PrintAsync(DpdOdysseeCredentials credentials)
        {
            FillFrom(credentials);
            var req = new DpdRequest(credentials, GetPath("print"), this);
            return await req.GetResponseAsync<ResponseGetLabels>();
        }

        public async Task<ResponseTempShipArray> SaveAsync(DpdOdysseeCredentials credentials)
        {
            FillFrom(credentials);
            var req = new DpdRequest(credentials, GetPath("ext"), this);
            return await req.GetResponseAsync<ResponseTempShipArray>();
        }
    }
}
