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

       
        public IWebElement prepare_account_from => driver.FindElement(By.XPath("//div[@id='companyStartDate']//input[@role='combobox']"));
        public IWebElement firstAccountingYearEndDate => driver.FindElement(By.XPath("//div[@id='firstAccountingYearEndDate']//input[@role='combobox']"));
        public IWebElement accountRefDate => driver.FindElement(By.XPath("//div[@id='accountRefDate']//input[@role='combobox']"));
        

    }
}
