using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.Constant;
using HaibooksAutomationForWeb.MyHelper;
using HaibooksAutomationForWeb.TestCases;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HaibooksAutomationForWeb.Elements
{
    public partial class system_elements : Baseclass
    {
        public String receipt_bill_description { get; set; }
        public bool receipt_bill_title_name { get; set; }
        public bool receipt_bill_title_time { get; set; }
        public bool receipt_bill_title { get; set; }
        public bool receipt_bill_title_description { get; set; }
        public String date_for_receipt_bill { get; set; }
        public String receipt_bill_document_number { get; set; }
        public String receipt_bill_unit_cost { get; set; }
        public String receipt_bill_quantity { get; set; }
        public String receipt_bill_vat_toal_value { get; set; }
        public String receipt_bill_total_amount { get; set; }
        public String receipt_bill_net_amount { get; set; } 
        public String receipt_bill_vat_amount { get; set; }
        public String receipt_bill_vat_total_amount { get; set; }

        public void perform_upload_receipt()
        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //_systemElements1.Add_receipt_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
             //using (Process exeProcess = Process.Start(Constants.multiple_file_upload_script)) ;

            file_upload.SendKeys(Constants.multiple_file_upload_path);            
            try
            {
                waitformee.Until(driver => _systemElements1.uploading_success_message.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uploading successfully message is not showing");
            }
            Thread.Sleep(TimeSpan.FromSeconds(3));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ToReview_tab);
            Thread.Sleep(TimeSpan.FromSeconds(3));

            if (Global_variables.receipt_toreview_count < Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text))
            {
                Console.WriteLine("File uploaded and moved to review successfully");
            }
        }


        public void perform_search_data_receipt(string data)
        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            try
            {
                waitformee.Until(driver => _systemElements1.Receipt_search_data_grid.Displayed);
            }catch(Exception e) { }
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.Receipt_search_data_grid);          
            Receipt_search_data_grid.Clear();          
            Receipt_search_data_grid.SendKeys(data);         
           
        }

        public void perform_add_receipt_as_bill()
        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.choose_type_as_bill);
            // _systemElements1.choose_type_as_bill.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            try { 
            waitformee.Until(driver => _systemElements1.date_receipt.Displayed);
            }catch(Exception e) { }

            String date_for_recceipt = _systemElements1.Date_for_receipt_showing.GetAttribute("value");
            DateTime oDate = Convert.ToDateTime(date_for_recceipt);
            var end_date_format = oDate.ToString("dd/MM/yyyy");
            var date_for_receipt = end_date_format.Replace('-', '/');
            date_for_receipt_bill = date_for_receipt;
            String document_number = _systemElements1.receipt_document_number.GetAttribute("value");
            receipt_bill_document_number = document_number;
            String contact_for_receipt = _systemElements1.contact_for_receipt.Text;
            Console.WriteLine("date for recceipt" + date_for_receipt);
            Console.WriteLine("document_number" + document_number);
            Console.WriteLine("contact_for_receipt" + contact_for_receipt);
            _systemElements1.click_on_receipt_account_first_drop_down.Click();


            //Add description
            MyHelperClass random_description = new MyHelperClass();
            var description_generate = random_description.template_message_body(20);
            _systemElements1.receipt_item_desc.SendKeys(description_generate);
            var description = _systemElements1.receipt_item_desc.GetAttribute("value");
            Console.WriteLine("description" + description);

            receipt_bill_description = description;

            //Select VAT Rate

            _systemElements1.perform_select_VAT_receipt(Constants.vat_value_20_Expenses);
            String vat = _systemElements1.global_vat_selected_value_vat;
            //Console.WriteLine("vat" + vat);

            //Ad unit cost
            String unit_cost = _systemElements1.receipt_item_unitcost.GetAttribute("value");
            Console.WriteLine("unit_cost" + unit_cost);
            receipt_bill_unit_cost = unit_cost;

            //Quantity
            String quantity_value = _systemElements1.receipt_item_quantity.GetAttribute("value");
            Console.WriteLine("quantity" + quantity_value);
            //int quantity = Convert.ToInt32(quantity_value);
            var quantitys = Convert.ToDouble(quantity_value);
            string quantity = $"{quantitys:0.00}";
            receipt_bill_quantity = quantity;

            String vat_toal_value = _systemElements1.vat_total_receipt.GetAttribute("value");
            receipt_bill_vat_toal_value = vat_toal_value;
            String total_amount_values = _systemElements1.total_amount_receipt.GetAttribute("value");
            //int total_amount = Convert.ToInt32(total_amount_values);
            var total_amounts = Convert.ToDouble(total_amount_values);
            string total_amount = $"{total_amounts:0.00}";

            receipt_bill_total_amount = total_amount;
            String net_amount_value = _systemElements1.net_amount_receipt.Text;
            string net_amount = net_amount_value.Trim('£');
            receipt_bill_net_amount = net_amount;

            String vat_amount_value = _systemElements1.vat_amount_receipt.Text;
            string vat_amount = vat_amount_value.Trim('£');
            receipt_bill_vat_amount = vat_amount;

            String vat_total_amount_receipt_value = _systemElements1.vat_total_amount_receipt.Text;
            string vat_total_amount_receipt = vat_total_amount_receipt_value.Trim('£');
            receipt_bill_vat_total_amount = vat_total_amount_receipt;
            Console.WriteLine("vat_toal_value" + vat_toal_value);
            Console.WriteLine("total_amount" + total_amount);
            Console.WriteLine("net_amount" + net_amount);
            Console.WriteLine("vat_amount" + vat_amount);
            Console.WriteLine("vat_total_amount_receipt" + vat_total_amount_receipt);


            //Add notes title
            MyHelperClass random_title = new MyHelperClass();
            var notes_title = random_title.template_message_body(8);
            _systemElements1.notes_title_receipt.SendKeys(notes_title);

            //Add notes description
            MyHelperClass notes_description = new MyHelperClass();
            var notes_desc = notes_description.template_message_body(20);
            _systemElements1.notes_description_receipt.SendKeys(notes_desc);

            String notes_title_value = _systemElements1.notes_title_receipt.GetAttribute("value");
            String notes_title_description = _systemElements1.notes_description_receipt.GetAttribute("value");

            Console.WriteLine("notes_title_value" + notes_title_value);
            Console.WriteLine("notes_title_description" + notes_title_description);

            _systemElements1.add_note_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            try
            {
                waitformee.Until(driver => _systemElements1.Receipt_title_name.Displayed);
            }
            catch (Exception e) { }
            bool receipt_title_name = _systemElements1.recceipt_title_related_items_showing("ReceiptNote0_Name");
            receipt_bill_title_name = receipt_title_name;
            bool receipt_title_time = _systemElements1.recceipt_title_related_items_showing("ReceiptNote0_Time");
            receipt_bill_title_time = receipt_title_time;
            bool receipt_title = _systemElements1.recceipt_title_related_items_showing("ReceiptNote0_Title");
            receipt_bill_title = receipt_title;
            bool receipt_title_description = _systemElements1.recceipt_title_related_items_showing("ReceiptNote0_Text");
            receipt_bill_title_description = receipt_title_description;
            _systemElements1.approve_and_next_button.Click();

            try
            {
                waitformee.Until(driver => _systemElements1.uploading_success_message.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("receipt moved to reviewed message is not showing");
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

        }

        public void perform_add_receipt_as_expense()
        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.choose_type_as_expense);
            // _systemElements1.choose_type_as_bill.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            try
            {
                waitformee.Until(driver => _systemElements1.receipt_paid_by_drop_down.Displayed);
            }
            catch (Exception e) { }

            String date_for_recceipt = _systemElements1.Date_for_receipt_showing.GetAttribute("value");
            DateTime oDate = Convert.ToDateTime(date_for_recceipt);
            var end_date_format = oDate.ToString("dd/MM/yyyy");
            var date_for_receipt = end_date_format.Replace('-', '/');
            date_for_receipt_bill = date_for_receipt;
            String document_number = _systemElements1.receipt_document_number.GetAttribute("value");
            receipt_bill_document_number = document_number;
            //String contact_for_receipt = _systemElements1.contact_for_receipt.Text;
            Console.WriteLine("date for recceipt" + date_for_receipt);
            Console.WriteLine("document_number" + document_number);

            //Select Paid by Staff
            SelectElement paid_by = new SelectElement(_systemElements1.receipt_paid_by_drop_down);
            paid_by.SelectByText(Constants.paid_by);
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //Select staf member            
            SelectElement staff = new SelectElement(_systemElements1.receipt_staff_drop_down);
            staff.SelectByIndex(1);

            _systemElements1.click_on_receipt_account_first_drop_down.Click();


            //Add description
            MyHelperClass random_description = new MyHelperClass();
            var description_generate = random_description.template_message_body(20);
            _systemElements1.receipt_item_desc.SendKeys(description_generate);
            var description = _systemElements1.receipt_item_desc.GetAttribute("value");
            Console.WriteLine("description" + description);

            receipt_bill_description = description;

            //Select VAT Rate

            _systemElements1.perform_select_VAT_receipt(Constants.vat_value_20_Expenses);
            String vat = _systemElements1.global_vat_selected_value_vat;
            //Console.WriteLine("vat" + vat);

            //Ad unit cost
            String unit_cost = _systemElements1.receipt_item_unitcost.GetAttribute("value");
            Console.WriteLine("unit_cost" + unit_cost);
            receipt_bill_unit_cost = unit_cost;

            //Quantity
            String quantity_value = _systemElements1.receipt_item_quantity.GetAttribute("value");
            Console.WriteLine("quantity" + quantity_value);
            //int quantity = Convert.ToInt32(quantity_value);
            var quantitys = Convert.ToDouble(quantity_value);
            string quantity = $"{quantitys:0.00}";
            receipt_bill_quantity = quantity;

            String vat_toal_value = _systemElements1.vat_total_receipt.GetAttribute("value");
            receipt_bill_vat_toal_value = vat_toal_value;
            String total_amount_values = _systemElements1.total_amount_receipt.GetAttribute("value");
            //int total_amount = Convert.ToInt32(total_amount_values);
            var total_amounts = Convert.ToDouble(total_amount_values);
            string total_amount = $"{total_amounts:0.00}";

            receipt_bill_total_amount = total_amount;
            String net_amount_value = _systemElements1.net_amount_receipt.Text;
            string net_amount = net_amount_value.Trim('£');
            receipt_bill_net_amount = net_amount;

            String vat_amount_value = _systemElements1.vat_amount_receipt.Text;
            string vat_amount = vat_amount_value.Trim('£');
            receipt_bill_vat_amount = vat_amount;

            String vat_total_amount_receipt_value = _systemElements1.vat_total_amount_receipt.Text;
            string vat_total_amount_receipt = vat_total_amount_receipt_value.Trim('£');
            receipt_bill_vat_total_amount = vat_total_amount_receipt;
            Console.WriteLine("vat_toal_value" + vat_toal_value);
            Console.WriteLine("total_amount" + total_amount);
            Console.WriteLine("net_amount" + net_amount);
            Console.WriteLine("vat_amount" + vat_amount);
            Console.WriteLine("vat_total_amount_receipt" + vat_total_amount_receipt);


            //Add notes title
            MyHelperClass random_title = new MyHelperClass();
            var notes_title = random_title.template_message_body(8);
            _systemElements1.notes_title_receipt.SendKeys(notes_title);

            //Add notes description
            MyHelperClass notes_description = new MyHelperClass();
            var notes_desc = notes_description.template_message_body(20);
            _systemElements1.notes_description_receipt.SendKeys(notes_desc);

            String notes_title_value = _systemElements1.notes_title_receipt.GetAttribute("value");
            String notes_title_description = _systemElements1.notes_description_receipt.GetAttribute("value");

            Console.WriteLine("notes_title_value" + notes_title_value);
            Console.WriteLine("notes_title_description" + notes_title_description);

            _systemElements1.add_note_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            try
            {
                waitformee.Until(driver => _systemElements1.Receipt_title_name.Displayed);
            }
            catch (Exception e) { }
            bool receipt_title_name = _systemElements1.recceipt_title_related_items_showing("ReceiptNote0_Name");
            receipt_bill_title_name = receipt_title_name;
            bool receipt_title_time = _systemElements1.recceipt_title_related_items_showing("ReceiptNote0_Time");
            receipt_bill_title_time = receipt_title_time;
            bool receipt_title = _systemElements1.recceipt_title_related_items_showing("ReceiptNote0_Title");
            receipt_bill_title = receipt_title;
            bool receipt_title_description = _systemElements1.recceipt_title_related_items_showing("ReceiptNote0_Text");
            receipt_bill_title_description = receipt_title_description;
            _systemElements1.approve_and_next_button.Click();

            try
            {
                waitformee.Until(driver => _systemElements1.uploading_success_message.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("receipt moved to reviewed message is not showing");
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

        }


    }
}


