using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnSite.TemplateWizard.Models;
using System.IO;

namespace OnSite.TemplateWizard.Classes
{
    public class SiteVisitFormTemplate
    {
        public enum FileType
        {
            Page,
            Code,
            Designer
        }
        public string OutputFilePath;
        public SiteVisitForm Form { get; set; }
        public FileType OutputType { get; set; }

        public void SaveOutput(string output)
        {
            File.WriteAllText(OutputFilePath, output); 
        }
    }
}
