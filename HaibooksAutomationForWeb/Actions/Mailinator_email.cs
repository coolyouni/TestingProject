using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.TestCases;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HaibooksAutomationForWeb.Elements
{
   public partial class system_elements: Baseclass
    {

        public void perform_searching(string email_value)
        {
            _systemElements1 = new system_elements(driver);
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            //search box displayed in mailinator
            try
            {
                waitformee.Until(driver => search_textbox.Displayed);
            }catch(Exception e) { }
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //enter email  in mailinator
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.search_textbox);
            //search_textbox.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('value','" + email_value + "')", _systemElements1.search_textbox);
            //search_textbox.SendKeys(email_value);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.Go_button);
            //Go_button.Click();
        }


    }
}
