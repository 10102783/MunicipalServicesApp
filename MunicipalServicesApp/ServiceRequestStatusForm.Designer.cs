using System.Windows.Forms;
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
        private TreeView graphDisplayTreeView;  // Changed to TreeView for graph dependencies
        private TextBox searchQueryTextBox;     // Added Search TextBox
        private Button searchButton;            // Added Search Button
        private Button SaveButton;              // Added Save Button (for saving requests to file)
        private Button DeleteButton;            // Added Delete Button (for deleting requests)
        private Button SortByIDButton;          // Added Sort Button (for sorting by ID)
        private Button SortByStatusButton;      // Added Sort Button (for sorting by Status)
        private Button ExportButton;            // Added Export Button (for exporting to CSV)

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
            this.graphDisplayTreeView = new TreeView();  // Initialize the TreeView for graph display
            this.searchQueryTextBox = new TextBox();     // Initialize the Search TextBox
            this.searchButton = new Button();            // Initialize the Search Button
            this.SaveButton = new Button();              // Initialize the Save Button
            this.DeleteButton = new Button();            // Initialize the Delete Button
            this.SortByIDButton = new Button();          // Initialize the Sort by ID Button
            this.SortByStatusButton = new Button();      // Initialize the Sort by Status Button
            this.ExportButton = new Button();            // Initialize the Export Button

            ((System.ComponentModel.ISupportInitialize)(this.serviceRequestsDataGridView)).BeginInit();
            this.SuspendLayout();

            // 
            // serviceRequestsDataGridView
            // 
            this.serviceRequestsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceRequestsDataGridView.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { HeaderText = "Request ID", Name = "RequestID" },
                new DataGridViewTextBoxColumn() { HeaderText = "Description", Name = "Description" },
                new DataGridViewTextBoxColumn() { HeaderText = "Status", Name = "Status" },
                new DataGridViewTextBoxColumn() { HeaderText = "Date", Name = "RequestDate" }
            });
            this.serviceRequestsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.serviceRequestsDataGridView.Name = "serviceRequestsDataGridView";
            this.serviceRequestsDataGridView.Size = new System.Drawing.Size(600, 200);

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
            this.trackStatusButton.Size = new System.Drawing.Size(75, 23);
            this.trackStatusButton.Text = "Track Status";
            this.trackStatusButton.Click += new EventHandler(this.TrackStatusButton_Click);

            // 
            // requestDetailsLabel
            // 
            this.requestDetailsLabel.Location = new System.Drawing.Point(12, 260);
            this.requestDetailsLabel.Name = "requestDetailsLabel";
            this.requestDetailsLabel.Size = new System.Drawing.Size(600, 40);

            // 
            // PrioritizeRequestButton
            // 
            this.PrioritizeRequestButton.Location = new System.Drawing.Point(12, 300);
            this.PrioritizeRequestButton.Name = "PrioritizeRequestButton";
            this.PrioritizeRequestButton.Size = new System.Drawing.Size(120, 23);
            this.PrioritizeRequestButton.Text = "Prioritize Request";
            this.PrioritizeRequestButton.Click += new EventHandler(this.PrioritizeRequestButton_Click);

            // 
            // ShowDependenciesButton
            // 
            this.ShowDependenciesButton.Location = new System.Drawing.Point(140, 300);
            this.ShowDependenciesButton.Name = "ShowDependenciesButton";
            this.ShowDependenciesButton.Size = new System.Drawing.Size(120, 23);
            this.ShowDependenciesButton.Text = "Show Dependencies";
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
            this.UpdateStatusButton.Click += new EventHandler(this.UpdateStatusButton_Click);

            // 
            // graphDisplayTreeView
            // 
            this.graphDisplayTreeView.Location = new System.Drawing.Point(12, 360);  // Adjust position as needed
            this.graphDisplayTreeView.Size = new System.Drawing.Size(600, 100);  // Adjust size as needed
            this.graphDisplayTreeView.Name = "graphDisplayTreeView";  // Name the TreeView for easy access

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
            this.searchButton.Click += new EventHandler(this.SearchButton_Click);

            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 460);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.Text = "Save";
            this.SaveButton.Click += new EventHandler(this.SaveButton_Click);

            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(100, 460);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new EventHandler(this.DeleteButton_Click);

            // 
            // SortByIDButton
            // 
            this.SortByIDButton.Location = new System.Drawing.Point(180, 460);
            this.SortByIDButton.Name = "SortByIDButton";
            this.SortByIDButton.Size = new System.Drawing.Size(75, 23);
            this.SortByIDButton.Text = "Sort by ID";
            this.SortByIDButton.Click += new EventHandler(this.SortByIDButton_Click);

            // 
            // SortByStatusButton
            // 
            this.SortByStatusButton.Location = new System.Drawing.Point(260, 460);
            this.SortByStatusButton.Name = "SortByStatusButton";
            this.SortByStatusButton.Size = new System.Drawing.Size(100, 23);
            this.SortByStatusButton.Text = "Sort by Status";
            this.SortByStatusButton.Click += new EventHandler(this.SortByStatusButton_Click);

            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(370, 460);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(100, 23);
            this.ExportButton.Text = "Export to CSV";
            this.ExportButton.Click += new EventHandler(this.ExportButton_Click);

            // 
            // ServiceRequestStatusForm
            // 
            this.ClientSize = new System.Drawing.Size(634, 511);  // Adjusted size to fit the buttons
            this.Controls.Add(this.serviceRequestsDataGridView);
            this.Controls.Add(this.searchRequestIDTextBox);
            this.Controls.Add(this.trackStatusButton);
            this.Controls.Add(this.requestDetailsLabel);
            this.Controls.Add(this.PrioritizeRequestButton);
            this.Controls.Add(this.ShowDependenciesButton);
            this.Controls.Add(this.statusUpdateTextBox);
            this.Controls.Add(this.UpdateStatusButton);
            this.Controls.Add(this.graphDisplayTreeView);  // Add the TreeView for graph display to the form
            this.Controls.Add(this.searchQueryTextBox);     // Add the search query textbox
            this.Controls.Add(this.searchButton);           // Add the search button
            this.Controls.Add(this.SaveButton);             // Add Save button
            this.Controls.Add(this.DeleteButton);           // Add Delete button
            this.Controls.Add(this.SortByIDButton);         // Add Sort by ID button
            this.Controls.Add(this.SortByStatusButton);     // Add Sort by Status button
            this.Controls.Add(this.ExportButton);           // Add Export button
            this.Name = "ServiceRequestStatusForm";
            this.Load += new EventHandler(this.ServiceRequestStatusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.serviceRequestsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


