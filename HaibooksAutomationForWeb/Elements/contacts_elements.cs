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

        public IWebElement create_new_contact => driver.FindElement(By.Id("button_add_new_contact"));
        public IWebElement add_contact => driver.FindElement(By.XPath(" //a[contains(text(),'Add Contact')]"));
       
        public IWebElement select_contact => driver.FindElement(By.XPath("//div[contains(text(),'Select Contact')]"));
        public IWebElement select_contact_drop_down_option => driver.FindElement(By.Id("createInvoice_contactInformationDropdown"));
        public IWebElement select_contact_drop_down_option_bill => driver.FindElement(By.Id("select-contact"));
        

        public IWebElement select_business_drop_down => driver.FindElement(By.Id("select-mode"));
        public IWebElement select_contact_drop_down_value => driver.FindElement(By.XPath("//*[@id='createInvoice_contactInformationDropdown']/option[3]"));
        public IWebElement select_contact_drop_down_value_bill => driver.FindElement(By.XPath("//*[@id='select-contact']/option[3]"));
        public IWebElement issue_date => driver.FindElement(By.XPath("//div[@id='issue-date']//input[@role='combobox']"));
        public IWebElement issue_date_mileage => driver.FindElement(By.XPath("//input[@class='dx-texteditor-input']"));
        
        public IWebElement due_date => driver.FindElement(By.XPath("//div[@id='due-date']//input[@role='combobox']"));
        public IWebElement invoice_number_txtbox => driver.FindElement(By.Id("bill-document-number"));

        public IWebElement Terms_drop_down => driver.FindElement(By.Id("termsDropdown"));
        public IWebElement invoice_term_days => driver.FindElement(By.XPath("//input[@id='invoice-terms-days']"));
        public IWebElement bill_term_days => driver.FindElement(By.XPath("//input[@id='bill-terms-days']"));
        
        //Contact information Grid textbox        
        public IWebElement Contact_information_expand_collapsed => driver.FindElement(By.XPath("//button[normalize-space()='Contact Information']//img"));
        public IWebElement Contact_information_grid => driver.FindElement(By.XPath("//button[normalize-space()='Contact Information']"));
        public IWebElement business_name_textbox => driver.FindElement(By.Id("BusinessName"));
        public IWebElement ContactPerson_textbox => driver.FindElement(By.Id("ContactPerson"));
        public IWebElement Email_textbox => driver.FindElement(By.Id("Email"));
        public IWebElement Telephone_textbox => driver.FindElement(By.Id("Telephone"));
        public IWebElement Mobile_textbox => driver.FindElement(By.Id("Mobile"));
        public IWebElement Website_textbox => driver.FindElement(By.Id("Website"));
        public IWebElement Fax_textbox => driver.FindElement(By.Id("Fax"));


        //Address Grid
        public IWebElement adress_expand_collapsed => driver.FindElement(By.XPath("//button[normalize-space()='Address']//img"));
        public IWebElement adress_grid => driver.FindElement(By.XPath("//button[normalize-space()='Address']"));
        
        public IWebElement Building_textbox => driver.FindElement(By.Id("Building"));
        public IWebElement Street_textbox => driver.FindElement(By.Id("Street"));
        public IWebElement CityOrTown_textbox => driver.FindElement(By.Id("CityOrTown"));
        public IWebElement PostCode_textbox => driver.FindElement(By.Id("PostCode"));
        public IWebElement CountryCode_textbox => driver.FindElement(By.Id("CountryCode"));
        public IWebElement region_textbox => driver.FindElement(By.Id("region"));

        //Financial Details
        public IWebElement financial_details_collapsed => driver.FindElement(By.XPath("//button[normalize-space()='Financial Details']//img"));
        public IWebElement financial_details_grid => driver.FindElement(By.XPath("//button[normalize-space()='Financial Details']"));
        public IWebElement vat_reg_no_textbox => driver.FindElement(By.Id("VatRegistrationNumber"));

        //Terms details
        public IWebElement Terms_details_collapsed => driver.FindElement(By.XPath("//button[normalize-space()='Terms Details']//img"));
        public IWebElement Terms_details_grid => driver.FindElement(By.XPath("//button[normalize-space()='Terms Details']"));

        public IWebElement add_contact_button => driver.FindElement(By.XPath("//button[normalize-space()='Add Contact']"));
        public IWebElement cancel => driver.FindElement(By.XPath("//button[normalize-space()='Cancel']"));       
        

        public IWebElement all_contact_tab => driver.FindElement(By.Id("tab_all_contacs"));
        public IWebElement edit_contacts => driver.FindElement(By.CssSelector(".list-inline-item:nth-child(1) img"));


        //Add contacts
        public IWebElement add_contact_business_full_name => driver.FindElement(By.Id("contact-modal-name"));
        public IWebElement add_contact_email => driver.FindElement(By.Id("contact-modal-email"));
        public IWebElement add_contact_building_nu => driver.FindElement(By.Id("contact-modal-building"));
        public IWebElement add_contact_street => driver.FindElement(By.Id("contact-modal-street"));
        public IWebElement add_contact_city => driver.FindElement(By.Id("contact-modal-city"));
        public IWebElement add_contact_post_code => driver.FindElement(By.Id("contact-modal-postal-code"));
        public IWebElement add_contact_region => driver.FindElement(By.Id("contact-modal-county"));


        public IWebElement Save_button_any => driver.FindElement(By.XPath("//button[contains(.,'Save')]"));
        public IWebElement Save_button_quick_check => driver.FindElement(By.XPath("//button[@type='button'][normalize-space()='Save']"));

        public IWebElement cancel_button => driver.FindElement(By.XPath("//button[contains(.,'Cancel')]"));

        public IWebElement All_contact_tab => driver.FindElement(By.XPath("//a[@id='tab_all_contacs']"));
        public IWebElement All_customers_tab => driver.FindElement(By.XPath(" //a[@id='tab_customers']"));
        public IWebElement All_suppliers_tab => driver.FindElement(By.XPath("//a[@id='tab_suppliers']"));

        public IWebElement Groups_drop_down => driver.FindElement(By.XPath("//a[normalize-space()='Groups']"));
        public IWebElement recent_contacts => driver.FindElement(By.XPath("//*[contains(text(),'Recent Contacts')]"));
        public IWebElement Active_contacts => driver.FindElement(By.XPath("//div[@class='dx-item-content dx-toolbar-item-content']//a[@class='btnActiveContacts nav-link active']"));      
        public IWebElement Active_contacts_count => driver.FindElement(By.XPath("//div[@class='dx-item-content dx-toolbar-item-content']//a[@class='btnActiveContacts nav-link active']//span[2]"));
        public IWebElement inActive_contacts => driver.FindElement(By.XPath("//div[@class='dx-item-content dx-toolbar-item-content']//span[contains(text(),'Inactive')]"));
        public IWebElement inActive_contacts_count => driver.FindElement(By.XPath("//div[@class='dx-item-content dx-toolbar-item-content']//span[@class='badge badge-light InActiveContactCount']"));
        



    }
}
