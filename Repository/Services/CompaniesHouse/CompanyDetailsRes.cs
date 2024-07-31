using Newtonsoft.Json;
using static Repository.Services.CompaniesHouse.CommanResModal;


namespace Repository.Services.CompaniesHouse
{

    public class CompanyDetails
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
        public string DateOfCessation { get; set; }

        [JsonProperty("date_of_creation")]
        public string DateOfCreation { get; set; }

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
        public string LastFullMembersListDate { get; set; }

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
        public string NextDue { get; set; }

        [JsonProperty("next_made_up_to")]
        public string NextMadeUpTo { get; set; }

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
        public string MadeUpTo { get; set; }

        [JsonProperty("period_end_on")]
        public string PeriodEndOn { get; set; }

        [JsonProperty("period_start_on")]
        public string PeriodStartOn { get; set; }

        [JsonProperty("type")]
        public object Type { get; set; }
    }

    public class NextAccounts
    {
        [JsonProperty("due_on")]
        public string DueOn { get; set; }

        [JsonProperty("overdue")]
        public bool Overdue { get; set; }

        [JsonProperty("period_end_on")]
        public string PeriodEndOn { get; set; }

        [JsonProperty("period_start_on")]
        public string PeriodStartOn { get; set; }
    }

    public class AnnualReturn
    {
        [JsonProperty("last_made_up_to")]
        public string LastMadeUpTo { get; set; }

        [JsonProperty("next_due")]
        public string NextDue { get; set; }

        [JsonProperty("next_made_up_to")]
        public string NextMadeUpTo { get; set; }

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
        public string LastMadeUpTo { get; set; }

        [JsonProperty("next_due")]
        public string NextDue { get; set; }

        [JsonProperty("next_made_up_to")]
        public string NextMadeUpTo { get; set; }

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

    public class ForeignCompanyAccounts
    {
        [JsonProperty("account_period_from")]
        public AccountingPeriod AccountPeriodFrom { get; set; }

        [JsonProperty("account_period_to")]
        public AccountingPeriod AccountPeriodTo { get; set; }

        [JsonProperty("must_file_within")]
        public MustFileWithin MustFileWithin { get; set; }
    }

    public class PreviousCompanyName
    {
        [JsonProperty("ceased_on")]
        public string CeasedOn { get; set; }

        [JsonProperty("effective_from")]
        public string EffectiveFrom { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
