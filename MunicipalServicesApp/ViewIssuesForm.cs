using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ViewIssuesForm : Form
    {
        private List<Issue> issues;

        public ViewIssuesForm(List<Issue> issues)
        {
            InitializeComponent();
            this.issues = issues;
            DisplayIssues();
        }

        private void DisplayIssues()
        {
            lstIssues.Items.Clear(); // Clear existing items, if any
            foreach (var issue in issues)
            {
                ListViewItem item = new ListViewItem(issue.Location);
                item.SubItems.Add(issue.Category);
                item.SubItems.Add(issue.Description);
                item.SubItems.Add(issue.MediaPath ?? "No Media");
                lstIssues.Items.Add(item);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
