USE [test_db]
GO
/****** Object:  StoredProcedure [dbo].[sp_getcustomer_custom]    Script Date: 28-04-24 15:39:48 ******/
DROP PROCEDURE [dbo].[sp_getcustomer_custom]
GO
/****** Object:  StoredProcedure [dbo].[sp_getcustomer]    Script Date: 28-04-24 15:39:48 ******/
DROP PROCEDURE [dbo].[sp_getcustomer]
GO
/****** Object:  StoredProcedure [dbo].[sp_deletecustomer]    Script Date: 28-04-24 15:39:48 ******/
DROP PROCEDURE [dbo].[sp_deletecustomer]
GO
/****** Object:  StoredProcedure [dbo].[sp_createcustomer]    Script Date: 28-04-24 15:39:48 ******/
DROP PROCEDURE [dbo].[sp_createcustomer]
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 28-04-24 15:39:48 ******/
DROP TABLE [dbo].[tbl_user]
GO
/****** Object:  Table [dbo].[tbl_tempuser]    Script Date: 28-04-24 15:39:48 ******/
DROP TABLE [dbo].[tbl_tempuser]
GO
/****** Object:  Table [dbo].[tbl_rolepermission]    Script Date: 28-04-24 15:39:48 ******/
DROP TABLE [dbo].[tbl_rolepermission]
GO
/****** Object:  Table [dbo].[tbl_role]    Script Date: 28-04-24 15:39:48 ******/
DROP TABLE [dbo].[tbl_role]
GO
/****** Object:  Table [dbo].[tbl_refreshtoken]    Script Date: 28-04-24 15:39:48 ******/
DROP TABLE [dbo].[tbl_refreshtoken]
GO
/****** Object:  Table [dbo].[tbl_pwdManger]    Script Date: 28-04-24 15:39:48 ******/
DROP TABLE [dbo].[tbl_pwdManger]
GO
/****** Object:  Table [dbo].[tbl_productimage]    Script Date: 28-04-24 15:39:48 ******/
DROP TABLE [dbo].[tbl_productimage]
GO
/****** Object:  Table [dbo].[tbl_product]    Script Date: 28-04-24 15:39:48 ******/
DROP TABLE [dbo].[tbl_product]
GO
/****** Object:  Table [dbo].[tbl_otpManager]    Script Date: 28-04-24 15:39:48 ******/
DROP TABLE [dbo].[tbl_otpManager]
GO
/****** Object:  Table [dbo].[tbl_menu]    Script Date: 28-04-24 15:39:48 ******/
DROP TABLE [dbo].[tbl_menu]
GO
/****** Object:  Table [dbo].[tbl_customer]    Script Date: 28-04-24 15:39:48 ******/
DROP TABLE [dbo].[tbl_customer]
GO
/****** Object:  User [local]    Script Date: 28-04-24 15:39:48 ******/
DROP USER [local]
GO
USE [master]
GO
/****** Object:  Database [test_db]    Script Date: 28-04-24 15:39:48 ******/
DROP DATABASE [test_db]
GO
/****** Object:  Database [test_db]    Script Date: 28-04-24 15:39:48 ******/
CREATE DATABASE [test_db]

