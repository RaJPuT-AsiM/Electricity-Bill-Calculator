using Microsoft.VisualBasic;

namespace Bill_Portal.Models
{
    public class disco
    {
        [key]
        public int disco_id { get; set; }
        public string disco_name { get; set; }
        public bool current_status { get; set; }
        public DateAndTime date { get; set; }

        public int notification_id { get; set; }
        public virtual notification disco_notification { get; set; }
    }
}

