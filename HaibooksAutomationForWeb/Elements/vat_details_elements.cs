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

       
        public IWebElement settings_vat_registered_checkbox => driver.FindElement(By.Id("vatRegister"));
        public IWebElement vat_effective_date => driver.FindElement(By.XPath("//*[@id='vatEffectiveDate']/div/input"));
        public IWebElement vat_effective_date_edit => driver.FindElement(By.XPath("//div[@id='vatEffectiveDate']//input[@role='combobox']"));
        public IWebElement vat_ok_prompt => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/button"));
        public IWebElement vat_registered_up_to => driver.FindElement(By.XPath("//div[@id='vatDeregistrationDate']//input[@role='combobox']"));
        public IWebElement vat_rate_label => driver.FindElement(By.XPath("//span[normalize-space()='VAT Rate']"));
        public IWebElement vat_total_label => driver.FindElement(By.XPath("//span[normalize-space()='VAT Total']"));
        public IWebElement display_vat_rate => driver.FindElement(By.XPath("//*[@id='bill-item-0']/div/div/div[4]"));
        public IWebElement display_vat_total => driver.FindElement(By.XPath("//*[@id='bill-item-0']/div/div/div[5]"));
        public IWebElement reclaim_vat => driver.FindElement(By.XPath("//div[@class='custom-control custom-checkbox']"));

        

    }
}
