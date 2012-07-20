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
    
    
    #line 1 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class FormsPrintTemplate : FormsPrintTemplateBase
    {
        public virtual string TransformText()
        {
            
            #line 2 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"

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
        
        #line 16 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"

    void GeneratePage(SiteVisit sitevisit, IEnumerable<SiteVisitForm> forms)
	{
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

        
        #line default
        #line hidden
        
        #line 20 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("<%@ Page Title=\"");

        
        #line default
        #line hidden
        
        #line 21 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 21 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(" Print\" Language=\"C#\" MasterPageFile=\"~/Site.master\" AutoEventWireup=\"true\" CodeB" +
        "ehind=\"");

        
        #line default
        #line hidden
        
        #line 21 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 21 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("Print.aspx.cs\" Inherits=\"OnSite.WebUI.SiteVisits.");

        
        #line default
        #line hidden
        
        #line 21 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 21 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("Print\" %>\r\n");

        
        #line default
        #line hidden
        
        #line 22 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(GenerateUserControlReferences(forms)));

        
        #line default
        #line hidden
        
        #line 22 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(@"

<asp:Content ID=""HeaderContent"" runat=""server"" ContentPlaceHolderID=""HeadContent"">
</asp:Content>
<asp:Content ID=""BodyContent"" runat=""server"" ContentPlaceHolderID=""MainContent"">
    <h2>
        Forms Printer
    </h2>
	<input type=""button"" value=""Print this page"" onClick=""window.print()"" />
");

        
        #line default
        #line hidden
        
        #line 31 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(GenerateUserControls(forms)));

        
        #line default
        #line hidden
        
        #line 31 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("\r\n</asp:Content>\r\n");

        
        #line default
        #line hidden
        
        #line 33 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"

    }  

	private string GenerateUserControlReferences(IEnumerable<SiteVisitForm> forms)
	{
		foreach(SiteVisitForm form in forms) {

        
        #line default
        #line hidden
        
        #line 39 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("<%@ Register src=\"~/UserControls/GeneratedForms/");

        
        #line default
        #line hidden
        
        #line 39 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(form.DBTableName));

        
        #line default
        #line hidden
        
        #line 39 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(".ascx\" tagname=\"");

        
        #line default
        #line hidden
        
        #line 39 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(form.DBTableName));

        
        #line default
        #line hidden
        
        #line 39 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("\" tagprefix=\"uc\" %>\r\n");

        
        #line default
        #line hidden
        
        #line 40 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
 
		}
		return "";
	}
	

	private string GenerateUserControls(IEnumerable<SiteVisitForm> forms)
	{
		foreach(SiteVisitForm form in forms) {
			string visible = form.SiteVisitParentFormID == null ? "True" : "False";

        
        #line default
        #line hidden
        
        #line 50 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("\t<h3>");

        
        #line default
        #line hidden
        
        #line 50 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(form.UIDisplayName));

        
        #line default
        #line hidden
        
        #line 50 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("</h3>\r\n\t<uc:");

        
        #line default
        #line hidden
        
        #line 51 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(form.DBTableName));

        
        #line default
        #line hidden
        
        #line 51 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(" ID=\"uc");

        
        #line default
        #line hidden
        
        #line 51 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(form.DBTableName));

        
        #line default
        #line hidden
        
        #line 51 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("\" runat=\"server\" />\r\n");

        
        #line default
        #line hidden
        
        #line 52 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
 
		}
		return "";
	}

    void GenerateCodeFile(SiteVisit sitevisit, IEnumerable<SiteVisitForm> forms)
	{
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

        
        #line default
        #line hidden
        
        #line 60 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("\r\nusing System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Sys" +
        "tem.Web;\r\nusing System.Web.UI;\r\nusing System.Web.UI.WebControls;\r\nusing OnSite.W" +
        "ebUI.Models;\r\n\r\nnamespace OnSite.WebUI.SiteVisits\r\n{\r\n    public partial class ");

        
        #line default
        #line hidden
        
        #line 72 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 72 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("Print : System.Web.UI.Page\r\n    {\r\n        protected void Page_Load(object sender" +
        ", EventArgs e)\r\n        {\r\n            if (!IsPostBack)\r\n            {\t\t\t\t\t\t\r\n");

        
        #line default
        #line hidden
        
        #line 78 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(GenerateUserControlBinds(forms)));

        
        #line default
        #line hidden
        
        #line 78 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("\r\n\t\t\t}\r\n\t\t}\r\n\r\n    }\r\n}\r\n");

        
        #line default
        #line hidden
        
        #line 84 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"

    }

	private string GenerateUserControlBinds(IEnumerable<SiteVisitForm> forms)
	{
		foreach(SiteVisitForm form in forms) {

        
        #line default
        #line hidden
        
        #line 90 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("\t\t\t\tuc");

        
        #line default
        #line hidden
        
        #line 90 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(form.DBTableName));

        
        #line default
        #line hidden
        
        #line 90 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(".BindListControls();        \r\n");

        
        #line default
        #line hidden
        
        #line 91 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
 
		}
		return "";
	}

	void GenerateDesignerFile(SiteVisit sitevisit, IEnumerable<SiteVisitForm> forms)
	{
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

        
        #line default
        #line hidden
        
        #line 99 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(@"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated. 
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnSite.WebUI.SiteVisits {
    
    
    public partial class ");

        
        #line default
        #line hidden
        
        #line 112 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 112 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("Print {\r\n\r\n");

        
        #line default
        #line hidden
        
        #line 114 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(GenerateDesignerProperties(forms)));

        
        #line default
        #line hidden
        
        #line 114 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("\r\n\r\n\t}\r\n}\r\n");

        
        #line default
        #line hidden
        
        #line 118 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"

	}

	private string GenerateDesignerProperties(IEnumerable<SiteVisitForm> forms)
	{
		foreach(SiteVisitForm form in forms) {

        
        #line default
        #line hidden
        
        #line 124 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write("        /// <summary>\r\n        /// uc");

        
        #line default
        #line hidden
        
        #line 126 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(form.DBTableName));

        
        #line default
        #line hidden
        
        #line 126 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(@" control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::OnSite.WebUI.UserControls.GeneratedForms.");

        
        #line default
        #line hidden
        
        #line 132 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(form.DBTableName));

        
        #line default
        #line hidden
        
        #line 132 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(" uc");

        
        #line default
        #line hidden
        
        #line 132 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(form.DBTableName));

        
        #line default
        #line hidden
        
        #line 132 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
this.Write(";\r\n");

        
        #line default
        #line hidden
        
        #line 133 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\FormsPrintTemplate.tt"
 
		}
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
    public class FormsPrintTemplateBase
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
