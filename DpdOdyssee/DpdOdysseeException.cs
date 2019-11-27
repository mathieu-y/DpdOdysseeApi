using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardConsulting.DpdOdyssee
{
    public class DpdOdysseeException: Exception
    {
        public readonly JSON.Error RemoteError;

        public DpdOdysseeException(JSON.Error error) : base($"[{error.code}]: {error.message}")
        {
        }
    }
}
