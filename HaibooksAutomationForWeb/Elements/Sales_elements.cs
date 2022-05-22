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

        public IWebElement ALL_INVOICES_TAB => driver.FindElement(By.XPath("//a[normalize-space()='All Invoices']"));
        public IWebElement draft_TAB => driver.FindElement(By.XPath("//a[normalize-space()='Drafts']"));
        public IWebElement recurring_INVOICES_TAB => driver.FindElement(By.XPath("//li[@class='list-inline-item ']//a[contains(text(),'Recurring Invoices')]"));
        public IWebElement archived_TAB => driver.FindElement(By.XPath("//a[normalize-space()='Archived']"));

        public IWebElement view_total => driver.FindElement(By.XPath("//a[@id='sale_total']"));
        public IWebElement sales_overdue => driver.FindElement(By.XPath("//a[@id='sale_overdue']"));
        public IWebElement view_unpaid => driver.FindElement(By.XPath("//a[@id='sale_unpaid']"));
        public IWebElement view_paid => driver.FindElement(By.XPath("//a[@id='sale_paid']"));

        public IWebElement sales_add_new => driver.FindElement(By.XPath("//a[normalize-space()='Add New']"));
        public IWebElement sales_add_invoice => driver.FindElement(By.XPath("//a[normalize-space()='Add Invoice']"));
        public IWebElement sales_add_credit_note => driver.FindElement(By.XPath("//a[normalize-space()='Add Credit Note']"));

        public IWebElement salessearch_data_grid => driver.FindElement(By.XPath("//input[@aria-label='Search in data grid']"));
        public IWebElement export => driver.FindElement(By.XPath("//div[@aria-label='Export']//div[@class='dx-button-content']"));
        public IWebElement Filter => driver.FindElement(By.XPath("//span[normalize-space()='Filter']"));


        ////////////Draft Tab eleements
        
        public IWebElement draft_title => driver.FindElement(By.XPath("//span[@class='title']"));
        public IWebElement draft_count => driver.FindElement(By.XPath("//span[@class='badge badge-light radius draft-count']"));

        public IWebElement recurring_invoice_count => driver.FindElement(By.XPath("//span[@class='badge badge-light radius recurring-invoice-count']"));
        public IWebElement sales_archived_count => driver.FindElement(By.XPath("//span[@class='badge badge-light radius archived-invoices-count']"));

        




    }
}
