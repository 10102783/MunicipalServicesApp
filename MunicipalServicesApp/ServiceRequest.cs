using System.Collections.Generic;
using System;

public class ServiceRequest
{
    public int RequestID { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime RequestDate { get; set; }
    public List<string> StatusHistory { get; set; }

    public ServiceRequest(int requestID, string description, string status, DateTime requestDate)
    {
        RequestID = requestID;
        Description = description;
        Status = status;
        RequestDate = requestDate;
        StatusHistory = new List<string> { status };  // Store the initial status in history
    }

    // Method to update the status and log history
    public void UpdateStatus(string newStatus)
    {
        Status = newStatus;
        StatusHistory.Add(newStatus);  // Log the new status
    }
}
