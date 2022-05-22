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

        //public IWebElement company_overview_leftmenu => driver.FindElement(By.XPath("//a[@class='nav-link active']//span[contains(text(),'Company Overview')]"));
        public IWebElement company_overview_leftmenu => driver.FindElement(By.CssSelector(".nav-item:nth-child(2) span"));
        
        public IWebElement accounting_dates_and_codes_leftmenu => driver.FindElement(By.XPath("//span[contains(.,'Accounting Dates and Codes')]"));
        public IWebElement vat_details_left_menu => driver.FindElement(By.XPath("//span[contains(.,'VAT Details')]"));
        public IWebElement people_left_menu => driver.FindElement(By.XPath("//span[normalize-space()='People']"));
        public IWebElement add_person_button => driver.FindElement(By.XPath("//a[normalize-space()='Add Person']"));

        //Add Person
        public IWebElement person_first_name=> driver.FindElement(By.XPath("//input[@id='firstName']"));
        public IWebElement person_last_name => driver.FindElement(By.XPath("//input[@id='lastName']"));
        public IWebElement person_position => driver.FindElement(By.XPath("//label[@id='positionDirectorLabel']"));
        public IWebElement person_number_of_shared => driver.FindElement(By.XPath("//input[@id='numberOfShares']"));

        
        
        
        


    }
}
