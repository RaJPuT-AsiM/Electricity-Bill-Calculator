using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bill_Portal.Models
{
    public partial class Billing_Portal_DbContext : IdentityDbContext<BillUsers>
    {
        public Billing_Portal_DbContext()
        {
        }

        public Billing_Portal_DbContext(DbContextOptions<Billing_Portal_DbContext> options)
            : base(options)
        {
        }
    }
}