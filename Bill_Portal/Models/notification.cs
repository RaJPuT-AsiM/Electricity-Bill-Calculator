using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Bill_Portal.Models
{
    public class notification
    {
        [Key]
        [Display(Name ="Id")]
        public int notification_id { get; set; }

        [Display(Name = "Sr No.")]
        public string notification_serial { get; set; }

        [Display(Name = "Title")]
        public string notification_title { get; set; }

        [Display(Name = "Image")]
        public string notification_document { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Date")]
        public DateTime date { get; set; }
    }
}
