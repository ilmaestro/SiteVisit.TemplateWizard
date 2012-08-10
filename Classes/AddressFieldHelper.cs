using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnSite.TemplateWizard.Models;
using System.Text.RegularExpressions;

namespace OnSite.TemplateWizard.Classes
{
    public class AddressFieldHelper
    {
        public SiteVisitFormField Address1 { get; set; }
        public SiteVisitFormField Address2 { get; set; }
        public SiteVisitFormField City { get; set; }
        public SiteVisitFormField State { get; set; }
        public SiteVisitFormField Zip { get; set; }

        public string GetAddressSingleLine(string containerName)
        {
            StringBuilder expression = new StringBuilder();

            if (this.Address1 != null)
                expression.Append(containerName + "." + this.Address1.FieldName + " + \" \" + ");
            if (this.Address2 != null)
                expression.Append(containerName + "." + this.Address2.FieldName + " + \" \" + ");
            if (this.City != null)
                expression.Append(containerName + "." + this.City.FieldName + " + \", \" + ");
            if (this.State != null)
                expression.Append(containerName + "." + this.State.FieldName + " + \" \" + ");
            if (this.Zip != null)
                expression.Append(containerName + "." + this.Zip.FieldName);

            return expression.ToString();
        }

        public string GetAddressFormatted(string containerName)
        {
            StringBuilder expression = new StringBuilder();

            if (this.Address1 != null)
                expression.Append(containerName + "." + this.Address1.FieldName + " + \"\\n\" + ");
            if (this.Address2 != null)
                expression.Append(containerName + "." + this.Address2.FieldName + " + \"\\n\" + ");
            if (this.City != null)
                expression.Append(containerName + "." + this.City.FieldName + " + \", \" + ");
            if (this.State != null)
                expression.Append(containerName + "." + this.State.FieldName + " + \" \" + ");
            if (this.Zip != null)
                expression.Append(containerName + "." + this.Zip.FieldName);

            return expression.ToString();
        }

        public AddressFieldHelper(SiteVisitForm form)
        {
            Address1 = (from f in form.SiteVisitFormFields
                        where IsAddress1(f.FieldName) == true
                        select f).FirstOrDefault();

            Address2 = (from f in form.SiteVisitFormFields
                        where IsAddress2(f.FieldName) == true
                        select f).FirstOrDefault();

            City = (from f in form.SiteVisitFormFields
                    where IsCity(f.FieldName) == true
                    select f).FirstOrDefault();

            State = (from f in form.SiteVisitFormFields
                     where IsState(f.FieldName) == true
                     select f).FirstOrDefault();

            Zip = (from f in form.SiteVisitFormFields
                   where f.ControlType.UITypeName == "ZipCode"
                   select f).FirstOrDefault();
        }

        private bool IsAddress1(string fieldName)
        {
            fieldName = fieldName.ToLower();

            return fieldName.EndsWith("address") || fieldName.EndsWith("address1") || fieldName.EndsWith("address_1");
        }

        private bool IsAddress2(string fieldName)
        {
            fieldName = fieldName.ToLower();

            return (fieldName.Contains("2") && fieldName.EndsWith("address")) || fieldName.EndsWith("address2") || fieldName.EndsWith("address_2");
        }

        private bool IsCity(string fieldName)
        {
            fieldName = fieldName.ToLower();

            return fieldName.EndsWith("city");
        }

        private bool IsState(string fieldName)
        {
            fieldName = fieldName.ToLower();

            return fieldName.EndsWith("state");
        }
    }
}
