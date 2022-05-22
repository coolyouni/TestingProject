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
        public IWebElement username => driver.FindElement(By.XPath("//a[contains(@href, \'#\')]"));
        public IWebElement My_profile => driver.FindElement(By.LinkText("My Profile"));
        public IWebElement Back_to_advisor_panel => driver.FindElement(By.XPath("//a[@title='Back to adviser panel']"));        
        public IWebElement My_profile_first_name => driver.FindElement(By.XPath("//input[@id='firstName']"));
        public IWebElement My_profile_last_name => driver.FindElement(By.XPath("//input[@id='lastName']"));
        public IWebElement My_profile_email => driver.FindElement(By.XPath("//input[@id='email']"));




    }


}
