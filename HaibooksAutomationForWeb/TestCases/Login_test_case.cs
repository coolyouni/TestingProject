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
using HaibooksAutomationForWeb.TestCases;
using HaibooksAutomationForWeb.Elements;
using HaibooksAutomationForWeb.MyHelper;
using HaibooksAutomationForWeb.Constant;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace HaibooksAutomationForWeb
{
    [TestClass]
    public class Login_test_case: Baseclass
    {

        [Test, Order(1)]

        public void test_case_1_verify_login_test_case_with_empty_email_empty_pwd()
        {
           
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
            waitformee.Until(driver => _systemElements1.signin_button.Displayed);     
         
            ////checking iframe exists
            //try
            //{
            //    List<IWebElement> list_for_element = new List<IWebElement>();
            //    list_for_element.AddRange(driver.FindElements(By.TagName("iframe")));
            //    if (list_for_element.Count > 0)
            //    {
            //        driver.SwitchTo().Frame(0);
            //        Thread.Sleep(TimeSpan.FromSeconds(10));
            //    }
            //}
            //catch (Exception e)
            //{
            //    driver.SwitchTo().DefaultContent();
            //    Console.WriteLine("iframme switch does not exists");
            //}
            //driver.SwitchTo().DefaultContent();

            //Enter email address
            _systemElements1.email_adress_textbox.Click();
            _systemElements1.email_adress_textbox.Clear();     
            
            //Enter password
            _systemElements1.password_textbox.Click();
            _systemElements1.password_textbox.Clear();     
            Thread.Sleep(TimeSpan.FromSeconds(2));
           
            _systemElements1.signin_button.Click();          
            Thread.Sleep(TimeSpan.FromSeconds(2));
            takesceenshot("TC_1_empty_email_and_pwd.png");
            waitformee.Until(driver => _systemElements1.login_email_validation.Displayed);
            waitformee.Until(driver => _systemElements1.login_pwd_validation.Displayed);
            Console.WriteLine("Login email validation is checked and showing following validation message: " + _systemElements1.login_email_validation.Text);
            Console.WriteLine("Login Password validation is checked and showing following validation message: " + _systemElements1.login_pwd_validation.Text);
            close();            
        }



        [Test, Order(2)]
      
        public void test_case_2_verify_login_test_case_invalid_email_invalid_pwd()       
        {
           
           
             WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
            waitformee.Until(driver => _systemElements1.signin_button.Displayed);
            _systemElements1.verifying_login_with_data_driven(2,1,2,2);
            var email_adress = _systemElements1.global_email_adress;
            var password = _systemElements1.global_password;
            Console.WriteLine(email_adress);
            Console.WriteLine(password);

            ////checking iframe exists
            //try
            //{
            //    List<IWebElement> list_for_element = new List<IWebElement>();
            //    list_for_element.AddRange(driver.FindElements(By.TagName("iframe")));
            //    if (list_for_element.Count > 0)
            //    { 
            //    driver.SwitchTo().Frame(0);
            //    Thread.Sleep(TimeSpan.FromSeconds(10));
            //    }
            //}
            //catch (Exception e)
            //{
            //    driver.SwitchTo().DefaultContent();
            //    Console.WriteLine("iframme switch does not exists");
            // }
            //driver.SwitchTo().DefaultContent();

            //Enter email address
            _systemElements1.email_adress_textbox.Click();
            _systemElements1.email_adress_textbox.Clear();
            _systemElements1.email_adress_textbox.SendKeys(email_adress);

            //Enter password
            _systemElements1.password_textbox.Click();
            _systemElements1.password_textbox.Clear();
            _systemElements1.password_textbox.SendKeys(password);
            Thread.Sleep(TimeSpan.FromSeconds(2));

           
            //// <iframe title="recaptcha challenge expires in two minutes" 
            /////src="https://www.google.com/recaptcha/api2/bframe?hl=en&amp;v=_exWVY_hlNJJl2Abm8pI9i1L&amp;k=6Lemx5MUAAAAAJRAQ7mdo5bh8-vPfEXbLk4XogGd" name="c-gtbcfza2qed3" frameborder="0" scrolling="no" sandbox="allow-forms allow-popups allow-same-origin allow-scripts allow-top-navigation allow-modals allow-popups-to-escape-sandbox" style="width: 400px; height: 580px;"></iframe>


            //click on sign in button
            // waitformee.Until(driver => _systemElements1.captcha_label.Displayed);
            //_systemElements1.captcha_label.Click();
            //_systemElements1.verify_captcha_clickable();
            _systemElements1.signin_button.Click();
            Console.WriteLine("Data is added from excel sheet");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            takesceenshot("TC_2_invalid_email_invalid_pwd.png");
            waitformee.Until(driver => _systemElements1.login_email_validation.Displayed);
            waitformee.Until(driver => _systemElements1.login_pwd_validation.Displayed);
            Console.WriteLine("Login email validation is checked and showing following validation message: " + _systemElements1.login_email_validation.Text);
            Console.WriteLine("Login Password validation is checked and showing following validation message: " + _systemElements1.login_pwd_validation.Text);
            close();           
        }


        [Test, Order(3)]
        public void test_case_3_verify_login_test_case_valid_email_invalid_pwd()
        {
           
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
            waitformee.Until(driver => _systemElements1.signin_button.Displayed);           
            _systemElements1.verifying_login_with_data_driven(3,1,3,2);
            var email_adress = _systemElements1.global_email_adress;
            var password = _systemElements1.global_password;
            Console.WriteLine(email_adress);
            Console.WriteLine(password);
            ////checking iframe exists
            //try
            //{
            //    driver.SwitchTo().Frame(0);
            //    Thread.Sleep(TimeSpan.FromSeconds(10));
            //}
            //catch (Exception e)
            //{
            //    driver.SwitchTo().DefaultContent();
            //    Console.WriteLine("iframme switch does not exists");
            //}
            //driver.SwitchTo().DefaultContent();
            _systemElements1.email_adress_textbox.Click();
            _systemElements1.email_adress_textbox.Clear();
            _systemElements1.email_adress_textbox.SendKeys(email_adress);

            //Enter password
            _systemElements1.password_textbox.Click();
            _systemElements1.password_textbox.Clear();
            _systemElements1.password_textbox.SendKeys(password);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.signin_button.Click();
            Console.WriteLine("Data imported from excel");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.login_email_validation.Displayed);
            waitformee.Until(driver => _systemElements1.login_pwd_validation.Displayed);
            Console.WriteLine("Login email validation is checked and showing following validation message: " + _systemElements1.login_email_validation.Text);
            Console.WriteLine("Login Password validation is checked and showing following validation message: " + _systemElements1.login_pwd_validation.Text);
            takesceenshot("TC_3_valid_email_invalid_pwd.png");
            close();
        }
               


        [Test, Order(4)]
        public void test_case_4_verify_session_expire_and_login_back_to_same_page()
        {           
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            waitformee.Until(driver => _systemElements1.signin_button.Displayed);           
           _systemElements1.verifying_login_with_data_driven(12, 1, 12, 2);           
            var email_adress = _systemElements1.global_email_adress;
            var password = _systemElements1.global_password;
            Console.WriteLine(email_adress);
            Console.WriteLine(password);
            //driver.SwitchTo().DefaultContent();
            _systemElements1.email_adress_textbox.Click();
            _systemElements1.email_adress_textbox.Clear();
            _systemElements1.email_adress_textbox.SendKeys(email_adress);

            //Enter password
            _systemElements1.password_textbox.Click();
            _systemElements1.password_textbox.Clear();
            _systemElements1.password_textbox.SendKeys(password);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.signin_button.Click();
            Console.WriteLine("Data imported from excel");
            try { 
                bool system_settings_display_first = _systemElements1.go_back_to_haibooks_leftmenu.Displayed;
             if (system_settings_display_first == true)
                    {
                      _systemElements1.go_back_to_haibooks_leftmenu.Click();
                     }
                }
            catch(Exception e){}
            waitformee.Until(driver => _systemElements1.contacts_leftmenu.Displayed);
            _systemElements1.contacts_leftmenu.Click();
            waitformee.Until(driver => _systemElements1.create_new_contact.Displayed);           
            takesceenshot("page_before_session_destroy.png");

            //Get session Id
            //string sessionId = ((RemoteWebDriver)driver).SessionId.ToString();
            //Console.WriteLine(sessionId);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            driver.Manage().Cookies.DeleteAllCookies();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            driver.Navigate().Refresh();
            waitformee.Until(driver => _systemElements1.signin_button.Displayed);
            takesceenshot("session_out.png");
            bool alert_session_out_message = _systemElements1.alert_session_out.Displayed;
            if(alert_session_out_message==true ) 
            {
                Console.WriteLine("Session time out message is showing: " + _systemElements1.alert_session_out.Text);
            }
            if (_systemElements1.signin_button.Displayed)
            {
                Console.WriteLine("user has been log out");
            }

            //Login again and verify same contact page open

           _systemElements1.verifying_login_with_data_driven(12, 1, 12, 2);         
            
            //driver.SwitchTo().DefaultContent();
            _systemElements1.email_adress_textbox.Click();
            _systemElements1.email_adress_textbox.Clear();
            _systemElements1.email_adress_textbox.SendKeys(email_adress);

            //Enter password
            _systemElements1.password_textbox.Click();
            _systemElements1.password_textbox.Clear();
            _systemElements1.password_textbox.SendKeys(password);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.signin_button.Click();           
            waitformee.Until(driver => _systemElements1.create_new_contact.Displayed);
            takesceenshot("login_again_and_same_page_open.png");
            close();        
        }


        [Test, Order(5)]
        public void test_case_5_verify_login_test_case_valid_email_valid_pwd()
        {
            
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            waitformee.Until(driver => _systemElements1.signin_button.Displayed);
            _systemElements1.verifying_login_with_data_driven(12, 1, 12, 2);           
            var email_adress = _systemElements1.global_email_adress;
            var password = _systemElements1.global_password;
            Console.WriteLine(email_adress);
            Console.WriteLine(password);
            //checking iframe exists
            //try
            //{
            //    driver.SwitchTo().Frame(0);
            //    Thread.Sleep(TimeSpan.FromSeconds(10));
            //}
            //catch (Exception e)
            //{
            //    driver.SwitchTo().DefaultContent();
            //    Console.WriteLine("iframme switch does not exists");
            //}
            //driver.SwitchTo().DefaultContent();
            _systemElements1.email_adress_textbox.Click();
            _systemElements1.email_adress_textbox.Clear();
            _systemElements1.email_adress_textbox.SendKeys(email_adress);

            //Enter password
            _systemElements1.password_textbox.Click();
            _systemElements1.password_textbox.Clear();
            _systemElements1.password_textbox.SendKeys(password);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.signin_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Data imported from excel");
            //try
            //{
            //    bool system_settings_display_first = _systemElements1.go_back_to_haibooks_leftmenu.Displayed;
            //    if (system_settings_display_first == true)
            //    {
            //        _systemElements1.go_back_to_haibooks_leftmenu.Click();
            //    }
            //}
            //catch (Exception e) { }
            //_systemElements1.dashboard_leftmenu.Click();
            _systemElements1.perform_click_to_dashboard();           
            Boolean create_new_left_side_showing = _systemElements1.create_new_left_side.Displayed;
            if(create_new_left_side_showing==true)
            {
                Console.WriteLine("user logged in successfully");
            }
            else
            {              
            }            
            waitformee.Until(driver => _systemElements1.financial_overview_view_sales_link.Displayed);
            //waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            takesceenshot("TC_4_valid_email_valid_pwd.png");
            close();
        }



        //[Test, Order(6)]
        //public void perform()
        //{
        //    TestInitForWeb("Chrome");
        //    WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        //    waitformee.Until(driver => _systemElements1.signin_button.Displayed);

        //    if (homeURL == Constants.main_website)
        //    {
        //        _systemElements1.verifying_login_with_data_driven(4, 1, 4, 2);
        //    }
        //    else if (homeURL == Constants.test_website)
        //    {
        //        _systemElements1.verifying_login_with_data_driven(5, 1, 5, 2);
        //    }
        //    var email_adress = _systemElements1.global_email_adress;
        //    var password = _systemElements1.global_password;
        //    Console.WriteLine(email_adress);
        //    Console.WriteLine(password);
        //    //checking iframe exists
        //    //try
        //    //{
        //    //    driver.SwitchTo().Frame(0);
        //    //    Thread.Sleep(TimeSpan.FromSeconds(10));
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    driver.SwitchTo().DefaultContent();
        //    //    Console.WriteLine("iframme switch does not exists");
        //    //}
        //    //driver.SwitchTo().DefaultContent();
        //    _systemElements1.email_adress_textbox.Click();
        //    _systemElements1.email_adress_textbox.Clear();
        //    _systemElements1.email_adress_textbox.SendKeys(email_adress);

        //    //Enter password
        //    _systemElements1.password_textbox.Click();
        //    _systemElements1.password_textbox.Clear();
        //    _systemElements1.password_textbox.SendKeys(password);
        //    Thread.Sleep(TimeSpan.FromSeconds(2));
        //    _systemElements1.signin_button.Click();
        //    Thread.Sleep(TimeSpan.FromSeconds(2));
        //    Console.WriteLine("Data imported from excel");
        //    try
        //    {
        //        bool system_settings_display_first = _systemElements1.go_back_to_haibooks_leftmenu.Displayed;
        //        if (system_settings_display_first == true)
        //        {
        //            _systemElements1.go_back_to_haibooks_leftmenu.Click();
        //        }
        //    }
        //    catch (Exception e) { }
        //    _systemElements1.dashboard_leftmenu.Click();
        //    waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
        //    waitformee.Until(driver => _systemElements1.financial_overview_view_sales_link.Displayed);
        //    _systemElements1.financial_overview_view_sales_link.Click();

        //    waitformee.Until(driver => driver.FindElements(By.XPath("//div[6]/div/table/tbody/tr/td[2]")));
        //    Thread.Sleep(TimeSpan.FromSeconds(5));
        //    Console.WriteLine( driver.FindElement(By.XPath("//table/tbody/tr[1]/td[2]/a")).Text);
           
        //    List <IWebElement> list_for_element = new List<IWebElement>();
        //    list_for_element.AddRange(driver.FindElements(By.XPath("//table[contains(@class,'dx-datagrid-table dx-datagrid-table-fixed']/colgroup/col")));
        //    if (list_for_element.Count > 0)
        //    {
        //        Console.WriteLine(list_for_element.Count);
        //    }


        //    //            Grid.ColumnCount:	9
        //    //Grid.RowCount:	8

        //    //#dx-col-1
      
               


        //    //                /html/body/main/div[2]/div/div[2]/div[4]/div/div/div[6]/div/table/tbody/tr[1]/td[2]/a
        //    //                /html/body/main/div[2]/div/div[2]/div[4]/div/div/div[6]/div/table/tbody/tr[1]/td[3]/a
        //    //                /html/body/main/div[2]/div/div[2]/div[4]/div/div/div[6]/div/table/tbody/tr[2]/td[4]/div/button/div/div/div


        //}


    }
}

    
    
