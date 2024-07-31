using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CompaniesHouse
{
    public class CommanResModal
    {
        public class Address
        {
            [JsonProperty("address_line_1")]
            public string AddressLine1 { get; set; }

            [JsonProperty("address_line_2")]
            public string AddressLine2 { get; set; }

            [JsonProperty("care_of")]
            public string CareOf { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("locality")]
            public string Locality { get; set; }

            [JsonProperty("po_box")]
            public string PoBox { get; set; }

            [JsonProperty("postal_code")]
            public string PostalCode { get; set; }

            [JsonProperty("premises")]
            public string Premises { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }
        }

        public class Links
        {
            [JsonProperty("self")]
            public string Self { get; set; }
        }

        public class CompanySearchResult
        {
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

            [JsonProperty("total_results")]
            public int TotalResults { get; set; }
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
            public DateTime? DateOfCessation { get; set; }

            [JsonProperty("date_of_creation")]
            public DateTime DateOfCreation { get; set; }

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

        public class CompanyProfile
        {
            [JsonProperty("accounts")]
            public Accounts Accounts { get; set; }

            [JsonProperty("annual_return")]
            public AnnualReturn AnnualReturn { get; set; }

            [JsonProperty("branch_company_details")]
            public BranchCompanyDetails BranchCompanyDetails { get; set; }

            [JsonProperty("can_file")]
            public bool CanFile { get; set; }

            [JsonProperty("company_name")]
            public string CompanyName { get; set; }

            [JsonProperty("company_number")]
            public string CompanyNumber { get; set; }

            [JsonProperty("company_status")]
            public string CompanyStatus { get; set; }

            [JsonProperty("company_status_detail")]
            public string CompanyStatusDetail { get; set; }

            [JsonProperty("confirmation_statement")]
            public ConfirmationStatement ConfirmationStatement { get; set; }

            [JsonProperty("date_of_cessation")]
            public DateTime? DateOfCessation { get; set; }

            [JsonProperty("date_of_creation")]
            public DateTime DateOfCreation { get; set; }

            [JsonProperty("etag")]
            public string Etag { get; set; }

            [JsonProperty("external_registration_number")]
            public string ExternalRegistrationNumber { get; set; }

            [JsonProperty("foreign_company_details")]
            public ForeignCompanyDetails ForeignCompanyDetails { get; set; }

            [JsonProperty("has_been_liquidated")]
            public bool HasBeenLiquidated { get; set; }

            [JsonProperty("has_charges")]
            public bool HasCharges { get; set; }

            [JsonProperty("has_insolvency_history")]
            public bool HasInsolvencyHistory { get; set; }

            [JsonProperty("is_community_interest_company")]
            public bool IsCommunityInterestCompany { get; set; }

            [JsonProperty("jurisdiction")]
            public string Jurisdiction { get; set; }

            [JsonProperty("last_full_members_list_date")]
            public DateTime? LastFullMembersListDate { get; set; }

            [JsonProperty("links")]
            public Links Links { get; set; }

            [JsonProperty("partial_data_available")]
            public string PartialDataAvailable { get; set; }

            [JsonProperty("previous_company_names")]
            public List<PreviousCompanyName> PreviousCompanyNames { get; set; }

            [JsonProperty("registered_office_address")]
            public Address RegisteredOfficeAddress { get; set; }

            [JsonProperty("registered_office_is_in_dispute")]
            public bool RegisteredOfficeIsInDispute { get; set; }

            [JsonProperty("service_address")]
            public Address ServiceAddress { get; set; }

            [JsonProperty("sic_codes")]
            public List<string> SicCodes { get; set; }

            [JsonProperty("subtype")]
            public string Subtype { get; set; }

            [JsonProperty("super_secure_managing_officer_count")]
            public int? SuperSecureManagingOfficerCount { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("undeliverable_registered_office_address")]
            public bool UndeliverableRegisteredOfficeAddress { get; set; }
        }

        public class Accounts
        {
            [JsonProperty("accounting_reference_date")]
            public AccountingReferenceDate AccountingReferenceDate { get; set; }

            [JsonProperty("last_accounts")]
            public LastAccounts LastAccounts { get; set; }

            [JsonProperty("next_accounts")]
            public NextAccounts NextAccounts { get; set; }

            [JsonProperty("next_due")]
            public DateTime NextDue { get; set; }

            [JsonProperty("next_made_up_to")]
            public DateTime NextMadeUpTo { get; set; }

            [JsonProperty("overdue")]
            public bool Overdue { get; set; }
        }

        public class AccountingReferenceDate
        {
            [JsonProperty("day")]
            public int Day { get; set; }

            [JsonProperty("month")]
            public int Month { get; set; }
        }

        public class LastAccounts
        {
            [JsonProperty("made_up_to")]
            public DateTime MadeUpTo { get; set; }

            [JsonProperty("period_end_on")]
            public DateTime PeriodEndOn { get; set; }

            [JsonProperty("period_start_on")]
            public DateTime PeriodStartOn { get; set; }

            [JsonProperty("type")]
            public object Type { get; set; }
        }

        public class NextAccounts
        {
            [JsonProperty("due_on")]
            public DateTime DueOn { get; set; }

            [JsonProperty("overdue")]
            public bool Overdue { get; set; }

            [JsonProperty("period_end_on")]
            public DateTime PeriodEndOn { get; set; }

            [JsonProperty("period_start_on")]
            public DateTime PeriodStartOn { get; set; }
        }

        public class AnnualReturn
        {
            [JsonProperty("last_made_up_to")]
            public DateTime LastMadeUpTo { get; set; }

            [JsonProperty("next_due")]
            public DateTime NextDue { get; set; }

            [JsonProperty("next_made_up_to")]
            public DateTime NextMadeUpTo { get; set; }

            [JsonProperty("overdue")]
            public bool Overdue { get; set; }
        }

        public class BranchCompanyDetails
        {
            [JsonProperty("business_activity")]
            public string BusinessActivity { get; set; }

            [JsonProperty("parent_company_name")]
            public string ParentCompanyName { get; set; }

            [JsonProperty("parent_company_number")]
            public string ParentCompanyNumber { get; set; }
        }

        public class ConfirmationStatement
        {
            [JsonProperty("last_made_up_to")]
            public DateTime LastMadeUpTo { get; set; }

            [JsonProperty("next_due")]
            public DateTime NextDue { get; set; }

            [JsonProperty("next_made_up_to")]
            public DateTime NextMadeUpTo { get; set; }

            [JsonProperty("overdue")]
            public bool Overdue { get; set; }
        }

        public class ForeignCompanyDetails
        {
            [JsonProperty("accounting_requirement")]
            public AccountingRequirement AccountingRequirement { get; set; }

            [JsonProperty("accounts")]
            public ForeignCompanyAccounts Accounts { get; set; }

            [JsonProperty("business_activity")]
            public string BusinessActivity { get; set; }

            [JsonProperty("company_type")]
            public string CompanyType { get; set; }

            [JsonProperty("governed_by")]
            public string GovernedBy { get; set; }

            [JsonProperty("is_a_credit_finance_institution")]
            public bool IsACreditFinanceInstitution { get; set; }

            [JsonProperty("originating_registry")]
            public OriginatingRegistry OriginatingRegistry { get; set; }

            [JsonProperty("registration_number")]
            public string RegistrationNumber { get; set; }
        }

        public class AccountingRequirement
        {
            [JsonProperty("foreign_account_type")]
            public string ForeignAccountType { get; set; }

            [JsonProperty("terms_of_account_publication")]
            public string TermsOfAccountPublication { get; set; }
        }

        public class ForeignCompanyAccounts
        {
            [JsonProperty("account_period_from")]
            public AccountingPeriod AccountPeriodFrom { get; set; }

            [JsonProperty("account_period_to")]
            public AccountingPeriod AccountPeriodTo { get; set; }

            [JsonProperty("must_file_within")]
            public MustFileWithin MustFileWithin { get; set; }
        }

        public class AccountingPeriod
        {
            [JsonProperty("day")]
            public int Day { get; set; }

            [JsonProperty("month")]
            public int Month { get; set; }
        }

        public class MustFileWithin
        {
            [JsonProperty("months")]
            public int Months { get; set; }
        }

        public class OriginatingRegistry
        {
            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class PreviousCompanyName
        {
            [JsonProperty("ceased_on")]
            public DateTime CeasedOn { get; set; }

            [JsonProperty("effective_from")]
            public DateTime EffectiveFrom { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}
