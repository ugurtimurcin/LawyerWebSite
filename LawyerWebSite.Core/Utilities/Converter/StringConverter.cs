using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LawyerWebSite.Core.Utilities.Converter
{
    public class StringConverter
    {
        public string TitleToPascalCase(string text)
        {
            text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            return text;
        }
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
            return text;
        }
    }
}
