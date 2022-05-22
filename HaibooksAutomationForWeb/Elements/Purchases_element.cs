using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.TestCases;
using OpenQA.Selenium;

namespace HaibooksAutomationForWeb.Elements
{
   public partial class system_elements : Baseclass
    {
        public IWebElement purchase_left_side => driver.FindElement(By.Id("nav_link_purchases"));

        public IWebElement bills_left_side => driver.FindElement(By.Id("sub_nav_link_bills"));

        public IWebElement ALL_bills_TAB => driver.FindElement(By.XPath("//a[@id='tab_all_bills']"));
        public IWebElement bills_draft_TAB => driver.FindElement(By.XPath("//a[@id='tab_drafts']"));
        public IWebElement recurring_BILLS_TAB => driver.FindElement(By.XPath("//a[@id='tab_recurring_bills']"));
        public IWebElement bills_archived_TAB => driver.FindElement(By.XPath("//a[@id='tab_archived']"));

        public IWebElement purchase_view_total => driver.FindElement(By.XPath("//a[@id='purchase_total']"));
        public IWebElement purchase_overdue => driver.FindElement(By.XPath("//a[@id='purchase_overdue']"));
        public IWebElement purchase_view_unpaid => driver.FindElement(By.XPath("//a[@id='purchase_unpaid']"));
        public IWebElement purchase_view_paid => driver.FindElement(By.XPath("//a[@id='purchase_paid']"));
       
        public IWebElement purchase_add_bill => driver.FindElement(By.XPath("//a[normalize-space()='Add Bill']"));
        public IWebElement recurring_bills => driver.FindElement(By.Id("sub_nav_link_recurring_bills"));
        public IWebElement recurring_bill_count => driver.FindElement(By.XPath("//span[@class='badge badge-light radius recurring-bills-count']"));
        public IWebElement purchase_archived_count => driver.FindElement(By.XPath(" //span[@class='badge badge-light radius archived-bills-count']"));


    
       




        //////////////Draft Tab eleements

        //public IWebElement draft_title => driver.FindElement(By.XPath("//span[@class='title']"));
        //public IWebElement draft_count => driver.FindElement(By.XPath("//span[@class='badge badge-light radius draft-count']"));


        //public IWebElement sales_archived_count => driver.FindElement(By.XPath("//span[@class='badge badge-light radius archived-invoices-count']"));






    }
}
