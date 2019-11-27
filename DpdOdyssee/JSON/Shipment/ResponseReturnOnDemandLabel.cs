using System;
using System.Collections.Generic;
using YardConsulting;
using System.ComponentModel;


namespace YardConsulting.DpdOdyssee.JSON.Shipment
{
    /// <summary>
    /// 2.5.2
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
