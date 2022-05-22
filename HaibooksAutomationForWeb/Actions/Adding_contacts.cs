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

        public string global_full_name { get; set; }
        public string global_contact { get; set; }
        public string global_email_value_contact { get; set; }
        public string global_vat_generate_contact { get; set; }

        public void perform_adding_contacts(string module_name)

        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            waitformee.Until(driver => _systemElements1.Contact_information_expand_collapsed.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(1));
           
            if (_systemElements1.Contact_information_grid.GetAttribute("aria-expanded")=="false")
            {
                _systemElements1.Contact_information_expand_collapsed.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            //Adding business full name
            MyHelperClass business_name = new MyHelperClass();
            var business_full_name = business_name.template_message_body(20);
            _systemElements1.business_name_textbox.SendKeys(business_full_name);

            global_full_name = business_full_name;

            //Adding contact
            MyHelperClass contact_person = new MyHelperClass();
            var contact_person_added = contact_person.contact_person(20);
            _systemElements1.ContactPerson_textbox.SendKeys(contact_person_added);
            global_contact = contact_person_added;


            //Adding Email
            MyHelperClass c = new MyHelperClass();
            string email_value = c.GetRandomEmailvalue(Constants.firstname);
            Console.WriteLine("Email Value: " + email_value);
            _systemElements1.Email_textbox.SendKeys(email_value);

            global_email_value_contact = email_value;

            //Adding telehphone
            _systemElements1.Telephone_textbox.SendKeys(Constants.phone_no_without_code);         

            //Adding mobile
            _systemElements1.Mobile_textbox.SendKeys(Constants.mobile_no);           

            //Adding website
            _systemElements1.Website_textbox.SendKeys(homeURL);


            //Adding Fax
            _systemElements1.Fax_textbox.SendKeys(Constants.Fax_no);

            if (_systemElements1.adress_grid.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.adress_expand_collapsed.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

            //address Grid Data adding
            _systemElements1.Building_textbox.SendKeys(Constants.Buidling_adress);

            //adding street
            //address Grid Data adding
            _systemElements1.Street_textbox.SendKeys(Constants.street_no);

            _systemElements1.CityOrTown_textbox.SendKeys(Constants.city);
            _systemElements1.PostCode_textbox.SendKeys(Constants.post_code);

            //country adding
            SelectElement drpCountry = new SelectElement(_systemElements1.CountryCode_textbox);
            drpCountry.SelectByValue("GB");

            _systemElements1.region_textbox.SendKeys(Constants.region);

            if (_systemElements1.financial_details_grid.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.financial_details_collapsed.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            //Vat registration no
            MyHelperClass vat = new MyHelperClass();
            var vat_generate = Convert.ToString(vat.GetRandominvoicevalue(9));
            _systemElements1.vat_reg_no_textbox.SendKeys(vat_generate);
            global_vat_generate_contact = vat_generate;

            if (_systemElements1.Terms_details_grid.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.Terms_details_collapsed.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            //country adding
            SelectElement terms_drop_down = new SelectElement(_systemElements1.Terms_drop_down);
            terms_drop_down.SelectByValue("4");
        }


        public void perform_search_data(string data)
        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitformee.Until(driver => _systemElements1.searchbox.Displayed);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.searchbox);           
            searchbox.Clear();
            searchbox.SendKeys(data);
        }

        public void perform_click_on_data(string data,string col,string  row,int td,string link)
        {
            _systemElements1.no_of_col_and_rows(col, row);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;

            string first_rwo = row + "/tr[" + 1 + "]/td["+  td + "]"+link;               
            Thread.Sleep(TimeSpan.FromSeconds(4));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath(first_rwo)));
            //driver.FindElement(By.XPath(first_rwo)).Click();              
         }
    }
}
