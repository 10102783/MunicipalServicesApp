using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;  // For saving service requests as JSON

namespace MunicipalServicesApp
{
    public partial class ServiceRequestStatusForm : Form
    {
        private BinarySearchTree bst = new BinarySearchTree();
        private MinHeap heap = new MinHeap();
        private Graph graph = new Graph();
        private List<ServiceRequest> serviceRequests = new List<ServiceRequest>();

        // Constructor to accept service requests
        public ServiceRequestStatusForm(List<ServiceRequest> requests)
        {
            InitializeComponent();
            serviceRequests = requests;
            InitializeServiceRequests();
        }

        // Initialize the service requests into BST, MinHeap, and Graph
        private void InitializeServiceRequests()
        {
            foreach (var request in serviceRequests)
            {
                // Ensure no duplicates in BST, MinHeap, and Graph
                if (bst.Search(request.RequestID) == null) // Check BST for duplication by RequestID
                {
                    bst.Insert(request);
                }

                if (!heap.Contains(request)) // Check MinHeap for duplication
                {
                    heap.Insert(request);
                }

                // Avoid duplicate edge in Graph: Only add an edge if it doesn't already exist
                if (!graph.HasEdge(request.RequestID, request.RequestID))
                {
                    graph.AddEdge(request.RequestID, request.RequestID); // Assuming self-dependency for now
                }
            }

            // Populate DataGridView and update the graph
            PopulateDataGridView();
            UpdateGraphDisplay();
        }

