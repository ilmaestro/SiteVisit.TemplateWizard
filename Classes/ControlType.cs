using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnSite.TemplateWizard.Classes
{
    public static class ControlType
    {
        public enum UIType
        {
            CheckList,
            DropdownList,
            RadioList,
            PercentList,
            NumberList,
            IntegerList,
            Text,
            Currency,
            Number,
            Percent,
            Date,
            PhoneNumber,
            Time,
            ZipCode,
            Integer,
            Label,
            Memo,
            Email,
            EditableTable
        }

        public static bool IsUIType(UIType type, string UITypeName)
        {
            return (ControlType.UIType)Enum.Parse(typeof(ControlType.UIType), UITypeName) == type;
        }

    }
}
