using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.MyHelper;
using HaibooksAutomationForWeb.TestCases;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HaibooksAutomationForWeb.Elements
{
   public partial class system_elements: Baseclass
    {
        public int global_col { get; set; }
        public int global_row { get; set; }
        public void no_of_col_and_rows(string xpath_for_col, string xpath_for_row)
        {

            //Finding no of columns            
            var find_col = driver.FindElement(By.XPath(xpath_for_col));
            List<IWebElement> total_columns_array = new List<IWebElement>(find_col.FindElements(By.TagName("col")));
            int total_column = total_columns_array.Count();         
            global_col = total_column;

            //Finding no of rows
            var find_row = driver.FindElement(By.XPath(xpath_for_row));
            List<IWebElement> total_rows_array = new List<IWebElement>(find_row.FindElements(By.TagName("tr")));
            int RowsCounter = total_rows_array.Count();
            global_row = RowsCounter;



            //String strRowData = "";
            //List<String> ColumnValues = new List<String>();         
            //Console.WriteLine("Rows are: " + RowsCounter);
            //Boolean status = false;
            //foreach(var data in total_rows_array)
            //{
            //    string data_showing = data.Text;

            //    if(data_showing.Contains("Younas Rehman"))
            //    {
            //        Console.WriteLine(data_showing);
            //        status = true;
            //        break;
            //    }
            //}

            //Assert.IsTrue(status);

        }



    }
}
