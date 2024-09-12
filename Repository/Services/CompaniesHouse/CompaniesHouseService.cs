using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CompaniesHouse
{
    public class CompaniesHouseService
    {
        private readonly HttpClient _httpClient;

        public CompaniesHouseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.company-information.service.gov.uk/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Assuming the API key is the username and the password is an empty string
            var apiKey = "aff7ac31-cacf-43cc-8de2-fef38736ca9c";
            var base64ApiKey = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{apiKey}:"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64ApiKey);
        }

        public async Task<CompanySearchResult> SearchCompaniesAsync(string query)
        {
            var response = await _httpClient.GetAsync($"search/companies?q={query}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CompanySearchResult>(jsonResponse);
        }

        public async Task<CompanyDetails> GetCompanyAsync(string companyNumber)
        {
            var response = await _httpClient.GetAsync($"company/{companyNumber}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CompanyDetails>(jsonResponse);
        }


        public async Task<RegisteredOfficeAddress> GetRegisteredOfficeAddressAsync(string companyNumber)
        {
            var response = await _httpClient.GetAsync($"company/{companyNumber}/registered-office-address");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RegisteredOfficeAddress>(jsonResponse);
        }
    }
}
