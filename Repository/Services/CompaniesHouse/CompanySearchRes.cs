using Newtonsoft.Json;
using static Repository.Services.CompaniesHouse.CommanResModal;
using System.Text.RegularExpressions;

namespace Repository.Services.CompaniesHouse
{
    public class CompanySearchResult
    {
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("items")]
        public List<CompanySearchItem> Items { get; set; }

        [JsonProperty("items_per_page")]
        public int ItemsPerPage { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("start_index")]
        public int StartIndex { get; set; }


    }

    public class CompanySearchItem
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("address_snippet")]
        public string AddressSnippet { get; set; }

        [JsonProperty("company_number")]
        public string CompanyNumber { get; set; }

        [JsonProperty("company_status")]
        public string CompanyStatus { get; set; }

        [JsonProperty("company_type")]
        public string CompanyType { get; set; }

        [JsonProperty("date_of_cessation")]
        public string DateOfCessation { get; set; }

        [JsonProperty("date_of_creation")]
        public string DateOfCreation { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description_identifier")]
        public List<string> DescriptionIdentifier { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }


}
