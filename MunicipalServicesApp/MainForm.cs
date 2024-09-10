using System;
using System.Collections.Generic;
using System.Drawing; // For Color
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainForm : Form
    {
        private List<Issue> issues = new List<Issue>();
        private Button btnExit;

        public MainForm()
        {
            InitializeComponent();
            // Initialize Exit Button
            InitializeExitButton();
        }

        private void InitializeExitButton()
        {
            this.btnExit = new Button
            {
                Location = new Point(12, 415), // Adjust as necessary
                Name = "btnExit",
                Size = new Size(75, 23),
                Text = "Exit",
                BackColor = Color.Red, // Set a bright color
                ForeColor = Color.White // Set text color for contrast
            };
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.Controls.Add(this.btnExit);
        }

        public void AddIssue(Issue issue)
        {
            issues.Add(issue);
            // Optionally, update UI or save to persistent storage
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            var reportIssuesForm = new ReportIssuesForm
            {
                Owner = this // Pass MainForm instance to ReportIssuesForm
            };
            LoadForm(reportIssuesForm);
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Local Events feature is currently unavailable.", "Feature Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnServiceRequestStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Service Request Status feature is currently unavailable.", "Feature Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewIssues_Click(object sender, EventArgs e)
        {
            var viewIssuesForm = new ViewIssuesForm(issues)
            {
                TopLevel = false, // Makes the form non-top-level
                Dock = DockStyle.Fill, // Makes the form fill the content panel
                FormBorderStyle = FormBorderStyle.None // Removes the form border
            };
            LoadForm(viewIssuesForm);
        }

        private void LoadForm(Form form)
        {
            contentPanel.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome to the Municipal Services App";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
