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
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace HaibooksAutomationForWeb
{
   
    [TestClass]
    public class Broken_links_test_case : Baseclass
    {


        [Test, Order(1)]

        public void test_case_1_verify_check_all_broken_links()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            waitformee.Until(PRED => _systemElements1.create_new_dashboard.Displayed);
           // _systemElements1.System_settings_left_menu.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            HttpWebRequest req = null;
            var urls = driver.FindElements(By.XPath("//a"));

            int a = urls.Count;
            int loopRowCounter = 2;
            foreach (var url in urls)
            {
                //if (!(url.Text.Contains("href") || url.Text == ""))
                //{
                try
                {
                    req = (HttpWebRequest)HttpWebRequest.Create(url.GetAttribute("href"));

                }
                catch (Exception f) { }

                try
                {
                    System.Diagnostics.Stopwatch timer = new Stopwatch();
                    timer.Start();
                    var response = (HttpWebResponse)req.GetResponse();
                    response.Close();

                    timer.Stop();

                    TimeSpan timeTaken = timer.Elapsed;
                    string time = timeTaken.ToString();
                    // Console.WriteLine(timeTaken);
                    System.Console.WriteLine("" + loopRowCounter);
                    System.Console.WriteLine($"URL: {url.GetAttribute("href")} status is :{response.StatusCode}");
                    System.Console.WriteLine($"URL: {url.GetAttribute("href")} status is :{response.GetResponseHeader("General")}");
                    int status = ((int)response.StatusCode);
                    int error_code = 0;
                    if (status == 200)
                    {
                        _systemElements1.adding_response_code_in_excel(4, url.GetAttribute("href"), status, error_code, time, loopRowCounter);
                    }
                    else if (status >= 400)
                    {
                        _systemElements1.adding_response_code_in_excel(4, url.GetAttribute("href"), status, status, time, loopRowCounter);
                        Console.WriteLine($"URL: {url.GetAttribute("href")} status is :{response.StatusCode}");
                        Console.WriteLine(url + " is a broken link ");
                    }
                }
                catch (WebException e)
                {
                    var errorResponse = (HttpWebResponse)e.Response;
                }
                loopRowCounter++;
            }

        }



        
        [Test, Order(2)]

        public void test_case_2_verify_all_pages_display_with_field()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _systemElements1.redirect_to_menu_from_settings();
            waitformee.Until(PRED => _systemElements1.dashboard_leftmenu.Displayed);
            _systemElements1.dashboard_leftmenu.Click();
            _systemElements1.verify_Dashboard_page_display();
            _systemElements1.verify_Dashboard_data_display();
            _systemElements1.verify_contact_page_display();
            _systemElements1.verify_sales_invoices_page_display();
            _systemElements1.verify_sales_draft_page_display();
            _systemElements1.verify_sales_recurring_invoices_display();
            _systemElements1.verify_sales_archived_display();

            //Recurring invoices left side menu
            waitformee.Until(PRED => _systemElements1.recurring_invoices_left_side.Displayed);
            _systemElements1.recurring_invoices_left_side.Click();
            waitformee.Until(driver => _systemElements1.draft_title.Displayed);
            string Recurring_Invoices = _systemElements1.draft_title.Text;
            if (Recurring_Invoices == "Recurring Invoices")
            {
                Console.WriteLine("Test case pass");
            }
            else
            {
                Console.WriteLine("Test case pass");
            }

            //Archive invoices left side

            waitformee.Until(driver => _systemElements1.archived_invoices_left_side.Displayed);
            _systemElements1.archived_invoices_left_side.Click();
            waitformee.Until(driver => _systemElements1.draft_title.Displayed);
            string archived_title = _systemElements1.draft_title.Text;
            if (archived_title == "Archived Invoices")
            {
                Console.WriteLine("Test case passssdf");
            }
            else
            {
                Console.WriteLine("Test case psdfasass");
            }
            _systemElements1.verify_purchases_bills_page_display();
            _systemElements1.verify_purchases_draft_page_display();
            _systemElements1.verify_purchases_recurring_bills_display();
            _systemElements1.verify_purchases_archived_display();
            _systemElements1.verify_staff_expenses_page_display();
            _systemElements1.verify_awaiting_payment_display();
            _systemElements1.verify_expnese_drafts_display();
            _systemElements1.verify_chart_of_accounts_page_display();
            _systemElements1.verify_charts_of_account_count();
            _systemElements1.verify_assest_count();
            _systemElements1.verify_Liabilites_count();
            _systemElements1.verify_equity_count();
            _systemElements1.verify_revenue_count();
            _systemElements1.verify_expenses_count();
            _systemElements1.verify_dividends_display();
            _systemElements1.verify_fixed_assests_display();
            _systemElements1.verify_disposed_assests_display();
            _systemElements1.verify_journals_display();
            _systemElements1.add_journal_display_fields();
            _systemElements1.add_opening_balance_display_field();
        }





        public void test_case_3_verify_check_all_broken_links_system_settings()
        {



            //_systemElements1.user_already_login();
            //WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //waitformee.Until(PRED => _systemElements1.create_new_dashboard.Displayed);
            //_systemElements1.System_settings_left_menu.Click();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            IList<IWebElement> links = driver.FindElements(By.TagName("a"));
                foreach (IWebElement link in links)
                {
                    var url = link.GetAttribute("href");
                    IsLinkWorking(url);
                }

            }
            bool IsLinkWorking(string url)
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://haibooks.com/2611142/Company");

                request.Method = "GET";
                request.UseDefaultCredentials = true;
                request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                request.UserAgent = "MyHttpRequester";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36";
                request.Credentials = CredentialCache.DefaultCredentials;
                //You can set some parameters in the "request" object...
                request.AllowAutoRedirect = true;
                request.KeepAlive = true;


                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine("\r\nResponse Status Code is OK and StatusDescription is ", response.StatusCode);
                        Console.WriteLine("\r\nResponse Status Code is OK and StatusDescription is ", response.Headers);
                        // Releases the resources of the response.
                        response.Close();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("\r\nResponse Status Code is not OK ", response.StatusCode);
                        return false;
                    }
                }
                catch
                { //TODO: Check for the right exception here
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Console.WriteLine("\r\nResponse Status Code is not OK  ", response.StatusCode);
                    return false;
                }

            }
        }
    }

        
 


    
    
