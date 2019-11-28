using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using YardConsulting.DpdOdyssee;
using YardConsulting.DpdOdyssee.JSON.PickupOrders;
using System.Diagnostics;

namespace DpdOdyssee_TestProject
{
    public static class PickupTests
    {

        /// <summary>
        /// Test: Trigger a one-off pickup order
        /// </summary>
        internal static async Task<long> TestProgramPickup()
        {
            var pickup = await new RequestProgramPickupOrder
            {
                contactPerson = "M. Jean Barque",
                desiredPickUpDate = DateTime.Now + TimeSpan.FromDays(5),
                desiredPickUpTime1 = "080000",
                desiredPickUpTime2 = "180000",

            }.ProgramAsync(Program.credentials);

            // Look in your "Output" tab for the result, use your Locals' window, or put your mouse over the pickup variable to see the result.
            Debugger.Break();

            return pickup.callId.Value;
        }

        /// <summary>
        /// Test: Cancel a one-off pickup order
        /// </summary>
        internal static async Task TestCancelProgramPickup(long callId)
        {
            var cancel = await new RequestCancelPickupOrder
            {
                callId = callId

            }.CancelAsync(Program.credentials);

            // Look in your "Output" tab for the result, use your Locals' window, or put your mouse over the cancel variable to see the result.
            Debugger.Break();
        }
    }
}
