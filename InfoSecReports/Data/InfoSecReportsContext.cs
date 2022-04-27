using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InfoSecReports.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class InfoSecReportsContext : IdentityDbContext
    {
        public InfoSecReportsContext (DbContextOptions<InfoSecReportsContext> options)
            : base(options)
        {
        //Database.EnsureDeleted();
        Database.EnsureCreated();   // создаем бд с новой схемой, если не создана
        }
        public DbSet<InfoSecReports.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<InfoSecReports.Models.Achievement> Achievement { get; set; }
        public DbSet<InfoSecReports.Models.EventOfObject> EventOfObject { get; set; }
        public DbSet<InfoSecReports.Models.Event> Event { get; set; }
        public DbSet<InfoSecReports.Models.FlawOfObject> FlawOfObject { get; set; }
        public DbSet<InfoSecReports.Models.Flaw> Flaw { get; set; }
        public DbSet<InfoSecReports.Models.ObjectOfVerification> ObjectOfVerification { get; set; }
        public DbSet<InfoSecReports.Models.Recomendation> Recomendation { get; set; }
        public DbSet<InfoSecReports.Models.ScriptOfObject> ScriptOfObject { get; set; }
        public DbSet<InfoSecReports.Models.Script> Script { get; set; }
        public DbSet<InfoSecReports.Models.WorkingGroup> WorkingGroup { get; set; }
        public DbSet<InfoSecReports.Models.Category> Category { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");

        modelBuilder.Entity<Achievement>().ToTable("Achievement")
            .HasOne(p => p.ObjectOfVerification)
            .WithMany(b => b.Achievement)
            .HasForeignKey(p => p.NameOfСompany)
            .HasPrincipalKey(b => b.Name);
        modelBuilder.Entity<EventOfObject>().ToTable("EventOfObject")
            .HasOne(p => p.ObjectOfVerification)
            .WithMany(b => b.EventOfObjects)
            .HasForeignKey(p => p.NameOfCompany)
            .HasPrincipalKey(b => b.Name);
        modelBuilder.Entity<Event>().ToTable("Event")
            .HasOne(p => p.Category)
            .WithMany(b => b.Event)
            .HasForeignKey(p => p.CategoryName)
            .HasPrincipalKey(b => b.Name);
        modelBuilder.Entity<FlawOfObject>().ToTable("FlawOfObject")
            .HasOne(p => p.ObjectOfVerification)
            .WithMany(b => b.FlawOfObjects)
            .HasForeignKey(p => p.NameOfCompany)
            .HasPrincipalKey(b => b.Name);
        modelBuilder.Entity<Flaw>().ToTable("Flaw")
            .HasOne(p => p.Category)
            .WithMany(b => b.Flaw)
            .HasForeignKey(p => p.CategoryName)
            .HasPrincipalKey(b => b.Name);
        modelBuilder.Entity<ObjectOfVerification>().ToTable("ObjectOfVerification");
        modelBuilder.Entity<Recomendation>().ToTable("Recomendation")
            .HasOne(p => p.Category)
            .WithMany(b => b.Recomendation)
            .HasForeignKey(p => p.CategoryName)
            .HasPrincipalKey(b => b.Name);
        modelBuilder.Entity<ScriptOfObject>().ToTable("ScriptOfObject")
            .HasOne(p => p.ObjectOfVerification)
            .WithMany(b => b.ScriptOfObject )
            .HasForeignKey(p => p.NameOfCompany)
            .HasPrincipalKey(b => b.Name);
        modelBuilder.Entity<Script>().ToTable("Script");
        modelBuilder.Entity<WorkingGroup>().ToTable("WorkingGroup")
            .HasOne(p => p.ObjectOfVerification)
            .WithMany(b => b.WorkingGroup)
            .HasForeignKey(p => p.NameOfСompany)
            .HasPrincipalKey(b => b.Name);
        modelBuilder.Entity<Category>().ToTable("Category");
    }


    public DbSet<InfoSecReports.Models.Member> Member { get; set; }
    }
