using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.Constant;
using HaibooksAutomationForWeb.MyHelper;
using HaibooksAutomationForWeb.TestCases;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HaibooksAutomationForWeb.Elements
{
   public partial class system_elements: Baseclass
    {
        public void alert_welcome_to_haibooks()
        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            List<IWebElement> list_for_element = new List<IWebElement>();
            list_for_element.AddRange((IEnumerable<IWebElement>)(By.XPath("//*[@id='intercom - container']/div/div/div/div/div[2]/span")));
            if (list_for_element.Count > 0)
            {
                driver.SwitchTo().Frame("intercom-tour-frame");
                Alert_intercom_tour_frame.Click();
            }
        }

        public void alert_quick_check_vat_save()
        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            List<IWebElement> list_for_element = new List<IWebElement>();
            list_for_element.AddRange(driver.FindElements(By.XPath("//button[@type='button'][normalize-space()='Save']")));        
            if (list_for_element.Count > 0)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.Save_button_any);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                // Save_button_any.Click();
            }
        }


        public int validation_invoice_number()
        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            List<IWebElement> list_for_element = new List<IWebElement>();
            list_for_element.AddRange(driver.FindElements(By.Id("invoice-document-number-validation")));            
           return list_for_element.Count;          
        } 
        

        public void terms_selection(string value, int term_days,string module)
        {
            SelectElement select_dropdown_value = new SelectElement(Terms_drop_down);
            select_dropdown_value.SelectByText(value);
            if(value=="Custom")
            {
                string term_days_value = Convert.ToString(term_days);
                if (module == Constants.invoice_creation)
                {
                    invoice_term_days.Click();
                    invoice_term_days.Clear();
                    invoice_term_days.SendKeys(term_days_value);
                }
                else if(module == Constants.bill_creation)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.bill_term_days);
                    //bill_term_days.Click();
                    bill_term_days.Clear();
                    bill_term_days.SendKeys(term_days_value);                 

                }              
            }
        }


      public  bool IsLinkWorking(string url)
        {
            _systemElements1 = new system_elements(driver); 
            HttpWebRequest request = null;


            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
            }
            catch{ }
            //You can set some parameters in the "request" object...
            request.AllowAutoRedirect = true;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("\r\nResponse Status Code is OK and tatusDescription is: { 0}      ", response.StatusDescription);
                  // Releases the resources of the response.
            response.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            { //TODO: Check for the right exception here
                return false;
            }
        }


    }
}
