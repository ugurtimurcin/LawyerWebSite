using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Extensions
{
    public class UrlConverter
    {
        public string StringReplace(string text)
        {
            text = text.Trim();
            text = Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
            text = text.Replace("İ", "i");
            text = text.Replace("ı", "i");
            text = text.Replace("Ğ", "g");
            text = text.Replace("ğ", "g");
            text = text.Replace("Ö", "o");
            text = text.Replace("ö", "o");
            text = text.Replace("Ü", "u");
            text = text.Replace("ü", "u");
            text = text.Replace("Ş", "s");
            text = text.Replace("ş", "s");
            text = text.Replace("Ç", "c");
            text = text.Replace("ç", "c");
            text = text.Replace(" ", "-");
            text = text.Replace(".", "");
            text = text.Replace("|", "");
            text = text.Replace("'", "");
            text = text.Replace("\"", "");
            text = text.Replace("!", "");
            text = text.Replace("+", "");
            text = text.Replace("%", "");
            text = text.Replace("{", "");
            text = text.Replace("}", "");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace("+", "");
            text = text.Replace("&", "");
            text = text.Replace("=", "");
            text = text.Replace("!", "");
            text = text.Replace(",", "-");
            text = text.Replace("/", "");
            text = text.Replace(";", "-");


            return text.ToLower();
        }
    }
}
