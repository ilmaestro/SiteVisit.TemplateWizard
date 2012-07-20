using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OnSite.TemplateWizard.Classes;
using OnSite.TemplateWizard.Models;

namespace OnSite.TemplateWizard
{
    public partial class Wizard : Form
    {
        SiteVisitMetaEntities ctx = new SiteVisitMetaEntities();

        public Wizard()
        {
            InitializeComponent();
            comboBox1.DataSource = ctx.Clients;
            comboBox1.ValueMember = "ClientID";
            comboBox1.DisplayMember = "ClientName";
            
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Client client = (Client)comboBox1.SelectedItem;
            string outputpath = Path.Combine(tbBasePath.Text, tbWebUIPath.Text);
            SiteVisitTemplateProcessor processor = new SiteVisitTemplateProcessor(outputpath);
            tbLogOutput.Text += "Beginning processing...";
            processor.ProcessTemplates(client.ClientID);
            tbLogOutput.Text += "processing complete!\n";
        }

        private void btnCleanup_Click(object sender, EventArgs e)
        {
            string outputpath = Path.Combine(tbBasePath.Text, tbWebUIPath.Text);
            SiteVisitTemplateProcessor processor = new SiteVisitTemplateProcessor(outputpath);
            tbLogOutput.Text += "Beginning cleanup...";
            processor.CleanUpFolders();
            tbLogOutput.Text += "cleanup complete!\n";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client client = (Client)comboBox1.SelectedItem;
            tbWebUIPath.Text = "On-Site." + client.ClientName + "\\OnSite.WebUI";
        }
    }
}
