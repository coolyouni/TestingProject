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

namespace HaibooksAutomationForWeb
{
    [TestClass]
    public class signup_test_case : Baseclass
    {


        [Test, Order(1)]
        public void test_case_1_verify_signup_for_business_owner()
        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            //Click on signup button
            try
            {
                waitformee.Until(driver => _systemElements1.sign_up_button.Displayed);
            }catch(Exception e) { }
          ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.sign_up_button);
            //_systemElements1.sign_up_button.Click();

            //business owner link is displaying
            waitformee.Until(driver => _systemElements1.business_owner_btn.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //Click on Business owner button
            Actions actions = new Actions(driver);
            actions.MoveToElement(_systemElements1.business_owner_btn).Click().Build().Perform();
            //clcik on next button
            _systemElements1.Next_btn.Click();
            waitformee.Until(driver => _systemElements1.Get_started_btn.Displayed);

            //Enter data for registering
            _systemElements1.first_name_txtbx.SendKeys(Constants.firstname);
            _systemElements1.last_name_txtbx.SendKeys(Constants.lastname);


            //Genrating email value
            MyHelperClass c = new MyHelperClass();
            string email_value = c.GetRandomEmailvalue(Constants.firstname);
            Console.WriteLine("Email Value: " + email_value);
            _systemElements1.register_email_txtbx.SendKeys(email_value);

            //phone no mandatory
            Thread.Sleep(TimeSpan.FromSeconds(2));
            SelectElement drpCountry = new SelectElement(_systemElements1.regisgter_phone_country_code_drop_down);
            drpCountry.SelectByValue("+92");
            _systemElements1.phone_no_txtbx.SendKeys(Constants.phone_no_without_code);

            //Password
            _systemElements1.password_txtbx.SendKeys(Constants.password);
            _systemElements1.confirm_pwd_txtbx.SendKeys(Constants.password);

            //Consent form

            Actions consentcheckbox = new Actions(driver);
            consentcheckbox.MoveToElement(_systemElements1.consent_checkbox).Click().Build().Perform();

            //Get started button
            _systemElements1.Get_started_btn.Click();

            waitformee.Until(driver => _systemElements1.Nearly_done.Displayed);
            Assert.AreEqual(email_value, _systemElements1.Activation_email.Text);


            //Mailinator.com
            driver.Navigate().GoToUrl(Constants.mailinator_URL);
            driver.Manage().Window.Maximize();
            try { 
            waitformee.Until(driver => _systemElements1.search_textbox.Displayed);
            }catch(Exception e){ }

            if (homeURL == Constants.test_website || homeURL == Constants.temp_test_environment || homeURL == Constants.receipt_site || homeURL== Constants.temp_test_3569_environment || homeURL == Constants.Any_link)
            {
                _systemElements1.perform_searching(Constants.forward_email);
                                                //subject body contains for clicking email
                waitformee.Until(driver => _systemElements1.subject_body_forwading_email.Displayed);
                _systemElements1.subject_body_forwading_email.Click();
            }
            else 
            { 
                _systemElements1.perform_searching(email_value);
                                              //subject body contains for clicking email
                waitformee.Until(driver => _systemElements1.subject_body.Displayed);
                _systemElements1.subject_body.Click();
            }           
         
            // switch mailinator iframe
            driver.SwitchTo().Frame(_systemElements1.iframe_id);
            waitformee.Until(driver => _systemElements1.yes_its_me_lets_get_started_btn.Displayed);
            _systemElements1.yes_its_me_lets_get_started_btn.Click();

            //switch to new tab 
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            waitformee.Until(driver => _systemElements1.limited_liability_company_type.Displayed);

            //Click on Limited Liability Company

            Actions click_LLC = new Actions(driver);
            click_LLC.MoveToElement(_systemElements1.limited_liability_company_type).Click().Build().Perform();

            //Search company name
            _systemElements1.search_external_companies.Click();
            _systemElements1.search_external_companies.SendKeys(Constants.Company_Name);

            waitformee.Until(driver => _systemElements1.select_company_name.Displayed);
            Actions compnay_name = new Actions(driver);
            compnay_name.MoveToElement(_systemElements1.select_company_name).Click().Build().Perform();
            waitformee.Until(driver => _systemElements1.Final_step_get_started.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.Final_step_get_started.Click();

            try
            {
                waitformee.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("intercom-tour-frame"));
                Thread.Sleep(TimeSpan.FromSeconds(8));
                //driver.SwitchTo().Frame("intercom-tour-frame");         
                _systemElements1.Alert_intercom_tour_frame.Click();
                driver.SwitchTo().DefaultContent();
                Thread.Sleep(TimeSpan.FromSeconds(4));
            }catch(Exception e) { }
            //driver.SwitchTo().Frame("intercom-modal-frame");       
            try
            {
                waitformee.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("intercom-modal-frame"));
                Thread.Sleep(TimeSpan.FromSeconds(4));
                _systemElements1.haibooks_last_popup.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                driver.SwitchTo().DefaultContent();
            }catch(Exception e) { }

