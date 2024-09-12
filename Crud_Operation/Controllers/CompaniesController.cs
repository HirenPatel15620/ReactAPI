using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository.Services.CompaniesHouse;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Crud_Operation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompaniesController : ControllerBase
    {
        private readonly CompaniesHouseService _companiesHouseService;

        public CompaniesController(CompaniesHouseService companiesHouseService)
        {
            _companiesHouseService = companiesHouseService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCompanies([FromQuery] string query)
        {
            var result = await _companiesHouseService.SearchCompaniesAsync(query);
            return Ok(result);
        }

        [HttpGet("{companyNumber}")]
        public async Task<IActionResult> GetCompany(string companyNumber)
        {
            var result = await _companiesHouseService.GetCompanyAsync(companyNumber);
            return Ok(result);
        }

        [HttpGet("{companyNumber}/registered-office-address")]
        public async Task<IActionResult> GetRegisteredOfficeAddress(string companyNumber)
        {
            var result = await _companiesHouseService.GetRegisteredOfficeAddressAsync(companyNumber);
            return Ok(result);
        }
    }
}
