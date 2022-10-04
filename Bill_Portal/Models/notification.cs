using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Bill_Portal.Models
{
    public class notification
    {
        [Key]
        public int notification_id { get; set; }
        public string notification_serial { get; set; }
        public string notification_title { get; set; }
        public Blob notification_document { get; set; }
        public string description { get; set; }
        public DateAndTime date { get; set; }
    }
}