            waitformee.Until(driver => _systemElements1.username.Displayed);
            _systemElements1.username.Click();
            waitformee.Until(driver => _systemElements1.My_profile.Displayed);
            _systemElements1.My_profile.Click();
            waitformee.Until(driver => _systemElements1.My_profile_first_name.Displayed);

            //Asserting values
            
            String firstname_actual_result = _systemElements1.My_profile_first_name.GetAttribute("value");
            String Lastname_actual_result = _systemElements1.My_profile_last_name.GetAttribute("value");
            String Email_actual_result = _systemElements1.My_profile_email.GetAttribute("value");
            
            Assert.AreEqual(Constants.firstname, firstname_actual_result);
            Assert.AreEqual(Constants.lastname, Lastname_actual_result);
            Assert.AreEqual(email_value, Email_actual_result);
            Console.WriteLine("Verifing that business owner signup and data showing in profile: ");
            Console.WriteLine("Expected First name: " + Constants.firstname + ", Actual First name: "+ firstname_actual_result);
            Console.WriteLine("Expected Last name: " + Constants.lastname + ", Actual Last name: " + Lastname_actual_result);
            Console.WriteLine("Expected Email Value: " + email_value + ", Actual Email value: " + Email_actual_result);
            close();
        }


        [Test, Order(2)]
        public void test_case_2_verify_signup_for_business_advisor()
        {
            
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            //Click on signup button
            try
            {
                waitformee.Until(driver => _systemElements1.sign_up_button.Displayed);
            }catch(Exception e) { }
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.sign_up_button);
            //_systemElements1.sign_up_button.Click();

            //business owner link is displaying
            waitformee.Until(driver => _systemElements1.business_adviser_btn.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //Click on Business owner button
            Actions actions = new Actions(driver);
            actions.MoveToElement(_systemElements1.business_adviser_btn).Click().Build().Perform();
            //clcik on next button
            _systemElements1.Next_btn.Click();
            waitformee.Until(driver => _systemElements1.Get_started_btn.Displayed);

            //Enter data for registering
            _systemElements1.first_name_txtbx.SendKeys(Constants.firstname);
            _systemElements1.last_name_txtbx.SendKeys(Constants.lastname);


            //Genrating email value
            MyHelperClass c = new MyHelperClass();
            string email_value = c.GetRandomEmailvalue(Constants.firstname);
            Console.WriteLine("Email Value: " + email_value);
            _systemElements1.register_email_txtbx.SendKeys(email_value);

            //phone no mandatory
            SelectElement drpCountry = new SelectElement(_systemElements1.regisgter_phone_country_code_drop_down);
            drpCountry.SelectByValue("+92");
            _systemElements1.phone_no_txtbx.SendKeys(Constants.phone_no_without_code);

            //Password
            _systemElements1.password_txtbx.SendKeys(Constants.password);
            _systemElements1.confirm_pwd_txtbx.SendKeys(Constants.password);

            //Consent form

            Actions consentcheckbox = new Actions(driver);
            consentcheckbox.MoveToElement(_systemElements1.consent_checkbox).Click().Build().Perform();

            //Get started button
            _systemElements1.Get_started_btn.Click();

            try
            {
                waitformee.Until(driver => _systemElements1.Nearly_done.Displayed);
            }catch(Exception e) { }
            Assert.AreEqual(email_value, _systemElements1.Activation_email.Text);


            //Mailinator.com
            driver.Navigate().GoToUrl(Constants.mailinator_URL);
            driver.Manage().Window.Maximize();
            try { 
                waitformee.Until(driver => _systemElements1.search_textbox.Displayed);
            }catch(Exception e) { }

            if (homeURL == Constants.test_website || homeURL == Constants.temp_test_environment || homeURL == Constants.receipt_site || homeURL == Constants.temp_test_3569_environment || homeURL == Constants.Any_link)
            {
                _systemElements1.perform_searching(Constants.forward_email);
                //subject body contains for clicking email
                waitformee.Until(driver => _systemElements1.subject_body_forwading_email.Displayed);
                _systemElements1.subject_body_forwading_email.Click();
            }

            //if (homeURL == Constants.test_website || homeURL == Constants.temp_test_environment || homeURL == Constants.receipt_site || homeURL == Constants.temp_test_3569_environment)
            //{
            //    _systemElements1.perform_searching(Constants.forward_email);
            //    //subject body contains for clicking email
            //    waitformee.Until(driver => _systemElements1.subject_body_forwading_email.Displayed);
            //    _systemElements1.subject_body_forwading_email.Click();
            //}
            else
            {
                _systemElements1.perform_searching(email_value);
                //subject body contains for clicking email
                waitformee.Until(driver => _systemElements1.subject_body.Displayed);
                _systemElements1.subject_body.Click();
            }

            // switch mailinator iframe
            driver.SwitchTo().Frame(_systemElements1.iframe_id);
            waitformee.Until(driver => _systemElements1.yes_its_me_lets_get_started_btn.Displayed);
            _systemElements1.yes_its_me_lets_get_started_btn.Click();

            //switch to new tab 
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            //click on New Client
            waitformee.Until(driver => _systemElements1.New_client.Displayed);
            _systemElements1.New_client.Click();


            waitformee.Until(driver => _systemElements1.limited_liability_company_type.Displayed);

            //Click on Limited Liability Company

            Actions click_LLC = new Actions(driver);
            click_LLC.MoveToElement(_systemElements1.limited_liability_company_type).Click().Build().Perform();

            //Search company name
            _systemElements1.search_external_companies.Click();
            _systemElements1.search_external_companies.SendKeys(Constants.Company_Name);

            waitformee.Until(driver => _systemElements1.select_company_name.Displayed);
            Actions compnay_name = new Actions(driver);
            compnay_name.MoveToElement(_systemElements1.select_company_name).Click().Build().Perform();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.Add_business.Click();
            try
            {

                waitformee.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("intercom-tour-frame"));
                Thread.Sleep(TimeSpan.FromSeconds(8));
                //driver.SwitchTo().Frame("intercom-tour-frame");         
                _systemElements1.Alert_intercom_tour_frame.Click();
                driver.SwitchTo().DefaultContent();
                Thread.Sleep(TimeSpan.FromSeconds(4));
                //driver.SwitchTo().Frame("intercom-modal-frame");
            }catch(Exception e) { }
            try
            {
                waitformee.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("intercom-modal-frame"));
                Thread.Sleep(TimeSpan.FromSeconds(4));
                _systemElements1.haibooks_last_popup.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                driver.SwitchTo().DefaultContent();
            }catch(Exception e) { }
            waitformee.Until(driver => _systemElements1.username.Displayed);
            _systemElements1.username.Click();
            waitformee.Until(driver => _systemElements1.Back_to_advisor_panel.Displayed);           
            waitformee.Until(driver => _systemElements1.My_profile.Displayed);
            _systemElements1.My_profile.Click();

            waitformee.Until(driver => _systemElements1.My_profile_first_name.Displayed);

            //Asserting values

            String firstname_actual_result = _systemElements1.My_profile_first_name.GetAttribute("value");
            String Lastname_actual_result = _systemElements1.My_profile_last_name.GetAttribute("value");
            String Email_actual_result = _systemElements1.My_profile_email.GetAttribute("value");

            Assert.AreEqual(Constants.firstname, firstname_actual_result);
            Assert.AreEqual(Constants.lastname, Lastname_actual_result);
            Assert.AreEqual(email_value, Email_actual_result);
            Console.WriteLine("Verifing that business owner signup and data showing in profile: ");
            Console.WriteLine("Expected First name: " + Constants.firstname + ", Actual First name: " + firstname_actual_result);
            Console.WriteLine("Expected Last name: " + Constants.lastname + ", Actual Last name: " + Lastname_actual_result);
            Console.WriteLine("Expected Email Value: " + email_value + ", Actual Email value: " + Email_actual_result);
            close();
        }      
    }
}

    
    
