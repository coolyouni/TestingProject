using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.Constant;
using HaibooksAutomationForWeb.MyHelper;
using HaibooksAutomationForWeb.TestCases;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HaibooksAutomationForWeb.Elements
{
    public partial class system_elements : Baseclass
    {
        public string global_selected_value_contact_info { get; set; }

        public string global_selected_text_contact_info { get; set; }
        public string global_account_type { get; set; }
        public string global_vat_selected_value { get; set; }

        //invoice creation
        public string selected_text_contact_info1 { get; set; }
        public string global_today_date { get; set; }
        public string global_addition_days { get; set; }
        public string global_terms { get; set; }
        public int global_terms_days { get; set; }
        public int global_invoice_number { get; set; }
        public string global_sales_turnover_value { get; set; }
        public string global_unit_cost_value { get; set; }
        public string global_Quantity { get; set; }
        public string global_vat_value_20_vat { get; set; }
        public string global_toal_value { get; set; }
        public string global_total_amount_expected { get; set; }
        public string global_subtotal { get; set; }
        public string global_tax { get; set; }
        public string global_total_value_expected { get; set; }
        public string global_amount_paid { get; set; }
        public string global_amount_due { get; set; }
        public string global_comment_added { get; set; }
        public string global_description { get; set; }
        public string global_status { get; set; }
        public string global_invoice_created { get; set; }
        public string global_price_bill_expected { get; set; }       
        public string  global_tota_value_expected { get; set; }
        public string global_total_amount_value { get; set; }
        public string global_price_bill_actual { get; set; }
        public string global_Net_Amount_expected { get; set; }
        public string global_vat_tax_value { get; set; }
        public string global_total_value_actual { get; set; }
        public string global_amount_due_actual { get; set; }



        //Saved data/////////////////////////////////////////////
        public string global_contact_saved { get; set; }
        public string global_invoice_issue_date { get; set; }
        public string global_invoice_due_date { get; set; }
        public string global_invoice_custom { get; set; }
        public string global_invoice_term_days { get; set; }
        public string global_detail_invoice_number { get; set; }
        public string global_account_types { get; set; }
        public string global_invoice_detail_unit_cost { get; set; }
        public string global_invoice_quantity { get; set; }
        public string global_invoice_vat_rate { get; set; }
        public string global_invoice_vat_total { get; set; }
        public string global_invoice_detail_total_amount { get; set; }
        public string global_invoice_detail_subtotal { get; set; }
        public string global_invoice_detail_tax { get; set; }
        public string global_invoice_detail_total { get; set; }
        public string global_invoice_detail_amount_paid { get; set; }
        public string global_invoice_detail_amount_due { get; set; }
        public string global_invoice_detail_comment { get; set; }
        public string global_invoice_detail_description { get; set; }
        public string global_invoice_detail_invoice_status { get; set; }
        public string global_invoice_detail_invoice_created { get; set; }
        public string global_invoice_detail_price { get; set; }


        //Mileage 
        public int global_mileage_number { get; set; }
        public string global_staff_value { get; set; }
        public string global_number_of_mileage_value { get; set; }
        public string global_vehicle_type { get; set; }
        public string global_vehicle_engine_value { get; set; }



        public void perform_select_contact(string module)
        {
            _systemElements1 = new system_elements(driver);
            //select contact list checked in sales invoice
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            List<IWebElement> list_for_element = new List<IWebElement>();
            if(module==Constants.invoice_creation)
            {
                list_for_element.AddRange(driver.FindElements(By.Id("createInvoice_contactInformationDropdown")));
            }
            else if(module == Constants.bill_creation)
            {
                list_for_element.AddRange(driver.FindElements(By.Id("select-contact")));                
            }

            else 
            {
              list_for_element.AddRange(driver.FindElements(By.Id("select-contact")));
            }

            if (list_for_element.Count > 0)
            {
                int size_of_drop_down_option, index;
                SelectElement select_contact_List;
                string selected_value_for_contact_info, contact_info_title;
                if (module == Constants.invoice_creation)
                {
                    select_contact_List = new SelectElement(select_contact_drop_down_option);
                    IList<IWebElement> options = select_contact_List.Options;
                    size_of_drop_down_option = options.Count;
                }
                else
                {
                    select_contact_List = new SelectElement(select_contact_drop_down_option_bill);
                    IList<IWebElement> options = select_contact_List.Options;
                    size_of_drop_down_option = options.Count;
                }


                if (size_of_drop_down_option <= 2)
                {
                    //Add contact
                   //_systemElements1.select_contact_drop_down_option.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    waitformee.Until(driver => _systemElements1.add_contact.Displayed);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    add_contact.Click();
                    waitformee.Until(driver => _systemElements1.add_contact_business_full_name.Displayed);

                    //Adding business
                    MyHelperClass business_name = new MyHelperClass();
                    var business_full_name = business_name.template_message_body(20);
                    _systemElements1.add_contact_business_full_name.SendKeys(business_full_name);

                    //Adding meail
                    //Adding Email
                    MyHelperClass c = new MyHelperClass();
                    string email_value = c.GetRandomEmailvalue(Constants.firstname);
                    Console.WriteLine("Email Value: " + email_value);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    _systemElements1.add_contact_email.SendKeys(email_value);

                    _systemElements1.add_contact_building_nu.SendKeys(Constants.Buidling_adress);
                    _systemElements1.add_contact_street.SendKeys(Constants.street_no);
                    _systemElements1.add_contact_city.SendKeys(Constants.city);
                    _systemElements1.add_contact_post_code.SendKeys(Constants.post_code);

                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    //country adding
                    SelectElement drpCountry = new SelectElement(_systemElements1.CountryCode_textbox);
                    drpCountry.SelectByValue("GB");

                    //Adding region
                    _systemElements1.add_contact_region.SendKeys(Constants.region);

                    _systemElements1.Save_button_any.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));

                }
                else if (size_of_drop_down_option > 2)
                {
                    select_contact_List.SelectByIndex(2);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                Thread.Sleep(TimeSpan.FromSeconds(2));
                if (module == Constants.invoice_creation)
                {
                   selected_value_for_contact_info = select_contact_drop_down_value.GetAttribute("value");
                    global_selected_value_contact_info = selected_value_for_contact_info;
                    contact_info_title = _systemElements1.select_contact_drop_down_value.GetAttribute("data-content");
                    index = contact_info_title.IndexOf('>');
                    contact_info_title = contact_info_title.Remove(0, index + 1);
                    index = contact_info_title.IndexOf('>');
                    contact_info_title = contact_info_title.Remove(0, index + 1);
                    global_selected_text_contact_info = contact_info_title;

                }
                else if(module == Constants.bill_creation)
                {
                    selected_value_for_contact_info = select_contact_drop_down_value_bill.GetAttribute("value");
                    global_selected_value_contact_info = selected_value_for_contact_info;
                    contact_info_title = _systemElements1.select_contact_drop_down_value_bill.GetAttribute("data-content");
                    index = contact_info_title.IndexOf('>');
                    contact_info_title = contact_info_title.Remove(0, index + 1);
                    index = contact_info_title.IndexOf('>');
                    contact_info_title = contact_info_title.Remove(0, index + 1);
                    global_selected_text_contact_info = contact_info_title;
                }

                else
                {
                    selected_value_for_contact_info = select_contact_drop_down_value_bill.GetAttribute("value");
                    global_selected_value_contact_info = selected_value_for_contact_info;
                    contact_info_title = _systemElements1.select_contact_drop_down_value_bill.GetAttribute("data-content");
                    index = contact_info_title.IndexOf('>');
                    contact_info_title = contact_info_title.Remove(0, index + 1);
                    index = contact_info_title.IndexOf('>');
                    contact_info_title = contact_info_title.Remove(0, index + 1);
                    global_selected_text_contact_info = contact_info_title;

                }
                             

            }
        }



        public void perform_select_account(string account_type, string module)
        {
            //select contact list checked in sales invoice

            List<IWebElement> list_for_element1 = new List<IWebElement>();
            list_for_element1.AddRange(driver.FindElements(By.Id("bill-item-0-chartOfAccounts")));
            if (list_for_element1.Count > 0)
            {
                //SelectElement select_contact_List1;
                //int size_of_drop_down_option;
                //if (module == Constants.invoice_creation)
                //{
                SelectElement  select_contact_List1 = new SelectElement(chart_of_account);
                    IList<IWebElement> options = select_contact_List1.Options;
                int size_of_drop_down_option = options.Count;
                //}
                //else {
                    //select_contact_List1 = new SelectElement(chart_of_account);
                    //IList<IWebElement> options = select_contact_List1.Options;
                    //size_of_drop_down_option = options.Count;
                //}



                if (size_of_drop_down_option <= 2)
                {
                    //Add Account
                }
                else if (size_of_drop_down_option > 2)
                {
                    //select_contact_List1.SelectByValue(account_type);
                    //Thread.Sleep(TimeSpan.FromSeconds(1));
                    //SelectElement drpCountry = new SelectElement(_systemElements1.chart_of_account);
                    //string data_content_type = chart_of_account.GetAttribute("data-content");
                    if (module == Constants.invoice_creation)
                    {
                        _systemElements1.click_on_sales_first_drop_down.Click();
                    }
                    else if (module == Constants.bill_creation)
                    {
                        _systemElements1.click_on_bills_first_drop_down.Click();
                    }
                    else if (module == Constants.expense_creation)
                    {
                        _systemElements1.click_on_bills_first_drop_down.Click();
                    }
                }

                string account_type_saved = chart_of_account.GetAttribute("value");
                Console.WriteLine("Account type value: " + account_type_saved);
                global_account_type = account_type_saved;
            }

        }

            public void perform_select_VAT(string vat_value)
            {
                //select contact list checked in sales invoice

                List<IWebElement> list_for_element1 = new List<IWebElement>();
                list_for_element1.AddRange(driver.FindElements(By.Id("bill-item-0-vatRates")));
                if (list_for_element1.Count >= 0)
                {
                    SelectElement select_contact_List1 = new SelectElement(vat_drop_down);
                    IList<IWebElement> options = select_contact_List1.Options;
                    int size_of_drop_down_option = options.Count;
                    if (size_of_drop_down_option <= 2)
                    {
                        //Add Account
                    }
                    else if (size_of_drop_down_option > 2)
                    {
                        select_contact_List1.SelectByValue(vat_value);
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                    quantity.SendKeys(Keys.Tab);
                    string vat_value_saved = vat_drop_down.GetAttribute("value");
                    Console.WriteLine("Vat value: " + vat_value_saved);               
                    global_vat_selected_value= vat_value_saved;
                }
            }

        public void perform_adding_invoice_bill_expense_mileage(string module)
        {
            _systemElements1 = new system_elements(driver);

            //if (module == Constants.expense_creation)
            //{
            //    //Select Paid by Staff
            //    SelectElement paid_by = new SelectElement(_systemElements1.paid_by_drop_down);
            //    paid_by.SelectByText(Constants.paid_by);
            //    Thread.Sleep(TimeSpan.FromSeconds(2));

            //    //Select staf member            
            //    SelectElement staff = new SelectElement(_systemElements1.staff_drop_down);
            //    staff.SelectByIndex(2);              

            // }

            string vat;
            //select contact info
            _systemElements1.perform_select_contact(module);
            string drop_down_value_contact_info = _systemElements1.global_selected_value_contact_info;
            string selected_text_contact_info = _systemElements1.global_selected_text_contact_info;

            selected_text_contact_info1 = selected_text_contact_info;

            //Add Issue Date
            DateTime odate = DateTime.Today;
            var today_date_string = odate.ToString("dd/MM/yyyy");
            var today_date = today_date_string.Replace('-', '/');


            global_today_date = today_date;

            //Add due date
            DateTime ADD_DAYS = DateTime.Today.AddDays(30);
            var add_date_string = ADD_DAYS.ToString("dd/MM/yyyy");
            var addition_days = add_date_string.Replace('-', '/');
            global_addition_days = addition_days;
            _systemElements1.issue_date.Clear();
            _systemElements1.issue_date.SendKeys(today_date);

            //Add Due Date
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //Actions action = new Actions(driver);
            //action.MoveToElement(_systemElements1.due_date).Click().Perform();           
            //_systemElements1.due_date.Clear();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            //_systemElements1.due_date.SendKeys(addition_days);

            //Add Terms
            if(module != Constants.expense_creation)
            { 
            Thread.Sleep(TimeSpan.FromSeconds(3));
            _systemElements1.terms_selection("Custom", 30, module);
            global_terms = "custom";
            global_terms_days = 30;
            }
            //Add invoice numbner
            Thread.Sleep(TimeSpan.FromSeconds(1));
            //MyHelperClass c = new MyHelperClass();
            //var invoice_value_int = c.GetRandominvoicevalue(4);
            //string invoice_value = invoice_value_int.ToString();

            //_systemElements1.invoice_number_txtbox.Clear();
            //_systemElements1.invoice_number_txtbox.SendKeys(invoice_value);

            if (module == Constants.expense_creation)
            {
                var expense_number = Convert.ToInt32(_systemElements1.expense_number.GetAttribute("value"));
                Console.WriteLine("expense_number:" + expense_number);
                global_invoice_number = expense_number;
            }
            if (module != Constants.expense_creation)
            {
                var invoice_number = Convert.ToInt32(_systemElements1.invoice_number_txtbox.GetAttribute("value"));
                Console.WriteLine("invoice no:" + invoice_number);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                global_invoice_number = invoice_number;
                _systemElements1.invoice_number_txtbox.SendKeys(Keys.Tab);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                //check if invoice number is already used
                //int list_for_element= _systemElements1.validation_invoice_number();
                //if (list_for_element > 0)
                //{
                //    MyHelperClass new_no = new MyHelperClass();
                //    var invoice_value_new = new_no.GetRandominvoicevalue(4);
                //    invoice_value = invoice_value_new.ToString();
                //    _systemElements1.invoice_number_txtbox.Clear();
                //    _systemElements1.invoice_number_txtbox.SendKeys(invoice_value);
                //}

                //Add Items
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            if (module != Constants.expense_creation)
            {
                _systemElements1.perform_select_account(Constants.sales_turnover_value, module);
                global_sales_turnover_value = Constants.sales_turnover_value;
            }
            else if (module == Constants.expense_creation)
            {
                _systemElements1.perform_select_account(Constants.opening_stock_value, module);
                global_sales_turnover_value = Constants.opening_stock_value;

            }
            //Add unit cost
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.unit_cost);
            //_systemElements1.unit_cost.Click();
            _systemElements1.unit_cost.Clear();
            _systemElements1.unit_cost.SendKeys(Constants.unit_cost_value);
            global_unit_cost_value = Constants.unit_cost_value;
            //Add Quantity
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.quantity);
            //_systemElements1.quantity.Click();
            _systemElements1.quantity.Clear();
            _systemElements1.quantity.SendKeys(Constants.Quantity);
            global_Quantity = Constants.Quantity;

            //Select VAT Rate
            if (module == Constants.invoice_creation)
            {
                _systemElements1.perform_select_VAT(Constants.vat_value_20_vat);
                vat = _systemElements1.global_vat_selected_value;
                global_vat_value_20_vat = Constants.vat_value_20_vat;
            }
            else
            {
                _systemElements1.perform_select_VAT(Constants.vat_value_20_Expenses);
                vat = _systemElements1.global_vat_selected_value;
                global_vat_value_20_vat = Constants.vat_value_20_vat;
            }
          
            // string percntage_value = Convert.ToString(percentage);
          
            //Get VAT Total
            var vat_toal_value = _systemElements1.vat_total_1.GetAttribute("value");
            global_toal_value = vat_toal_value;
            //Calculating tax value
            var unit_cost_value = Convert.ToDouble(_systemElements1.unit_cost.GetAttribute("value"));
            Console.WriteLine("unit cost: " + unit_cost_value);
            // decimal unit_cost_value1 = Convert.ToDecimal(unit_cost_value);          
            string unit_cost_value2 = $"{unit_cost_value:0.00}";
            Console.WriteLine("unit cost value 2:" + unit_cost_value2);

            var quantity_value = Convert.ToDouble(_systemElements1.quantity.GetAttribute("value"));
            Console.WriteLine("quantity value " + quantity_value);
            // decimal quantity_value1 = Convert.ToDecimal(quantity_value);
            string quantity_value2 = $"{quantity_value:0.00}";


            var total_amount_value = Convert.ToString(_systemElements1.total_amount.GetAttribute("value"));
            Console.WriteLine("Total_amount_value: " + total_amount_value);
            global_total_amount_value = total_amount_value;

            var price_bill_actual_string="";
            decimal price_bill_actual1;

            if (module == Constants.invoice_creation)
            {
                price_bill_actual_string = _systemElements1.price_bill_total.Text;
                price_bill_actual1 = Convert.ToDecimal(price_bill_actual_string);
                string price_bill_actual = $"{price_bill_actual1:0.00}";
                global_price_bill_actual = price_bill_actual;
                //price_bill_actual = String.Format("{0:0.000}", price_bill_actual);
                Console.WriteLine("Total_price bill: " + price_bill_actual);
            }
            else if (module == Constants.bill_creation)
            {
                price_bill_actual_string = _systemElements1.price_bill_total_in_bills.Text;
                price_bill_actual1 = Convert.ToDecimal(price_bill_actual_string);
                string price_bill_actual = $"{price_bill_actual1:0.00}";
                global_price_bill_actual = price_bill_actual;
                //price_bill_actual = String.Format("{0:0.000}", price_bill_actual);
                Console.WriteLine("Total_price bill: " + price_bill_actual);
            }
            else
            {
                price_bill_actual_string = _systemElements1.price_total_amount_expense.Text;
                price_bill_actual1 = Convert.ToDecimal(price_bill_actual_string);
                string price_bill_actual = $"{price_bill_actual1:0.00}";
                global_price_bill_actual = price_bill_actual;
                //price_bill_actual = String.Format("{0:0.000}", price_bill_actual);
                Console.WriteLine("Total_price bill: " + price_bill_actual);

            }

            string tota_value_expected, total_amount_expected;
            
            if (vat == Constants.vat_value_20_vat || vat==Constants.vat_value_20_Expenses)
            {
                double total_value_d = (unit_cost_value * quantity_value) * (0.20);
                tota_value_expected = $"{total_value_d:0.00}";              

            }
            else if (vat == Constants.vat_value_no_vat || vat=="0")
            {
                double total_value_d = (unit_cost_value * quantity_value) * (1);
                tota_value_expected = $"{total_value_d:0.00}";                
            }
            else
            {
                tota_value_expected = null;               
            }

            global_tota_value_expected = tota_value_expected;

            Console.WriteLine("total value Expected:" + tota_value_expected);

            //total amount
            double Net_Amount = unit_cost_value * quantity_value;
            Console.WriteLine("Net amount"+Net_Amount);
            double total_amount_d = Convert.ToDouble(tota_value_expected) + Net_Amount;
            Console.WriteLine("Total amount:" + total_amount_d);
            total_amount_expected = $"{total_amount_d:0.00}";
            Console.WriteLine("Total amount expected" + total_amount_expected);
            global_total_amount_expected = total_amount_expected;

            //Price Bill
            string price_bill_expected = $"{total_amount_d:0.00}";
            price_bill_expected = price_bill_expected.Trim('£');
            global_price_bill_expected = price_bill_expected;

            //subtotal
            string subtotal_str1;
            decimal subtotal_str2=0;
            try
            {
                subtotal_str1 = _systemElements1.subtotal.Text;
                subtotal_str2 = Convert.ToDecimal(subtotal_str1);
                string subtotal_str = $"{subtotal_str2:0.00}";
                global_subtotal = subtotal_str;
            }
            catch(Exception e)
            {
                Console.WriteLine("Alert: subtotal is not showing");
            }
            decimal Net_Amount_expected1 = Convert.ToDecimal(unit_cost_value * quantity_value);
            string Net_Amount_expected = $"{Net_Amount_expected1:0.00}";
            global_Net_Amount_expected = Net_Amount_expected;

            //Tax
            decimal tax_2=0;
            try
            {
                string tax_str = _systemElements1.tax.Text;
                 tax_2 = Convert.ToDecimal(tax_str);
                string tax = $"{tax_2:0.00}";
                global_tax = tax;
            }
            catch(Exception e)
            {
                Console.WriteLine("Alert: Tax is not showing because company is not vat registered");
            }
            decimal vat_value2 = Convert.ToDecimal(vat_toal_value);
            string vat_tax_value = $"{vat_value2:0.00}";
            global_vat_tax_value = vat_tax_value;
            //Total
            string total_value_actual1 = _systemElements1.Total.Text;
            decimal total_value_actual2 = Convert.ToDecimal(total_value_actual1);
            string total_value_actual = $"{total_value_actual2:0.00}";
            global_total_value_actual = total_value_actual;
            decimal total_value_expected1 = tax_2 + subtotal_str2;
            string total_value_expected = $"{total_value_expected1:0.00}";
            global_total_value_expected = total_value_expected;
            //Amount paid
            string amount_paid1 = _systemElements1.amount_paid.Text;
            decimal amount_paid2 = Convert.ToDecimal(amount_paid1);
            string amount_paid = $"{amount_paid2:0.00}";
            global_amount_paid = amount_paid;
            //Amount due
            string amount_due_actual1 = _systemElements1.amount_due.Text;
            decimal amount_due_actual2 = Convert.ToDecimal(amount_due_actual1);
            string amount_due_actual = $"{amount_due_actual2:0.00}";
            global_amount_due_actual = amount_due_actual;
            decimal amount_due_1 = total_value_expected1 - amount_paid2;
            string amount_due = $"{amount_due_1:0.00}";
            global_amount_due = amount_due;

            //Add Desccription
            MyHelperClass random_description = new MyHelperClass();
            var description_generate = random_description.template_message_body(20);
            _systemElements1.description.SendKeys(description_generate);
            var description = _systemElements1.description.Text;
            global_description = description;
            //Add comments
            MyHelperClass comments_1 = new MyHelperClass();
            var comment_added = comments_1.template_message_body(20);
            global_comment_added = comment_added;

            if (module == Constants.invoice_creation)
            {
                _systemElements1.bill_comment.SendKeys(comment_added);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                //var comments = _systemElements1.bill_comment.Text;
            }
            else if (module == Constants.bill_creation)
            {
                try
                {
                    _systemElements1.bill_comment_for_bill.SendKeys(comment_added);
                }
                catch(Exception e)
                {
                    _systemElements1.bill_comment.SendKeys(comment_added);

                }
                Thread.Sleep(TimeSpan.FromSeconds(2));
                //var comments = _systemElements1.bill_comment.Text;
            }

            else
            {             

            }
            Thread.Sleep(TimeSpan.FromSeconds(2));
            global_status = "Unpaid";
            global_invoice_created = "Invoice Created";
           
        }


        public void perform_saved_invoice_bill_expense_mileage(string module)
        {
            _systemElements1 = new system_elements(driver);
            WebDriverWait waitformee = new WebDriverWait(driver, TimeSpan.FromSeconds(12));
            if (module != Constants.expense_creation)
            {
                waitformee.Until(driver => _systemElements1.invoice_overview_tab.Displayed);
            }

            if (module == Constants.invoice_creation)
            {
                waitformee.Until(driver => _systemElements1.payments_tab.Displayed);
                waitformee.Until(driver => _systemElements1.notes_tab.Displayed);
                waitformee.Until(driver => _systemElements1.Files_tab.Displayed);
            }
            else if (module == Constants.bill_creation)
            {
                waitformee.Until(driver => _systemElements1.payments_tab_bill.Displayed);
                waitformee.Until(driver => _systemElements1.notes_tab_bill.Displayed);
                waitformee.Until(driver => _systemElements1.Files_tab_bill.Displayed);               

            }

            else
            {
                waitformee.Until(driver => _systemElements1.payments_tab_expense.Displayed);
                waitformee.Until(driver => _systemElements1.notes_tab_expense.Displayed);
                waitformee.Until(driver => _systemElements1.files_tab_expense.Displayed);
            }
          

            Thread.Sleep(TimeSpan.FromSeconds(2));

            if (module != Constants.expense_creation)
            {
                //Verify contact info
                string contact_saved = _systemElements1.contact_saved.Text;
                global_contact_saved = contact_saved;
                //Get invoice number
                string invoice_number_added = _systemElements1.invoice_number.Text;
                Console.WriteLine("invoice_number_added:" + invoice_number_added);
            }


            if (module == Constants.expense_creation)
            {
                //Verify contact info
                string contact_saved = _systemElements1.supplier.GetAttribute("value");               
                global_contact_saved = contact_saved;
                //Get invoice number
                string invoice_number_added = _systemElements1.invoice_number.Text;
                Console.WriteLine("invoice_number_added:" + invoice_number_added);
            }


            if (module != Constants.expense_creation)
            {
                //Get Status of invoice
                string invoice_status_added = _systemElements1.invoice_status.Text;
                Console.WriteLine("invoice_status_added:" + invoice_status_added);
            }

            Thread.Sleep(TimeSpan.FromSeconds(2));
            if (module != Constants.expense_creation)
            {
                //Get issue date
                string invoice_issue_date = _systemElements1.invoice_detail_issue_date.Text;
                Console.WriteLine("invoice_issue_date:" + invoice_issue_date);
                global_invoice_issue_date = invoice_issue_date;
            }

            if (module == Constants.expense_creation)
            {
                //Get issue date
                string invoice_issue_date = _systemElements1.issue_date_expense.GetAttribute("value");
                Console.WriteLine("invoice_issue_date:" + invoice_issue_date);
                global_invoice_issue_date = invoice_issue_date;
            }

            if (module != Constants.expense_creation)
            {
                //Get invoice due date
                string invoice_due_date = _systemElements1.invoice_detail_due_date.Text;
                Console.WriteLine("invoice_due_date:" + invoice_due_date);
                global_invoice_due_date = invoice_due_date;
            }
            if (module != Constants.expense_creation)
            {
                //Invoice detail custom
                string invoice_custom = _systemElements1.invoice_detail_custom.Text;
                Console.WriteLine("invoice_custom:" + invoice_custom);
                global_invoice_custom = invoice_custom;
            }

            if (module != Constants.expense_creation)
            {
                //invoice terms day
                string invoice_term_days = _systemElements1.invoice_detail_custom_term_days.Text;
                Console.WriteLine("invoice_term_days:" + invoice_term_days);
                global_invoice_term_days = invoice_term_days;
            }

            if (module != Constants.expense_creation)
            {
                //invoice number
                string detail_invoice_number = _systemElements1.invoice_detail_invoice_number.Text;
                Console.WriteLine("detail_invoice_number:" + detail_invoice_number);
                detail_invoice_number = detail_invoice_number.Trim('"');
                global_detail_invoice_number = detail_invoice_number;
            }

            if (module == Constants.expense_creation)
            {
                string detail_invoice_number = _systemElements1.saved_expense_number.GetAttribute("value");
                Console.WriteLine("detail_invoice_number:" + detail_invoice_number);
                detail_invoice_number = detail_invoice_number.Trim('"');
                detail_invoice_number = detail_invoice_number.Trim(' ');
                global_detail_invoice_number = detail_invoice_number;
                
                ////invoice number
                //var detail_invoice_number = Convert.ToInt32(_systemElements1.saved_expense_number.GetAttribute("value"));
                //Console.WriteLine("expense_number:" + detail_invoice_number);               
                //global_detail_invoice_number = Convert.ToString(detail_invoice_number);
            }
                //Invoice detail account type
                string account_type = _systemElements1.invoice_detail_account_type.Text;
            Console.WriteLine("account_type:" + account_type);
            global_account_types = account_type;

            if (module != Constants.expense_creation)
            {
                //invoice detail unit cost
                string invoice_detail_unit_cost = _systemElements1.invoice_detail_unit_cost.Text;
                Console.WriteLine("invoice_detail_unit_cost:" + invoice_detail_unit_cost);
                global_invoice_detail_unit_cost = invoice_detail_unit_cost;
            }

            if (module == Constants.expense_creation)
            {
                //invoice detail unit cost
                string invoice_detail_unit_cost = _systemElements1.invoice_detail_unit_cost.Text;
                Console.WriteLine("invoice_detail_unit_cost:" + invoice_detail_unit_cost);
                invoice_detail_unit_cost = invoice_detail_unit_cost.Trim('£');
                global_invoice_detail_unit_cost = invoice_detail_unit_cost;
            }

                //invoice detail quantity
            string invoice_quantity = _systemElements1.invoice_detail_quanitity.Text;
            Console.WriteLine("invoice_quantity:" + invoice_quantity);

            if (module == Constants.expense_creation)
            {
                string output = Constants.Quantity.Substring(Constants.Quantity.IndexOf('.') + 1);
                if (output == "00")
                {
                    invoice_quantity = invoice_quantity + ".00";
                }
            }
            global_invoice_quantity = invoice_quantity;
            //invoice vat Rate
            string invoice_vat_rate = _systemElements1.invoice_detail_vat_rate.Text;
            Console.WriteLine("invoice_vat_rate:" + invoice_vat_rate);
            global_invoice_vat_rate = invoice_vat_rate;


            if (module != Constants.expense_creation)
            {
                //invoice detail VAt Total
                string invoice_vat_total = _systemElements1.invoice_detail_vat_total.Text;
                Console.WriteLine("invoice_vat_total:" + invoice_vat_total);
                global_invoice_vat_total = invoice_vat_total;
            }

            if (module == Constants.expense_creation)
            {
                //invoice detail VAt Total
                string invoice_vat_total = _systemElements1.invoice_detail_vat_total.Text;
                Console.WriteLine("invoice_vat_total:" + invoice_vat_total);
                invoice_vat_total = invoice_vat_total.Trim('£');
                global_invoice_vat_total = invoice_vat_total;

            }
                //invoice detail total amount
                string invoice_detail_total_amount = _systemElements1.invoice_detail_total_amount.Text;
            Console.WriteLine("invoice_detail_total_amount:" + invoice_detail_total_amount);
            if (module == Constants.expense_creation)
            {
                invoice_detail_total_amount= invoice_detail_total_amount.Trim('£');
            }

                global_invoice_detail_total_amount = invoice_detail_total_amount;
            //Invoice detail subtotal
            string invoice_detail_subtotal = _systemElements1.invoice_detail_Subtotal.Text;
            invoice_detail_subtotal = invoice_detail_subtotal.Trim('£');
            Console.WriteLine("invoice_detail_subtotal:" + invoice_detail_subtotal);
            global_invoice_detail_subtotal = invoice_detail_subtotal;
            //invoice detail Tax
            string invoice_detail_tax = _systemElements1.invoice_detail_Tax.Text;
            Console.WriteLine("invoice_detail_tax:" + invoice_detail_tax);
            invoice_detail_tax = invoice_detail_tax.Trim('£');
            global_invoice_detail_tax = invoice_detail_tax;
            //invoice_detail_Total
            string invoice_detail_total = _systemElements1.invoice_detail_Total.Text;
            Console.WriteLine("invoice_detail_total:" + invoice_detail_total);
            invoice_detail_total = invoice_detail_total.Trim('£');
            global_invoice_detail_total = invoice_detail_total;

            //invoice_detail_amount_paid
            string invoice_detail_amount_paid = _systemElements1.invoice_detail_amount_paid.Text;
            Console.WriteLine("invoice_detail_amount_paid:" + invoice_detail_amount_paid);
            invoice_detail_amount_paid = invoice_detail_amount_paid.Trim('£');
            global_invoice_detail_amount_paid = invoice_detail_amount_paid;

            //invoice_detail_amount_due
            string invoice_detail_amount_due = _systemElements1.invoice_detail_amount_due.Text;
            Console.WriteLine("invoice_detail_amount_due:" + invoice_detail_amount_due);
            invoice_detail_amount_due = invoice_detail_amount_due.Trim('£');
            global_invoice_detail_amount_due = invoice_detail_amount_due;

            if (module != Constants.expense_creation)
            {
                //invoice_detail_comment
                string invoice_detail_comment = _systemElements1.invoice_detail_comment.Text;
                Console.WriteLine("invoice_detail_comment:" + invoice_detail_comment);
                global_invoice_detail_comment = invoice_detail_comment;
            }
            //invoice_detail_description
            string invoice_detail_description = _systemElements1.invoice_detail_description.Text;
            Console.WriteLine("invoice_detail_description:" + invoice_detail_description);
            global_invoice_detail_description = invoice_detail_description;

            if (module != Constants.expense_creation)
            {
                //invoice_detail_invoice_status
                string invoice_detail_invoice_status = _systemElements1.invoice_detail_invoice_status.Text;
                Console.WriteLine("invoice_detail_invoice_status:" + invoice_detail_invoice_status);
                global_invoice_detail_invoice_status = invoice_detail_invoice_status;
            }

            if (module == Constants.expense_creation)
            {
                //invoice_detail_invoice_status
                string invoice_detail_invoice_status = _systemElements1.expense_status.Text;
                Console.WriteLine("invoice_detail_invoice_status:" + invoice_detail_invoice_status);
                global_invoice_detail_invoice_status = invoice_detail_invoice_status;
            }
            
            string invoice_detail_invoice_created, invoice_detail_invoice_created_date_time;

            //invoice_detail_invoice_created
           if (homeURL!=Constants.main_website)
            {
                try
                {
                   invoice_detail_invoice_created = _systemElements1.invoice_detail_invoice_created.Text;
                    Console.WriteLine("invoice_detail_invoice_created:" + invoice_detail_invoice_created);
                    global_invoice_detail_invoice_created = invoice_detail_invoice_created;
                    //invoice_detail_invoice_created_date_time
                   invoice_detail_invoice_created_date_time = _systemElements1.invoice_detail_invoice_created_date_time.Text;
                    Console.WriteLine("invoice_detail_invoice_created_date_time:" + invoice_detail_invoice_created_date_time);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Alert: Invoice created is not showing");
                }
            }
            else
            {
                try
                {
                    invoice_detail_invoice_created = _systemElements1.invoice_detail_invoice_created.Text;
                    Console.WriteLine("invoice_detail_invoice_created:" + invoice_detail_invoice_created);
                    global_invoice_detail_invoice_created = invoice_detail_invoice_created;
                    //invoice_detail_invoice_created_date_time
                    invoice_detail_invoice_created_date_time = _systemElements1.invoice_detail_invoice_created_date_time.Text;
                    Console.WriteLine("invoice_detail_invoice_created_date_time:" + invoice_detail_invoice_created_date_time);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Alert: Invoice created is not showing");
                }
            }
           

            //invoice_detail_price
            string invoice_detail_price = _systemElements1.invoice_detail_price.Text;
            Console.WriteLine("invoice_detail_price:" + invoice_detail_price);
            invoice_detail_price = invoice_detail_price.Trim('£');

            global_invoice_detail_price = invoice_detail_price;


        }



        public void perform_adding_new_mileage(string module)
        {
            //Select staf member            
            SelectElement staff = new SelectElement(_systemElements1.Mileage_staff_drop_down);
            staff.SelectByIndex(2);         
            String staff_value = staff.Options.ElementAt(2).Text;

            global_staff_value = staff_value;

            //Add Issue Date
            DateTime odate = DateTime.Today;
            var today_date_string = odate.ToString("dd/MM/yyyy");
            var today_date = today_date_string.Replace('-', '/');
            global_today_date = today_date;

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.issue_date);
           // _systemElements1.issue_date.Click();
            _systemElements1.issue_date.Clear();
            try
            { 
            _systemElements1.issue_date.SendKeys(today_date);
            }catch(Exception e)
            { }
             Thread.Sleep(TimeSpan.FromSeconds(2));      

            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.ok_button);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }catch(Exception e) { }

            //Mileage number
            var Mileage_no = Convert.ToInt32(_systemElements1.mileage_expense_number.GetAttribute("value"));
            Console.WriteLine("Mileage no:" + Mileage_no);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            global_mileage_number = Mileage_no;
            Thread.Sleep(TimeSpan.FromSeconds(1));

            string currency = _systemElements1.currency.Text;
            if(currency != "GBP")
            {
                Console.WriteLine("Alert: currency not showing in GBP");
            }
            _systemElements1.number_of_mileage.Clear();
            _systemElements1.number_of_mileage.SendKeys(Constants.miles);
            Thread.Sleep(TimeSpan.FromSeconds(2));            
            string number_of_mileage_value = _systemElements1.number_of_mileage.GetAttribute("value");
            global_number_of_mileage_value = number_of_mileage_value;
            SelectElement vehicle = new SelectElement(_systemElements1.vehicle);
            vehicle.SelectByIndex(0);
            String vehicle_type = vehicle.Options.ElementAt(0).Text;          
            global_vehicle_type = vehicle_type;
            Thread.Sleep(TimeSpan.FromSeconds(3));
            string value_for_vehicle_drop_down = _systemElements1.vehicle_engine_dropdown.GetAttribute("disabled");          
            if (value_for_vehicle_drop_down == "true")
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", _systemElements1.recliam_vat_checkbox);          
            }

            SelectElement vehicle_engine = new SelectElement(_systemElements1.vehicle_engine_dropdown);
            vehicle_engine.SelectByIndex(0);
            string vehicle_engine_value = vehicle_engine.Options.ElementAt(0).Text;
            global_vehicle_engine_value = vehicle_engine_value;            

            MyHelperClass random_description = new MyHelperClass();
            var description_generate = random_description.template_message_body(20);
            _systemElements1.mileage_description.SendKeys(description_generate);
            var description = _systemElements1.mileage_description.GetAttribute("value");
            global_description = description;          

        }
    }
}

