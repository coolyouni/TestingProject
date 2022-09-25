﻿using NUnit.Framework;
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
        public string loginurl = Constants.login_main_website;
       public string homeurl = Constants.main_website;
        public system_elements _systemElements1;
        public T_S_4_Create_new_invoice_test_case Create_new_test_case1;
      


        [SetUp]
        public void TestInitForWeb()
        {
            if (driver == null)
            {
                Browser(Constants.chrome);

                try
                {
                    driver.Navigate().GoToUrl(loginurl);

                }
                catch (Exception e)
                {
                    driver.Navigate().GoToUrl(loginurl);
                }
                //WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

               
                var window = driver.Manage().Window;
                var position = window.Position;
                window.Minimize();
                window.Position = position;
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
             // FirefoxProfile firefoxprofile = new FirefoxProfile();            
              
                driver = new FirefoxDriver();
                _systemElements1 = new system_elements(driver);
                //Create_new_test_case1 = new Create_new_test_case(driver);

            }


            else if (browser == Constants.chrome)
            {
                //var sessionIdProperty = typeof(RemoteWebDriver).GetProperty("SessionId", BindingFlags.Instance | BindingFlags.NonPublic);
                //SessionId sessionId = sessionIdProperty.GetValue(driver, null) as SessionId;
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                var options = new ChromeOptions();                
                options.AddArguments("--enable-extensions", "--ignore-certificate-errors", "general.useragent.override");
                //options.AddArgument("headless");
                var directories = GetDirectories(@"C:\Users\younas.rehman\AppData\Local\Temp\Chrome");
                Console.WriteLine("Checkpath::::" + directories.ElementAt(directories.Count - 1));
                var pathfor_chrome = directories.ElementAt(directories.Count - 1);
                driver = new ChromeDriver(pathfor_chrome, options);            
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



        public static List<string> GetDirectories(string path, string searchPattern = "*",
       SearchOption searchOption = SearchOption.AllDirectories)
        {
            if (searchOption == SearchOption.TopDirectoryOnly)
                return Directory.GetDirectories(path, searchPattern).ToList();

            var directories = new List<string>(GetDirectories(path, searchPattern));

            for (var i = 0; i < directories.Count; i++)
                directories.AddRange(GetDirectories(directories[i], searchPattern));

            return directories;
        }

        private static List<string> GetDirectories(string path, string searchPattern)
        {
            try
            {
                return Directory.GetDirectories(path, searchPattern).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }

        public void take_home_page()
        {
            _systemElements1 = new system_elements(driver);
            driver.Navigate().GoToUrl(homeurl);
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitformee.Until(driver => _systemElements1.login_button.Displayed);
        }      



        }
}
