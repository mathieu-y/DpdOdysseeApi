// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using YardConsulting;
using System.ComponentModel;


namespace YardConsulting.DpdOdyssee.JSON.Shipment
{
    /// <summary>
    /// 2.5.2
    /// The API returns the requested shipping information, as well as a document that contains the transport labels
    /// </summary>
    public class ResponseReturnOnDemandLabel
    {
        [Description("Shipment ID - unused")]
        public long shpId { get; set; }

        [Description("Manifest ID - unused")]
        public long manifestId { get; set; }

        [Description("Parcel number")]
        public List<long> parcels { get; set; }

        [Description("List of <Label>")]
        public List<Label> label { get; set; }        
    }
}
