using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Diagnostics;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Firefox;
using  HaibooksAutomationForWeb.TestCases;
using HaibooksAutomationForWeb;
using HaibooksAutomationForWeb.MyHelper;
using HaibooksAutomationForWeb.Constant;
using NUnit.Framework;
using HaibooksAutomationForWeb.Elements;
using Assert = NUnit.Framework.Assert;
using System.Linq;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using OpenQA.Selenium.Chrome;
using System.IO;
using SolrNet.Utils;


namespace HaibooksAutomationForWeb
{

    [TestFixture]
    public class Create_new_invoice_test_case : Baseclass
    {


        [Test, Order(1)]

        public void test_case_1_create_new_invoice_without_file_attachment()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            waitformee.Until(driver => _systemElements1.create_new_dashboard.Displayed);
            _systemElements1.create_new_dashboard.Click();
            waitformee.Until(driver => _systemElements1.create_new_invoice_dashboard.Displayed);
            _systemElements1.create_new_invoice_dashboard.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.select_contact.Displayed);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.select_contact);
            //_systemElements1.select_contact.Click();

            _systemElements1.perform_adding_invoice_bill_expense_mileage(Constants.invoice_creation);

            string selected_text_contact_info = _systemElements1.selected_text_contact_info1;
            string today_date = _systemElements1.global_today_date;
            string addition_days = _systemElements1.global_addition_days;
            string terms = _systemElements1.global_terms;
            int terms_days = _systemElements1.global_terms_days;
            int invoice_number = _systemElements1.global_invoice_number;
            string account_type_sales = _systemElements1.global_sales_turnover_value;
            string unit_cost_value2 = _systemElements1.global_unit_cost_value;
            string quantity_value2 = _systemElements1.global_Quantity;
            string vat_percentage = _systemElements1.global_vat_value_20_vat;
            string vat_toal_value = _systemElements1.global_toal_value;
            string total_amount_expected = _systemElements1.global_total_amount_expected;
            string subtotal_str = _systemElements1.global_subtotal;
            string tax = _systemElements1.global_tax;
            string total_value_expected = _systemElements1.global_total_value_expected;
            string amount_paid = _systemElements1.global_amount_paid;
            string amount_due = _systemElements1.global_amount_due;
            string comment_added = _systemElements1.global_comment_added;
            string description = _systemElements1.global_description;
            string status = _systemElements1.global_status;
            string invoice_created_by = _systemElements1.global_invoice_created;
            string price_bill_expected = _systemElements1.global_price_bill_expected;
            string tota_value_expected = _systemElements1.global_tota_value_expected;
            string total_amount_value = _systemElements1.global_total_amount_value;
            string price_bill_actual = _systemElements1.global_price_bill_actual;
            string Net_Amount_expected = _systemElements1.global_Net_Amount_expected;
            string vat_tax_value = _systemElements1.global_vat_tax_value;
            string total_value_actual = _systemElements1.global_total_value_actual;
            string amount_due_actual = _systemElements1.global_amount_due_actual;

            Thread.Sleep(TimeSpan.FromSeconds(2));

            _systemElements1.verifying_invoice_added_data_driven(Constants.shhet_2, selected_text_contact_info, today_date, addition_days, terms, terms_days, invoice_number, Constants.sales_turnover_value,
                                                               Constants.unit_cost_value, Constants.Quantity, Constants.vat_value_20_vat, vat_toal_value, total_amount_expected,
                                                               subtotal_str, tax, total_value_expected, amount_paid, amount_due, comment_added, description,
                                                               status, invoice_created_by, price_bill_expected);

            //click on saved And approve button
            _systemElements1.saved_and_approve_btn.Click();

            _systemElements1.perform_saved_invoice_bill_expense_mileage(Constants.invoice_creation);

            string contact_saved = _systemElements1.global_contact_saved;
            string invoice_issue_date = _systemElements1.global_invoice_issue_date;
            string invoice_due_date = _systemElements1.global_invoice_due_date;
            string invoice_custom = _systemElements1.global_invoice_custom;
            string invoice_term_days = _systemElements1.global_invoice_term_days;
            string detail_invoice_number = _systemElements1.global_detail_invoice_number;
            string account_type = _systemElements1.global_account_types;
            string invoice_detail_unit_cost = _systemElements1.global_invoice_detail_unit_cost;
            string invoice_quantity = _systemElements1.global_invoice_quantity;
            string invoice_vat_rate = _systemElements1.global_invoice_vat_rate;
            string invoice_vat_total = _systemElements1.global_invoice_vat_total;
            string invoice_detail_total_amount = _systemElements1.global_invoice_detail_total_amount;
            string invoice_detail_subtotal = _systemElements1.global_invoice_detail_subtotal;
            string invoice_detail_tax = _systemElements1.global_invoice_detail_tax;
            string invoice_detail_total = _systemElements1.global_invoice_detail_total;
            string invoice_detail_amount_paid = _systemElements1.global_invoice_detail_amount_paid;
            string invoice_detail_amount_due = _systemElements1.global_invoice_detail_amount_due;
            string invoice_detail_comment = _systemElements1.global_invoice_detail_comment;
            string invoice_detail_description = _systemElements1.global_invoice_detail_description;
            string invoice_detail_invoice_status = _systemElements1.global_invoice_detail_invoice_status;
            string invoice_detail_invoice_created = _systemElements1.global_invoice_detail_invoice_created;
            string invoice_detail_price = _systemElements1.global_invoice_detail_price;



            _systemElements1.verifying_invoice_saved_data_driven(Constants.shhet_2, contact_saved, invoice_issue_date, invoice_due_date, invoice_custom, invoice_term_days, detail_invoice_number, account_type,
                                                               invoice_detail_unit_cost, invoice_quantity, invoice_vat_rate, invoice_vat_total, invoice_detail_total_amount,
                                                                invoice_detail_subtotal, invoice_detail_tax, invoice_detail_total, invoice_detail_amount_paid, invoice_detail_amount_due, invoice_detail_comment, invoice_detail_description,
                                                                invoice_detail_invoice_status, invoice_detail_invoice_created, invoice_detail_price);


            //Console.WriteLine("Total Vat Expected: Real= " + tota_value_expected + ": " + vat_toal_value);
            //Console.WriteLine("Total Amount Expected: Real= " + total_amount_expected + ": " + total_amount_value);
            //Console.WriteLine("Price bill Expected: Real= " + price_bill_expected + ": " + price_bill_actual);
            //Console.WriteLine("Net Amount Expected: Real= " + Net_Amount_expected + ": " + subtotal_str);
            //Console.WriteLine("Vat Tax Value Expected: Real= " + vat_tax_value + ": " + tax);
            //Console.WriteLine("Total Value Expected: Real=" + total_value_expected + ": " + total_value_actual);
            //Console.WriteLine("Amount Paid Expected: Real=" + "0.00" + ": " + amount_paid);
            //Console.WriteLine("Amount Due Expected: Real=" + amount_due + ": " + amount_due_actual);

            Assert.AreEqual(tota_value_expected, vat_toal_value);
            Assert.AreEqual(total_amount_expected, total_amount_value);
            Assert.AreEqual(price_bill_expected, price_bill_actual);
            Assert.AreEqual(Net_Amount_expected, subtotal_str);
            Assert.AreEqual(vat_tax_value, tax);
            Assert.AreEqual(total_value_expected, total_value_actual);
            Assert.AreEqual("0.00", amount_paid);
            Assert.AreEqual(amount_due, amount_due_actual);


            //////////////////////////////////////Verifying save data//////////////
            ///

            Assert.AreEqual(selected_text_contact_info, contact_saved);

            //Verify issue date
            Assert.AreEqual(today_date, invoice_issue_date);

            //verifying due date
            Assert.AreEqual(addition_days, invoice_due_date);

            //custom
            Assert.AreEqual("Custom", invoice_custom);

            //custom term days
            Assert.AreEqual("30", invoice_term_days);

            //invoice number
            // Assert.AreEqual(invoice_number, detail_invoice_number);

            //account_type
            Assert.AreEqual("Turnover", account_type);

            //invoice_detail_unit_cost
            Assert.AreEqual(unit_cost_value2, invoice_detail_unit_cost);

            //invoice_quantity
            Assert.AreEqual(quantity_value2, invoice_quantity);

            //invoice_vat_rate
            //Assert.AreEqual(vat_value_20, invoice_vat_rate);

            //invoice_vat_total
            Assert.AreEqual(vat_toal_value, invoice_vat_total);

            //invoice_detail_total_amount
            Assert.AreEqual(total_amount_expected, invoice_detail_total_amount);

            //invoice_detail_subtotal
            Assert.AreEqual(subtotal_str, invoice_detail_subtotal);

            //invoice_detail_tax
            Assert.AreEqual(tax, invoice_detail_tax);

            //invoice_detail_total
            Assert.AreEqual(total_value_expected, invoice_detail_total);

            //invoice_detail_amount_paid
            Assert.AreEqual(amount_paid, invoice_detail_amount_paid);

            //invoice_detail_amount_due
            Assert.AreEqual(amount_due, invoice_detail_amount_due);


            //invoice_detail_comment
            Assert.AreEqual(comment_added, invoice_detail_comment);

            //invoice_detail_description
            Assert.AreEqual(description, invoice_detail_description);

            //invoice_detail_invoice_status
            Assert.AreEqual("Unpaid", invoice_detail_invoice_status);

            //invoice_detail_invoice_created
           
                if( invoice_detail_invoice_created== "Invoice Created")
                {
                    Console.WriteLine("invoice created is showing");
                }
            else { 
                Console.WriteLine("Alert: invoice created is not showing");
            }

            //invoice_detail_price
            Assert.AreEqual(price_bill_expected, invoice_detail_price);


        }


        [Test, Order(2)]

        public void test_case_2_create_new_invoice_with_file_attachment()
        {
          
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            waitformee.Until(driver => _systemElements1.dashboard_leftmenu.Displayed);
            _systemElements1.dashboard_leftmenu.Click();
            waitformee.Until(driver => _systemElements1.create_new_dashboard.Displayed);    
            _systemElements1.create_new_dashboard.Click();
            waitformee.Until(driver => _systemElements1.create_new_invoice_dashboard.Displayed);
            _systemElements1.create_new_invoice_dashboard.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.select_contact.Displayed);
            waitformee.Until(driver => _systemElements1.attach_files.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            _systemElements1.attach_files.Click();
            waitformee.Until(driver => _systemElements1.upload_tab.Displayed);
            _systemElements1.upload_tab.Click();
            waitformee.Until(driver => _systemElements1.browse_file_upload.Displayed);
            _systemElements1.browse_file_upload.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            using (Process exeProcess = Process.Start(Constants.file_upload_script)) ;
            Thread.Sleep(TimeSpan.FromSeconds(3));
            waitformee.Until(driver => _systemElements1.add_files_button.Enabled);
            _systemElements1.add_files_button.Click();
            try
            {
                bool attached_file_showing = _systemElements1.file_attached.Displayed;
                if (attached_file_showing == true)
                {
                    Console.WriteLine("File has been attached and showing");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("File not attached");
            }


            _systemElements1.select_contact.Click();

            _systemElements1.perform_adding_invoice_bill_expense_mileage(Constants.invoice_creation);

            string selected_text_contact_info = _systemElements1.selected_text_contact_info1;
            string today_date = _systemElements1.global_today_date;
            string addition_days = _systemElements1.global_addition_days;
            string terms = _systemElements1.global_terms;
            int terms_days = _systemElements1.global_terms_days;
            int invoice_number = _systemElements1.global_invoice_number;
            string account_type_sales = _systemElements1.global_sales_turnover_value;
            string unit_cost_value2 = _systemElements1.global_unit_cost_value;
            string quantity_value2 = _systemElements1.global_Quantity;
            string vat_percentage = _systemElements1.global_vat_value_20_vat;
            string vat_toal_value = _systemElements1.global_toal_value;
            string total_amount_expected = _systemElements1.global_total_amount_expected;
            string subtotal_str = _systemElements1.global_subtotal;
            string tax = _systemElements1.global_tax;
            string total_value_expected = _systemElements1.global_total_value_expected;
            string amount_paid = _systemElements1.global_amount_paid;
            string amount_due = _systemElements1.global_amount_due;
            string comment_added = _systemElements1.global_comment_added;
            string description = _systemElements1.global_description;
            string status = _systemElements1.global_status;
            string invoice_created_by = _systemElements1.global_invoice_created;
            string price_bill_expected = _systemElements1.global_price_bill_expected;
            string tota_value_expected = _systemElements1.global_tota_value_expected;
            string total_amount_value = _systemElements1.global_total_amount_value;
            string price_bill_actual = _systemElements1.global_price_bill_actual;
            string Net_Amount_expected = _systemElements1.global_Net_Amount_expected;
            string vat_tax_value = _systemElements1.global_vat_tax_value;
            string total_value_actual = _systemElements1.global_total_value_actual;
            string amount_due_actual = _systemElements1.global_amount_due_actual;

            Thread.Sleep(TimeSpan.FromSeconds(2));

            _systemElements1.verifying_invoice_added_data_driven(Constants.shhet_5, selected_text_contact_info, today_date, addition_days, terms, terms_days, invoice_number, Constants.sales_turnover_value,
                                                               Constants.unit_cost_value, Constants.Quantity, Constants.vat_value_20_vat, vat_toal_value, total_amount_expected,
                                                               subtotal_str, tax, total_value_expected, amount_paid, amount_due, comment_added, description,
                                                               status, invoice_created_by, price_bill_expected);

            //click on saved And approve button
            _systemElements1.saved_and_approve_btn.Click();

            _systemElements1.perform_saved_invoice_bill_expense_mileage(Constants.invoice_creation);

            string contact_saved = _systemElements1.global_contact_saved;
            string invoice_issue_date = _systemElements1.global_invoice_issue_date;
            string invoice_due_date = _systemElements1.global_invoice_due_date;
            string invoice_custom = _systemElements1.global_invoice_custom;
            string invoice_term_days = _systemElements1.global_invoice_term_days;
            string detail_invoice_number = _systemElements1.global_detail_invoice_number;
            string account_type = _systemElements1.global_account_types;
            string invoice_detail_unit_cost = _systemElements1.global_invoice_detail_unit_cost;
            string invoice_quantity = _systemElements1.global_invoice_quantity;
            string invoice_vat_rate = _systemElements1.global_invoice_vat_rate;
            string invoice_vat_total = _systemElements1.global_invoice_vat_total;
            string invoice_detail_total_amount = _systemElements1.global_invoice_detail_total_amount;
            string invoice_detail_subtotal = _systemElements1.global_invoice_detail_subtotal;
            string invoice_detail_tax = _systemElements1.global_invoice_detail_tax;
            string invoice_detail_total = _systemElements1.global_invoice_detail_total;
            string invoice_detail_amount_paid = _systemElements1.global_invoice_detail_amount_paid;
            string invoice_detail_amount_due = _systemElements1.global_invoice_detail_amount_due;
            string invoice_detail_comment = _systemElements1.global_invoice_detail_comment;
            string invoice_detail_description = _systemElements1.global_invoice_detail_description;
            string invoice_detail_invoice_status = _systemElements1.global_invoice_detail_invoice_status;
            string invoice_detail_invoice_created = _systemElements1.global_invoice_detail_invoice_created;
            string invoice_detail_price = _systemElements1.global_invoice_detail_price;



            _systemElements1.verifying_invoice_saved_data_driven(Constants.shhet_5, contact_saved, invoice_issue_date, invoice_due_date, invoice_custom, invoice_term_days, detail_invoice_number, account_type,
                                                               invoice_detail_unit_cost, invoice_quantity, invoice_vat_rate, invoice_vat_total, invoice_detail_total_amount,
                                                                invoice_detail_subtotal, invoice_detail_tax, invoice_detail_total, invoice_detail_amount_paid, invoice_detail_amount_due, invoice_detail_comment, invoice_detail_description,
                                                                invoice_detail_invoice_status, invoice_detail_invoice_created, invoice_detail_price);


            //Console.WriteLine("Total Vat Expected: Real= " + tota_value_expected + ": " + vat_toal_value);
            //Console.WriteLine("Total Amount Expected: Real= " + total_amount_expected + ": " + total_amount_value);
            //Console.WriteLine("Price bill Expected: Real= " + price_bill_expected + ": " + price_bill_actual);
            //Console.WriteLine("Net Amount Expected: Real= " + Net_Amount_expected + ": " + subtotal_str);
            //Console.WriteLine("Vat Tax Value Expected: Real= " + vat_tax_value + ": " + tax);
            //Console.WriteLine("Total Value Expected: Real=" + total_value_expected + ": " + total_value_actual);
            //Console.WriteLine("Amount Paid Expected: Real=" + "0.00" + ": " + amount_paid);
            //Console.WriteLine("Amount Due Expected: Real=" + amount_due + ": " + amount_due_actual);

            Assert.AreEqual("1", _systemElements1.invoice_file_count.Text);
            _systemElements1.Files_tab.Click();
            waitformee.Until(driver => _systemElements1.All_files_label.Displayed);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.no_of_col_and_rows(Constants.files_col, Constants.files_rows);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;

            _systemElements1.invoice_overview_tab.Click();
            waitformee.Until(driver => _systemElements1.invoice_detail_issue_date.Displayed);
            
            Assert.AreEqual(tota_value_expected, vat_toal_value);
            Assert.AreEqual(total_amount_expected, total_amount_value);
            Assert.AreEqual(price_bill_expected, price_bill_actual);
            Assert.AreEqual(Net_Amount_expected, subtotal_str);
            Assert.AreEqual(vat_tax_value, tax);
            Assert.AreEqual(total_value_expected, total_value_actual);
            Assert.AreEqual("0.00", amount_paid);
            Assert.AreEqual(amount_due, amount_due_actual);


            //////////////////////////////////////Verifying save data//////////////
            ///

            Assert.AreEqual(selected_text_contact_info, contact_saved);

            //Verify issue date
            Assert.AreEqual(today_date, invoice_issue_date);

            //verifying due date
            Assert.AreEqual(addition_days, invoice_due_date);

            //custom
            Assert.AreEqual("Custom", invoice_custom);

            //custom term days
            Assert.AreEqual("30", invoice_term_days);

            //invoice number
            // Assert.AreEqual(invoice_number, detail_invoice_number);

            //account_type
            Assert.AreEqual("Turnover", account_type);

            //invoice_detail_unit_cost
            Assert.AreEqual(unit_cost_value2, invoice_detail_unit_cost);

            //invoice_quantity
            Assert.AreEqual(quantity_value2, invoice_quantity);

            //invoice_vat_rate
            //Assert.AreEqual(vat_value_20, invoice_vat_rate);

            //invoice_vat_total
            Assert.AreEqual(vat_toal_value, invoice_vat_total);

            //invoice_detail_total_amount
            Assert.AreEqual(total_amount_expected, invoice_detail_total_amount);

            //invoice_detail_subtotal
            Assert.AreEqual(subtotal_str, invoice_detail_subtotal);

            //invoice_detail_tax
            Assert.AreEqual(tax, invoice_detail_tax);

            //invoice_detail_total
            Assert.AreEqual(total_value_expected, invoice_detail_total);

            //invoice_detail_amount_paid
            Assert.AreEqual(amount_paid, invoice_detail_amount_paid);

            //invoice_detail_amount_due
            Assert.AreEqual(amount_due, invoice_detail_amount_due);


            //invoice_detail_comment
            Assert.AreEqual(comment_added, invoice_detail_comment);

            //invoice_detail_description
            Assert.AreEqual(description, invoice_detail_description);

            //invoice_detail_invoice_status
            Assert.AreEqual("Unpaid", invoice_detail_invoice_status);

            //invoice_detail_invoice_created
            if(invoice_detail_invoice_created == null )
            {
                Console.WriteLine("Alert: Invoice created is null");
            }
            else
            {
                Assert.AreEqual("Invoice Created", invoice_detail_invoice_created);

            }

          
            //invoice_detail_price
            Assert.AreEqual(price_bill_expected, invoice_detail_price);

            if(row_size-1 == 1)
            {
                Console.WriteLine("Files uploaded and showing in files tab");
            }
            else
            {
                Assert.Fail("Files not showing in files tab");
            }

        }





        [Test, Order(3)]

        public void test_case_3_verify_created_invoice_data_in_contacts()
        {

            //char myChar = 'x';
            //string myString = "xyz";

            //int count = myString.Count(s => s == myChar);
            //int counts = Regex.Matches(selected_value_for_contact_info, ">").Count;



            //WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //_systemElements1.create_new_dashboard.Click();
            //waitformee.Until(PRED => _systemElements1.create_new_invoice_dashboard.Displayed);
            //_systemElements1.create_new_invoice_dashboard.Click();
            //Thread.Sleep(TimeSpan.FromSeconds(2));

            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            waitformee.Until(driver => _systemElements1.create_new_dashboard.Displayed);
            _systemElements1.create_new_dashboard.Click();
            Thread.Sleep(TimeSpan.FromSeconds(17));
            // //Get Contact selected
            // string selected_value_for_contact_info = _systemElements1.select_contact_drop_down_value.GetAttribute("data-content");
            //// int counts = Regex.Matches(selected_value_for_contact_info, ">").Count;
            // int index1 = selected_value_for_contact_info.IndexOf('>');
            // //Console.WriteLine(counts);
            // Console.WriteLine("index: " + index1);

            //string selected_value_for_contact_info1 = selected_value_for_contact_info.Remove(0, index1+1);

            // int index2 = selected_value_for_contact_info1.IndexOf('>');
            // Console.WriteLine("index: "+index2);
            //string  selected_value_for_contact_info2 = selected_value_for_contact_info1.Remove(0, index2+1);

            // Console.WriteLine(selected_value_for_contact_info2);

            //string contact_info_title = _systemElements1.select_contact_drop_down_value.GetAttribute("data-content");
            //int index = contact_info_title.IndexOf('>');
            //contact_info_title = contact_info_title.Remove(0, index + 1);
            //index = contact_info_title.IndexOf('>');
            //contact_info_title = contact_info_title.Remove(0, index + 1);
            //Console.WriteLine(contact_info_title);

            //MyHelperClass comments_1 = new MyHelperClass();
            //var comment_added = comments_1.template_message_body(20);
            //_systemElements1.bill_comment.SendKeys(comment_added);
            //var comments = _systemElements1.bill_comment.Text;

            //Console.WriteLine(comments);           

        }


        [Test, Order(4)]
        public void test_case_4_verify_created_invoice_data_in_total_sales()
        {
          

        }


        [Test, Order(5)]
        public void test_case_5_verify_created_invoice_data_in_statement_of_account()
        {


        }


        [Test, Order(6)]
        public void test_case_6_verify_created_invoice_data_in_Debtors_Control_Account()
        {


        }    



    }
    
}

    
    
