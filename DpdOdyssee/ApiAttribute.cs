using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace YardConsulting.DpdOdyssee
{
    public class ApiAttribute : Attribute
    {
        public int MaxLen = 0;
        public bool Mandatory; 
    }
}
