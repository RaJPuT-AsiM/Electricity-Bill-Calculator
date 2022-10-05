using System;
using System.ComponentModel.DataAnnotations;

namespace Bill_Portal.Models
{
    public class tariff_group
    {
        [Key]
        public int tariff_group_Id { get; set; }
        public string tariff_group_code { get; set; }
        public string tariff_group_name { get; set; }
        public bool current_status { get; set; }
        public DateTime date { get; set; }
        public int notification_id { get; set; }
        //        public virtual notification disco_notification { get; set; }
    }
}
