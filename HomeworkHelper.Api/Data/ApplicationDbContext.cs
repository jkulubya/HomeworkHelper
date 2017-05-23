using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HomeworkHelper.Api.Models;

namespace HomeworkHelper.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(e =>
            {
                e.HasOne(l => l.LearnerProfile)
                    .WithOne(l => l.User)
                    .HasForeignKey<LearnerProfile>(l => l.UserId);
            });

            builder.Entity<LearnerProfile>(e =>
            {
                e.HasKey(l => l.UserId);
                e.HasMany(l => l.QuestionsAsked)
                    .WithOne(q => q.Author)
                    .HasForeignKey(d => d.AuthorId)
                    .HasPrincipalKey(t => t.UserId);
            });

            builder.Entity<Question>(e =>
            {
                e.HasKey(q => q.Id);
                e.HasMany(q => q.Answers)
                    .WithOne(a => a.Question)
                    .HasForeignKey(a => a.QuestionId)
                    .HasPrincipalKey(q => q.Id);
            });

            builder.Entity<Answer>(e =>
            {
                e.HasKey(a => a.Id);
            });
        }

        public DbSet<LearnerProfile> LearnerProfiles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
