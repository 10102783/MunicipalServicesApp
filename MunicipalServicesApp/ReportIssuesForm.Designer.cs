using System.Drawing;
using System.Windows.Forms;
using System;

namespace MunicipalServicesApp
{
    partial class ReportIssuesForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeader;
        private Label lblLocation;
        private TextBox txtLocation;
        private Label lblCategory;
        private ComboBox ddlCategory;
        private Label lblDescription;
        private RichTextBox rtbDescription;
        private Button btnAttachMedia;
        private Button btnSubmit;
        private Button btnBack;
        private Label lblEngagement;
        private Label lblMediaPath;
        private PictureBox picMediaPreview;
        private Timer headerAnimationTimer;

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
            this.components = new System.ComponentModel.Container();
            this.lblHeader = new Label();
            this.lblLocation = new Label();
            this.txtLocation = new TextBox();
            this.lblCategory = new Label();
            this.ddlCategory = new ComboBox();
            this.lblDescription = new Label();
            this.rtbDescription = new RichTextBox();
            this.btnAttachMedia = new Button();
            this.btnSubmit = new Button();
            this.btnBack = new Button();
            this.lblEngagement = new Label();
            this.lblMediaPath = new Label();
            this.picMediaPreview = new PictureBox();
            this.headerAnimationTimer = new Timer(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.picMediaPreview)).BeginInit();
            this.SuspendLayout();

            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = Color.Transparent;
            this.lblHeader.ForeColor = Color.FromArgb(33, 150, 243);
            this.lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            this.lblHeader.Dock = DockStyle.Top;
            this.lblHeader.Padding = new Padding(10);
            this.lblHeader.Text = "Report an Issue";
            this.lblHeader.Size = new Size(440, 60);
            this.lblHeader.Name = "lblHeader";

            // 
            // headerAnimationTimer
            // 
            this.headerAnimationTimer.Interval = 100; // 100 ms for animation update
            this.headerAnimationTimer.Tick += new System.EventHandler(this.headerAnimationTimer_Tick);

            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblLocation.ForeColor = Color.FromArgb(33, 150, 243);
            this.lblLocation.Location = new Point(20, 70);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new Size(90, 28);
            this.lblLocation.Text = "Location:";

            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = Color.White;
            this.txtLocation.BorderStyle = BorderStyle.FixedSingle;
            this.txtLocation.Font = new Font("Segoe UI", 12F);
            this.txtLocation.ForeColor = Color.FromArgb(33, 150, 243);
            this.txtLocation.Location = new Point(124, 70);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new Size(280, 30);
            this.txtLocation.Padding = new Padding(10);

            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblCategory.ForeColor = Color.FromArgb(33, 150, 243);
            this.lblCategory.Location = new Point(20, 110);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new Size(97, 28);
            this.lblCategory.Text = "Category:";

            // 
            // ddlCategory
            // 
            this.ddlCategory.BackColor = Color.White;
            this.ddlCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ddlCategory.Font = new Font("Segoe UI", 12F);
            this.ddlCategory.ForeColor = Color.FromArgb(33, 150, 243);
            this.ddlCategory.FormattingEnabled = true;
            this.ddlCategory.Items.AddRange(new object[] {
                "Pothole",
                "Streetlight Outage",
                "Graffiti",
                "Other"});
            this.ddlCategory.Location = new Point(124, 110);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new Size(280, 36);

            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblDescription.ForeColor = Color.FromArgb(33, 150, 243);
            this.lblDescription.Location = new Point(12, 150);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(120, 28);
            this.lblDescription.Text = "Description:";

            // 
            // rtbDescription
            // 
            this.rtbDescription.BackColor = Color.White;
            this.rtbDescription.BorderStyle = BorderStyle.FixedSingle;
            this.rtbDescription.Font = new Font("Segoe UI", 12F);
            this.rtbDescription.ForeColor = Color.FromArgb(33, 150, 243);
            this.rtbDescription.Location = new Point(124, 150);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new Size(280, 100);

            // 
            // btnAttachMedia
            // 
            this.btnAttachMedia.BackColor = Color.FromArgb(33, 150, 243);
            this.btnAttachMedia.FlatAppearance.BorderSize = 0;
            this.btnAttachMedia.FlatStyle = FlatStyle.Flat;
            this.btnAttachMedia.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnAttachMedia.ForeColor = Color.White;
            this.btnAttachMedia.Location = new Point(120, 260);
            this.btnAttachMedia.Name = "btnAttachMedia";
            this.btnAttachMedia.Size = new Size(130, 40);
            this.btnAttachMedia.TabIndex = 6;
            this.btnAttachMedia.Text = "Attach Media";
            this.btnAttachMedia.UseVisualStyleBackColor = false;
            this.btnAttachMedia.Click += new EventHandler(this.btnAttachMedia_Click);
            this.btnAttachMedia.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 118, 210); // Hover effect

            // 
            // lblMediaPath
            // 
            this.lblMediaPath.AutoSize = true;
            this.lblMediaPath.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblMediaPath.ForeColor = Color.FromArgb(33, 150, 243);
            this.lblMediaPath.Location = new Point(120, 310);
            this.lblMediaPath.Name = "lblMediaPath";
            this.lblMediaPath.Size = new Size(150, 23);
            this.lblMediaPath.Text = "No media attached.";
            this.lblMediaPath.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // picMediaPreview
            // 
            this.picMediaPreview.BorderStyle = BorderStyle.FixedSingle;
            this.picMediaPreview.Location = new Point(120, 340);
            this.picMediaPreview.Name = "picMediaPreview";
            this.picMediaPreview.Size = new Size(280, 80);
            this.picMediaPreview.SizeMode = PictureBoxSizeMode.Zoom;
            this.picMediaPreview.TabIndex = 11;

            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = Color.FromArgb(76, 175, 80);
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = FlatStyle.Flat;
            this.btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnSubmit.ForeColor = Color.White;
            this.btnSubmit.Location = new Point(120, 430);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new Size(130, 40);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);
            this.btnSubmit.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60); // Hover effect

            // 
            // btnBack
            // 
            this.btnBack.BackColor = Color.FromArgb(244, 67, 54);
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnBack.ForeColor = Color.White;
            this.btnBack.Location = new Point(260, 430);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new Size(130, 40);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);
            this.btnBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 115, 115); // Hover effect

            // 
            // lblEngagement
            // 
            this.lblEngagement.AutoSize = true;
            this.lblEngagement.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblEngagement.ForeColor = Color.Red;
            this.lblEngagement.Location = new Point(120, 480);
            this.lblEngagement.Name = "lblEngagement";
            this.lblEngagement.Size = new Size(303, 23);
            this.lblEngagement.TabIndex = 9;
            this.lblEngagement.Text = "Please fill out all fields before submitting.";
            this.lblEngagement.Visible = false;

            // 
            // ReportIssuesForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(440, 520);
            this.Controls.Add(this.lblEngagement);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.picMediaPreview);
            this.Controls.Add(this.lblMediaPath);
            this.Controls.Add(this.btnAttachMedia);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.ddlCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblHeader);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportIssuesForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Report an Issue";
            ((System.ComponentModel.ISupportInitialize)(this.picMediaPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
