using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnSite.TemplateWizard.Classes
{
    public static class StringSanitizer
    {
        public static string SanitizeForWeb(string input)
        {
            string output = input.Replace("\n", "<br />")
                                 .Replace("°", "&deg;")
                                 .Replace(">", "&gt;")
                                 .Replace("<", "&lt;")
                                 .Replace("/", "&#47;")
                                 .Replace("µ", "&micro;");
            return output;
        }
    }
}
