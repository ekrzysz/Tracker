using System.Runtime.Serialization;
using System.Text.Json;

namespace Tracker.Models
{
    public class Entries
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int BreakTime { get; set; }

        public int WorkTime { get; set; }

        // Method to serialize an Entries object to JSON

    }
}
