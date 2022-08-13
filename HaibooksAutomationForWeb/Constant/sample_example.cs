using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.TestCases;

namespace HaibooksAutomationForWeb.Constant
{
    public class sample_example : Baseclass
    {

        //////////////////////////////////////////////sample example for drop down options//////////////////////////////////////////////


        //IList<IWebElement> oSize = oSelection.Options;
        //int iListSize = oSize.Count;

        //// Setting up the loop to print all the options
        //for (int i = 0; i < iListSize; i++)
        //{
        //    // Storing the value of the option	
        //    String sValue = oSelection.Options.ElementAt(i).Text;
        //    // Printing the stored value
        //    Console.WriteLine("Value of the Item is :" + sValue);
        //}


        //select_contact_List = new SelectElement(select_contact_drop_down_option_bill);
        //IList<IWebElement> options = select_contact_List.Options;
        //size_of_drop_down_option = options.Count;


        //Set element value through javascript

        //IWebDriver driver = new ChromeDriver();
        //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //string value = (string)js.ExecuteScript("document.getElementById('elementID').setAttribute('value', 'new value for element')");

        //((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].click()", _systemElements1.Dividends_left_side);

        //Selected option ki value get krny ky liye
        // String TitleName = js.ExecuteScript("return document.getElementById('ddBankAccount').options[document.getElementById('ddBankAccount').selectedIndex].text;").ToString();

        // JavascriptExecutor jse = (JavascriptExecutor)driver;
        //jse.executeScript("document.getElementById('elementID').setAttribute('value', 'new value for element')");



        //    JavascriptExecutor jsExecutor = (JavascriptExecutor)driver;
        //    //set the text
        //    jsExecutor.executeScript("document.getElementById('firstName').value='testuser'");  
        ////get the text
        //String text = (String)jsExecutor.executeScript("return document.getElementById('firstName').value");
        //    System.out.println(text);

        //# inputting values in the text box with help of Javascript executor
        //  javaScript = "document.getElementsByClassName('gsc-input')[0].value = 'TestNG' "
        //driver.execute_script(javaScript)


        ////////////////////////////////converstion string to int////////////////////////
        ///
        //string all_dividens_counts = _systemElements1.all_Dividends_count.Text;
        //int all_divident_count = Convert.ToInt32(all_dividens_counts);


        ////////////////Softassertion using in nunit ///////////////////////

        //Assert.Multiple(() =>
        //    {              
        //        Assert.AreEqual(true, count_processing_int >=0, "Processing count value is not showing in integer");               
        //        Assert.AreEqual(true, count_toreview_int >=0, "To Review count value is not showing in integer");
        //        Assert.AreEqual(true, count_reviewed_int >= 0, "Reviewed count value is not showing in integer");
        //        Assert.AreEqual(true, count_archived_int >= 0, "archive count value is not showing in integer");
        //    });





        ////////////////////////////////////////file upload scenarios///////////////////
        //     try
        // {
        //     if(_systemElements1.Receipt_processing_count.Text == "0")
        //     {
        //         Console.WriteLine("file not moving to review automatically");
        //     }
        // }
        // catch(Exception e)
        // {
        //    if( Global_variables.receipt_toreview_count < Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text))
        //     {
        //         Console.WriteLine("file uploaded and moved to review");
        //     }
        // }
        // Thread.Sleep(TimeSpan.FromSeconds(3));
        // ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ToReview_tab);
        // //_systemElements1.ToReview_tab.Click();
        // Thread.Sleep(TimeSpan.FromSeconds(2));
        // Console.WriteLine("to review count" + Global_variables.receipt_toreview_count);
        // if(Global_variables.receipt_toreview_count < Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text))
        // {
        //     if(_systemElements1.Receipt_processing_count.Text == "0")
        //     {
        //         Console.WriteLine("Receipt has been moved to Review Tab");
        //     }
        //     else
        //     {
        //         Thread.Sleep(TimeSpan.FromSeconds(3));
        //         _systemElements1.ToReview_tab.Click();
        //     }
        // }

        // Thread.Sleep(TimeSpan.FromSeconds(5));
        // bool display_page_size = _systemElements1.page_size_display();
        // if (display_page_size == true)
        // {
        //     _systemElements1.itmes_50_display_on_page.Click();
        // }
        // Console.WriteLine("updated value:"+_systemElements1.Receipt_processing_count.Text);
        // Console.WriteLine(_systemElements1.Receipt_toreview_count.Text);
        // Console.WriteLine(_systemElements1.Receipt_reviewed_count.Text);
        // Console.WriteLine(_systemElements1.Receipt_archived_count.Text);


        //if(Global_variables.receipt_toreview_count < Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text))
        // {
        //     bool display_page_sizes = _systemElements1.page_size_display();
        //     if (display_page_sizes == true)
        //     {
        //         _systemElements1.itmes_50_display_on_page.Click();
        //     }
        // }

        // _systemElements1.no_of_col_and_rows(Constants.receipts_col, Constants.receipts_rows);
        // int column_size = _systemElements1.global_col;
        // int row_size = _systemElements1.global_row;
        // Console.WriteLine("col size" + column_size);
        // Console.WriteLine("rowsize" + row_size);
        // if (Convert.ToInt32(_systemElements1.Receipt_toreview_count.Text) == row_size - 1)
        // {
        //     Console.WriteLine("Showing Receipt is added in To Review tab");
        // }
        // else
        // {
        //     Console.WriteLine("fail");
        // }


    }
}


