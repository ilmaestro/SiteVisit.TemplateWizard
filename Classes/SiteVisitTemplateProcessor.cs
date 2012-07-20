using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OnSite.TemplateWizard.Models;

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

        public void ProcessTemplates(int clientID)
        {
            var sitevisits = SiteVisitDBHelper.GetSiteVisits(clientID);

            foreach (SiteVisit sitevisit in sitevisits)
            {
                //generate forms (user controls)
                foreach (SiteVisitForm form in sitevisit.SiteVisitForms)
                {
                    GenerateForm(form);
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
            }

            //generate sitemap
            GenerateSitemap(sitevisits.FirstOrDefault()); //TODO: adjust sitemap to work for all sitevisits
            GenerateDocuments();
        }

        private void GenerateForm(SiteVisitForm form)
        {
            FormsTemplate template = new FormsTemplate();
            template.Form = form;

            template.OutputType = FormsTemplate.FileType.Page;
            template.OutputFilePath = Path.Combine(FormsPath, form.DBTableName + ".ascx");
            template.SaveOutput(template.TransformText());
            
            template.OutputType = FormsTemplate.FileType.Code;
            template.OutputFilePath = Path.Combine(FormsPath, form.DBTableName + ".ascx.cs");            
            template.SaveOutput(template.TransformText());

            template.OutputType = FormsTemplate.FileType.Designer;
            template.OutputFilePath = Path.Combine(FormsPath, form.DBTableName + ".ascx.designer.cs");
            template.SaveOutput(template.TransformText());
        }

        private void GenerateFormsEdit(SiteVisit sitevisit)
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

        private void GenerateFormsPreview(SiteVisit sitevisit)
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

        private void GenerateFormsPrint(SiteVisit sitevisit)
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

        private void GenerateFormsSearch(SiteVisit sitevisit)
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

        private void GenerateResourceSchedule(SiteVisit sitevisit)
        {
            ResourceScheduleTemplate template = new ResourceScheduleTemplate();
            template.SiteVisit = sitevisit;
            string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

            template.OutputType = ResourceScheduleTemplate.FileType.Page;
            template.OutputFilePath = Path.Combine(ResourcePath, "My"+sitevisitName+"Schedule.aspx");
            template.SaveOutput(template.TransformText());

            template.OutputType = ResourceScheduleTemplate.FileType.Code;
            template.OutputFilePath = Path.Combine(ResourcePath, "My" + sitevisitName + "Schedule.aspx.cs");
            template.SaveOutput(template.TransformText());

            template.OutputType = ResourceScheduleTemplate.FileType.Designer;
            template.OutputFilePath = Path.Combine(ResourcePath, "My" + sitevisitName + "Schedule.aspx.designer.cs");
            template.SaveOutput(template.TransformText());
        }

        private void GenerateReportSchedule(SiteVisit sitevisit)
        {
            ReportScheduleTemplate template = new ReportScheduleTemplate();
            template.SiteVisit = sitevisit;
            string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

            template.OutputType = ReportScheduleTemplate.FileType.Page;
            template.OutputFilePath = Path.Combine(ReportsPath, sitevisitName + "Schedule.aspx");
            template.SaveOutput(template.TransformText());

            template.OutputType = ReportScheduleTemplate.FileType.Code;
            template.OutputFilePath = Path.Combine(ReportsPath, sitevisitName + "Schedule.aspx.cs");
            template.SaveOutput(template.TransformText());

            template.OutputType = ReportScheduleTemplate.FileType.Designer;
            template.OutputFilePath = Path.Combine(ReportsPath, sitevisitName + "Schedule.aspx.designer.cs");
            template.SaveOutput(template.TransformText());
        }

        private void GenerateSchedulerImport(SiteVisit sitevisit)
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

        private void GenerateSchedulerEdit(SiteVisit sitevisit)
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

        private void GenerateSitemap(SiteVisit sitevisit)
        {
            SitemapTemplate template = new SitemapTemplate();
            template.SiteVisit = sitevisit;
            template.OutputFilePath = Path.Combine(SitemapPath, "Web.sitemap");
            template.SaveOutput(template.TransformText());            
        }

        private void GenerateDocuments()
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
}
