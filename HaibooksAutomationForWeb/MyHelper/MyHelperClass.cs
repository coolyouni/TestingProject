using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaibooksAutomationForWeb.TestCases;

namespace HaibooksAutomationForWeb.MyHelper
{
   public class MyHelperClass: Baseclass
    {     

            public string GetRandomName(int length)
            {
                var temp_name = "alax";
                var stringChars = new char[length];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = temp_name[random.Next(temp_name.Length)];
                }
                return new String(stringChars);
            }
            public string GetRandomFileName(int length)
            {
                var temp_name = "downloadfile";
                var stringChars = new char[length];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = temp_name[random.Next(temp_name.Length)];
                }
                return new String(stringChars);
            }

            public string GetRandomtitle(int length)
            {
                var temp_name = "Manager" + "Role";
                var stringChars = new char[length];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = temp_name[random.Next(temp_name.Length)];
                }
                return new String(stringChars);
            }

            public string GetRandomOrdername(int length)
            {
                var temp_name = "order" + "name";
                var stringChars = new char[length];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = temp_name[random.Next(temp_name.Length)];
                }
                return new String(stringChars);
            }

            public string GetRandomOrderValue(int length)
            {
                var temp_name = "Ordervalue";
                var stringChars = new char[length];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = temp_name[random.Next(temp_name.Length)];
                }
                return new String(stringChars);
            }


            public string IncludeMessagetoReceiver(int length)
            {
                var temp_name = "IncludeMessagetoReciver";
                var stringChars = new char[length];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = temp_name[random.Next(temp_name.Length)];
                }
                return new String(stringChars);
            }


            public string template_message_body(int length)
            {
                var temp_name = "Business_name";
                var stringChars = new char[length];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = temp_name[random.Next(temp_name.Length)];
                }
                return new String(stringChars);
            }



        public string contact_person(int length)
        {
            var temp_name = "contact person";
            var stringChars = new char[length];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = temp_name[random.Next(temp_name.Length)];
            }
            return new String(stringChars);
        }


        public string GetRandomquestion_types(int length)
            {
                var temp_name = "property" + "question_type";
                var stringChars = new char[length];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = temp_name[random.Next(temp_name.Length)];
                }
                return new String(stringChars);
            }


            public int GetRandominvoicevalue(int length)
            {
                int _min = 500;
                int _max = 1000;
                Random _rdm = new Random();
                return _rdm.Next(_min, _max);
            }

            //Genrating email 
            public string GetRandomEmailvalue(string signer_name)
            {
                MyHelperClass c = new MyHelperClass();
                var names_generate = c.GetRandominvoicevalue(4);
                //string email_value = Constants.accounting_signer_name + "_" + names_generate + "@mailinator.com";
                string email_value = signer_name + "_" + names_generate + "@mailinator.com";
                return email_value;
            }
        }

    }

