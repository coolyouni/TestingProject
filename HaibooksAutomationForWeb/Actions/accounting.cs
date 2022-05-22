using System;
using System.Collections.Generic;
using System.Linq;
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
        public int no_of_items { get; set; }



        public void perform_showing_dividens_fields()
        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(5));          
            _systemElements1.add_Dividend_button.Click();
            try { 
                waitformee.Until(driver => _systemElements1.profilt_available_label.Displayed);
                waitformee.Until(driver => _systemElements1.txtProfitAvailable.Displayed);
                waitformee.Until(driver => _systemElements1.shareholder_label.Displayed);
                waitformee.Until(driver => _systemElements1.Amount.Displayed);
                waitformee.Until(driver => _systemElements1.account_label.Displayed);
                waitformee.Until(driver => _systemElements1.Account.Displayed);
                waitformee.Until(driver => _systemElements1.document_number.Displayed);
                waitformee.Until(driver => _systemElements1.description_dividend.Displayed);
               
            }catch(Exception e)
            {
                Console.WriteLine("Adding dividends form is missing some fields");
            }
            cancel.Click();
        }


        public void perform_no_of_drop_down(IWebElement e)
        {
            SelectElement oSelect = new SelectElement(e);
            IList<IWebElement> elementCount = oSelect.Options;
            int list_of_items = elementCount.Count;
            no_of_items = list_of_items;
        }


    }
}
