using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssuesForm : Form
    {
        private string mediaFilePath; // Stores the path of the attached media file

        public ReportIssuesForm()
        {
            InitializeComponent();
            // Attach the Paint event handler here
            lblHeader.Paint += OnLblHeaderPaint;
            // Start the timer for header animation
            headerAnimationTimer.Start();
        }

        // Handles the click event for the Attach Media button
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
                    UpdateMediaPreview(); // Update the preview with the selected media
                }
            }
        }

        // Updates the media preview display
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

        // Handles the click event for the Submit button
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

        // Handles the click event for the Back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the current form
        }

        // Custom drawing logic
        private void OnLblHeaderPaint(object sender, PaintEventArgs e)
        {
            // Draw animated border
            var rect = new Rectangle(0, 0, lblHeader.Width - 1, lblHeader.Height - 1);
            using (var pen = new Pen(lblHeader.ForeColor, 3))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        // Timer tick event for header animation
        private void headerAnimationTimer_Tick(object sender, EventArgs e)
        {
            // Basic animation effect: cyclic border color
            var random = new Random();
            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);

            lblHeader.ForeColor = Color.FromArgb(r, g, b);
            lblHeader.Invalidate(); // Trigger re-draw to update the border color
        }
    }
}
