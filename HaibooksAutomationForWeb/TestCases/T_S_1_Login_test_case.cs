using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using HaibooksAutomationForWeb.TestCases;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace HaibooksAutomationForWeb
{
	[TestClass]
	[TestFixture]
	[AllureNUnit]
	[AllureSuite("Login Test cases")]
	[AllureTag("Login Test Cases")]
	public class Login_test_case : Baseclass
	{
		[AllureSeverity(SeverityLevel.critical)]
		[AllureTms("TMS")]
		[AllureEpic("Regression Test")]
		[AllureStory("verify_login_test_case_with_empty_email_empty_pwd")]
		[Test, Order(1)]
		public void test_case_1_verify_login_test_case_with_empty_email_empty_pwd()
		{
			WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
			waitformee.Until(driver => _systemElements1.signin_button.Displayed);

			// Enter email address
			_systemElements1.email_adress_textbox.Click();
			_systemElements1.email_adress_textbox.Clear();

			// Enter password
			_systemElements1.password_textbox.Click();
			_systemElements1.password_textbox.Clear();
			Thread.Sleep(TimeSpan.FromSeconds(2));

			_systemElements1.signin_button.Click();
			Thread.Sleep(TimeSpan.FromSeconds(2));
			Takescreenshot("TC_1_empty_email_and_pwd.png");
			waitformee.Until(driver => _systemElements1.login_email_validation.Displayed);
			waitformee.Until(driver => _systemElements1.login_pwd_validation.Displayed);
			Console.WriteLine("Login email validation is checked and showing the following validation message: " + _systemElements1.login_email_validation.Text);
			Console.WriteLine("Login Password validation is checked and showing the following validation message: " + _systemElements1.login_pwd_validation.Text);
			Close();
		}

		[AllureSeverity(SeverityLevel.critical)]
		[AllureTms("TMS")]
		[AllureEpic("Regression Test")]
		[AllureStory("verify_login_test_case_invalid_email_invalid_pwd")]
		[Test, Order(2)]
		public void test_case_2_verify_login_test_case_invalid_email_invalid_pwd()
		{
			WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
			waitformee.Until(driver => _systemElements1.signin_button.Displayed);
			_systemElements1.verifying_login_with_data_driven(2, 1, 2, 2);
			var email_adress = _systemElements1.global_email_adress;
			var password = _systemElements1.global_password;
			Console.WriteLine(email_adress);
			Console.WriteLine(password);

			// Enter email address
			_systemElements1.email_adress_textbox.Click();
			_systemElements1.email_adress_textbox.Clear();
			_systemElements1.email_adress_textbox.SendKeys(email_adress);

			// Enter password
			_systemElements1.password_textbox.Click();
			_systemElements1.password_textbox.Clear();
			_systemElements1.password_textbox.SendKeys(password);
			Thread.Sleep(TimeSpan.FromSeconds(2));
			_systemElements1.signin_button.Click();
			Console.WriteLine("Data is added from excel sheet");
			Thread.Sleep(TimeSpan.FromSeconds(2));
			Takescreenshot("TC_2_invalid_email_invalid_pwd.png");
			waitformee.Until(driver => _systemElements1.login_email_validation.Displayed);
			waitformee.Until(driver => _systemElements1.login_pwd_validation.Displayed);
			Console.WriteLine("Login email validation is checked and showing the following validation message: " + _systemElements1.login_email_validation.Text);
			Console.WriteLine("Login Password validation is checked and showing the following validation message: " + _systemElements1.login_pwd_validation.Text);
			Close();
		}

		[AllureSeverity(SeverityLevel.critical)]
		[AllureTms("TMS")]
		[AllureEpic("Regression Test")]
		[AllureStory("verify_login_test_case_valid_email_invalid_pwd")]
		[Test, Order(3)]
		public void test_case_3_verify_login_test_case_valid_email_invalid_pwd()
		{
			WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
			waitformee.Until(driver => _systemElements1.signin_button.Displayed);
			_systemElements1.verifying_login_with_data_driven(3, 1, 3, 2);
			var email_adress = _systemElements1.global_email_adress;
			var password = _systemElements1.global_password;
			Console.WriteLine(email_adress);
			Console.WriteLine(password);

			// Enter email address
			_systemElements1.email_adress_textbox.Click();
			_systemElements1.email_adress_textbox.Clear();
			_systemElements1.email_adress_textbox.SendKeys(email_adress);

			// Enter password
			_systemElements1.password_textbox.Click();
			_systemElements1.password_textbox.Clear();
			_systemElements1.password_textbox.SendKeys(password);
			Thread.Sleep(TimeSpan.FromSeconds(2));
			_systemElements1.signin_button.Click();
			Console.WriteLine("Data imported from excel");
			Thread.Sleep(TimeSpan.FromSeconds(2));
			waitformee.Until(driver => _systemElements1.login_email_validation.Displayed);
			waitformee.Until(driver => _systemElements1.login_pwd_validation.Displayed);
			Console.WriteLine("Login email validation is checked and showing the following validation message: " + _systemElements1.login_email_validation.Text);
			Console.WriteLine("Login Password validation is checked and showing the following validation message: " + _systemElements1.login_pwd_validation.Text);
			Takescreenshot("TC_3_valid_email_invalid_pwd.png");
			Close();
		}

		[AllureSeverity(SeverityLevel.critical)]
		[AllureTms("TMS")]
		[AllureEpic("Regression Test")]
		[AllureStory("verify_that_user_is_able_to_see_the_forgot_password_option_from_login_page")]
		[Test, Order(4)]
		public void Test_case_4_verify_that_user_is_able_to_see_the_forgot_password_option_from_login_page()
		{
			WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
			waitformee.Until(driver => _systemElements1.signin_button.Displayed);
			bool forgot_password = _systemElements1.Forgot_password.Displayed;
			_systemElements1.Forgot_password.Click();
			waitformee.Until(driver => _systemElements1.email_address_send_button.Displayed);
			waitformee.Until(driver => _systemElements1.back_to_login_button.Displayed);
			_systemElements1.back_to_login_button.Click();
			Thread.Sleep(TimeSpan.FromSeconds(2));
			bool signin_button_showing = _systemElements1.signin_button.Displayed;
			Assert.Multiple(() =>
			{
				Assert.AreEqual(true, forgot_password, "Forgot password link should be showing");
				Assert.AreEqual(true, signin_button_showing, "Verify user navigate back to login page");
			});
		}

		[AllureSeverity(SeverityLevel.critical)]
		[AllureTms("TMS")]
		[AllureEpic("Regression Test")]
		[AllureStory("verify_session_expire_and_login_back_to_same_page")]
		[Test, Order(5)]
		public void test_case_5_verify_session_expire_and_login_back_to_same_page()
		{
			WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
			waitformee.Until(driver => _systemElements1.signin_button.Displayed);
			_systemElements1.verifying_login_with_data_driven(12, 1, 12, 2);
			var email_adress = _systemElements1.global_email_adress;
			var password = _systemElements1.global_password;
			Console.WriteLine(email_adress);
			Console.WriteLine(password);

			// Enter email address
			_systemElements1.email_adress_textbox.Click();
			_systemElements1.email_adress_textbox.Clear();
			_systemElements1.email_adress_textbox.SendKeys(email_adress);

			// Enter password
			_systemElements1.password_textbox.Click();
			_systemElements1.password_textbox.Clear();
			_systemElements1.password_textbox.SendKeys(password);
			Thread.Sleep(TimeSpan.FromSeconds(2));
			_systemElements1.signin_button.Click();
			Console.WriteLine("Data imported from excel");

			try
			{
				bool system_settings_display_first = _systemElements1.go_back_to_haibooks_leftmenu.Displayed;
				if (system_settings_display_first == true)
				{
					_systemElements1.go_back_to_haibooks_leftmenu.Click();
				}
			}
			catch (Exception e) { }

			Thread.Sleep(TimeSpan.FromSeconds(3));
			waitformee.Until(driver => _systemElements1.contacts_leftmenu.Displayed);
			_systemElements1.contacts_leftmenu.Click();
			waitformee.Until(driver => _systemElements1.create_new_contact.Displayed);
			Takescreenshot("page_before_session_destroy.png");

			Thread.Sleep(TimeSpan.FromSeconds(2));
			driver.Manage().Cookies.DeleteAllCookies();
			Thread.Sleep(TimeSpan.FromSeconds(1));
			driver.Navigate().Refresh();
			waitformee.Until(driver => _systemElements1.signin_button.Displayed);
			Takescreenshot("session_out.png");
			bool alert_session_out_message = _systemElements1.alert_session_out.Displayed;
			if (alert_session_out_message == true)
			{
				Console.WriteLine(_systemElements1.alert_session_out.Text);
			}

			_systemElements1.verifying_login_with_data_driven(12, 1, 12, 2);
			var email_adress1 = _systemElements1.global_email_adress;
			var password1 = _systemElements1.global_password;
			Console.WriteLine(email_adress1);
			Console.WriteLine(password1);

			// Enter email address
			_systemElements1.email_adress_textbox.Click();
			_systemElements1.email_adress_textbox.Clear();
			_systemElements1.email_adress_textbox.SendKeys(email_adress1);

			// Enter password
			_systemElements1.password_textbox.Click();
			_systemElements1.password_textbox.Clear();
			_systemElements1.password_textbox.SendKeys(password1);
			_systemElements1.signin_button.Click();
			Console.WriteLine("Data imported from excel");
			Thread.Sleep(TimeSpan.FromSeconds(3));
			Takescreenshot("after_session_login_same_page.png");
			waitformee.Until(driver => _systemElements1.contacts_leftmenu.Displayed);
			waitformee.Until(driver => _systemElements1.create_new_contact.Displayed);
			Takescreenshot("contact_screen_after_session_login_same_page.png");
			bool contact_menu_left_after_login_again = _systemElements1.contacts_leftmenu.Displayed;
			Assert.AreEqual(true, contact_menu_left_after_login_again, "Verify user login again and see the same screen");
		}
	}
}
