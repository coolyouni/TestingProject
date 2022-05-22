using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.TestCases;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HaibooksAutomationForWeb.Elements
{
   public partial class system_elements: Baseclass
    {
      public void perform_click_to_dashboard()
        {
            _systemElements1 = new system_elements(driver);
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                bool system_settings_display_first = _systemElements1.go_back_to_haibooks_leftmenu.Displayed;
                if (system_settings_display_first == true)
                {                   
                    _systemElements1.redirect_to_menu_from_settings();
                    waitformee.Until(driver => _systemElements1.go_back_to_haibooks_leftmenu.Displayed);
                    _systemElements1.go_back_to_haibooks_leftmenu.Click();
                }
            }
            catch (Exception e) { }
            Thread.Sleep(TimeSpan.FromSeconds(3));
            waitformee.Until(driver => _systemElements1.dashboard_leftmenu.Displayed);
            _systemElements1.dashboard_leftmenu.Click();
        }
    }
}
