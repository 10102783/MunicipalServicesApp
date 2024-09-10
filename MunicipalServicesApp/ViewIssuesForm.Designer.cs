namespace MunicipalServicesApp
{
    partial class ViewIssuesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lstIssues;
        private System.Windows.Forms.ColumnHeader chLocation;
        private System.Windows.Forms.ColumnHeader chCategory;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.ColumnHeader chMediaPath;
        private System.Windows.Forms.Button btnClose;

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
            this.lstIssues = new System.Windows.Forms.ListView();
            this.chLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMediaPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstIssues
            // 
            this.lstIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLocation,
            this.chCategory,
            this.chDescription,
            this.chMediaPath});
            this.lstIssues.FullRowSelect = true;
            this.lstIssues.GridLines = true;
            this.lstIssues.Location = new System.Drawing.Point(12, 12);
            this.lstIssues.Name = "lstIssues";
            this.lstIssues.Size = new System.Drawing.Size(900, 400);  // Increased ListView size
            this.lstIssues.TabIndex = 0;
            this.lstIssues.UseCompatibleStateImageBehavior = false;
            this.lstIssues.View = System.Windows.Forms.View.Details;
            // 
            // chLocation
            // 
            this.chLocation.Text = "Location";
            this.chLocation.Width = 120;
            // 
            // chCategory
            // 
            this.chCategory.Text = "Category";
            this.chCategory.Width = 120;
            // 
            // chDescription
            // 
            this.chDescription.Text = "Description";
            this.chDescription.Width = 250; // Adjusted width
            // 
            // chMediaPath
            // 
            this.chMediaPath.Text = "Media Path";
            this.chMediaPath.Width = 400; // Increased width to accommodate full path
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(837, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ViewIssuesForm
            // 
            this.ClientSize = new System.Drawing.Size(924, 460);  // Increased form size
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstIssues);
            this.Name = "ViewIssuesForm";
            this.Text = "View Issues";
            this.ResumeLayout(false);

        }
    }
}

