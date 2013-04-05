using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.EntityClient;
using OnSite.TemplateWizard.Models;

namespace OnSite.TemplateWizard.Classes
{
    public static class SiteVisitDBHelper
    {
        private static SiteVisitMetaEntities ctx = new SiteVisitMetaEntities();

        public static IEnumerable<SiteVisit> GetSiteVisits(int clientID)
        {
            var forms = from f in ctx.SiteVisits
                        orderby f.SiteVisitID
                        where f.Project.ClientID == clientID
                        select f;
            return forms;
        }

        public static SiteVisitForm GetParentForm(SiteVisit sitevisit)
        {
            var form = (from f in sitevisit.SiteVisitForms
                        where f.SiteVisitParentFormID == null
                        select f).FirstOrDefault();
            return form;
        }

        public static IEnumerable<SiteVisitFormGroup> GetSiteVisitFormGroups(int siteVisitFormID)
        {
            var groups = from g in ctx.SiteVisitFormGroups
                         where g.SiteVisitFormID == siteVisitFormID
                         orderby g.SiteVisitFormGroupOrder
                         select g;
            return groups;
        }

        public static List<string> GetFieldGroups(int siteVisitFormID, int? siteVisitFormGroupID)
        {
            List<string> fieldGroups;

            if (siteVisitFormGroupID != null)
            {
                var groupFields = from gf in ctx.SiteVisitFormGroupFields
                                  where gf.SiteVisitFormGroupID == siteVisitFormGroupID
                                  select gf.SiteVisitFormFieldID;

                var query = (from f in ctx.SiteVisitFormFields
                             orderby f.FieldGroupOrder
                             where f.SiteVisitFormID == siteVisitFormID && groupFields.Contains(f.SiteVisitFormFieldID)
                             select new { f.FieldGroupOrder, f.FieldGroupName }).Distinct();
                fieldGroups = (from g in query
                               orderby g.FieldGroupOrder
                               select g.FieldGroupName).ToList();
                              
            }
            else
            {
                var query = (from f in ctx.SiteVisitFormFields
                             orderby f.FieldGroupOrder
                             where f.SiteVisitFormID == siteVisitFormID
                             select new { f.FieldGroupOrder, f.FieldGroupName }).Distinct();
                fieldGroups = (from g in query
                               orderby g.FieldGroupOrder
                               select g.FieldGroupName).ToList();
            }
            if (fieldGroups.Count == 0)
                fieldGroups.Add("Empty Group");

            return fieldGroups;
        }

        public static IEnumerable<SiteVisitFormField> GetSiteVisitFormFields(int? siteVisitFormID, int? siteVisitFormGroupID, bool includeLabels)
        {
            IEnumerable<SiteVisitFormField> fields;
            
            if (siteVisitFormGroupID != null)
            {
                var groupFields = from gf in ctx.SiteVisitFormGroupFields
                                  where gf.SiteVisitFormGroupID == siteVisitFormGroupID
                                  select gf.SiteVisitFormFieldID;

                fields = from f in ctx.SiteVisitFormFields
                         where groupFields.Contains(f.SiteVisitFormFieldID) && (includeLabels == true || !string.IsNullOrEmpty(f.ControlType.CSTypeName))
                         orderby f.FieldTabIndex
                         select f;
            }
            else
            {
                fields = from f in ctx.SiteVisitFormFields
                         where (includeLabels == true || !string.IsNullOrEmpty(f.ControlType.CSTypeName)) && f.SiteVisitFormID == siteVisitFormID
                         orderby f.FieldTabIndex
                         select f;
            }

            return fields;
        }

        public static IEnumerable<SiteVisitFormField> GetSiteVisitFormFieldsByFieldGroup(int siteVisitFormGroupID, string fieldGroupName)
        {
            IEnumerable<SiteVisitFormField> fields;
            var groupFields = from gf in ctx.SiteVisitFormGroupFields
                              where gf.SiteVisitFormGroupID == siteVisitFormGroupID
                              select gf.SiteVisitFormFieldID;

            fields = from f in ctx.SiteVisitFormFields
                     where groupFields.Contains(f.SiteVisitFormFieldID) && (string.IsNullOrEmpty(f.FieldGroupName) || f.FieldGroupName == fieldGroupName)
                     orderby f.FieldTabIndex
                     select f;
            return fields;
        }

        public static IEnumerable<SiteVisitFormField> GetSiteVisitSearchableFields(SiteVisitForm form)
        {
            IEnumerable<SiteVisitFormField> fields;

            fields = (from f in form.SiteVisitFormFields
                      orderby f.FieldTabIndex
                      where f.IsSearchableField == true
                      || f.FieldName.EndsWith("Address")
                      || f.FieldName.EndsWith("City")
                      || f.FieldName.EndsWith("State")
                      || f.FieldName.EndsWith("Zip")
                      || f.FieldName.EndsWith("ZipCode")
                      select f);

            return fields;
        }

        public static IEnumerable<SiteVisitFormField> GetSiteVisitSummaryFields(SiteVisitForm form)
        {
            IEnumerable<SiteVisitFormField> fields;

            fields = (from f in form.SiteVisitFormFields
                      orderby f.FieldTabIndex
                      where f.IsSummaryField == true
                      select f);

            return fields;
        }


        public static IEnumerable<SiteVisitFormField> GetSiteVisitExportFields(SiteVisitForm form)
        {
            IEnumerable<SiteVisitFormField> fields;

            var searchFields = GetSiteVisitSearchableFields(form);

            fields = (from f in form.SiteVisitFormFields
                      orderby f.FieldTabIndex
                      where !searchFields.Contains(f)
                      select f);

            return fields;
        }

        public static IEnumerable<SiteVisitFormField> GetSiteVisitEditableTableFields(SiteVisitForm form)
        {
            IEnumerable<SiteVisitFormField> fields;

            fields = (from f in form.SiteVisitFormFields
                      orderby f.FieldTabIndex
                      where ControlType.IsUIType(ControlType.UIType.EditableTable, f.ControlType.UITypeName)
                      select f);

            return fields;
        }

        public static SiteVisitFormField GetSiteVisitReportViewerFilterField(SiteVisitForm form)
        {
            SiteVisitFormField field = (from f in form.SiteVisitFormFields
                                        orderby f.FieldTabIndex
                                        where f.IsReportViewerFilterField == true
                                        select f).FirstOrDefault();
            return field;
        }

        public static bool FieldHasListItemOther(SiteVisitFormField field)
        {
            bool retval = false;

            var query = from i in field.SiteVisitFormFieldItems
                        where i.ListItemLabel.ToLower() == "other"
                        select i;
            if (query.Count() > 0)
                retval = true;
            return retval;
        }

        public static int GetDefaultDisposition()
        {
            return ctx.Dispositions.Where(d => d.IsDefault == true).FirstOrDefault().DispositionID;
        }

        public static int GetDefaultAppointmentStatus()
        {
            return ctx.AppointmentStatus.Where(d => d.IsDefault == true).FirstOrDefault().AppointmentStatusID;
        }


        public static bool CanGenerateTemplate(int clientID, string templateName)
        {
            bool retval = false;

            var result = (from c in ctx.ClientTemplateSettings
                          where c.TemplateName == templateName && c.ClientID == clientID
                          select c.CanGenerate).FirstOrDefault();
            if (result != null)
                retval = result;

            return retval;
        }
    }
}