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
    public class Create_new_mileage : Baseclass
    {

      

        [Test, Order(1)]
        public void test_case_1_create_new_Mileage()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitformee.Until(driver => _systemElements1.create_new_dashboard.Displayed);
            _systemElements1.create_new_dashboard.Click();
            waitformee.Until(driver => _systemElements1.create_new_Mileage_dashboard_1.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.create_new_Mileage_dashboard_1.Click();
            Thread.Sleep(TimeSpan.FromSeconds(4));     

            _systemElements1.perform_adding_new_mileage(Constants.mileage);

            string staff_value = _systemElements1.global_staff_value;
            string today_date = _systemElements1.global_today_date;
            int mileage_number = _systemElements1.global_mileage_number;
            string number_of_mileage_value = _systemElements1.global_number_of_mileage_value;
            string vehicle_type = _systemElements1.global_vehicle_type;
            string vehicle_engine_value = _systemElements1.global_vehicle_engine_value;
            string description = _systemElements1.global_description;


            Thread.Sleep(TimeSpan.FromSeconds(2));

            _systemElements1.verifying_mileage_added_data_driven(Constants.shhet_10, staff_value, today_date, mileage_number, number_of_mileage_value, vehicle_type, vehicle_engine_value, description);

            //click on saved And approve button
            _systemElements1.saved_and_approve_btn.Click();
            _systemElements1.perform_saved_mileage();

            string staff_saved_value =_systemElements1.global_staff_saved_value;
            string issue_date_saved_value = _systemElements1.global_issue_date_saved_value;
            string mileage_number_saved_value = _systemElements1.global_mileage_number_saved_value;
            string currency_saved_value = _systemElements1.global_currency_saved_value;
            string numberof_miles_saved_value = _systemElements1.global_numberof_miles_saved_value;
            string mileage_expense_saved_value = _systemElements1.global_mileage_expense_saved_value;
            string vehicle_saved_value = _systemElements1.global_vehicle_saved_value;
            string engine_saved_value = _systemElements1.global_engine_saved_value;
            string description_saved_value = _systemElements1.global_description_saved_value;
            string mileage_created = _systemElements1.global_mileage_created;
            string mileage_status = _systemElements1.global_mileage_status;
            string mileage_number_showint_top = _systemElements1.global_mileage_number_showint_top;
            string mileage_status_showing_at_top = _systemElements1.global_mileage_status_showing_at_top;



            _systemElements1.verifying_mileage_saved_data_driven(Constants.shhet_10, staff_saved_value, issue_date_saved_value, mileage_number_saved_value, numberof_miles_saved_value, vehicle_saved_value, engine_saved_value, description_saved_value, mileage_created, mileage_status, mileage_number_showint_top, mileage_status_showing_at_top, currency_saved_value, mileage_expense_saved_value);

            Assert.AreEqual(staff_value, staff_saved_value);
            Assert.AreEqual(today_date, issue_date_saved_value);

            //Mileage number showing
            int number_mileage = Convert.ToInt32(mileage_number_saved_value);
            Assert.AreEqual(mileage_number, number_mileage);
            
            decimal number_of_saved_values= Convert.ToDecimal(numberof_miles_saved_value);
           string values_of_miles = number_of_saved_values.ToString("0.##");
            Assert.AreEqual(number_of_mileage_value, values_of_miles);
            Assert.AreEqual(vehicle_type, vehicle_saved_value);
            Assert.AreEqual(vehicle_engine_value, engine_saved_value);
            Assert.AreEqual(description, description_saved_value);
            Assert.AreEqual("Mileage Created", mileage_created);
            Assert.AreEqual("Unpaid", mileage_status);

            //Mileage number
            string Mileage_number_value = "Mileage #" + mileage_number;
            Assert.AreEqual(Mileage_number_value, mileage_number_showint_top);

            Assert.AreEqual("Unpaid", mileage_status_showing_at_top);
            Assert.AreEqual("GBP", currency_saved_value);
                      
                                   
            try
            {
                //Mileage expense
                double mileage_value = Convert.ToInt32(number_of_mileage_value);
                double number_of_miles = mileage_value * 0.45;
                int mileage_value_int = Convert.ToInt32(number_of_miles);
                string mileag_saved_values = $"{mileage_expense_saved_value:0.00}";
                mileag_saved_values = mileag_saved_values.Trim('£');
                decimal saved_val = Convert.ToDecimal(mileag_saved_values);
                string saved_values_1 = saved_val.ToString("0.##");
                int saved_values_12 = Convert.ToInt32(saved_values_1);
                Assert.AreEqual(mileage_value_int, saved_values_12);
            }catch(Exception e)
            {
                Console.WriteLine("Fail: Mileage expense value does not match");
            }

        }



        [Test, Order(2)]
        public void test_case_2_create_new_Mileage_with_file_attachment()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitformee.Until(driver => _systemElements1.create_new_dashboard.Displayed);
            _systemElements1.create_new_dashboard.Click();
            waitformee.Until(driver => _systemElements1.create_new_Mileage_dashboard_1.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.create_new_Mileage_dashboard_1.Click();
            Thread.Sleep(TimeSpan.FromSeconds(4));

            waitformee.Until(driver => _systemElements1.attach_files.Displayed);
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

            _systemElements1.perform_adding_new_mileage(Constants.mileage);

            string staff_value = _systemElements1.global_staff_value;
            string today_date = _systemElements1.global_today_date;
            int mileage_number = _systemElements1.global_mileage_number;
            string number_of_mileage_value = _systemElements1.global_number_of_mileage_value;
            string vehicle_type = _systemElements1.global_vehicle_type;
            string vehicle_engine_value = _systemElements1.global_vehicle_engine_value;
            string description = _systemElements1.global_description;


            Thread.Sleep(TimeSpan.FromSeconds(2));

            _systemElements1.verifying_mileage_added_data_driven(Constants.shhet_10, staff_value, today_date, mileage_number, number_of_mileage_value, vehicle_type, vehicle_engine_value, description);

            //click on saved And approve button
            _systemElements1.saved_and_approve_btn.Click();
            _systemElements1.perform_saved_mileage();

            string staff_saved_value = _systemElements1.global_staff_saved_value;
            string issue_date_saved_value = _systemElements1.global_issue_date_saved_value;
            string mileage_number_saved_value = _systemElements1.global_mileage_number_saved_value;
            string currency_saved_value = _systemElements1.global_currency_saved_value;
            string numberof_miles_saved_value = _systemElements1.global_numberof_miles_saved_value;
            string mileage_expense_saved_value = _systemElements1.global_mileage_expense_saved_value;
            string vehicle_saved_value = _systemElements1.global_vehicle_saved_value;
            string engine_saved_value = _systemElements1.global_engine_saved_value;
            string description_saved_value = _systemElements1.global_description_saved_value;
            string mileage_created = _systemElements1.global_mileage_created;
            string mileage_status = _systemElements1.global_mileage_status;
            string mileage_number_showint_top = _systemElements1.global_mileage_number_showint_top;
            string mileage_status_showing_at_top = _systemElements1.global_mileage_status_showing_at_top;



            _systemElements1.verifying_mileage_saved_data_driven(Constants.shhet_10, staff_saved_value, issue_date_saved_value, mileage_number_saved_value, numberof_miles_saved_value, vehicle_saved_value, engine_saved_value, description_saved_value, mileage_created, mileage_status, mileage_number_showint_top, mileage_status_showing_at_top, currency_saved_value, mileage_expense_saved_value);

            Assert.AreEqual("1", _systemElements1.Mileage_file_count.Text);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.mileage_files_tab.Click();
            waitformee.Until(driver => _systemElements1.expense_all_Files_label.Displayed);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            _systemElements1.no_of_col_and_rows(Constants.files_col, Constants.files_rows);
            int column_size = _systemElements1.global_col;
            int row_size = _systemElements1.global_row;

            _systemElements1.mileage_overview_tab.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));


            Assert.AreEqual(staff_value, staff_saved_value);
            Assert.AreEqual(today_date, issue_date_saved_value);

            //Mileage number showing
            int number_mileage = Convert.ToInt32(mileage_number_saved_value);
            Assert.AreEqual(mileage_number, number_mileage);

            decimal number_of_saved_values = Convert.ToDecimal(numberof_miles_saved_value);
            string values_of_miles = number_of_saved_values.ToString("0.##");
            Assert.AreEqual(number_of_mileage_value, values_of_miles);
            Assert.AreEqual(vehicle_type, vehicle_saved_value);
            Assert.AreEqual(vehicle_engine_value, engine_saved_value);
            Assert.AreEqual(description, description_saved_value);
            Assert.AreEqual("Mileage Created", mileage_created);
            Assert.AreEqual("Unpaid", mileage_status);

            //Mileage number
            string Mileage_number_value = "Mileage #" + mileage_number;
            Assert.AreEqual(Mileage_number_value, mileage_number_showint_top);

            Assert.AreEqual("Unpaid", mileage_status_showing_at_top);
            Assert.AreEqual("GBP", currency_saved_value);


            try
            {
                //Mileage expense
                double mileage_value = Convert.ToInt32(number_of_mileage_value);
                double number_of_miles = mileage_value * 0.45;
                int mileage_value_int = Convert.ToInt32(number_of_miles);
                string mileag_saved_values = $"{mileage_expense_saved_value:0.00}";
                mileag_saved_values = mileag_saved_values.Trim('£');
                decimal saved_val = Convert.ToDecimal(mileag_saved_values);
                string saved_values_1 = saved_val.ToString("0.##");
                int saved_values_12 = Convert.ToInt32(saved_values_1);
                Assert.AreEqual(mileage_value_int, saved_values_12);
            }
            catch (Exception e)
            {
                Console.WriteLine("Fail: Mileage expense value does not match");
            }

        }










    }
    
}

    
    
