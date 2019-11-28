using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using YardConsulting.DpdOdyssee;
using YardConsulting.DpdOdyssee.JSON.Shipment;

namespace DpdOdyssee_TestProject
{
    class ShippingTests
    {
        /// <summary>
        /// Test: Print an unique label, and re-print it.
        /// </summary>
        /// <returns>ParcelID</returns>
        internal static async Task<long> TestOne()
        {
            // Prepare a command
            var request_label = new RequestLabelCreation
            {
                receiverFirmName = "DPD ßöëéà Şimşek Матье", // Testing UTF-8
                receiverHouseNo = "8",
                receiverStreet = "Rue de Chevilly",
                receiverZipCode = "94260",
                receiverCity = "Fresnes",
                receiverCountryCode = "FR",

                returnType = RODType.OnDemand,

                parcels = new List<RequestLabelCreation.Parcel> {
                    new RequestLabelCreation.Parcel()
                    {
                        cref1 = "cref1",
                        weight = 30.33333M
                    }
                },

                products = DPDProduct.DpdClassic,

                manifest = new RequestLabelCreation.ManifestItem
                {
                    labelFormat = LabelFormat.A6,
                    referenceAsBarcode = true,
                    dpi = LabelDPI.dpi203
                }

            };
            
            // Remote Call DPD
            var labels = await request_label.PrintAsync(Program.credentials);

            // Write the label in the current path.
            File.WriteAllBytes(labels.label.fileName, labels.label.fileContent);

            // Return the parcel's id
            return labels.shipments.First().parcels.First();
        }

        /// <summary>
        /// Test: Reprint a label
        /// </summary>
        /// <param name="parcelNumber">ParcelNumber to reprint</param>
        /// <returns></returns>
        internal static async Task TestReprint(long parcelNumber)
        {
            var label = await new RequestGetLabels
            {
                labelFormat = LabelFormat.A6,
                referenceAsBarcode = true,
                parcelNumber = parcelNumber.ToString(),
                fileType = FileType.PDF,
                dpi = LabelDPI.dpi300

            }.ReprintAsync(Program.credentials);

            // Write the label in the current path.
            File.WriteAllBytes($"reprint.{label.fileName}", label.fileContent);
        }

        /// <summary>
        /// Test: Print a return-on-demand label
        /// </summary>
        /// <param name="parcelNumber">ParcelNumber corresponding to the ROD</param>
        /// <returns></returns>
        internal static async Task TestPrintROD(long parcelNumber)
        {
            var rod = await new RequestGetLabels
            {
                labelFormat = LabelFormat.A6,
                referenceAsBarcode = true,
                parcelNumber = parcelNumber.ToString(),
                fileType = FileType.PDF,
                dpi = LabelDPI.dpi300

            }.PrintReturnOnDemandAsync(Program.credentials);

            // Write the label in the current path.
            File.WriteAllBytes($"print.on.demand.{rod.label.First().fileName}", rod.label.First().fileContent);
        }

        /// <summary>
        /// Test: Print and consolidate 3 parcels at once.
        /// </summary>
        /// <returns></returns>
        internal static async Task TestMulti()
        {
            var response = await new RequestLabelCreation
            {
                receiverFirmName = "DPD",
                receiverHouseNo = "8",
                receiverStreet = "Rue de Chevilly",
                receiverZipCode = "94260",
                receiverCity = "Fresnes",
                receiverCountryCode = "FR",

                mps = true, // 2-5 

                parcels = new List<RequestLabelCreation.Parcel> {
                    new RequestLabelCreation.Parcel()
                    {
                        cref1 = "cref1-A",
                        weight = 1.1M
                    },
                    new RequestLabelCreation.Parcel()
                    {
                        cref1 = "cref1-B",
                        weight = 1.2M
                    },
                    new RequestLabelCreation.Parcel()
                    {
                        cref1 = "cref1-C",
                        weight = 1.3M
                    }
                },

                products = DPDProduct.DpdClassic

            }.SaveAsync(Program.credentials);


            var labels = await new RequestGetLabels
            {
                labelFormat = LabelFormat.A6,
                referenceAsBarcode = true,
                shpIdList = response,
                fileType = FileType.ZPL,
                dpi = LabelDPI.dpi203
            }.DownloadAsync(Program.credentials);

            // Write the label in the current path.
            File.WriteAllBytes(labels.label.fileName, labels.label.fileContent);
        }
    }
}
