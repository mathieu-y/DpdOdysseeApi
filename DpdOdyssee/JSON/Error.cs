// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardConsulting.DpdOdyssee.JSON
{
    public class Error
    {
        public long timestamp { get; set; } // 1574445529616,
        public int httpStatus { get; set; } // 400,
        public string code { get; set; } // 990110,
        public string error { get; set; } // "VALIDATION_ERROR",
        public string message { get; set; } // "Field: departureUnitId must not be null.",
        public List<string> parameters { get; set; } // [ "departureUnitId" ],        
        public string trace { get; set; } // "[X-B3-TraceId : 5ae2337aea95f135]"

    }
}
