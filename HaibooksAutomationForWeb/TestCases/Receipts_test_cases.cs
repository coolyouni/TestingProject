using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Diagnostics;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Firefox;
using  HaibooksAutomationForWeb.TestCases;
using HaibooksAutomationForWeb;
using HaibooksAutomationForWeb.MyHelper;
using HaibooksAutomationForWeb.Constant;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using System.Linq;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;
using System.Net;
using SoftAssert;
using FluentAssertions;

namespace HaibooksAutomationForWeb
{
    [TestClass]
    public class Receipts_test_cases : Baseclass
    {


        [Test, Order(1)]
        //Receipts >> verify that user can upload single receipt successfully
        //HAIB-TC-16

        public void test_case_1_Receipts_verify_user_upload_single_receipt_successfully()
        {
            _systemElements1.user_already_login();
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            waitformee.Until(driver => _systemElements1.create_new_left_side.Displayed);
            _systemElements1.receipt_left_menu.Click();
            waitformee.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            waitformee.Until(driver => _systemElements1.Add_receipt_button.Displayed);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            string abc = _systemElements1.All_receipts_count_1.GetAttribute("name");
            Console.WriteLine("count" + abc);
            _systemElements1.Add_receipt_button.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            using (Process exeProcess = Process.Start(Constants.file_upload_script)) ;
            Thread.Sleep(TimeSpan.FromSeconds(3));
          


        }









    }
    }

    
    
