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

    }
}


