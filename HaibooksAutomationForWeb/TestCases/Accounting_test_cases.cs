using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Diagnostics;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Firefox;
using  HaibooksAutomationForWeb.TestCases;
using HaibooksAutomationForWeb;
using HaibooksAutomationForWeb.MyHelper;
using HaibooksAutomationForWeb.Constant;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using System.Linq;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;
using System.Net;
using SoftAssert;
using FluentAssertions;
using NUnit.Allure.Attributes;
using Allure.Commons;
using NUnit.Allure.Core;

namespace HaibooksAutomationForWeb
{
    [TestClass]
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Accounting Test cases")]
    [AllureTag("Accounting Test Cases")]

    public class Accounting_test_cases : Baseclass
    {

        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("verify that user can Add Dividends successfully")]
        [Test, Order(1)]
        //Receipts >> verify that user can Add Dividends successfully       

        public void test_case_1_Add_Dividens_added_successfully()
        {
            _systemElements1.user_already_login();
            _systemElements1.redirect_to_menu_from_settings();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitformee.Until(driver => _systemElements1.acccounting_left_menu.Displayed);
            if (_systemElements1.acccounting_left_menu.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.acccounting_left_menu.Click();
            }
             ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.Dividends_left_side);
            waitformee.Until(driver => _systemElements1.Dividends_label.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));           

            _systemElements1.add_Dividend_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.profilt_available_label.Displayed);
            string txtProfitAvailable = _systemElements1.txtProfitAvailable.Text;
            double text_pofit_val=0;
            string  txtProfitAvailable_price = txtProfitAvailable.Trim('£');
          if(txtProfitAvailable_price.Contains("-"))
            {
                txtProfitAvailable_price = txtProfitAvailable_price.Trim('-');
                txtProfitAvailable_price = txtProfitAvailable_price.Trim(' ');
                txtProfitAvailable_price = txtProfitAvailable_price.Trim('£');
               // Console.WriteLine(txtProfitAvailable_price);
                double txtProfitAvailable_price_int = Convert.ToDouble(txtProfitAvailable_price);
                text_pofit_val = -txtProfitAvailable_price_int;
            }

            //Console.WriteLine(txtProfitAvailable);

            //Select shareholder

            String share_holder_value="";
            int index;
            SelectElement select_shareholder = new SelectElement(_systemElements1.shareholder_drop_down_select);
            IList<IWebElement> options = select_shareholder.Options;
            if(options.Count >= 1)
            {
                select_shareholder.SelectByIndex(0);
                share_holder_value = select_shareholder.Options.ElementAt(0).GetAttribute("data-content");              
                 index = share_holder_value.IndexOf('>');
                share_holder_value = share_holder_value.Remove(0, index + 1);
                index = share_holder_value.IndexOf('>');
                share_holder_value = share_holder_value.Remove(0, index + 1);
                //global_share_holder_value = share_holder_value;
               // Console.WriteLine(share_holder_value);
            }
            else if (options.Count <= 0)
            { 
                _systemElements1.cancel.Click();
                waitformee.Until(driver => _systemElements1.System_settings_left_menu.Displayed);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.System_settings_left_menu);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.people_left_menu);
                waitformee.Until(driver => _systemElements1.add_person_button.Displayed);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.add_person_button);
                waitformee.Until(driver => _systemElements1.person_first_name.Displayed);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _systemElements1.add_person();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _systemElements1.redirect_to_menu_from_settings();
                if (_systemElements1.acccounting_left_menu.GetAttribute("aria-expanded") == "false")
                {
                    _systemElements1.acccounting_left_menu.Click();
                }
             ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.Dividends_left_side);
                waitformee.Until(driver => _systemElements1.Dividends_label.Displayed);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _systemElements1.add_Dividend_button.Click();
                Thread.Sleep(TimeSpan.FromSeconds(4));
                waitformee.Until(driver => _systemElements1.profilt_available_label.Displayed);

                select_shareholder.SelectByIndex(0);
                share_holder_value = select_shareholder.Options.ElementAt(0).GetAttribute("data-content");
                index = share_holder_value.IndexOf('>');
                share_holder_value = share_holder_value.Remove(0, index + 1);
                index = share_holder_value.IndexOf('>');
                share_holder_value = share_holder_value.Remove(0, index + 1);
                //global_share_holder_value = share_holder_value;
               // Console.WriteLine(share_holder_value);
            }

            //Add Issue Date
            DateTime odate = DateTime.Today;
            var today_date_string = odate.ToString("dd/MM/yyyy");
            var today_date = today_date_string.Replace('-', '/');
            //global_issue_date_dividends = today_date;            
            //_systemElements1.issue_date_dividends.Clear();
            //_systemElements1.issue_date_dividends.SendKeys(today_date);


            if(text_pofit_val > 0)
            { 

            //Amount
            _systemElements1.Amount.Clear();
            _systemElements1.Amount.SendKeys(Constants.number_of_shares);
            string amount = _systemElements1.Amount.GetAttribute("value");
            //Console.WriteLine(amount);
            
            //Account
            string account_value = _systemElements1.Account.Text;
            //((IJavaScriptExecutor)driver).ExecuteScript("account_value.options[account_value.selectedIndex].text");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            String TitleName = js.ExecuteScript("return document.getElementById('ddBankAccount').options[document.getElementById('ddBankAccount').selectedIndex].text;").ToString();
            //Console.WriteLine(TitleName);
          
            //Document Number
            string document_number = _systemElements1.document_number.GetAttribute("value");
            //Console.WriteLine(document_number);

            //Description 
            MyHelperClass random_description = new MyHelperClass();
            var description_generate = random_description.template_message_body(20);
            _systemElements1.description_dividend.SendKeys(description_generate);
            var description = _systemElements1.description_dividend.GetAttribute("value");           
            // global_description = description;
            //Console.WriteLine(description);

            _systemElements1.Save_button_any.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //count all dividens
            string all_dividens_counts = _systemElements1.all_Dividends_count.Text;
            int all_divident_count = Convert.ToInt32(all_dividens_counts);

            bool display_page_size = _systemElements1.page_size_display();
            if (display_page_size == true)
            {
                _systemElements1.itmes_50_display_on_page.Click();
            }

            if (all_divident_count <=1)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _systemElements1.no_of_col_and_rows(Constants.all_divides_col, Constants.all_divides_row);
                int column_size = _systemElements1.global_col;
                int row_size = _systemElements1.global_row;                         
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _systemElements1.description_row.Click();              

            }

            else
            {
                driver.Navigate().Refresh();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _systemElements1.no_of_col_and_rows(Constants.all_divides_col, Constants.all_divides_row);
                int column_size = _systemElements1.global_col;
                int row_size = _systemElements1.global_row;

              //Finding description match and click on it
              for(int i=1; i <= row_size; i++)
                {
                 
                    string description_finding= "//div[@class='dx-datagrid-rowsview dx-datagrid-nowrap']/div/table/tbody//"+ "tr[" + i + "]/td[4]";
                    string description_after_saved = driver.FindElement(By.XPath(description_finding)).Text;                  
                 if (description == driver.FindElement(By.XPath(description_finding)).Text)
                    {                       
                        Thread.Sleep(TimeSpan.FromSeconds(4));
                        driver.FindElement(By.XPath(description_finding)).Click();
                        break;
                    }
                }
            }



            //Verification of data
            Thread.Sleep(TimeSpan.FromSeconds(2));
            string txt_today_date = "//span[contains(text()," + "'" + today_date + "')]";
           bool verify_today_date = driver.FindElement(By.XPath(txt_today_date)).Displayed;
          if(verify_today_date == false)
            {
                Console.WriteLine("Alert: Date is not saving");
            }

            //shareholder
            string txt_shareholder = "//span[contains(text()," + "'" + share_holder_value + "')]";
            bool verify_shareholder = driver.FindElement(By.XPath(txt_shareholder)).Displayed;
            if (verify_shareholder == false)
            {
                Console.WriteLine("Alert: Date is not saving");
            }


            //document number
            
            string txt_document_number = "//span[contains(text()," + "'" + document_number + "')]";
            bool verify_document_number = driver.FindElement(By.XPath(txt_document_number)).Displayed;
            if (verify_document_number == false)
            {
                Console.WriteLine("Alert: Date is not saving");
            }

            //total Amouunt
            string amount_set = "£" + amount + ".00";
            string txt_amount_set = "//span[contains(text()," + "'" + amount_set + "')]";
            bool verify__amount_set = driver.FindElement(By.XPath(txt_amount_set)).Displayed;
            if (verify__amount_set == false)
            {
                Console.WriteLine("Alert: Date is not saving");
            }
            }

            else
            {
                Console.WriteLine("Profit cannot be added because profit is in negative");
                _systemElements1.cancel.Click();
            }
        }



        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("verify that user can Add Journals successfully")]
        [Test, Order(2)]
        //Receipts >> verify that user can Add Journals successfully
        public void test_case_2_add_journals_with_VAT_inclusive()
        {
            _systemElements1.user_already_login();
            _systemElements1.redirect_to_menu_from_settings();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitformee.Until(driver => _systemElements1.acccounting_left_menu.Displayed);
            if (_systemElements1.acccounting_left_menu.GetAttribute("aria-expanded") == "false")
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.acccounting_left_menu);
               // _systemElements1.acccounting_left_menu.Click();
            }
             ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.journals_left_side);
            waitformee.Until(driver => _systemElements1.jounrals_label.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.Add_journal_button);
           // _systemElements1.Add_journal_button.Click();
            waitformee.Until(driver => _systemElements1.add_journal_label.Displayed);


            //Add Issue Date
            DateTime odate = DateTime.Today;
            var today_date_string = odate.ToString("dd/MM/yyyy");
            var today_date = today_date_string.Replace('-', '/');
            //global_issue_date_dividends = today_date;            
            //_systemElements1.issue_date_dividends.Clear();
            //_systemElements1.issue_date_dividends.SendKeys(today_date);



            //Document Number
            string document_number = _systemElements1.document_number_journal.GetAttribute("value");
            Console.WriteLine(document_number);

            //Reference 
            MyHelperClass random_description = new MyHelperClass();
            var description_generate = random_description.template_message_body(8);
            _systemElements1.reference_textarea.SendKeys(description_generate);
            var description = _systemElements1.reference_textarea.GetAttribute("value");
            Console.WriteLine(description);

            //Vat Inclusive
            SelectElement oSelect = new SelectElement(_systemElements1.VATTaxSettingDropDown);
            IList<IWebElement> elementCount = oSelect.Options;
            int iListSize = elementCount.Count;            
            String vat_inclusive = oSelect.Options.ElementAt(1).GetAttribute("data-content");
            if (vat_inclusive == Constants.vat_inclusive)
            {
                oSelect.SelectByIndex(1);
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

            _systemElements1.click_on_journals_first_drop_down.Click();
            string abc = _systemElements1.click_on_journals_first_drop_down.GetAttribute("data-content");           
            int index = abc.IndexOf("<");
            if (index > 0)
            {
                abc = abc.Substring(0, index);
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));


            //Add Item Description 1 
            MyHelperClass item_desc1 = new MyHelperClass();
            var item_description_1 = item_desc1.template_message_body(3);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.item_desription_1);
            //_systemElements1.item_desription_1.Click();
            _systemElements1.item_desription_1.Clear();
            _systemElements1.item_desription_1.SendKeys(item_description_1);
            var items_desc_1 = _systemElements1.item_desription_1.GetAttribute("value");
            Console.WriteLine(items_desc_1);

            //VAt Rate
            SelectElement vat = new SelectElement(_systemElements1.vat_rate_drop_down1);
            vat.SelectByText(Constants.vat_rate_20_revenue);

            //Credit side
            _systemElements1.credit_1.Click();
            _systemElements1.credit_1.Clear();
            Thread.Sleep(TimeSpan.FromSeconds(2));           
            _systemElements1.credit_1.SendKeys(Constants.credit);


            //Add for second row
        


            //Add Item Description 2
            MyHelperClass item_desc2 = new MyHelperClass();
            var item_description_2 = item_desc2.template_message_body(3);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.item_desription_2);
           // _systemElements1.item_desription_2.Click();           
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.reference_textarea.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.item_desription_2.Clear();
            _systemElements1.item_desription_2.SendKeys(item_description_2);
            var items_desc_2 = _systemElements1.item_desription_2.GetAttribute("value");
            Console.WriteLine(items_desc_2);

            
            _systemElements1.click_on_journals_second_drop_down.Click();
            string second_drop_down = _systemElements1.click_on_journals_second_drop_down.GetAttribute("data-content");
            int index2 = abc.IndexOf("<");
            if (index2 > 0)
            {
                second_drop_down = second_drop_down.Substring(0, index2);
            }
            


            //VAt Rate
            SelectElement vat2 = new SelectElement(_systemElements1.vat_rate_drop_down2);
            vat2.SelectByText(Constants.vat_rate_20_expenses);

            //Debit side
            _systemElements1.debit_2.Click();
            _systemElements1.debit_2.Clear();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.debit_2.SendKeys(Constants.debit);
            _systemElements1.debit_2.SendKeys(Keys.Tab);
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

    }
}

    
    
