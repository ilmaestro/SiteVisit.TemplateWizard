using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnSite.TemplateWizard.Classes
{
    public static class DevExpressHelper
    {
        public static string GetValueExpression(string UIType)
        {
            string retval = "";

            switch (UIType)
            {
                case "CheckList":
                case "DropDownList":
                case "RadioList":
                    retval = "GetSelectedItem()";
                    break;
                case "Memo":
                case "Text":
                case "ZipCode":
                case "PhoneNumber":
                case "Email":
                    retval = "GetText()";
                    break;
                case "Number":
                case "Percent":
                case "Integer":
                case "Currency":
                    retval = "GetValue()";
                    break;
                case "Date":
                case "Time":
                    retval = "GetDate()";
                    break;
                default:
                    break;
            }

            return retval;
        }
    }
}