        // Populate the DataGridView with service requests
        private void PopulateDataGridView()
        {
            serviceRequestsDataGridView.Rows.Clear();
            foreach (var request in serviceRequests)
            {
                // Create a new row for each service request
                DataGridViewRow row = new DataGridViewRow();

                // Add cells to the row
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = request.RequestID });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = request.Description });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = request.Status });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = request.RequestDate });

                // Add the row to the DataGridView
                serviceRequestsDataGridView.Rows.Add(row);
            }
        }

        // Update the Graph display (using TreeView for hierarchical display)
        private void UpdateGraphDisplay()
        {
            graphDisplayTreeView.Nodes.Clear();  // Clear previous items

            // Add the root nodes and dependencies as child nodes
            foreach (var request in serviceRequests)
            {
                var requestNode = new TreeNode($"Request {request.RequestID}: {request.Description}");
                var dependencies = graph.GetDependencies(request.RequestID);

                if (dependencies.Count > 0)
                {
                    foreach (var dep in dependencies)
                    {
                        var depNode = new TreeNode($"Request {dep}");
                        requestNode.Nodes.Add(depNode);  // Add dependency as a child node
                    }
                }
                else
                {
                    requestNode.Nodes.Add(new TreeNode("No Dependencies"));
                }

                graphDisplayTreeView.Nodes.Add(requestNode);  // Add the request node to the TreeView
            }
        }

        // Handle the click event for tracking a service request by its ID
        private void TrackStatusButton_Click(object sender, EventArgs e)
        {
            int requestID;
            if (int.TryParse(searchRequestIDTextBox.Text, out requestID))
            {
                var request = bst.Search(requestID);
                if (request != null)
                {
                    requestDetailsLabel.Text = $"Request ID: {request.RequestID}, Description: {request.Description}, Status: {request.Status}, Date: {request.RequestDate}";
                }
                else
                {
                    MessageBox.Show("Service Request not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Request ID.");
            }
        }

        // Prioritize and display the service request with the smallest RequestID from MinHeap
        private void PrioritizeRequestButton_Click(object sender, EventArgs e)
        {
            var minRequest = heap.ExtractMin();
            if (minRequest != null)
            {
                MessageBox.Show($"Prioritized Request: {minRequest.RequestID} - {minRequest.Description}");
                // Optionally, you could update the DataGridView or handle further.
            }
            else
            {
                MessageBox.Show("No requests to prioritize.");
            }
        }

        // Display dependencies for the selected request
        private void ShowDependenciesButton_Click(object sender, EventArgs e)
        {
            int requestID;
            if (int.TryParse(searchRequestIDTextBox.Text, out requestID))
            {
                var dependencies = graph.GetDependencies(requestID);
                if (dependencies.Count > 0)
                {
                    string dependencyList = string.Join(", ", dependencies);
                    MessageBox.Show($"Request {requestID} has dependencies on: {dependencyList}");
                }
                else
                {
                    MessageBox.Show($"Request {requestID} has no dependencies.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Request ID.");
            }
        }

        // Update the status of a service request
        private void UpdateStatusButton_Click(object sender, EventArgs e)
        {
            int requestID;
            if (int.TryParse(searchRequestIDTextBox.Text, out requestID))
            {
                var request = bst.Search(requestID);
                if (request != null)
                {
                    // Get the new status from the user input
                    string newStatus = statusUpdateTextBox.Text;
                    if (!string.IsNullOrEmpty(newStatus))
                    {
                        request.UpdateStatus(newStatus);  // Update status and add to history
                        PopulateDataGridView();  // Refresh the grid with updated status
                        MessageBox.Show($"Status for Request {requestID} updated to {newStatus}");
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid status.");
                    }
                }
                else
                {
                    MessageBox.Show("Service Request not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Request ID.");
            }
        }

        // Save Service Requests to a file
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveServiceRequestsToFile();
        }

        private void SaveServiceRequestsToFile()
        {
            // Use SaveFileDialog to prompt user for file location
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                FileName = "service_requests.json"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter file = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var request in serviceRequests)
                        {
                            file.WriteLine(JsonConvert.SerializeObject(request));
                        }
                        MessageBox.Show("Service requests saved successfully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving service requests: {ex.Message}");
                }
            }
        }

        // Delete Service Request
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int requestID;
            if (int.TryParse(searchRequestIDTextBox.Text, out requestID))
            {
                var request = bst.Search(requestID);
                if (request != null)
                {
                    DeleteServiceRequest(request);
                    MessageBox.Show($"Request {requestID} deleted successfully.");
                    PopulateDataGridView();
                }
                else
                {
                    MessageBox.Show("Service Request not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Request ID.");
            }
        }

        private void DeleteServiceRequest(ServiceRequest request)
        {
            // Delete from BST
            bst.Delete(request.RequestID);  // Pass RequestID instead of the full object

            // Delete from MinHeap (Assuming a Remove method is implemented in MinHeap)
            heap.Remove(request);

            // Remove from the serviceRequests list
            serviceRequests.Remove(request);
        }

        // Search by Description or Status
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchQuery = searchQueryTextBox.Text.ToLower();
            var results = serviceRequests.FindAll(r => r.Description.ToLower().Contains(searchQuery) || r.Status.ToLower().Contains(searchQuery));

            if (results.Count > 0)
            {
                // Update the DataGridView with the filtered results
                serviceRequestsDataGridView.Rows.Clear();
                foreach (var request in results)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = request.RequestID });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = request.Description });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = request.Status });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = request.RequestDate });
                    serviceRequestsDataGridView.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("No matching requests found.");
            }
        }

        // Sort by RequestID or Status
        private void SortByIDButton_Click(object sender, EventArgs e)
        {
            serviceRequests.Sort((r1, r2) => r1.RequestID.CompareTo(r2.RequestID));
            PopulateDataGridView();
        }

        private void SortByStatusButton_Click(object sender, EventArgs e)
        {
            serviceRequests.Sort((r1, r2) => r1.Status.CompareTo(r2.Status));
            PopulateDataGridView();
        }

        // Export to CSV
        private void ExportButton_Click(object sender, EventArgs e)
        {
            ExportServiceRequestsToCSV();
        }

        private void ExportServiceRequestsToCSV()
        {
            // Use SaveFileDialog to prompt user for file location
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = "service_requests.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter file = new StreamWriter(saveFileDialog.FileName))
                    {
                        file.WriteLine("RequestID,Description,Status,RequestDate");

                        foreach (var request in serviceRequests)
                        {
                            file.WriteLine($"{request.RequestID},{request.Description},{request.Status},{request.RequestDate}");
                        }

                        MessageBox.Show("Service requests exported to CSV successfully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting service requests: {ex.Message}");
                }
            }
        }

        // Event Handler for Form Load
        private void ServiceRequestStatusForm_Load(object sender, EventArgs e)
        {
            // Any initialization you need when the form loads
        }
    }
}

