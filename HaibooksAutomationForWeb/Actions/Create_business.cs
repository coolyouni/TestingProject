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
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HaibooksAutomationForWeb.Elements
{
   public partial class system_elements: Baseclass
    {
        public bool global_added_business_match { get; set; }
        public void perform_added_business()
        {
            _systemElements1 = new system_elements(driver);
            //select contact list checked in sales invoice
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitformee.Until(driver => _systemElements1.click_filter_business_menu.Displayed);
            _systemElements1.click_filter_business_menu.Click();
            List<IWebElement> list_for_element = new List<IWebElement>();
            list_for_element.AddRange(driver.FindElements(By.Id("select-mode")));
            if (list_for_element.Count > 0)
            {
                SelectElement select_business_list = new SelectElement(select_business_drop_down);
                IList<IWebElement> options = select_business_list.Options;
                int size_of_drop_down_option = options.Count;
                Console.WriteLine(size_of_drop_down_option);
                if (size_of_drop_down_option >= 0)
                {
                    bool business_name_already_given = false ;
                    foreach (IWebElement option in options)
                    {
                        for (int i = 0; i <= size_of_drop_down_option; i++)
                        {
                            try
                            {
                                string xpath = "//*[@id='" + "bs-select-1-" + i + "']/span/span";
                                Console.WriteLine(driver.FindElement(By.XPath(xpath)).Text);
                                string value = driver.FindElement(By.XPath(xpath)).Text;

                                if (value == Constants.Company_Name_1)
                                {
                                    business_name_already_given = true;
                                    global_added_business_match = business_name_already_given;
                                    Console.WriteLine(business_name_already_given);
                                    break;
                                }
                            }
                            catch(Exception ex)
                            {}

                        }
                        if(business_name_already_given)
                        {
                            break;
                        }
                    }
                }         

            }
        }



        public void create_business_with_sole_trader()
        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _systemElements1.redirect_to_menu_from_settings();
            waitformee.Until(driver => _systemElements1.dashboard_leftmenu.Displayed);
            _systemElements1.click_filter_business_menu.Click();          
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
            Thread.Sleep(TimeSpan.FromSeconds(4));      


        }
    }
 }
