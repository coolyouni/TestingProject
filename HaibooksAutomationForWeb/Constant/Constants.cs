using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.TestCases;

namespace HaibooksAutomationForWeb.Constant
{
    public class Constants: Baseclass
    {

		////////////////////////Configuration for each path you need to set by your own path
		// Assuming the file is in the output directory
		public static readonly string ExcelPathForDataDriven = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datadriven_haibooks.xlsx");
		public static readonly string screenshot_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "screenshots");
		public const string file_upload_script = @"D:\Haibooks\file_upload_script.exe";
        public const string wrong_file_upload_script = @"D:\Haibooks\wrong_file_upload.exe";
        public const string multiple_file_upload_script = @"D:\Haibooks\multiple_file_upload.exe";

        //file upload 
        public const string multiple_file_upload_path = "D:/Haibooks/receipt_for_upload.jpg \n D:/Haibooks/multiple_upload_1.jpg";
        public const string single_file_upload_path = "D:/Haibooks/receipt_for_upload.jpg";
        public const string wrong_file_upload_path = "D:/Haibooks/wrong_type_upload.bmp";
        

        //Login with paramters haibooks
        public const string login_username = "engyounasrehman@gmail.com";
        public const string login_password = "Khattak@321";
        public const string forward_email = "activationemailsupportforhaibooks123@mailinator.com";


        // //Login with paramters test2haibooks
        public const string test2_login_username = "younas.rehman@haibooks.com";
        public const string test2_login_password = "Khattak@321";

        //// //Login with paramters test2haibooks
        //public const string test2_login_username = "seckin.tuzun@arfitect.com";
        //public const string test2_login_password = "Arf1234";

        // //Login with paramters receipthaibooks
        public const string receipt_login_username = "alax_883@mailinator.com";
        public const string receipt_login_password = "Pakistan@1124";

        // //Login with paramters temp_test_environment
        public const string temp_test_login_username = "Alax_805@mailinator.com";
        public const string temp_test_login_password = "Pakistan@1124";

        // //Login with paramters temp_test_environment 3569
        public const string temp_3569_login_username = "Alax_628@mailinator.com";
        public const string temp_3569_login_password = "Pakistan@1124";

        public const string seckin_username = "seckin.tuzun@arfitect.com";
        public const string seckin_password = "Arf1234";

        //Browser///////////////////////////////

        public const string chrome = "chrome";
        public const string Firefox = "firefox";        

        ////////////////////////////////////////////URL ///////////////////////////////////
        public const string login_main_website = "https://haibooks.com/Login";
        public const string login_test2_website = "https://test2.haibooks.com/login";
        public const string mailinator_URL = "https://mailinator.com";
        public const string login_receipt_site = "https://testreceipts.haibooks.com/login";
        public const string login_temp_test_environment = "https://haib-3713.test.haibooks.com/Login";
        public const string login_temp_test_3569_environment = "https://haib-3569.test.haibooks.com/Login";
        public const string login_Any_link = "https://haib-3982.test.haibooks.com/Login";

        public const string main_website = "https://haibooks.com";
        public const string test2_website = "https://test2.haibooks.com";       
        public const string receipt_site = "https://testreceipts.haibooks.com";
        public const string temp_test_environment = "https://haib-3713.test.haibooks.com";
        public const string temp_test_3569_environment = "https://haib-3569.test.haibooks.com";
        public const string Any_link = "https://haib-3982.test.haibooks.com";


        //Registration Data///////////////////////////////////////
        public const string firstname = "Alax";
        public const string lastname = "hales";
        public const string phone_no_without_code = "3165144396";
        public const string mobile_no = "478989484894";
        public const string Fax_no = "441225800801";
        public const string Buidling_adress = "house 42, str 31, office #  342, london";
        public const string street_no = "98";
        public const string city = "Greenwich";
        public const string region = "bermingum";
        
        public const string post_code = "06807";
        public const string password = "Pakistan@1124";
        public const string Company_Name = "MCA ACCOUNTANTS LIMITED";
        public const string Company_Name_1 = "MACRO DECISIONS LLP";
        public const string business_type = "UK Sole Trader";

        public const string password_less_than_6_char = "pakis";


