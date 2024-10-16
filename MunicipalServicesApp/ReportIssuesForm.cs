using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssuesForm : Form
    {
        private string mediaFilePath; // Stores the path of the attached media file
        private ProgressBar progressBar;
        private Label lblProgressPercentage;

        public ReportIssuesForm()
        {
            InitializeComponent();
            lblHeader.Paint += OnLblHeaderPaint;
            headerAnimationTimer.Start();

            // Initialize Progress Bar
            InitializeProgressBar();
            UpdateProgressBar();

            // Attach event handlers for text changes
            txtLocation.TextChanged += (s, e) => UpdateProgressBar();
            ddlCategory.SelectedIndexChanged += (s, e) => UpdateProgressBar();
            rtbDescription.TextChanged += (s, e) => UpdateProgressBar();
        }

        private void InitializeProgressBar()
        {
            progressBar = new ProgressBar
            {
                Location = new Point(124, 470),
                Size = new Size(280, 25),
                Style = ProgressBarStyle.Continuous,
                ForeColor = Color.FromArgb(76, 175, 80), // Custom color for progress
                BackColor = Color.LightGray // Background color
            };

            lblProgressPercentage = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 150, 243),
                Location = new Point(410, 470),
                Text = "0%"
            };

            Controls.Add(progressBar);
            Controls.Add(lblProgressPercentage);
        }

        private void UpdateProgressBar()
        {
            int filledFields = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) filledFields++;
            if (ddlCategory.SelectedItem != null) filledFields++;
            if (!string.IsNullOrWhiteSpace(rtbDescription.Text)) filledFields++;

            int totalFields = 3; // Location, Category, Description
            int progress = (filledFields * 100) / totalFields;

            progressBar.Value = progress;
            lblProgressPercentage.Text = $"{progress}%";
        }

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Media File";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    mediaFilePath = openFileDialog.FileName;
                    UpdateMediaPreview();
                    UpdateProgressBar(); // Update progress after attaching media
                }
            }
        }

        private void UpdateMediaPreview()
        {
            if (string.IsNullOrEmpty(mediaFilePath))
            {
                lblMediaPath.Text = "No media attached.";
                picMediaPreview.Image = null;
            }
            else
            {
                lblMediaPath.Text = $"Attached Media: {Path.GetFileName(mediaFilePath)}";
                try
                {
                    picMediaPreview.Image = Image.FromFile(mediaFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    picMediaPreview.Image = null;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string location = txtLocation.Text;
            string category = ddlCategory.SelectedItem?.ToString() ?? "Unspecified";
            string description = rtbDescription.Text;

            if (string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(description))
            {
                lblEngagement.Text = "Please fill out all fields before submitting.";
                lblEngagement.Visible = true; // Show engagement label
                MessageBox.Show("Please fill out all fields before submitting.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Issue newIssue = new Issue(location, category, description, mediaFilePath);

            if (Owner is MainForm mainForm)
            {
                mainForm.AddIssue(newIssue); // Add the new issue to the list in MainForm
            }

            lblEngagement.Text = "Issue submitted successfully!";
            lblEngagement.Visible = true; // Show engagement label
            MessageBox.Show("Issue submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the current form
        }

        private void OnLblHeaderPaint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, lblHeader.Width - 1, lblHeader.Height - 1);
            using (var pen = new Pen(lblHeader.ForeColor, 3))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void headerAnimationTimer_Tick(object sender, EventArgs e)
        {
            var random = new Random();
            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);

            lblHeader.ForeColor = Color.FromArgb(r, g, b);
            lblHeader.Invalidate(); // Trigger re-draw to update the border color
        }
    }
}
