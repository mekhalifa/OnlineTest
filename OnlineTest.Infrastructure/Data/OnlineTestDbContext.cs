using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineTest.Core.Models;
using OnlineTest.Infrastructure.Data.IdentityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Infrastructure.Data
{
    public class OnlineTestDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public OnlineTestDbContext(DbContextOptions<OnlineTestDbContext> options)
            :base(options)
        {

        }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamQuestion>().HasKey(sc => new { sc.ExamId, sc.QuestionId });

            modelBuilder.Entity<ExamQuestion>()
                   .HasOne<Exam>(sc => sc.Exam)
                   .WithMany(s => s.ExamQuestions)
                   .HasForeignKey(sc => sc.ExamId);


            modelBuilder.Entity<ExamQuestion>()
                .HasOne<Question>(sc => sc.Question)
                .WithMany(s => s.ExamQuestions)
                .HasForeignKey(sc => sc.QuestionId);


            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<UserAnswer> UserAnswers { get; set; }
        
    }
}
