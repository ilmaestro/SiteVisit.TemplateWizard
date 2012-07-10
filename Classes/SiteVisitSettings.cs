using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnSite.TemplateWizard.Classes
{
    public static class SiteVisitSettings
    {
        //App Settings
        public static bool CodeGenerationEnabled = false;
        public static string Datasource = "NANATOO"; //ConfigurationManager.AppSettings["datasource"]; //"NANATOO";
        public static int ClientID = 2; //NEEA
        public static string BasePath = @"C:\Apps\On-Site_v2\OnSite.WebUI\"; //ConfigurationManager.AppSettings["BasePath"]; //@"C:\Apps\On-Site_v2\OnSite.WebUI\";
        public static string Catalog = "On-Site_AdminConcept";
    }
}
