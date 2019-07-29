namespace GitAppLocalCore.Forms
{
    partial class MainForm
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
            this.RepoPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FetchButtonTemplate = new System.Windows.Forms.Button();
            this.SyncButtonTemplate = new System.Windows.Forms.Button();
            this.PublishButtonTemplate = new System.Windows.Forms.Button();
            this.DBDeployButtonTemplate = new System.Windows.Forms.Button();
            this.DeployLogsButtonTemplate = new System.Windows.Forms.Button();
            this.LocalPathLabelTemplate = new System.Windows.Forms.Label();
            this.BranchLabelTemplate = new System.Windows.Forms.Label();
            this.StatusLabelTemplate = new System.Windows.Forms.Label();
            this.FetchAllButton = new System.Windows.Forms.Button();
            this.SyncAllButton = new System.Windows.Forms.Button();
            this.DeployAllButton = new System.Windows.Forms.Button();
            this.WebJobPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.StartButtonTemplate = new System.Windows.Forms.Button();
            this.KillWebJobButtonTemplate = new System.Windows.Forms.Button();
            this.WebJobLogsTemplate = new System.Windows.Forms.Button();
            this.WebJobStatusTemplate = new System.Windows.Forms.Label();
            this.WebJobNameTempate = new System.Windows.Forms.Label();
            this.StartAllWebJobs = new System.Windows.Forms.Button();
            this.KillAllWebJobs = new System.Windows.Forms.Button();
            this.DBDeployAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AzureEmulatorStart = new System.Windows.Forms.Button();
            this.AzureEmulatorStop = new System.Windows.Forms.Button();
            this.AzureEmulatorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchJobsButton = new System.Windows.Forms.Button();
            this.RepoPanel.SuspendLayout();
            this.WebJobPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RepoPanel
            // 
            this.RepoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RepoPanel.Controls.Add(this.FetchButtonTemplate);
            this.RepoPanel.Controls.Add(this.SyncButtonTemplate);
            this.RepoPanel.Controls.Add(this.PublishButtonTemplate);
            this.RepoPanel.Controls.Add(this.DBDeployButtonTemplate);
            this.RepoPanel.Controls.Add(this.DeployLogsButtonTemplate);
            this.RepoPanel.Controls.Add(this.LocalPathLabelTemplate);
            this.RepoPanel.Controls.Add(this.BranchLabelTemplate);
            this.RepoPanel.Controls.Add(this.StatusLabelTemplate);
            this.RepoPanel.Location = new System.Drawing.Point(16, 52);
            this.RepoPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RepoPanel.Name = "RepoPanel";
            this.RepoPanel.Size = new System.Drawing.Size(1057, 964);
            this.RepoPanel.TabIndex = 5;
            // 
            // FetchButtonTemplate
            // 
            this.FetchButtonTemplate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FetchButtonTemplate.Location = new System.Drawing.Point(4, 4);
            this.FetchButtonTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FetchButtonTemplate.Name = "FetchButtonTemplate";
            this.FetchButtonTemplate.Size = new System.Drawing.Size(76, 28);
            this.FetchButtonTemplate.TabIndex = 5;
            this.FetchButtonTemplate.Text = "Fetch";
            this.FetchButtonTemplate.UseVisualStyleBackColor = false;
            // 
            // SyncButtonTemplate
            // 
            this.SyncButtonTemplate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SyncButtonTemplate.Location = new System.Drawing.Point(88, 4);
            this.SyncButtonTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SyncButtonTemplate.Name = "SyncButtonTemplate";
            this.SyncButtonTemplate.Size = new System.Drawing.Size(73, 28);
            this.SyncButtonTemplate.TabIndex = 0;
            this.SyncButtonTemplate.Text = "Pull";
            this.SyncButtonTemplate.UseVisualStyleBackColor = false;
            // 
            // PublishButtonTemplate
            // 
            this.PublishButtonTemplate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PublishButtonTemplate.Enabled = false;
            this.PublishButtonTemplate.Location = new System.Drawing.Point(169, 4);
            this.PublishButtonTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PublishButtonTemplate.Name = "PublishButtonTemplate";
            this.PublishButtonTemplate.Size = new System.Drawing.Size(84, 28);
            this.PublishButtonTemplate.TabIndex = 4;
            this.PublishButtonTemplate.Text = "Publish";
            this.PublishButtonTemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PublishButtonTemplate.UseVisualStyleBackColor = false;
            // 
            // DBDeployButtonTemplate
            // 
            this.DBDeployButtonTemplate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DBDeployButtonTemplate.Enabled = false;
            this.DBDeployButtonTemplate.Location = new System.Drawing.Point(261, 4);
            this.DBDeployButtonTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DBDeployButtonTemplate.Name = "DBDeployButtonTemplate";
            this.DBDeployButtonTemplate.Size = new System.Drawing.Size(96, 28);
            this.DBDeployButtonTemplate.TabIndex = 6;
            this.DBDeployButtonTemplate.Text = "DB Publish";
            this.DBDeployButtonTemplate.UseVisualStyleBackColor = false;
            // 
            // DeployLogsButtonTemplate
            // 
            this.DeployLogsButtonTemplate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DeployLogsButtonTemplate.Enabled = false;
            this.DeployLogsButtonTemplate.Location = new System.Drawing.Point(365, 4);
            this.DeployLogsButtonTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeployLogsButtonTemplate.Name = "DeployLogsButtonTemplate";
            this.DeployLogsButtonTemplate.Size = new System.Drawing.Size(84, 28);
            this.DeployLogsButtonTemplate.TabIndex = 7;
            this.DeployLogsButtonTemplate.Text = "Logs";
            this.DeployLogsButtonTemplate.UseVisualStyleBackColor = false;
            // 
            // LocalPathLabelTemplate
            // 
            this.LocalPathLabelTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalPathLabelTemplate.Location = new System.Drawing.Point(457, 4);
            this.LocalPathLabelTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LocalPathLabelTemplate.Name = "LocalPathLabelTemplate";
            this.LocalPathLabelTemplate.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.LocalPathLabelTemplate.Size = new System.Drawing.Size(195, 28);
            this.LocalPathLabelTemplate.TabIndex = 2;
            this.LocalPathLabelTemplate.Text = "Kund";
            // 
            // BranchLabelTemplate
            // 
            this.BranchLabelTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchLabelTemplate.Location = new System.Drawing.Point(660, 4);
            this.BranchLabelTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BranchLabelTemplate.Name = "BranchLabelTemplate";
            this.BranchLabelTemplate.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.BranchLabelTemplate.Size = new System.Drawing.Size(240, 28);
            this.BranchLabelTemplate.TabIndex = 3;
            this.BranchLabelTemplate.Text = "Not initialized";
            // 
            // StatusLabelTemplate
            // 
            this.StatusLabelTemplate.BackColor = System.Drawing.SystemColors.Control;
            this.StatusLabelTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabelTemplate.Location = new System.Drawing.Point(908, 4);
            this.StatusLabelTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StatusLabelTemplate.Name = "StatusLabelTemplate";
            this.StatusLabelTemplate.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.StatusLabelTemplate.Size = new System.Drawing.Size(140, 28);
            this.StatusLabelTemplate.TabIndex = 1;
            this.StatusLabelTemplate.Text = "Unknown";
            // 
            // FetchAllButton
            // 
            this.FetchAllButton.Location = new System.Drawing.Point(21, 16);
            this.FetchAllButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FetchAllButton.Name = "FetchAllButton";
            this.FetchAllButton.Size = new System.Drawing.Size(76, 28);
            this.FetchAllButton.TabIndex = 1;
            this.FetchAllButton.Text = "Fetch All";
            this.FetchAllButton.UseVisualStyleBackColor = true;
            this.FetchAllButton.Click += new System.EventHandler(this.FetchAllButton_Click);
            // 
            // SyncAllButton
            // 
            this.SyncAllButton.Location = new System.Drawing.Point(105, 16);
            this.SyncAllButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SyncAllButton.Name = "SyncAllButton";
            this.SyncAllButton.Size = new System.Drawing.Size(73, 28);
            this.SyncAllButton.TabIndex = 2;
            this.SyncAllButton.Text = "Pull All";
            this.SyncAllButton.UseVisualStyleBackColor = true;
            this.SyncAllButton.Click += new System.EventHandler(this.SyncAllButton_Click);
            // 
            // DeployAllButton
            // 
            this.DeployAllButton.Enabled = false;
            this.DeployAllButton.Location = new System.Drawing.Point(187, 16);
            this.DeployAllButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeployAllButton.Name = "DeployAllButton";
            this.DeployAllButton.Size = new System.Drawing.Size(84, 28);
            this.DeployAllButton.TabIndex = 3;
            this.DeployAllButton.Text = "Publish All";
            this.DeployAllButton.UseVisualStyleBackColor = true;
            this.DeployAllButton.Click += new System.EventHandler(this.DeployAllButton_Click);
            // 
            // WebJobPanel
            // 
            this.WebJobPanel.AutoScroll = true;
            this.WebJobPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WebJobPanel.Controls.Add(this.StartButtonTemplate);
            this.WebJobPanel.Controls.Add(this.KillWebJobButtonTemplate);
            this.WebJobPanel.Controls.Add(this.WebJobLogsTemplate);
            this.WebJobPanel.Controls.Add(this.WebJobStatusTemplate);
            this.WebJobPanel.Controls.Add(this.WebJobNameTempate);
            this.WebJobPanel.Location = new System.Drawing.Point(1081, 52);
            this.WebJobPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WebJobPanel.Name = "WebJobPanel";
            this.WebJobPanel.Size = new System.Drawing.Size(721, 964);
            this.WebJobPanel.TabIndex = 6;
            // 
            // StartButtonTemplate
            // 
            this.StartButtonTemplate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.StartButtonTemplate.Enabled = false;
            this.StartButtonTemplate.Location = new System.Drawing.Point(4, 4);
            this.StartButtonTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartButtonTemplate.Name = "StartButtonTemplate";
            this.StartButtonTemplate.Size = new System.Drawing.Size(76, 28);
            this.StartButtonTemplate.TabIndex = 6;
            this.StartButtonTemplate.Text = "Run";
            this.StartButtonTemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.StartButtonTemplate.UseVisualStyleBackColor = false;
            // 
            // KillWebJobButtonTemplate
            // 
            this.KillWebJobButtonTemplate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.KillWebJobButtonTemplate.Enabled = false;
            this.KillWebJobButtonTemplate.Location = new System.Drawing.Point(88, 4);
            this.KillWebJobButtonTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KillWebJobButtonTemplate.Name = "KillWebJobButtonTemplate";
            this.KillWebJobButtonTemplate.Size = new System.Drawing.Size(76, 28);
            this.KillWebJobButtonTemplate.TabIndex = 7;
            this.KillWebJobButtonTemplate.Text = "Kill";
            this.KillWebJobButtonTemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.KillWebJobButtonTemplate.UseVisualStyleBackColor = false;
            // 
            // WebJobLogsTemplate
            // 
            this.WebJobLogsTemplate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.WebJobLogsTemplate.Enabled = false;
            this.WebJobLogsTemplate.Location = new System.Drawing.Point(172, 4);
            this.WebJobLogsTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WebJobLogsTemplate.Name = "WebJobLogsTemplate";
            this.WebJobLogsTemplate.Size = new System.Drawing.Size(76, 28);
            this.WebJobLogsTemplate.TabIndex = 8;
            this.WebJobLogsTemplate.Text = "Logs";
            this.WebJobLogsTemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.WebJobLogsTemplate.UseVisualStyleBackColor = false;
            // 
            // WebJobStatusTemplate
            // 
            this.WebJobStatusTemplate.BackColor = System.Drawing.Color.LightPink;
            this.WebJobStatusTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebJobStatusTemplate.Location = new System.Drawing.Point(256, 4);
            this.WebJobStatusTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WebJobStatusTemplate.Name = "WebJobStatusTemplate";
            this.WebJobStatusTemplate.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.WebJobStatusTemplate.Size = new System.Drawing.Size(96, 28);
            this.WebJobStatusTemplate.TabIndex = 6;
            this.WebJobStatusTemplate.Text = "Halted";
            // 
            // WebJobNameTempate
            // 
            this.WebJobNameTempate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebJobNameTempate.Location = new System.Drawing.Point(360, 4);
            this.WebJobNameTempate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WebJobNameTempate.Name = "WebJobNameTempate";
            this.WebJobNameTempate.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.WebJobNameTempate.Size = new System.Drawing.Size(332, 28);
            this.WebJobNameTempate.TabIndex = 6;
            this.WebJobNameTempate.Text = "Kund.Notify.Webjob";
            // 
            // StartAllWebJobs
            // 
            this.StartAllWebJobs.Enabled = false;
            this.StartAllWebJobs.Location = new System.Drawing.Point(1087, 16);
            this.StartAllWebJobs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartAllWebJobs.Name = "StartAllWebJobs";
            this.StartAllWebJobs.Size = new System.Drawing.Size(76, 28);
            this.StartAllWebJobs.TabIndex = 7;
            this.StartAllWebJobs.Text = "Run All";
            this.StartAllWebJobs.UseVisualStyleBackColor = true;
            this.StartAllWebJobs.Click += new System.EventHandler(this.StartAllWebJobs_Click);
            // 
            // KillAllWebJobs
            // 
            this.KillAllWebJobs.Enabled = false;
            this.KillAllWebJobs.Location = new System.Drawing.Point(1171, 16);
            this.KillAllWebJobs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KillAllWebJobs.Name = "KillAllWebJobs";
            this.KillAllWebJobs.Size = new System.Drawing.Size(76, 28);
            this.KillAllWebJobs.TabIndex = 8;
            this.KillAllWebJobs.Text = "Kill All";
            this.KillAllWebJobs.UseVisualStyleBackColor = true;
            this.KillAllWebJobs.Click += new System.EventHandler(this.StopAllWebJobs_Click);
            // 
            // DBDeployAll
            // 
            this.DBDeployAll.Enabled = false;
            this.DBDeployAll.Location = new System.Drawing.Point(279, 16);
            this.DBDeployAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DBDeployAll.Name = "DBDeployAll";
            this.DBDeployAll.Size = new System.Drawing.Size(96, 28);
            this.DBDeployAll.TabIndex = 9;
            this.DBDeployAll.Text = "DB Pub All";
            this.DBDeployAll.UseVisualStyleBackColor = true;
            this.DBDeployAll.Click += new System.EventHandler(this.DBDeployAll_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.AzureEmulatorStart);
            this.panel1.Controls.Add(this.AzureEmulatorStop);
            this.panel1.Controls.Add(this.AzureEmulatorLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(1393, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 45);
            this.panel1.TabIndex = 10;
            // 
            // AzureEmulatorStart
            // 
            this.AzureEmulatorStart.Location = new System.Drawing.Point(137, 7);
            this.AzureEmulatorStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AzureEmulatorStart.Name = "AzureEmulatorStart";
            this.AzureEmulatorStart.Size = new System.Drawing.Size(76, 28);
            this.AzureEmulatorStart.TabIndex = 9;
            this.AzureEmulatorStart.Text = "Start";
            this.AzureEmulatorStart.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.AzureEmulatorStart.UseVisualStyleBackColor = true;
            this.AzureEmulatorStart.Click += new System.EventHandler(this.AzureEmulatorStart_Click);
            // 
            // AzureEmulatorStop
            // 
            this.AzureEmulatorStop.Location = new System.Drawing.Point(221, 7);
            this.AzureEmulatorStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AzureEmulatorStop.Name = "AzureEmulatorStop";
            this.AzureEmulatorStop.Size = new System.Drawing.Size(76, 28);
            this.AzureEmulatorStop.TabIndex = 9;
            this.AzureEmulatorStop.Text = "Stop";
            this.AzureEmulatorStop.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.AzureEmulatorStop.UseVisualStyleBackColor = true;
            this.AzureEmulatorStop.Click += new System.EventHandler(this.AzureEmulatorStop_Click);
            // 
            // AzureEmulatorLabel
            // 
            this.AzureEmulatorLabel.BackColor = System.Drawing.Color.LightPink;
            this.AzureEmulatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AzureEmulatorLabel.Location = new System.Drawing.Point(305, 7);
            this.AzureEmulatorLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AzureEmulatorLabel.Name = "AzureEmulatorLabel";
            this.AzureEmulatorLabel.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.AzureEmulatorLabel.Size = new System.Drawing.Size(96, 28);
            this.AzureEmulatorLabel.TabIndex = 9;
            this.AzureEmulatorLabel.Text = "Halted";
            this.AzureEmulatorLabel.Click += new System.EventHandler(this.AzureEmulatorLabel_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.label2.Size = new System.Drawing.Size(125, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "Azure Emulator";
            // 
            // SearchJobsButton
            // 
            this.SearchJobsButton.Enabled = false;
            this.SearchJobsButton.Location = new System.Drawing.Point(1255, 16);
            this.SearchJobsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchJobsButton.Name = "SearchJobsButton";
            this.SearchJobsButton.Size = new System.Drawing.Size(109, 28);
            this.SearchJobsButton.TabIndex = 11;
            this.SearchJobsButton.Text = "Search Jobs";
            this.SearchJobsButton.UseVisualStyleBackColor = true;
            this.SearchJobsButton.Click += new System.EventHandler(this.SearchJobsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1819, 1031);
            this.Controls.Add(this.SearchJobsButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DBDeployAll);
            this.Controls.Add(this.KillAllWebJobs);
            this.Controls.Add(this.StartAllWebJobs);
            this.Controls.Add(this.WebJobPanel);
            this.Controls.Add(this.DeployAllButton);
            this.Controls.Add(this.SyncAllButton);
            this.Controls.Add(this.FetchAllButton);
            this.Controls.Add(this.RepoPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GitAppLocalCore";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.RepoPanel.ResumeLayout(false);
            this.WebJobPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel RepoPanel;
        private System.Windows.Forms.Button SyncButtonTemplate;
        private System.Windows.Forms.Label StatusLabelTemplate;
        private System.Windows.Forms.Label LocalPathLabelTemplate;
        private System.Windows.Forms.Button PublishButtonTemplate;
        private System.Windows.Forms.Label BranchLabelTemplate;
        private System.Windows.Forms.Button FetchButtonTemplate;
        private System.Windows.Forms.Button FetchAllButton;
        private System.Windows.Forms.Button SyncAllButton;
        private System.Windows.Forms.Button DeployAllButton;
        private System.Windows.Forms.FlowLayoutPanel WebJobPanel;
        private System.Windows.Forms.Button StartButtonTemplate;
        private System.Windows.Forms.Button KillWebJobButtonTemplate;
        private System.Windows.Forms.Label WebJobStatusTemplate;
        private System.Windows.Forms.Label WebJobNameTempate;
        private System.Windows.Forms.Button StartAllWebJobs;
        private System.Windows.Forms.Button KillAllWebJobs;
        private System.Windows.Forms.Button WebJobLogsTemplate;
        private System.Windows.Forms.Button DBDeployButtonTemplate;
        private System.Windows.Forms.Button DeployLogsButtonTemplate;
        private System.Windows.Forms.Button DBDeployAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AzureEmulatorStart;
        private System.Windows.Forms.Button AzureEmulatorStop;
        private System.Windows.Forms.Label AzureEmulatorLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SearchJobsButton;
    }
}