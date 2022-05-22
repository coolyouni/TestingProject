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
        public IWebElement Add_receipt_button => driver.FindElement(By.XPath("//a[normalize-space()='Add Receipt']"));
        public IWebElement All_receipts_count => driver.FindElement(By.XPath("//*[@id='allReceiptsGridButton']/span[2]"));
        public IWebElement All_receipts_count_1 => driver.FindElement(By.XPath("//li[@class='nav-item']//a[@id='processingGridButton']/span[2]"));

       


    }

}