ALTER DATABASE [test_db] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [test_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [test_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [test_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [test_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [test_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [test_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [test_db] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [test_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [test_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [test_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [test_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [test_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [test_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [test_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [test_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [test_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [test_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [test_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [test_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [test_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [test_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [test_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [test_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [test_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [test_db] SET  MULTI_USER 
GO
ALTER DATABASE [test_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [test_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [test_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [test_db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [test_db] SET DELAYED_DURABILITY = DISABLED 
GO
USE [test_db]
GO
/****** Object:  User [local]    Script Date: 28-04-24 15:39:49 ******/
CREATE USER [local] FOR LOGIN [local] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[tbl_customer]    Script Date: 28-04-24 15:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_customer](
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Creditlimit] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[Taxcode] [int] NULL,
 CONSTRAINT [PK_tbl_customer] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_menu]    Script Date: 28-04-24 15:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_menu](
	[code] [nvarchar](50) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_tbl_menu] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_otpManager]    Script Date: 28-04-24 15:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_otpManager](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[otptext] [varchar](10) NOT NULL,
	[otptype] [varchar](20) NULL,
	[expiration] [datetime] NOT NULL,
	[createddate] [datetime] NULL,
 CONSTRAINT [PK_tbl_otpManager] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_product]    Script Date: 28-04-24 15:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_product](
	[code] [varchar](50) NOT NULL,
	[name] [varchar](max) NULL,
	[price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tbl_product] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_productimage]    Script Date: 28-04-24 15:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_productimage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productcode] [varchar](50) NULL,
	[productimage] [image] NULL,
 CONSTRAINT [PK_tbl_productimage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_pwdManger]    Script Date: 28-04-24 15:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_pwdManger](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](200) NOT NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_pwdManger] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_refreshtoken]    Script Date: 28-04-24 15:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_refreshtoken](
	[userid] [varchar](50) NOT NULL,
	[tokenid] [varchar](50) NULL,
	[refreshtoken] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_refreshtoken] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_role]    Script Date: 28-04-24 15:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_role](
	[code] [nvarchar](50) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_tbl_role] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_rolepermission]    Script Date: 28-04-24 15:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_rolepermission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userrole] [nvarchar](50) NOT NULL,
	[menucode] [nvarchar](50) NOT NULL,
	[haveview] [bit] NOT NULL,
	[haveadd] [bit] NOT NULL,
	[haveedit] [bit] NOT NULL,
	[havedelete] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_rolepermission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_tempuser]    Script Date: 28-04-24 15:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_tempuser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](50) NOT NULL,
	[name] [varchar](250) NOT NULL,
	[email] [varchar](100) NULL,
	[phone] [varchar](20) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [tbl_tempuser1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 28-04-24 15:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_user](
	[username] [varchar](50) NOT NULL,
	[name] [varchar](250) NOT NULL,
	[email] [varchar](100) NULL,
	[phone] [varchar](20) NULL,
	[password] [varchar](50) NULL,
	[isactive] [bit] NULL,
	[role] [varchar](50) NULL,
	[islocked] [bit] NULL,
	[failattempt] [int] NULL,
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tbl_customer] ([Code], [Name], [Email], [Phone], [Creditlimit], [IsActive], [Taxcode]) VALUES (N'002', N'Nihira Techiees', N'nihiratechiees@gmail.com', N'899000000', CAST(2000.00 AS Decimal(18, 2)), 1, 2)
GO
INSERT [dbo].[tbl_customer] ([Code], [Name], [Email], [Phone], [Creditlimit], [IsActive], [Taxcode]) VALUES (N'010', N'Akil', N'akil@in.com', N'8000899000', CAST(34044.00 AS Decimal(18, 2)), 1, 2)
GO
INSERT [dbo].[tbl_customer] ([Code], [Name], [Email], [Phone], [Creditlimit], [IsActive], [Taxcode]) VALUES (N'020', N'Rakesh', N'ra@in.com', N'999999', CAST(20000.00 AS Decimal(18, 2)), 1, NULL)
GO
INSERT [dbo].[tbl_customer] ([Code], [Name], [Email], [Phone], [Creditlimit], [IsActive], [Taxcode]) VALUES (N'022', N'Ram kumar', N'ram@in.com', N'67899999', NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_customer] ([Code], [Name], [Email], [Phone], [Creditlimit], [IsActive], [Taxcode]) VALUES (N'023', N'Rahim', N'rahim@in.com', N'788999', CAST(100.00 AS Decimal(18, 2)), 1, NULL)
GO
INSERT [dbo].[tbl_menu] ([code], [name], [status]) VALUES (N'customer', N'Customer', 1)
GO
INSERT [dbo].[tbl_menu] ([code], [name], [status]) VALUES (N'invoice', N'Invoice', 1)
GO
INSERT [dbo].[tbl_menu] ([code], [name], [status]) VALUES (N'reports', N'Reports', 1)
GO
INSERT [dbo].[tbl_menu] ([code], [name], [status]) VALUES (N'user', N'Users', 1)
GO
INSERT [dbo].[tbl_menu] ([code], [name], [status]) VALUES (N'userrole', N'Userrole', 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_otpManager] ON 

GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (1, N'admin', N'916455', N'register', CAST(N'2024-03-27 21:20:01.977' AS DateTime), CAST(N'2024-03-27 20:50:01.977' AS DateTime))
GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (2, N'ntuser', N'161189', N'register', CAST(N'2024-03-27 21:21:17.657' AS DateTime), CAST(N'2024-03-27 20:51:17.657' AS DateTime))
GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (3, N'ntuser', N'521468', N'forgetpassword', CAST(N'2024-03-27 21:23:54.183' AS DateTime), CAST(N'2024-03-27 20:53:54.183' AS DateTime))
GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (4, N'ntuser1', N'080171', N'register', CAST(N'2024-03-29 08:07:46.450' AS DateTime), CAST(N'2024-03-29 07:37:46.450' AS DateTime))
GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (5, N'ntuser1', N'184329', N'forgetpassword', CAST(N'2024-03-29 08:11:12.340' AS DateTime), CAST(N'2024-03-29 07:41:12.340' AS DateTime))
GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (6, N'string', N'429701', N'register', CAST(N'2024-03-29 15:58:40.440' AS DateTime), CAST(N'2024-03-29 15:28:40.440' AS DateTime))
GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (1004, N'testuser', N'899099', N'register', CAST(N'2024-03-30 19:58:44.210' AS DateTime), CAST(N'2024-03-30 19:28:44.210' AS DateTime))
GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (1005, N'testuser1', N'858157', N'register', CAST(N'2024-03-30 22:24:57.443' AS DateTime), CAST(N'2024-03-30 21:54:57.443' AS DateTime))
GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (1006, N'testuser1', N'305406', N'forgetpassword', CAST(N'2024-04-03 21:56:30.717' AS DateTime), CAST(N'2024-04-03 21:26:30.717' AS DateTime))
GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (1007, N'testuser1', N'160243', N'forgetpassword', CAST(N'2024-04-03 22:03:10.917' AS DateTime), CAST(N'2024-04-03 21:33:10.917' AS DateTime))
GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (1008, N'testuser1', N'500184', N'forgetpassword', CAST(N'2024-04-03 22:13:21.933' AS DateTime), CAST(N'2024-04-03 21:43:21.933' AS DateTime))
GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (1009, N'ntech', N'940336', N'register', CAST(N'2024-04-05 23:06:52.730' AS DateTime), CAST(N'2024-04-05 22:36:52.730' AS DateTime))
GO
INSERT [dbo].[tbl_otpManager] ([id], [username], [otptext], [otptype], [expiration], [createddate]) VALUES (1010, N'ntech', N'159286', N'forgetpassword', CAST(N'2024-04-05 23:09:21.160' AS DateTime), CAST(N'2024-04-05 22:39:21.160' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tbl_otpManager] OFF
GO
INSERT [dbo].[tbl_product] ([code], [name], [price]) VALUES (N'001', N'bat', CAST(1000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tbl_product] ([code], [name], [price]) VALUES (N'002', N'ball', CAST(120.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tbl_product] ([code], [name], [price]) VALUES (N'003', N'pad', CAST(1200.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[tbl_productimage] ON 

GO
INSERT [dbo].[tbl_productimage] ([id], [productcode], [productimage]) VALUES (1, N'002', 0xFFD8FFE000104A46494600010100000100010000FFDB0084000906071012120F10100D0F0E100F121010100F120F0F0F100F0F1611171615151515191D3420181A251B131521312225352B2E2F2E171F333C332C37292D2E2B010A0A0A0E0D0E1B10101A2B251D252D2B2D372F372D2D2D2F2E2D2D2B2D2B2D2C372D2D2B2B2D35302D322D2B352B35312D2B372D2E2D2D2B362F2B2B2B2D2D37FFC00011080190006503012200021101031101FFC4001C0001000203010101000000000000000000000205010406030708FFC400431000020102020606050A050207000000000001020311043105061221417132335161B1B213227273810714233442628291A1C12452B3C3D115F01653637492A2C2FFC400190101000301010000000000000000000000000103040205FFC4002B110100010303030204070000000000000000010203111221310432415171136191F0223381A1D1E1F1FFDA000C03010002110311003F00FB88000000000000000000000000000000000001ABA4B10E14DCA3D2DC971B37C4DA2BB4F3FA2BF0528FEEBF70292B62EB3DEEBD4F838C7C11EDABBA5EA4ABCE8549B9A74DD48376DA4E3249ABACFA5FA1A75A6AD9A35B559ED639B4EEA142A5ED92BCE097FBEE18C3A776000E4000000000000000034F4BF553FC3E746E1A3A6FA99FE0F3C40E76BE5912D4A8FD3631DADBA82F85EA7F83CEAE5C7F367B6A575B8DE587E37FF9A4A5D6000840000000000000000068E9AEA67F83CE8DE3534AAFA29FE1F320399A991EBA97D6E37961FF00BA42BE47AEA6AFA5C672A1E35094BAA0010800000000000000000D4D29D54FF0F991B66869B7F433E70F3A039FAF91EBA9BD6E2F950FEE1E35323D7537AEC672A1E35094BAB0010800000000000000000AFD3BD4CB9C3CE8B034B4C754F9C7C40E72791EBA9BD762FD9A1E35085527A9DD762FD9A3E35094BAB0010800000000000000000D2D30FE8DFB51F1374AED3DD57E3881455B227A9FD762FD9A3E333CEA644F541FF118BF628F8CC94BAC0010800000000000000000ADD3CBE8D7B71FDCB23434D7417B4BC1814335B86A8FD6315EC52F34855C8CEAA7D62BF7D387E927FE494BAC0010800000000000000000AED3924A11EF9AF2C8B1391D35AC9849D574238BA2E741BF491F491569E56BBDD75FB819A83565DB155171745BFCA71FF2692C7D3795583E528B34A3AC783C2D7A756B62E8D34EF0927523B5B12DCDD96FB26937C99297D1C18849349A69A6934D3BA69E4D3324200000000000002352564DF626FF0042479D7E8CBD97E007CFA1AE988AB89F9B6CC610DA9C2528DD4AF18C9FC37A383D65D1D41D6AD08A950B4E4DEC34DCDCACDBDFDED9D7CB0985C34E589AB55425294A6A752A28454A57BA8AE39DB89A188D77D1F06DC64EA4B8BA745ABBF6A564CBA2E51AF55346634C46FB6FEBE58E2CDFAA8C555E275676DF6F4F0E0BFE184F7A7579FA33D29684A11DD554E5D9B568DFBAF9FEA76B86D7C854EAB0D8AAB6DDEA46136B9A8B658D2D61DB5F4981C6C57DFC24A6BF28DDFE85917A989FCA8FAFF4E6AE96F4C63E34FD23F95851D2557094B0B0C338C61E8D7D1C939452518DB655F766CEC357748CEBD273A8A2A4A5B368A715D08BC9B7FCC7114B1B84C4354FD2476E1B953BCA9558649AD8959F05C0EC35529A8D3AD14DB51ACD26F36952A7999B31A223189CCB5534D515CCCCED885D800858000000001E7887EACFD99781E879E27A13F665E007E49D6EC4CDE371979B7B35EB4136DB6A0AA3B24DE49761DE6A2EA152F474F138D87A59D44A74E84F7C29C1ADDB717D2935C1EE5D973E7DADBF5DC76EBFF1388DDDBF48CFBCE88D234B11469D6A3252A738ACB38BB6F8B5C1ACAC46674C3AF2C694D3384C1C23E9AAD3A117BA104B7BB67B308ABBF81CF62FE52B47A85474AACE7523193841D1AD1539A5EAABB8D96FED3675CB53A9E3F627E96546B538B8C656DB838B77B4A3CFB1A3E6FA57E4FF004851BB54A38982BFAD465B4EDDAE0ED2F82B88C1395668DC6D59D65294DCE539B9CDBDF79B776FBB7BB9FA5B509DF0A9E7770DEF7BEA291F99741D292AF1528B8CA0DED4649C649F634F7A67E9BD42FAAC79C3FA14C4CEF08F0E8C004A0000000003CF11D19FB32F03D0F3C47467ECCBC00FC89AD3F5DC77FDD623FAB223A134D623093DBC3D5706FA50E953A9DD38E4F9E7DE8FA257F936F9D56C4E2258A74A3531159C611A6A4EDB5BDED37DB7E05968EF932C0D26A551D5C4B5BED524943E318A575DCEE446D1894F3BC2C65AD74A9E068E3B11174FD3422E34A3EB4A751AE8C2F9ADCDDDF0DE729475C74BE2EF2C0E8E82A49DB69A73DFD9E92528C5BEE4B711F962C3CD2C1B8AD9A308D582B2B42351ECD9776E5BB933CF5835A68470186580C77CDE74634D3C3C22D557B926A52FB297ACF8ED3B04ADEBE07135B092C5690A14A8E2E8D551838454652A0DC6369BDA77F5A4DADFC3BD9F4FF93FFAA479C3FA34CF9C69CC7CA185C260EA547571338D19E21B7796E49BBF7B9E5DD167D2750E1B3858C5E69C53E7E8A98C4F2E731C3A3001200000000042BF465ECBF02642B7465ECBF0038CC2496F8E4D36F9DC9D5894F82D24A756AD16D46AD29BD8FF00A90EEEF450EBD55D24E3FC3D7F470DFBA9C546535FCBB6F7C65CAD7145BAA76F38CFF8E66FD111AB3B671EDEEBED3BA43094A9B58BA94634E5B9C2A6CCBD277283E97248F98694D6BC0D393FF4DD198784F862AA518271EFA70CEFDEEDC99C9E32536E5E91CDCEFEB39ED39DFEF37BEE5C6AB6AC54C4CE2E7192A574FB25515F87647EF7E4774DB999C415DC8A6332E8FE4FB01571156588ACE53726DFA495DB9CF8CB7F05B9765ECB81F72D568254EA24AC955692EC4A10390C1D3A584A6B745592518ADC9DB28AEE4753A9759CF0EE6ED79D47276CAEE107B857BE34F11E7D65C5B9DE75777A7A42FC0070B400000000215BA32E4FC0990ADD19727E007C669EED2693CFD237F074AEBF465ED4D2F47D355C3D54A1B2D2527D09A693B3EC7BCD1D2B84D9C760EBA5D6374DBE0A71849ABF357FFC4E4F5AF18E38AAEB75EF0BF3F471B9A6D68EA6AA7338C51F498960AE8BBD3D35688CE6B99FD261D6693D50A15AA42A3841B8BBDE49B695B77B6BB99B55F1387C1C6D6DAA8F2826B6E5D8E4FECAFF00691C16175971308BA74EB4D46D95949C52FE56FA28D4A78D9C9B936DB7BE6DDDE7DAFB4D14F4F54CE2E571A7E5CCFBFDCAAAEE4C466D51F8BE7BC47B7DC3E85AC188DAA7424FD5934DF736E1093B776F3B5D458B58549AB3DA575D8FD1C371C1E3287A5F98C37DA4A2DF1B4551A6E5CB71F44D57EAEA7BD9792260AAB88A29B71F39FDDBEDDB9D755C9F3885C800E5680000000042B7465C9F813215BA32E4FC00E1EA534ED757B3525DCD64CF976B72A71C7623E70AAC612519436146F3B4236B37BADBA4AFC19F54A89ECFAA9395B75DD95F9F0394D2984A388A70C3635B8D6BB8D3AD6F5A33DCAFB5649A6F7E56B385ECDA31F4B77E1D79968BB4EA8C38CFF59A0A0DC53A37BC7E6F4A3B0E6B84AA57BDDC7EEC6DBFE0CD3ABA5A752D04A34E9DD6CD0A6AD14F24DACE52DF9B3D748EA6632954508D275E327685485B65FB57E87C7777B3AED5CD56A7834ABD771AD897D553DA4A319BDC946F9BDFD2E1D87A955EA288D4CF14676757A2E86CD3A2E51B4D528277CE2FD1C1497FE8BF23ACD58EAEA7BD97920725A21557B739BF56A3DA84654DD3A91565B9F2CADDD7BEF3ADD58EAEA7BD979627996A666B9995D5C6295C000D6A4000000002157A32E4FC0990ABD19727E0071D05B91AF8EC1C6A465092769593B6E76BDED7ECDD91B30C9196796D8AAC3616AC2138EDC673F59D2BAD98C777AAADC15F87044F09A3BD6752A5A5277DCF6256E8FDAD94DEF827D89FC0B0B6F27126251308D8BCD59EAEA7BD979225232EF567ABA9EF65E4897D8EE577385B800D8A000000000235729727E0488D5E8CB93F0038F864B9196469E4B9196796D8C712488F13284124B22EF567AB9FBD9792251CB22F3567AB9FBC7E489A2C772AB9C2DC006C500000000011AB94B93F02446A64F93F0038E864B919314F25C9196796D8C71328C7132840C48BCD59EAE7EF1F96251C8BCD5AEAE7EF1F96268B1DCA6E70B7001B1480000000046A64F93F02446A64F93F0038EA792E483314F25C9196796D87132478994209624CBDD5AEAE7EF1F96250B2FB56BAB9FBC9796269B1DCA6E70B7001AD480000000046793E4C918964C0E329E4B920C8D2C9724499E5B630B3248871648412C32FB56BAB9FBC979225097DAB5D5D4F7AFC903458EE557385B800D8A00000000030CC80388A592E4BC093214B28F25E04D9E5B631C59922B364841217BAB3D0A9EF5FF4E05117BAB3D0ABEF7FB703458EE557385C000D8A0000000000001C3D2C9725E04991A792E4499E5B622B89220B89310485EEACF42AFBDFEDC0A22F7567A157DE7FF112FB3DEAABE1720036A800000000000070F032CC232CF29B118F1264239B268412C979AB3D1ABEDAF2A288BCD59E8D5F6979517D8EF577385D000DCCE000000000000E1B695DACECDAFC992B9D5E2745D09BBCA94769FDA57849FC63BCD49EAF527954AD0E528BF32662ABA7ABC2F8BB0E738B3D11732D5B57BAC454F8C60FF6270D5E8F1AD51F254D7EC731D3D699BB4A8D979AB4F755F6A3E546D51D0F463F65CDFDE937FA646FC6292B24925924AC917DAB334CE655D75C4C619001A15800000000000000000000000000000003FFD9)
GO
SET IDENTITY_INSERT [dbo].[tbl_productimage] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_pwdManger] ON 

GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (1, N'admin', N'admin', CAST(N'2024-03-27 20:50:15.957' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (2, N'ntuser', N'test', CAST(N'2024-03-27 20:51:39.093' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (3, N'ntuser', N'Test3', CAST(N'2024-03-27 20:54:29.710' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (4, N'ntuser', N'Test1', CAST(N'2024-03-27 21:04:25.913' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (5, N'ntuser1', N'test', CAST(N'2024-03-29 07:38:25.107' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (6, N'ntuser1', N'test1', CAST(N'2024-03-29 07:39:32.657' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (7, N'ntuser1', N'test2', CAST(N'2024-03-29 07:42:46.397' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (1005, N'testuser', N'test', CAST(N'2024-03-30 19:45:20.740' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (1006, N'testuser1', N'test', CAST(N'2024-03-30 21:55:51.940' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (1007, N'testuser1', N'test1', CAST(N'2024-04-02 22:56:29.290' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (1008, N'testuser1', N'test2', CAST(N'2024-04-02 22:57:14.937' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (1009, N'testuser1', N'test3', CAST(N'2024-04-03 21:43:38.590' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (1010, N'ntech', N'ntech', CAST(N'2024-04-05 22:37:50.577' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (1011, N'ntech', N'ntech1', CAST(N'2024-04-05 22:39:09.640' AS DateTime))
GO
INSERT [dbo].[tbl_pwdManger] ([id], [username], [password], [ModifyDate]) VALUES (1012, N'ntech', N'test', CAST(N'2024-04-05 22:39:44.510' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tbl_pwdManger] OFF
GO
INSERT [dbo].[tbl_refreshtoken] ([userid], [tokenid], [refreshtoken]) VALUES (N'admin', N'282256895', N'FbT+YlpU+dipd8nxgqoIdWq5Fc0nAcwhWmEIvJHngHA=')
GO
INSERT [dbo].[tbl_refreshtoken] ([userid], [tokenid], [refreshtoken]) VALUES (N'nataraj', N'1264250656', N'LtnEu5DbSsO5eHEzAG+PpW07R6uPUMNEYveZh8KuCZQ=')
GO
INSERT [dbo].[tbl_refreshtoken] ([userid], [tokenid], [refreshtoken]) VALUES (N'ntech', N'855022571', N'n2KnhvLcsc9XX6msIEbRB1fdYlhjOMimjF7G3jucfHs=')
GO
INSERT [dbo].[tbl_refreshtoken] ([userid], [tokenid], [refreshtoken]) VALUES (N'ntuser', N'2083529210', N'Lm8D22t+avaUNbOrAHz/yjX8/HPYSRoyB6oVmv2GZJs=')
GO
INSERT [dbo].[tbl_refreshtoken] ([userid], [tokenid], [refreshtoken]) VALUES (N'ntuser1', N'1141721508', N'uOLH1/ypmXbRgUCXiG06hJ/jwZFjwtDMYN5OttRfgfA=')
GO
INSERT [dbo].[tbl_refreshtoken] ([userid], [tokenid], [refreshtoken]) VALUES (N'testuser1', N'1440321981', N'3f1LwxCOd9hFoPSEoNo5yJPFUzgW/3nr6UG7v/wqxFU=')
GO
INSERT [dbo].[tbl_role] ([code], [name], [status]) VALUES (N'admin', N'Admin', 1)
GO
INSERT [dbo].[tbl_role] ([code], [name], [status]) VALUES (N'staff', N'Staff', 1)
GO
INSERT [dbo].[tbl_role] ([code], [name], [status]) VALUES (N'user', N'User', 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_rolepermission] ON 

GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (1, N'admin', N'userrole', 1, 1, 1, 1)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (2, N'admin', N'user', 1, 1, 1, 1)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (3, N'admin', N'customer', 1, 1, 1, 1)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (4, N'admin', N'reports', 1, 1, 1, 1)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (5, N'user', N'reports', 1, 0, 0, 0)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (7, N'user', N'customer', 1, 1, 0, 1)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (8, N'staff', N'reports', 1, 0, 0, 0)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (9, N'staff', N'customer', 1, 1, 1, 1)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (10, N'string', N'string', 1, 1, 1, 1)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (11, N'user', N'userrole', 0, 0, 0, 0)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (12, N'user', N'user', 0, 0, 0, 0)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (13, N'admin', N'invoice', 1, 1, 1, 1)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (14, N'user', N'invoice', 1, 1, 1, 1)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (15, N'staff', N'user', 0, 0, 0, 0)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (16, N'staff', N'userrole', 0, 0, 0, 0)
GO
INSERT [dbo].[tbl_rolepermission] ([id], [userrole], [menucode], [haveview], [haveadd], [haveedit], [havedelete]) VALUES (17, N'staff', N'invoice', 1, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_rolepermission] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_tempuser] ON 

GO
INSERT [dbo].[tbl_tempuser] ([id], [code], [name], [email], [phone], [password]) VALUES (1, N'admin', N'Admin user', N'admin@nt.com', N'787878899', N'admin')
GO
INSERT [dbo].[tbl_tempuser] ([id], [code], [name], [email], [phone], [password]) VALUES (2, N'ntuser', N'NT User', N'nt@nt.com', N'78999000', N'test')
GO
INSERT [dbo].[tbl_tempuser] ([id], [code], [name], [email], [phone], [password]) VALUES (3, N'ntuser1', N'NT User', N'nt1@in.com', N'9999999999', N'test')
GO
INSERT [dbo].[tbl_tempuser] ([id], [code], [name], [email], [phone], [password]) VALUES (4, N'string', N'string', N'string', N'string', N'string')
GO
INSERT [dbo].[tbl_tempuser] ([id], [code], [name], [email], [phone], [password]) VALUES (1003, N'testuser', N'User', N'test@nt.com', N'456666', N'test')
GO
INSERT [dbo].[tbl_tempuser] ([id], [code], [name], [email], [phone], [password]) VALUES (1004, N'testuser1', N'Test User', N'test1@in.com', N'89900000', N'test')
GO
INSERT [dbo].[tbl_tempuser] ([id], [code], [name], [email], [phone], [password]) VALUES (1005, N'ntech', N'Nihira Techiees', N'ntech@in.com', N'8900000', N'ntech')
GO
SET IDENTITY_INSERT [dbo].[tbl_tempuser] OFF
GO
INSERT [dbo].[tbl_user] ([username], [name], [email], [phone], [password], [isactive], [role], [islocked], [failattempt]) VALUES (N'admin', N'Admin user', N'admin@nt.com', N'787878899', N'admin', 1, N'admin', 0, 0)
GO
INSERT [dbo].[tbl_user] ([username], [name], [email], [phone], [password], [isactive], [role], [islocked], [failattempt]) VALUES (N'ntech', N'Nihira Techiees', N'ntech@in.com', N'8900000', N'test', 1, N'admin', 0, 0)
GO
INSERT [dbo].[tbl_user] ([username], [name], [email], [phone], [password], [isactive], [role], [islocked], [failattempt]) VALUES (N'ntuser', N'NT User', N'nt@nt.com', N'78999000', N'Test1', 1, N'staff', 0, 0)
GO
INSERT [dbo].[tbl_user] ([username], [name], [email], [phone], [password], [isactive], [role], [islocked], [failattempt]) VALUES (N'ntuser1', N'NT User', N'nt1@in.com', N'9999999999', N'test2', 1, N'staff', 0, 0)
GO
INSERT [dbo].[tbl_user] ([username], [name], [email], [phone], [password], [isactive], [role], [islocked], [failattempt]) VALUES (N'testuser', N'User', N'test@nt.com', N'456666', N'test', 1, N'staff', 0, 0)
GO
INSERT [dbo].[tbl_user] ([username], [name], [email], [phone], [password], [isactive], [role], [islocked], [failattempt]) VALUES (N'testuser1', N'Test User', N'test1@in.com', N'89900000', N'test3', 1, N'admin', 0, 0)
GO
/****** Object:  StoredProcedure [dbo].[sp_createcustomer]    Script Date: 28-04-24 15:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_createcustomer](
@code varchar(50),
@name varchar(200),
@email varchar(200),
@phone varchar(100),
@creditlimit decimal(18,2),
@active bit,
@taxcode int,
@type varchar(10)

)
as
begin
if @type='add'
begin
Insert Into tbl_customer values(@code,@name,@email,@phone,@creditlimit,@active,@taxcode)
end
if @type='update'
begin
Update tbl_customer SET name=@name,email=@email,phone=@phone,creditlimit=@creditlimit,IsActive=@active,taxcode=@taxcode where code=@code
end

end

GO
/****** Object:  StoredProcedure [dbo].[sp_deletecustomer]    Script Date: 28-04-24 15:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_deletecustomer](
@code varchar(50)

)
as
begin
Delete from tbl_customer where code=@code

end


GO
/****** Object:  StoredProcedure [dbo].[sp_getcustomer]    Script Date: 28-04-24 15:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[sp_getcustomer]
as
begin
Select * from tbl_customer 

end




GO
/****** Object:  StoredProcedure [dbo].[sp_getcustomer_custom]    Script Date: 28-04-24 15:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_getcustomer_custom]
as
begin
Select *,'Active' as Statusname from tbl_customer 

end



GO
USE [master]
GO
ALTER DATABASE [test_db] SET  READ_WRITE 
GO
