Create database test_db
USE test_db



CREATE TABLE [dbo].[tbl_customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[CreditLimit] [int] NULL DEFAULT ((0)),
        [IsActive] [bit] NULL DEFAULT ((1)),
		[Code] [varchar](50) Null,
 CONSTRAINT [PK_tbl_customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[tbl_user](
	[userid] [varchar](50) NOT NULL,
	[Name] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
	[IsActive] [bit] NULL DEFAULT ((1)),
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




GO
INSERT [dbo].[tbl_customer] ( [Name], [Email], [Phone], [CreditLimit]) VALUES ( N'Jamison', N'jami@gmail.com', N'7878786775', 0)
GO






















/scaffold commands/
Scaffold-DbContext "Server=SRV2022\SQLEXPRESS;DataBase=test_db;Trusted_Connection=True;TrustServerCertificate=True;"Microsoft.EntityFrameworkCore.SqlServer -OutputDir Repos/Models -context LearnDataContext -f -contextDir Repos -DataAnnotations