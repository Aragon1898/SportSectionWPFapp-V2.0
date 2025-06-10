using SportSectionWPF2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSectionWPF2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("SportSectionDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Migrations.Configuration>());
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AchievementEntity> Achievements { get; set; }
        public DbSet<CoachEntity> Coachs { get; set; }
        public DbSet<AttendancesEntity> Attendances { get; set; }
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<ScheduleEntity> Schedules { get; set; }
        public DbSet<SectionEntity> Sections { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SectionEntity>()
                .HasOptional(s => s.Schedule)
                .WithRequired(sch => sch.Section);

            base.OnModelCreating(modelBuilder);
        }

    }
}