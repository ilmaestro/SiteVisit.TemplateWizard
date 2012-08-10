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
    
    
    #line 1 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class ReportAppointmentsTemplate : ReportAppointmentsTemplateBase
    {
        public virtual string TransformText()
        {
            
            #line 2 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"

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
        
        #line 16 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"

    void GeneratePage(SiteVisit sitevisit, IEnumerable<SiteVisitForm> forms)
    {
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");
		var parentForm = SiteVisitDBHelper.GetParentForm(sitevisit);
		string table = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBTableName;
        string pkey = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBPrimaryKeyName;

        
        #line default
        #line hidden
        
        #line 23 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write("<%@ Page Title=\"");

        
        #line default
        #line hidden
        
        #line 23 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisit.SiteVisitName));

        
        #line default
        #line hidden
        
        #line 23 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write("\" Language=\"C#\" MasterPageFile=\"~/Site.master\" AutoEventWireup=\"true\" CodeBehind=" +
        "\"");

        
        #line default
        #line hidden
        
        #line 23 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 23 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write("Appointments.aspx.cs\" Inherits=\"OnSite.WebUI.Reports.");

        
        #line default
        #line hidden
        
        #line 23 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 23 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(@"Appointments"" %>
<%@ Register Assembly=""DevExpress.Web.ASPxGridView.v12.1.Export, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a""
    Namespace=""DevExpress.Web.ASPxGridView.Export"" TagPrefix=""dx"" %>
<asp:Content ID=""Content1"" ContentPlaceHolderID=""HeadContent"" runat=""server"">
<script type=""text/javascript"">
    // <![CDATA[
    // ]]> 
</script>
</asp:Content>
<asp:Content ID=""Content2"" ContentPlaceHolderID=""MainContent"" runat=""server"">
	<h2>Data Import/Export</h2>
	<dx:ASPxButton ID=""btnCsvExport"" runat=""server"" Text=""Export to Csv"" UseSubmitBehavior=""False"" />
    <div style=""margin-top: 5px; margin-bottom: 5px;"">
    <dx:ASPxGridView ID=""grid"" runat=""server"" AutoGenerateColumns=""False"" ClientInstanceName=""grid"" 
        DataSourceID=""AppointmentsDataSource"" KeyFieldName=""");

        
        #line default
        #line hidden
        
        #line 37 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(table));

        
        #line default
        #line hidden
        
        #line 37 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write("AppointmentID\">\r\n        <Columns>\r\n            <dx:GridViewDataTextColumn FieldN" +
        "ame=\"");

        
        #line default
        #line hidden
        
        #line 39 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(pkey));

        
        #line default
        #line hidden
        
        #line 39 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write("\" Caption=\"Contact ID\" ReadOnly=\"True\" Visible=\"true\"\r\n                VisibleInd" +
        "ex=\"0\">\r\n            </dx:GridViewDataTextColumn>\r\n            <dx:GridViewDataT" +
        "extColumn FieldName=\"SiteVisitAppointmentID\" Caption=\"Appointment ID\" ReadOnly=\"" +
        "True\" Visible=\"True\"\r\n                VisibleIndex=\"0\">\r\n            </dx:GridVi" +
        "ewDataTextColumn>\r\n\t\t\t<dx:GridViewDataTextColumn FieldName=\"AppointmentStatus.Ap" +
        "pointmentStatusName\" Caption=\"Appointment Status\" VisibleIndex=\"1\" Visible=\"true" +
        "\">\r\n            </dx:GridViewDataTextColumn>\r\n            <dx:GridViewDataTextCo" +
        "lumn FieldName=\"SiteVisitAppointment.SiteVisitID\" VisibleIndex=\"1\" Visible=\"fals" +
        "e\">\r\n            </dx:GridViewDataTextColumn>\r\n            <dx:GridViewDataTextC" +
        "olumn FieldName=\"SiteVisitAppointment.ResourceID\" VisibleIndex=\"2\">\r\n           " +
        " </dx:GridViewDataTextColumn>\r\n            <dx:GridViewDataTextColumn FieldName=" +
        "\"SiteVisitAppointment.Type\" VisibleIndex=\"3\" Visible=\"false\">\r\n            </dx:" +
        "GridViewDataTextColumn>\r\n            <dx:GridViewDataTextColumn FieldName=\"SiteV" +
        "isitAppointment.Subject\" VisibleIndex=\"4\">\r\n            </dx:GridViewDataTextCol" +
        "umn>\r\n            <dx:GridViewDataTextColumn FieldName=\"SiteVisitAppointment.Des" +
        "cription\" VisibleIndex=\"5\">\r\n            </dx:GridViewDataTextColumn>\r\n         " +
        "   <dx:GridViewDataTextColumn FieldName=\"SiteVisitAppointment.AppointmentLocatio" +
        "n\" VisibleIndex=\"6\">\r\n            </dx:GridViewDataTextColumn>\r\n            <dx:" +
        "GridViewDataTextColumn FieldName=\"SiteVisitAppointment.AppointmentStartDate\" Vis" +
        "ibleIndex=\"7\">\r\n            </dx:GridViewDataTextColumn>\r\n            <dx:GridVi" +
        "ewDataTextColumn FieldName=\"SiteVisitAppointment.AppointmentEndDate\" VisibleInde" +
        "x=\"8\">\r\n            </dx:GridViewDataTextColumn>\r\n            <dx:GridViewDataTe" +
        "xtColumn FieldName=\"SiteVisitAppointment.Status\" VisibleIndex=\"10\" Visible=\"fals" +
        "e\">\r\n            </dx:GridViewDataTextColumn>\r\n            <dx:GridViewDataTextC" +
        "olumn FieldName=\"SiteVisitAppointment.Label\" VisibleIndex=\"11\" Visible=\"false\">\r" +
        "\n            </dx:GridViewDataTextColumn>\r\n        </Columns>\r\n\t\t<Settings ShowF" +
        "ilterRow=\"True\" />\r\n    </dx:ASPxGridView>\r\n    </div>\r\n    <asp:EntityDataSourc" +
        "e ID=\"AppointmentsDataSource\" runat=\"server\" \r\n        ConnectionString=\"name=Si" +
        "teVisitDataEntities\" \r\n        DefaultContainerName=\"SiteVisitDataEntities\" Enab" +
        "leFlattening=\"False\" \r\n        EntitySetName=\"");

        
        #line default
        #line hidden
        
        #line 74 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(table));

        
        #line default
        #line hidden
        
        #line 74 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write("Appointments\" Include=\"SiteVisitAppointment,AppointmentStatus\" Where=\"it.SiteVisi" +
        "tAppointment.SiteVisitID = ");

        
        #line default
        #line hidden
        
        #line 74 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisit.SiteVisitID));

        
        #line default
        #line hidden
        
        #line 74 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write("\">\r\n    </asp:EntityDataSource>\r\n    <dx:ASPxGridViewExporter ID=\"gridExporter\" r" +
        "unat=\"server\" GridViewID=\"grid\">\r\n    </dx:ASPxGridViewExporter>\r\n    \r\n</asp:Co" +
        "ntent>\r\n\r\n");

        
        #line default
        #line hidden
        
        #line 81 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"

    }  

    void GenerateCodeFile(SiteVisit sitevisit, IEnumerable<SiteVisitForm> forms)
    {
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");
		var parentForm = SiteVisitDBHelper.GetParentForm(sitevisit);
		string table = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBTableName;
        string pkey = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBPrimaryKeyName;

        
        #line default
        #line hidden
        
        #line 90 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxUploadControl;
using System.IO;
using CadmusUtility;
using System.Data;
using OnSite.WebUI.Models;
using System.Web.Security;

namespace OnSite.WebUI.Reports
{
    public partial class ");

        
        #line default
        #line hidden
        
        #line 107 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 107 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(@"Appointments : System.Web.UI.Page
    {
        private SiteVisitDataEntities dataCtx = new SiteVisitDataEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnCsvExport.Click += new EventHandler(btnCsvExport_Click);
            grid.CustomCallback += new DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventHandler(grid_CustomCallback);
        }

        protected void grid_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            grid.DataBind();
        }

        protected void btnCsvExport_Click(object sender, EventArgs e)
        {
			gridExporter.FileName = """);

        
        #line default
        #line hidden
        
        #line 124 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 124 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write("Appointments\";\r\n            gridExporter.WriteCsvToResponse();\r\n        }\r\n    }\r" +
        "\n}\r\n");

        
        #line default
        #line hidden
        
        #line 129 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"

    }
	
	void GenerateDesignerFile(SiteVisit sitevisit, IEnumerable<SiteVisitForm> forms)
	{
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

        
        #line default
        #line hidden
        
        #line 135 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(@"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated. 
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnSite.WebUI.Reports {
    
    
    public partial class ");

        
        #line default
        #line hidden
        
        #line 148 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 148 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"
this.Write(@"Appointments {

/// <summary>
        /// btnCsvExport control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::DevExpress.Web.ASPxEditors.ASPxButton btnCsvExport;
        
        /// <summary>
        /// grid control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::DevExpress.Web.ASPxGridView.ASPxGridView grid;
        
        /// <summary>
        /// AppointmentsDataSource control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.EntityDataSource AppointmentsDataSource;
        
        /// <summary>
        /// gridExporter control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::DevExpress.Web.ASPxGridView.Export.ASPxGridViewExporter gridExporter;        
	}
}
");

        
        #line default
        #line hidden
        
        #line 187 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportAppointmentsTemplate.tt"

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
    public class ReportAppointmentsTemplateBase
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
