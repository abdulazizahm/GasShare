using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Repository.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //DBsets
        public DbSet<Car> Cars { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Complain> Complains { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<JourneyRate> JourneyRates { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Request_Photo> Request_Photos { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<UserRate> UserRates { get; set; }

        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
        }

       
    }
}
