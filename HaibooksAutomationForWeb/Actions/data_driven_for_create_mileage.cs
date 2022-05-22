using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.TestCases;
using Excel = Microsoft.Office.Interop.Excel;  
using OpenQA.Selenium;
using System.Threading;
using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using HaibooksAutomationForWeb.Constant;

namespace HaibooksAutomationForWeb.Elements
{
    public partial class system_elements : Baseclass
    {
        public string global_staff_saved_value { get; set; }
        public string global_issue_date_saved_value { get; set; }
        public string  global_mileage_number_saved_value { get; set; }
        public string global_currency_saved_value { get; set; }
        public string global_numberof_miles_saved_value { get; set; }
        public string global_mileage_expense_saved_value { get; set; }
        public string global_vehicle_saved_value { get; set; }
        public string global_engine_saved_value { get; set; }
        public string global_description_saved_value { get; set; }
        public string global_mileage_created { get; set; }
        public string global_mileage_status { get; set; }
        public string global_mileage_number_showint_top { get; set; }
        public string global_mileage_status_showing_at_top { get; set; }


        public void verifying_mileage_added_data_driven(int sheet_no, string staff_value, string today_date, int mileage_number, string number_of_mileage_value,
                                                        string vehicle_type, string vehicle_engine_value, string description)
        { 
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;       

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Constants.excel_path_for_data_driven);          
            xlWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(sheet_no);
            xlWorkSheet.Activate();
            //string new_value ;
            ////new_value = xlWorkSheet.Cells[2, 3].value2;
            //Console.WriteLine(new_value);          
            xlWorkSheet.Cells[2, 2] = staff_value;
            xlWorkSheet.Cells[3, 2] = today_date;
            xlWorkSheet.Cells[4, 2] = mileage_number;
            xlWorkSheet.Cells[5, 2] = number_of_mileage_value;
            xlWorkSheet.Cells[6, 2] = vehicle_type;
            xlWorkSheet.Cells[7, 2] = vehicle_engine_value;
            xlWorkSheet.Cells[8, 2] = description;                   
            xlWorkbook.Save();
            xlWorkbook.Close(true, misValue, misValue);
            xlApp.Quit();                
        }

        public void verifying_mileage_saved_data_driven(int sheet_no, string staff_saved_value, string issue_date_saved_value,string mileage_number_saved_value, string numberof_miles_saved_value, string vehicle_saved_value, string engine_saved_value, string description_saved_value, string mileage_created, string mileage_status, string mileage_number_showint_top, string mileage_status_showing_at_top, string currency_saved_value, string mileage_expense_saved_value)

        {
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Constants.excel_path_for_data_driven);
            xlWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(sheet_no);
            xlWorkSheet.Activate();
            //string new_value ;
            ////new_value = xlWorkSheet.Cells[2, 3].value2;
            //Console.WriteLine(new_value);          
            xlWorkSheet.Cells[2, 3] = staff_saved_value;
            xlWorkSheet.Cells[3, 3] = issue_date_saved_value;
            xlWorkSheet.Cells[4, 3] = mileage_number_saved_value;
            xlWorkSheet.Cells[5, 3] = numberof_miles_saved_value;
            xlWorkSheet.Cells[6, 3] = vehicle_saved_value;
            xlWorkSheet.Cells[7, 3] = engine_saved_value;
            xlWorkSheet.Cells[8, 3] = description_saved_value;
            xlWorkSheet.Cells[9, 3] = mileage_created;
            xlWorkSheet.Cells[10, 3] = mileage_status;
            xlWorkSheet.Cells[11, 3] = mileage_number_showint_top;
            xlWorkSheet.Cells[12, 3] = mileage_status_showing_at_top;
            xlWorkSheet.Cells[13, 3] = currency_saved_value;
            xlWorkSheet.Cells[14, 3] = mileage_expense_saved_value;          
            xlWorkbook.Save();
            xlWorkbook.Close(true, misValue, misValue);
            xlApp.Quit();
        }





        public void perform_saved_mileage()
        {
            _systemElements1 = new system_elements(driver);
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(12));
            waitformee.Until(driver => _systemElements1.staff_saved_value.Displayed);

            //staff 
            string staff_saved_value = _systemElements1.staff_saved_value.GetAttribute("value");
            global_staff_saved_value = staff_saved_value;
           
            //issue date
            string issue_date_saved_value = _systemElements1.issue_date_saved_value.GetAttribute("value");
            global_issue_date_saved_value = issue_date_saved_value;
          
            //Mileage number
            string mileage_number_saved_value = _systemElements1.mileage_number_saved_value.GetAttribute("value");
            global_mileage_number_saved_value = mileage_number_saved_value;
            Console.WriteLine("Mileage Number" + mileage_number_saved_value);
            //Currency
            string currency_saved_value = _systemElements1.currency_saved_value.Text;
            global_currency_saved_value = currency_saved_value;
            

            //Number of miles
            string numberof_miles_saved_value = _systemElements1.numberof_miles_saved_value.GetAttribute("value");
            global_numberof_miles_saved_value = numberof_miles_saved_value;
          

            //Mileage Expense
            string mileage_expense_saved_value = _systemElements1.mileage_expense_saved_value.GetAttribute("value");
            global_mileage_expense_saved_value = mileage_expense_saved_value;
           

            //Vehicle
            string vehicle_saved_value = _systemElements1.vehicle_saved_value.GetAttribute("value");
            global_vehicle_saved_value = vehicle_saved_value;
           

            //Engine value            
            string engine_saved_value = _systemElements1.engine_saved_value.GetAttribute("value");
            global_engine_saved_value = engine_saved_value;
          

            //Description
            string description_saved_value = _systemElements1.description_saved_value.GetAttribute("value");
            global_description_saved_value = description_saved_value;
       

            //Mileage created
            string mileage_created = _systemElements1.mileage_created.Text;
            global_mileage_created = mileage_created;
           

            //Mileage status            
            string mileage_status = _systemElements1.mileage_status.Text;
            global_mileage_status = mileage_status;
            

            //Mileage number showing at top            
            string mileage_number_showint_top = _systemElements1.invoice_number.Text;
            global_mileage_number_showint_top = mileage_number_showint_top;
            

            //Mileage status showing at top

            string mileage_status_showing_at_top = _systemElements1.mileage_status_showing_at_top.Text;
            global_mileage_status_showing_at_top = mileage_status_showing_at_top;         


        }







    }
}
