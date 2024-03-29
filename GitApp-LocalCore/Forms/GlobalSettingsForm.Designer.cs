﻿namespace GitAppLocalCore.Forms
{
    partial class GlobalSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.GitPath = new System.Windows.Forms.TextBox();
            this.AzureStorageEmulatorPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WwwRootPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OtherRootPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.MsBuild = new System.Windows.Forms.TextBox();
            this.LogViewer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ProxyRootPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CoreRootPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "GitPath";
            // 
            // GitPath
            // 
            this.GitPath.BackColor = System.Drawing.SystemColors.Window;
            this.GitPath.Location = new System.Drawing.Point(152, 10);
            this.GitPath.Name = "GitPath";
            this.GitPath.Size = new System.Drawing.Size(459, 20);
            this.GitPath.TabIndex = 1;
            // 
            // AzureStorageEmulatorPath
            // 
            this.AzureStorageEmulatorPath.Location = new System.Drawing.Point(152, 37);
            this.AzureStorageEmulatorPath.Name = "AzureStorageEmulatorPath";
            this.AzureStorageEmulatorPath.Size = new System.Drawing.Size(459, 20);
            this.AzureStorageEmulatorPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "AzureStorageEmulatorPath";
            // 
            // WwwRootPath
            // 
            this.WwwRootPath.Location = new System.Drawing.Point(152, 64);
            this.WwwRootPath.Name = "WwwRootPath";
            this.WwwRootPath.Size = new System.Drawing.Size(459, 20);
            this.WwwRootPath.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "WwwRootPath";
            // 
            // OtherRootPath
            // 
            this.OtherRootPath.Location = new System.Drawing.Point(152, 91);
            this.OtherRootPath.Name = "OtherRootPath";
            this.OtherRootPath.Size = new System.Drawing.Size(459, 20);
            this.OtherRootPath.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "OtherRootPath";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(536, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "MS Build v.15";
            // 
            // MsBuild
            // 
            this.MsBuild.Location = new System.Drawing.Point(152, 169);
            this.MsBuild.Name = "MsBuild";
            this.MsBuild.Size = new System.Drawing.Size(459, 20);
            this.MsBuild.TabIndex = 10;
            // 
            // LogViewer
            // 
            this.LogViewer.Location = new System.Drawing.Point(152, 195);
            this.LogViewer.Name = "LogViewer";
            this.LogViewer.Size = new System.Drawing.Size(459, 20);
            this.LogViewer.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "LogViewer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "ProxyRootPath";
            // 
            // ProxyRootPath
            // 
            this.ProxyRootPath.Location = new System.Drawing.Point(152, 143);
            this.ProxyRootPath.Name = "ProxyRootPath";
            this.ProxyRootPath.Size = new System.Drawing.Size(459, 20);
            this.ProxyRootPath.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "CoreRootPath";
            // 
            // CoreRootPath
            // 
            this.CoreRootPath.Location = new System.Drawing.Point(152, 117);
            this.CoreRootPath.Name = "CoreRootPath";
            this.CoreRootPath.Size = new System.Drawing.Size(459, 20);
            this.CoreRootPath.TabIndex = 15;
            // 
            // GlobalSettingsForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 275);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CoreRootPath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ProxyRootPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LogViewer);
            this.Controls.Add(this.MsBuild);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OtherRootPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WwwRootPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AzureStorageEmulatorPath);
            this.Controls.Add(this.GitPath);
            this.Controls.Add(this.label1);
            this.Name = "GlobalSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GlobalSettingsForm";
            this.Load += new System.EventHandler(this.GlobalSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GitPath;
        private System.Windows.Forms.TextBox AzureStorageEmulatorPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WwwRootPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OtherRootPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MsBuild;
        private System.Windows.Forms.TextBox LogViewer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ProxyRootPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CoreRootPath;
    }
}