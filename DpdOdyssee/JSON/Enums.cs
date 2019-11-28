using System;
using System.Collections.Generic;
using System.Text;

namespace YardConsulting.DpdOdyssee
{
    /// <summary>
    /// This parameter is to be set if you want to allow your consignee to proceed to a merchandise return.
    /// </summary>
    public enum RODType : long
    {
        /// <summary>
        /// Initial and return labels are both printed at the same time, you will include the return label inside the parcel for a future usage by the consignee
        /// </summary>
        Prepared = 0,

        /// <summary>
        /// Return label will be authorized and printed afterwards, by calling the shipment/print/return-ondemand method, or by your consignee on our website dpd.fr
        /// </summary>
        OnDemand = 1
    };

    public enum LabelFormat
    {
        A4,
        A6
    };

    public enum FileType
    {
        PDF,
        DPL,
        ZPL,
        EPL,
        FPL
    }

    public enum LabelDPI : long
    {
        dpi203 = 203,
        dpi300 = 300,
        dpi600 = 600
    }

    /// <summary>
    /// List of delivery services proposed by DPD France
    /// </summary>
    public enum DPDProduct : long
    {
        /// <summary>
        /// Destinations: France, Europe
        /// Deferred delivery in France and Europe
        /// </summary>
        DpdClassic = 1,

        /// <summary>
        /// Destinations: World excl. France, Europe
        /// Delivery by air for destinations outside Europe
        /// </summary>
        DpdClassicIntercontinental = 40033,

        /// <summary>
        /// Destinations: France, Europe
        /// Private customers delivery with an SMS/Mail interaction
        /// </summary>
        DpdPredict = 40275,

        /// <summary>
        /// Destinations: France
        /// Delivery to a Pickup PUDO shop
        /// </summary>
        DpdRelais = 40276,

        /// <summary>
        /// Destinations: France
        /// Parcel drop-off at a Pickup PUDO shop to be returned to sender
        /// </summary>
        DpdRetour = 40278
    }
}
