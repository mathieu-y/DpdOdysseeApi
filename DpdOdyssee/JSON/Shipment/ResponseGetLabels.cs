// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using YardConsulting;
using System.ComponentModel;

namespace YardConsulting.DpdOdyssee.JSON.Shipment
{
    /// <summary>
    /// <b>2.1.2</b>
    /// The API returns the requested shipping information, as well as a document that contains the transport labels
    /// </summary>
    public class ResponseGetLabels
    {
        public class Shipment
        {
            /// <summary>
            /// Shipment ID - unused
            /// </summary>
            [Description("Shipment ID - unused")]
            public long shpId { get; set; }

            /// <summary>
            /// Return shipment ID – unused
            /// </summary>
            [Description("Return shipment ID – unused")]
            public long returnShpId { get; set; }

            /// <summary>
            /// Manifest ID - unused
            /// </summary>
            [Description("Manifest ID - unused")]
            public long manifestId { get; set; }

            /// <summary>
            /// Master parcel ID (when grouped)
            /// </summary>
            [Description("Master parcel ID (when grouped)")]
            public long masterParcelId { get; set; }

            /// <summary>
            /// Parcel number
            /// </summary>
            [Description("Parcel number")]
            public List<long> parcels { get; set; }

            /// <summary>
            /// Return parcel number
            /// </summary>
            [Description("Return parcel number")]
            public List<long> returnParcels { get; set; }

            
        }

        /// <summary>
        /// Données d’expédition
        /// </summary>
        [Description("Données d’expédition")]
        public List<Shipment> shipments { get; set; }

        /// <summary>
        /// Etiquette
        /// </summary>
        [Description("Etiquette")]
        public Label label { get; set; }

    }
}
