using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.TestCases;
using excel = Microsoft.Office.Interop.Excel;
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
        public string global_email_adress { get; set; }
        public string global_password { get; set; }

        public void verifying_login_with_data_driven(int emailadrress_row, int emailadrress_col, int password_row, int password_col)
        {
            //Creates a new instance of Excel
            excel.Application xlApp = new excel.Application();

            //Opens demo.xlsx
            excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Constants.excel_path_for_data_driven);

            //Selects the first Sheet

            excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];

            //Finds the range of cells used in the sheet
            excel.Range xlRange = xlWorksheet.UsedRange;
            Console.WriteLine(xlRange);
            string password = xlRange.Cells[password_col][password_row].value2;

            global_password = password;

            string email_adress = xlRange.Cells[emailadrress_col][emailadrress_row].value2;
            global_email_adress = email_adress;

        }


        public void verify_captcha_clickable()
        {
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
            List<IWebElement> list_for_element = new List<IWebElement>();
            list_for_element.AddRange(driver.FindElements(By.Id("recaptcha-anchor-label")));
            if (list_for_element.Count > 0)
            {
                waitformee.Until(driver => _systemElements1.captcha_label.Displayed);
                captcha_label.Click();
            }

        }
    }
}


