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

        public IWebElement go_back_to_haibooks_leftmenu => driver.FindElement(By.XPath("//a[normalize-space()='Go back to Haibooks']"));
        public IWebElement dashboard_leftmenu => driver.FindElement(By.Id("nav_link_dashboard"));
        public IWebElement contacts_leftmenu => driver.FindElement(By.Id("nav_link_contacts"));
        public IWebElement contact_link_left_menu => driver.FindElement(By.Id("nav_link_contacts"));
        public IWebElement System_settings_left_menu => driver.FindElement(By.XPath("//span[normalize-space()='System Settings']"));
        public IWebElement Receipts_left_menu => driver.FindElement(By.XPath(" //span[normalize-space()='Receipts']"));
       
        public IWebElement select_account_drop_down => driver.FindElement(By.XPath("//div[contains(text(),'Select Account')]"));

        public IWebElement select_account_drop_down_1 => driver.FindElement(By.XPath("//button[@title='Select Account']//div[@class='filter-option-inner']"));
        public IWebElement chart_of_account => driver.FindElement(By.Id("bill-item-0-chartOfAccounts"));
        //public IWebElement unit_cost_1 => driver.FindElement(By.CssSelector("#bill-item-0 .mini"))
        //
        public IWebElement click_on_sales_first_drop_down => driver.FindElement(By.XPath("//select[@id='bill-item-0-chartOfAccounts']/optgroup[@label='Sales']/option"));
        public IWebElement click_on_bills_first_drop_down => driver.FindElement(By.XPath("//select[@id='bill-item-0-chartOfAccounts']/optgroup[@label='Cost of Goods Sold']/option"));
       

        public IWebElement vat_drop_down => driver.FindElement(By.Id("bill-item-0-vatRates"));
        public IWebElement unit_cost => driver.FindElement(By.XPath("//div[@id='bill-item-0']/div/div/div[2]/div/input"));
        public IWebElement quantity => driver.FindElement(By.XPath("//div[@id='bill-item-0']/div/div/div[3]/div/input"));
        public IWebElement vat_total_1 => driver.FindElement(By.XPath("//div[@id='bill-item-0']/div/div/div[5]/div/input"));
        public IWebElement vat_total => driver.FindElement(By.XPath("//div[@id='bill-item-0']//div[@class='box vat-column']//input[@placeholder='Value']"));
        //public IWebElement total_amount_1 => driver.FindElement(By.XPath("//div[@id='bill-item-0']/div/div/div[6]/div/input"));
        public IWebElement total_amount => driver.FindElement(By.XPath(" //div[@id='bill-item-0']//div[@class='form-group text-right']//input[@placeholder='Value']"));
        
       // public IWebElement price_bill_total => driver.FindElement(By.XPath("//span[@class='price bill-total-search-class']"));
        public IWebElement price_bill_total => driver.FindElement(By.XPath("//span[@class='price bill-total-search-class']"));
        public IWebElement price_bill_total_in_bills => driver.FindElement(By.XPath("//span[@class='price bill-total-amount']"));
        
        public IWebElement subtotal => driver.FindElement(By.XPath("//td[@class='value bill-items-summary-subtotal-search-class']"));
        public IWebElement tax => driver.FindElement(By.XPath("//td[@class='value bill-items-summary-tax-search-class']"));
        public IWebElement Total => driver.FindElement(By.XPath("//td[@class='value bill-items-summary-total-search-class']"));
        public IWebElement amount_paid => driver.FindElement(By.XPath("//td[@class='value bill-items-summary-amountpaid-search-class']"));
        public IWebElement amount_due => driver.FindElement(By.XPath(" //td[@class='value bill-amount-due-search-class']"));
        public IWebElement bill_comment => driver.FindElement(By.XPath("//textarea[@id='bill-comment']"));
        public IWebElement bill_comment_for_bill => driver.FindElement(By.XPath("//textarea[@id='comment']"));
        
        public IWebElement description => driver.FindElement(By.XPath(" //div[@id='bill-item-0']//textarea[@placeholder='Description']"));
        public IWebElement saved_and_approve_btn => driver.FindElement(By.XPath("//a[normalize-space()='Save & Approve']"));


        /////////////////////////////view invoice Tab////////////////////////////////////

        public IWebElement invoice_overview_tab => driver.FindElement(By.XPath("//a[@class='tab-item overview-tab']"));
        public IWebElement payments_tab => driver.FindElement(By.XPath("//li[@data-module-invoice='Payments']//a[@class='tab-item']"));
        public IWebElement payments_tab_bill => driver.FindElement(By.XPath(" //li[@data-module-bill='Payments']//a[@class='tab-item']"));

       

        public IWebElement notes_tab => driver.FindElement(By.XPath("//li[@data-module-invoice='Notes']//a[@class='tab-item']"));
        public IWebElement notes_tab_bill => driver.FindElement(By.XPath("//a[@class='tab-item note-tab']"));        
        public IWebElement Files_tab => driver.FindElement(By.XPath("//li[@data-module-invoice='Files']//a[@class='tab-item']"));
        public IWebElement Files_tab_for_bills => driver.FindElement(By.XPath("//li[@data-module-invoice='Files']//a[@class='tab-item']"));
        public IWebElement Files_tab_bill => driver.FindElement(By.XPath("//li[@data-module-bill='Files']//a[@class='tab-item']"));
        

        public IWebElement invoice_payment_count => driver.FindElement(By.XPath("//span[@id='invoicePaymentsCount']"));
        public IWebElement invoice_notes_count => driver.FindElement(By.XPath("//span[@id='invoiceNotesCount']"));
        public IWebElement invoice_file_count => driver.FindElement(By.XPath("//span[@id='invoice-tab-file-count']"));
        public IWebElement bill_file_count => driver.FindElement(By.XPath("//span[@id='bill-tab-file-count']"));
        
        public IWebElement invoice_number => driver.FindElement(By.XPath("//span[@class='text-twilight-blue']"));
        public IWebElement invoice_status => driver.FindElement(By.XPath("//span[@id='badgeStatus']"));

        public IWebElement contact_saved => driver.FindElement((By.CssSelector(".read-input > a > span")));

        public IWebElement invoice_detail_issue_date => driver.FindElement(By.Id("issueDateSpan"));

        public IWebElement invoice_detail_due_date => driver.FindElement(By.XPath("//span[@class='ml-4']"));
        public IWebElement invoice_detail_custom => driver.FindElement(By.XPath("//span[normalize-space()='Custom']"));
        public IWebElement invoice_detail_custom_term_days => driver.FindElement((By.CssSelector(".col-md-6:nth-child(2) .read-input:nth-child(2)")));
        public IWebElement invoice_detail_invoice_number => driver.FindElement((By.CssSelector(".row:nth-child(2) .read-input")));
        public IWebElement invoice_detail_account_type => driver.FindElement((By.CssSelector(".cell > .box:nth-child(1) > span")));
        public IWebElement invoice_detail_unit_cost => driver.FindElement((By.CssSelector(".cell > .box:nth-child(2) > span")));
        public IWebElement invoice_detail_quanitity => driver.FindElement((By.CssSelector(".cell > .box:nth-child(3) > span")));
        public IWebElement invoice_detail_vat_rate => driver.FindElement((By.CssSelector(".cell > .box:nth-child(4) > span")));
        public IWebElement invoice_detail_vat_total => driver.FindElement((By.CssSelector(".cell > .box:nth-child(5) > span")));
        public IWebElement invoice_detail_total_amount => driver.FindElement((By.CssSelector(".cell > .box:nth-child(6) > span")));
        public IWebElement invoice_detail_Subtotal => driver.FindElement((By.CssSelector("table:nth-child(1) tr:nth-child(1) > .value")));
        public IWebElement invoice_detail_Tax => driver.FindElement((By.CssSelector("table:nth-child(1) tr:nth-child(2) > .value")));
        public IWebElement invoice_detail_Total => driver.FindElement((By.CssSelector("table:nth-child(3) tr:nth-child(1) > .value")));
        public IWebElement invoice_detail_amount_paid => driver.FindElement((By.CssSelector("table:nth-child(3) tr:nth-child(2) > .value")));
        public IWebElement invoice_detail_amount_due => driver.FindElement((By.CssSelector("table:nth-child(5) .value")));
        public IWebElement invoice_detail_comment => driver.FindElement((By.Id("comment")));
        public IWebElement invoice_detail_description => driver.FindElement((By.Id("Description")));
        public IWebElement invoice_detail_invoice_status => driver.FindElement((By.Id("statusCardText")));
        public IWebElement invoice_detail_invoice_created => driver.FindElement((By.CssSelector("span > b")));
        public IWebElement invoice_detail_invoice_created_date_time => driver.FindElement((By.CssSelector(".date")));
        public IWebElement invoice_detail_price => driver.FindElement((By.CssSelector(".price")));

        //Attaching files
        public IWebElement attach_files => driver.FindElement(By.XPath("//a[normalize-space()='+ Attach files']"));
        public IWebElement upload_tab => driver.FindElement((By.Id("home-tab")));
        public IWebElement attach_from_library_tab => driver.FindElement((By.Id("profile-tab")));
        public IWebElement browse_file_upload => driver.FindElement((By.Id("upload")));
        public IWebElement add_files_button => driver.FindElement((By.Id("addFilesButton")));
        public IWebElement file_attached => driver.FindElement((By.XPath("//span[@class='name']")));
        public IWebElement All_files_label => driver.FindElement((By.XPath("//span[@class='title']")));
        public IWebElement save_button => driver.FindElement((By.XPath("//button[@role='button']")));
      

        //Items display on page

        public IWebElement itmes_50_display_on_page => driver.FindElement((By.XPath("//div[@aria-label='Display 50 items on page']")));
        public IWebElement itmes_20_display_on_page => driver.FindElement((By.XPath(" //div[@aria-label='Display 20 items on page']")));
        public IWebElement itmes_10_display_on_page => driver.FindElement((By.XPath(" //div[@aria-label='Display 10 items on page']")));
        public IWebElement itmes_5_display_on_page => driver.FindElement((By.XPath("//div[@aria-label='Display 5 items on page']")));


        public IWebElement number_of_pages => driver.FindElement((By.XPath("//div[@class='dx-info']")));



        //Page number
        public IWebElement page_1 => driver.FindElement((By.XPath("//div[@aria-label='Page 1']")));
        public IWebElement page_2 => driver.FindElement((By.XPath("//div[@aria-label='Page 2']")));
        public IWebElement page_3 => driver.FindElement((By.XPath("//div[@aria-label='Page 3']")));
        public IWebElement page_4 => driver.FindElement((By.XPath("//div[@aria-label='Page 4']")));
        public IWebElement page_5 => driver.FindElement((By.XPath("//div[@aria-label='Page 5']")));
        public IWebElement page_6 => driver.FindElement((By.XPath("//div[@aria-label='Page 6']")));
        public IWebElement page_7 => driver.FindElement((By.XPath("//div[@aria-label='Page 7']")));
        public IWebElement page_8 => driver.FindElement((By.XPath("//div[@aria-label='Page 8']")));
        public IWebElement page_9 => driver.FindElement((By.XPath("//div[@aria-label='Page 9']")));
        public IWebElement page_10 => driver.FindElement((By.XPath("//div[@aria-label='Page 10']")));

        //Add filters
        public IWebElement Add_filters => driver.FindElement((By.XPath("//span[normalize-space()='Add Filters']")));
        public IWebElement export_button => driver.FindElement((By.XPath("//span[normalize-space()='Export']")));
        public IWebElement upload_icon => driver.FindElement((By.XPath("//i[@class='dx-icon dx-icon-upload']")));


        //Add item
        public IWebElement add_item => driver.FindElement((By.XPath("//button[normalize-space()='Add Item']")));


        //Searchbox
        public IWebElement searchbox => driver.FindElement((By.Id("input_search_0")));
        










    }
}
