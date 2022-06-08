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
    public class Contacts : Baseclass
    {
        

        [Test, Order(1)]                  
        public void test_case_1_verify_contacts_are_adding()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            _systemElements1.perform_click_to_dashboard();
            _systemElements1.redirect_to_menu_from_settings();
            waitformee.Until(driver => _systemElements1.create_new_dashboard.Displayed);
            _systemElements1.contact_link_left_menu.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.create_new_contact.Displayed);
            _systemElements1.create_new_contact.Click();
            _systemElements1.perform_adding_contacts(Constants.adding_contact_left_menu);
            string full_name = _systemElements1.global_full_name;
            string contact= _systemElements1.global_contact;
            string email_value= _systemElements1.global_email_value_contact;
            string vat_registration= _systemElements1.global_vat_generate_contact;
            _systemElements1.add_contact_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.all_contact_tab.Displayed);

            //Creating xpath for added contact
            string xpath_for_business_name = "//span[@class='name'][normalize-space()='" + full_name + "']";
            _systemElements1.perform_search_data(full_name);
            _systemElements1.perform_click_on_data(full_name, Constants.contact_col, Constants.contact_rows,2, "/ul/li[1]/a");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //driver.FindElement(By.XPath(xpath_for_business_name)).Click();
            waitformee.Until(driver => _systemElements1.edit_contacts.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.edit_contacts.Click();

            //Verification of Contacts
            waitformee.Until(driver => _systemElements1.Contact_information_expand_collapsed.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));

            if (_systemElements1.Contact_information_grid.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.Contact_information_expand_collapsed.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            Assert.AreEqual(full_name, _systemElements1.business_name_textbox.GetAttribute("value"));
            Assert.AreEqual(contact, _systemElements1.ContactPerson_textbox.GetAttribute("value"));
            Assert.AreEqual(email_value, _systemElements1.Email_textbox.GetAttribute("value"));
            Assert.AreEqual(Constants.phone_no_without_code, _systemElements1.Telephone_textbox.GetAttribute("value"));
            Assert.AreEqual(Constants.mobile_no, _systemElements1.Mobile_textbox.GetAttribute("value"));
            Assert.AreEqual(homeURL, _systemElements1.Website_textbox.GetAttribute("value"));
            Assert.AreEqual(Constants.Fax_no, _systemElements1.Fax_textbox.GetAttribute("value"));
            if (_systemElements1.adress_grid.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.adress_expand_collapsed.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

            Assert.AreEqual(Constants.Buidling_adress, _systemElements1.Building_textbox.GetAttribute("value"));
            Assert.AreEqual(Constants.street_no, _systemElements1.Street_textbox.GetAttribute("value"));
            Assert.AreEqual(Constants.city, _systemElements1.CityOrTown_textbox.GetAttribute("value"));
            Assert.AreEqual(Constants.post_code, _systemElements1.PostCode_textbox.GetAttribute("value"));
            Assert.AreEqual(Constants.region, _systemElements1.region_textbox.GetAttribute("value"));
            string country_selected = driver.FindElement(By.XPath("//select[@id='CountryCode']")).GetAttribute("value");
            if (country_selected == "GB")
            {
                Console.WriteLine("Country drop down is selecting correct value");
            }
            else
            {
                Assert.Fail("country drop down value is showing wrong");
            }


            if (_systemElements1.financial_details_grid.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.financial_details_collapsed.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            Assert.AreEqual(vat_registration, _systemElements1.vat_reg_no_textbox.GetAttribute("value"));


            if (_systemElements1.Terms_details_grid.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.Terms_details_collapsed.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }


            try
            {
              bool terms_selection=  driver.FindElement(By.XPath("//div[contains(text(),'30 days')]")).Displayed;
                if(terms_selection==true)
                {
                    Console.WriteLine("Terms days are selecting correctly");
                }
                else
                {
                    Assert.Fail("Terms days are not showing correctly");
                }
            }catch(Exception e)
                {}         


            Console.WriteLine("Test case passed: All added values for each textbox and dropwon is showing correctly");
           
        }


        [Test, Order(2)]

        public void test_case_2_verify_contacts_expand_and_collpased_working_fine()

        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            _systemElements1.perform_click_to_dashboard();
            _systemElements1.redirect_to_menu_from_settings();
            waitformee.Until(driver => _systemElements1.create_new_dashboard.Displayed);
            _systemElements1.contact_link_left_menu.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.create_new_contact.Displayed);
            _systemElements1.create_new_contact.Click();

            waitformee.Until(driver => _systemElements1.Contact_information_expand_collapsed.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //Adress book should be default expand
            string contact_information_status_expand_expand = _systemElements1.Contact_information_grid.GetAttribute("aria-expanded");
            string adress_status_expand_collpased = _systemElements1.adress_grid.GetAttribute("aria-expanded");
            string financial_details_expand_collpased = _systemElements1.financial_details_grid.GetAttribute("aria-expanded");
            string terms_details_expand_collpased = _systemElements1.Terms_details_grid.GetAttribute("aria-expanded");
            Assert.AreEqual(contact_information_status_expand_expand, "true");
            Assert.AreEqual(adress_status_expand_collpased, "false");
            Assert.AreEqual(financial_details_expand_collpased, "false");
            Assert.AreEqual(terms_details_expand_collpased, "false");

            if (contact_information_status_expand_expand == "true")
            {
                bool display_text_box = _systemElements1.business_name_textbox.Displayed;
                if (display_text_box == true)
                {
                    Console.WriteLine("Contact information is by default expandable");
                }
                else
                {
                    Assert.Fail("Contact information is not expandable");
                }

            }


                if (_systemElements1.adress_grid.GetAttribute("aria-expanded") == "false")
                {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.adress_expand_collapsed);
                //_systemElements1.adress_expand_collapsed.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                string display_text_box = _systemElements1.adress_grid.GetAttribute("aria-expanded");

                if (display_text_box == "true")
                  {
                      Console.WriteLine("Adress is  expandable");
                  }
                   else
                   {
                       Assert.Fail("Adress is not expandable");
                   }
                }



            if (_systemElements1.financial_details_grid.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.financial_details_collapsed.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                string display_text_box = _systemElements1.financial_details_grid.GetAttribute("aria-expanded");
                
                if (display_text_box == "true")
                {
                    Console.WriteLine("Financial Details is expandable");
                }
                else
                {
                    Assert.Fail("Financial Details is not expandable");
                }
            }


            if (_systemElements1.Terms_details_grid.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.Terms_details_collapsed.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                string display_text_box = _systemElements1.Terms_details_grid.GetAttribute("aria-expanded");
                if (display_text_box == "true")
                {
                    Console.WriteLine("Terms Details is expandable");
                }
                else
                {
                    Assert.Fail("Terms Details is not expandable");
                }
            }



        }






    }
}

    
    
