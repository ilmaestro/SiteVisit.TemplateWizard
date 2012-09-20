using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OnSite.TemplateWizard.Models;
using OnSite.TemplateWizard.Classes;

namespace OnSite.TemplateWizard.Classes
{
    public class SiteVisitTemplateProcessor
    {
        public string BasePath { get; set; }
        public string FormsPath { get; set; }
        public string SiteVisitsPath { get; set; }
        public string ReportsPath { get; set; }
        public string SchedulerPath { get; set; }
        public string ResourcePath { get; set; }
        public string DocumentsPath { get; set; }
        public string SitemapPath { get; set; }
        public string iCalPath { get; set; }

        public SiteVisitTemplateProcessor(string basePath)
        {
            BasePath = basePath;
            FormsPath = Path.Combine(BasePath, @"UserControls\GeneratedForms\");
            SiteVisitsPath = Path.Combine(BasePath,  @"SiteVisits\");
            ReportsPath = Path.Combine(BasePath, @"Reports\");
            SchedulerPath = Path.Combine(BasePath, @"Scheduler\");
            ResourcePath = Path.Combine(BasePath, @"Resource\");
            DocumentsPath = Path.Combine(BasePath, @"Documents\");
            SitemapPath = BasePath;
            iCalPath = Path.Combine(BasePath, @"WebServices\");
        }

        public void CleanUpFolders()
        {
            foreach (string file in Directory.EnumerateFiles(FormsPath))
            {
                if (file.EndsWith(".ascx") || file.EndsWith(".cs")) 
                    File.Delete(file);
            }

            foreach (string file in Directory.EnumerateFiles(SiteVisitsPath))
            {
                if (file.EndsWith(".aspx") || file.EndsWith(".cs"))
                    File.Delete(file);
            }

            foreach (string file in Directory.EnumerateFiles(ReportsPath))
            {
                if (file.EndsWith(".aspx") || file.EndsWith(".cs"))
                    File.Delete(file);
            }

            foreach (string file in Directory.EnumerateFiles(SchedulerPath))
            {
                if (file.EndsWith(".aspx") || file.EndsWith(".cs"))
                    File.Delete(file);
            }

            foreach (string file in Directory.EnumerateFiles(ResourcePath))
            {
                if (file.EndsWith(".aspx") || file.EndsWith(".cs"))
                    File.Delete(file);
            }

            foreach (string file in Directory.EnumerateFiles(SitemapPath))
            {
                if (file.EndsWith(".sitemap"))
                    File.Delete(file);
            }
        }

        private int clientID;

        public void ProcessTemplates(int clientID)
        {
            this.clientID = clientID;
            var sitevisits = SiteVisitDBHelper.GetSiteVisits(this.clientID);

            foreach (SiteVisit sitevisit in sitevisits)
            {
                //generate forms (user controls)
                foreach (SiteVisitForm form in sitevisit.SiteVisitForms)
                {
                    //GenerateForm(form);
                    GenerateMobileForm(form);

                    //check if we need to generate search/edit pages for other parents - DOES not appy to the top-level parent.
                    if (form.SiteVisitParentFormID != null)
                    {
                        var formChildren = from f in sitevisit.SiteVisitForms
                                         where f.SiteVisitParentFormID == form.SiteVisitFormID
                                         select f;
                        if (formChildren.Count() > 0 || form.IsMultipleReponse == true)
                        {
                            GenerateChildEditTemplate(form);
                            GenerateChildSearchTemplate(form);
                        }
                    }
                    
                }
                //generate site visit pages
                GenerateFormsEdit(sitevisit);
                GenerateFormsPreview(sitevisit);
                GenerateFormsPrint(sitevisit);
                GenerateFormsSearch(sitevisit);
                //generate scheduler pages
                GenerateSchedulerEdit(sitevisit);
                GenerateSchedulerImport(sitevisit);
                //generate resource pages
                GenerateResourceSchedule(sitevisit);
                //generate report pages
                GenerateReportSchedule(sitevisit);
                //generate calendar service
                GenerateICal(sitevisit);
            }

            //generate sitemap
            GenerateSitemap(sitevisits.FirstOrDefault()); //TODO: adjust sitemap to work for all sitevisits
            GenerateDocuments();
        }

        //private void GenerateForm(SiteVisitForm form)
        //{
        //    FormsTemplate template = new FormsTemplate();
        //    template.Form = form;

        //    template.OutputType = FormsTemplate.FileType.Page;
        //    template.OutputFilePath = Path.Combine(FormsPath, form.DBTableName + ".ascx");
        //    template.SaveOutput(template.TransformText());
            
        //    template.OutputType = FormsTemplate.FileType.Code;
        //    template.OutputFilePath = Path.Combine(FormsPath, form.DBTableName + ".ascx.cs");            
        //    template.SaveOutput(template.TransformText());

        //    template.OutputType = FormsTemplate.FileType.Designer;
        //    template.OutputFilePath = Path.Combine(FormsPath, form.DBTableName + ".ascx.designer.cs");
        //    template.SaveOutput(template.TransformText());
        //}

        private void GenerateMobileForm(SiteVisitForm form)
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "MobileFormsTemplate"))
            {
                MobileFormsTemplate template = new MobileFormsTemplate();
                template.Form = form;

                template.OutputType = MobileFormsTemplate.FileType.Page;
                template.OutputFilePath = Path.Combine(FormsPath, form.DBTableName + ".ascx");
                template.SaveOutput(template.TransformText());

                template.OutputType = MobileFormsTemplate.FileType.Code;
                template.OutputFilePath = Path.Combine(FormsPath, form.DBTableName + ".ascx.cs");
                template.SaveOutput(template.TransformText());

                template.OutputType = MobileFormsTemplate.FileType.Designer;
                template.OutputFilePath = Path.Combine(FormsPath, form.DBTableName + ".ascx.designer.cs");
                template.SaveOutput(template.TransformText());
            }
        }

        private void GenerateFormsEdit(SiteVisit sitevisit)
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "FormsEditTemplate"))
            {
                FormsEditTemplate template = new FormsEditTemplate();
                template.SiteVisit = sitevisit;
                string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

                template.OutputType = FormsEditTemplate.FileType.Page;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, sitevisitName + "Edit.aspx");
                template.SaveOutput(template.TransformText());

                template.OutputType = FormsEditTemplate.FileType.Code;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, sitevisitName + "Edit.aspx.cs");
                template.SaveOutput(template.TransformText());

                template.OutputType = FormsEditTemplate.FileType.Designer;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, sitevisitName + "Edit.aspx.designer.cs");
                template.SaveOutput(template.TransformText());
            }
        }

        private void GenerateChildEditTemplate(SiteVisitForm form)
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "FormsChildEditTemplate"))
            {
                FormsChildEditTemplate template = new FormsChildEditTemplate();
                template.SiteVisitForm = form;

                template.OutputType = FormsChildEditTemplate.FileType.Page;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, form.DBTableName + "Edit.aspx");
                template.SaveOutput(template.TransformText());

                template.OutputType = FormsChildEditTemplate.FileType.Code;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, form.DBTableName + "Edit.aspx.cs");
                template.SaveOutput(template.TransformText());

                template.OutputType = FormsChildEditTemplate.FileType.Designer;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, form.DBTableName + "Edit.aspx.designer.cs");
                template.SaveOutput(template.TransformText());
            }
        }

        private void GenerateChildSearchTemplate(SiteVisitForm form)
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "FormsChildSearchTemplate"))
            {
                FormsChildSearchTemplate template = new FormsChildSearchTemplate();
                template.SiteVisitForm = form;

                template.OutputType = FormsChildSearchTemplate.FileType.Page;
                template.OutputFilePath = Path.Combine(FormsPath, form.DBTableName + "Search.ascx");
                template.SaveOutput(template.TransformText());

                template.OutputType = FormsChildSearchTemplate.FileType.Code;
                template.OutputFilePath = Path.Combine(FormsPath, form.DBTableName + "Search.ascx.cs");
                template.SaveOutput(template.TransformText());

                template.OutputType = FormsChildSearchTemplate.FileType.Designer;
                template.OutputFilePath = Path.Combine(FormsPath, form.DBTableName + "Search.ascx.designer.cs");
                template.SaveOutput(template.TransformText());
            }
        }

        private void GenerateFormsPreview(SiteVisit sitevisit)
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "FormsPreviewTemplate"))
            {
                FormsPreviewTemplate template = new FormsPreviewTemplate();
                template.SiteVisit = sitevisit;
                string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

                template.OutputType = FormsPreviewTemplate.FileType.Page;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, sitevisitName + "Preview.aspx");
                template.SaveOutput(template.TransformText());

                template.OutputType = FormsPreviewTemplate.FileType.Code;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, sitevisitName + "Preview.aspx.cs");
                template.SaveOutput(template.TransformText());

                template.OutputType = FormsPreviewTemplate.FileType.Designer;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, sitevisitName + "Preview.aspx.designer.cs");
                template.SaveOutput(template.TransformText());
            }
        }

        private void GenerateFormsPrint(SiteVisit sitevisit)
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "FormsPrintTemplate"))
            {
                FormsPrintTemplate template = new FormsPrintTemplate();
                template.SiteVisit = sitevisit;
                string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

                template.OutputType = FormsPrintTemplate.FileType.Page;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, sitevisitName + "Print.aspx");
                template.SaveOutput(template.TransformText());

                template.OutputType = FormsPrintTemplate.FileType.Code;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, sitevisitName + "Print.aspx.cs");
                template.SaveOutput(template.TransformText());

                template.OutputType = FormsPrintTemplate.FileType.Designer;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, sitevisitName + "Print.aspx.designer.cs");
                template.SaveOutput(template.TransformText());
            }
        }

        private void GenerateFormsSearch(SiteVisit sitevisit)
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "FormsSearchTemplate"))
            {
                FormsSearchTemplate template = new FormsSearchTemplate();
                template.SiteVisit = sitevisit;
                string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

                template.OutputType = FormsSearchTemplate.FileType.Page;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, sitevisitName + "Search.aspx");
                template.SaveOutput(template.TransformText());

                template.OutputType = FormsSearchTemplate.FileType.Code;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, sitevisitName + "Search.aspx.cs");
                template.SaveOutput(template.TransformText());

                template.OutputType = FormsSearchTemplate.FileType.Designer;
                template.OutputFilePath = Path.Combine(SiteVisitsPath, sitevisitName + "Search.aspx.designer.cs");
                template.SaveOutput(template.TransformText());
            }
        }

        private void GenerateResourceSchedule(SiteVisit sitevisit)
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "ResourceScheduleTemplate"))
            {
                ResourceScheduleTemplate template = new ResourceScheduleTemplate();
                template.SiteVisit = sitevisit;
                string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

                template.OutputType = ResourceScheduleTemplate.FileType.Page;
                template.OutputFilePath = Path.Combine(ResourcePath, "My" + sitevisitName + "Schedule.aspx");
                template.SaveOutput(template.TransformText());

                template.OutputType = ResourceScheduleTemplate.FileType.Code;
                template.OutputFilePath = Path.Combine(ResourcePath, "My" + sitevisitName + "Schedule.aspx.cs");
                template.SaveOutput(template.TransformText());

                template.OutputType = ResourceScheduleTemplate.FileType.Designer;
                template.OutputFilePath = Path.Combine(ResourcePath, "My" + sitevisitName + "Schedule.aspx.designer.cs");
                template.SaveOutput(template.TransformText());
            }
        }

        private void GenerateReportSchedule(SiteVisit sitevisit)
        {
            string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

            /** Schedule - calendar **/
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "ReportScheduleTemplate"))
            {
                ReportScheduleTemplate scheduleTemplate = new ReportScheduleTemplate();
                scheduleTemplate.SiteVisit = sitevisit;
                

                scheduleTemplate.OutputType = ReportScheduleTemplate.FileType.Page;
                scheduleTemplate.OutputFilePath = Path.Combine(ReportsPath, sitevisitName + "Schedule.aspx");
                scheduleTemplate.SaveOutput(scheduleTemplate.TransformText());

                scheduleTemplate.OutputType = ReportScheduleTemplate.FileType.Code;
                scheduleTemplate.OutputFilePath = Path.Combine(ReportsPath, sitevisitName + "Schedule.aspx.cs");
                scheduleTemplate.SaveOutput(scheduleTemplate.TransformText());

                scheduleTemplate.OutputType = ReportScheduleTemplate.FileType.Designer;
                scheduleTemplate.OutputFilePath = Path.Combine(ReportsPath, sitevisitName + "Schedule.aspx.designer.cs");
                scheduleTemplate.SaveOutput(scheduleTemplate.TransformText());
            }

            /** Appointments list **/
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "ReportAppointmentsTemplate"))
            {
                ReportAppointmentsTemplate appointmentsTemplate = new ReportAppointmentsTemplate();
                appointmentsTemplate.SiteVisit = sitevisit;

                appointmentsTemplate.OutputType = ReportAppointmentsTemplate.FileType.Page;
                appointmentsTemplate.OutputFilePath = Path.Combine(ReportsPath, sitevisitName + "Appointments.aspx");
                appointmentsTemplate.SaveOutput(appointmentsTemplate.TransformText());

                appointmentsTemplate.OutputType = ReportAppointmentsTemplate.FileType.Code;
                appointmentsTemplate.OutputFilePath = Path.Combine(ReportsPath, sitevisitName + "Appointments.aspx.cs");
                appointmentsTemplate.SaveOutput(appointmentsTemplate.TransformText());

                appointmentsTemplate.OutputType = ReportAppointmentsTemplate.FileType.Designer;
                appointmentsTemplate.OutputFilePath = Path.Combine(ReportsPath, sitevisitName + "Appointments.aspx.designer.cs");
                appointmentsTemplate.SaveOutput(appointmentsTemplate.TransformText());
            }

            /** Contacts list **/
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "ReportContactsTemplate"))
            {
                ReportContactsTemplate ContactsTemplate = new ReportContactsTemplate();
                ContactsTemplate.SiteVisit = sitevisit;

                ContactsTemplate.OutputType = ReportContactsTemplate.FileType.Page;
                ContactsTemplate.OutputFilePath = Path.Combine(ReportsPath, sitevisitName + "Contacts.aspx");
                ContactsTemplate.SaveOutput(ContactsTemplate.TransformText());

                ContactsTemplate.OutputType = ReportContactsTemplate.FileType.Code;
                ContactsTemplate.OutputFilePath = Path.Combine(ReportsPath, sitevisitName + "Contacts.aspx.cs");
                ContactsTemplate.SaveOutput(ContactsTemplate.TransformText());

                ContactsTemplate.OutputType = ReportContactsTemplate.FileType.Designer;
                ContactsTemplate.OutputFilePath = Path.Combine(ReportsPath, sitevisitName + "Contacts.aspx.designer.cs");
                ContactsTemplate.SaveOutput(ContactsTemplate.TransformText());
            }

            /** Master schedule **/
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "ReportMasterScheduleTemplate"))
            {
                ReportMasterScheduleTemplate MasterScheduleTemplate = new ReportMasterScheduleTemplate();
                MasterScheduleTemplate.SiteVisit = sitevisit;

                MasterScheduleTemplate.OutputType = ReportMasterScheduleTemplate.FileType.Page;
                MasterScheduleTemplate.OutputFilePath = Path.Combine(ReportsPath, "Master" + sitevisitName + "Schedule.aspx");
                MasterScheduleTemplate.SaveOutput(MasterScheduleTemplate.TransformText());

                MasterScheduleTemplate.OutputType = ReportMasterScheduleTemplate.FileType.Code;
                MasterScheduleTemplate.OutputFilePath = Path.Combine(ReportsPath, "Master" + sitevisitName + "Schedule.aspx.cs");
                MasterScheduleTemplate.SaveOutput(MasterScheduleTemplate.TransformText());

                MasterScheduleTemplate.OutputType = ReportMasterScheduleTemplate.FileType.Designer;
                MasterScheduleTemplate.OutputFilePath = Path.Combine(ReportsPath, "Master" + sitevisitName + "Schedule.aspx.designer.cs");
                MasterScheduleTemplate.SaveOutput(MasterScheduleTemplate.TransformText());
            }
        }

        private void GenerateSchedulerImport(SiteVisit sitevisit)
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "SchedulerImportTemplate"))
            {
                SchedulerImportTemplate template = new SchedulerImportTemplate();
                template.SiteVisit = sitevisit;
                string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

                template.OutputType = SchedulerImportTemplate.FileType.Page;
                template.OutputFilePath = Path.Combine(SchedulerPath, sitevisitName + "Data.aspx");
                template.SaveOutput(template.TransformText());

                template.OutputType = SchedulerImportTemplate.FileType.Code;
                template.OutputFilePath = Path.Combine(SchedulerPath, sitevisitName + "Data.aspx.cs");
                template.SaveOutput(template.TransformText());

                template.OutputType = SchedulerImportTemplate.FileType.Designer;
                template.OutputFilePath = Path.Combine(SchedulerPath, sitevisitName + "Data.aspx.designer.cs");
                template.SaveOutput(template.TransformText());
            }
        }

        private void GenerateSchedulerEdit(SiteVisit sitevisit)
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "SchedulerEditTemplate"))
            {
                SchedulerEditTemplate template = new SchedulerEditTemplate();
                template.SiteVisit = sitevisit;
                string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

                template.OutputType = SchedulerEditTemplate.FileType.Page;
                template.OutputFilePath = Path.Combine(SchedulerPath, sitevisitName + "Edit.aspx");
                template.SaveOutput(template.TransformText());

                template.OutputType = SchedulerEditTemplate.FileType.Code;
                template.OutputFilePath = Path.Combine(SchedulerPath, sitevisitName + "Edit.aspx.cs");
                template.SaveOutput(template.TransformText());

                template.OutputType = SchedulerEditTemplate.FileType.Designer;
                template.OutputFilePath = Path.Combine(SchedulerPath, sitevisitName + "Edit.aspx.designer.cs");
                template.SaveOutput(template.TransformText());
            }
        }

        private void GenerateSitemap(SiteVisit sitevisit)
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "SitemapTemplate"))
            {
                SitemapTemplate template = new SitemapTemplate();
                template.SiteVisit = sitevisit;
                template.OutputFilePath = Path.Combine(SitemapPath, "Web.sitemap");
                template.SaveOutput(template.TransformText());
            }
        }

        private void GenerateDocuments()
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "DocumentsTemplate"))
            {
                DocumentsTemplate template = new DocumentsTemplate();
                template.OutputType = DocumentsTemplate.FileType.DocPage;
                template.OutputFilePath = Path.Combine(DocumentsPath, "Default.aspx");
                template.SaveOutput(template.TransformText());
                template.OutputType = DocumentsTemplate.FileType.DocCode;
                template.OutputFilePath = Path.Combine(DocumentsPath, "Default.aspx.cs");
                template.SaveOutput(template.TransformText());
                template.OutputType = DocumentsTemplate.FileType.DocDesigner;
                template.OutputFilePath = Path.Combine(DocumentsPath, "Default.aspx.designer.cs");
                template.SaveOutput(template.TransformText());

                template.OutputType = DocumentsTemplate.FileType.GetPage;
                template.OutputFilePath = Path.Combine(DocumentsPath, "GetFile.aspx");
                template.SaveOutput(template.TransformText());
                template.OutputType = DocumentsTemplate.FileType.GetCode;
                template.OutputFilePath = Path.Combine(DocumentsPath, "GetFile.aspx.cs");
                template.SaveOutput(template.TransformText());
                template.OutputType = DocumentsTemplate.FileType.GetDesigner;
                template.OutputFilePath = Path.Combine(DocumentsPath, "GetFile.aspx.designer.cs");
                template.SaveOutput(template.TransformText());
            }
        }

        private void GenerateICal(SiteVisit sitevisit)
        {
            if (SiteVisitDBHelper.CanGenerateTemplate(this.clientID, "iCalTemplate"))
            {
                iCalTemplate template = new iCalTemplate();
                template.SiteVisit = sitevisit;
                string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

                template.OutputType = iCalTemplate.FileType.Page;
                template.OutputFilePath = Path.Combine(iCalPath, sitevisitName + "Calendar.aspx");
                template.SaveOutput(template.TransformText());
                template.OutputType = iCalTemplate.FileType.Code;
                template.OutputFilePath = Path.Combine(iCalPath, sitevisitName + "Calendar.aspx.cs");
                template.SaveOutput(template.TransformText());
                template.OutputType = iCalTemplate.FileType.Designer;
                template.OutputFilePath = Path.Combine(iCalPath, sitevisitName + "Calendar.aspx.designer.cs");
                template.SaveOutput(template.TransformText());
            }
        }
    }
}
