// Mathieu Yard, 2019 - mathieu.yard at gmail.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace YardConsulting
{
    public class DpdOdysseeCredentials
    {
        static readonly JsonSerializer serializer = new JsonSerializer { MissingMemberHandling = MissingMemberHandling.Error };
        static readonly Encoding httpHeaderEncoding = Encoding.GetEncoding("ISO-8859-1");

        public string login { get; set; }
        public string password { get; set; }
        public long? payerId { get; set; }
        public long? payerAddressId { get; set; }
        public long? senderId { get; set; }
        public long? senderAddressId { get; set; }
        public string departureUnitId { get; set; }
        public string senderZipCode { get; set; }
        public string senderCountryCode { get; set; }
        public int maxParcelInGroup { get; set; } = 3;

        public DpdOdysseeCredentials()
        {
        }

        public DpdOdysseeCredentials(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public DpdOdysseeCredentials(string path)
        {
            using (var stream = File.OpenRead(path))
                serializer.Populate(new JsonTextReader(new StreamReader(stream)), this);
        }

        public override string ToString() => String.Concat("Basic ", Convert.ToBase64String(httpHeaderEncoding.GetBytes($"{login}:{password}")));
    }
}
