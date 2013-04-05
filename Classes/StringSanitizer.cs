using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnSite.TemplateWizard.Classes
{
    public static class StringSanitizer
    {
        /** 
         * for further encodings, please reference the following website:
         * http://www.ascii.cl/htmlcodes.htm
         */
        public static string SanitizeForWeb(string input)
        {
            string output = ReplaceStandardSymbols(input)
                                 .Replace("\n", "&nbsp;");
            return output;
        }

        public static string SanitizeForHtml(string input)
        {
            string output = ReplaceStandardSymbols(input)
                                 .Replace("\n", "<br />");
            return output;
        }

        public static string ReplaceStandardSymbols(string input)
        {
            string output = input.Replace("°", "&deg;")
                                 .Replace(">", "&gt;")
                                 .Replace("<", "&lt;")
                                 .Replace("/", "&#47;")
                                 .Replace("²", "&sup2;")
                                 .Replace("³", "&sup3;")
                                 .Replace("¶", "&para;")
                                 .Replace("®", "&reg;")
                                 .Replace("©", "&copy;")
                                 .Replace("µ", "&micro;")
                                 .Replace("¼", "&frac14;")
                                 .Replace("½", "&frac12;")
                                 .Replace("¾", "&frac34;")
                                 .Replace("‘", "&#8216;")
                                 .Replace("’", "&#8217;")
                                 .Replace("“", "&#8220;")
                                 .Replace("”", "&#8221;")
                                 .Replace("•", "&#8226;");
            return output;
        }

        public static string SanitizeForCode(string input)
        {
            string output = input.Replace("°", "")
                                 .Replace(" ", "")
                                 .Replace("-", "")
                                 .Replace(">", "")
                                 .Replace("<", "")
                                 .Replace("/", "")
                                 .Replace("²", "")
                                 .Replace("³", "")
                                 .Replace("¶", "")
                                 .Replace("®", "")
                                 .Replace("©", "")
                                 .Replace("µ", "")
                                 .Replace("¼", "")
                                 .Replace("½", "")
                                 .Replace("¾", "")
                                 .Replace("‘", "")
                                 .Replace("’", "")
                                 .Replace("“", "")
                                 .Replace("”", "")
                                 .Replace("•", "")
                                 .Replace("\n", "");
            return output;
        }

    }
}
