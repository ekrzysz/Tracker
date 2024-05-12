using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tracker.Models
{
    public class Entry
    {
        //[Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int BreakTime { get; set; }

        public int WorkTime { get; set; }

        //[ForeignKey(nameof(UserId))
        public int UserId { get; set; }
        [JsonIgnore]
        public User? Users { get; set; }
        // Method to serialize an Entries object to JSON

    }
}
