using System.Configuration;
namespace OnSite.TemplateWizard
{
    partial class Wizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tbBasePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLogOutput = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCleanup = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbWebUIPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(80, 89);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tbBasePath
            // 
            this.tbBasePath.Location = new System.Drawing.Point(80, 41);
            this.tbBasePath.Name = "tbBasePath";
            this.tbBasePath.Size = new System.Drawing.Size(257, 20);
            this.tbBasePath.TabIndex = 1;
            this.tbBasePath.Text = ConfigurationManager.AppSettings["BasePath"].ToString();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Base Path:";
            // 
            // tbLogOutput
            // 
            this.tbLogOutput.Location = new System.Drawing.Point(16, 144);
            this.tbLogOutput.Name = "tbLogOutput";
            this.tbLogOutput.Size = new System.Drawing.Size(320, 161);
            this.tbLogOutput.TabIndex = 3;
            this.tbLogOutput.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Log:";
            // 
            // btnCleanup
            // 
            this.btnCleanup.Location = new System.Drawing.Point(171, 89);
            this.btnCleanup.Name = "btnCleanup";
            this.btnCleanup.Size = new System.Drawing.Size(75, 23);
            this.btnCleanup.TabIndex = 5;
            this.btnCleanup.Text = "Clean Up Folders";
            this.btnCleanup.UseVisualStyleBackColor = true;
            this.btnCleanup.Click += new System.EventHandler(this.btnCleanup_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(80, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(257, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Client:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "WebUI Path:";
            // 
            // tbWebUIPath
            // 
            this.tbWebUIPath.Location = new System.Drawing.Point(80, 63);
            this.tbWebUIPath.Name = "tbWebUIPath";
            this.tbWebUIPath.Size = new System.Drawing.Size(256, 20);
            this.tbWebUIPath.TabIndex = 9;
            this.tbWebUIPath.Text = "On-Site\\OnSite.WebUI\\";
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 321);
            this.Controls.Add(this.tbWebUIPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnCleanup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLogOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbBasePath);
            this.Controls.Add(this.btnGenerate);
            this.Name = "Wizard";
            this.Text = "Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox tbBasePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox tbLogOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCleanup;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbWebUIPath;
    }
}