using System;

public class Event
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public string Description { get; set; } // Add description property

    public override string ToString()
    {
        return $"{Name} - {Date.ToString("MM/dd/yyyy")} ({Category})";
    }
}
