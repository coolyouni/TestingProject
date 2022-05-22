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

        public IWebElement acccounting_left_menu => driver.FindElement(By.Id("nav_link_accounting"));
        public IWebElement chart_of_accounts_left_side => driver.FindElement(By.XPath(" //a[normalize-space()='Chart of Accounts']"));
        public IWebElement Dividends_left_side => driver.FindElement(By.XPath("//a[normalize-space()='Dividends']"));
        public IWebElement fixed_assets_left_side => driver.FindElement(By.XPath("//a[@id='nav_link_fixed_assets']"));
        public IWebElement journals_left_side => driver.FindElement(By.XPath("//a[@id='nav_link_journals']"));

        public IWebElement All_accounts_tab => driver.FindElement(By.XPath("//a[normalize-space()='All Accounts']"));
        public IWebElement Assets_tab => driver.FindElement(By.XPath("//a[normalize-space()='Assets']"));
        public IWebElement Liabilities_tab => driver.FindElement(By.XPath("//a[normalize-space()='Liabilities']"));
        public IWebElement Equity_tab => driver.FindElement(By.XPath("//a[normalize-space()='Equity']"));
        public IWebElement Revenue_tab => driver.FindElement(By.XPath("//a[normalize-space()='Revenue']"));
        public IWebElement Expenses_tab => driver.FindElement(By.XPath("//li[@class='list-inline-item ']//a[contains(text(),'Expenses')]"));
        public IWebElement Archived_tab => driver.FindElement(By.XPath("//a[normalize-space()='Archived']"));

        public IWebElement Dividends_label => driver.FindElement(By.XPath("//span[normalize-space()='Dividends']"));
        public IWebElement all_Dividends_label => driver.FindElement(By.XPath("//div[@class='dx-item-content dx-toolbar-item-content']//span[@class='title']"));
        public IWebElement all_Dividends_count => driver.FindElement(By.XPath("//div[@class='dx-item-content dx-toolbar-item-content']//span[@class='badge badge-light txtCount']"));
        public IWebElement no_data_found_message => driver.FindElement(By.XPath("//span[@class='dx-datagrid-nodata']"));
        public IWebElement filter => driver.FindElement(By.XPath("//span[@class='dx-button-text']"));
        public IWebElement filter_icon => driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-filter']"));
        public IWebElement add_Dividend_button => driver.FindElement(By.XPath("//a[normalize-space()='Add Dividend']"));

        //Add Dividend
        public IWebElement profilt_available_label => driver.FindElement(By.XPath("//label[normalize-space()='Profit Available to be declared as dividends']"));
        public IWebElement txtProfitAvailable => driver.FindElement(By.Id("txtProfitAvailable"));
        public IWebElement shareholder_label => driver.FindElement(By.XPath("//label[normalize-space()='Shareholder']"));        
        public IWebElement shareholder_drop_down => driver.FindElement(By.XPath("//div[contains(text(),'Nothing selected')]"));
        public IWebElement Amount => driver.FindElement(By.Id("txtAmount"));
        public IWebElement account_label => driver.FindElement(By.XPath(" //label[normalize-space()='Account']"));       
        public IWebElement Account => driver.FindElement(By.Id("ddBankAccount"));
        public IWebElement document_number => driver.FindElement(By.Id("txtDocumentNumber"));
        public IWebElement description_dividend => driver.FindElement(By.Id("txtDescription"));
        public IWebElement issue_date_dividends => driver.FindElement(By.XPath("//input[@class='dx-texteditor-input']"));
        public IWebElement shareholder_drop_down_select => driver.FindElement(By.Id("ddShareHolder"));
        public IWebElement description_row => driver.FindElement(By.XPath("//div[@class='dx-datagrid-rowsview dx-datagrid-nowrap']/div/table/tbody//td[4]"));
        

        //Fixed Assets
        public IWebElement fixed_assets_label => driver.FindElement(By.XPath("//span[normalize-space()='Fixed Assets']"));
        public IWebElement Acquired_assets_tab => driver.FindElement(By.XPath("//div[@id='acquiredAssetsGrid']//span[contains(text(),'Acquired Assets')]"));
        public IWebElement Acquired_assets_count => driver.FindElement(By.XPath("//div[@id='acquiredAssetsGrid']//span[@class='badge badge-light nav-link acquired-assets-count']"));        
        public IWebElement Disposed_assets_tab => driver.FindElement(By.XPath("//div[@id='disposedAssetsGrid']//span[contains(text(),'Disposed Assets')]"));      
        public IWebElement Disposed_assets_count => driver.FindElement(By.CssSelector("div[id = 'acquiredAssetsGrid'] span[class='badge badge-light disposed-assets-count']"));

        //journals 
        public IWebElement jounrals_label => driver.FindElement(By.XPath("//h4[normalize-space()='Journals']"));
        public IWebElement posted_tab => driver.FindElement(By.XPath("//a[normalize-space()='Posted']"));
        public IWebElement drafts_tab_journals => driver.FindElement(By.XPath("//a[normalize-space()='Drafts']"));
        public IWebElement archived_tab_journals => driver.FindElement(By.XPath("//a[normalize-space()='Archived']"));

        public IWebElement Add_journal_button => driver.FindElement(By.XPath("//a[normalize-space()='Add Journal']"));
        public IWebElement Add_opening_balance_button => driver.FindElement(By.XPath("//a[normalize-space()='Add Opening Balance']"));

        //Add journal label
        public IWebElement add_journal_label => driver.FindElement(By.XPath("//span[@class='text-twilight-blue page-title-search-class']"));
        public IWebElement document_number_journal => driver.FindElement(By.XPath("//input[@id='DocumentNumberInput']"));
        public IWebElement reference_textarea => driver.FindElement(By.XPath("//textarea[@id='refenceInput']"));
        public IWebElement VATTaxSettingDropDown => driver.FindElement(By.Id("VATTaxSettingDropDown"));
        public IWebElement click_on_journals_first_drop_down => driver.FindElement(By.XPath("//select[@id='journal-item-0-chartOfAccounts']/optgroup[@label='Sales']/option"));
        public IWebElement click_on_journals_second_drop_down => driver.FindElement(By.XPath("//select[@id='journal-item-1-chartOfAccounts']/optgroup[@label='Cost of Goods Sold']/option"));
        public IWebElement item_desription_1 => driver.FindElement(By.XPath("(//input[@placeholder='Add Item Description'])[1]"));
        public IWebElement item_desription_2 => driver.FindElement(By.XPath("(//input[@placeholder='Add Item Description'])[2]"));


        //Account type
        public IWebElement account_type_journals => driver.FindElement(By.Id("journal-item-0-chartOfAccounts"));
        public IWebElement account_type_journals_1 => driver.FindElement(By.Id("journal-item-1-chartOfAccounts"));

        //Add item description

        public IWebElement item_description_journals => driver.FindElement(By.XPath("//div[@id='journal-items-container']/div[1]/div[2]/div[1]"));

        public IWebElement debit_journals => driver.FindElement(By.XPath("//div[@id='journal-items-container']/div[1]/div[3]/div[1]"));
        public IWebElement credit_journals => driver.FindElement(By.XPath("//div[@id='journal-items-container']/div[1]/div[4]/div[1]"));
        public IWebElement item_description_journals_1 => driver.FindElement(By.XPath("//div[@id='journal-items-container']/div[2]/div[2]/div[1]"));
        public IWebElement debit_journals_1 => driver.FindElement(By.XPath("//div[@id='journal-items-container']/div[2]/div[3]/div[1]"));
        public IWebElement credit_journals_1 => driver.FindElement(By.XPath("//div[@id='journal-items-container']/div[2]/div[4]/div[1]"));

        //Vat Rate
        public IWebElement vat_rate_drop_down1 => driver.FindElement(By.Id("journal-item-0-vatRates"));
        public IWebElement vat_rate_drop_down2 => driver.FindElement(By.Id("journal-item-1-vatRates"));
        
        //Debit or credit
        public IWebElement credit_1 => driver.FindElement((By.XPath("//div[@id='journal-items-container']//div[1]//div[5]//div[1]//input[1]")));
        public IWebElement credit_2 => driver.FindElement((By.XPath("//*[@id='journal-items-container']/div[2]/div[5]/input")));
        public IWebElement debit_2 => driver.FindElement((By.XPath("//div[@id='journal-items-container']//div[2]//div[4]//div[1]//input[1]")));
        
        //Total
        public IWebElement total => driver.FindElement((By.XPath("//td[normalize-space()='Total']")));
        public IWebElement debit_total_journals => driver.FindElement((By.XPath("//td[@class='value journal-items-debit-total-search-class']")));
        public IWebElement credit_total_journals => driver.FindElement((By.XPath("//td[@class='value journal-items-credit-total-search-class']")));
        public IWebElement difference => driver.FindElement((By.XPath("//td[normalize-space()='Difference']")));
        public IWebElement items_difference_journals => driver.FindElement((By.XPath("//td[@class='value journal-items-summary-diffrence-search-class']")));

        public IWebElement cancel_journals => driver.FindElement(By.XPath("//a[normalize-space()='Cancel']"));


        //public IWebElement draft_TAB => driver.FindElement(By.XPath("//a[normalize-space()='Drafts']"));
        //public IWebElement recurring_INVOICES_TAB => driver.FindElement(By.XPath("//li[@class='list-inline-item ']//a[contains(text(),'Recurring Invoices')]"));
        //public IWebElement archived_TAB => driver.FindElement(By.XPath("//a[normalize-space()='Archived']"));

        //public IWebElement view_total => driver.FindElement(By.XPath("//a[@id='sale_total']"));
        //public IWebElement sales_overdue => driver.FindElement(By.XPath("//a[@id='sale_overdue']"));
        //public IWebElement view_unpaid => driver.FindElement(By.XPath("//a[@id='sale_unpaid']"));
        //public IWebElement view_paid => driver.FindElement(By.XPath("//a[@id='sale_paid']"));

        //public IWebElement sales_add_new => driver.FindElement(By.XPath("//a[normalize-space()='Add New']"));
        //public IWebElement sales_add_invoice => driver.FindElement(By.XPath("//a[normalize-space()='Add Invoice']"));
        //public IWebElement sales_add_credit_note => driver.FindElement(By.XPath("//a[normalize-space()='Add Credit Note']"));

        //public IWebElement salessearch_data_grid => driver.FindElement(By.XPath("//input[@aria-label='Search in data grid']"));
        //public IWebElement export => driver.FindElement(By.XPath("//div[@aria-label='Export']//div[@class='dx-button-content']"));
        //public IWebElement Filter => driver.FindElement(By.XPath("//span[normalize-space()='Filter']"));


        //////////////Draft Tab eleements

        //public IWebElement draft_title => driver.FindElement(By.XPath("//span[@class='title']"));
        //public IWebElement draft_count => driver.FindElement(By.XPath("//span[@class='badge badge-light radius draft-count']"));

        //public IWebElement recurring_invoice_count => driver.FindElement(By.XPath("//span[@class='badge badge-light radius recurring-invoice-count']"));
        //public IWebElement sales_archived_count => driver.FindElement(By.XPath("//span[@class='badge badge-light radius archived-invoices-count']"));






    }
}
