namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'690c3ce8-d1f2-452d-a234-3f3d937cf93a', N'admin@gmail.com', 0, N'APJlDOILTON7m5CXDmRXlfK/7NvyeLC41mapevrARh8DknVPoSbAM3DczuvQ50n1kw==', N'b0784c50-a861-452f-9fb6-ed7c766d7e0c', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'84d844ca-b2a3-482c-a359-d80bc2cb5d81', N'admin1@gmail.com', 0, N'APVRO0Y7xlXhOD/CSGRjTAiW+t75n73mHzuV6zRvOmao+fPZ7Bgxk/rgKezpQcO9qw==', N'ce78bb08-cd4a-4fbf-a6cb-5cb146d76dd6', NULL, 0, 0, NULL, 1, 0, N'admin1@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'969bf222-846f-4e1a-8bb6-f0912f3c0fe2', N'admin3@gmail.com', 0, N'AIGJ8/zWzTEXOJksBaXSwCZoEOo64CKivW86hyhG587id3M3ACTuY08xtGesvso+wA==', N'b5470624-83c5-4f77-9795-5f4bcdbe9835', NULL, 0, 0, NULL, 1, 0, N'admin3@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'008888c0-a915-4e01-b532-21dbf013518c', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'690c3ce8-d1f2-452d-a234-3f3d937cf93a', N'008888c0-a915-4e01-b532-21dbf013518c')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'84d844ca-b2a3-482c-a359-d80bc2cb5d81', N'008888c0-a915-4e01-b532-21dbf013518c')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'969bf222-846f-4e1a-8bb6-f0912f3c0fe2', N'008888c0-a915-4e01-b532-21dbf013518c')

");
        }
        
        public override void Down()
        {
        }
    }
}
