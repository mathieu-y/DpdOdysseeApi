using System;
using System.Collections.Generic;
using YardConsulting;
using System.ComponentModel;

namespace YardConsulting.DpdOdyssee.JSON.Shipment
{
    /// <summary>
    /// 2.1.2
    /// </summary>
    public class ResponseGetLabels
    {
        public class Shipment
        {
            [Description("Shipment ID - unused")]
            public long shpId { get; set; }

            [Description("Return shipment ID – unused")]
            public long returnShpId { get; set; }

            [Description("Manifest ID - unused")]
            public long manifestId { get; set; }

            [Description("Master parcel ID (when grouped)")]
            public long masterParcelId { get; set; }

            [Description("Parcel number")]
            public List<long> parcels { get; set; }

            [Description("Return parcel number")]
            public List<long> returnParcels { get; set; }

            
        }

        [Description("Données d’expédition")]
        public List<Shipment> shipments { get; set; }

        [Description("Etiquette")]
        public Label label { get; set; }

    }
}
