using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LocalEventsForm : Form
    {
        private SortedDictionary<DateTime, List<Event>> events;
        private SortedDictionary<DateTime, List<Announcement>> announcements;
        private HashSet<string> categories;
        private Dictionary<string, (List<Event>, int)> userSearchHistory;
        private Queue<Event> eventQueue;
        private ListViewItem highlightedItem;

        public LocalEventsForm()
        {
            InitializeComponent();
            InitializeEventsAndAnnouncements();
            PopulateEventAndAnnouncementList();
            LoadSearchHistory();

            listViewEvents.MouseMove += ListViewEvents_MouseMove;
        }

        private void InitializeEventsAndAnnouncements()
        {
            events = new SortedDictionary<DateTime, List<Event>>();
            announcements = new SortedDictionary<DateTime, List<Announcement>>();
            categories = new HashSet<string>();
            userSearchHistory = new Dictionary<string, (List<Event>, int)>();
            eventQueue = new Queue<Event>();

            // Sample events and announcements
            AddEvent(new Event { Name = "Art Festival", Date = DateTime.Now.AddDays(5), Category = "Art", Description = "A celebration of local artists." });
            AddEvent(new Event { Name = "Food Fair", Date = DateTime.Now.AddDays(10), Category = "Food", Description = "Taste the best local cuisine." });
            AddEvent(new Event { Name = "Music Concert", Date = DateTime.Now.AddDays(3), Category = "Music", Description = "Enjoy live music from local bands." });

            AddAnnouncement(new Announcement { Title = "Community Clean-Up", Date = DateTime.Now.AddDays(2), Description = "Join us for a community clean-up day!" });
            AddAnnouncement(new Announcement { Title = "Town Hall Meeting", Date = DateTime.Now.AddDays(7), Description = "Participate in the town hall meeting to discuss local issues." });

            categories.Add("Announcement");
        }

        private void AddEvent(Event newEvent)
        {
            if (newEvent.Date.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Event date must be in the future.", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!events.ContainsKey(newEvent.Date))
            {
                events[newEvent.Date] = new List<Event>();
            }
            events[newEvent.Date].Add(newEvent);
            categories.Add(newEvent.Category);
            UpdateEventQueue();
        }

        private void AddAnnouncement(Announcement newAnnouncement)
        {
            if (newAnnouncement.Date.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Announcement date must be in the future.", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!announcements.ContainsKey(newAnnouncement.Date))
            {
                announcements[newAnnouncement.Date] = new List<Announcement>();
            }
            announcements[newAnnouncement.Date].Add(newAnnouncement);
        }

        private void UpdateEventQueue()
        {
            var orderedEvents = events.Values.SelectMany(x => x).OrderBy(ev => ev.Date);
            eventQueue = new Queue<Event>(orderedEvents);
        }

        private void PopulateEventAndAnnouncementList()
        {
            listViewEvents.Items.Clear();

            foreach (var eventList in events)
            {
                foreach (var ev in eventList.Value)
                {
                    var item = CreateListViewItem(ev.Name, ev.Date, ev.Category, ev.Description);
                    listViewEvents.Items.Add(item);
                }
            }

            foreach (var announcementList in announcements)
            {
                foreach (var ann in announcementList.Value)
                {
                    var item = CreateListViewItem(ann.Title, ann.Date, "Announcement", ann.Description);
                    listViewEvents.Items.Add(item);
                }
            }

            comboBoxCategory.Items.Clear();
            comboBoxCategory.Items.AddRange(categories.ToArray());
        }

        private ListViewItem CreateListViewItem(string title, DateTime date, string category, string description)
        {
            var item = new ListViewItem(title);
            item.SubItems.Add(date.ToString("MM/dd/yyyy"));
            item.SubItems.Add(category);
            item.SubItems.Add(description);
            item.Tag = category;

            item.BackColor = GetCategoryColor(category);

            return item;
        }

        private void ListViewEvents_MouseMove(object sender, MouseEventArgs e)
        {
            var item = listViewEvents.GetItemAt(e.X, e.Y);
            if (item != null && item != highlightedItem)
            {
                if (highlightedItem != null)
                {
                    highlightedItem.BackColor = GetCategoryColor((string)highlightedItem.Tag);
                }

                item.BackColor = Color.LightGray;
                highlightedItem = item;
            }
        }

        private Color GetCategoryColor(string category)
        {
            if (category == "Music")
            {
                return Color.LightSalmon;
            }
            else if (category == "Art")
            {
                return Color.LightSkyBlue;
            }
            else if (category == "Food")
            {
                return Color.LightGoldenrodYellow;
            }
            else if (category == "Announcement")
            {
                return Color.LightGreen;
            }
            else
            {
                return Color.White;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchCategory = comboBoxCategory.SelectedItem?.ToString();
            DateTime selectedDate = dateTimePicker.Value.Date;

            if (string.IsNullOrEmpty(searchCategory))
            {
                MessageBox.Show("Please select a category before searching.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filteredEvents = events.Values.SelectMany(x => x)
                .Where(ev => ev.Category.Equals(searchCategory, StringComparison.OrdinalIgnoreCase) && ev.Date.Date == selectedDate);

            var filteredAnnouncements = announcements.Values.SelectMany(x => x)
                .Where(ann => ann.Date.Date == selectedDate && searchCategory.Equals("Announcement", StringComparison.OrdinalIgnoreCase));

            listViewEvents.Items.Clear();

            if (!filteredEvents.Any() && !filteredAnnouncements.Any())
            {
                MessageBox.Show("No events or announcements found matching your search criteria.", "No Results", MessageBoxButtons.OK);
                return;
            }

            foreach (var ev in filteredEvents)
            {
                var item = CreateListViewItem(ev.Name, ev.Date, ev.Category, ev.Description);
                listViewEvents.Items.Add(item);
            }

            foreach (var ann in filteredAnnouncements)
            {
                var item = CreateListViewItem(ann.Title, ann.Date, "Announcement", ann.Description);
                listViewEvents.Items.Add(item);
            }

            UpdateUserSearchHistory(searchCategory, filteredEvents);
            DisplayRecommendations(selectedDate);
        }

        private void UpdateUserSearchHistory(string searchCategory, IEnumerable<Event> filteredEvents)
        {
            if (!userSearchHistory.ContainsKey(searchCategory))
            {
                userSearchHistory[searchCategory] = (new List<Event>(), 0);
            }
            userSearchHistory[searchCategory].Item1.AddRange(filteredEvents);
            userSearchHistory[searchCategory] = (userSearchHistory[searchCategory].Item1, userSearchHistory[searchCategory].Item2 + 1);

            SaveSearchHistory();
        }

        private void SaveSearchHistory()
        {
            using (StreamWriter writer = new StreamWriter("searchHistory.txt"))
            {
                foreach (var entry in userSearchHistory)
                {
                    writer.WriteLine($"{entry.Key};{entry.Value.Item2};{string.Join(",", entry.Value.Item1.Select(e => e.Name))}");
                }
            }
        }

        private void LoadSearchHistory()
        {
            if (File.Exists("searchHistory.txt"))
            {
                using (StreamReader reader = new StreamReader("searchHistory.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(';');
                        var category = parts[0];
                        var count = int.Parse(parts[1]);
                        var eventsList = parts[2].Split(',').ToList();

                        userSearchHistory[category] = (eventsList.Select(e => new Event { Name = e }).ToList(), count);
                    }
                }
            }
        }

        private void DisplayRecommendations(DateTime selectedDate)
        {
            listViewRecommendations.Items.Clear();

            if (!userSearchHistory.Any())
            {
                listViewRecommendations.Items.Add(new ListViewItem(new[] { "No recommendations available.", "", "" }));
                return;
            }

            var allEvents = events.Values.SelectMany(x => x).Where(ev => ev.Date.Date == selectedDate).ToList();
            var popularEvents = userSearchHistory
                .OrderByDescending(kvp => kvp.Value.Item2)
                .SelectMany(kvp => kvp.Value.Item1)
                .Distinct()
                .Where(ev => ev.Date.Date == selectedDate)
                .Take(5)
                .ToList();

            var recommendedEvents = allEvents
                .Where(ev => !popularEvents.Any(pe => pe.Name == ev.Name))
                .OrderBy(ev => ev.Date)
                .Take(5)
                .Concat(popularEvents)
                .Distinct()
                .ToList();

            foreach (var ev in recommendedEvents)
            {
                var item = CreateListViewItem(ev.Name, ev.Date, ev.Category, ev.Description);
                listViewRecommendations.Items.Add(item);
            }
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (listViewEvents.SelectedItems.Count > 0)
            {
                var selectedItem = listViewEvents.SelectedItems[0];
                var eventName = selectedItem.Text;

                foreach (var eventList in events.Values)
                {
                    var eventToRemove = eventList.FirstOrDefault(ev => ev.Name == eventName);
                    if (eventToRemove != null)
                    {
                        eventList.Remove(eventToRemove);
                        break;
                    }
                }

                foreach (var announcementList in announcements.Values)
                {
                    var announcementToRemove = announcementList.FirstOrDefault(ann => ann.Title == eventName);
                    if (announcementToRemove != null)
                    {
                        announcementList.Remove(announcementToRemove);
                        break;
                    }
                }

                PopulateEventAndAnnouncementList();
            }
            else
            {
                MessageBox.Show("Please select an event or announcement to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFilterByCategory_Click(object sender, EventArgs e)
        {
            string selectedCategory = comboBoxCategory.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedCategory))
            {
                MessageBox.Show("Please select a category to filter.", "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filteredItems = listViewEvents.Items.Cast<ListViewItem>()
                .Where(item => item.Tag.ToString().Equals(selectedCategory, StringComparison.OrdinalIgnoreCase))
                .ToList();

            listViewEvents.Items.Clear();
            foreach (var item in filteredItems)
            {
                listViewEvents.Items.Add(item);
            }
        }

        private void btnSortByDate_Click(object sender, EventArgs e)
        {
            var sortedItems = listViewEvents.Items.Cast<ListViewItem>()
                .OrderBy(item => DateTime.Parse(item.SubItems[1].Text))
                .ToList();

            listViewEvents.Items.Clear();
            foreach (var item in sortedItems)
            {
                listViewEvents.Items.Add(item);
            }
        }

        private void btnSortByCategory_Click(object sender, EventArgs e)
        {
            var sortedItems = listViewEvents.Items.Cast<ListViewItem>()
                .OrderBy(item => item.Tag.ToString())
                .ToList();

            listViewEvents.Items.Clear();
            foreach (var item in sortedItems)
            {
                listViewEvents.Items.Add(item);
            }
        }

        private void btnSortByName_Click(object sender, EventArgs e)
        {
            var sortedItems = listViewEvents.Items.Cast<ListViewItem>()
                .OrderBy(item => item.Text)
                .ToList();

            listViewEvents.Items.Clear();
            foreach (var item in sortedItems)
            {
                listViewEvents.Items.Add(item);
            }
        }

        private void listViewEvents_DoubleClick(object sender, EventArgs e)
        {
            if (listViewEvents.SelectedItems.Count > 0)
            {
                var selectedItem = listViewEvents.SelectedItems[0];
                string message = selectedItem.Tag.ToString() == "Announcement"
                    ? "You selected an announcement."
                    : $"You selected event: {selectedItem.Text}";

                MessageBox.Show(message, "Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void labelCategory_Click(object sender, EventArgs e)
        {

        }

        private void listViewRecommendations_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
