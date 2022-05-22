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

        public IWebElement sign_up_button => driver.FindElement(By.XPath("//a[normalize-space()='Sign up now']"));
        public IWebElement business_owner_btn => driver.FindElement(By.Id("businessOwnerOption"));
        public IWebElement business_adviser_btn => driver.FindElement(By.Id("businessAdviserOption"));
        //public IWebElement business_owner_btn => driver.FindElement(By.XPath("//*[@id='registerRoleContainer']/div/div[2]/div/label[1]"));
        //public IWebElement business_adviser_btn => driver.FindElement(By.XPath("//*[@id='registerRoleContainer']/div/div[2]/div/label[2]"));


        public IWebElement Next_btn => driver.FindElement(By.XPath("//button[normalize-space()='Next']"));
        public IWebElement first_name_txtbx => driver.FindElement(By.Id("registerFirstName"));
        public IWebElement last_name_txtbx => driver.FindElement(By.Id("registerLastName"));
        public IWebElement register_email_txtbx => driver.FindElement(By.Id("registerEmail"));
        public IWebElement regisgter_phone_country_code_drop_down => driver.FindElement(By.Id("registerPhoneCountryCode"));
        public IWebElement phone_no_search_placeholder => driver.FindElement(By.XPath("//input[@placeholder='Search']"));
        public IWebElement pakistan_phone_no_dropdown => driver.FindElement(By.Id("bs-select-1-169"));
        public IWebElement phone_no_txtbx => driver.FindElement(By.Id("registerPhoneNumber"));
        public IWebElement password_txtbx => driver.FindElement(By.Id("registerPassword"));
        public IWebElement confirm_pwd_txtbx => driver.FindElement(By.Id("registerPasswordConfirm"));
        public IWebElement consent_checkbox => driver.FindElement(By.Id("registerConsent"));
        public IWebElement Get_started_btn => driver.FindElement(By.XPath(" //button[normalize-space()='Get Started']"));
        public IWebElement Nearly_done => driver.FindElement(By.ClassName("text-success"));
        public IWebElement Activation_email => driver.FindElement(By.XPath("(//*[@class='mt-3'])/span/b"));
        public IWebElement search_textbox => driver.FindElement(By.Id("search"));
        public IWebElement Go_button => driver.FindElement(By.XPath("//button[@value='Search for public inbox for free']"));
        public IWebElement iframe_id => driver.FindElement(By.Id("html_msg_body"));
        public IWebElement subject_body => driver.FindElement(By.XPath("//td[normalize-space()='Activation Email']"));
        public IWebElement subject_body_forwading_email => driver.FindElement(By.XPath("//td[normalize-space()='FW: Activation Email']"));
        
        public IWebElement yes_its_me_lets_get_started_btn => driver.FindElement(By.XPath("//a[normalize-space()=\"Yes, it's me - let's get started!\"]"));
        public IWebElement limited_liability_company_type => driver.FindElement(By.XPath(" //span[normalize-space()='UK Limited Liability Company']"));
        public IWebElement uk_sole_trader_company_type => driver.FindElement(By.Id("soleTraderOption"));
        public IWebElement search_external_companies => driver.FindElement(By.Id("externalCompanies"));
        public IWebElement select_company_name => driver.FindElement(By.XPath("//a[normalize-space()='MCA ACCOUNTANTS LIMITED']"));
        public IWebElement select_company_name_1 => driver.FindElement(By.XPath("//a[normalize-space()='MACRO DECISIONS LLP']"));
        public IWebElement Final_step_get_started => driver.FindElement(By.CssSelector(".btn-primary"));
        public IWebElement Alert_intercom_tour_frame => driver.FindElement(By.XPath("//*[@id='intercom-container']/div/div/div/div/div[2]/span"));
        public IWebElement company_name_left_side => driver.FindElement(By.Id("select-mode"));
        public IWebElement haibooks_last_popup => driver.FindElement(By.XPath("//*[@id='intercom-container']/div/span/div/div/div/div[2]/div/div/span"));
        public IWebElement New_client => driver.FindElement(By.XPath("//a[normalize-space()='New Client']"));
        public IWebElement Add_business => driver.FindElement(By.XPath("//a[normalize-space()='Add Business']"));
        
    }
}
