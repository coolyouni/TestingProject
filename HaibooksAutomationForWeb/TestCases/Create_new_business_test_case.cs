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
using HaibooksAutomationForWeb.Elements;
using Assert = NUnit.Framework.Assert;
using System.Linq;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using OpenQA.Selenium.Chrome;
using System.IO;
using SolrNet.Utils;


namespace HaibooksAutomationForWeb
{

    [TestFixture]
    public class Create_new_business_test_case : Baseclass
    {
        

        [Test, Order(1)]
        public void test_case_1_verify_create_new_business_with_vat()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _systemElements1.redirect_to_menu_from_settings();
            waitformee.Until(driver => _systemElements1.dashboard_leftmenu.Displayed);
            _systemElements1.click_filter_business_menu.Click();
            // _systemElements1.perform_added_business();
            ////_systemElements1.click_filter_business_menu.Click();

            //bool business_name_match = _systemElements1.global_added_business_match;
            //if (business_name_match==false)
            //{
            // waitformee.Until(driver => _systemElements1.create_new_business_link.Displayed);
            // _systemElements1.create_new_business_link.Click();
            //    waitformee.Until(driver => _systemElements1.limited_liability_company_type.Displayed);

            ////Click on Limited Liability Company

            //Actions click_LLC = new Actions(driver);
            //click_LLC.MoveToElement(_systemElements1.limited_liability_company_type).Click().Build().Perform();

            ////Search company name
            //_systemElements1.search_external_companies.Click();
            //_systemElements1.search_external_companies.SendKeys(Constants.Company_Name_1);

            //waitformee.Until(PRED => _systemElements1.select_company_name_1.Displayed);
            //Actions compnay_name = new Actions(driver);
            //compnay_name.MoveToElement(_systemElements1.select_company_name_1).Click().Build().Perform();
            //waitformee.Until(PRED => _systemElements1.save_button.Displayed);
            //Thread.Sleep(TimeSpan.FromSeconds(1));
            //_systemElements1.save_button.Click();
            //}


            //else if(business_name_match == true)
            //{
            waitformee.Until(driver => _systemElements1.create_new_business_link.Displayed);
            _systemElements1.create_new_business_link.Click();
            waitformee.Until(driver => _systemElements1.uk_sole_trader_company_type.Displayed);

            Actions clicksole_trader = new Actions(driver);
            clicksole_trader.MoveToElement(_systemElements1.uk_sole_trader_company_type).Click().Build().Perform();

            waitformee.Until(driver => _systemElements1.business_name.Displayed);
            //Adding business name
            MyHelperClass business_name = new MyHelperClass();
            var business_full_name = business_name.template_message_body(20);
            _systemElements1.business_name.SendKeys(business_full_name);
           

            //Adding Prepare account from
            DateTime odate = DateTime.Today;
            odate = odate.AddYears(-20);
            var today_date_string = odate.ToString("dd/MM/yyyy");
            var today_date_in_yyyy_mm_dd_format = odate.ToString("yyyy/MM/dd");
            var today_date = today_date_string.Replace('-', '/');          
            _systemElements1.prepareAccountsFrom_textbox.Click();
            _systemElements1.prepareAccountsFrom_textbox.SendKeys(today_date);

            //Adding first account made up to
            _systemElements1.accountsMadeUpTo_textbox.Click();
            _systemElements1.accountsMadeUpTo_textbox.Clear();
            _systemElements1.accountsMadeUpTo_textbox.SendKeys(today_date);


            //Selecting industry

            SelectElement select_industry_type = new SelectElement(_systemElements1.industry);
            select_industry_type.SelectByText(Constants.industry_type);

            _systemElements1.vat_registered_checkbox.Click();
            waitformee.Until(driver => _systemElements1.vat_registration_number.Displayed);

            MyHelperClass vat_registration_number = new MyHelperClass();
            var vat_number = Convert.ToString(vat_registration_number.GetRandominvoicevalue(8));
            _systemElements1.vat_registration_number.SendKeys(vat_number);
            //Adding building number
            _systemElements1.building_number.Click();
            _systemElements1.building_number.Clear();
            _systemElements1.building_number.SendKeys(Constants.Buidling_adress);

            //adding street
            _systemElements1.address_street.SendKeys(Constants.street_no);

            //adding city
            _systemElements1.address_city.SendKeys(Constants.city);

            //Adding region
            _systemElements1.address_region.SendKeys(Constants.region);

            //Adding postalcode
            _systemElements1.postal_code.SendKeys(Constants.post_code);

