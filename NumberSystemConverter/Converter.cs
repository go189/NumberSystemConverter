using System;
using System.Text.RegularExpressions;

namespace NumberSystemConverter {
    class Converter {

        public static string convert(string from, string to, string input) {
            
            string result = String.Empty;
            if (from == "fbinary" && to == "tbinary" || from == "foctal" && to == "toctal" || from == "fdecimal" && to == "tdecimal" || from == "fhexadecimal" && to == "thexadecimal") {
                result = input;
            } else if (from == "fbinary" && to == "toctal") {
                int integer = Convert.ToInt32(input, 2);
                result = Convert.ToString(integer, 8);
            } else if (from == "fbinary" && to == "tdecimal") {
                result = Convert.ToInt32(input, 2).ToString();
            } else if (from == "fbinary" && to == "thexadecimal") {
                int integer = Convert.ToInt32(input, 2);
                result = Convert.ToString(integer, 16);
            } else if (from == "foctal" && to == "tbinary") {
                int integer = Convert.ToInt32(input, 8);
                result = Convert.ToString(integer, 2);
            } else if (from == "foctal" && to == "tdecimal") {
                result = Convert.ToInt32(input, 8).ToString();
            } else if (from == "foctal" && to == "thexadecimal") {
                int integer = Convert.ToInt32(input, 8);
                result = Convert.ToString(integer, 16);
            } else if (from == "fdecimal" && to == "tbinary") {
                int integer = Convert.ToInt32(input, 10);
                result = Convert.ToString(integer, 2);
            } else if (from == "fdecimal" && to == "toctal") {
                int integer = Convert.ToInt32(input, 10);
                result = Convert.ToString(integer, 8);
            } else if (from == "fdecimal" && to == "thexadecimal") {
                int integer = Convert.ToInt32(input, 10);
                result = Convert.ToString(integer, 16);
            } else if (from == "fhexadecimal" && to == "tbinary") {
                int integer = Convert.ToInt32(input, 16);
                result = Convert.ToString(integer, 2);
            } else if (from == "fhexadecimal" && to == "toctal") {
                int integer = Convert.ToInt32(input, 16);
                result = Convert.ToString(integer, 8);
            } else if (from == "fhexadecimal" && to == "tdecimal") {
                result = Convert.ToInt32(input, 16).ToString();
            }
            return result;
        }

        private bool validateInput(string from, string to, string input) {
            System.Text.RegularExpressions.Regex r;
            if (from != String.Empty && to != String.Empty && input != String.Empty) {
                switch (from) {
                    case "fbinary":
                        r = new Regex(@"^[01]+$");
                        return r.Match(input).Success;
                    case "foctal":
                        r = new Regex(@"^[0-7]+$");
                        return r.Match(input).Success;
                    case "fdecimal":
                        r = new Regex(@"^[0-9]+$");
                        return r.Match(input).Success;
                    default:
                        r = new Regex(@"^[0-9A-F]+$");
                        return r.Match(input).Success;
                }
            }
            return false;
        }
    }
}
