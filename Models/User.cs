using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tracker.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public ICollection<Entry>? Entries { get; set; }
        //public virtual ICollection<Entries> Entries { get; set; }


    }
}
