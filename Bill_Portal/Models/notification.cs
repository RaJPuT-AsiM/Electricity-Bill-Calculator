using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required(ErrorMessage ="*")]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
    }
}
