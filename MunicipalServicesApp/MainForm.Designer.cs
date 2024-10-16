using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    partial class MainForm
    {
        private IContainer components = null;
        private Label lblWelcome;
        private Button btnReportIssues;
        private Button btnLocalEvents;
        private Button btnServiceRequestStatus;
        private Panel contentPanel;
        private Button btnViewIssues;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new Label();
            this.btnReportIssues = new Button();
            this.btnLocalEvents = new Button();
            this.btnServiceRequestStatus = new Button();
            this.contentPanel = new Panel();
            this.btnViewIssues = new Button();
            this.SuspendLayout();

            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Arial", 14F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.Location = new Point(373, 18); // Moved 40 pixels to the right
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(382, 24);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to the Municipal Services App";

            // 
            // btnReportIssues
            // 
            this.btnReportIssues.BackColor = Color.FromArgb(34, 45, 50);
            this.btnReportIssues.Font = new Font("Arial", 12F);
            this.btnReportIssues.ForeColor = Color.White;
            this.btnReportIssues.Location = new Point(13, 62);
            this.btnReportIssues.Name = "btnReportIssues";
            this.btnReportIssues.Size = new Size(333, 62);
            this.btnReportIssues.TabIndex = 1;
            this.btnReportIssues.Text = "Report Issues";
            this.btnReportIssues.UseVisualStyleBackColor = false;
            this.btnReportIssues.FlatStyle = FlatStyle.Flat;
            this.btnReportIssues.FlatAppearance.BorderSize = 0;
            this.btnReportIssues.Click += new EventHandler(this.btnReportIssues_Click);

            // 
            // btnLocalEvents
            // 
            this.btnLocalEvents.BackColor = Color.FromArgb(34, 45, 50);
            this.btnLocalEvents.Font = new Font("Arial", 12F);
            this.btnLocalEvents.ForeColor = Color.White;
            this.btnLocalEvents.Location = new Point(13, 135);
            this.btnLocalEvents.Name = "btnLocalEvents";
            this.btnLocalEvents.Size = new Size(333, 62);
            this.btnLocalEvents.TabIndex = 2;
            this.btnLocalEvents.Text = "Local Events And Announcements";
            this.btnLocalEvents.UseVisualStyleBackColor = false;
            this.btnLocalEvents.FlatStyle = FlatStyle.Flat;
            this.btnLocalEvents.FlatAppearance.BorderSize = 0;
            this.btnLocalEvents.Click += new EventHandler(this.btnLocalEvents_Click);

            // 
            // btnServiceRequestStatus
            // 
            this.btnServiceRequestStatus.Enabled = false;
            this.btnServiceRequestStatus.BackColor = Color.Gray;
            this.btnServiceRequestStatus.Font = new Font("Arial", 12F);
            this.btnServiceRequestStatus.ForeColor = Color.White;
            this.btnServiceRequestStatus.Location = new Point(13, 209);
            this.btnServiceRequestStatus.Name = "btnServiceRequestStatus";
            this.btnServiceRequestStatus.Size = new Size(333, 62);
            this.btnServiceRequestStatus.TabIndex = 3;
            this.btnServiceRequestStatus.Text = "Service Request Status";
            this.btnServiceRequestStatus.UseVisualStyleBackColor = false;
            this.btnServiceRequestStatus.FlatStyle = FlatStyle.Flat;
            this.btnServiceRequestStatus.FlatAppearance.BorderSize = 0;

            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = Color.FromArgb(45, 55, 60);
            this.contentPanel.Location = new Point(360, 62);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new Size(1067, 615);
            this.contentPanel.TabIndex = 5;

            // 
            // btnViewIssues
            // 
            this.btnViewIssues.BackColor = Color.FromArgb(34, 45, 50);
            this.btnViewIssues.Font = new Font("Arial", 12F);
            this.btnViewIssues.ForeColor = Color.White;
            this.btnViewIssues.Location = new Point(13, 283);
            this.btnViewIssues.Name = "btnViewIssues";
            this.btnViewIssues.Size = new Size(333, 62);
            this.btnViewIssues.TabIndex = 4;
            this.btnViewIssues.Text = "View Submitted Issues";
            this.btnViewIssues.UseVisualStyleBackColor = false;
            this.btnViewIssues.FlatStyle = FlatStyle.Flat;
            this.btnViewIssues.FlatAppearance.BorderSize = 0;
            this.btnViewIssues.Click += new EventHandler(this.btnViewIssues_Click);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(28, 36, 41); // Form background color
            this.ClientSize = new Size(1467, 738);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.btnViewIssues);
            this.Controls.Add(this.btnServiceRequestStatus);
            this.Controls.Add(this.btnLocalEvents);
            this.Controls.Add(this.btnReportIssues);
            this.Controls.Add(this.lblWelcome);
            this.Name = "MainForm";
            this.Text = "Municipal Services Application";
            this.Load += new EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
