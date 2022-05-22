using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.Constant;
using HaibooksAutomationForWeb.MyHelper;
using HaibooksAutomationForWeb.TestCases;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HaibooksAutomationForWeb.Elements
{
    public partial class system_elements : Baseclass
    {
        public void add_person()
        {

            //Add person form

            //Add first name
            MyHelperClass first_name = new MyHelperClass();
            var random_first_name = first_name.IncludeMessagetoReceiver(7);
            _systemElements1.person_first_name.SendKeys(random_first_name);

            //Add Last name
            MyHelperClass last_name = new MyHelperClass();
            var random_last_name = first_name.IncludeMessagetoReceiver(7);
            _systemElements1.person_last_name.SendKeys(random_last_name);

            //Number of shares
            _systemElements1.person_number_of_shared.Clear();
            _systemElements1.person_number_of_shared.SendKeys(Constants.number_of_shares);

            _systemElements1.save_button.Click();

        }

    }
}


