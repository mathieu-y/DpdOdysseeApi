using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Diagnostics;

using System.IO;

using YardConsulting;
using YardConsulting.DpdOdyssee;
using YardConsulting.DpdOdyssee.JSON.Shipment;


namespace DpdOdyssee_TestProject
{
    class Program
    { 
        static DpdOdysseeCredentials credentials;

        static async Task Main(string[] args)
        {
            // This file must be in the same path as the .exe
            credentials = new DpdOdysseeCredentials("credentials.json");

            await TestOne();
            await TestMulti();
        }

        static async Task TestOne()
        {
            var labels = await new RequestLabelCreation
            {               
                receiverFirmName = "DPD ßöëéà Şimşek Матье",
                receiverHouseNo = "8",
                receiverStreet = "Rue de Chevilly",
                receiverZipCode = "94260",
                receiverCity = "Fresnes",
                receiverCountryCode = "FR",

                parcels = new List<RequestLabelCreation.Parcel> {
                    new RequestLabelCreation.Parcel()
                    {
                        cref1 = "cref1",
                        weight = 1.1f
                    }
                },

                products = DPDProduct.DpdClassic,

                manifest = new RequestLabelCreation.ManifestItem
                {
                    labelFormat = LabelFormat.A6,
                    referenceAsBarcode = true,
                    dpi = LabelDPI.dpi203
                }

            }.PrintAsync(credentials);

            // Write the label in the current path.
            File.WriteAllBytes(labels.label.fileName, labels.label.fileContent);
        }

        static async Task TestMulti()
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
                        weight = 1.1f
                    },
                    new RequestLabelCreation.Parcel()
                    {
                        cref1 = "cref1-B",
                        weight = 1.2f
                    },                    
                    new RequestLabelCreation.Parcel()
                    {
                        cref1 = "cref1-C",
                        weight = 1.3f
                    }
                },

                products = DPDProduct.DpdClassic

            }.SaveAsync(credentials);


            var labels = await new RequestGetLabels
            {
                labelFormat = LabelFormat.A6,
                referenceAsBarcode = true,
                shpIdList = response,
                fileType = FileType.ZPL,
                dpi = LabelDPI.dpi203
            }.DownloadAsync(credentials);

            // Write the label in the current path.
            File.WriteAllBytes(labels.label.fileName, labels.label.fileContent);        
        }        
    }
}
