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
    
    
    #line 1 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class SitemapTemplate : SitemapTemplateBase
    {
        public virtual string TransformText()
        {
            
            #line 2 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"

GenerateSitemap(SiteVisit);

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 5 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"

	protected void GenerateSitemap(SiteVisit sitevisit)
	{

        
        #line default
        #line hidden
        
        #line 8 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<siteMap xmlns=""http://schemas.microsoft.com/AspNet/SiteMap-File-1.0"" >
	<siteMapNode url=""~/Default.aspx?id=1"" title=""Home""  description=""Home Page"">
	  <siteMapNode url=""~/Default.aspx"" title=""Home""  description=""Home Page""></siteMapNode>
");

        
        #line default
        #line hidden
        
        #line 13 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(GenerateAuditorMap(sitevisit)));

        
        #line default
        #line hidden
        
        #line 13 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("\r\n");

        
        #line default
        #line hidden
        
        #line 14 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(GenerateSchedulerMap(sitevisit)));

        
        #line default
        #line hidden
        
        #line 14 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("\r\n");

        
        #line default
        #line hidden
        
        #line 15 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(GenerateReportMap(sitevisit)));

        
        #line default
        #line hidden
        
        #line 15 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("\r\n");

        
        #line default
        #line hidden
        
        #line 16 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(GenerateResourceMap(sitevisit)));

        
        #line default
        #line hidden
        
        #line 16 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(@"
	  <siteMapNode url=""~/Documents/Default.aspx"" title=""Documents""  description=""Documents"" roles=""Administrator,Auditor,ReportViewer,Scheduler,Resource"" />
      <siteMapNode url=""~/Admin/ManageUsers.aspx"" title=""Admin""  description=""Administrative Manager"" roles=""Administrator"" />
	</siteMapNode>
</siteMap>
");

        
        #line default
        #line hidden
        
        #line 21 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"

    }  

	
	private string GenerateAuditorMap(SiteVisit sitevisit)
	{
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

        
        #line default
        #line hidden
        
        #line 28 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("\t\t\t<siteMapNode url=\"~/SiteVisits/");

        
        #line default
        #line hidden
        
        #line 28 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 28 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Search.aspx?id=1\" title=\"Site Visit\"  description=\"");

        
        #line default
        #line hidden
        
        #line 28 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 28 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(" Site Visit\" roles=\"Auditor\">\r\n        <siteMapNode url=\"~/SiteVisits/");

        
        #line default
        #line hidden
        
        #line 29 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 29 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Search.aspx\" title=\"Search\"  description=\"Search ");

        
        #line default
        #line hidden
        
        #line 29 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 29 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("\" />\r\n        <siteMapNode url=\"~/SiteVisits/");

        
        #line default
        #line hidden
        
        #line 30 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 30 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Preview.aspx\" title=\"Preview\"  description=\"Preview ");

        
        #line default
        #line hidden
        
        #line 30 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 30 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("\" />\r\n\t\t<siteMapNode url=\"~/SiteVisits/");

        
        #line default
        #line hidden
        
        #line 31 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 31 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Print.aspx\" title=\"Print\"  description=\"Print ");

        
        #line default
        #line hidden
        
        #line 31 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 31 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("\" />\r\n      </siteMapNode>\r\n");

        
        #line default
        #line hidden
        
        #line 33 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
 

		return "";
	}
	private string GenerateSchedulerMap(SiteVisit sitevisit)
	{
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

        
        #line default
        #line hidden
        
        #line 40 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("\t\t\t<siteMapNode url=\"~/Scheduler/");

        
        #line default
        #line hidden
        
        #line 40 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 40 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Edit.aspx?id=1\" title=\"Scheduler\"  description=\"");

        
        #line default
        #line hidden
        
        #line 40 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 40 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(" Schedule\" roles=\"Scheduler\">\r\n        <siteMapNode url=\"~/Scheduler/");

        
        #line default
        #line hidden
        
        #line 41 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 41 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Edit.aspx\" title=\"Calendar\"  description=\"Checklist Calendar\" />\r\n        <siteMa" +
        "pNode url=\"~/Scheduler/");

        
        #line default
        #line hidden
        
        #line 42 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 42 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Data.aspx\" title=\"Data Import/Export\"  description=\"Data Import/Export\" />\r\n     " +
        " </siteMapNode>\r\n");

        
        #line default
        #line hidden
        
        #line 44 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
 
		return "";
	}
	private string GenerateReportMap(SiteVisit sitevisit)
	{
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

        
        #line default
        #line hidden
        
        #line 50 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("\t\t\t<siteMapNode url=\"~/Reports/");

        
        #line default
        #line hidden
        
        #line 50 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 50 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Schedule.aspx?id=1\" title=\"Reports\"  description=\"");

        
        #line default
        #line hidden
        
        #line 50 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 50 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(" Reports\" roles=\"ReportViewer\">\r\n        <siteMapNode url=\"~/Reports/Master");

        
        #line default
        #line hidden
        
        #line 51 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 51 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Schedule.aspx\" title=\"Master Calendar\"  description=\"");

        
        #line default
        #line hidden
        
        #line 51 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 51 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(" Master Calendar\" />\r\n\t\t<siteMapNode url=\"~/Reports/");

        
        #line default
        #line hidden
        
        #line 52 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 52 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Schedule.aspx\" title=\"Print Schedule\"  description=\"");

        
        #line default
        #line hidden
        
        #line 52 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 52 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(" Schedule Report\" />        \r\n        <siteMapNode url=\"~/Reports/");

        
        #line default
        #line hidden
        
        #line 53 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 53 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Appointments.aspx\" title=\"Appointments\"  description=\"");

        
        #line default
        #line hidden
        
        #line 53 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 53 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(" Appointments Report\" />\r\n        <siteMapNode url=\"~/Reports/");

        
        #line default
        #line hidden
        
        #line 54 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 54 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Contacts.aspx\" title=\"Contacts\"  description=\"");

        
        #line default
        #line hidden
        
        #line 54 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 54 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(" Contacts Report\" />\r\n      </siteMapNode>\r\n");

        
        #line default
        #line hidden
        
        #line 56 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
 
		return "";
	}
	private string GenerateResourceMap(SiteVisit sitevisit)
	{
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

        
        #line default
        #line hidden
        
        #line 62 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("\t\t\t<siteMapNode url=\"~/Resource/My");

        
        #line default
        #line hidden
        
        #line 62 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 62 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Schedule.aspx?id=1\" title=\"Resource\"  description=\"");

        
        #line default
        #line hidden
        
        #line 62 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 62 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(" Resource\" roles=\"Resource\">\r\n        <siteMapNode url=\"~/Resource/My");

        
        #line default
        #line hidden
        
        #line 63 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 63 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
this.Write("Schedule.aspx\" title=\"My Schedule\"  description=\"My Schedule\" />\r\n      </siteMap" +
        "Node>\r\n");

        
        #line default
        #line hidden
        
        #line 65 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\SitemapTemplate.tt"
 
		return "";
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
    public class SitemapTemplateBase
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
