using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using YardConsulting;


namespace DpdOdyssee_TestProject
{
    class Program
    { 
        internal static DpdOdysseeCredentials credentials;

        static async Task Main(string[] args)
        {
            // This file must be in the same path as the .exe
            credentials = new DpdOdysseeCredentials("credentials.json");

            // Feel free to comment/uncomment the lines below to run the matching tests

            long callId = await PickupTests.TestProgramPickup();
            await PickupTests.TestCancelProgramPickup(callId);

            long parcelNumber = await ShippingTests.TestOne();
            await ShippingTests.TestReprint(parcelNumber);
            await ShippingTests.TestPrintROD(parcelNumber);

            await ShippingTests.TestMulti();

            long [] callId = await CollectionRequestTests.ProgramCollectionRequest();
            await CollectionRequestTests.CancelCollectionRequest(callId.First()); // <== error 504, timeout. Problem at DPD side.


        }
    }
}
