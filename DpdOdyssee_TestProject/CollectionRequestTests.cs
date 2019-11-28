using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YardConsulting.DpdOdyssee;
using YardConsulting.DpdOdyssee.JSON.CollectionRequests;
using System.Diagnostics;

namespace DpdOdyssee_TestProject
{
    public static class CollectionRequestTests
    {
        internal static async Task<long> ProgramCollectionRequest()
        {
            var request = new RequestProgramCollectionRequest
            {
                custref = "my_ref123",
                weight = 5,
                parcelCount = 10,
                desiredPickupDate = DateTime.Now + TimeSpan.FromDays(1),

                cname = "DPD",
                cstreet = "9 rue Maurice Mallet",
                cpostal = "92130",
                ccity = "Issy -les-Moulineaux",
                ccountry = "FR",
                cphone = "+33 (0)6 00 00 00 00",

                rname = "Geopost",
                rstreet = "26, rue Guynemer",
                rpostal = "92130",
                rcity = "Issy-les-Moulineaux",
                rcountry = "FR",
                rphone = "+33 (0)1 41 33 90 00",


            };

            var acquired_data = await request.ProgramAsync(Program.credentials);

            Debugger.Break();

            return acquired_data.callId.Value;
        }

        internal static async Task CancelCollectionRequest(long callId)
        {
            var request = new RequestCancelCollectionRequest
            {
                callId = callId
            };

            var response = await request.CancelAsync(Program.credentials);

            Debugger.Break();
        }



    }
}
