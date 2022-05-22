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
        public int row,col_1, col_2, col_3;
       

        public void adding_response_code_in_excel(int sheet_no,string url, int status_code, int error_code,string timeTaken, int indexOfRow)

        {        
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;     

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Constants.excel_path_for_data_driven);          
            xlWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(sheet_no);
            xlWorkSheet.Activate();
            ////string new_value ;
            //////new_value = xlWorkSheet.Cells[2, 3].value2;
            ////Console.WriteLine(new_value);
            //col_1 = col_1 + 1;
            //col_2 = 2 + 1;
            //col_3 = 3 + 1;
            xlWorkSheet.Cells[indexOfRow, 1] = url;
            xlWorkSheet.Cells[indexOfRow, 2] = status_code;
            xlWorkSheet.Cells[indexOfRow, 3] = error_code;
            xlWorkSheet.Cells[indexOfRow, 4] = timeTaken;
            xlWorkbook.Save();
            xlWorkbook.Close(true, misValue, misValue);
            xlApp.Quit();                
        }

       



    }
}
