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
        //public        
        public static string FormsPath = SiteVisitSettings.BasePath + @"UserControls\GeneratedForms\";
        public static string SiteVisitsPath = SiteVisitSettings.BasePath + @"SiteVisits\";
        public static string ReportsPath = SiteVisitSettings.BasePath + @"Reports\";
        public static string SchedulerPath = SiteVisitSettings.BasePath + @"Scheduler\";
        public static string ResourcePath = SiteVisitSettings.BasePath + @"Resource\";
        public static string SitemapPath = SiteVisitSettings.BasePath;

        //private static SiteVisitMetaEntities ctx = new SiteVisitMetaEntities("metadata=res://*/SiteVisitMetaModel.csdl|res://*/SiteVisitMetaModel.ssdl|res://*/SiteVisitMetaModel.msl;provider=System.Data.SqlClient;provider connection string='data source=" + SiteVisitSettings.Datasource + ";initial catalog=" + SiteVisitSettings.Catalog + ";integrated security=True;multipleactiveresultsets=True;App=EntityFramework'");
        private static SiteVisitMetaEntities ctx = new SiteVisitMetaEntities();

        public static IEnumerable<SiteVisit> GetSiteVisits(int clientID)
        {
            var forms = from f in ctx.SiteVisits
                        orderby f.SiteVisitID
                        where f.Project.ClientID == clientID
                        select f;
            return forms;
        }

        public static IEnumerable<SiteVisitForm> GetSiteVisitForms()
        {
            var forms = from f in ctx.SiteVisitForms
                        orderby f.UIDisplayOrder
                        where f.SiteVisit.Project.ClientID == SiteVisitSettings.ClientID
                        select f;
            return forms;
        }

        public static IEnumerable<SiteVisitForm> GetSiteVisitForms(int siteVisitID)
        {
            var forms = from f in ctx.SiteVisitForms
                        orderby f.UIDisplayOrder
                        where f.SiteVisitID == siteVisitID && f.SiteVisit.Project.ClientID == SiteVisitSettings.ClientID
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
                         where g.SiteVisitFormID == siteVisitFormID && g.SiteVisitForm.SiteVisit.Project.ClientID == SiteVisitSettings.ClientID
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
                                  && gf.SiteVisitFormGroup.SiteVisitForm.SiteVisit.Project.ClientID == SiteVisitSettings.ClientID
                                  select gf.SiteVisitFormFieldID;

                var query = (from f in ctx.SiteVisitFormFields
                             orderby f.FieldGroupOrder
                             where f.SiteVisitFormID == siteVisitFormID && groupFields.Contains(f.SiteVisitFormFieldID)
                             && f.SiteVisitForm.SiteVisit.Project.ClientID == SiteVisitSettings.ClientID
                             select new { f.FieldGroupOrder, f.FieldGroupName }).Distinct();
                fieldGroups = (from g in query
                               orderby g.FieldGroupOrder
                               select g.FieldGroupName).ToList();
                              
            }
            else
            {
                var query = (from f in ctx.SiteVisitFormFields
                             orderby f.FieldGroupOrder
                             where f.SiteVisitFormID == siteVisitFormID && f.SiteVisitForm.SiteVisit.Project.ClientID == SiteVisitSettings.ClientID
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
                                  && gf.SiteVisitFormGroup.SiteVisitForm.SiteVisit.Project.ClientID == SiteVisitSettings.ClientID
                                  select gf.SiteVisitFormFieldID;

                fields = from f in ctx.SiteVisitFormFields
                         where groupFields.Contains(f.SiteVisitFormFieldID) && (includeLabels == true || !string.IsNullOrEmpty(f.ControlType.CSTypeName))
                         && f.SiteVisitForm.SiteVisit.Project.ClientID == SiteVisitSettings.ClientID
                         orderby f.FieldTabIndex
                         select f;
            }
            else
            {
                fields = from f in ctx.SiteVisitFormFields
                         where (includeLabels == true || !string.IsNullOrEmpty(f.ControlType.CSTypeName)) && f.SiteVisitFormID == siteVisitFormID
                         && f.SiteVisitForm.SiteVisit.Project.ClientID == SiteVisitSettings.ClientID
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
                              && gf.SiteVisitFormGroup.SiteVisitForm.SiteVisit.Project.ClientID == SiteVisitSettings.ClientID
                              select gf.SiteVisitFormFieldID;

            fields = from f in ctx.SiteVisitFormFields
                     where groupFields.Contains(f.SiteVisitFormFieldID) && (string.IsNullOrEmpty(f.FieldGroupName) || f.FieldGroupName == fieldGroupName)
                     && f.SiteVisitForm.SiteVisit.Project.ClientID == SiteVisitSettings.ClientID
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
    }
}