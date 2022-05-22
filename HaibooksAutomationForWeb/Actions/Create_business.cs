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
   }
 }
