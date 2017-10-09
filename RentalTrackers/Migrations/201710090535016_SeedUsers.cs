namespace RentalTrackers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql
            (@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0d9d5d39-f655-41b4-b36d-264e208dee2c', N'guest@gmail.com', 0, N'AHhdkirCVC1F2rCkrfz6rXSEZ4qrUKIR7p1ExyUJnFL4c/2FJpzddYZyywlOwvdUZw==', N'c12b3db7-3000-4be2-8f24-b0ad8a38cf34', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'58c80c2a-2c71-4965-b3a5-45c057883ec0', N'admin@MovieRentals.com', 0, N'ANpcfMl+3Jr6D3u8vSgrUiWGsDxD/7k66Er8Rm5CmCQRlzrdTnwRqI26V2jdnJIVnA==', N'575df434-9b5a-4e4c-9c7c-b36558893494', NULL, 0, 0, NULL, 1, 0, N'admin@MovieRentals.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'74f55912-c35d-4136-b32f-9a4b3f4727f7', N'admin2@MovieRentals.com', 0, N'ALoLZvRtXqKxjn07zqFBvTgLgQTSxmMU7+3fzyk9f7HdU693+X9Yo6lt5DHhraTwvg==', N'73ce679d-0d00-45ca-939e-3d5f2b30562a', NULL, 0, 0, NULL, 1, 0, N'admin2@MovieRentals.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'febf4945-23ad-41b5-93c0-8100e96657c5', N'thienng93@gmail.com', 0, N'ALdhRveXJ83tTTwjcbYcaLM1VHK6BP/pRxWm6gXbLNoeEFwFeIIjBXH4Gp9RUgBx7Q==', N'3cf598df-b1ea-47b6-9d8d-4d7e55fc9cb3', NULL, 0, 0, NULL, 1, 0, N'thienng93@gmail.com')
            
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4c3fe33b-abba-4fee-b863-0072a6d165a9', N'CanManageMovie')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'889bff38-bccb-4e72-a885-ebd54a126da5', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'74f55912-c35d-4136-b32f-9a4b3f4727f7', N'889bff38-bccb-4e72-a885-ebd54a126da5')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
