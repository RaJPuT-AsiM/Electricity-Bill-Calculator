using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Http;

namespace Bill_Portal.ViewModels
{
    public class NotificationViewModel
    {
        
        [Display(Name = "Id")]
        public int notification_id { get; set; }

        [Required(ErrorMessage ="*")]
        [Display(Name = "Sr No.")]
        public string notification_serial { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Title")]
        public string notification_title { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Image")]
        public IFormFile notification_image { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        public string notification_image_url { get; set; }
    }
}