            //Adding countrycode
            _systemElements1.country_code.SendKeys(Constants.post_code);


            SelectElement drpCountry = new SelectElement(_systemElements1.CountryCode_textbox);
            drpCountry.SelectByValue("PK");

            _systemElements1.save_button.Click();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            //verifying data               


            //verifying that added business name is showing or not
            //string xpath_for_business = "//div[@class='filter-option-inner-inner']//span[contains(text(),'" + business_full_name + "')]";
            //bool selected_busineess_showing = driver.FindElement(By.XPath(xpath_for_business)).Displayed;

            
            string selected_value = driver.FindElement(By.CssSelector("div[class='filter-option-inner-inner'] span")).Text;
           //string selected_value = driver.FindElement(By.XPath("//*[@id='select-mode']/optgroup[1]/option[1]")).GetAttribute("data-content");
            
            Console.WriteLine(selected_value);

            Thread.Sleep(TimeSpan.FromSeconds(4));
            if (homeURL == Constants.main_website)
            {

                if (selected_value != business_full_name)
                {
                    _systemElements1.click_filter_business_menu.Click();
                    SelectElement selected_value_of_drop_down = new SelectElement(_systemElements1.select_business_drop_down);
                    selected_value_of_drop_down.SelectByText(business_full_name);
                }
            }
            //Go to system Settings
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.System_settings_left_menu.Click();
            waitformee.Until(driver => _systemElements1.company_overview_leftmenu.Displayed);
            waitformee.Until(driver => _systemElements1.company_overview_company_name.Displayed);

            string company_name = _systemElements1.company_overview_company_name.GetAttribute("value");
            Assert.AreEqual(business_full_name, company_name);

            string business_type = _systemElements1.company_overview_business_type_id.GetAttribute("value");
            Assert.AreEqual("1", business_type);

            //industry verification
            string industry_showing = _systemElements1.company_overview_business_industry.GetAttribute("value");
            bool industry_type_value_equal = false;

            if (Constants.industry_type == industry_showing)
            {
                industry_type_value_equal = true;
            }
            else
            {
                Console.WriteLine("Alert: industry type mismatch");
            }

            string building_number = _systemElements1.company_overview_adress_building.GetAttribute("value");
            Assert.AreEqual(Constants.Buidling_adress, building_number);

            string streetn_no = _systemElements1.company_overview_address_str.GetAttribute("value");
            Assert.AreEqual(Constants.street_no, streetn_no);

            string city = _systemElements1.company_overview_address_town.GetAttribute("value");
            Assert.AreEqual(Constants.city, city);

            string postal_code = _systemElements1.company_overview_address_postcode.GetAttribute("value");
            Assert.AreEqual(Constants.post_code, postal_code);

            string country = _systemElements1.company_overview_address_country_code.GetAttribute("value");
            bool country_selected = false;
            if ("PK" == country)
            {
                country_selected = true;
            }
            else
            {
                Console.WriteLine("Alert: Country is not selected");
            }


            string region = _systemElements1.company_overview_address_regions.GetAttribute("value");
            Assert.AreEqual(Constants.region, region);

            //Accounting dates and code
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.accounting_dates_and_codes_leftmenu.Click();

            waitformee.Until(driver => _systemElements1.prepare_account_from.Displayed);
           Global.prepare_account_from = _systemElements1.prepare_account_from.GetAttribute("value");
            Assert.AreEqual(today_date, Global.prepare_account_from);

            string first_accounting_made_up = _systemElements1.firstAccountingYearEndDate.GetAttribute("value");
            Assert.AreEqual(today_date, first_accounting_made_up);

            string account_reference_date = _systemElements1.accountRefDate.GetAttribute("value");
            Assert.AreEqual(today_date, account_reference_date);


            ////////////////Verifying VAT Details
            _systemElements1.vat_details_left_menu.Click();
            waitformee.Until(driver => _systemElements1.settings_vat_registered_checkbox.Displayed);
            string vat_registered_checkbox_true = _systemElements1.settings_vat_registered_checkbox.GetAttribute("aria-checked");
            if (vat_registered_checkbox_true == "false")
            {
                Console.WriteLine("Alert: Vat Registered checkbox is not checked");
            }
            //Vat registration no
            string vat_registration_no = _systemElements1.vat_registration_number.GetAttribute("value");
            Assert.AreEqual(vat_number, vat_registration_no);

            //Vat Effective Date
            string vat_effect_date = _systemElements1.vat_effective_date.GetAttribute("value");

