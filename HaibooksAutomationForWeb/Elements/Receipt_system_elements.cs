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
        public IWebElement Add_receipt_button => driver.FindElement(By.XPath("//a[normalize-space()='Add Receipt']"));
        public IWebElement All_receipts_count => driver.FindElement(By.XPath("//*[@id='allReceiptsGridButton']/span[2]"));
        public IWebElement All_receipts_count_1 => driver.FindElement(By.XPath("//li[@class='nav-item']//a[@id='processingGridButton']/span[2]"));      
        public IWebElement Receipt_processing_count => driver.FindElement(By.XPath("//div[@class='dx-item-content dx-toolbar-item-content']//span[@class='badge badge-light processing-filter-count-search-class']"));
        public IWebElement Receipt_toreview_count => driver.FindElement(By.XPath("//div[@class='dx-item-content dx-toolbar-item-content']//span[@class='badge badge-light toreview-filter-count-search-class']"));
        public IWebElement Receipt_reviewed_count => driver.FindElement(By.XPath("//div[@class='dx-item-content dx-toolbar-item-content']//span[@class='badge badge-light reviewed-filter-count-search-class']"));
        public IWebElement Receipt_archived_count => driver.FindElement(By.XPath(" //div[@class='dx-item-content dx-toolbar-item-content']//span[@class='badge badge-light archived-filter-count-search-class']"));
        public IWebElement uploading_success_message => driver.FindElement(By.Id("success-messagebox-message"));
        public IWebElement invalid_file_type_message => driver.FindElement(By.XPath("//div[contains(@id,'message')]"));

        //div[contains(@id,'test')]

        // public IWebElement Receipt_processing_count => driver.FindElement(By.XPath("//span[@class='badge badge-light processing-filter-count-search-class']"));
        // public IWebElement Receipt_toreview_count => driver.FindElement(By.XPath("//span[@class='badge badge-light toreview-filter-count-search-class']"));
        //public IWebElement Receipt_reviewed_count => driver.FindElement(By.XPath("//span[@class='badge badge-light reviewed-filter-count-search-class']"));
        // public IWebElement Receipt_archived_count => driver.FindElement(By.XPath("//span[@class='badge badge-light archived-filter-count-search-class']"));

        //Tab Processing
        public IWebElement Processing_tab => driver.FindElement(By.XPath("//span[normalize-space()='Processing']"));
        public IWebElement ToReview_tab => driver.FindElement(By.XPath("//span[normalize-space()='To Review']"));
        public IWebElement Reviewed_tab => driver.FindElement(By.XPath("//span[normalize-space()='Reviewed']"));
        public IWebElement recceipt_archived_tab => driver.FindElement(By.XPath("//span[normalize-space()='Archived']"));

        //File upload from drop files
        public IWebElement drop_files => driver.FindElement(By.XPath("//div[@class='dz-default dz-message']//img"));

        //file upload from browse your computer button
        public IWebElement file_upload_browse_your_computer => driver.FindElement(By.XPath("//div[@class='dz-default dz-message']//button[@type='button'][normalize-space()='Browse your computer']"));


        //first recceipt row 

        public IWebElement first_row_receipt => driver.FindElement(By.XPath("//*[@class='dx-datagrid-rowsview dx-datagrid-nowrap']/div/table/tbody/tr[1]/td[3]"));

        //Edit recceipt 
        public IWebElement receipt_document_number => driver.FindElement(By.Id("documentNumber"));
        public IWebElement status_in_edit_receipt => driver.FindElement(By.XPath("//span[@class='badge badge-warning']"));
        public IWebElement choose_type_as_bill => driver.FindElement(By.Id("receiptBillOption"));
        public IWebElement choose_type_as_expense => driver.FindElement(By.Id("receiptExpenseOption"));
        public IWebElement date_receipt => driver.FindElement(By.XPath("//input[@class='dx-texteditor-input']"));        
        public IWebElement Date_for_receipt_showing => driver.FindElement(By.XPath("//*[@id='purchaseDate']/div/input"));
        public IWebElement contact_for_receipt => driver.FindElement(By.XPath("//input[@id='contact']"));
        public IWebElement receipt_item_desc => driver.FindElement(By.XPath(" //*[@id='ReceiptItem0_Description']"));        
        public IWebElement receipt_item_description => driver.FindElement(By.XPath("//*[@id='ReceiptItem0_DescriptionValidation']"));
        public IWebElement click_on_receipt_account_first_drop_down => driver.FindElement(By.XPath("//select[@id='ReceiptItem0_ChartOfAccount']/optgroup[@label='Cost of Goods Sold']/option"));
        public IWebElement receipt_item_unitcost => driver.FindElement(By.Id("ReceiptItem0_UnitCost"));
        public IWebElement receipt_item_quantity => driver.FindElement(By.Id("ReceiptItem0_Quantity"));
        public IWebElement vat_drop_down_receipt => driver.FindElement(By.Id("ReceiptItem0_VatRate"));
        public IWebElement vat_total_receipt => driver.FindElement(By.Id("ReceiptItem0_VatTotal"));
        public IWebElement total_amount_receipt => driver.FindElement(By.Id("ReceiptItem0_TotalAmount"));
        public IWebElement net_amount_receipt => driver.FindElement(By.XPath("//span[@class='receipt-net']"));
        public IWebElement vat_amount_receipt => driver.FindElement(By.XPath("//span[@class='receipt-vat']"));
        public IWebElement vat_total_amount_receipt => driver.FindElement(By.XPath("//span[@class='receipt-total']"));

        //Notes
        public IWebElement notes_title_receipt => driver.FindElement(By.XPath("//input[@id='newCommentTitle']"));
        public IWebElement notes_description_receipt => driver.FindElement(By.XPath("//textarea[@id='newCommentText']"));
        public IWebElement add_note_button => driver.FindElement(By.XPath("//button[@id='addNewNoteButton']"));
        public IWebElement Receipt_title_name => driver.FindElement(By.Id("ReceiptNote0_Name"));
        public IWebElement Receipt_title_time => driver.FindElement(By.Id("ReceiptNote0_Time"));
        public IWebElement Receipt_title => driver.FindElement(By.Id("ReceiptNote0_Title"));
        public IWebElement Receipt_title_desc => driver.FindElement(By.Id("ReceiptNote0_Text"));
        public IWebElement bill_notes_count => driver.FindElement(By.XPath("//span[@id='billNotesCount']"));
        public IWebElement bill_notes_data => driver.FindElement(By.XPath("//div[@class='card-body']"));

        
        //Approve and next button
        public IWebElement approve_and_next_button => driver.FindElement(By.XPath("//a[normalize-space()='Approve & Next']"));

        // public IWebElement Receipt_search_data_grid => driver.FindElement(By.XPath("//input[@aria-label='Search in data grid']"));
        //public IWebElement Receipt_search_data_grid => driver.FindElement(By.CssSelector("#reviewedGrid > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div > div > div.dx-texteditor-input-container > input"));

        public IWebElement Receipt_search_data_grid => driver.FindElement(By.ClassName("dx-texteditor-input"));
        //input[@aria-label='Search in data grid'])[1]

        // Paid by
        public IWebElement receipt_paid_by_drop_down => driver.FindElement(By.Id("paidBy"));
        public IWebElement receipt_staff_drop_down => driver.FindElement(By.Id("staff"));

        //File expense allocation
        
        public IWebElement allocated_receipt_label => driver.FindElement(By.XPath("//h6[contains(text(),'Allocated Receipt')]"));
        public IWebElement receipt_file_image_showing => driver.FindElement(By.XPath("//div[@class='card-body']//figure"));
        public IWebElement receipt_download_document => driver.FindElement(By.XPath("//a[normalize-space()='Download Document']"));

        //public IWebElement receipt_expense_file_count => driver.FindElement(By.XPath("//*[@id='tab_list']/li[4]/a/span"));
        public IWebElement receipt_expense_file_count => driver.FindElement(By.XPath("//li[@data-module-expense='Files']/a/span"));
        public IWebElement receipt_expense_file_tab => driver.FindElement(By.XPath("//li[@data-module-expense='Files']"));

        public IWebElement expense_notes_count => driver.FindElement(By.XPath("//span[@id='staffExpenseNotesCount']"));
        public IWebElement expense_notes_data => driver.FindElement(By.XPath("//div[@class='card-body']"));

        public IWebElement receipt_expense_notes_tab => driver.FindElement(By.XPath("//li[@data-module-expense='Notes']/a"));

        //Scan receipt

        public IWebElement Create_new_scan_receipt => driver.FindElement((By.Id("receiptQuickUpload")));
        public IWebElement scan_receipt_bill => driver.FindElement(By.XPath("//button[normalize-space()='Scan Receipt']"));
        
    }

}
