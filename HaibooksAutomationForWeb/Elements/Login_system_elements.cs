using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.TestCases;
using OpenQA.Selenium;

namespace HaibooksAutomationForWeb.Elements
{
   public partial class system_elements: Baseclass
    {
        public system_elements(IWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement signin_button => driver.FindElement(By.XPath("//button[normalize-space()='Sign In']"));
        public IWebElement email_adress_textbox => driver.FindElement(By.Id("loginEmail"));
        public IWebElement password_textbox => driver.FindElement(By.Id("loginPassword"));
        public IWebElement captcha_label => driver.FindElement(By.XPath("//label[@id='recaptcha-anchor-label']"));
        public IWebElement login_email_validation => driver.FindElement(By.Id("loginEmailValidation"));
        public IWebElement login_pwd_validation => driver.FindElement(By.Id("loginPasswordValidation"));
        public IWebElement create_new_left_side => driver.FindElement(By.XPath("//span[normalize-space()='Create New']"));
        public IWebElement create_new_dashboard => driver.FindElement(By.XPath("//a[@class='btn btn-primary btn-circle'][normalize-space()='Create New']"));       
        public IWebElement alert_session_out => driver.FindElement(By.XPath("//div[@role='alert']/b"));
        public IWebElement receipt_left_menu => driver.FindElement(By.Id("nav_link_receipts"));
        public IWebElement sales_left_side => driver.FindElement(By.Id("nav_link_sales"));
        public IWebElement invoices_left_side => driver.FindElement(By.Id("sub_nav_link_invoices"));
        public IWebElement recurring_invoices_left_side => driver.FindElement(By.Id("sub_nav_link_recurring_invoices"));
        public IWebElement archived_invoices_left_side => driver.FindElement(By.Id("sub_nav-link_archived_invoices"));
        




    }
}
