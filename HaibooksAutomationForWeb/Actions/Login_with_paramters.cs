using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HaibooksAutomationForWeb;
using HaibooksAutomationForWeb.Constant;
using HaibooksAutomationForWeb.TestCases;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HaibooksAutomationForWeb.Elements
{
   public partial class system_elements: Baseclass
    {

        
        public void perform_login_with_paramters(string email_value, string password)
        {
            _systemElements1 = new system_elements(driver);          
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
           waitformee.Until(driver => _systemElements1.signin_button.Displayed);
            
            Console.WriteLine(email_value);
            Console.WriteLine(password);
            //checking iframe exists
          
            _systemElements1.email_adress_textbox.Click();
            _systemElements1.email_adress_textbox.Clear();
            _systemElements1.email_adress_textbox.SendKeys(email_value);

            //Enter password
            _systemElements1.password_textbox.Click();
            _systemElements1.password_textbox.Clear();
            _systemElements1.password_textbox.SendKeys(password);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.signin_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            perform_click_to_dashboard();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            try
            {
                waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
                waitformee.Until(driver => _systemElements1.financial_overview_view_sales_link.Displayed);
            }
            catch(Exception e) { }
            takesceenshot("TC_4_valid_email_valid_pwd.png");
           
        }

        public void user_already_login()
        {
          
            List <IWebElement> list_for_element = new List<IWebElement>();
            list_for_element.AddRange(driver.FindElements(By.XPath("//a[contains(@href, \'#\')]")));
            if (list_for_element.Count <= 0)
            {
                //driver.Quit();
                if(homeURL == Constants.main_website)
                { 
                perform_login_with_paramters(Constants.login_username, Constants.login_password);
                }
                else if(homeURL == Constants.test_website)
                {
                    perform_login_with_paramters(Constants.test2_login_username, Constants.test2_login_password);
                }
                else if (homeURL == Constants.receipt_site)
                {
                    perform_login_with_paramters(Constants.receipt_login_username, Constants.receipt_login_password);
                }
                else if (homeURL == Constants.temp_test_environment)
                {
                    perform_login_with_paramters(Constants.temp_test_login_username, Constants.temp_test_login_password);
                }

                else if (homeURL == Constants.temp_test_3569_environment)
                {
                    perform_login_with_paramters(Constants.temp_3569_login_username, Constants.temp_test_login_password);
                }

                else if(homeURL==Constants.Any_link)
                {
                    perform_login_with_paramters(Constants.seckin_username, Constants.seckin_password);                    
                }

             


            }          
        }


        public void redirect_to_menu_from_settings()
        {
            try
            {
                bool system_settings_display_first = _systemElements1.go_back_to_haibooks_leftmenu.Displayed;
                if (system_settings_display_first == true)
                {
                    _systemElements1.go_back_to_haibooks_leftmenu.Click();
                }
            }
            catch (Exception e) { }
        }


       

    }
}
