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
       
       

        public void verifying_invoice_added_data_driven(int sheet_no,string selected_text_contact_info, string issue_date, string due_date, string Terms,
                                                        int terms_days,int invoice_number, string account_type,string unit_cost, string quantity,
                                                        string vat_rate,string vat_total,string total_amount,string sub_total,string  tax,  
                                                        string total_value,string amount_paid,string amount_due,string comments,string description, 
                                                        string status,string invoice_created,string price_bill)

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
            xlWorkSheet.Cells[2, 2] = selected_text_contact_info;
            xlWorkSheet.Cells[3, 2] = issue_date;
            xlWorkSheet.Cells[4, 2] = due_date;
            xlWorkSheet.Cells[5, 2] = Terms;
            xlWorkSheet.Cells[6, 2] = terms_days;
            xlWorkSheet.Cells[7, 2] = invoice_number;
            xlWorkSheet.Cells[8, 2] = account_type;
            xlWorkSheet.Cells[9, 2] = unit_cost;
            xlWorkSheet.Cells[10, 2] = quantity;
            xlWorkSheet.Cells[11, 2] = vat_rate;
            xlWorkSheet.Cells[12, 2] = vat_total;
            xlWorkSheet.Cells[13, 2] = total_amount;
            xlWorkSheet.Cells[14, 2] = sub_total;
            xlWorkSheet.Cells[15, 2] = tax;
            xlWorkSheet.Cells[16, 2] = total_value;
            xlWorkSheet.Cells[17, 2] = amount_paid;
            xlWorkSheet.Cells[18, 2] = amount_due;
            xlWorkSheet.Cells[19, 2] = comments;
            xlWorkSheet.Cells[20, 2] = description;
            xlWorkSheet.Cells[21, 2] = status;
            xlWorkSheet.Cells[22, 2] = invoice_created;
            xlWorkSheet.Cells[23, 2] = price_bill;
            xlWorkbook.Save();
            xlWorkbook.Close(true, misValue, misValue);
            xlApp.Quit();                
        }

        public void verifying_invoice_saved_data_driven(int sheet_no, string selected_text_contact_info, string issue_date, string due_date, string Terms,
                                                      string terms_days, string invoice_number, string account_type, string unit_cost, string quantity,
                                                      string vat_rate, string vat_total, string total_amount, string sub_total, string tax,
                                                      string total_value, string amount_paid, string amount_due, string comments, string description,
                                                      string status, string invoice_created, string price_bill)

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
            xlWorkSheet.Cells[2, 3] = selected_text_contact_info;
            xlWorkSheet.Cells[3, 3] = issue_date;
            xlWorkSheet.Cells[4, 3] = due_date;
            xlWorkSheet.Cells[5, 3] = Terms;
            xlWorkSheet.Cells[6, 3] = terms_days;
            xlWorkSheet.Cells[7, 3] = invoice_number;
            xlWorkSheet.Cells[8, 3] = account_type;
            xlWorkSheet.Cells[9, 3] = unit_cost;
            xlWorkSheet.Cells[10, 3] = quantity;
            xlWorkSheet.Cells[11, 3] = vat_rate;
            xlWorkSheet.Cells[12, 3] = vat_total;
            xlWorkSheet.Cells[13, 3] = total_amount;
            xlWorkSheet.Cells[14, 3] = sub_total;
            xlWorkSheet.Cells[15, 3] = tax;
            xlWorkSheet.Cells[16, 3] = total_value;
            xlWorkSheet.Cells[17, 3] = amount_paid;
            xlWorkSheet.Cells[18, 3] = amount_due;
            xlWorkSheet.Cells[19, 3] = comments;
            xlWorkSheet.Cells[20, 3] = description;
            xlWorkSheet.Cells[21, 3] = status;
            xlWorkSheet.Cells[22, 3] = invoice_created;
            xlWorkSheet.Cells[23, 3] = price_bill;
            xlWorkbook.Save();
            xlWorkbook.Close(true, misValue, misValue);
            xlApp.Quit();
        }











    }
}
