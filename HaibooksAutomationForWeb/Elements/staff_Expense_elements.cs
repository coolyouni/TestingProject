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

        public IWebElement staff_expnses_left_menu => driver.FindElement(By.XPath("//span[normalize-space()='Staff Expenses']"));
        public IWebElement all_expense_tab => driver.FindElement(By.XPath("//a[normalize-space()='All Expenses']"));
        public IWebElement awaiting_tab => driver.FindElement(By.XPath("//a[normalize-space()='Awaiting Payment']"));
        public IWebElement expense_tab_drafts => driver.FindElement(By.XPath("//a[normalize-space()='Drafts']"));

        public IWebElement expense_view_unpaid=> driver.FindElement(By.XPath("//a[normalize-space()='View Unpaid ->']"));
        public IWebElement expense_check_paid => driver.FindElement(By.XPath("//a[normalize-space()='Check Paid ->']"));
        public IWebElement expense_view_total => driver.FindElement(By.XPath("//a[normalize-space()='View Total ->']"));

        public IWebElement add_new_expense => driver.FindElement(By.XPath("//a[normalize-space()='Add New Expense']"));
        public IWebElement add_new_mileage=> driver.FindElement(By.XPath("//a[normalize-space()='Add New Mileage']"));
        public IWebElement awaiting_payment_count => driver.FindElement(By.XPath("//span[@class='badge badge-light radius awaiting-payment-count']"));
        public IWebElement expense_drafts_count => driver.FindElement(By.XPath(" //span[@class='badge badge-light radius draft-count']"));

        public IWebElement paid_by_drop_down => driver.FindElement(By.Id("createStaffExpense_paidByDropdown"));

        public IWebElement expense_number => driver.FindElement(By.XPath("//input[@id='document-number']"));

        public IWebElement price_total_amount_expense => driver.FindElement(By.XPath("//span[@class='price total-amount-text']"));

        public IWebElement staff_drop_down => driver.FindElement(By.Id("createStaffExpense_staffDropdown"));
        public IWebElement Mileage_staff_drop_down => driver.FindElement(By.Id("createMileage_staffInformationDropdown"));
        

        public IWebElement payments_tab_expense => driver.FindElement(By.XPath("//li[@data-module-expense='Payments']//a[@class='google-drive-opener']"));
        public IWebElement notes_tab_expense => driver.FindElement(By.XPath("//a[@class='google-drive-opener notes-tab-link']"));
        public IWebElement files_tab_expense => driver.FindElement(By.XPath("//li[@data-module-expense='Files']"));
        public IWebElement supplier => driver.FindElement(By.CssSelector("#supplier"));
        public IWebElement issue_date_expense => driver.FindElement(By.Id("123"));

        public IWebElement saved_expense_number => driver.FindElement(By.CssSelector("div:nth-child(1) > div:nth-child(4) > div:nth-child(1) > input:nth-child(2"));
        public IWebElement expense_status => driver.FindElement(By.XPath("//span[@class='badge badgeBig float-right']"));
        public IWebElement expense_file_count => driver.FindElement(By.XPath("//li[@data-module-expense='Files']//span[@class='badge badge-light']"));

        public IWebElement Mileage_file_count => driver.FindElement(By.XPath("//li[@data-module-mileage='Files']//span[@class='badge badge-light']"));
        public IWebElement expense_all_Files_label => driver.FindElement(By.XPath("//div[@class='dx-item-content dx-toolbar-item-content']//span[@class='title']"));
        public IWebElement expense_overview_tab => driver.FindElement(By.XPath("//a[normalize-space()='Expense Overview']"));

        //Add new Milage

        public IWebElement add_new_mileage_button => driver.FindElement(By.XPath("//a[normalize-space()='Add New Mileage']"));
        public IWebElement mileage_expense_number => driver.FindElement(By.XPath("//input[@id='mileage-document-number']"));
        public IWebElement ok_button => driver.FindElement(By.XPath("//button[normalize-space()='OK']"));
        public IWebElement currency => driver.FindElement(By.XPath("//small[@class='text-twilight-blue']"));

        //number of miles
        public IWebElement number_of_mileage => driver.FindElement(By.Id("mile-amount-input"));
        public IWebElement mileage_expense => driver.FindElement(By.Id("amount-input"));

        //vehicle drop down
        public IWebElement vehicle => driver.FindElement(By.Id("createMileage_vehicleDropdown"));
        public IWebElement recliam_vat_checkbox => driver.FindElement(By.Id("IsReclaimVatInput"));
        public IWebElement vehicle_engine_dropdown => driver.FindElement(By.Id("createMileage_engineDropdown"));
        public IWebElement mileage_description => driver.FindElement(By.Id("description-input"));

        //mileage tab
        public IWebElement mileage_overview_tab => driver.FindElement(By.XPath("//a[normalize-space()='Mileage Overview']"));
        public IWebElement mileage_payments_tab => driver.FindElement(By.XPath("//li[@data-module-mileage='Payments']"));
        public IWebElement mileage_notes_tab => driver.FindElement(By.XPath("//a[@class='google-drive-opener notes-tab-link']"));
        public IWebElement mileage_files_tab => driver.FindElement(By.XPath("//li[@data-module-mileage='Files']//a[@class='google-drive-opener']"));

        //Saved mileage values

        public IWebElement staff_saved_value => driver.FindElement(By.Id("staff-value"));
        public IWebElement issue_date_saved_value => driver.FindElement(By.Id("date-value"));
        public IWebElement mileage_number_saved_value => driver.FindElement(By.Id("document-number-value"));
        public IWebElement currency_saved_value => driver.FindElement(By.XPath("//small[normalize-space()='GBP']"));

        public IWebElement numberof_miles_saved_value => driver.FindElement(By.Id("numberof"));
        public IWebElement mileage_expense_saved_value => driver.FindElement(By.Id("amount-value"));
        public IWebElement vehicle_saved_value => driver.FindElement(By.Id("vehicle-value"));
        public IWebElement engine_saved_value => driver.FindElement(By.Id("engine-value"));
        public IWebElement description_saved_value => driver.FindElement(By.Id("description-value"));


        public IWebElement mileage_created => driver.FindElement(By.XPath("//b[normalize-space()='Mileage Created']"));
        public IWebElement mileage_status => driver.FindElement(By.XPath("//span[@class='badge badgeBig float-right']"));
        //public IWebElement mileage_number_showint_top => driver.FindElement(By.XPath("//div[@class='sticky']//ul[@class='list-unstyled float-left']//li[1]"));
        public IWebElement mileage_status_showing_at_top => driver.FindElement(By.XPath("//span[contains(text(),'Unpaid')]"));
        public IWebElement staff_label => driver.FindElement(By.XPath("//label[normalize-space()='Staff']"));
        

    }
}
