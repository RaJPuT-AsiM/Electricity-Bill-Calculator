using System;
using System.Collections.Generic;

namespace Bill_Portal.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string UserRole { get; set; }
        public int UserRoleId { get; set; }
    }
}
