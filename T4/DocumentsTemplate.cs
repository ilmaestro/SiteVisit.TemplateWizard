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
    
    
    #line 1 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class DocumentsTemplate : DocumentsTemplateBase
    {
        public virtual string TransformText()
        {
            
            #line 2 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"

switch (OutputType) {
	case FileType.DocPage:
		GenerateDocumentPage();
		break;
	case FileType.DocCode:
		GenerateDocumentCodeFile();
		break;
	case FileType.DocDesigner:
		GenerateDocumentDesignerFile();
		break;
	case FileType.GetPage:
		GenerateGetFilePage();
		break;
	case FileType.GetCode:
		GenerateGetFileCodeFile();
		break;
	case FileType.GetDesigner:
		GenerateGetFileDesignerFile();
		break;
	default:
		break;
}

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 25 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"

    void GenerateDocumentPage()
	{

        
        #line default
        #line hidden
        
        #line 28 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"
this.Write("<%@ Page Title=\"Documents\" Language=\"C#\" MasterPageFile=\"~/Site.master\" AutoEvent" +
        "Wireup=\"true\" CodeBehind=\"Default.aspx.cs\" Inherits=\"OnSite.WebUI.ClientCode.Doc" +
        "uments.Default\" %>\r\n<asp:Content ID=\"HeaderContent\" runat=\"server\" ContentPlaceH" +
        "olderID=\"HeadContent\">\r\n<script type=\"text/javascript\">\r\n    // <![CDATA[\r\n    f" +
        "unction Uploader_OnUploadStart() {\r\n        btnUpload.SetEnabled(false);\r\n    }\r" +
        "\n    function Uploader_OnFileUploadComplete(args) {\r\n        if (args.callbackDa" +
        "ta.length > 0) {\r\n            alert(args.callbackData);\r\n        } else {\r\n     " +
        "       grid.PerformCallback(uploader.GetText() + \"|\" + txtDescription.GetText())" +
        ";\r\n            txtDescription.SetValue(\'\');\r\n        }\r\n    }\r\n    function Uplo" +
        "ader_OnFilesUploadComplete(args) {\r\n        UpdateUploadButton();\r\n    }\r\n    fu" +
        "nction UpdateUploadButton() {\r\n        btnUpload.SetEnabled(uploader.GetText(0) " +
        "!= \"\");\r\n    }\r\n    function OnCustomButtonClick(s, e) {\r\n        if (e.buttonID" +
        " == \'Delete\') {\r\n            e.processOnServer = confirm(\'Are you sure you want " +
        "to delete this item?\');\r\n        } else {\r\n            e.processOnServer = true;" +
        "\r\n        }\r\n    }\r\n\r\n    function OnGridEndCallback(s, e) {\r\n        if (grid.c" +
        "pErrorMessage.length > 0)\r\n\t\t{\r\n            alert(grid.cpErrorMessage); \r\n\t\t\tgri" +
        "d.cpErrorMessage = \"\";       \r\n\t\t}\r\n    }\r\n    // ]]> \r\n</script>\r\n</asp:Content" +
        ">\r\n<asp:Content ID=\"BodyContent\" runat=\"server\" ContentPlaceHolderID=\"MainConten" +
        "t\">\r\n\t<h2>Documents</h2>\r\n    <p>\r\n    <dx:ASPxPopupControl ID=\"pcUpload\" runat=" +
        "\"server\" ClientInstanceName=\"uploadPopup\" CloseAction=\"CloseButton\" Modal=\"True\"" +
        "\r\n        PopupHorizontalAlign=\"WindowCenter\" PopupVerticalAlign=\"WindowCenter\" " +
        "HeaderText=\"New Document\" AllowDragging=\"True\">\r\n        <ContentCollection>\r\n  " +
        "          <dx:PopupControlContentControl>\r\n                <dx:ASPxUploadControl" +
        " ID=\"uplFile\" runat=\"server\" ClientInstanceName=\"uploader\" ShowProgressPanel=\"Tr" +
        "ue\"\r\n                    NullText=\"Click here to browse files...\" Size=\"35\" OnFi" +
        "leUploadComplete=\"uploader_FileUploadComplete\">\r\n                    <ClientSide" +
        "Events FileUploadComplete=\"function(s, e) { Uploader_OnFileUploadComplete(e); }\"" +
        "\r\n                        FilesUploadComplete=\"function(s, e) { Uploader_OnFiles" +
        "UploadComplete(e); }\"\r\n                        FileUploadStart=\"function(s, e) {" +
        " Uploader_OnUploadStart(); }\"\r\n                        TextChanged=\"function(s, " +
        "e) { UpdateUploadButton(); }\"></ClientSideEvents>\r\n                    <Validati" +
        "onSettings MaxFileSize=\"20480000\">\r\n                    </ValidationSettings>\r\n " +
        "               </dx:ASPxUploadControl>\r\n                Description:\r\n          " +
        "      <dx:ASPxTextBox ID=\"mDescription\" runat=\"server\" Width=\"200px\" ClientInsta" +
        "nceName=\"txtDescription\">\r\n                </dx:ASPxTextBox>\r\n                <d" +
        "x:ASPxButton ID=\"btnUpload\" runat=\"server\" AutoPostBack=\"False\" Text=\"Upload\" Cl" +
        "ientInstanceName=\"btnUpload\"\r\n                    Width=\"100px\" ClientEnabled=\"F" +
        "alse\">\r\n                    <ClientSideEvents Click=\"function(s, e) { uploader.U" +
        "pload(); }\" />\r\n                </dx:ASPxButton>\r\n            </dx:PopupControlC" +
        "ontentControl>\r\n        </ContentCollection>\r\n    </dx:ASPxPopupControl>\r\n    <d" +
        "x:ASPxButton ID=\"btnNewDocument\" runat=\"server\" Text=\"New Document\" AutoPostBack" +
        "=\"false\">\r\n        <ClientSideEvents Click=\"function(s,e){uploadPopup.Show();}\" " +
        "/>\r\n    </dx:ASPxButton>\r\n    </p>\r\n    <dx:ASPxGridView ID=\"gvFiles\" runat=\"ser" +
        "ver\" AutoGenerateColumns=\"False\" ClientInstanceName=\"grid\"\r\n        DataSourceID" +
        "=\"FileDataSource\" KeyFieldName=\"FileGUID\">\r\n        <Columns>\r\n            <dx:G" +
        "ridViewCommandColumn VisibleIndex=\"0\">\r\n                <ClearFilterButton Visib" +
        "le=\"True\">\r\n                </ClearFilterButton>\r\n                <CustomButtons" +
        ">\r\n                    <dx:GridViewCommandColumnCustomButton ID=\"Delete\" Text=\"D" +
        "elete\"></dx:GridViewCommandColumnCustomButton>\r\n                    <dx:GridView" +
        "CommandColumnCustomButton ID=\"Download\" Text=\"Download\"></dx:GridViewCommandColu" +
        "mnCustomButton>\r\n                </CustomButtons>\r\n            </dx:GridViewComm" +
        "andColumn>\r\n            <dx:GridViewDataTextColumn FieldName=\"ProjectFileID\" Vis" +
        "ible=\"False\" \r\n                VisibleIndex=\"1\">\r\n            </dx:GridViewDataT" +
        "extColumn>\r\n            <dx:GridViewDataTextColumn FieldName=\"FileGUID\" ReadOnly" +
        "=\"True\" Visible=\"False\" \r\n                VisibleIndex=\"2\">\r\n            </dx:Gr" +
        "idViewDataTextColumn>\r\n            <dx:GridViewDataTextColumn FieldName=\"FileNam" +
        "e\" VisibleIndex=\"3\">\r\n            </dx:GridViewDataTextColumn>\r\n            <dx:" +
        "GridViewDataTextColumn FieldName=\"FileDescription\" VisibleIndex=\"4\">\r\n          " +
        "  </dx:GridViewDataTextColumn>\r\n            <dx:GridViewDataTextColumn FieldName" +
        "=\"CreatedBy\" VisibleIndex=\"8\">\r\n            </dx:GridViewDataTextColumn>\r\n      " +
        "      <dx:GridViewDataDateColumn FieldName=\"CreatedDate\" VisibleIndex=\"7\">\r\n    " +
        "        </dx:GridViewDataDateColumn>\r\n            <dx:GridViewDataTextColumn Fie" +
        "ldName=\"ModifiedBy\" VisibleIndex=\"6\">\r\n            </dx:GridViewDataTextColumn>\r" +
        "\n            <dx:GridViewDataTextColumn FieldName=\"ModifiedDate\" VisibleIndex=\"5" +
        "\">\r\n            </dx:GridViewDataTextColumn>\r\n        </Columns>\r\n\t\t<Settings Sh" +
        "owFilterRow=\"True\" ShowHeaderFilterButton=\"true\" />\r\n\t\t<ClientSideEvents CustomB" +
        "uttonClick=\"OnCustomButtonClick\" EndCallback=\"OnGridEndCallback\" />\r\n    </dx:AS" +
        "PxGridView>\r\n    <asp:EntityDataSource ID=\"FileDataSource\" runat=\"server\" \r\n    " +
        "    ConnectionString=\"name=SiteVisitMetaEntities\" \r\n        DefaultContainerName" +
        "=\"SiteVisitMetaEntities\" EnableFlattening=\"False\" \r\n        EntitySetName=\"Proje" +
        "ctFiles\">\r\n    </asp:EntityDataSource>\r\n</asp:Content>\r\n");

        
        #line default
        #line hidden
        
        #line 137 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"

    }  

    void GenerateDocumentCodeFile()
	{

        
        #line default
        #line hidden
        
        #line 142 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"
this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Syste" +
        "m.Web;\r\nusing System.Web.UI;\r\nusing System.Web.UI.WebControls;\r\nusing DevExpress" +
        ".Web.ASPxTreeList;\r\nusing System.IO;\r\nusing DevExpress.Web.Data;\r\nusing DevExpre" +
        "ss.Web.ASPxUploadControl;\r\nusing System.Collections;\r\nusing OnSite.WebUI.Models;" +
        "\r\nusing OnSite.WebUI.Classes;\r\nusing System.Web.Security;\r\nusing DevExpress.Web." +
        "ASPxClasses;\r\n\r\nnamespace OnSite.WebUI.ClientCode.Documents\r\n{\r\n    public parti" +
        "al class Default : System.Web.UI.Page\r\n    {\r\n       const string UploadDirector" +
        "y = \"~/Uploads/\";\r\n        private SiteVisitMetaEntities ctx = new SiteVisitMeta" +
        "Entities();\r\n        private string gvFilesErrorMessage = \"\";\r\n\r\n        protect" +
        "ed void Page_Load(object sender, EventArgs e)\r\n        {\r\n            gvFiles.Cu" +
        "stomButtonCallback += new DevExpress.Web.ASPxGridView.ASPxGridViewCustomButtonCa" +
        "llbackEventHandler(gvFiles_CustomButtonCallback);\r\n            gvFiles.CustomCal" +
        "lback += new DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventHandler(" +
        "gvFiles_CustomCallback);\r\n            gvFiles.CustomJSProperties += new DevExpre" +
        "ss.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventHandler(gvFiles_CustomJSP" +
        "roperties);\r\n        }\r\n\r\n        protected void gvFiles_CustomJSProperties(obje" +
        "ct sender, DevExpress.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventArgs e" +
        ")\r\n        {\r\n            e.Properties.Add(\"cpErrorMessage\", gvFilesErrorMessage" +
        ");\r\n        }\r\n\r\n        protected void gvFiles_CustomCallback(object sender, De" +
        "vExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)\r\n        {\r\n   " +
        "         if (e.Parameters.Length > 0)\r\n            {\r\n                string[] p" +
        "arameters = e.Parameters.Split(new char[]{\'|\'});\r\n                string filenam" +
        "e = parameters[0];\r\n                string description = parameters[1];\r\n\r\n\t\t\t\ti" +
        "f (filename.Contains(\"\\\\\"))\r\n                {\r\n                    //get the fi" +
        "lename by itself\r\n                    int l = filename.LastIndexOf(\"\\\\\")+1;\r\n   " +
        "                 filename = filename.Substring(l, filename.Length - l);\r\n       " +
        "         }\r\n\r\n                var file = (from f in ctx.ProjectFiles\r\n          " +
        "                  where f.FileName == filename\r\n                            sele" +
        "ct f).FirstOrDefault();\r\n                if (file != null)\r\n                {\r\n " +
        "                   file.FileDescription = description;\r\n                    ctx." +
        "SaveChanges();\r\n\r\n                    string fileLength = file.FileContents.Leng" +
        "th / 1024 + \"kb\";\r\n                    gvFilesErrorMessage = string.Format(\"Succ" +
        "essfully uploaded {0} ({1}).\", file.FileName, fileLength);                    \r\n" +
        "                }\r\n            }\r\n            gvFiles.DataBind();\r\n        }\r\n\r\n" +
        "        protected void gvFiles_CustomButtonCallback(object sender, DevExpress.We" +
        "b.ASPxGridView.ASPxGridViewCustomButtonCallbackEventArgs e)\r\n        {\r\n        " +
        "    try\r\n            {\r\n                if (e.ButtonID == \"Download\")\r\n         " +
        "       {\r\n                    if (PermissionHelper.Documents.CanDownload())\r\n   " +
        "                 {\r\n                        string fileguid = gvFiles.GetRowValu" +
        "es(e.VisibleIndex, \"FileGUID\").ToString();\r\n                        ASPxWebContr" +
        "ol.RedirectOnCallback(\"GetFile.aspx?f=\" + fileguid);\r\n                    }\r\n   " +
        "                 else\r\n                    {\r\n                        throw new " +
        "Exception(PermissionHelper.Documents.DownloadDeniedMessage);\r\n                  " +
        "  }\r\n                }\r\n                else\r\n                {\r\n               " +
        "     Guid fileguid = (Guid)gvFiles.GetRowValues(e.VisibleIndex, \"FileGUID\");\r\n  " +
        "                  ProjectFile file = (from f in ctx.ProjectFiles\r\n              " +
        "                          where f.FileGUID == fileguid\r\n                        " +
        "                select f).FirstOrDefault();\r\n                    if (file != nul" +
        "l)\r\n                    {\r\n                        if (PermissionHelper.Document" +
        "s.CanDelete(file.CreatedBy))\r\n                        {\r\n                       " +
        "     ctx.ProjectFiles.DeleteObject(file);\r\n                            ctx.SaveC" +
        "hanges();\r\n                        }\r\n                        else\r\n            " +
        "            {\r\n                            throw new Exception(PermissionHelper." +
        "Documents.DeleteDeniedMessage);\r\n                        }\r\n                    " +
        "}\r\n                }\r\n            }\r\n            catch (Exception ex)\r\n         " +
        "   {\r\n                gvFilesErrorMessage = ex.Message;\r\n                \r\n     " +
        "       }\r\n            gvFiles.DataBind();\r\n        }\r\n\r\n        protected void u" +
        "ploader_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)\r\n      " +
        "  {\r\n            e.CallbackData = SavePostedFile(e.UploadedFile);\r\n        }\r\n\r\n" +
        "        protected string SavePostedFile(UploadedFile uploadedFile)\r\n        {\r\n " +
        "           if (!uploadedFile.IsValid)\r\n                return string.Empty;\r\n\r\n\r" +
        "\n            var file = (from f in ctx.ProjectFiles\r\n                        whe" +
        "re f.FileName == uploadedFile.FileName\r\n                        select f).FirstO" +
        "rDefault();\r\n            string returnMessage = \"\";\r\n\r\n            try\r\n        " +
        "    {\r\n                if (file == null)\r\n                {\r\n                   " +
        " if (PermissionHelper.Documents.CanUpload())\r\n                    {\r\n\r\n         " +
        "               //TODO: come up with a better way to select projectID (actually b" +
        "etter way to deal with projects.!)\r\n                        int projectID = (fro" +
        "m p in ctx.Projects\r\n                                         select p.ProjectID" +
        ").FirstOrDefault();\r\n\r\n                        ProjectFile newFile = new Project" +
        "File();\r\n                        newFile.ProjectID = projectID;\r\n               " +
        "         newFile.FileGUID = Guid.NewGuid();\r\n                        newFile.Fil" +
        "eContents = ReadFully(uploadedFile.FileContent); //System.IO.File.ReadAllBytes(r" +
        "esFileName);\r\n                        newFile.FileName = uploadedFile.FileName;\r" +
        "\n                        newFile.FileType = uploadedFile.ContentType;\r\n         " +
        "               string currentuser = Membership.GetUser().UserName;\r\n            " +
        "            newFile.CreatedBy = currentuser;\r\n                        newFile.Mo" +
        "difiedBy = currentuser;\r\n                        newFile.CreatedDate = DateTime." +
        "Now;\r\n                        newFile.ModifiedDate = DateTime.Now;\r\n            " +
        "            ctx.AddObject(\"ProjectFiles\", newFile);\r\n                        ctx" +
        ".SaveChanges();\r\n                    }\r\n                    else\r\n              " +
        "      {\r\n                        throw new Exception(PermissionHelper.Documents." +
        "UploadDeniedMessage);\r\n                    }\r\n                }\r\n               " +
        " else\r\n                {\r\n                    if (PermissionHelper.Documents.Can" +
        "Overwrite(file.CreatedBy))\r\n                    {\r\n                        //sav" +
        "e file contents over the top of the existing file\r\n                        file." +
        "FileContents = ReadFully(uploadedFile.FileContent);\r\n                        fil" +
        "e.FileType = uploadedFile.ContentType;\r\n                        file.ModifiedBy " +
        "= Membership.GetUser().UserName;\r\n                        file.ModifiedDate = Da" +
        "teTime.Now;\r\n                        ctx.SaveChanges();\r\n                    }\r\n" +
        "                    else\r\n                    {\r\n                        throw n" +
        "ew Exception(PermissionHelper.Documents.OverwriteDeniedMessage);\r\n              " +
        "      }\r\n                }\r\n            }\r\n            catch (Exception ex)\r\n   " +
        "         {\r\n                returnMessage = ex.Message;\r\n            }\r\n\r\n      " +
        "      return returnMessage;\r\n        }\r\n\r\n        public byte[] ReadFully(Stream" +
        " input)\r\n        {\r\n            byte[] buffer = new byte[input.Length];\r\n       " +
        "     //byte[] buffer = new byte[16 * 1024];\r\n            using (MemoryStream ms " +
        "= new MemoryStream())\r\n            {\r\n                int read;\r\n               " +
        " while ((read = input.Read(buffer, 0, buffer.Length)) > 0)\r\n                {\r\n " +
        "                   ms.Write(buffer, 0, read);\r\n                }\r\n              " +
        "  return ms.ToArray();\r\n            }\r\n        }\r\n    }\r\n}\r\n");

        
        #line default
        #line hidden
        
        #line 340 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"

    }

	void GenerateDocumentDesignerFile()
	{

        
        #line default
        #line hidden
        
        #line 345 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"
this.Write("//------------------------------------------------------------------------------\r" +
        "\n// <auto-generated>\r\n//     This code was generated by a tool.\r\n//\r\n//     Chan" +
        "ges to this file may cause incorrect behavior and will be lost if\r\n//     the co" +
        "de is regenerated. \r\n// </auto-generated>\r\n//-----------------------------------" +
        "-------------------------------------------\r\n\r\nnamespace OnSite.WebUI.ClientCode" +
        ".Documents {\r\n    \r\n    \r\n    public partial class Default {\r\n\t\t/// <summary>\r\n " +
        "       /// pcUpload control.\r\n        /// </summary>\r\n        /// <remarks>\r\n   " +
        "     /// Auto-generated field.\r\n        /// To modify move field declaration fro" +
        "m designer file to code-behind file.\r\n        /// </remarks>\r\n        protected " +
        "global::DevExpress.Web.ASPxPopupControl.ASPxPopupControl pcUpload;\r\n        \r\n  " +
        "      /// <summary>\r\n        /// uplFile control.\r\n        /// </summary>\r\n     " +
        "   /// <remarks>\r\n        /// Auto-generated field.\r\n        /// To modify move " +
        "field declaration from designer file to code-behind file.\r\n        /// </remarks" +
        ">\r\n        protected global::DevExpress.Web.ASPxUploadControl.ASPxUploadControl " +
        "uplFile;\r\n        \r\n        /// <summary>\r\n        /// mDescription control.\r\n  " +
        "      /// </summary>\r\n        /// <remarks>\r\n        /// Auto-generated field.\r\n" +
        "        /// To modify move field declaration from designer file to code-behind f" +
        "ile.\r\n        /// </remarks>\r\n        protected global::DevExpress.Web.ASPxEdito" +
        "rs.ASPxTextBox mDescription;\r\n        \r\n        /// <summary>\r\n        /// btnUp" +
        "load control.\r\n        /// </summary>\r\n        /// <remarks>\r\n        /// Auto-g" +
        "enerated field.\r\n        /// To modify move field declaration from designer file" +
        " to code-behind file.\r\n        /// </remarks>\r\n        protected global::DevExpr" +
        "ess.Web.ASPxEditors.ASPxButton btnUpload;\r\n        \r\n        /// <summary>\r\n    " +
        "    /// btnNewDocument control.\r\n        /// </summary>\r\n        /// <remarks>\r\n" +
        "        /// Auto-generated field.\r\n        /// To modify move field declaration " +
        "from designer file to code-behind file.\r\n        /// </remarks>\r\n        protect" +
        "ed global::DevExpress.Web.ASPxEditors.ASPxButton btnNewDocument;\r\n        \r\n    " +
        "    /// <summary>\r\n        /// gvFiles control.\r\n        /// </summary>\r\n       " +
        " /// <remarks>\r\n        /// Auto-generated field.\r\n        /// To modify move fi" +
        "eld declaration from designer file to code-behind file.\r\n        /// </remarks>\r" +
        "\n        protected global::DevExpress.Web.ASPxGridView.ASPxGridView gvFiles;\r\n  " +
        "      \r\n        /// <summary>\r\n        /// Delete control.\r\n        /// </summar" +
        "y>\r\n        /// <remarks>\r\n        /// Auto-generated field.\r\n        /// To mod" +
        "ify move field declaration from designer file to code-behind file.\r\n        /// " +
        "</remarks>\r\n        protected global::DevExpress.Web.ASPxGridView.GridViewComman" +
        "dColumnCustomButton Delete;\r\n        \r\n        /// <summary>\r\n        /// Downlo" +
        "ad control.\r\n        /// </summary>\r\n        /// <remarks>\r\n        /// Auto-gen" +
        "erated field.\r\n        /// To modify move field declaration from designer file t" +
        "o code-behind file.\r\n        /// </remarks>\r\n        protected global::DevExpres" +
        "s.Web.ASPxGridView.GridViewCommandColumnCustomButton Download;\r\n        \r\n      " +
        "  /// <summary>\r\n        /// FileDataSource control.\r\n        /// </summary>\r\n  " +
        "      /// <remarks>\r\n        /// Auto-generated field.\r\n        /// To modify mo" +
        "ve field declaration from designer file to code-behind file.\r\n        /// </rema" +
        "rks>\r\n        protected global::System.Web.UI.WebControls.EntityDataSource FileD" +
        "ataSource;\r\n\t}\r\n}\r\n");

        
        #line default
        #line hidden
        
        #line 441 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"

	}
	void GenerateGetFilePage()
	{

        
        #line default
        #line hidden
        
        #line 445 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"
this.Write(@"<%@ Page Language=""C#"" AutoEventWireup=""true"" CodeBehind=""GetFile.aspx.cs"" Inherits=""OnSite.WebUI.ClientCode.Documents.GetFile"" %>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head runat=""server"">
    <title></title>
</head>
<body>
    <form id=""form1"" runat=""server"">
    <div>
		No Data
    </div>
    </form>
</body>
</html>
");

        
        #line default
        #line hidden
        
        #line 460 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"

    }  

    void GenerateGetFileCodeFile()
	{

        
        #line default
        #line hidden
        
        #line 465 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"
this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Syste" +
        "m.Web;\r\nusing System.Web.UI;\r\nusing System.Web.UI.WebControls;\r\nusing OnSite.Web" +
        "UI.Models;\r\nusing System.IO;\r\n\r\nnamespace OnSite.WebUI.ClientCode.Documents\r\n{\r\n" +
        "    public partial class GetFile : System.Web.UI.Page\r\n    {\r\n        SiteVisitM" +
        "etaEntities ctx = new SiteVisitMetaEntities();\r\n\r\n        protected void Page_Lo" +
        "ad(object sender, EventArgs e)\r\n        {\r\n            Guid fileguid;\r\n         " +
        "   Guid.TryParse(Request.Params[0], out fileguid);\r\n            \r\n            Pr" +
        "ojectFile file = (from f in ctx.ProjectFiles\r\n                                wh" +
        "ere f.FileGUID == fileguid\r\n                                select f).FirstOrDef" +
        "ault();\r\n            if (file != null)\r\n            {\r\n                using (St" +
        "ream st = new MemoryStream(file.FileContents))\r\n                {\r\n             " +
        "       long dataLengthToRead = st.Length;\r\n                    Response.ContentT" +
        "ype = file.FileType;\r\n                    Response.AddHeader(\"Content-Dispositio" +
        "n\", \"attachment; filename=\\\"\" + file.FileName + \"\\\"\");\r\n                    byte" +
        "[] buffer = new byte[1024];\r\n                    int blockSize = 100;\r\n\r\n       " +
        "             while (dataLengthToRead > 0 && Response.IsClientConnected)\r\n       " +
        "             {\r\n                        Int32 lengthRead = st.Read(buffer, 0, bl" +
        "ockSize);\r\n                        Response.OutputStream.Write(buffer, 0, length" +
        "Read);\r\n                        Response.Flush();\r\n                        dataL" +
        "engthToRead = dataLengthToRead - lengthRead;\r\n                    }\r\n           " +
        "         Response.Flush();\r\n                    Response.Close();\r\n             " +
        "   }\r\n                Response.End();\r\n            }\r\n        }\r\n    }\r\n}\r\n");

        
        #line default
        #line hidden
        
        #line 514 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"

    }

	void GenerateGetFileDesignerFile()
	{

        
        #line default
        #line hidden
        
        #line 519 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"
this.Write(@"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated. 
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnSite.WebUI.ClientCode.Documents {   
    
    public partial class Default {
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
        
        #line 542 "C:\Apps\On-Site\Admin\OnSite.TemplateWizard\T4\DocumentsTemplate.tt"

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
    public class DocumentsTemplateBase
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
