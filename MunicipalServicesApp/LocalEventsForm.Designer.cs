using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ProgressBar progressBarCategories;

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
            this.listViewEvents = new System.Windows.Forms.ListView();
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.btnFilterByCategory = new System.Windows.Forms.Button();
            this.btnSortByDate = new System.Windows.Forms.Button();
            this.btnSortByCategory = new System.Windows.Forms.Button();
            this.btnSortByName = new System.Windows.Forms.Button();
            this.columnHeaderRecommendation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewRecommendations = new System.Windows.Forms.ListView();
            this.progressBarCategories = new System.Windows.Forms.ProgressBar(); // Added ProgressBar
            this.SuspendLayout();

            // listViewEvents
            this.listViewEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTitle,
            this.columnHeaderDate,
            this.columnHeaderCategory,
            this.columnHeaderDescription});
            this.listViewEvents.FullRowSelect = true;
            this.listViewEvents.GridLines = true;
            this.listViewEvents.HideSelection = false;
            this.listViewEvents.Location = new System.Drawing.Point(16, 15);
            this.listViewEvents.Margin = new System.Windows.Forms.Padding(4);
            this.listViewEvents.Name = "listViewEvents";
            this.listViewEvents.Size = new System.Drawing.Size(799, 245);
            this.listViewEvents.TabIndex = 0;
            this.listViewEvents.UseCompatibleStateImageBehavior = false;
            this.listViewEvents.View = System.Windows.Forms.View.Details;
            this.listViewEvents.DoubleClick += new System.EventHandler(this.listViewEvents_DoubleClick);

            // columnHeaderTitle
            this.columnHeaderTitle.Text = "Title";
            this.columnHeaderTitle.Width = 150;
            // columnHeaderDate
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 100;
            // columnHeaderCategory
            this.columnHeaderCategory.Text = "Category";
            this.columnHeaderCategory.Width = 100;
            // columnHeaderDescription
            this.columnHeaderDescription.Text = "Description";
            this.columnHeaderDescription.Width = 250;

            // comboBoxCategory
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.Location = new System.Drawing.Point(16, 271);
            this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(199, 24);
            this.comboBoxCategory.TabIndex = 1;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);

            // dateTimePicker
            this.dateTimePicker.Location = new System.Drawing.Point(240, 271);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker.TabIndex = 2;

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(533, 271);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnDeleteEvent
            this.btnDeleteEvent.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDeleteEvent.ForeColor = System.Drawing.Color.White;
            this.btnDeleteEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteEvent.Location = new System.Drawing.Point(667, 271);
            this.btnDeleteEvent.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteEvent.TabIndex = 4;
            this.btnDeleteEvent.Text = "Delete";
            this.btnDeleteEvent.UseVisualStyleBackColor = false;
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);

            // btnFilterByCategory
            this.btnFilterByCategory.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnFilterByCategory.ForeColor = System.Drawing.Color.White;
            this.btnFilterByCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterByCategory.Location = new System.Drawing.Point(16, 308);
            this.btnFilterByCategory.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilterByCategory.Name = "btnFilterByCategory";
            this.btnFilterByCategory.Size = new System.Drawing.Size(200, 28);
            this.btnFilterByCategory.TabIndex = 5;
            this.btnFilterByCategory.Text = "Filter by Category";
            this.btnFilterByCategory.UseVisualStyleBackColor = false;
            this.btnFilterByCategory.Click += new System.EventHandler(this.btnFilterByCategory_Click);

            // btnSortByDate
            this.btnSortByDate.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSortByDate.ForeColor = System.Drawing.Color.White;
            this.btnSortByDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortByDate.Location = new System.Drawing.Point(240, 308);
            this.btnSortByDate.Margin = new System.Windows.Forms.Padding(4);
            this.btnSortByDate.Name = "btnSortByDate";
            this.btnSortByDate.Size = new System.Drawing.Size(133, 28);
            this.btnSortByDate.TabIndex = 6;
            this.btnSortByDate.Text = "Sort by Date";
            this.btnSortByDate.UseVisualStyleBackColor = false;
            this.btnSortByDate.Click += new System.EventHandler(this.btnSortByDate_Click);

            // btnSortByCategory
            this.btnSortByCategory.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSortByCategory.ForeColor = System.Drawing.Color.White;
            this.btnSortByCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortByCategory.Location = new System.Drawing.Point(400, 308);
            this.btnSortByCategory.Margin = new System.Windows.Forms.Padding(4);
            this.btnSortByCategory.Name = "btnSortByCategory";
            this.btnSortByCategory.Size = new System.Drawing.Size(133, 28);
            this.btnSortByCategory.TabIndex = 7;
            this.btnSortByCategory.Text = "Sort by Category";
            this.btnSortByCategory.UseVisualStyleBackColor = false;
            this.btnSortByCategory.Click += new System.EventHandler(this.btnSortByCategory_Click);

            // btnSortByName
            this.btnSortByName.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSortByName.ForeColor = System.Drawing.Color.White;
            this.btnSortByName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortByName.Location = new System.Drawing.Point(560, 308);
            this.btnSortByName.Margin = new System.Windows.Forms.Padding(4);
            this.btnSortByName.Name = "btnSortByName";
            this.btnSortByName.Size = new System.Drawing.Size(133, 28);
            this.btnSortByName.TabIndex = 8;
            this.btnSortByName.Text = "Sort by Name";
            this.btnSortByName.UseVisualStyleBackColor = false;
            this.btnSortByName.Click += new System.EventHandler(this.btnSortByName_Click);

            // columnHeaderRecommendation
            this.columnHeaderRecommendation.Text = "Recommendation";
            this.columnHeaderRecommendation.Width = 150;

            // listViewRecommendations
            this.listViewRecommendations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRecommendation});
            this.listViewRecommendations.FullRowSelect = true;
            this.listViewRecommendations.GridLines = false; // Removed grid lines
            this.listViewRecommendations.HideSelection = false;
            this.listViewRecommendations.Location = new System.Drawing.Point(16, 345);
            this.listViewRecommendations.Margin = new System.Windows.Forms.Padding(4);
            this.listViewRecommendations.Name = "listViewRecommendations";
            this.listViewRecommendations.Size = new System.Drawing.Size(799, 184);
            this.listViewRecommendations.TabIndex = 9;
            this.listViewRecommendations.UseCompatibleStateImageBehavior = false;
            this.listViewRecommendations.View = System.Windows.Forms.View.Details;

            // progressBarCategories
            this.progressBarCategories.Location = new System.Drawing.Point(16, 536);
            this.progressBarCategories.Size = new System.Drawing.Size(799, 23);
            this.Controls.Add(this.progressBarCategories); // Added ProgressBar to Controls

            // LocalEventsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 570);
            this.Controls.Add(this.listViewRecommendations);
            this.Controls.Add(this.btnSortByName);
            this.Controls.Add(this.btnSortByCategory);
            this.Controls.Add(this.btnSortByDate);
            this.Controls.Add(this.btnFilterByCategory);
            this.Controls.Add(this.btnDeleteEvent);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.listViewEvents);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LocalEventsForm";
            this.Text = "Local Events and Announcements";
            this.ResumeLayout(false);
        }

        private void UpdateCategoryProgress()
        {
            int totalEvents = listViewEvents.Items.Count;
            if (totalEvents == 0) return;

            int selectedCategoryCount = listViewEvents.Items.Cast<ListViewItem>()
                .Count(item => item.SubItems[2].Text == comboBoxCategory.SelectedItem.ToString());

            int percentage = (int)((selectedCategoryCount / (float)totalEvents) * 100);
            progressBarCategories.Value = percentage;

            UpdateRecommendations(selectedCategoryCount, totalEvents);
        }

        private void UpdateRecommendations(int selectedCount, int totalCount)
        {
            listViewRecommendations.Items.Clear();
            if (totalCount == 0) return;

            // Example recommendations based on percentage
            if (selectedCount == 0)
            {
                listViewRecommendations.Items.Add(new ListViewItem("No events in this category"));
            }
            else if (selectedCount > totalCount / 2) // More than 50%
            {
                listViewRecommendations.Items.Add(new ListViewItem("Highly recommended: Participate!"));
            }
            else
            {
                listViewRecommendations.Items.Add(new ListViewItem("Consider joining events in this category."));
            }
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCategoryProgress();
        }

        private System.Windows.Forms.ListView listViewEvents;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderCategory;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.Button btnFilterByCategory;
        private System.Windows.Forms.Button btnSortByDate;
        private System.Windows.Forms.Button btnSortByCategory;
        private System.Windows.Forms.Button btnSortByName;
        private System.Windows.Forms.ColumnHeader columnHeaderRecommendation;
        private System.Windows.Forms.ListView listViewRecommendations;
    }
}
