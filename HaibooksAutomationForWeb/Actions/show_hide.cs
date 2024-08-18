using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.TestCases;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HaibooksAutomationForWeb.Elements
{
    public partial class system_elements : Baseclass
    {
        public bool global_vat_is_shoiwng { get; set; }
        public bool global_vat_total { get; set; }


        public void finding_VAT_drop_down(string id)
        {
            bool vat_drop_down_showing;
            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.Id(id)));
            if (list_for_element1.Count > 0)
            {
                vat_drop_down_showing = true;
                global_vat_is_shoiwng = vat_drop_down_showing;
            }
            else
            {
                vat_drop_down_showing = false;
                global_vat_is_shoiwng = vat_drop_down_showing;
            }
        }


        public void finding_VAT_total(string xpath)
        {
            bool vat_drop_down_showing;
            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.XPath(xpath)));
            if (list_for_element1.Count > 0)
            {
                vat_drop_down_showing = true;
                global_vat_total = vat_drop_down_showing;
            }
            else
            {
                vat_drop_down_showing = false;
                global_vat_total = vat_drop_down_showing;
            }
        }


        public bool Vat_rate_label_showing()
        {
            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.XPath("//span[normalize-space()='VAT Rate']")));
            if (list_for_element1.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool Vat_rate_total_label_showing()
        {
            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.XPath("//span[normalize-space()='VAT Total']")));
            if (list_for_element1.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool page_size_display()
        {
            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.XPath("//div[@class='dx-page-sizes']")));
            if (list_for_element1.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }   
        }


        public bool no_dividend_showing()
        {
            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.XPath("//span[@class='dx-datagrid-nodata']")));
            if (list_for_element1.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool pages_size_display()
        {
            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.XPath("//div[@class='dx-info']")));
            if (list_for_element1.Count > 0)
            {
                string no_of_pages = _systemElements1.number_of_pages.Text;
                string items = no_of_pages.Substring(13, 4);
                int counts_items = Convert.ToInt32(items);
                int items_divided_per_page = counts_items / 50;
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool recceipt_title_related_items_showing(String id)
        {
            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.Id(id)));
            if (list_for_element1.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool business_space_x_showing()
        {
            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.XPath("//span[normalize-space()='STLC Limited']")));
            if (list_for_element1.Count > 0)
            {               
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool business_space_x_placeholder_showing()
        {
            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.XPath("//span[contains(text(),'SpaceX')]")));
            if (list_for_element1.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void perform_select_SpaceX()
        {
            _systemElements1 = new system_elements(driver);
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            bool business_spacex_shoiwng = _systemElements1.business_space_x_showing();
            if (business_spacex_shoiwng == false)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                              
                waitformee.Until(driver => _systemElements1.business_filter_option.Displayed);
                business_filter_option.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                bool showing_palceholder = _systemElements1.business_space_x_placeholder_showing();
                if (showing_palceholder == true)
                {
                    business_spacex.Click();
                }
            }

        }



        public bool display_items_summary_with_vat()
        {
            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.XPath("//div[@class='col-md-4'][3]/table[@id='bill-items-summary-with-vat']")));
            if (list_for_element1.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool display_saved_items_summary_with_vat()
        {
            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.XPath("//div[@class='offset-9 col-3']/table/tbody/tr/td[@class='label']")));
            if (list_for_element1.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
