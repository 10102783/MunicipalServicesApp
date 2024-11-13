using System.Windows.Forms;
using System.Drawing;
using System;

namespace MunicipalServicesApp
{
    partial class ServiceRequestStatusForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView serviceRequestsDataGridView;
        private TextBox searchRequestIDTextBox;
        private Button trackStatusButton;
        private Label requestDetailsLabel;
        private Button PrioritizeRequestButton;
        private Button ShowDependenciesButton;
        private TextBox statusUpdateTextBox;
        private Button UpdateStatusButton;
        private TreeView graphDisplayTreeView;
        private TextBox searchQueryTextBox;
        private Button searchButton;
        private Button SaveButton;
        private Button DeleteButton;
        private Button SortByIDButton;
        private Button SortByStatusButton;
        private Button ExportButton;

        private void InitializeComponent()
        {
            this.serviceRequestsDataGridView = new DataGridView();
            this.searchRequestIDTextBox = new TextBox();
            this.trackStatusButton = new Button();
            this.requestDetailsLabel = new Label();
            this.PrioritizeRequestButton = new Button();
            this.ShowDependenciesButton = new Button();
            this.statusUpdateTextBox = new TextBox();
            this.UpdateStatusButton = new Button();
            this.graphDisplayTreeView = new TreeView();
            this.searchQueryTextBox = new TextBox();
            this.searchButton = new Button();
            this.SaveButton = new Button();
            this.DeleteButton = new Button();
            this.SortByIDButton = new Button();
            this.SortByStatusButton = new Button();
            this.ExportButton = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.serviceRequestsDataGridView)).BeginInit();
            this.SuspendLayout();

            // 
            // serviceRequestsDataGridView
            // 
            this.serviceRequestsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceRequestsDataGridView.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { HeaderText = "Request ID", Name = "RequestID", Width = 200 },
                new DataGridViewTextBoxColumn() { HeaderText = "Description", Name = "Description", Width = 300 },
                new DataGridViewTextBoxColumn() { HeaderText = "Status", Name = "Status", Width = 100 },
                new DataGridViewTextBoxColumn() { HeaderText = "Date", Name = "RequestDate", Width = 150 }
            });
            this.serviceRequestsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.serviceRequestsDataGridView.Name = "serviceRequestsDataGridView";
            this.serviceRequestsDataGridView.Size = new System.Drawing.Size(600, 200);
            this.serviceRequestsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Set the background color for the entire grid and the header
            this.serviceRequestsDataGridView.BackgroundColor = Color.White;
            this.serviceRequestsDataGridView.GridColor = Color.LightGray;  // Set light gray for grid lines

            // Customize cell appearance
            this.serviceRequestsDataGridView.DefaultCellStyle.BackColor = Color.White;
            this.serviceRequestsDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            this.serviceRequestsDataGridView.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // Highlight when selected
            this.serviceRequestsDataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Customize header style
            this.serviceRequestsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            this.serviceRequestsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.serviceRequestsDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.serviceRequestsDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);

            // Add borders to column divider lines to make them distinct
            this.serviceRequestsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;  // Horizontal lines for rows
            this.serviceRequestsDataGridView.RowHeadersVisible = false;  // Optional: Hide row headers if not needed
            this.serviceRequestsDataGridView.BorderStyle = BorderStyle.None;  // Remove outer border for a clean look

            // 
            // searchRequestIDTextBox
            // 
            this.searchRequestIDTextBox.Location = new System.Drawing.Point(12, 230);
            this.searchRequestIDTextBox.Name = "searchRequestIDTextBox";
            this.searchRequestIDTextBox.Size = new System.Drawing.Size(200, 20);

            // 
            // trackStatusButton
            // 
            this.trackStatusButton.Location = new System.Drawing.Point(220, 230);
            this.trackStatusButton.Name = "trackStatusButton";
            this.trackStatusButton.Size = new System.Drawing.Size(100, 23);
            this.trackStatusButton.Text = "Track Status";
            this.trackStatusButton.BackColor = System.Drawing.Color.LightBlue;
            this.trackStatusButton.Click += new EventHandler(this.TrackStatusButton_Click);

            // 
            // requestDetailsLabel
            // 
            this.requestDetailsLabel.Location = new System.Drawing.Point(12, 260);
            this.requestDetailsLabel.Name = "requestDetailsLabel";
            this.requestDetailsLabel.Size = new System.Drawing.Size(600, 40);
            this.requestDetailsLabel.Text = "Request Details";

            // 
            // PrioritizeRequestButton
            // 
            this.PrioritizeRequestButton.Location = new System.Drawing.Point(12, 300);
            this.PrioritizeRequestButton.Name = "PrioritizeRequestButton";
            this.PrioritizeRequestButton.Size = new System.Drawing.Size(120, 23);
            this.PrioritizeRequestButton.Text = "Prioritize Request";
            this.PrioritizeRequestButton.BackColor = System.Drawing.Color.LightYellow;
            this.PrioritizeRequestButton.Click += new EventHandler(this.PrioritizeRequestButton_Click);

            // 
            // ShowDependenciesButton
            // 
            this.ShowDependenciesButton.Location = new System.Drawing.Point(140, 300);
            this.ShowDependenciesButton.Name = "ShowDependenciesButton";
            this.ShowDependenciesButton.Size = new System.Drawing.Size(120, 23);
            this.ShowDependenciesButton.Text = "Show Dependencies";
            this.ShowDependenciesButton.BackColor = System.Drawing.Color.LightGreen;
            this.ShowDependenciesButton.Click += new EventHandler(this.ShowDependenciesButton_Click);

            // 
            // statusUpdateTextBox
            // 
            this.statusUpdateTextBox.Location = new System.Drawing.Point(12, 330);
            this.statusUpdateTextBox.Name = "statusUpdateTextBox";
            this.statusUpdateTextBox.Size = new System.Drawing.Size(200, 20);

            // 
            // UpdateStatusButton
            // 
            this.UpdateStatusButton.Location = new System.Drawing.Point(220, 330);
            this.UpdateStatusButton.Name = "UpdateStatusButton";
            this.UpdateStatusButton.Size = new System.Drawing.Size(100, 23);
            this.UpdateStatusButton.Text = "Update Status";
            this.UpdateStatusButton.BackColor = System.Drawing.Color.LightCoral;
            this.UpdateStatusButton.Click += new EventHandler(this.UpdateStatusButton_Click);

            // 
            // graphDisplayTreeView
            // 
            this.graphDisplayTreeView.Location = new System.Drawing.Point(12, 360);
            this.graphDisplayTreeView.Size = new System.Drawing.Size(600, 100);
            this.graphDisplayTreeView.Name = "graphDisplayTreeView";

            // 
            // searchQueryTextBox
            // 
            this.searchQueryTextBox.Location = new System.Drawing.Point(12, 430);
            this.searchQueryTextBox.Name = "searchQueryTextBox";
            this.searchQueryTextBox.Size = new System.Drawing.Size(200, 20);

            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(220, 430);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.Text = "Search";
            this.searchButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.searchButton.Click += new EventHandler(this.SearchButton_Click);

            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 460);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.Text = "Save";
            this.SaveButton.BackColor = System.Drawing.Color.PaleGreen;
            this.SaveButton.Click += new EventHandler(this.SaveButton_Click);

            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(100, 460);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.BackColor = System.Drawing.Color.LightCoral;
            this.DeleteButton.Click += new EventHandler(this.DeleteButton_Click);

            // 
            // SortByIDButton
            // 
            this.SortByIDButton.Location = new System.Drawing.Point(190, 460);
            this.SortByIDButton.Name = "SortByIDButton";
            this.SortByIDButton.Size = new System.Drawing.Size(75, 23);
            this.SortByIDButton.Text = "Sort by ID";
            this.SortByIDButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.SortByIDButton.Click += new EventHandler(this.SortByIDButton_Click);

            // 
            // SortByStatusButton
            // 
            this.SortByStatusButton.Location = new System.Drawing.Point(260, 460);
            this.SortByStatusButton.Name = "SortByStatusButton";
            this.SortByStatusButton.Size = new System.Drawing.Size(100, 23);
            this.SortByStatusButton.Text = "Sort by Status";
            this.SortByStatusButton.BackColor = System.Drawing.Color.LightPink;
            this.SortByStatusButton.Click += new EventHandler(this.SortByStatusButton_Click);

            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(370, 460);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(100, 23);
            this.ExportButton.Text = "Export to CSV";
            this.ExportButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ExportButton.Click += new EventHandler(this.ExportButton_Click);

            // 
            // ServiceRequestStatusForm
            // 
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.serviceRequestsDataGridView);
            this.Controls.Add(this.searchRequestIDTextBox);
            this.Controls.Add(this.trackStatusButton);
            this.Controls.Add(this.requestDetailsLabel);
            this.Controls.Add(this.PrioritizeRequestButton);
            this.Controls.Add(this.ShowDependenciesButton);
            this.Controls.Add(this.statusUpdateTextBox);
            this.Controls.Add(this.UpdateStatusButton);
            this.Controls.Add(this.graphDisplayTreeView);
            this.Controls.Add(this.searchQueryTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SortByIDButton);
            this.Controls.Add(this.SortByStatusButton);
            this.Controls.Add(this.ExportButton);
            this.Name = "ServiceRequestStatusForm";
            this.Load += new EventHandler(this.ServiceRequestStatusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.serviceRequestsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}



