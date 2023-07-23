using Cimeri.Domain.DomainModels;
using Cimeri.Domain.Identity;


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cimeri.Repository
{
    public class ApplicationDbContext : IdentityDbContext<CimeriApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<CimeriPost> CimeriPost { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

           
        }
    }
}
