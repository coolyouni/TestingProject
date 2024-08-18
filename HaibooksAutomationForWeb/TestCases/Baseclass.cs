using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HaibooksAutomationForWeb.Elements;
using HaibooksAutomationForWeb.Constant;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace HaibooksAutomationForWeb.TestCases
{
	[TestFixture]
	public class Baseclass
	{
		public IWebDriver driver;
		public string loginurl = Constants.login_main_website;
		public string homeurl = Constants.main_website;
		public system_elements _systemElements1;

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
				catch (Exception)
				{
					driver.Navigate().GoToUrl(loginurl);
				}

				var window = driver.Manage().Window;
				var position = window.Position;
				window.Minimize();
				window.Position = position;
				driver.Manage().Window.Maximize();
			}
		}

		public void Close()
		{
			driver.Quit();
			driver = null;
		}

		public void Takescreenshot(string screenshotname)
		{
			Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
			string path = Constants.screenshot_path + screenshotname;
			ss.SaveAsFile(path, ScreenshotImageFormat.Png);
		}

		public void Browser(string browser)
		{
			if (browser == Constants.Firefox)
			{
				driver = new FirefoxDriver();
				_systemElements1 = new system_elements(driver);
			}
			else if (browser == Constants.chrome)
			{
				new DriverManager().SetUpDriver(new ChromeConfig());
				var chromeOptions = new ChromeOptions();
				chromeOptions.AddArgument("start-maximized");
				driver = new ChromeDriver(chromeOptions);
				_systemElements1 = new system_elements(driver);
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

		public void Take_home_page()
		{
			_systemElements1 = new system_elements(driver);
			driver.Navigate().GoToUrl(homeurl);
			WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			waitformee.Until(driver => _systemElements1.login_button.Displayed);
		}
	}
}