            Assert.AreEqual(today_date_in_yyyy_mm_dd_format, vat_effect_date);

            _systemElements1.redirect_to_menu_from_settings();         

            

        }




        [Test, Order(2)]
        public void test_case_2_verify_vat_showing_in_document_for_uncheck_VAT_business()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitformee.Until(driver => _systemElements1.dashboard_leftmenu.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.System_settings_left_menu.Click();
            waitformee.Until(driver => _systemElements1.company_overview_leftmenu.Displayed);
            waitformee.Until(driver => _systemElements1.company_overview_company_name.Displayed);

            _systemElements1.accounting_dates_and_codes_leftmenu.Click();

            waitformee.Until(driver => _systemElements1.prepare_account_from.Displayed);

            //Verifying prepare account from date is less than from today date
            string prepare_account_date = _systemElements1.prepare_account_from.GetAttribute("value");
            string year_finding = prepare_account_date.Remove(0, 6);
            Console.WriteLine(year_finding);
            int year_findings = Convert.ToInt32(year_finding);
            DateTime myDateTime = DateTime.Now;
            string year = myDateTime.Year.ToString();
            int current_year = Convert.ToInt32(year);

            if (year_findings > current_year - 10)
            {
                //Adding Prepare account from
                DateTime odate = DateTime.Today;
                odate = odate.AddYears(-20);
                var today_date_minus_20 = odate.ToString("dd/MM/yyyy");
                var today_date_in_yyyy_mm_dd_format = odate.ToString("yyyy/MM/dd");
                var today_date_minus = today_date_minus_20.Replace('-', '/');
                Console.WriteLine(today_date_minus);
                _systemElements1.prepare_account_from.Click();
                _systemElements1.prepare_account_from.Clear();
                _systemElements1.prepare_account_from.SendKeys(today_date_minus);
                _systemElements1.save_button.Click();
            }



            ////////////////Verifying VAT Details
            string vat_registered_upto;
            //DateTime odates = DateTime.Today;           
            //var today_date_now = odates.ToString("dd/MM/yyyy");
            //var today_date_plus = today_date_now.Replace('-', '/');            
            //var reclaim_vat_date = today_date_now.Replace('-', '/');
            var today_date_plus = "";
            var reclaim_vat_date = "";

            _systemElements1.vat_details_left_menu.Click();
            waitformee.Until(driver => _systemElements1.settings_vat_registered_checkbox.Displayed);
            string vat_registered_checkbox_true = _systemElements1.settings_vat_registered_checkbox.GetAttribute("aria-checked");
            //if (vat_registered_checkbox_true == "false")
            //{
            //    _systemElements1.settings_vat_registered_checkbox.Click();
            //    MyHelperClass vat = new MyHelperClass();
            //    var vat_generate = Convert.ToString(vat.GetRandominvoicevalue(9));
            //    Thread.Sleep(TimeSpan.FromSeconds(2));
            //    _systemElements1.vat_registration_number.Clear();
            //    _systemElements1.vat_registration_number.SendKeys(vat_generate);
            //    Thread.Sleep(TimeSpan.FromSeconds(2));
            //    try
            //    {
            //        // _systemElements1.vat_effective_date_edit.Click();
            //        _systemElements1.vat_effective_date_edit.Clear();
            //        Thread.Sleep(TimeSpan.FromSeconds(2));
            //        DateTime odate = DateTime.Today;
            //        odate = odate.AddYears(-20);
            //        var today_date_minus_20 = odate.ToString("dd/MM/yyyy");
            //        var today_date_minus = today_date_minus_20.Replace('-', '/');
            //        Thread.Sleep(TimeSpan.FromSeconds(2));
            //        try
            //        {
            //            _systemElements1.vat_ok_prompt.Click();
            //        }
            //        catch (Exception)
            //        { }
            //        _systemElements1.vat_effective_date_edit.SendKeys(today_date_minus);
            //        _systemElements1.save_button.Click();
            //    }

            //    catch(Exception e)
            //    {
            //       // _systemElements1.vat_effective_date_edit.Click();
            //        _systemElements1.vat_effective_date_edit.Clear();
            //        Thread.Sleep(TimeSpan.FromSeconds(2));
            //        DateTime odate = DateTime.Today;
            //        odate = odate.AddYears(-20);
            //        var today_date_minus_20 = odate.ToString("dd/MM/yyyy");
            //        var today_date_minus = today_date_minus_20.Replace('-', '/');
            //        Thread.Sleep(TimeSpan.FromSeconds(2));
            //        try{
            //            _systemElements1.vat_ok_prompt.Click();
            //        }catch(Exception)
            //        { }
            //        _systemElements1.vat_effective_date_edit.SendKeys(today_date_minus);                   
            //        _systemElements1.save_button.Click();
            //    }


            //    ////Vat registration no
            //    //string vat_registration_no = _systemElements1.vat_registration_number.GetAttribute("value");
            //    ////Vat Effective Date
            //    //string vat_effect_date = _systemElements1.vat_effective_date.GetAttribute("value");
            //}

            if (vat_registered_checkbox_true == "true")
            {
                _systemElements1.settings_vat_registered_checkbox.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                vat_registered_upto = _systemElements1.vat_registered_up_to.GetAttribute("value");
                DateTime tempDate = Convert.ToDateTime(vat_registered_upto);
                tempDate = tempDate.AddDays(3);                
                var new_date_for_checking = tempDate.ToString("dd/MM/yyyy");
                today_date_plus = new_date_for_checking.Replace('-', '/');

                DateTime tempDate_for_recliam_vat = Convert.ToDateTime(vat_registered_upto);
                tempDate_for_recliam_vat = tempDate_for_recliam_vat.AddDays(-3);
                var new_date_for_reclaim = tempDate_for_recliam_vat.ToString("dd/MM/yyyy");
                reclaim_vat_date = new_date_for_checking.Replace('-', '/');
                _systemElements1.save_button.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _systemElements1.alert_quick_check_vat_save();
            }

            _systemElements1.redirect_to_menu_from_settings();

            {        //Verifying VAT is in Document
                waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _systemElements1.create_new_left_side.Click();
                waitformee.Until(driver => _systemElements1.create_new_invoice_dashboard.Displayed);
                _systemElements1.create_new_invoice_dashboard.Click();
                waitformee.Until(driver => _systemElements1.select_contact.Displayed);

                Thread.Sleep(TimeSpan.FromSeconds(2));
                //Verifying VAT RATE is diplaying
                string display_vat_showing = _systemElements1.display_vat_rate.GetCssValue("display");
                Console.WriteLine("display"+display_vat_showing);
                if (display_vat_showing == "inline-block")
                {
                    Console.WriteLine("Displaying VAT RATE DROP Down for Invoice document");
                }
                else
                {
                    Assert.Fail("Not Displaying VAT RATE DROP Down for Invoice document");
                }


                //Verifying VAT Total is displaying
                string display_vat_total = _systemElements1.display_vat_total.GetCssValue("display");
                if (display_vat_total == "inline-block")
                {
                    Console.WriteLine("Displaying VAT Total for Invoice document");
                }
                else
                {
                    Console.WriteLine("Not Displaying VAT Total for Invoice document");
                }


                string id_for_invoice = "bill-item-0-vatRates";
                _systemElements1.finding_VAT_drop_down(id_for_invoice);
                bool VAT_drop_down_showing = _systemElements1.global_vat_is_shoiwng;
                if (VAT_drop_down_showing == true)
                {
                    Console.WriteLine("Vat Drop down is showing");
                }
                else
                {
                    Assert.Fail("VAT Drop down is not showing");
                }
                Thread.Sleep(TimeSpan.FromSeconds(2));

                //  //Verifying vat total is showing
                //  string vat_total_invoice_xpath = "//*[@id='bill-item-0']/div/div/div[4]";
                //string abc=  driver.FindElement(By.XPath(vat_total_invoice_xpath)).GetAttribute("style");
                //  Console.WriteLine("abc   " + abc);
                //  _systemElements1.finding_VAT_total(vat_total_invoice_xpath);
                //  bool vat_total_value = _systemElements1.global_vat_is_shoiwng;
                //  if (vat_total_value == true)
                //  {
                //      Console.WriteLine("Test case Pass: Vat total is showing");
                //  }
                //  else
                //  {
                //      Assert.Fail("Test case Pass: VAT Total is not showing");
                //  }


                //Verifying that VAt total is not showing            
                waitformee.Until(driver => _systemElements1.issue_date.Displayed);
                waitformee.Until(ExpectedConditions.ElementToBeClickable(_systemElements1.issue_date));
                _systemElements1.issue_date.Clear();
                waitformee.Until(ExpectedConditions.ElementToBeClickable(_systemElements1.issue_date));
                _systemElements1.issue_date.Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                waitformee.Until(ExpectedConditions.ElementToBeClickable(_systemElements1.issue_date));
                _systemElements1.issue_date.SendKeys(today_date_plus);
                _systemElements1.issue_date.SendKeys(Keys.Tab);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                bool vat_rate_showing = _systemElements1.Vat_rate_label_showing();

                string display_vat_hiding = _systemElements1.display_vat_rate.GetCssValue("display");
                Console.WriteLine("display" + display_vat_hiding);
                if (display_vat_hiding == "none")
                {
                    Console.WriteLine("Test case pass: VAT Rate drop down is hide for Invoice document");
                }
                else
                {
                    Assert.Fail("Test case fail: VAT DROP Down is still showing for Invoice document");
                }



                //Verifying VAT Total is Hiding
                string hide_vat_total = _systemElements1.display_vat_total.GetCssValue("display");
                if (hide_vat_total == "none")
                {
                    Console.WriteLine("Test case pass: VAT Total  is Hide for Invoice document");
                }
                else
                {
                    Assert.Fail("Test case fail: VAT total is still showing for Invoice document");
                }

            }

            {

                //Checking document for Bills

                //Verifying VAT is in Document
                waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _systemElements1.create_new_left_side.Click();
                waitformee.Until(driver => _systemElements1.create_new_bill_dashboard.Displayed);
                _systemElements1.create_new_bill_dashboard.Click();
                waitformee.Until(driver => _systemElements1.select_contact.Displayed);
                //Verifying VAT RATE is diplaying
                string display_vat_showing = _systemElements1.display_vat_rate.GetAttribute("display");
                if (display_vat_showing == "inline-block")
                {
                    Console.WriteLine("Displaying VAT RATE DROP Down for Bill document");
                }
                else
                {
                    Console.WriteLine("Not Displaying VAT RATE DROP Down for Bill document");
                }


                //Verifying VAT Total is displaying
                string display_vat_total = _systemElements1.display_vat_total.GetAttribute("display");
                if (display_vat_total == null)
                {
                    Console.WriteLine("Displaying VAT Total for Bill document");
                }
                else
                {
                    Console.WriteLine("Not Displaying VAT Total for Bill document");
                }


                string id_for_invoice = "bill-item-0-vatRates";
                _systemElements1.finding_VAT_drop_down(id_for_invoice);
                bool VAT_drop_down_showing = _systemElements1.global_vat_is_shoiwng;
                if (VAT_drop_down_showing == true)
                {
                    Console.WriteLine("Vat Drop down is showing for Bill document");
                }
                else
                {
                    Assert.Fail("VAT Drop down is not showing for Bill document");
                }
                Thread.Sleep(TimeSpan.FromSeconds(2));


                //Verifying that VAt total is not showing            
                waitformee.Until(driver => _systemElements1.issue_date.Displayed);
                waitformee.Until(ExpectedConditions.ElementToBeClickable(_systemElements1.issue_date));
                _systemElements1.issue_date.Clear();
                waitformee.Until(ExpectedConditions.ElementToBeClickable(_systemElements1.issue_date));
                _systemElements1.issue_date.Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                waitformee.Until(ExpectedConditions.ElementToBeClickable(_systemElements1.issue_date));
                _systemElements1.issue_date.SendKeys(today_date_plus);
                _systemElements1.issue_date.SendKeys(Keys.Tab);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                bool vat_rate_showing = _systemElements1.Vat_rate_label_showing();

                string display_vat_hiding = _systemElements1.display_vat_rate.GetCssValue("display");
                if (display_vat_hiding == "none")
                {
                    Console.WriteLine("Test case pass: VAT Rate drop down is hide for Bill document");
                }
                else
                {
                    Assert.Fail("Test case fail: VAT DROP Down is still showing for Bill document");
                }

                //Verifying VAT Total is Hiding
                string hide_vat_total = _systemElements1.display_vat_total.GetCssValue("display");
                if (hide_vat_total == "none")
                {
                    Console.WriteLine("Test case pass: VAT Total  is Hide for Bill document");
                }
                else
                {
                    Assert.Fail("Test case fail: VAT total is still showing for Bill document");
                }
            }




            //Checking document for Expenses

        {   //Verifying VAT is in Document
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.create_new_left_side.Click();
            waitformee.Until(driver => _systemElements1.create_new_expenses_dashboard.Displayed);
            _systemElements1.create_new_expenses_dashboard.Click();
            waitformee.Until(driver => _systemElements1.select_contact.Displayed);
            //Verifying VAT RATE is diplaying
            string display_vat_showing = _systemElements1.display_vat_rate.GetAttribute("display");
            if (display_vat_showing == null)
            {
                Console.WriteLine("Displaying VAT RATE DROP Down for Expense document");
            }
            else
            {
                Console.WriteLine("Not Displaying VAT RATE DROP Down for Expense document");
            }


            //Verifying VAT Total is displaying
            string display_vat_total = _systemElements1.display_vat_total.GetAttribute("display");
            if (display_vat_total == null)
            {
                Console.WriteLine("Displaying VAT Total");
            }
            else
            {
                Console.WriteLine("Not Displaying VAT Total");
            }


            string id_for_invoice = "bill-item-0-vatRates";
            _systemElements1.finding_VAT_drop_down(id_for_invoice);
            bool VAT_drop_down_showing = _systemElements1.global_vat_is_shoiwng;
            if (VAT_drop_down_showing == true)
            {
                Console.WriteLine("Vat Drop down is showing for Expense document");
            }
            else
            {
                Assert.Fail("VAT Drop down is not showing for Expense document");
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));


            //Verifying that VAt total is not showing            
            waitformee.Until(driver => _systemElements1.issue_date.Displayed);
                waitformee.Until(ExpectedConditions.ElementToBeClickable(_systemElements1.issue_date));
                _systemElements1.issue_date.Clear();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                waitformee.Until(ExpectedConditions.ElementToBeClickable(_systemElements1.issue_date));
                _systemElements1.issue_date.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
                waitformee.Until(ExpectedConditions.ElementToBeClickable(_systemElements1.issue_date));
                _systemElements1.issue_date.SendKeys(today_date_plus);
            _systemElements1.issue_date.SendKeys(Keys.Tab);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            bool vat_rate_showing = _systemElements1.Vat_rate_label_showing();

            string display_vat_hiding = _systemElements1.display_vat_rate.GetCssValue("display");
            if (display_vat_hiding == "none")
            {
                Console.WriteLine("Test case pass: VAT Rate drop down is hide for Expense document");
            }
            else
            {
                Assert.Fail("Test case fail: VAT DROP Down is still showing for Expense document");
            }

            //Verifying VAT Total is Hiding
            string hide_vat_total = _systemElements1.display_vat_total.GetCssValue("display");
            if (hide_vat_total == "none")
            {
                Console.WriteLine("Test case pass: VAT Total  is Hide for Expense document");
            }
            else
            {
                Assert.Fail("Test case fail: VAT total is still showing for Expense document");
            }
        }         

        }






        [Test, Order(3)]
        public void test_case_3_verify_vat_showing_in_document_for_registered_vat_business()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitformee.Until(driver => _systemElements1.dashboard_leftmenu.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.System_settings_left_menu.Click();
            waitformee.Until(driver => _systemElements1.company_overview_leftmenu.Displayed);
            waitformee.Until(driver => _systemElements1.company_overview_company_name.Displayed);

            _systemElements1.accounting_dates_and_codes_leftmenu.Click();

            waitformee.Until(driver => _systemElements1.prepare_account_from.Displayed);

            //Verifying prepare account from date is less than from today date
            string prepare_account_date = _systemElements1.prepare_account_from.GetAttribute("value");
            string year_finding = prepare_account_date.Remove(0, 6);
            Console.WriteLine(year_finding);
            int year_findings = Convert.ToInt32(year_finding);
            DateTime myDateTime = DateTime.Now;
            string year = myDateTime.Year.ToString();
            int current_year = Convert.ToInt32(year);

            if (year_findings > current_year - 10)
            {
                //Adding Prepare account from
                DateTime odate = DateTime.Today;
                odate = odate.AddYears(-20);
                var today_date_minus_20 = odate.ToString("dd/MM/yyyy");
                var today_date_in_yyyy_mm_dd_format = odate.ToString("yyyy/MM/dd");
                var today_date_minus = today_date_minus_20.Replace('-', '/');
                Console.WriteLine(today_date_minus);
                _systemElements1.prepare_account_from.Click();
                _systemElements1.prepare_account_from.Clear();
                _systemElements1.prepare_account_from.SendKeys(today_date_minus);
                _systemElements1.save_button.Click();
            }



            ////////////////Verifying VAT Details
            string vat_registered_upto;
            DateTime odates = DateTime.Today;
            var today_date_now = odates.ToString("dd/MM/yyyy");
            var today_date_plus = today_date_now.Replace('-', '/');
            var reclaim_vat_date = today_date_now.Replace('-', '/');
            //var today_date_plus = "";
            //var reclaim_vat_date = "";

            _systemElements1.vat_details_left_menu.Click();
            waitformee.Until(driver => _systemElements1.settings_vat_registered_checkbox.Displayed);
            string vat_registered_checkbox_true = _systemElements1.settings_vat_registered_checkbox.GetAttribute("aria-checked");
            if (vat_registered_checkbox_true == "false")
            {
                _systemElements1.settings_vat_registered_checkbox.Click();               
                _systemElements1.save_button.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }     
              
            _systemElements1.redirect_to_menu_from_settings();

            {   //Verifying VAT is in Document
                waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _systemElements1.create_new_left_side.Click();
                waitformee.Until(driver => _systemElements1.create_new_invoice_dashboard.Displayed);
                _systemElements1.create_new_invoice_dashboard.Click();
                waitformee.Until(driver => _systemElements1.select_contact.Displayed);

                Thread.Sleep(TimeSpan.FromSeconds(3));
                //Verifying VAT RATE is diplaying
                string display_vat_showing = _systemElements1.display_vat_rate.GetCssValue("display");
                if (display_vat_showing == "inline-block")
                {
                    Console.WriteLine("Displaying VAT RATE DROP Down for invoice document");
                }
                else
                {
                    Console.WriteLine("Not Displaying VAT RATE DROP Down for invoice document");
                }


                //Verifying VAT Total is displaying
                string display_vat_total = _systemElements1.display_vat_total.GetCssValue("display");
                if (display_vat_total == "inline-block")
                {
                    Console.WriteLine("Displaying VAT Total for invoice document");
                }
                else
                {
                    Console.WriteLine("Not Displaying VAT Total for invoice document");
                }


                string id_for_invoice = "bill-item-0-vatRates";
                _systemElements1.finding_VAT_drop_down(id_for_invoice);
                bool VAT_drop_down_showing = _systemElements1.global_vat_is_shoiwng;
                if (VAT_drop_down_showing == true)
                {
                    Console.WriteLine("Vat Drop down is showing for invoice document");
                }
                else
                {
                    Assert.Fail("VAT Drop down is not showing for invoice document");
                }
                Thread.Sleep(TimeSpan.FromSeconds(2));

                

                //Verifying that VAt total is showing  after date change          
                waitformee.Until(driver => _systemElements1.issue_date.Displayed);
                _systemElements1.issue_date.Clear();
                _systemElements1.issue_date.Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                _systemElements1.issue_date.SendKeys(today_date_plus);
                _systemElements1.issue_date.SendKeys(Keys.Tab);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                bool vat_rate_showing = _systemElements1.Vat_rate_label_showing();

                string display_vat_hiding = _systemElements1.display_vat_rate.GetCssValue("display");
                Console.WriteLine("display" + display_vat_hiding);
                if (display_vat_hiding == "inline-block")
                {
                    Console.WriteLine("Test case pass: VAT Rate drop down is hide for invoice document");
                }
                else
                {
                    Assert.Fail("Test case fail: VAT DROP Down is still showing for invoice document");
                }



                //Verifying VAT Total is Hiding
                string hide_vat_total = _systemElements1.display_vat_total.GetCssValue("display");
                if (hide_vat_total == "inline-block")
                {
                    Console.WriteLine("Test case pass: VAT Total  is Hide for invoice document");
                }
                else
                {
                    Assert.Fail("Test case fail: VAT total is still showing for invoice document");
                }

            }

            {

                //Checking document for Bills

                //Verifying VAT is in Document
                waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _systemElements1.create_new_left_side.Click();
                waitformee.Until(driver => _systemElements1.create_new_bill_dashboard.Displayed);
                _systemElements1.create_new_bill_dashboard.Click();
                waitformee.Until(driver => _systemElements1.select_contact.Displayed);
                //Verifying VAT RATE is diplaying
                string display_vat_showing = _systemElements1.display_vat_rate.GetAttribute("display");
                if (display_vat_showing == "inline-block")
                {
                    Console.WriteLine("Displaying VAT RATE DROP Down for Bill document");
                }
                else
                {
                    Console.WriteLine("Not Displaying VAT RATE DROP Down for Bill document");
                }


                //Verifying VAT Total is displaying
                string display_vat_total = _systemElements1.display_vat_total.GetAttribute("display");
                if (display_vat_total == "inline-block")
                {
                    Console.WriteLine("Displaying VAT Total for Bill document");
                }
                else
                {
                    Console.WriteLine("Not Displaying VAT Total for Bill document");
                }


                string id_for_invoice = "bill-item-0-vatRates";
                _systemElements1.finding_VAT_drop_down(id_for_invoice);
                bool VAT_drop_down_showing = _systemElements1.global_vat_is_shoiwng;
                if (VAT_drop_down_showing == true)
                {
                    Console.WriteLine("Vat Drop down is showing for Bill document");
                }
                else
                {
                    Assert.Fail("VAT Drop down is not showing for Bill document");
                }
                Thread.Sleep(TimeSpan.FromSeconds(2));


                //Verifying that VAt total is not showing            
                waitformee.Until(driver => _systemElements1.issue_date.Displayed);
                _systemElements1.issue_date.Clear();
                _systemElements1.issue_date.Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                waitformee.Until(ExpectedConditions.ElementToBeClickable(_systemElements1.issue_date));
                _systemElements1.issue_date.SendKeys(today_date_plus);
                _systemElements1.issue_date.SendKeys(Keys.Tab);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                bool vat_rate_showing = _systemElements1.Vat_rate_label_showing();

                string display_vat_hiding = _systemElements1.display_vat_rate.GetCssValue("display");
                if (display_vat_hiding == "inline-block")
                {
                    Console.WriteLine("Test case pass: VAT Rate drop down is hide for Bill document");
                }
                else
                {
                    Assert.Fail("Test case fail: VAT DROP Down is still showing for Bill document");
                }

                //Verifying VAT Total is Hiding
                string hide_vat_total = _systemElements1.display_vat_total.GetCssValue("display");
                if (hide_vat_total == "inline-block")
                {
                    Console.WriteLine("Test case pass: VAT Total  is Hide for Bill document");
                }
                else
                {
                    Assert.Fail("Test case fail: VAT total is still showing for Bill document");
                }
            }




            //Checking document for Expenses

            {   //Verifying VAT is in Document
                waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _systemElements1.create_new_left_side.Click();
                waitformee.Until(driver => _systemElements1.create_new_expenses_dashboard.Displayed);
                _systemElements1.create_new_expenses_dashboard.Click();
                waitformee.Until(driver => _systemElements1.select_contact.Displayed);
                //Verifying VAT RATE is diplaying
                string display_vat_showing = _systemElements1.display_vat_rate.GetAttribute("display");
                if (display_vat_showing == "inline-block")
                {
                    Console.WriteLine("Displaying VAT RATE DROP Down for Expense document");
                }
                else
                {
                    Console.WriteLine("Not Displaying VAT RATE DROP Down for Expense document");
                }


                //Verifying VAT Total is displaying
                string display_vat_total = _systemElements1.display_vat_total.GetAttribute("display");
                if (display_vat_total == "inline-block")
                {
                    Console.WriteLine("Displaying VAT Total for Expense document");
                }
                else
                {
                    Console.WriteLine("Not Displaying VAT Total for Expense document");
                }


                string id_for_invoice = "bill-item-0-vatRates";
                _systemElements1.finding_VAT_drop_down(id_for_invoice);
                bool VAT_drop_down_showing = _systemElements1.global_vat_is_shoiwng;
                if (VAT_drop_down_showing == true)
                {
                    Console.WriteLine("Vat Drop down is showing for Expense document");
                }
                else
                {
                    Assert.Fail("VAT Drop down is not showing for Expense document");
                }
                Thread.Sleep(TimeSpan.FromSeconds(2));


                //Verifying that VAt total is not showing            
                waitformee.Until(driver => _systemElements1.issue_date.Displayed);
                _systemElements1.issue_date.Clear();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                _systemElements1.issue_date.Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                _systemElements1.issue_date.SendKeys(today_date_plus);
                _systemElements1.issue_date.SendKeys(Keys.Tab);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                bool vat_rate_showing = _systemElements1.Vat_rate_label_showing();

                string display_vat_hiding = _systemElements1.display_vat_rate.GetCssValue("display");
                if (display_vat_hiding == "inline-block")
                {
                    Console.WriteLine("Test case pass: VAT Rate drop down is hide for Expense document");
                }
                else
                {
                    Assert.Fail("Test case fail: VAT DROP Down is still showing for Expense document");
                }

                //Verifying VAT Total is Hiding
                string hide_vat_total = _systemElements1.display_vat_total.GetCssValue("display");
                if (hide_vat_total == "inline-block")
                {
                    Console.WriteLine("Test case pass: VAT Total  is Hide for Expense document");
                }
                else
                {
                    Assert.Fail("Test case fail: VAT total is still showing for Expense document");
                }
            }
        }





        }
}


    


    
    
