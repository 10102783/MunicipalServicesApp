public class Issue
{
    public string Location { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string MediaPath { get; set; } // Ensure this property exists

    // Constructor
    public Issue(string location, string category, string description, string mediaPath)
    {
        Location = location;
        Category = category;
        Description = description;
        MediaPath = mediaPath;
    }
}

