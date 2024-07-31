using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repository.Services.CompaniesHouse.CommanResModal;

namespace Repository.Services.CompaniesHouse
{

    public class RegisteredOfficeAddress
    {
        [JsonProperty("accept_appropriate_office_address_statement")]
        public bool AcceptAppropriateOfficeAddressStatement { get; set; }

        [JsonProperty("address_line_1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("address_line_2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("premises")]
        public string Premises { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }
    }
}
