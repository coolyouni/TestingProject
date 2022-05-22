using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.TestCases;
using OpenQA.Selenium;

namespace HaibooksAutomationForWeb.Elements
{
   public partial class system_elements : Baseclass
    {
        public IWebElement selected_company_drop_down => driver.FindElement(By.CssSelector("div[class='filter-option-inner-inner'] span"));
       

        public IWebElement company_overview_company_name => driver.FindElement(By.Id("BasicInfo_CompanyName"));
        public IWebElement company_overview_business_type_id => driver.FindElement(By.Id("BasicInfo_BusinessTypeId"));

        public IWebElement company_overview_business_industry => driver.FindElement(By.Id("BusinessSectors"));
        public IWebElement company_overview_adress_building => driver.FindElement(By.Id("Address_Building"));
        public IWebElement company_overview_address_str => driver.FindElement(By.Id("Address_Street"));
        public IWebElement company_overview_address_town => driver.FindElement(By.Id("Address_CityOrTown"));
        public IWebElement company_overview_address_postcode => driver.FindElement(By.Id("Address_PostCode"));
        public IWebElement company_overview_address_country_code => driver.FindElement(By.Id("CountryCode"));
        public IWebElement company_overview_address_regions => driver.FindElement(By.Id("Address_Region"));
        public IWebElement company_overview_address_company_registration_no => driver.FindElement(By.Id("BasicInfo_CompanyRegistrationNumber"));
        public IWebElement company_overview_address_basicinfo => driver.FindElement(By.Id("BasicInfo_BusinessDetails"));

        public IWebElement company_overview_contact_person => driver.FindElement(By.Id("contactPerson"));
        public IWebElement company_overview_email => driver.FindElement(By.Id("email"));
        public IWebElement company_overview_phone => driver.FindElement(By.Id("phone"));
        public IWebElement company_overview_mobile => driver.FindElement(By.Id("mobile"));
        public IWebElement company_overview_website => driver.FindElement(By.Id("website"));
        public IWebElement company_overview_fax => driver.FindElement(By.Id("fax"));
        public IWebElement company_overview_profile_image => driver.FindElement(By.Id("profile_image"));
        public IWebElement company_overview_upload => driver.FindElement(By.XPath("//img[@src='/assets/img/upload-grey.svg']"));       

    }
}
