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
                                 //.Replace("\n", "<br />"); //<BR> must be last (since it has <> chars)
                                 .Replace("\n", "&nbsp;");
            return output;
        }
    }
}
