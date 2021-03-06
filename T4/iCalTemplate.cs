﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 10.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace OnSite.TemplateWizard.Classes
{
    using System;
    using System.Data;
    using System.Data.Objects;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;
    using System.Data.Objects.DataClasses;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text;
    using OnSite.TemplateWizard.Classes;
    using OnSite.TemplateWizard.Models;
    using System.Data.EntityClient;
    
    
    #line 1 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class iCalTemplate : iCalTemplateBase
    {
        public virtual string TransformText()
        {
            
            #line 2 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"

switch (OutputType) {
	case FileType.Page:
		GeneratePage(SiteVisit, SiteVisit.SiteVisitForms);
		break;
	case FileType.Code:
		GenerateCodeFile(SiteVisit, SiteVisit.SiteVisitForms);
		break;
	case FileType.Designer:
		GenerateDesignerFile(SiteVisit, SiteVisit.SiteVisitForms);
		break;
	default:
		break;
}

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 16 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"

    void GeneratePage(SiteVisit sitevisit, IEnumerable<SiteVisitForm> forms)
    {
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");
		string siteVisitID = sitevisit.SiteVisitID.ToString();
		var parentForm = SiteVisitDBHelper.GetParentForm(sitevisit);
		string table = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBTableName;
        string pkey = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBPrimaryKeyName;

        
        #line default
        #line hidden
        
        #line 24 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"");

        
        #line default
        #line hidden
        
        #line 25 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 25 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write("Calendar.aspx.cs\" Inherits=\"OnSite.WebUI.ClientCode.WebServices.");

        
        #line default
        #line hidden
        
        #line 25 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 25 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write(@"Calendar"" %>

<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">

<html xmlns=""http://www.w3.org/1999/xhtml"">
<head runat=""server"">
    <title></title>
</head>
<body>
    <form id=""form1"" runat=""server"">
    <div>
        Improper navigation.
    </div>
    </form>
</body>
</html>

");

        
        #line default
        #line hidden
        
        #line 42 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"

    }  

    void GenerateCodeFile(SiteVisit sitevisit, IEnumerable<SiteVisitForm> forms)
    {
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");
		string siteVisitID = sitevisit.SiteVisitID.ToString();
		var parentForm = SiteVisitDBHelper.GetParentForm(sitevisit);
		string table = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBTableName;
        string pkey = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBPrimaryKeyName;
		SiteVisitFormField reportViewerFilterField = SiteVisitDBHelper.GetSiteVisitReportViewerFilterField(parentForm);
		string reportViewerFilterExpression = "";
		if (reportViewerFilterField != null)
		{
			reportViewerFilterExpression = "&& (c." + table +"." + reportViewerFilterField.FieldName + " == reportViewerFilterValue || string.IsNullOrEmpty(reportViewerFilterValue))";
		}

        
        #line default
        #line hidden
        
        #line 58 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDay;
using System.Xml.Serialization;
using System.Web.Security;
using System.Data;
using OnSite.WebUI.ClientCode.Models;
using OnSite.WebUI.Models;
using CadmusUtility;
using System.Configuration;
using OnSite.WebUI.Classes;

namespace OnSite.WebUI.ClientCode.WebServices
{
    public partial class ");

        
        #line default
        #line hidden
        
        #line 76 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 76 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write("Calendar : System.Web.UI.Page\r\n    {\r\n        private SiteVisitDataEntities dataC" +
        "tx = new SiteVisitDataEntities();\r\n        private SiteVisitMetaEntities metaCtx" +
        " = new SiteVisitMetaEntities();\r\n        protected void Page_Load(object sender," +
        " EventArgs e)\r\n        {\r\n            IEnumerable<SiteVisitAppointment> appointm" +
        "ents = null;\r\n            int siteVisitID = 0;\r\n\r\n            if (!string.IsNull" +
        "OrEmpty(Request[\"q\"]))\r\n            {\r\n                var requestQuery = HttpUt" +
        "ility.ParseQueryString(Encoding.Base64Decode(Request[\"q\"]));\r\n\r\n                " +
        "Guid resourceUserKey;\r\n                Guid requestingUserKey;\r\n\r\n              " +
        "  Guid.TryParse(requestQuery[\"RID\"], out resourceUserKey);\r\n                Guid" +
        ".TryParse(requestQuery[\"UID\"], out requestingUserKey);\r\n\r\n                siteVi" +
        "sitID = CadmusUtility.SafeConversion.IntParse(requestQuery[\"SID\"], 0);\r\n\r\n      " +
        "          if (resourceUserKey != Guid.Empty && requestingUserKey != Guid.Empty &" +
        "& siteVisitID != 0)\r\n                    appointments = GetAppointmentsByResourc" +
        "e(siteVisitID, requestingUserKey, resourceUserKey);\r\n                else if (re" +
        "sourceUserKey == Guid.Empty && requestingUserKey != Guid.Empty && siteVisitID !=" +
        " 0)\r\n                    appointments = GetAppointmentsBySiteVisit(siteVisitID, " +
        "requestingUserKey);\r\n            }\r\n\r\n            if (appointments != null && si" +
        "teVisitID != 0)\r\n                RenderAppointmentsICS(siteVisitID, appointments" +
        ");\r\n            else\r\n                Response.Redirect(Page.ResolveClientUrl(\"~" +
        "/\"));\r\n        }\r\n\r\n        /** Get appointments for a given resource **/\r\n     " +
        "   private IEnumerable<SiteVisitAppointment> GetAppointmentsByResource(int siteV" +
        "isitID, Guid requestingUserKey, Guid resourceUserKey)\r\n        {\r\n            IE" +
        "numerable<SiteVisitAppointment> appointments = null;\r\n            MembershipUser" +
        " requestingUser = Membership.GetUser(requestingUserKey);\r\n            Membership" +
        "User resourceUser = Membership.GetUser(resourceUserKey);\r\n\r\n            //Verify" +
        " that users are okay to view calendar\r\n            if (requestingUser.IsApproved" +
        " && Roles.IsUserInRole(requestingUser.UserName, \"Resource\") && Roles.IsUserInRol" +
        "e(resourceUser.UserName, \"Resource\"))\r\n            {\r\n                string res" +
        "ourceID = resourceUser.UserName;\r\n\r\n                //The username and the User " +
        "GUID provided match.The fun begins.                \r\n                appointment" +
        "s = (from s in dataCtx.SiteVisitAppointments\r\n                                wh" +
        "ere s.ResourceID == resourceID && s.SiteVisitID == siteVisitID\r\n                " +
        "                select s);\r\n\r\n            }\r\n            return appointments;\r\n " +
        "       }\r\n\r\n        /** Get appointments for the entire site visit **/\r\n        " +
        "private IEnumerable<SiteVisitAppointment> GetAppointmentsBySiteVisit(int siteVis" +
        "itID, Guid requestingUserKey)\r\n        {\r\n            IEnumerable<SiteVisitAppoi" +
        "ntment> appointments = null;\r\n            MembershipUser requestingUser = Member" +
        "ship.GetUser(requestingUserKey);\r\n\t\t\tProfileHelper requestinUserProfile = Profil" +
        "eHelper.GetUserProfile(requestingUser.UserName);\r\n\r\n\t\t\tstring reportViewerFilter" +
        "Value = requestinUserProfile.ReportViewerFilterValue;\r\n\r\n            if (request" +
        "ingUser.IsApproved)\r\n            {              \r\n                appointments =" +
        " (from s in dataCtx.SiteVisitAppointments\r\n\t\t\t\t\t\t\t\tjoin c in dataCtx.");

        
        #line default
        #line hidden
        
        #line 142 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(table));

        
        #line default
        #line hidden
        
        #line 142 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write("Appointments on s.SiteVisitAppointmentID equals c.SiteVisitAppointmentID\r\n       " +
        "                         where s.SiteVisitID == siteVisitID\r\n\t\t\t\t\t\t\t\t");

        
        #line default
        #line hidden
        
        #line 144 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(reportViewerFilterExpression));

        
        #line default
        #line hidden
        
        #line 144 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write("\r\n                                select s);\r\n            }\r\n\r\n            return" +
        " appointments;\r\n        }\r\n\r\n        private void RenderAppointmentsICS(int site" +
        "VisitID, IEnumerable<SiteVisitAppointment> appointments)\r\n        {\r\n           " +
        " var siteVisit = (from sv in metaCtx.SiteVisits\r\n                             wh" +
        "ere sv.SiteVisitID == siteVisitID\r\n                             select sv).First" +
        "OrDefault();\r\n\r\n            DDay.iCal.iCalendar onSiteCalendar = new DDay.iCal.i" +
        "Calendar();\r\n            onSiteCalendar.Version = \"2.0\";\r\n            onSiteCale" +
        "ndar.AddProperty(\"X-WR-CALNAME\", siteVisit.Project.Client.ClientName + \" \" + sit" +
        "eVisit.SiteVisitName + \" Schedule\");\r\n\r\n            //add possible timezones to " +
        "calendar\r\n            foreach (string tz in getTimeZones())\r\n            {\r\n    " +
        "            System.TimeZoneInfo timezoneinfo = System.TimeZoneInfo.FindSystemTim" +
        "eZoneById(tz);\r\n                DDay.iCal.iCalTimeZone timezone = DDay.iCal.iCal" +
        "TimeZone.FromSystemTimeZone(timezoneinfo);\r\n                onSiteCalendar.AddTi" +
        "meZone(timezone);\r\n            }\r\n\r\n            foreach (SiteVisitAppointment sv" +
        "a in appointments)\r\n            {\r\n                DDay.iCal.Event myEvent = onS" +
        "iteCalendar.Create<DDay.iCal.Event>();\r\n                myEvent.Start = new DDay" +
        ".iCal.iCalDateTime(sva.AppointmentStartDate, ConfigurationManager.AppSettings[\"I" +
        "CalTimeZone\"].ToString());\r\n                myEvent.End = new DDay.iCal.iCalDate" +
        "Time(sva.AppointmentEndDate, ConfigurationManager.AppSettings[\"ICalTimeZone\"].To" +
        "String());\r\n                myEvent.Summary = sva.Subject;\r\n                myEv" +
        "ent.Location = sva.AppointmentLocation;\r\n                myEvent.Description = s" +
        "va.Description;\r\n                myEvent.Resources.Add(sva.ResourceID);\r\n       " +
        "     }\r\n\r\n            DDay.iCal.Serialization.iCalendar.iCalendarSerializer mySe" +
        "rializer = new DDay.iCal.Serialization.iCalendar.iCalendarSerializer();\r\n       " +
        "     Response.Clear();\r\n            Response.ContentType = \"text/calendar\";\r\n   " +
        "         Response.AppendHeader(\"Content-Disposition\", \"attachment; filename=\" + " +
        "siteVisit.Project.Client.ClientName + \".\" + siteVisit.SiteVisitName + \".ics\");\r\n" +
        "\r\n            string output = mySerializer.SerializeToString(onSiteCalendar);\r\n " +
        "           Response.Write(output);\r\n            Response.End();\r\n        }\r\n\r\n  " +
        "      private List<string> getTimeZones()\r\n        {\r\n            string[] tz = " +
        "\r\n                { \r\n                    \"Eastern Standard Time\",\r\n            " +
        "        \"Central Standard Time\",\r\n                    \"Mountain Standard Time\",\r" +
        "\n                    \"Pacific Standard Time\"\r\n                };\r\n\r\n            " +
        "return tz.ToList<string>();\r\n        }\r\n\r\n    }\r\n}\r\n");

        
        #line default
        #line hidden
        
        #line 205 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"

    }

	void GenerateDesignerFile(SiteVisit sitevisit, IEnumerable<SiteVisitForm> forms)
	{
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");
		var parentForm = SiteVisitDBHelper.GetParentForm(sitevisit);
		string table = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBTableName;
        string pkey = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBPrimaryKeyName;

        
        #line default
        #line hidden
        
        #line 214 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write(@"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnSite.WebUI.ClientCode.WebServices
{


    public partial class ");

        
        #line default
        #line hidden
        
        #line 227 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 227 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"
this.Write(@"Calendar
    {

        /// <summary>
        /// form1 control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.HtmlControls.HtmlForm form1;
    }
}

");

        
        #line default
        #line hidden
        
        #line 241 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\iCalTemplate.tt"

	}

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public class iCalTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
