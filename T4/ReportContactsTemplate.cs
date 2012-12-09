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
    
    
    #line 1 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class ReportContactsTemplate : ReportContactsTemplateBase
    {
        public virtual string TransformText()
        {
            
            #line 2 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"

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
        
        #line 16 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"

    void GeneratePage(SiteVisit sitevisit, IEnumerable<SiteVisitForm> forms)
    {
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");
		var parentForm = SiteVisitDBHelper.GetParentForm(sitevisit);
		string table = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBTableName;
        string pkey = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBPrimaryKeyName;

		SiteVisitFormField reportViewerFilterField = SiteVisitDBHelper.GetSiteVisitReportViewerFilterField(parentForm);
		string reportViewerFilterExpression = "", whereParameters = "";
		if (reportViewerFilterField != null)
		{
			reportViewerFilterExpression = "it." + reportViewerFilterField.FieldName + " = @ReportViewerFilterValue OR @ReportViewerFilterValue IS NULL OR @ReportViewerFilterValue = ''";
			whereParameters = @"<WhereParameters>
            <asp:ProfileParameter Name=""ReportViewerFilterValue"" PropertyName=""ReportViewerFilterValue"" Type=""String"" />
        </WhereParameters>";
		}

        
        #line default
        #line hidden
        
        #line 33 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("<%@ Page Title=\"");

        
        #line default
        #line hidden
        
        #line 33 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(parentForm.UIDisplayName));

        
        #line default
        #line hidden
        
        #line 33 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(" Search\" Language=\"C#\" MasterPageFile=\"~/Site.master\" AutoEventWireup=\"true\" Code" +
        "Behind=\"");

        
        #line default
        #line hidden
        
        #line 33 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 33 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("Search.aspx.cs\" Inherits=\"OnSite.WebUI.ClientCode.Reports.");

        
        #line default
        #line hidden
        
        #line 33 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 33 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(@"Search"" %>
<%@ Register Assembly=""DevExpress.Web.ASPxGridView.v12.1.Export, Version=12.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a""
    Namespace=""DevExpress.Web.ASPxGridView.Export"" TagPrefix=""dx"" %>
<asp:Content ID=""Content1"" ContentPlaceHolderID=""HeadContent"" runat=""server"">
<script type=""text/javascript"">

</script>
</asp:Content>
<asp:Content ID=""Content2"" ContentPlaceHolderID=""MainContent"" runat=""server"">
	<h2>Contacts</h2>
	<table>
		<tr>
			<td>
				<dx:ASPxButton ID=""btnCsvExport"" runat=""server"" Text=""Export to Csv"" UseSubmitBehavior=""False"" />
			</td>
            <td>            
                <dx:ASPxButton ID=""btnResetToDefault"" AutoPostBack=""false"" runat=""server"" Text=""Reset Columns"">
                    <ClientSideEvents Click=""function(s,e){ASPxClientUtils.DeleteCookie('");

        
        #line default
        #line hidden
        
        #line 50 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(table));

        
        #line default
        #line hidden
        
        #line 50 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("ContactsReportCookie\'); window.location = window.location;}\" />\r\n                " +
        "</dx:ASPxButton>\r\n            </td>\r\n\t\t</tr>\r\n\t</table>\r\n    <dx:ASPxGridView ID" +
        "=\"ASPxGridView1\" runat=\"server\" AutoGenerateColumns=\"False\" \r\n\t\tDataSourceID=\"");

        
        #line default
        #line hidden
        
        #line 56 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(table));

        
        #line default
        #line hidden
        
        #line 56 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("DataSource\" \r\n\t\tKeyFieldName=\"");

        
        #line default
        #line hidden
        
        #line 57 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(pkey));

        
        #line default
        #line hidden
        
        #line 57 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(@"""
		ClientInstanceName=""grid"">
        <Columns>
            <dx:GridViewCommandColumn VisibleIndex=""0"">
                <ClearFilterButton Visible=""True"">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName=""");

        
        #line default
        #line hidden
        
        #line 64 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(pkey));

        
        #line default
        #line hidden
        
        #line 64 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\" Caption=\"");

        
        #line default
        #line hidden
        
        #line 64 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(pkey));

        
        #line default
        #line hidden
        
        #line 64 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(@"""
                ReadOnly=""True"" VisibleIndex=""0"" Visible=""False"">
			</dx:GridViewDataTextColumn>
			<dx:GridViewDataComboBoxColumn FieldName=""DispositionID"" Caption=""Disposition"" ReadOnly=""True"" VisibleIndex=""0"" Visible=""true"">
				<PropertiesComboBox DataSourceID=""DispositionsDataSource"" ValueField=""DispositionID"" IncrementalFilteringMode=""StartsWith"" TextField=""DispositionName"" ValueType=""System.Int32"" DropDownStyle=""DropDown"" />
			</dx:GridViewDataComboBoxColumn>
");

        
        #line default
        #line hidden
        
        #line 70 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(GenerateGridViewColumns(parentForm)));

        
        #line default
        #line hidden
        
        #line 70 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\r\n");

        
        #line default
        #line hidden
        
        #line 71 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(GenerateGridViewExportColumns(parentForm)));

        
        #line default
        #line hidden
        
        #line 71 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(@"
            <dx:GridViewDataTextColumn FieldName=""LocationLatitude"" 
                ReadOnly=""True"" VisibleIndex=""0"" Visible=""False"">
			</dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName=""LocationLongitude"" 
                ReadOnly=""True"" VisibleIndex=""0"" Visible=""False"">
			</dx:GridViewDataTextColumn>
        </Columns>
        <Settings ShowFilterRow=""True"" ShowHeaderFilterButton=""true"" />
		<SettingsBehavior />
		<SettingsPager PageSizeItemSettings-Visible=""true""></SettingsPager>
        <SettingsCookies CookiesID=""");

        
        #line default
        #line hidden
        
        #line 82 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(table));

        
        #line default
        #line hidden
        
        #line 82 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("ContactsReportCookie\" Enabled=\"true\" StoreColumnsVisiblePosition=\"true\" StoreFilt" +
        "ering=\"false\" StoreGroupingAndSorting=\"false\" StorePaging=\"false\" />\r\n\t\t<ClientS" +
        "ideEvents />\r\n    </dx:ASPxGridView>\r\n    <asp:EntityDataSource ID=\"");

        
        #line default
        #line hidden
        
        #line 85 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(table));

        
        #line default
        #line hidden
        
        #line 85 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("DataSource\" runat=\"server\" \r\n        ConnectionString=\"name=SiteVisitDataEntities" +
        "\" \r\n        DefaultContainerName=\"SiteVisitDataEntities\" EnableFlattening=\"False" +
        "\" \r\n        EntitySetName=\"");

        
        #line default
        #line hidden
        
        #line 88 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(table));

        
        #line default
        #line hidden
        
        #line 88 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\" Where=\"");

        
        #line default
        #line hidden
        
        #line 88 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(reportViewerFilterExpression));

        
        #line default
        #line hidden
        
        #line 88 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\">\r\n        ");

        
        #line default
        #line hidden
        
        #line 89 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(whereParameters));

        
        #line default
        #line hidden
        
        #line 89 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(@"
    </asp:EntityDataSource>
	<asp:EntityDataSource ID=""DispositionsDataSource"" runat=""server"" 
		ConnectionString=""name=SiteVisitDataEntities"" DefaultContainerName=""SiteVisitDataEntities"" 
		EnableFlattening=""False"" EntitySetName=""Dispositions"">
	</asp:EntityDataSource> 
	<dx:ASPxGridViewExporter ID=""gridExport"" runat=""server"" GridViewID=""ASPxGridView1"">
    </dx:ASPxGridViewExporter>
</asp:Content>

");

        
        #line default
        #line hidden
        
        #line 99 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"

    }  

	private string GenerateGridViewColumns(SiteVisitForm form)
	{
		foreach(SiteVisitFormField field in SiteVisitDBHelper.GetSiteVisitSearchableFields(form)) {

        
        #line default
        #line hidden
        
        #line 105 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\t\t\t<dx:GridViewDataTextColumn FieldName=\"");

        
        #line default
        #line hidden
        
        #line 105 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(field.FieldName));

        
        #line default
        #line hidden
        
        #line 105 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\" Caption=\"");

        
        #line default
        #line hidden
        
        #line 105 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(field.FieldLabel));

        
        #line default
        #line hidden
        
        #line 105 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\"\r\n                ReadOnly=\"True\" VisibleIndex=\"");

        
        #line default
        #line hidden
        
        #line 106 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(field.FieldTabIndex));

        
        #line default
        #line hidden
        
        #line 106 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\">\r\n            </dx:GridViewDataTextColumn>\r\n");

        
        #line default
        #line hidden
        
        #line 108 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
 
		}
		return "";
	}

	private string GenerateGridViewExportColumns(SiteVisitForm form)
	{
		foreach(SiteVisitFormField field in SiteVisitDBHelper.GetSiteVisitExportFields(form)) {
			string output = "";
			//checkbox columns
			if (field.ControlType.ControlTypeID == 1)
			{
				foreach(SiteVisitFormFieldItem item in field.SiteVisitFormFieldItems)
				{
					output += "\t\t\t<dx:GridViewDataTextColumn FieldName=\""+ field.FieldName +"_"+item.ListItemValue +"\" Caption=\""+item.ListItemLabel+"\" ReadOnly=\"True\" VisibleIndex=\""+ field.FieldTabIndex +"\" Visible=\"False\">\r\n\t\t\t</dx:GridViewDataTextColumn>\r\n";
				}
			}
			else 
			{
				output = "<dx:GridViewDataTextColumn FieldName=\""+ field.FieldName +"\" ReadOnly=\"True\" VisibleIndex=\""+ field.FieldTabIndex +"\" Visible=\"False\">\r\n\t\t\t</dx:GridViewDataTextColumn>";
			}


        
        #line default
        #line hidden
        
        #line 130 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\t\t\t");

        
        #line default
        #line hidden
        
        #line 130 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(output));

        
        #line default
        #line hidden
        
        #line 130 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\r\n");

        
        #line default
        #line hidden
        
        #line 131 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
 
		}
		return "";
	}

    void GenerateCodeFile(SiteVisit sitevisit, IEnumerable<SiteVisitForm> forms)
    {
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");
		var parentForm = SiteVisitDBHelper.GetParentForm(sitevisit);
		string table = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBTableName;
        string pkey = sitevisit.SiteVisitName.Replace(" ", "") + "_" + parentForm.DBPrimaryKeyName;

        
        #line default
        #line hidden
        
        #line 142 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses;
using OnSite.WebUI.ClientCode.Models;
using OnSite.WebUI.Models;

namespace OnSite.WebUI.ClientCode.Reports
{
    public partial class ");

        
        #line default
        #line hidden
        
        #line 156 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 156 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(@"Search : System.Web.UI.Page
    {
        SiteVisitDataEntities ctx = new SiteVisitDataEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
			btnCsvExport.Click += new EventHandler(btnCsvExport_Click);
        }


        protected void btnCsvExport_Click(object sender, EventArgs e)
        {
			ASPxGridView1.Columns[""");

        
        #line default
        #line hidden
        
        #line 168 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(pkey));

        
        #line default
        #line hidden
        
        #line 168 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\"].Visible = true;\r\n");

        
        #line default
        #line hidden
        
        #line 169 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(GenerateExportColumns(parentForm)));

        
        #line default
        #line hidden
        
        #line 169 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\r\n\t\t\tASPxGridView1.DataBind();\r\n\t\t\tgridExport.FileName = \"");

        
        #line default
        #line hidden
        
        #line 171 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(table));

        
        #line default
        #line hidden
        
        #line 171 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\";\r\n            gridExport.WriteCsvToResponse();\r\n        }\r\n    }\r\n}\r\n");

        
        #line default
        #line hidden
        
        #line 176 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"

    }

	private string GenerateExportColumns(SiteVisitForm form)
	{

		foreach(SiteVisitFormField field in SiteVisitDBHelper.GetSiteVisitExportFields(form)) {
			string output = "";
			//checkbox columns
			if (field.ControlType.ControlTypeID == 1)
			{
				foreach(SiteVisitFormFieldItem item in field.SiteVisitFormFieldItems)
				{
					output += "ASPxGridView1.Columns[\""+ field.FieldName +"_"+item.ListItemValue +"\"].Visible = true;\r\n";
				}
			}
			else 
			{
				output = "ASPxGridView1.Columns[\""+ field.FieldName +"\"].Visible = true;";
			}

        
        #line default
        #line hidden
        
        #line 196 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\t\t\t");

        
        #line default
        #line hidden
        
        #line 196 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(output));

        
        #line default
        #line hidden
        
        #line 196 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("\r\n");

        
        #line default
        #line hidden
        
        #line 197 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
 
		}
		return "";
	}
	

	void GenerateDesignerFile(SiteVisit sitevisit, IEnumerable<SiteVisitForm> forms)
	{
		string sitevisitName = sitevisit.SiteVisitName.Replace(" ", "");

        
        #line default
        #line hidden
        
        #line 206 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(@"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated. 
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnSite.WebUI.ClientCode.Reports {
    
    
    public partial class ");

        
        #line default
        #line hidden
        
        #line 219 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(sitevisitName));

        
        #line default
        #line hidden
        
        #line 219 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"
this.Write("Search {\r\n        \r\n\t\t/// <summary>\r\n        /// btnXLSExport control.\r\n        /" +
        "// </summary>\r\n        /// <remarks>\r\n        /// Auto-generated field.\r\n       " +
        " /// To modify move field declaration from designer file to code-behind file.\r\n " +
        "       /// </remarks>\r\n        protected global::DevExpress.Web.ASPxEditors.ASPx" +
        "Button btnCsvExport;\r\n\r\n        /// <summary>\r\n        /// ASPxGridView1 control" +
        ".\r\n        /// </summary>\r\n        /// <remarks>\r\n        /// Auto-generated fie" +
        "ld.\r\n        /// To modify move field declaration from designer file to code-beh" +
        "ind file.\r\n        /// </remarks>\r\n        protected global::DevExpress.Web.ASPx" +
        "GridView.ASPxGridView ASPxGridView1;\r\n\r\n\t\t/// <summary>\r\n        /// cbDispositi" +
        "on control.\r\n        /// </summary>\r\n        /// <remarks>\r\n        /// Auto-gen" +
        "erated field.\r\n        /// To modify move field declaration from designer file t" +
        "o code-behind file.\r\n        /// </remarks>\r\n        protected global::DevExpres" +
        "s.Web.ASPxEditors.ASPxComboBox cbDisposition;\r\n\r\n\t\t/// <summary>\r\n        /// Di" +
        "spositionsDataSource control.\r\n        /// </summary>\r\n        /// <remarks>\r\n  " +
        "      /// Auto-generated field.\r\n        /// To modify move field declaration fr" +
        "om designer file to code-behind file.\r\n        /// </remarks>\r\n        protected" +
        " global::System.Web.UI.WebControls.EntityDataSource DispositionsDataSource;\r\n   " +
        "     \r\n        /// <summary>\r\n        /// gridExport control.\r\n        /// </sum" +
        "mary>\r\n        /// <remarks>\r\n        /// Auto-generated field.\r\n        /// To " +
        "modify move field declaration from designer file to code-behind file.\r\n        /" +
        "// </remarks>\r\n        protected global::DevExpress.Web.ASPxGridView.Export.ASPx" +
        "GridViewExporter gridExport;\r\n\r\n\t}\r\n}\r\n");

        
        #line default
        #line hidden
        
        #line 268 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\ReportContactsTemplate.tt"

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
    public class ReportContactsTemplateBase
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
