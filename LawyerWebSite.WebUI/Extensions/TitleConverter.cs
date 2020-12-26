using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Extensions
{
    public class TitleConverter
    {
        public string TitleToPascalCase(string text)
        {
            text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());

            return text;
        }
    }
}
