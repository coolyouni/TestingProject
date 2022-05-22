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

        public IWebElement click_filter_business_menu => driver.FindElement(By.XPath("//div[@class='filter-option']"));
        public IWebElement create_new_business_link => driver.FindElement(By.XPath("//span[normalize-space()='New Business']"));

        public IWebElement business_name => driver.FindElement(By.Id("companyName"));
        public IWebElement prepareAccountsFrom_textbox => driver.FindElement(By.XPath("//div[@id='prepareAccountsFrom']//input[@role='combobox']"));
        public IWebElement accountsMadeUpTo_textbox => driver.FindElement(By.XPath("//div[@id='accountsMadeUpTo']//input[@role='combobox']"));
        public IWebElement industry => driver.FindElement(By.Id("BusinessSectors"));
        public IWebElement vat_registered_checkbox => driver.FindElement(By.XPath("//label[@for='vatRegistered']"));
        public IWebElement vat_registration_number => driver.FindElement(By.Id("vatRegistrationNumber"));
        
        public IWebElement building_number => driver.FindElement(By.Id("addressBuilding"));
        public IWebElement address_street => driver.FindElement(By.Id("addressStreet"));
        public IWebElement address_region => driver.FindElement(By.Id("addressRegion"));        
        public IWebElement postal_code => driver.FindElement(By.Id("addressPostCode"));
        public IWebElement country_code => driver.FindElement(By.Id("CountryCode"));

        public IWebElement address_city => driver.FindElement(By.Id("addressCity"));

       


    }
}
