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
using HaibooksAutomationForWeb.TestCases;
using HaibooksAutomationForWeb;
using HaibooksAutomationForWeb.MyHelper;
using HaibooksAutomationForWeb.Constant;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using System.Linq;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;
using System.Net;
using SoftAssert;
using FluentAssertions;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace HaibooksAutomationForWeb
{
    [TestClass]
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Receipt Module Test cases")]
    [AllureTag("Receipt Module Test Cases")]

    public class T_S11_Receipts_test_cases : Baseclass
    {
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("Receipts_count_display_in_integer_properly")]

        //https://haibooks.atlassian.net/plugins/servlet/ac/com.kaanha.jira.tcms/aio-tcms-app-browse?ac.project.id=10000&ac.page=case-details&ac.params=%7B%22caseId%22:844339%7D
        //Automation-key-45
        //Automation-key-90        
        //Automation-key-78


        [Test, Order(1)]
       

        public void test_case_1_Receipts_count_display_in_integer_properly()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            _systemElements1.create_business_with_sole_trader_with_vat();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            Thread.Sleep(TimeSpan.FromSeconds(3));

            waitformee.Until(driver => _systemElements1.Receipt_processing_count.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //Adding processing count
            String count_processing_str = _systemElements1.Receipt_processing_count.Text;
            int count_processing_int = Convert.ToInt32(count_processing_str);

            //Adding ToReview count
            String count_toreview_str = _systemElements1.Receipt_toreview_count.Text;
            int count_toreview_int = Convert.ToInt32(count_toreview_str);

            //Adding Reviewed count
            String count_reviewed_str = _systemElements1.Receipt_reviewed_count.Text;
            int count_reviewed_int = Convert.ToInt32(count_reviewed_str);

            //Adding Archived count
            String count_archived_str = _systemElements1.Receipt_archived_count.Text;
            int count_archived_int = Convert.ToInt32(count_archived_str);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, count_processing_int >= 0, "Processing count value is not showing in integer:");
                Assert.AreEqual(true, count_toreview_int >= 0, "To Review count value is not showing in integer:");
                Assert.AreEqual(true, count_reviewed_int >= 0, "Reviewed count value is not showing in integer:");
                Assert.AreEqual(true, count_archived_int >= 0, "archive count value is not showing in integer:");
            });

            Console.WriteLine("Count for all is showing");
        }

        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("Receipts_verify_uploading_successfully_message_and_move_to_review_automatically_is_showing")]
        //https://haibooks.atlassian.net/plugins/servlet/ac/com.kaanha.jira.tcms/aio-tcms-app-browse?ac.project.id=10000&ac.page=case-details&ac.params=%7B%22caseId%22:812621%7D
        //Automation-key-21
        //Automation-key-22

        [Test, Order(2)]

        public void test_case_2_Receipts_verify_uploading_successfully_message_and_move_to_review_automatically_is_showing()
        {
            bool message_showing, move_to_review_automatically;
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            // _systemElements1.Add_receipt_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //using (Process exeProcess = Process.Start(Constants.file_upload_script)) ;
            _systemElements1.file_upload.SendKeys(Constants.single_file_upload_path);
            try
            {
                waitformee.Until(driver => _systemElements1.uploading_success_message.Displayed);
                message_showing = true;
            }
            catch (Exception e)
            {
                message_showing = false;
            }

            if (_systemElements1.Receipt_processing_count.Text == "0")
            {
                Console.WriteLine("receipt moved to review automatically");
                move_to_review_automatically = true;
            }
            else
            {
                move_to_review_automatically = false;
            }

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, message_showing, "Verify uploading message snakbar:");
                Assert.AreEqual(true, move_to_review_automatically, "Verify move to review autoamtically:");
            });
        }


        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("Receipts_verify_user_upload_single_receipt_successfully")]

        //https://haibooks.atlassian.net/plugins/servlet/ac/com.kaanha.jira.tcms/aio-tcms-app-browse?ac.project.id=10000&ac.page=case-details&ac.params=%7B%22caseId%22:804323%7D
        //Automation-key-16

        [Test, Order(3)]
        //Receipts >> verify that user can upload single receipt successfully
     

        public void test_case_3_Receipts_verify_user_upload_single_receipt_successfully()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            //_systemElements1.create_business_with_sole_trader();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            // _systemElements1.Add_receipt_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //using (Process exeProcess = Process.Start(Constants.file_upload_script)) ;

            //Adding processing count
            String count_processing_str = _systemElements1.Receipt_processing_count.Text;
            // Console.WriteLine(count_processing_str);
            int count_processing_int = Convert.ToInt32(count_processing_str);
            Global_variables.receipt_processing_count = count_processing_int;


            //Adding ToReview count
            String count_toreview_str = _systemElements1.Receipt_toreview_count.Text;
            int count_toreview_int = Convert.ToInt32(count_toreview_str);
            Global_variables.receipt_toreview_count = count_toreview_int;

            //Adding Reviewed count
            String count_reviewed_str = _systemElements1.Receipt_reviewed_count.Text;
            int count_reviewed_int = Convert.ToInt32(count_reviewed_str);
            Global_variables.receipt_reviewed_count = count_reviewed_int;

            //Adding Archived count
            String count_archived_str = _systemElements1.Receipt_archived_count.Text;
            int count_archived_int = Convert.ToInt32(count_archived_str);
            Global_variables.receipt_archived_count = count_archived_int;


            _systemElements1.file_upload.SendKeys(Constants.single_file_upload_path);

            try
            {
                waitformee.Until(driver => _systemElements1.uploading_success_message.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uploading successfully message is not showing");
            }
            Thread.Sleep(TimeSpan.FromSeconds(3));

            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ToReview_tab);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            bool count_increament;

            if (Global_variables.receipt_toreview_count < Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text))
            {
                Console.WriteLine("File uploaded and moved to review successfully");
                count_increament = true;
            }
            else
            {
                count_increament = false;
            }


            bool display_page_sizes = _systemElements1.page_size_display();
            if (display_page_sizes == true)
            {
                _systemElements1.itmes_50_display_on_page.Click();
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));


            _systemElements1.no_of_col_and_rows(Constants.receipts_col, Constants.receipts_rows);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;
            Console.WriteLine("col size:" + column_size);
            Console.WriteLine("rowsize:" + row_size);
            bool receipt_showing;

            if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == row_size - 1)
            {
                Console.WriteLine("Receipt is added in \"To Review \" tab");
                receipt_showing = true;
            }
            else
            {               
                receipt_showing = false;
            }

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, count_increament, "File not uploaded and moved to review successfully ");
                Assert.AreEqual(true, receipt_showing, "Receipt row is not showing");

            });

        }


        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("Receipts_verify_unspported_files_showing_warning_message")]
        //https://haibooks.atlassian.net/plugins/servlet/ac/com.kaanha.jira.tcms/aio-tcms-app-browse?ac.project.id=10000&ac.page=case-details&ac.params=%7B%22caseId%22:804345%7D
        //Automation-key-18

        [Test, Order(4)]

        public void test_case_4_Receipts_verify_unspported_files_showing_warning_message()
        {
            //File upload from Add receipt Button
            bool message_showing, drop_file_message_showing, browse_your_computer_message;
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            // _systemElements1.Add_receipt_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //using (Process exeProcess = Process.Start(Constants.wrong_file_upload_script)) ;
            _systemElements1.file_upload.SendKeys(Constants.wrong_file_upload_path);
            try
            {
                waitformee.Until(driver => _systemElements1.invalid_file_type_message.Displayed);
                message_showing = true;
            }
            catch (Exception e)
            {
                message_showing = false;
            }


            //File upload from drop files
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            //_systemElements1.drop_files.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //using (Process exeProcess = Process.Start(Constants.wrong_file_upload_script)) ;
            _systemElements1.file_upload.SendKeys(Constants.wrong_file_upload_path);
            try
            {
                waitformee.Until(driver => _systemElements1.invalid_file_type_message.Displayed);
                drop_file_message_showing = true;
            }
            catch (Exception e)
            {
                drop_file_message_showing = false;
            }


            //File upload from browse your computer button
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            //_systemElements1.drop_files.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //using (Process exeProcess = Process.Start(Constants.wrong_file_upload_script)) ;
            _systemElements1.file_upload.SendKeys(Constants.wrong_file_upload_path);
            try
            {
                waitformee.Until(driver => _systemElements1.invalid_file_type_message.Displayed);
                browse_your_computer_message = true;
            }
            catch (Exception e)
            {
                browse_your_computer_message = false;
            }

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, message_showing, "File upload from Add receipt Button:");
                Assert.AreEqual(true, drop_file_message_showing, "File upload from drop files:");
                Assert.AreEqual(true, browse_your_computer_message, "File upload from Browse your computer:");
            });
        }



        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("Receipts_verify_multiple_receipt_upload_successfully")]
        //https://haibooks.atlassian.net/plugins/servlet/ac/com.kaanha.jira.tcms/aio-tcms-app-browse?ac.project.id=10000&ac.page=case-details&ac.params=%7B%22caseId%22:804324%7D
        //Automation-key-17

        [Test, Order(5)]
        //Receipts >> Receipts_verify_multiple_receipt_upload_successfully


        public void test_case_5_Receipts_verify_multiple_receipt_upload_successfully()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            //_systemElements1.create_business_with_sole_trader();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //_systemElements1.Add_receipt_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            //Adding processing count
            String count_processing_str = _systemElements1.Receipt_processing_count.Text;
            // Console.WriteLine(count_processing_str);
            int count_processing_int = Convert.ToInt32(count_processing_str);
            Global_variables.receipt_processing_count = count_processing_int;


            //Adding ToReview count
            String count_toreview_str = _systemElements1.Receipt_toreview_count.Text;
            int count_toreview_int = Convert.ToInt32(count_toreview_str);
            Global_variables.receipt_toreview_count = count_toreview_int;

            //Adding Reviewed count
            String count_reviewed_str = _systemElements1.Receipt_reviewed_count.Text;
            int count_reviewed_int = Convert.ToInt32(count_reviewed_str);
            Global_variables.receipt_reviewed_count = count_reviewed_int;

            //Adding Archived count
            String count_archived_str = _systemElements1.Receipt_archived_count.Text;
            int count_archived_int = Convert.ToInt32(count_archived_str);
            Global_variables.receipt_archived_count = count_archived_int;


            //using (Process exeProcess = Process.Start(Constants.multiple_file_upload_script)) ;
            _systemElements1.file_upload.SendKeys(Constants.multiple_file_upload_path);
            try
            {
                waitformee.Until(driver => _systemElements1.uploading_success_message.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uploading successfully message is not showing");
            }
            Thread.Sleep(TimeSpan.FromSeconds(3));

            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));


            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ToReview_tab);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            bool count_increament;
            if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == count_toreview_int + 2)
            {
                Console.WriteLine("File uploaded and moved to review successfully");
                count_increament = true;
            }
            else
            {
                count_increament = false;
            }

            bool display_page_sizes = _systemElements1.page_size_display();
            if (display_page_sizes == true)
            {
                _systemElements1.itmes_50_display_on_page.Click();
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //find no of rows equal to count
            _systemElements1.no_of_col_and_rows(Constants.receipts_col, Constants.receipts_rows);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;
            Console.WriteLine("col size:" + column_size);
            Console.WriteLine("rowsize:" + row_size);

            bool receipt_showing;
            if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == row_size - 1)
            {
                Console.WriteLine("Receipt is added in \"To Review \" tab");
                receipt_showing = true;
            }
            else
            {
                receipt_showing = false;
            }



            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, count_increament, "File not uploaded and moved to review successfully ");
                Assert.AreEqual(true, receipt_showing, "Receipt row is not showing");

            });

        }



        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("Receipts_add_receipt_as_bill")]
        //https://haibooks.atlassian.net/plugins/servlet/ac/com.kaanha.jira.tcms/aio-tcms-app-browse?ac.project.id=10000&ac.page=case-details&ac.params=%7B%22caseId%22:844391%7D
        //Automation-key-50


        [Test, Order(6)]
      

        public void test_case_6_Receipts_add_receipt_as_bill()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            try
            {
                waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            }
            catch (Exception e) { }
            //_systemElements1.create_business_with_sole_trader();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.receipt_left_menu.Click();
            try
            {
                waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            }
            catch (Exception e) { }
            Thread.Sleep(TimeSpan.FromSeconds(4));
            try
            {
                waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception e) { }

            //Adding ToReview count
            String count_toreview_str = _systemElements1.Receipt_toreview_count.Text;
            int count_toreview_int = Convert.ToInt32(count_toreview_str);
            Global_variables.receipt_toreview_count = count_toreview_int;

            if (count_toreview_int <= 0)
            {
                _systemElements1.perform_upload_receipt();
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }

            //Counting to Review
            String count_to_review = _systemElements1.Receipt_toreview_count.Text;
            int count_to_review_int = Convert.ToInt32(count_to_review);

            //Adding Reviewed count
            String count_reviewed_str = _systemElements1.Receipt_reviewed_count.Text;
            int count_reviewed_int = Convert.ToInt32(count_reviewed_str);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ToReview_tab);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            String status_in_review = _systemElements1.first_row_receipt.Text;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.first_row_receipt);
            try
            {
                waitformee.Until(driver => _systemElements1.receipt_document_number.Displayed);
            }
            catch (Exception e) { }

            Thread.Sleep(TimeSpan.FromSeconds(4));
            String status_in_edit_receipt = _systemElements1.status_in_edit_receipt.Text;

            Thread.Sleep(TimeSpan.FromSeconds(4));
            _systemElements1.perform_add_receipt_as_bill();
            String description = _systemElements1.receipt_bill_description;
            bool receipt_title_name = _systemElements1.receipt_bill_title_name;
            bool receipt_title_time = _systemElements1.receipt_bill_title_time;
            bool receipt_title = _systemElements1.receipt_bill_title;
            bool receipt_title_description = _systemElements1.receipt_bill_title_description;
            String date_for_receipt = _systemElements1.date_for_receipt_bill;
            String document_number = _systemElements1.receipt_bill_document_number;
            String unit_cost = _systemElements1.receipt_bill_unit_cost;
            String quantity = _systemElements1.receipt_bill_quantity;
            String vat_toal_value = _systemElements1.receipt_bill_vat_toal_value;
            String total_amount = _systemElements1.receipt_bill_total_amount;
            String net_amount = _systemElements1.receipt_bill_net_amount;
            String vat_amount = _systemElements1.receipt_bill_vat_amount;
            String vat_total_amount_receipt = _systemElements1.receipt_bill_vat_total_amount;
            try
            {
                waitformee.Until(driver => _systemElements1.Receipt_toreview_count.Displayed);
            }
            catch (Exception e) { }
            Thread.Sleep(TimeSpan.FromSeconds(4));
            bool count_change_when_approved_and_next;

            if ((Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) < count_to_review_int) && (Convert.ToInt32(_systemElements1.Receipt_reviewed_count.Text) > count_reviewed_int))
            {
                count_change_when_approved_and_next = true;
            }
            else
            {
                count_change_when_approved_and_next = false;
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //Verifying in Reviewed Tab
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.Reviewed_tab);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.perform_search_data_receipt(description);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.perform_click_on_data(description, Constants.receipts_col, Constants.receipts_rows, 2, "");

            Thread.Sleep(TimeSpan.FromSeconds(2));
            //Adding bills data verifying 

            _systemElements1.perform_saved_invoice_bill_expense_mileage(Constants.bill_creation);

            string contact_saved = _systemElements1.global_contact_saved;
            string invoice_issue_date = _systemElements1.global_invoice_issue_date;
            string invoice_due_date = _systemElements1.global_invoice_due_date;
            string invoice_custom = _systemElements1.global_invoice_custom;
            string invoice_term_days = _systemElements1.global_invoice_term_days;
            string detail_invoice_number = _systemElements1.global_detail_invoice_number;
            string account_type = _systemElements1.global_account_types;
            string invoice_detail_unit_cost = _systemElements1.global_invoice_detail_unit_cost;
            string invoice_quantity_value = _systemElements1.global_invoice_quantity;
            //int invoice_quantity = Convert.ToInt32(invoice_quantity_value);
            var invoice_quantitys = Convert.ToDouble(invoice_quantity_value);
            string invoice_quantity = $"{invoice_quantitys:0.00}";

            string invoice_vat_rate = _systemElements1.global_invoice_vat_rate;
            string invoice_vat_total = _systemElements1.global_invoice_vat_total;
            string invoice_detail_total_amount_val = _systemElements1.global_invoice_detail_total_amount;
            // int invoice_detail_total_amount = Convert.ToInt32(invoice_detail_total_amount_val);
            var invoice_detail_total_amounts = Convert.ToDouble(invoice_detail_total_amount_val);
            string invoice_detail_total_amount = $"{invoice_detail_total_amounts:0.00}";
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

            //Verify file count 
            String file_count = _systemElements1.bill_file_count.Text;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.Files_tab_bill.Click();
            try
            {
                waitformee.Until(driver => _systemElements1.All_files_label.Displayed);
            }
            catch (Exception e) { }

            bool file_row_exists;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.no_of_col_and_rows(Constants.files_col, Constants.files_rows);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;
            if (row_size >= 2)
            {
                file_row_exists = true;
            }
            else
            {
                file_row_exists = false;
            }

            //Verify notes count
            String bill_notes_count = _systemElements1.bill_notes_count.Text;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.notes_tab_bill);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            bool notes_data_showing;
            try
            {
                waitformee.Until(driver => _systemElements1.bill_notes_data.Displayed);
                notes_data_showing = _systemElements1.bill_notes_data.Displayed;
            }
            catch (Exception e)
            {
                notes_data_showing = false;
            }

            Assert.Multiple(() =>
            {
                //Added receipt title is showing in edit receipt below
                Assert.AreEqual(true, receipt_title_name, "Added receipt_title_name is not showing");
                Assert.AreEqual(true, receipt_title_time, "Added receipt_title_time is not showing");
                Assert.AreEqual(true, receipt_title, "Added receipt_title is not showing");
                Assert.AreEqual(true, receipt_title_description, "Added receipt_title_description is not showing");

                //Count change and move to reviewed automatically
                Assert.AreEqual(true, count_change_when_approved_and_next, "count should be changed and Reviewed count should be increased");
                Assert.AreEqual(status_in_review, status_in_edit_receipt, "status in review tab should be equal to status in edit receipt");

                //Verifying file count exists
                Assert.AreEqual("1", file_count, "Verifying file count");
                Assert.AreEqual("1", bill_notes_count, "Verifying notes count");
                Assert.AreEqual(true, file_row_exists, "Verifying file exists");
                Assert.AreEqual(true, notes_data_showing, "notes data showing in notes tab or not ");

                //Verifying data in billing
                Assert.AreEqual(date_for_receipt, invoice_issue_date, "Comparision of issue date is showing correctly");
                Assert.AreEqual(document_number, detail_invoice_number, "Comparision of document number matched with invoice number in billing");
                Assert.AreEqual(description, invoice_detail_description, "Comparision of Description matched with bill description");
                Assert.AreEqual(unit_cost, invoice_detail_unit_cost, "Comparision of unit cost matched with bill unit cost value");
                Assert.AreEqual(quantity, invoice_quantity, "Comparision of Quantity matched with bill quanitity value");
                Assert.AreEqual(vat_toal_value, invoice_vat_total, "Comparision of Vat Total Value matched with bill Vat value");

                //Format in two digits
                String total_amount_value = String.Format("{0:0.00}", total_amount);
                String invoice_detail_total_amount_value = String.Format("{0:0.00}", invoice_detail_total_amount);
                Assert.AreEqual(total_amount_value, invoice_detail_total_amount_value, "Comparision of Total Amount value");

                //Net Amount
                String net_amount_nt = String.Format("{0:0.00}", net_amount);
                String invoice_detail_subtotal_nt = String.Format("{0:0.00}", invoice_detail_subtotal);
                invoice_detail_subtotal_nt = invoice_detail_subtotal_nt.Trim(' ');
                Assert.AreEqual(net_amount_nt, invoice_detail_subtotal_nt, "Comparision of Net Amount value");
              
                //vat_amount
                String vat_amount_at = String.Format("{0:0.00}", vat_amount);
                String invoice_detail_tax_at = String.Format("{0:0.00}", invoice_detail_tax);
                invoice_detail_tax_at = invoice_detail_tax_at.Trim(' ');
                Assert.AreEqual(vat_amount_at, invoice_detail_tax_at, "Comparision of VAT Tax value");

                //Vat Total amount Receipt
                String vat_total_amount_receipts = String.Format("{0:0.00}", vat_total_amount_receipt);
                String invoice_detail_amount_dues = String.Format("{0:0.00}", invoice_detail_amount_due);
                invoice_detail_amount_dues = invoice_detail_amount_dues.Trim(' ');
                Assert.AreEqual(vat_total_amount_receipts, invoice_detail_amount_dues, "Comparision of VAT Total Amount receipt");
            });
        }


        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("Receipts_add_receipt_as_expense")]

        //https://haibooks.atlassian.net/plugins/servlet/ac/com.kaanha.jira.tcms/aio-tcms-app-browse?ac.project.id=10000&ac.page=case-details&ac.params=%7B%22caseId%22:844440%7D
        //Automation-key-67

        [Test, Order(7)]
        public void test_case_7_Receipts_add_receipt_as_expense()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            try
            {
                waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            }
            catch (Exception e) { }
            //_systemElements1.create_business_with_sole_trader();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.receipt_left_menu.Click();
            try
            {
                waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            }
            catch (Exception e) { }
            Thread.Sleep(TimeSpan.FromSeconds(4));
            try
            {
                waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception e) { }
            Thread.Sleep(TimeSpan.FromSeconds(4));
            //Adding ToReview count
            String count_toreview_str = _systemElements1.Receipt_toreview_count.Text;
            int count_toreview_int = Convert.ToInt32(count_toreview_str);
            Global_variables.receipt_toreview_count = count_toreview_int;

            if (count_toreview_int <= 0)
            {
                _systemElements1.perform_upload_receipt();
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }

            //Counting to Review
            String count_to_review = _systemElements1.Receipt_toreview_count.Text;
            int count_to_review_int = Convert.ToInt32(count_to_review);

            //Adding Reviewed count
            String count_reviewed_str = _systemElements1.Receipt_reviewed_count.Text;
            int count_reviewed_int = Convert.ToInt32(count_reviewed_str);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ToReview_tab);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            String status_in_review = _systemElements1.first_row_receipt.Text;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.first_row_receipt);
            try
            {
                waitformee.Until(driver => _systemElements1.receipt_document_number.Displayed);
            }
            catch (Exception e) { }

            Thread.Sleep(TimeSpan.FromSeconds(4));
            String status_in_edit_receipt = _systemElements1.status_in_edit_receipt.Text;

            Thread.Sleep(TimeSpan.FromSeconds(4));
            _systemElements1.perform_add_receipt_as_expense();
            String description = _systemElements1.receipt_bill_description;
            bool receipt_title_name = _systemElements1.receipt_bill_title_name;
            bool receipt_title_time = _systemElements1.receipt_bill_title_time;
            bool receipt_title = _systemElements1.receipt_bill_title;
            bool receipt_title_description = _systemElements1.receipt_bill_title_description;
            String date_for_receipt = _systemElements1.date_for_receipt_bill;
            String document_number = _systemElements1.receipt_bill_document_number;
            String unit_cost = _systemElements1.receipt_bill_unit_cost;
            String quantity = _systemElements1.receipt_bill_quantity;
            String vat_toal_value = _systemElements1.receipt_bill_vat_toal_value;
            String total_amount = _systemElements1.receipt_bill_total_amount;
            String net_amount = _systemElements1.receipt_bill_net_amount;
            String vat_amount = _systemElements1.receipt_bill_vat_amount;
            String vat_total_amount_receipt = _systemElements1.receipt_bill_vat_total_amount;
            try
            {
                waitformee.Until(driver => _systemElements1.Receipt_toreview_count.Displayed);
            }
            catch (Exception e) { }
            Thread.Sleep(TimeSpan.FromSeconds(4));
            bool count_change_when_approved_and_next;

            if ((Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) < count_to_review_int) && (Convert.ToInt32(_systemElements1.Receipt_reviewed_count.Text) > count_reviewed_int))
            {
                count_change_when_approved_and_next = true;
            }
            else
            {
                count_change_when_approved_and_next = false;
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //Verifying in Reviewed Tab
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.Reviewed_tab);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.perform_search_data_receipt(description);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.perform_click_on_data(description, Constants.receipts_col, Constants.receipts_rows, 2, "");

            Thread.Sleep(TimeSpan.FromSeconds(2));
            //Adding bills data verifying 

            _systemElements1.perform_saved_invoice_bill_expense_mileage(Constants.expense_creation);

            string contact_saved = _systemElements1.global_contact_saved;
            string invoice_issue_date = _systemElements1.global_invoice_issue_date;
            string invoice_due_date = _systemElements1.global_invoice_due_date;
            string invoice_custom = _systemElements1.global_invoice_custom;
            string invoice_term_days = _systemElements1.global_invoice_term_days;
            string detail_invoice_number = _systemElements1.global_detail_invoice_number;
            string account_type = _systemElements1.global_account_types;
            string invoice_detail_unit_cost = _systemElements1.global_invoice_detail_unit_cost;
            string invoice_quantity_value = _systemElements1.global_invoice_quantity;
            //int invoice_quantity = Convert.ToInt32(invoice_quantity_value);
            var invoice_quantitys = Convert.ToDouble(invoice_quantity_value);
            string invoice_quantity = $"{invoice_quantitys:0.00}";

            string invoice_vat_rate = _systemElements1.global_invoice_vat_rate;
            string invoice_vat_total = _systemElements1.global_invoice_vat_total;
            string invoice_detail_total_amount_val = _systemElements1.global_invoice_detail_total_amount;
            // int invoice_detail_total_amount = Convert.ToInt32(invoice_detail_total_amount_val);
            var invoice_detail_total_amounts = Convert.ToDouble(invoice_detail_total_amount_val);
            string invoice_detail_total_amount = $"{invoice_detail_total_amounts:0.00}";
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

            bool allocated_receipt_label_showing, receipt_file_image_showing, receipt_download_document;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //Verify file count                       
            if (_systemElements1.allocated_receipt_label.Displayed)
            {
                allocated_receipt_label_showing = true;
            }
            else
            {
                allocated_receipt_label_showing = false;
            }
            if (_systemElements1.receipt_file_image_showing.Displayed)
            {
                receipt_file_image_showing = true;
            }
            else
            {
                receipt_file_image_showing = false;
            }

            if (_systemElements1.receipt_download_document.Displayed)
            {
                receipt_download_document = true;
            }
            else
            {
                receipt_download_document = false;
            }



            String file_count = _systemElements1.receipt_expense_file_count.Text;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.receipt_expense_file_tab.Click();
            try
            {
                waitformee.Until(driver => _systemElements1.All_files_label.Displayed);
            }
            catch (Exception e) { }

            bool file_row_exists;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.no_of_col_and_rows(Constants.files_col, Constants.files_rows);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;
            if (row_size >= 1)
            {
                file_row_exists = true;
            }
            else
            {
                file_row_exists = false;
            }

            //Verify notes count
            String bill_notes_count = _systemElements1.expense_notes_count.Text;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.receipt_expense_notes_tab);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            bool notes_data_showing;
            try
            {
                waitformee.Until(driver => _systemElements1.bill_notes_data.Displayed);
                notes_data_showing = _systemElements1.bill_notes_data.Displayed;
            }
            catch (Exception e)
            {
                notes_data_showing = false;
            }

            Assert.Multiple(() =>
            {
                //Added receipt title is showing in edit receipt below
                Assert.AreEqual(true, receipt_title_name, "Added receipt_title_name is not showing");
                Assert.AreEqual(true, receipt_title_time, "Added receipt_title_time is not showing");
                Assert.AreEqual(true, receipt_title, "Added receipt_title is not showing");
                Assert.AreEqual(true, receipt_title_description, "Added receipt_title_description is not showing");

                //Count change and move to reviewed automatically
                Assert.AreEqual(true, count_change_when_approved_and_next, "count should be changed and Reviewed count should be increased");
                Assert.AreEqual(status_in_review, status_in_edit_receipt, "status in review tab should be equal to status in edit receipt");

                //Verifying file count exists               
                Assert.AreEqual(true, allocated_receipt_label_showing, "Verifying label for Allocated Receipt is showing");
                Assert.AreEqual(true, receipt_file_image_showing, "Verifying file receipt imagee is showing");
                Assert.AreEqual(true, receipt_download_document, "Verifying download Receipt link is showing");


                Assert.AreEqual("0", file_count, "Verifying file count");
                Assert.AreEqual("1", bill_notes_count, "Verifying notes count");
                Assert.AreEqual(true, file_row_exists, "Verifying file exists");
                Assert.AreEqual(true, notes_data_showing, "notes data showing in notes tab or not ");

                //Verifying data in billing
                Assert.AreEqual(date_for_receipt, invoice_issue_date, "Comparision of issue date is showing correctly");
                Assert.AreEqual(document_number, detail_invoice_number, "Comparision of document number matched with invoice number in billing");
                Assert.AreEqual(description, invoice_detail_description, "Comparision of Description matched with bill description");
                Assert.AreEqual(unit_cost, invoice_detail_unit_cost, "Comparision of unit cost matched with bill unit cost value");
                Assert.AreEqual(quantity, invoice_quantity, "Comparision of Quantity matched with bill quanitity value");
                Assert.AreEqual(vat_toal_value, invoice_vat_total, "Comparision of Vat Total Value matched with bill Vat value");

                //Format in two digits
                String total_amount_value = String.Format("{0:0.00}", total_amount);
                String invoice_detail_total_amount_value = String.Format("{0:0.00}", invoice_detail_total_amount);
                Assert.AreEqual(total_amount_value, invoice_detail_total_amount_value, "Comparision of Total Amount value");

                //Net Amount
                String net_amount_nt = String.Format("{0:0.00}", net_amount);
                String invoice_detail_subtotal_nt = String.Format("{0:0.00}", invoice_detail_subtotal);
                invoice_detail_subtotal_nt = invoice_detail_subtotal_nt.Trim(' ');
                Assert.AreEqual(net_amount_nt, invoice_detail_subtotal_nt, "Comparision of Net Amount value");

                //vat_amount
                String vat_amount_at = String.Format("{0:0.00}", vat_amount);
                String invoice_detail_tax_at = String.Format("{0:0.00}", invoice_detail_tax);
                invoice_detail_tax_at = invoice_detail_tax_at.Trim(' ');
                Assert.AreEqual(vat_amount_at, invoice_detail_tax_at, "Comparision of VAT Tax value");

                //Vat Total amount Receipt
                String vat_total_amount_receipts = String.Format("{0:0.00}", vat_total_amount_receipt);
                String invoice_detail_amount_dues = String.Format("{0:0.00}", invoice_detail_amount_due);
                invoice_detail_amount_dues = invoice_detail_amount_dues.Trim(' ');
                Assert.AreEqual(vat_total_amount_receipts, invoice_detail_amount_dues, "Comparision of VAT Total Amount receipt due");
            });

        }



        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("Scan Receipt from +Add new button")]

        [Test, Order(8)]
        public void test_case_8_scan_single_receipts_from_Add_new_button()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            //_systemElements1.create_business_with_sole_trader();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            // _systemElements1.Add_receipt_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //using (Process exeProcess = Process.Start(Constants.file_upload_script)) ;

            //Adding processing count
            String count_processing_str = _systemElements1.Receipt_processing_count.Text;
            // Console.WriteLine(count_processing_str);
            int count_processing_int = Convert.ToInt32(count_processing_str);
            Global_variables.receipt_processing_count = count_processing_int;


            //Adding ToReview count
            String count_toreview_str = _systemElements1.Receipt_toreview_count.Text;
            int count_toreview_int = Convert.ToInt32(count_toreview_str);
            Global_variables.receipt_toreview_count = count_toreview_int;

            //Adding Reviewed count
            String count_reviewed_str = _systemElements1.Receipt_reviewed_count.Text;
            int count_reviewed_int = Convert.ToInt32(count_reviewed_str);
            Global_variables.receipt_reviewed_count = count_reviewed_int;

            //Adding Archived count
            String count_archived_str = _systemElements1.Receipt_archived_count.Text;
            int count_archived_int = Convert.ToInt32(count_archived_str);
            Global_variables.receipt_archived_count = count_archived_int;

            _systemElements1.dashboard_leftmenu.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            _systemElements1.create_new_left_side.Click();
            waitformee.Until(driver => _systemElements1.create_new_receipt_dashboard.Displayed);

            _systemElements1.Create_new_scan_receipt.SendKeys(Constants.single_file_upload_path);

            try
            {
                waitformee.Until(driver => _systemElements1.uploading_success_message.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uploading successfully message is not showing");
            }
            Thread.Sleep(TimeSpan.FromSeconds(3));

            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            Thread.Sleep(TimeSpan.FromSeconds(7));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ToReview_tab);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            bool count_increament;

            if (Global_variables.receipt_toreview_count < Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text))
            {
                Console.WriteLine("File uploaded and moved to review successfully");
                count_increament = true;
            }
            else
            {
                count_increament = false;
            }

            bool display_page_sizes = _systemElements1.page_size_display();
            if (display_page_sizes == true)
            {
                _systemElements1.itmes_50_display_on_page.Click();
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

            _systemElements1.no_of_col_and_rows(Constants.receipts_col, Constants.receipts_rows);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;
            Console.WriteLine("col size:" + column_size);
            Console.WriteLine("rowsize:" + row_size);

            bool receipt_showing;
            if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == row_size - 1)
            {
                Console.WriteLine("Receipt is added in \"To Review \" tab");
                receipt_showing = true;
            }
            else
            {
                receipt_showing = false;
            }

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, count_increament, "File not uploaded and moved to review successfully ");
                Assert.AreEqual(true, receipt_showing, "Receipt row is not showing");
            });
        }




        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("scan_multiple_receipts_from_Add_new_button")]

        [Test, Order(9)]

        public void test_case_9_scan_multiple_receipts_from_Add_new_button()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            //_systemElements1.create_business_with_sole_trader();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //_systemElements1.Add_receipt_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            //Adding processing count
            String count_processing_str = _systemElements1.Receipt_processing_count.Text;
            // Console.WriteLine(count_processing_str);
            int count_processing_int = Convert.ToInt32(count_processing_str);
            Global_variables.receipt_processing_count = count_processing_int;


            //Adding ToReview count
            String count_toreview_str = _systemElements1.Receipt_toreview_count.Text;
            int count_toreview_int = Convert.ToInt32(count_toreview_str);
            Global_variables.receipt_toreview_count = count_toreview_int;

            //Adding Reviewed count
            String count_reviewed_str = _systemElements1.Receipt_reviewed_count.Text;
            int count_reviewed_int = Convert.ToInt32(count_reviewed_str);
            Global_variables.receipt_reviewed_count = count_reviewed_int;

            //Adding Archived count
            String count_archived_str = _systemElements1.Receipt_archived_count.Text;
            int count_archived_int = Convert.ToInt32(count_archived_str);
            Global_variables.receipt_archived_count = count_archived_int;

            _systemElements1.dashboard_leftmenu.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            _systemElements1.create_new_left_side.Click();
            waitformee.Until(driver => _systemElements1.create_new_receipt_dashboard.Displayed);

            //using (Process exeProcess = Process.Start(Constants.multiple_file_upload_script)) ;
            _systemElements1.Create_new_scan_receipt.SendKeys(Constants.multiple_file_upload_path);
            try
            {
                waitformee.Until(driver => _systemElements1.uploading_success_message.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uploading successfully message is not showing");
            }
            Thread.Sleep(TimeSpan.FromSeconds(3));

            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            Thread.Sleep(TimeSpan.FromSeconds(7));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ToReview_tab);
            Thread.Sleep(TimeSpan.FromSeconds(3));

            bool count_increament;
            if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == count_toreview_int + 2)
            {
                Console.WriteLine("File uploaded and moved to review successfully");
                count_increament = true;
            }
            else
            {
                count_increament = false;
            }

            bool display_page_sizes = _systemElements1.page_size_display();
            if (display_page_sizes == true)
            {
                _systemElements1.itmes_50_display_on_page.Click();
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //find no of rows equal to count
            _systemElements1.no_of_col_and_rows(Constants.receipts_col, Constants.receipts_rows);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;
            Console.WriteLine("col size:" + column_size);
            Console.WriteLine("rowsize:" + row_size);

            bool receipt_showing;
            if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == row_size - 1)
            {
                Console.WriteLine("Receipt is added in \"To Review \" tab");
                receipt_showing = true;
            }
            else
            {
                receipt_showing = false;
            }

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, count_increament, "File not uploaded and moved to review successfully ");
                Assert.AreEqual(true, receipt_showing, "Receipt row is not showing");

            });


        }





        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("scan_single_receipt_from_bill")]
        //https://haibooks.atlassian.net/plugins/servlet/ac/com.kaanha.jira.tcms/aio-tcms-app-browse?ac.project.id=10000&ac.page=case-details&ac.params=%7B%22caseId%22:844343%7D
        ////Automation-key-48


        [Test, Order(10)]
        public void test_case10_scan_single_receipt_from_bill()
        {

             _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            //_systemElements1.create_business_with_sole_trader();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            // _systemElements1.Add_receipt_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //using (Process exeProcess = Process.Start(Constants.file_upload_script)) ;

            //Adding processing count
            String count_processing_str = _systemElements1.Receipt_processing_count.Text;
            // Console.WriteLine(count_processing_str);
            int count_processing_int = Convert.ToInt32(count_processing_str);
            Global_variables.receipt_processing_count = count_processing_int;


            //Adding ToReview count
            String count_toreview_str = _systemElements1.Receipt_toreview_count.Text;
            int count_toreview_int = Convert.ToInt32(count_toreview_str);
            Global_variables.receipt_toreview_count = count_toreview_int;

            //Adding Reviewed count
            String count_reviewed_str = _systemElements1.Receipt_reviewed_count.Text;
            int count_reviewed_int = Convert.ToInt32(count_reviewed_str);
            Global_variables.receipt_reviewed_count = count_reviewed_int;

            //Adding Archived count
            String count_archived_str = _systemElements1.Receipt_archived_count.Text;
            int count_archived_int = Convert.ToInt32(count_archived_str);
            Global_variables.receipt_archived_count = count_archived_int;

            waitformee.Until(driver => _systemElements1.purchase_left_side.Displayed);
            if (_systemElements1.purchase_left_side.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.purchase_left_side.Click();
            }
            waitformee.Until(driver => _systemElements1.bills_left_side.Displayed);
            _systemElements1.bills_left_side.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.sales_add_new.Displayed);
            _systemElements1.sales_add_new.Click();
            waitformee.Until(driver => _systemElements1.purchase_add_bill.Displayed);          
            _systemElements1.purchase_add_bill.Click();
            Thread.Sleep(TimeSpan.FromSeconds(4));            
             waitformee.Until(driver => _systemElements1.scan_receipt_bill.Displayed);

            _systemElements1.file_upload.SendKeys(Constants.single_file_upload_path);

            try
            {
                waitformee.Until(driver => _systemElements1.uploading_success_message.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uploading successfully message is not showing");
            }
            Thread.Sleep(TimeSpan.FromSeconds(3));

            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            try
            {
                waitformee.Until(driver => _systemElements1.ToReview_tab.Displayed);
            }
            catch(Exception e) { }
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ToReview_tab);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            bool count_increament;

            if (Global_variables.receipt_toreview_count < Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text))
            {
                Console.WriteLine("File uploaded and moved to review successfully");
                count_increament = true;
            }
            else
            {
                count_increament = false;
            }

            bool display_page_sizes = _systemElements1.page_size_display();
            if (display_page_sizes == true)
            {
                _systemElements1.itmes_50_display_on_page.Click();
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

            _systemElements1.no_of_col_and_rows(Constants.receipts_col, Constants.receipts_rows);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;
            Console.WriteLine("col size:" + column_size);
            Console.WriteLine("rowsize:" + row_size);

            bool receipt_showing;
            if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == row_size - 1)
            {
                Console.WriteLine("Receipt is added in \"To Review \" tab");
                receipt_showing = true;
            }
            else
            {
                receipt_showing = false;
            }

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, count_increament, "File not uploaded and moved to review successfully ");
                Assert.AreEqual(true, receipt_showing, "Receipt row is not showing");
            });

        }




        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("scan_multiple_receipt_from_bill")]
        //https://haibooks.atlassian.net/plugins/servlet/ac/com.kaanha.jira.tcms/aio-tcms-app-browse?ac.project.id=10000&ac.page=case-details&ac.params=%7B%22caseId%22:844343%7D
        ////Automation-key-48


        [Test, Order(11)]
        public void test_case11_scan_multiple_receipt_from_bill()
        {

            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            //_systemElements1.create_business_with_sole_trader();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            // _systemElements1.Add_receipt_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //using (Process exeProcess = Process.Start(Constants.file_upload_script)) ;

            //Adding processing count
            String count_processing_str = _systemElements1.Receipt_processing_count.Text;
            // Console.WriteLine(count_processing_str);
            int count_processing_int = Convert.ToInt32(count_processing_str);
            Global_variables.receipt_processing_count = count_processing_int;


            //Adding ToReview count
            String count_toreview_str = _systemElements1.Receipt_toreview_count.Text;
            int count_toreview_int = Convert.ToInt32(count_toreview_str);
            Global_variables.receipt_toreview_count = count_toreview_int;

            //Adding Reviewed count
            String count_reviewed_str = _systemElements1.Receipt_reviewed_count.Text;
            int count_reviewed_int = Convert.ToInt32(count_reviewed_str);
            Global_variables.receipt_reviewed_count = count_reviewed_int;

            //Adding Archived count
            String count_archived_str = _systemElements1.Receipt_archived_count.Text;
            int count_archived_int = Convert.ToInt32(count_archived_str);
            Global_variables.receipt_archived_count = count_archived_int;

            waitformee.Until(driver => _systemElements1.purchase_left_side.Displayed);
            if (_systemElements1.purchase_left_side.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.purchase_left_side.Click();
            }
            waitformee.Until(driver => _systemElements1.bills_left_side.Displayed);
            _systemElements1.bills_left_side.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.sales_add_new.Displayed);
            _systemElements1.sales_add_new.Click();
            waitformee.Until(driver => _systemElements1.purchase_add_bill.Displayed);
            _systemElements1.purchase_add_bill.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.scan_receipt_bill.Displayed);

            _systemElements1.file_upload.SendKeys(Constants.multiple_file_upload_path);

            try
            {
                waitformee.Until(driver => _systemElements1.uploading_success_message.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uploading successfully message is not showing");
            }
            Thread.Sleep(TimeSpan.FromSeconds(8));

            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));          
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ToReview_tab);          
            Thread.Sleep(TimeSpan.FromSeconds(4));

            bool count_increament;
            if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == count_toreview_int + 2)
            {
                Console.WriteLine("File uploaded and moved to review successfully");
                count_increament = true;
            }
            else
            {
                count_increament = false;
            }

            bool display_page_sizes = _systemElements1.page_size_display();
            if (display_page_sizes == true)
            {
                _systemElements1.itmes_50_display_on_page.Click();
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //find no of rows equal to count
            _systemElements1.no_of_col_and_rows(Constants.receipts_col, Constants.receipts_rows);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;
            Console.WriteLine("col size:" + column_size);
            Console.WriteLine("rowsize:" + row_size);

            bool receipt_showing;
            if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == row_size - 1)
            {
                Console.WriteLine("Receipt is added in \"To Review \" tab");
                receipt_showing = true;
            }
            else
            {
                receipt_showing = false;
            }

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, count_increament, "File not uploaded and moved to review successfully ");
                Assert.AreEqual(true, receipt_showing, "Receipt row is not showing");

            });
        }



        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("scan_single_receipt_from_expense")]
        //https://haibooks.atlassian.net/plugins/servlet/ac/com.kaanha.jira.tcms/aio-tcms-app-browse?ac.project.id=10000&ac.page=case-details&ac.params=%7B%22caseId%22:844344%7D
        //Automation-key-49


        [Test, Order(12)]
        public void test_case12_scan_single_receipt_from_expense()
        {

            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            //_systemElements1.create_business_with_sole_trader();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            // _systemElements1.Add_receipt_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //using (Process exeProcess = Process.Start(Constants.file_upload_script)) ;

            //Adding processing count
            String count_processing_str = _systemElements1.Receipt_processing_count.Text;
            // Console.WriteLine(count_processing_str);
            int count_processing_int = Convert.ToInt32(count_processing_str);
            Global_variables.receipt_processing_count = count_processing_int;


            //Adding ToReview count
            String count_toreview_str = _systemElements1.Receipt_toreview_count.Text;
            int count_toreview_int = Convert.ToInt32(count_toreview_str);
            Global_variables.receipt_toreview_count = count_toreview_int;

            //Adding Reviewed count
            String count_reviewed_str = _systemElements1.Receipt_reviewed_count.Text;
            int count_reviewed_int = Convert.ToInt32(count_reviewed_str);
            Global_variables.receipt_reviewed_count = count_reviewed_int;

            //Adding Archived count
            String count_archived_str = _systemElements1.Receipt_archived_count.Text;
            int count_archived_int = Convert.ToInt32(count_archived_str);
            Global_variables.receipt_archived_count = count_archived_int;

            waitformee.Until(driver => _systemElements1.staff_expnses_left_menu.Displayed);
            if (_systemElements1.purchase_left_side.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.staff_expnses_left_menu.Click();
            }          
            waitformee.Until(driver => _systemElements1.add_new_expense.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.add_new_expense);
           // _systemElements1.add_new_expense.Click();          
            Thread.Sleep(TimeSpan.FromSeconds(4));
            waitformee.Until(driver => _systemElements1.scan_receipt_bill.Displayed);

            _systemElements1.file_upload.SendKeys(Constants.single_file_upload_path);

            try
            {
                waitformee.Until(driver => _systemElements1.uploading_success_message.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uploading successfully message is not showing");
            }
            Thread.Sleep(TimeSpan.FromSeconds(5));

            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
           // waitformee.Until(driver => _systemElements1.ToReview_tab.Displayed);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ToReview_tab);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            bool count_increament;

            if (Global_variables.receipt_toreview_count < Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text))
            {
                Console.WriteLine("File uploaded and moved to review successfully");
                count_increament = true;
            }
            else
            {
                count_increament = false;
            }

            bool display_page_sizes = _systemElements1.page_size_display();
            if (display_page_sizes == true)
            {
                _systemElements1.itmes_50_display_on_page.Click();
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

            _systemElements1.no_of_col_and_rows(Constants.receipts_col, Constants.receipts_rows);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;
            Console.WriteLine("col size:" + column_size);
            Console.WriteLine("rowsize:" + row_size);

            bool receipt_showing;
            if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == row_size - 1)
            {
                Console.WriteLine("Receipt is added in \"To Review \" tab");
                receipt_showing = true;
            }
            else
            {
                receipt_showing = false;
            }

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, count_increament, "File not uploaded and moved to review successfully ");
                Assert.AreEqual(true, receipt_showing, "Receipt row is not showing");
            });

        }





        [AllureSeverity(SeverityLevel.critical)]
        [AllureTms("TMS")]
        [AllureEpic("Regression Test")]
        [AllureStory("scan_multiple_receipt_from_bill")]

        //https://haibooks.atlassian.net/plugins/servlet/ac/com.kaanha.jira.tcms/aio-tcms-app-browse?ac.project.id=10000&ac.page=case-details&ac.params=%7B%22caseId%22:844344%7D
        //Automation-key-49

        [Test, Order(13)]
        public void test_case13_scan_multiple_receipt_from_expense()
        {

            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            //_systemElements1.create_business_with_sole_trader();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            // _systemElements1.Add_receipt_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //using (Process exeProcess = Process.Start(Constants.file_upload_script)) ;

            //Adding processing count
            String count_processing_str = _systemElements1.Receipt_processing_count.Text;
            // Console.WriteLine(count_processing_str);
            int count_processing_int = Convert.ToInt32(count_processing_str);
            Global_variables.receipt_processing_count = count_processing_int;


            //Adding ToReview count
            String count_toreview_str = _systemElements1.Receipt_toreview_count.Text;
            int count_toreview_int = Convert.ToInt32(count_toreview_str);
            Global_variables.receipt_toreview_count = count_toreview_int;

            //Adding Reviewed count
            String count_reviewed_str = _systemElements1.Receipt_reviewed_count.Text;
            int count_reviewed_int = Convert.ToInt32(count_reviewed_str);
            Global_variables.receipt_reviewed_count = count_reviewed_int;

            //Adding Archived count
            String count_archived_str = _systemElements1.Receipt_archived_count.Text;
            int count_archived_int = Convert.ToInt32(count_archived_str);
            Global_variables.receipt_archived_count = count_archived_int;

            waitformee.Until(driver => _systemElements1.staff_expnses_left_menu.Displayed);
            if (_systemElements1.purchase_left_side.GetAttribute("aria-expanded") == "false")
            {
                _systemElements1.staff_expnses_left_menu.Click();
            }
            waitformee.Until(driver => _systemElements1.add_new_expense.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.add_new_expense);
            // _systemElements1.add_new_expense.Click();          
            Thread.Sleep(TimeSpan.FromSeconds(4));           
            waitformee.Until(driver => _systemElements1.scan_receipt_bill.Displayed);

            _systemElements1.file_upload.SendKeys(Constants.multiple_file_upload_path);

            try
            {
                waitformee.Until(driver => _systemElements1.uploading_success_message.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Uploading successfully message is not showing");
            }
            Thread.Sleep(TimeSpan.FromSeconds(6));

            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ToReview_tab);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            bool count_increament;
            try
            {
                if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == count_toreview_int + 2)
                {
                    Console.WriteLine("File uploaded and moved to review successfully");
                    count_increament = true;
                }
                else
                {
                    count_increament = false;
                }
            }
            catch(Exception e)
            {
                if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == count_toreview_int + 2)
                {
                    Console.WriteLine("File uploaded and moved to review successfully");
                    count_increament = true;
                }
                else
                {
                    count_increament = false;
                }

            }
                


            bool display_page_sizes = _systemElements1.page_size_display();
            if (display_page_sizes == true)
            {
                _systemElements1.itmes_50_display_on_page.Click();
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //find no of rows equal to count
            _systemElements1.no_of_col_and_rows(Constants.receipts_col, Constants.receipts_rows);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;
            Console.WriteLine("col size:" + column_size);
            Console.WriteLine("rowsize:" + row_size);

            bool receipt_showing;
            if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == row_size - 1)
            {
                Console.WriteLine("Receipt is added in \"To Review \" tab");
                receipt_showing = true;
            }
            else
            {
                receipt_showing = false;
            }

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, count_increament, "File not uploaded and moved to review successfully ");
                Assert.AreEqual(true, receipt_showing, "Receipt row is not showing");

            });
        }
    }
}









