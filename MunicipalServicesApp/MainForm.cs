using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainForm : Form
    {
        private List<Issue> issues = new List<Issue>();
        private List<ServiceRequest> serviceRequests = new List<ServiceRequest>(); // List to hold service requests
        private Button btnExit;

        public MainForm()
        {
            InitializeComponent();
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
            var localEventsForm = new LocalEventsForm();
            LoadForm(localEventsForm);
        }

        private void btnServiceRequestStatus_Click(object sender, EventArgs e)
        {
            // Pass the serviceRequests list to the ServiceRequestStatusForm
            var serviceRequestStatusForm = new ServiceRequestStatusForm(serviceRequests)
            {
                Owner = this // Optional, to set MainForm as the owner
            };
            LoadForm(serviceRequestStatusForm);
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

            // Example: Adding service requests to the list (replace with real data as needed)
            serviceRequests.Add(new ServiceRequest(1, "Fix Water Pipe", "Pending", DateTime.Now));
            serviceRequests.Add(new ServiceRequest(2, "Repair Streetlight", "In Progress", DateTime.Now.AddDays(1)));
            serviceRequests.Add(new ServiceRequest(3, "Clean Park", "Completed", DateTime.Now.AddDays(2)));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you! See you soon.", "Goodbye", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
    }
}
