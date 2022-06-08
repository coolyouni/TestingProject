using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using HaibooksAutomationForWeb.Elements;
using HaibooksAutomationForWeb;


using HaibooksAutomationForWeb.Constant;
using OpenQA.Selenium.Remote;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HaibooksAutomationForWeb.TestCases
{

    [TestFixture]
    public class Baseclass
    {
        public IWebDriver driver;
        public string homeURL = Constants.Any_link;
        public system_elements _systemElements1;
        public Create_new_invoice_test_case Create_new_test_case1;


        [SetUp]
        public void TestInitForWeb()
        {
            if (driver == null)
            {
                Browser(Constants.chrome);

                try
                {
                    driver.Navigate().GoToUrl(homeURL);

                }
                catch (Exception e)
                {
                    driver.Navigate().GoToUrl(homeURL);
                }
                //WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                driver.Manage().Window.Maximize();
            }
        }



        public void close()
        {
            driver.Quit();
            driver = null;
        }




        public void takesceenshot(string screenshotname)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string path = Constants.screenshot_path + screenshotname;
            ss.SaveAsFile(path, ScreenshotImageFormat.Png);
        }




        public void Browser(string browser)
        {
            if (browser == Constants.Firefox)
            {
                // string path_new = @"C:\Users\younas.rehman\source\repos\HaibooksAutomationForWeb\packages\Selenium.Firefox.WebDriver.0.27.0\driver\geckodriver.exe";
                //string path = @"C:\Users\younas.rehman\AppData\Local\Mozilla\Firefox\Profiles\amita4ga.default";
                // FirefoxProfile ffprofile = new FirefoxProfile();

                //   ffprofile.AddExtension(@"C:\Users\younas.rehman\Downloads\im_not_robot_captcha_clicker-1.3.1-fx.xpi");
                //  FirefoxOptions options = new FirefoxOptions()
                //   {
                //       Profile = ffprofile
                //     };

                //   driver = new FirefoxDriver(options);
                //FirefoxOptions opt = new FirefoxOptions();
                //FirefoxProfile firefoxprofile = new FirefoxProfile();             

                driver = new FirefoxDriver();
                _systemElements1 = new system_elements(driver);
                //Create_new_test_case1 = new Create_new_test_case(driver);

            }


            else if (browser == Constants.chrome)
            {
                //var sessionIdProperty = typeof(RemoteWebDriver).GetProperty("SessionId", BindingFlags.Instance | BindingFlags.NonPublic);
                //SessionId sessionId = sessionIdProperty.GetValue(driver, null) as SessionId;


                var options = new ChromeOptions();
                options.AddArguments("--enable-extensions", "--ignore-certificate-errors", "general.useragent.override");
                //options.AddArgument("headless");
                driver = new ChromeDriver(options);
                _systemElements1 = new system_elements(driver);



                //new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                ////For adding Extensions             
                //var options = new ChromeOptions();
                //options.AddExtension(Path.GetFullPath(@"C:\Users\younas.rehman\AppData\Local\Google\Chrome\User Data\Default\Extensions\ceipnlhmjohemhfpbjdgeigkababhmjc\1.2.1_0.crx"));
                //options.AddExtension(Path.GetFullPath(@"C:\Users\younas.rehman\AppData\Local\Google\Chrome\User Data\Default\Extensions\mpbjkejclgfgadiemmefgebjfooflfhl\1.3.1_0.crx"));
                //var pathfor_chrome = @"C:\Users\younas.rehman\AppData\Local\Temp\Chrome\99.0.4844.51\X64\";
                //options.AddArguments("--enable-extensions", "--ignore-certificate-errors", "general.useragent.override");
                //driver = new ChromeDriver(pathfor_chrome, options);
                //_systemElements1 = new system_elements(driver);
            }
        }





    }
}
