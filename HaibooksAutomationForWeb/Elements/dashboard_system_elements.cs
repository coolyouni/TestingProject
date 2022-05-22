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

        public IWebElement financial_overview_view_sales_link => driver.FindElement(By.XPath("//a[normalize-space()='View Sales ->']"));
        public IWebElement financial_overview_view_purchase_link => driver.FindElement(By.XPath(" //a[normalize-space()='View Purchases ->']"));
        public IWebElement financial_overview_view_Taxes_link => driver.FindElement(By.XPath("//a[normalize-space()='View Taxes ->']"));
        public IWebElement financial_overview_view_profit_link => driver.FindElement(By.XPath("//a[normalize-space()='View Profit ->']"));
        public IWebElement financial_overview_total_sales_value => driver.FindElement(By.XPath("(//*[@class='list-unstyled'])/li[2]/span"));
        public IWebElement create_new_invoice_dashboard => driver.FindElement(By.XPath("//div[@class='dropdown-menu context-menu show']//a[@id='link_create_new_invoice']//div[@class='icon-box']"));
        public IWebElement create_new_bill_dashboard => driver.FindElement(By.XPath("//div[@class='dropdown-menu context-menu show']//a[@id='link_create_new_bill']//img"));
        public IWebElement create_new_expenses_dashboard => driver.FindElement(By.XPath("//a[@id='link_create_new_expense']//div[@class='icon-box']"));
        public IWebElement create_new_Mileage_dashboard => driver.FindElement(By.XPath("//span[normalize-space()='Mileage']"));
        public IWebElement create_new_expenses_dashboard_1 => driver.FindElement(By.XPath("//div[@class='dropdown-menu context-menu show']//a[@id='link_create_new_expense']//div[@class='icon-box']"));
        public IWebElement create_new_contact_dashboard => driver.FindElement(By.XPath("//div[@class='dropdown-menu context-menu show']//a[@id='link_create_new_contact']//div[@class='icon-box']"));
        public IWebElement create_new_Mileage_dashboard_1 => driver.FindElement(By.XPath("//div[@class='dropdown-menu context-menu show']//a[@id='link_create_new_mileage']//div[@class='icon-box']"));
        public IWebElement financial_overivew_Fiscal_year => driver.FindElement(By.XPath("//a[@role='button'][normalize-space()='Fiscal Year'][1]"));
        public IWebElement financial_overivew_six_months => driver.FindElement(By.LinkText("6 Months"));
        public IWebElement financial_overivew_This_month => driver.FindElement(By.LinkText("This Month"));

        public IWebElement sales_Fiscal_year => driver.FindElement(By.XPath("//div[@class='card pie-chart sales-pie-chart-container mt-5']//a[@role='button'][normalize-space()='Fiscal Year']"));       
        public IWebElement sales_six_months => driver.FindElement(By.LinkText("6 Months"));
        public IWebElement sales_This_month => driver.FindElement(By.LinkText("This Month"));
        public IWebElement sales_pie_chart_containter => driver.FindElement(By.XPath("//div[@class='title']//span[contains(text(),'Sales')]"));

        public IWebElement sales_pie_chart_paid => driver.FindElement(By.XPath("//a[contains(text(),'Paid')][1]"));
        public IWebElement sales_pie_chart_unpaid => driver.FindElement(By.XPath("//a[contains(text(),'Unpaid')][1]"));
        public IWebElement sales_pie_chart_overdue => driver.FindElement(By.XPath("//a[contains(text(),'Overdue')][1]"));

        public IWebElement purchase_Fiscal_year => driver.FindElement(By.XPath("//div[@class='card pie-chart purchases-pie-chart-container mt-5']//a[@role='button'][normalize-space()='Fiscal Year']"));
        public IWebElement purchase_six_months => driver.FindElement(By.LinkText("6 Months"));
        public IWebElement purchase_This_month => driver.FindElement(By.LinkText("This Month"));
        public IWebElement purchase_pie_chart_containter => driver.FindElement(By.XPath("//div[@class='title']//span[contains(text(),'Purchases')]"));
        public IWebElement purchase_pie_chart_paid => driver.FindElement(By.XPath("//div[@class='card pie-chart purchases-pie-chart-container mt-5']//a[contains(text(),'Paid')]"));
        public IWebElement purchase_pie_chart_unpaid => driver.FindElement(By.XPath("//div[@class='card pie-chart purchases-pie-chart-container mt-5']//a[contains(text(),'Unpaid')]"));
        public IWebElement purchase_pie_chart_overdue => driver.FindElement(By.XPath("//div[@class='card pie-chart purchases-pie-chart-container mt-5']//a[contains(text(),'Overdue')]"));



        public IWebElement Expenses_Fiscal_year => driver.FindElement(By.XPath("//div[@class='card pie-chart expenses-pie-chart-container mt-5']//a[@role='button'][normalize-space()='Fiscal Year']"));
        public IWebElement Expenses_six_months => driver.FindElement(By.LinkText("6 Months"));
        public IWebElement Expenses_This_month => driver.FindElement(By.LinkText("This Month"));
        public IWebElement Expenses_pie_chart_containter => driver.FindElement(By.XPath("//div[@class='title']//span[contains(text(),'Expenses')]"));
        public IWebElement Expenses_pie_chart_MileageExpense => driver.FindElement(By.XPath("//span[contains(text(),'MileageExpense')][1]"));
        public IWebElement Expenses_pie_chart_purchases => driver.FindElement(By.XPath("//ul[@class='color']//span[contains(text(),'Purchases')]"));
        public IWebElement Expenses_pie_chart_Other => driver.FindElement(By.XPath("//span[contains(text(),'Other')][1]"));

        public IWebElement connect_new_account => driver.FindElement(By.XPath(" //a[normalize-space()='Connect New Account']"));
        public IWebElement show_all => driver.FindElement(By.XPath("//a[normalize-space()='Show all']"));        

        public IWebElement Default_bank_account => driver.FindElement(By.XPath("//*[contains(text(),'Default Bank Account')]"));

    }


}
