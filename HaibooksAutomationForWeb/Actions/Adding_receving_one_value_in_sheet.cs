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
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HaibooksAutomationForWeb.Elements
{
    public partial class system_elements : Baseclass
    {
        public string global_value { get; set; }

        public void adding_one_value_in_sheet(int sheet_no, string value,int row, int col)

        {
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Constants.ExcelPathForDataDriven);
            xlWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(sheet_no);
            xlWorkSheet.Activate();
            xlWorkSheet.Cells[row, col] = business_name;
            xlWorkbook.Save();
            xlWorkbook.Close(true, misValue, misValue);
            xlApp.Quit();
        }


        public void receiving_one_value_from_sheet(int sheet_no,int col, int row)

        {
            //Creates a new instance of Excel
            Excel.Application xlApp = new Excel.Application();

            //Opens demo.xlsx
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Constants.ExcelPathForDataDriven);

            //Selects the first Sheet

            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[sheet_no];

            //Finds the range of cells used in the sheet
            Excel.Range xlRange = xlWorksheet.UsedRange;
            Console.WriteLine(xlRange);
            string value = xlRange.Cells[col][row].value2;

            global_value = value;           

            xlApp.Quit();
        }


       






    }
}


