namespace SportSectionWPF2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inith : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AchievementEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompetitionName = c.String(),
                        Points = c.String(),
                        Awards = c.String(),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberEntities", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.MemberEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AttendancesEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsPresent = c.Boolean(nullable: false),
                        Schedule_Id = c.Int(),
                        MemberEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScheduleEntities", t => t.Schedule_Id)
                .ForeignKey("dbo.MemberEntities", t => t.MemberEntity_Id)
                .Index(t => t.Schedule_Id)
                .Index(t => t.MemberEntity_Id);
            
            CreateTable(
                "dbo.ScheduleEntities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        BeginTime = c.String(),
                        EndingTime = c.String(),
                        SectionEntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SectionEntities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SectionEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CoachId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoachEntities", t => t.CoachId)
                .Index(t => t.CoachId);
            
            CreateTable(
                "dbo.CoachEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdminEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SectionEntityMemberEntities",
                c => new
                    {
                        SectionEntity_Id = c.Int(nullable: false),
                        MemberEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SectionEntity_Id, t.MemberEntity_Id })
                .ForeignKey("dbo.SectionEntities", t => t.SectionEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.MemberEntities", t => t.MemberEntity_Id, cascadeDelete: true)
                .Index(t => t.SectionEntity_Id)
                .Index(t => t.MemberEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminEntities", "UserId", "dbo.UserEntities");
            DropForeignKey("dbo.MemberEntities", "UserId", "dbo.UserEntities");
            DropForeignKey("dbo.AttendancesEntities", "MemberEntity_Id", "dbo.MemberEntities");
            DropForeignKey("dbo.ScheduleEntities", "Id", "dbo.SectionEntities");
            DropForeignKey("dbo.SectionEntityMemberEntities", "MemberEntity_Id", "dbo.MemberEntities");
            DropForeignKey("dbo.SectionEntityMemberEntities", "SectionEntity_Id", "dbo.SectionEntities");
            DropForeignKey("dbo.SectionEntities", "CoachId", "dbo.CoachEntities");
            DropForeignKey("dbo.CoachEntities", "UserId", "dbo.UserEntities");
            DropForeignKey("dbo.AttendancesEntities", "Schedule_Id", "dbo.ScheduleEntities");
            DropForeignKey("dbo.AchievementEntities", "MemberId", "dbo.MemberEntities");
            DropIndex("dbo.SectionEntityMemberEntities", new[] { "MemberEntity_Id" });
            DropIndex("dbo.SectionEntityMemberEntities", new[] { "SectionEntity_Id" });
            DropIndex("dbo.AdminEntities", new[] { "UserId" });
            DropIndex("dbo.CoachEntities", new[] { "UserId" });
            DropIndex("dbo.SectionEntities", new[] { "CoachId" });
            DropIndex("dbo.ScheduleEntities", new[] { "Id" });
            DropIndex("dbo.AttendancesEntities", new[] { "MemberEntity_Id" });
            DropIndex("dbo.AttendancesEntities", new[] { "Schedule_Id" });
            DropIndex("dbo.MemberEntities", new[] { "UserId" });
            DropIndex("dbo.AchievementEntities", new[] { "MemberId" });
            DropTable("dbo.SectionEntityMemberEntities");
            DropTable("dbo.AdminEntities");
            DropTable("dbo.UserEntities");
            DropTable("dbo.CoachEntities");
            DropTable("dbo.SectionEntities");
            DropTable("dbo.ScheduleEntities");
            DropTable("dbo.AttendancesEntities");
            DropTable("dbo.MemberEntities");
            DropTable("dbo.AchievementEntities");
        }
    }
}