        //Account type values
        public const string sales_turnover_value = "2365541";
        public const string opening_stock_value = "50002";
        
        public const string vat_value_no_vat = "1";
        public const string vat_value_20_vat = "2";
        public const string vat_value_20_Expenses = "12";

        //Add items value
        public const string  unit_cost_value = "3.99";
        public const string  Quantity = "5.00";
        public const string debit = "30";
        public const string credit = "40";
        //Module name
        public const string invoice_creation = "invoice";
        public const string bill_creation = "bill";
        public const string expense_creation = "expense";
        public const string mileage = "mileage";
        public const string invoice_creation_without_vat = "invoice_without_vat";

        //sheet no
        public const int shhet_1 = 1;
        public const int shhet_2 = 2;
        public const int shhet_3 = 3;
        public const int shhet_4 = 4;
        public const int shhet_5 = 5;
        public const int shhet_7 = 7;
        public const int shhet_8 = 8;
        public const int shhet_9 = 9;
        public const int shhet_10 = 10;
        public const int shhet_11 = 11;
        //Adding contacts from left mneu
        public const string adding_contact_left_menu = "contact_left_menu";




        /////////////////////////////////////////////////////////////////////////////////////////
        //Find xpath for column and rows

        //Find xpath for fils tab
        public const string files_col = "//*[@id='filesGrid']/div/div[5]/div/table/colgroup";
        public const string files_rows = "//*[@id='filesGrid']/div/div[6]/div/table/tbody";

        public const string contact_col = "//*[@id='table_all_contacts']/div/div[5]/div/table/colgroup";
        public const string contact_rows = "//*[@class='dx-datagrid-rowsview dx-datagrid-nowrap']/div/table/tbody";
        //adding business
        public const string industry_type = "Agriculture, Forestry and Fishing";

        public const string draft_col = "//*[@class='table-sales-draft grid-content dx-widget dx-visibility-change-handler']/div/div[5]/div/table/colgroup";
        public const string draft_rows = "//*[@class='dx-datagrid-rowsview dx-datagrid-nowrap']/div/table/tbody";

        public const string recurring_invoice_col = "//div[@class='table-all-contact grid-content dx-widget dx-visibility-change-handler']/div/div[5]/div/table/colgroup";

        public const string sales_archived_col = "//div[@class='dx-datagrid-content dx-datagrid-scroll-container']//colgroup";

        public const string recurring_bills_col = "//div[@class='dx-datagrid-content dx-datagrid-scroll-container']//colgroup";

        public const string aquired_assets_rows = "//*[@class='dx-datagrid-rowsview dx-datagrid-nowrap dx-scrollable dx-visibility-change-handler dx-scrollable-both dx-scrollable-simulated']//table/tbody";

        public const string disposed_rows = "//div[@id='disposedAssetsGrid']//div[@class='dx-scrollable-content']/div/table/tbody";

        public const string all_divides_col = "//div[@class='dx-datagrid-content dx-datagrid-scroll-container']//colgroup";
        //public const string all_divides_rows = "//div[@class='dx-datagrid-headers dx-datagrid-nowrap']/div/table/tbody";
        public const string all_divides_row = "//div[@class='dx-datagrid-rowsview dx-datagrid-nowrap']/div/table/tbody";

        //Receipt cols and rows
        public const string receipts_col = "//*[@class='dx-datagrid-rowsview dx-datagrid-nowrap']/div/table/colgroup";
        public const string receipts_rows = "//*[@class='dx-datagrid-rowsview dx-datagrid-nowrap']/div/table/tbody";
        



        //Vat drop down options
        public const string no_vat = "No VAT";
        public const string vat_inclusive = "VAT Inclusive";
        public const string vat_execlusive = "VAT Exclusive";

        public const string vat_rate_20_revenue = "20% Revenue";
        public const string vat_rate_20_expenses = "20% Expenses";
        //expense 

        public const string paid_by = "Staff";
        public const string staff = "younas rehman";


        //Mileage
        public const string miles = "20";

        //shares
        public const string number_of_shares = "10";


        public const string pwd_validation_error = "Your password should be at least 6 characters.\r\nYour password should have at least one uppercase letter.";

        //Global Variables
        public static String email_value_registered;
        public static String business_name_without_vat;


    }
}


