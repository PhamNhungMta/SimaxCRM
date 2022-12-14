
/****** Object:  Schema [SimaxRealEstate]    Script Date: 01/05/2022 01:29 PM ******/
USE [SimaxRealEstate]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Tid] [int] NOT NULL,
	[AgentCount] [int] NULL,
	[QaCount] [int] NULL,
	[AccountCount] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[Experience] [nvarchar](max) NULL,
	[WorkingEmployees] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[UserRank] [int] NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[RERANo] [nvarchar](max) NULL,
	[News] [nvarchar](max) NULL,
	[LanguageSpeak] [nvarchar](max) NULL,
	[Specializations] [nvarchar](max) NULL,
	[ShowInHomePage] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Attachment]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attachment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[UploadCategoryId] [int] NULL,
	[FilePath] [nvarchar](max) NULL,
	[FileName] [nvarchar](max) NULL,
	[FileType] [nvarchar](max) NULL,
	[FileSize] [bigint] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[TempId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AttachmentProductMapping]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachmentProductMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UploadCategoryId] [int] NULL,
	[AttachmentId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_AttachmentProductMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AttachmentProjectMapping]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachmentProjectMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[UploadCategoryId] [int] NULL,
	[AttachmentId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_AttachmentProjectMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CallLog]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CallLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[LeadId] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[AlertDate] [datetime2](7) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AlertStatus] [int] NOT NULL,
	[AlertStatusFcm] [int] NOT NULL,
	[InvoiceId] [int] NULL,
 CONSTRAINT [PK_CallLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CallLogProduct]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CallLogProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[AlertDate] [datetime2](7) NULL,
	[AlertStatus] [int] NOT NULL,
	[AlertStatusFcm] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[InvoiceId] [int] NULL,
 CONSTRAINT [PK_CallLogProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[City]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerQuery]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerQuery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[ProjectId] [int] NULL,
	[ProductId] [int] NULL,
	[UserId] [nvarchar](450) NULL,
	[CustomerName] [nvarchar](max) NOT NULL,
	[CustomerPhone] [nvarchar](max) NOT NULL,
	[CustomerEmail] [nvarchar](max) NOT NULL,
	[CustomerMessage] [nvarchar](max) NOT NULL,
	[ProjectRelatedIds] [nvarchar](max) NULL,
	[ProductRelatedIds] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_CustomerQuery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailSent]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailSent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[FromEmail] [nvarchar](max) NOT NULL,
	[ToEmail] [nvarchar](max) NOT NULL,
	[SendBy] [nvarchar](max) NULL,
	[IsSent] [bit] NOT NULL,
	[Subject] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_EmailSent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailSetup]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailSetup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[SmtpServer] [nvarchar](100) NOT NULL,
	[SmtpPort] [int] NOT NULL,
	[UseSsl] [nvarchar](5) NOT NULL,
	[Username] [nvarchar](200) NULL,
	[Password] [nvarchar](200) NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[IncommingMailServer] [nvarchar](max) NOT NULL,
	[IncommingMailPort] [int] NOT NULL,
 CONSTRAINT [PK_EmailSetup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InventoryTag]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_InventoryTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InventoryTagMapping]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryTagMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[InventoryTagId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_InventoryTagMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[LeadId] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[DiscountAmount] [decimal](18, 2) NOT NULL,
	[OtherCharges] [decimal](18, 2) NOT NULL,
	[TaxPercent] [decimal](18, 2) NOT NULL,
	[TaxAmount] [decimal](18, 2) NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[OrderStatus] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[ProductName] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[ActionType] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lead]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lead](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[AlternatePhoneNumber] [nvarchar](20) NULL,
	[ReferPhoneNumber] [nvarchar](20) NULL,
	[LeadType] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NULL,
	[Address] [nvarchar](500) NULL,
	[PropertyCategoryId] [int] NOT NULL,
	[PropertySubcategoryId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[SocietyId] [int] NOT NULL,
	[ReferName] [nvarchar](200) NULL,
	[BudgetMin] [decimal](18, 2) NOT NULL,
	[BudgetMax] [decimal](18, 2) NOT NULL,
	[City] [nvarchar](200) NULL,
	[State] [nvarchar](200) NULL,
	[Country] [nvarchar](200) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[LeadSourceId] [int] NOT NULL,
	[LastContact] [datetime2](7) NULL,
	[UserId] [nvarchar](450) NULL,
	[LeadStatus] [nvarchar](50) NULL,
	[DeletedById] [nvarchar](450) NULL,
	[DeletedDate] [datetime2](7) NULL,
	[IsPurchased] [bit] NOT NULL,
	[PurchasedCount] [int] NULL,
	[AssignedDate] [datetime2](7) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[AlertDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Lead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeadAutoAssign]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadAutoAssign](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_LeadAutoAssign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeadAutoAssignLog]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadAutoAssignLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[LeadId] [int] NOT NULL,
	[LeadSourceId] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_LeadAutoAssignLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeadAutoAssignSourceMapping]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadAutoAssignSourceMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[LeadAutoAssignId] [int] NOT NULL,
	[LeadSourceId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_LeadAutoAssignSourceMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeadOrder]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[PaymentLogId] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[TotalLeads] [int] NOT NULL,
	[LeadOrderStatus] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_LeadOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeadOrderDetail]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadOrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[LeadOrderId] [int] NOT NULL,
	[LeadId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[NewLeadId] [int] NOT NULL,
 CONSTRAINT [PK_LeadOrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeadProductMapping]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadProductMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[LeadId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_LeadProductMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeadProjectMapping]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadProjectMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[LeadId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_LeadProjectMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeadRemarks]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadRemarks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Status] [nvarchar](200) NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_LeadRemarks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeadSource]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadSource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_LeadSource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeadTag]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_LeadTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeadTagMapping]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadTagMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[LeadId] [int] NOT NULL,
	[LeadTagId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_LeadTagMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeadType]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_LeadType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Message]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedById] [nvarchar](450) NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageDetail]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[MessageId] [int] NOT NULL,
	[SentToUserId] [nvarchar](450) NULL,
	[AlertStatus] [int] NOT NULL,
 CONSTRAINT [PK_MessageDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OtpLog]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtpLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[SentType] [int] NOT NULL,
	[SentTo] [nvarchar](max) NULL,
	[Pin] [nvarchar](max) NULL,
	[IsUsed] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[VerifiedDate] [datetime2](7) NULL,
	[ApiResponse] [nvarchar](max) NULL,
 CONSTRAINT [PK_OtpLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentLog]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[TransId] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PaymentLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhoneCallLeadLog]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneCallLeadLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecId] [bigint] NOT NULL,
	[Tid] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[Date] [nvarchar](max) NULL,
	[CallTime] [datetime2](7) NOT NULL,
	[Number] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[Duration] [int] NOT NULL,
	[IsNew] [int] NOT NULL,
	[CachedName] [nvarchar](max) NULL,
	[CachedNumberType] [int] NOT NULL,
	[PhoneAccountId] [nvarchar](max) NULL,
	[ViaNumber] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Contact] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[LeadId] [int] NOT NULL,
 CONSTRAINT [PK_PhoneCallLeadLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhoneCallProductLog]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneCallProductLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecId] [bigint] NOT NULL,
	[Tid] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[Date] [nvarchar](max) NULL,
	[CallTime] [datetime2](7) NOT NULL,
	[Number] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[Duration] [int] NOT NULL,
	[IsNew] [int] NOT NULL,
	[CachedName] [nvarchar](max) NULL,
	[CachedNumberType] [int] NOT NULL,
	[PhoneAccountId] [nvarchar](max) NULL,
	[ViaNumber] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Contact] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_PhoneCallProductLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[PropertyCategoryId] [int] NOT NULL,
	[PropertySubcategoryId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[MetaTag] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[CityId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[SocietyId] [int] NOT NULL,
	[AddressPlain] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[AddressLat] [nvarchar](max) NULL,
	[AddressLng] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[PropertyDimType] [nvarchar](max) NULL,
	[TotalArea] [decimal](18, 2) NOT NULL,
	[PropertyPrice] [decimal](18, 2) NOT NULL,
	[TotalPropertyPrice] [nvarchar](max) NULL,
	[ConstructionStatus] [nvarchar](max) NULL,
	[Bedroom] [nvarchar](max) NULL,
	[Parking] [nvarchar](max) NULL,
	[Bathrooms] [nvarchar](max) NULL,
	[MaintenanceCharges] [nvarchar](max) NULL,
	[TotalMaintenanceCharges] [nvarchar](max) NULL,
	[CentralizedAc] [bit] NOT NULL,
	[SecurityGuard] [bit] NOT NULL,
	[FireSafety] [bit] NOT NULL,
	[CctvCamera] [bit] NOT NULL,
	[Lift] [bit] NOT NULL,
	[club] [bit] NOT NULL,
	[SwimmingPool] [bit] NOT NULL,
	[GardenArea] [bit] NOT NULL,
	[KidsPlayArea] [bit] NOT NULL,
	[Gym] [bit] NOT NULL,
	[PropertyFloor] [nvarchar](max) NULL,
	[Furnished] [nvarchar](max) NULL,
	[MaxSaleRate] [decimal](18, 2) NOT NULL,
	[OwnerName] [nvarchar](max) NULL,
	[OwnerPhoneNumber] [nvarchar](max) NULL,
	[OwnerEmailId] [nvarchar](max) NULL,
	[Source] [nvarchar](max) NULL,
	[ReferenceName] [nvarchar](max) NULL,
	[ReferenceNumber] [nvarchar](max) NULL,
	[MainImage] [nvarchar](1000) NULL,
	[EmbadVideo] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ActiveStatus] [int] NOT NULL,
	[Status] [nvarchar](max) NULL,
	[ViewCount] [int] NOT NULL,
	[RecIdOld] [int] NOT NULL,
	[VideoLink] [nvarchar](300) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[AlertDate] [datetime2](7) NULL,
	[ProjectId] [int] NULL,
	[ImagePath1] [nvarchar](200) NULL,
	[ImagePath2] [nvarchar](200) NULL,
	[ImagePath3] [nvarchar](200) NULL,
	[ImagePath4] [nvarchar](200) NULL,
	[ImagePath5] [nvarchar](200) NULL,
	[ImagePath6] [nvarchar](200) NULL,
	[ImagePath7] [nvarchar](200) NULL,
	[ImagePath8] [nvarchar](200) NULL,
	[ImagePath9] [nvarchar](200) NULL,
	[ImagePath10] [nvarchar](200) NULL,
	[SubCategoryId] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[PropertyCategoryId] [int] NOT NULL,
	[PropertySubcategoryId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[MetaTag] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[CityId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[SocietyId] [int] NOT NULL,
	[AddressPlain] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[AddressLat] [nvarchar](max) NULL,
	[AddressLng] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[PropertyDimType] [nvarchar](max) NULL,
	[TotalArea] [decimal](18, 2) NOT NULL,
	[PropertyPrice] [decimal](18, 2) NOT NULL,
	[TotalPropertyPrice] [nvarchar](max) NULL,
	[ConstructionStatus] [nvarchar](max) NULL,
	[Bedroom] [nvarchar](max) NULL,
	[Parking] [nvarchar](max) NULL,
	[Bathrooms] [nvarchar](max) NULL,
	[MaintenanceCharges] [nvarchar](max) NULL,
	[TotalMaintenanceCharges] [nvarchar](max) NULL,
	[CentralizedAc] [bit] NOT NULL,
	[SecurityGuard] [bit] NOT NULL,
	[FireSafety] [bit] NOT NULL,
	[CctvCamera] [bit] NOT NULL,
	[Lift] [bit] NOT NULL,
	[club] [bit] NOT NULL,
	[SwimmingPool] [bit] NOT NULL,
	[GardenArea] [bit] NOT NULL,
	[KidsPlayArea] [bit] NOT NULL,
	[Gym] [bit] NOT NULL,
	[PropertyFloor] [nvarchar](max) NULL,
	[Furnished] [nvarchar](max) NULL,
	[MaxSaleRate] [decimal](18, 2) NOT NULL,
	[OwnerName] [nvarchar](max) NULL,
	[OwnerPhoneNumber] [nvarchar](max) NULL,
	[OwnerEmailId] [nvarchar](max) NULL,
	[Source] [nvarchar](max) NULL,
	[ReferenceName] [nvarchar](max) NULL,
	[ReferenceNumber] [nvarchar](max) NULL,
	[MainImage] [nvarchar](1000) NULL,
	[EmbadVideo] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ActiveStatus] [int] NOT NULL,
	[Status] [nvarchar](max) NULL,
	[ViewCount] [int] NOT NULL,
	[RecIdOld] [int] NOT NULL,
	[VideoLink] [nvarchar](300) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[AlertDate] [datetime2](7) NULL,
	[TotalBlocks] [nvarchar](max) NULL,
	[TotalFloors] [nvarchar](max) NULL,
	[TotalFlats] [nvarchar](max) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectTagMapping]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTagMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[InventoryTagId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_ProjectTagMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seo]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[SeoPage] [int] NOT NULL,
	[PageTitle] [nvarchar](max) NOT NULL,
	[MetaKeyword] [nvarchar](max) NOT NULL,
	[MetaDescription] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Seo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slider]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Society]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Society](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Society] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SystemSetup]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemSetup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[CompanyName] [nvarchar](200) NOT NULL,
	[AddressPlain] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
	[AddressLat] [nvarchar](200) NULL,
	[AddressLng] [nvarchar](200) NULL,
	[CompanyEmail] [nvarchar](200) NULL,
	[CompanyContact] [nvarchar](200) NULL,
	[CompanyGstNumber] [nvarchar](200) NULL,
	[TaxPercent] [decimal](18, 2) NOT NULL,
	[Currency] [nvarchar](50) NOT NULL,
	[CurrencySymbol] [nvarchar](50) NOT NULL,
	[CompanyLogo] [nvarchar](200) NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_SystemSetup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tcf]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tcf](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[LeadId] [int] NOT NULL,
	[Property] [nvarchar](max) NULL,
	[Rate] [nvarchar](max) NULL,
	[Size] [nvarchar](max) NULL,
	[BSP] [nvarchar](max) NULL,
	[OtherCharges] [nvarchar](max) NULL,
	[BookingForm] [nvarchar](max) NULL,
	[PaymentDetails] [nvarchar](max) NULL,
	[OpsChecklist] [nvarchar](max) NULL,
	[DiscountApproval] [nvarchar](max) NULL,
	[AadharCard] [nvarchar](max) NULL,
	[PanCard] [nvarchar](max) NULL,
	[VoterID] [nvarchar](max) NULL,
	[Passport] [nvarchar](max) NULL,
	[BrokerageRate] [nvarchar](max) NULL,
	[RoyaltyDiscount] [nvarchar](max) NULL,
	[ReferralBrokerage] [nvarchar](max) NULL,
	[FinalBrokerage] [nvarchar](max) NULL,
	[EmployeeCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tcf] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Template]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Template](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Type] [int] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Subject] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TempLead]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempLead](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](200) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_TempLead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UploadCategory]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UploadCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_UploadCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserLog]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[LeadId] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[LogType] [nvarchar](max) NOT NULL,
	[LogRecId] [int] NOT NULL,
	[LogText] [nvarchar](max) NULL,
	[LogStatus] [nvarchar](max) NULL,
	[IsSuccess] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UserLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRating]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRating](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[ProductId] [int] NULL,
	[ProjectId] [int] NULL,
	[Message] [nvarchar](max) NULL,
	[Rating] [float] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](450) NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_UserRating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wallet]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[TotalPoints] [decimal](18, 2) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[PurchaseCount] [int] NOT NULL,
 CONSTRAINT [PK_Wallet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WalletDetail]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WalletDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[WalletId] [int] NOT NULL,
	[PaymentLogId] [int] NOT NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_WalletDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wishlist]    Script Date: 01/05/2022 01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlist](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[ProductId] [int] NULL,
	[ProjectId] [int] NULL,
	[UserId] [nvarchar](450) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Wishlist] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220412111839_InitTables', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220430113430_Changes_Homepage_Agents', N'3.1.5')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'502b0984-e22d-407c-8ef3-66bfccea8916', N'Admin', N'ADMIN', N'da6709b5-b10f-4548-b64e-4309c566da8d')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'806f2136-e64c-4d4d-a6e1-6d6c63b95143', N'Agent', N'AGENT', N'25af9051-d223-4101-b568-4ab736f2191a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd157deb0-521e-45ac-9fce-da07b09b858c', N'502b0984-e22d-407c-8ef3-66bfccea8916')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'16bd82f3-dc97-48c6-acd1-b9498c8b8bd8', N'806f2136-e64c-4d4d-a6e1-6d6c63b95143')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'37a00614-acf2-4475-a7b3-ffa94943e49c', N'806f2136-e64c-4d4d-a6e1-6d6c63b95143')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'870d66d8-2225-4a5e-8408-911d7e0dfc5f', N'806f2136-e64c-4d4d-a6e1-6d6c63b95143')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bf7cf1d3-db92-4584-a2e1-04fbab8249d1', N'806f2136-e64c-4d4d-a6e1-6d6c63b95143')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Tid], [AgentCount], [QaCount], [AccountCount], [CreatedDate], [CreatedBy], [StartDate], [EndDate], [IsActive], [ImagePath], [Experience], [WorkingEmployees], [Address], [City], [UserRank], [CompanyName], [RERANo], [News], [LanguageSpeak], [Specializations], [ShowInHomePage]) VALUES (N'16bd82f3-dc97-48c6-acd1-b9498c8b8bd8', N'jc@gmail.com', N'JC@GMAIL.COM', N'jc@gmail.com', N'JC@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEpla7iiK/OuXVwer4RjJbS5A2ybBz7Q9xxWSmbypOOo7Kt5cMlniL5wxAFyIKw78w==', N'ZWDH52BG5D7CRG6AAAWEXNJCOJVAH7SR', N'fe1a39d2-21d3-43c0-8b35-d0ca5cf97e92', N'1234567890', 0, 0, NULL, 1, 0, N'john carton', 0, NULL, NULL, NULL, CAST(N'2022-04-13 13:39:27.3493527' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', NULL, NULL, 1, N'Uploads/Profile/132943117865735821.jpg', N'5 years', NULL, NULL, N'New York', 2, N'Simax Company', NULL, NULL, N'English, French', NULL, 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Tid], [AgentCount], [QaCount], [AccountCount], [CreatedDate], [CreatedBy], [StartDate], [EndDate], [IsActive], [ImagePath], [Experience], [WorkingEmployees], [Address], [City], [UserRank], [CompanyName], [RERANo], [News], [LanguageSpeak], [Specializations], [ShowInHomePage]) VALUES (N'37a00614-acf2-4475-a7b3-ffa94943e49c', N'pk@gamil.com', N'PK@GAMIL.COM', N'pk@gamil.com', N'PK@GAMIL.COM', 0, N'AQAAAAEAACcQAAAAEGKSJOcuku/MTD6EtquKpDE/2vez9VgEDO7Mb5t+YHRLJ1/+f+XZ+L9QxXeyzgx+Ng==', N'62P3QJBHZCPPETWMXONQQFIFLNH5BOXA', N'f71629f5-1fe4-4afc-9ae6-e70afa83f3bf', N'1212321212', 0, 0, NULL, 1, 0, N'Parmod Kalia', 0, NULL, NULL, NULL, CAST(N'2022-04-13 15:24:30.2853807' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', NULL, NULL, 1, N'Uploads/Profile/132943179489532189.jpg', N'8 years', NULL, N'H. no. 123 Jaipur, Rajasthan', N'jaipur', 2, N'Simax Company', NULL, N'Reading Books, Playing Cricket.', N'English, Hindi', NULL, 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Tid], [AgentCount], [QaCount], [AccountCount], [CreatedDate], [CreatedBy], [StartDate], [EndDate], [IsActive], [ImagePath], [Experience], [WorkingEmployees], [Address], [City], [UserRank], [CompanyName], [RERANo], [News], [LanguageSpeak], [Specializations], [ShowInHomePage]) VALUES (N'870d66d8-2225-4a5e-8408-911d7e0dfc5f', N'kp@gmail.com', N'KP@GMAIL.COM', N'kp@gmail.com', N'KP@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEO4huXnZ1isMDPF3HzDJJJWNPNWKgKy4elttYUSARGBKVk9EwuWs42KWssYbGiXhHg==', N'LWUWLUVLWIQNORY4WCT62A3QH4ZFZEDT', N'b5fbe77f-475c-456d-a567-6e83f6d08602', N'0120120120', 0, 0, NULL, 1, 0, N'Katty piere', 0, NULL, NULL, NULL, CAST(N'2022-04-13 15:26:08.1192993' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', NULL, NULL, 1, N'Uploads/Profile/132943180974410940.jpg', N'5 years', NULL, N'Street 66, London, England', N'London', 2, N'Simax Company', NULL, N'Reading Books, Watching News.', N'English, French', NULL, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Tid], [AgentCount], [QaCount], [AccountCount], [CreatedDate], [CreatedBy], [StartDate], [EndDate], [IsActive], [ImagePath], [Experience], [WorkingEmployees], [Address], [City], [UserRank], [CompanyName], [RERANo], [News], [LanguageSpeak], [Specializations], [ShowInHomePage]) VALUES (N'bf7cf1d3-db92-4584-a2e1-04fbab8249d1', N'pj@gmail.com', N'PJ@GMAIL.COM', N'pj@gmail.com', N'PJ@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPLtMmtTkQgtd3IQC1MLl7mQ78rhFoyVkeflafI/ZqdgZSIcd5/MrXdHPHpx2k0wcw==', N'RT335ED6U6PJQVMF4XKLBZXHULPZLEIA', N'f5e1a6af-fb78-440e-bcc0-f38d6ef1cfc3', N'3211233213', 0, 0, NULL, 1, 0, N'Pankaj Jain', 0, NULL, NULL, NULL, CAST(N'2022-04-13 15:27:50.8352045' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', NULL, NULL, 1, N'Uploads/Profile/132943182916610702.jpg', N'6 years', NULL, N'Village Rampur, Hisar, Haryana', N'Hisar', 2, N'Simax Company', NULL, N'Playing Cricket, Watching Historical Places', N'English, Hindi', NULL, 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Tid], [AgentCount], [QaCount], [AccountCount], [CreatedDate], [CreatedBy], [StartDate], [EndDate], [IsActive], [ImagePath], [Experience], [WorkingEmployees], [Address], [City], [UserRank], [CompanyName], [RERANo], [News], [LanguageSpeak], [Specializations], [ShowInHomePage]) VALUES (N'd157deb0-521e-45ac-9fce-da07b09b858c', N'demo@gmail.com', N'DEMO@GMAIL.COM', N'demo@gmail.com', N'DEMO@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEA/9wE36EakFIYEzXQ9Y3Y2UD/TN1QU7/66OBBjJRqZy4Tq0QjlEOvYnDF6YSx/uSQ==', N'G2LGBDQFQE4Q7IUITDBTX65WOKBKCRP5', N'478086ab-b79e-48c0-8700-1efa2915023e', N'9896565656', 0, 0, NULL, 1, 0, N'demo', 0, NULL, NULL, NULL, CAST(N'2022-04-12 17:18:31.5544752' AS DateTime2), NULL, NULL, NULL, 1, N'Uploads/Profile/132943182916610702.jpg', NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Attachment] ON 

INSERT [dbo].[Attachment] ([Id], [Tid], [UploadCategoryId], [FilePath], [FileName], [FileType], [FileSize], [Status], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [TempId]) VALUES (1, 0, 4, N'Uploads/Product/132943066670965455_1342dfdab56bf20b7aa3682c69559d3c.jpg', N'132943066670965455_1342dfdab56bf20b7aa3682c69559d3c.jpg', N'.jpg', 284587, 1, CAST(N'2022-04-13 12:27:47.2464889' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', NULL, NULL, N'b496600f-9715-429e-a346-4be777894dec')
SET IDENTITY_INSERT [dbo].[Attachment] OFF
SET IDENTITY_INSERT [dbo].[CallLog] ON 

INSERT [dbo].[CallLog] ([Id], [Tid], [LeadId], [UserId], [StartTime], [EndTime], [Status], [Remarks], [Message], [AlertDate], [CreatedDate], [AlertStatus], [AlertStatusFcm], [InvoiceId]) VALUES (1, 0, 1, N'd157deb0-521e-45ac-9fce-da07b09b858c', CAST(N'12:48:55.8425693' AS Time), CAST(N'12:48:55.8425689' AS Time), N'Lead', N'New Lead', N'New Lead Created', CAST(N'2022-04-13 12:48:55.8425661' AS DateTime2), CAST(N'2022-04-13 12:48:55.8425688' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[CallLog] ([Id], [Tid], [LeadId], [UserId], [StartTime], [EndTime], [Status], [Remarks], [Message], [AlertDate], [CreatedDate], [AlertStatus], [AlertStatusFcm], [InvoiceId]) VALUES (2, 0, 1, N'd157deb0-521e-45ac-9fce-da07b09b858c', CAST(N'12:49:00' AS Time), CAST(N'12:51:00' AS Time), N'FollowUp', N'Taking Follow up', N'hello', CAST(N'2022-04-20 12:50:00.0000000' AS DateTime2), CAST(N'2022-04-13 12:51:11.0448389' AS DateTime2), 1, 1, NULL)
INSERT [dbo].[CallLog] ([Id], [Tid], [LeadId], [UserId], [StartTime], [EndTime], [Status], [Remarks], [Message], [AlertDate], [CreatedDate], [AlertStatus], [AlertStatusFcm], [InvoiceId]) VALUES (4, 0, 3, N'16bd82f3-dc97-48c6-acd1-b9498c8b8bd8', CAST(N'13:13:09.9905317' AS Time), CAST(N'13:13:09.9894714' AS Time), N'Lead', N'', N'asdasd1', CAST(N'2022-04-20 13:13:09.9888674' AS DateTime2), CAST(N'2022-04-20 13:13:09.9892394' AS DateTime2), 0, 1, NULL)
SET IDENTITY_INSERT [dbo].[CallLog] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, N'Commercial', 1, CAST(N'2022-04-12 17:18:32.7705287' AS DateTime2), NULL)
INSERT [dbo].[Category] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (2, 0, N'Residential', 1, CAST(N'2022-04-12 17:18:32.8514348' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, N'New Delhi', 1, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2022-04-13 11:34:20.5575853' AS DateTime2))
INSERT [dbo].[City] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (2, 0, N'Kolkata', 1, CAST(N'2022-04-12 17:18:32.9584163' AS DateTime2), NULL)
INSERT [dbo].[City] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (3, 0, N'Chandigarh', 1, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2022-04-13 11:32:56.2254523' AS DateTime2))
INSERT [dbo].[City] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (4, 0, N'Noida', 1, CAST(N'2022-04-15 10:51:23.2243836' AS DateTime2), NULL)
INSERT [dbo].[City] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (5, 0, N'Bengaluru', 1, CAST(N'2022-04-15 10:53:31.9033464' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[CustomerQuery] ON 

INSERT [dbo].[CustomerQuery] ([Id], [Tid], [ProjectId], [ProductId], [UserId], [CustomerName], [CustomerPhone], [CustomerEmail], [CustomerMessage], [ProjectRelatedIds], [ProductRelatedIds], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, NULL, 2, NULL, N'Test', N'9513456052', N'm@gmail.com', N'message', NULL, NULL, 0, CAST(N'2022-04-20 11:20:25.1703433' AS DateTime2), NULL)
INSERT [dbo].[CustomerQuery] ([Id], [Tid], [ProjectId], [ProductId], [UserId], [CustomerName], [CustomerPhone], [CustomerEmail], [CustomerMessage], [ProjectRelatedIds], [ProductRelatedIds], [Status], [CreatedDate], [UpdatedDate]) VALUES (2, 0, NULL, NULL, N'16bd82f3-dc97-48c6-acd1-b9498c8b8bd8', N'Test1', N'9513456051', N'm1@gmail.com', N'asdasd1', NULL, NULL, 0, CAST(N'2022-04-20 13:13:05.6388438' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[CustomerQuery] OFF
SET IDENTITY_INSERT [dbo].[InventoryTag] ON 

INSERT [dbo].[InventoryTag] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, N'Low Price', 1, CAST(N'2022-04-12 17:18:32.9621159' AS DateTime2), NULL)
INSERT [dbo].[InventoryTag] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (2, 0, N'High Price', 1, CAST(N'2022-04-12 17:18:32.9819956' AS DateTime2), NULL)
INSERT [dbo].[InventoryTag] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (3, 0, N'Best Price', 1, CAST(N'2022-04-12 17:18:32.9839749' AS DateTime2), NULL)
INSERT [dbo].[InventoryTag] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (4, 0, N'Vip', 1, CAST(N'2022-04-12 17:18:32.9861573' AS DateTime2), NULL)
INSERT [dbo].[InventoryTag] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (5, 0, N'Despirit', 1, CAST(N'2022-04-12 17:18:32.9878966' AS DateTime2), NULL)
INSERT [dbo].[InventoryTag] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (6, 0, N'Hurry', 1, CAST(N'2022-04-12 17:18:32.9895030' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[InventoryTag] OFF
SET IDENTITY_INSERT [dbo].[InventoryTagMapping] ON 

INSERT [dbo].[InventoryTagMapping] ([Id], [Tid], [ProductId], [InventoryTagId], [Status], [CreatedDate], [UpdatedDate]) VALUES (4, 0, 3, 6, 1, CAST(N'2022-04-20 13:28:33.2112540' AS DateTime2), NULL)
INSERT [dbo].[InventoryTagMapping] ([Id], [Tid], [ProductId], [InventoryTagId], [Status], [CreatedDate], [UpdatedDate]) VALUES (5, 0, 2, 6, 1, CAST(N'2022-04-30 17:17:02.7632444' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[InventoryTagMapping] OFF
SET IDENTITY_INSERT [dbo].[Lead] ON 

INSERT [dbo].[Lead] ([Id], [Tid], [Name], [PhoneNumber], [AlternatePhoneNumber], [ReferPhoneNumber], [LeadType], [Email], [Address], [PropertyCategoryId], [PropertySubcategoryId], [CityId], [LocationId], [SocietyId], [ReferName], [BudgetMin], [BudgetMax], [City], [State], [Country], [PostalCode], [LeadSourceId], [LastContact], [UserId], [LeadStatus], [DeletedById], [DeletedDate], [IsPurchased], [PurchasedCount], [AssignedDate], [CreatedDate], [UpdatedDate], [AlertDate], [CreatedBy]) VALUES (1, 0, N'john carton', N'1234567890', NULL, NULL, N'3', N'jc@gmail.com', N'abc street New delhi', 1, 4, 1, 3, 1, NULL, CAST(2500000.00 AS Decimal(18, 2)), CAST(2800000.00 AS Decimal(18, 2)), N'Kalash ', N'Delhi', N'india ', N'112233', 9, CAST(N'2022-04-13 12:51:14.0669931' AS DateTime2), NULL, N'FollowUp', NULL, NULL, 0, NULL, CAST(N'2022-04-13 12:48:55.5003418' AS DateTime2), CAST(N'2022-04-13 12:48:55.5003305' AS DateTime2), NULL, CAST(N'2022-04-20 12:50:00.0000000' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c')
INSERT [dbo].[Lead] ([Id], [Tid], [Name], [PhoneNumber], [AlternatePhoneNumber], [ReferPhoneNumber], [LeadType], [Email], [Address], [PropertyCategoryId], [PropertySubcategoryId], [CityId], [LocationId], [SocietyId], [ReferName], [BudgetMin], [BudgetMax], [City], [State], [Country], [PostalCode], [LeadSourceId], [LastContact], [UserId], [LeadStatus], [DeletedById], [DeletedDate], [IsPurchased], [PurchasedCount], [AssignedDate], [CreatedDate], [UpdatedDate], [AlertDate], [CreatedBy]) VALUES (2, 0, N'Test', N'9513456052', NULL, NULL, N'', N'm@gmail.com', NULL, 0, 0, 0, 0, 0, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, 10, NULL, N'd157deb0-521e-45ac-9fce-da07b09b858c', N'NewLead', NULL, NULL, 0, NULL, CAST(N'2022-04-20 11:21:02.9502330' AS DateTime2), CAST(N'2022-04-20 11:21:02.9488623' AS DateTime2), NULL, NULL, N'd157deb0-521e-45ac-9fce-da07b09b858c')
INSERT [dbo].[Lead] ([Id], [Tid], [Name], [PhoneNumber], [AlternatePhoneNumber], [ReferPhoneNumber], [LeadType], [Email], [Address], [PropertyCategoryId], [PropertySubcategoryId], [CityId], [LocationId], [SocietyId], [ReferName], [BudgetMin], [BudgetMax], [City], [State], [Country], [PostalCode], [LeadSourceId], [LastContact], [UserId], [LeadStatus], [DeletedById], [DeletedDate], [IsPurchased], [PurchasedCount], [AssignedDate], [CreatedDate], [UpdatedDate], [AlertDate], [CreatedBy]) VALUES (3, 0, N'Test1', N'9513456051', NULL, NULL, N'', N'm1@gmail.com', NULL, 0, 0, 0, 0, 0, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, 10, NULL, N'16bd82f3-dc97-48c6-acd1-b9498c8b8bd8', N'NewLead', NULL, NULL, 0, NULL, CAST(N'2022-04-20 13:13:09.6912712' AS DateTime2), CAST(N'2022-04-20 13:13:09.6908297' AS DateTime2), NULL, NULL, N'16bd82f3-dc97-48c6-acd1-b9498c8b8bd8')
SET IDENTITY_INSERT [dbo].[Lead] OFF
SET IDENTITY_INSERT [dbo].[LeadProductMapping] ON 

INSERT [dbo].[LeadProductMapping] ([Id], [Tid], [LeadId], [ProductId], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, 2, 2, 1, CAST(N'2022-04-20 11:21:03.2083221' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[LeadProductMapping] OFF
SET IDENTITY_INSERT [dbo].[LeadRemarks] ON 

INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (1, 0, N'FollowUp', N'First Call Done', CAST(N'2022-04-12 17:18:33.0307085' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (2, 0, N'FollowUp', N'Taking Follow up', CAST(N'2022-04-12 17:18:33.0445688' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (3, 0, N'FollowUp', N'Proposal Send', CAST(N'2022-04-12 17:18:33.0466061' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (4, 0, N'FollowUp', N'Site Visit Plan', CAST(N'2022-04-12 17:18:33.0483242' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (5, 0, N'FollowUp', N'Site Visit Done', CAST(N'2022-04-12 17:18:33.0502847' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (6, 0, N'FollowUp', N'Call Back', CAST(N'2022-04-12 17:18:33.0521180' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (7, 0, N'Reopen', N'Interest shown by Client', CAST(N'2022-04-12 17:18:33.0541143' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (8, 0, N'Reopen', N'Reopen by follow-up', CAST(N'2022-04-12 17:18:33.0564532' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (9, 0, N'Reopen', N'Auto Re-open Lead', CAST(N'2022-04-12 17:18:33.0584152' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (10, 0, N'Postpone', N'One Week', CAST(N'2022-04-12 17:18:33.0608464' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (11, 0, N'Postpone', N'Two Week', CAST(N'2022-04-12 17:18:33.0632646' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (12, 0, N'Postpone', N'One Month', CAST(N'2022-04-12 17:18:33.0657135' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (13, 0, N'Postpone', N'Three Month', CAST(N'2022-04-12 17:18:33.0676827' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (14, 0, N'Postpone', N'Plan Postpone', CAST(N'2022-04-12 17:18:33.0698438' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (15, 0, N'Comment', N'Call Done', CAST(N'2022-04-12 17:18:33.0719523' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (16, 0, N'Comment', N'Working in Progress', CAST(N'2022-04-12 17:18:33.0739909' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (17, 0, N'Comment', N'Following up', CAST(N'2022-04-12 17:18:33.0758819' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (18, 0, N'Converted', N'Deal Done', CAST(N'2022-04-12 17:18:33.0777747' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (19, 0, N'Converted', N'Booked Payment awaited', CAST(N'2022-04-12 17:18:33.0796992' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (20, 0, N'Converted', N'Booked Payment received', CAST(N'2022-04-12 17:18:33.0820477' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (21, 0, N'Surrender', N'Give up', CAST(N'2022-04-12 17:18:33.0843959' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (22, 0, N'Surrender', N'Wrong no', CAST(N'2022-04-12 17:18:33.0864842' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (23, 0, N'Surrender', N'Wrong inquiry', CAST(N'2022-04-12 17:18:33.0884062' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (24, 0, N'Surrender', N'Wrong city', CAST(N'2022-04-12 17:18:33.0905669' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (25, 0, N'Surrender', N'Wrong project', CAST(N'2022-04-12 17:18:33.0934144' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (26, 0, N'Closed', N'Query closed', CAST(N'2022-04-12 17:18:33.0955578' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (27, 0, N'Closed', N'Not responding', CAST(N'2022-04-12 17:18:33.0976815' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (28, 0, N'Closed', N'Repeat Query', CAST(N'2022-04-12 17:18:33.1000411' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (29, 0, N'Closed', N'Fake query', CAST(N'2022-04-12 17:18:33.1021967' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (30, 0, N'Closed', N'Low Budget', CAST(N'2022-04-12 17:18:33.1043195' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (31, 0, N'Closed', N'Junk', CAST(N'2022-04-12 17:18:33.1063361' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (32, 0, N'Soldout', N'Property Sold by Me', CAST(N'2022-04-12 17:18:33.1091358' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (33, 0, N'Soldout', N'Property Sold out by Team', CAST(N'2022-04-12 17:18:33.1113440' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (34, 0, N'Soldout', N'Property Sold by other agent', CAST(N'2022-04-12 17:18:33.1133678' AS DateTime2), NULL)
INSERT [dbo].[LeadRemarks] ([Id], [Tid], [Status], [Name], [CreatedDate], [UpdatedDate]) VALUES (35, 0, N'Soldout', N'Property Sold by owner', CAST(N'2022-04-12 17:18:33.1155106' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[LeadRemarks] OFF
SET IDENTITY_INSERT [dbo].[LeadSource] ON 

INSERT [dbo].[LeadSource] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, N'SMS', 1, CAST(N'2022-04-12 17:18:32.9911039' AS DateTime2), NULL)
INSERT [dbo].[LeadSource] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (2, 0, N'Google', 1, CAST(N'2022-04-12 17:18:33.0151863' AS DateTime2), NULL)
INSERT [dbo].[LeadSource] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (3, 0, N'Facebook', 1, CAST(N'2022-04-12 17:18:33.0172088' AS DateTime2), NULL)
INSERT [dbo].[LeadSource] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (4, 0, N'YouTube', 1, CAST(N'2022-04-12 17:18:33.0189189' AS DateTime2), NULL)
INSERT [dbo].[LeadSource] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (5, 0, N'Emailer', 1, CAST(N'2022-04-12 17:18:33.0212128' AS DateTime2), NULL)
INSERT [dbo].[LeadSource] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (6, 0, N'walkin', 1, CAST(N'2022-04-12 17:18:33.0228603' AS DateTime2), NULL)
INSERT [dbo].[LeadSource] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (7, 0, N'99Acres', 1, CAST(N'2022-04-12 17:18:33.0246034' AS DateTime2), NULL)
INSERT [dbo].[LeadSource] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (8, 0, N'Magicbricks', 1, CAST(N'2022-04-12 17:18:33.0263828' AS DateTime2), NULL)
INSERT [dbo].[LeadSource] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (9, 0, N'Housing', 1, CAST(N'2022-04-12 17:18:33.0282917' AS DateTime2), NULL)
INSERT [dbo].[LeadSource] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (10, 0, N'Website', 1, CAST(N'2022-04-20 11:21:02.6645696' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[LeadSource] OFF
SET IDENTITY_INSERT [dbo].[LeadTag] ON 

INSERT [dbo].[LeadTag] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, N'Vip', 1, CAST(N'2022-04-12 17:18:32.8990174' AS DateTime2), NULL)
INSERT [dbo].[LeadTag] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (2, 0, N'Sincere', 1, CAST(N'2022-04-12 17:18:32.9161801' AS DateTime2), NULL)
INSERT [dbo].[LeadTag] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (3, 0, N'Hurry', 1, CAST(N'2022-04-12 17:18:32.9180217' AS DateTime2), NULL)
INSERT [dbo].[LeadTag] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (4, 0, N'Cold', 1, CAST(N'2022-04-12 17:18:32.9196253' AS DateTime2), NULL)
INSERT [dbo].[LeadTag] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (5, 0, N'Warm', 1, CAST(N'2022-04-12 17:18:32.9209879' AS DateTime2), NULL)
INSERT [dbo].[LeadTag] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (6, 0, N'Hot', 1, CAST(N'2022-04-12 17:18:32.9223391' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[LeadTag] OFF
SET IDENTITY_INSERT [dbo].[LeadTagMapping] ON 

INSERT [dbo].[LeadTagMapping] ([Id], [Tid], [LeadId], [LeadTagId], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, 1, 2, 1, CAST(N'2022-04-13 12:48:55.9165920' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[LeadTagMapping] OFF
SET IDENTITY_INSERT [dbo].[LeadType] ON 

INSERT [dbo].[LeadType] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, N'Buy', 1, CAST(N'2022-04-12 17:18:32.9237850' AS DateTime2), NULL)
INSERT [dbo].[LeadType] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (2, 0, N'Rent', 1, CAST(N'2022-04-12 17:18:32.9416685' AS DateTime2), NULL)
INSERT [dbo].[LeadType] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (3, 0, N'Sell', 1, CAST(N'2022-04-12 17:18:32.9435793' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[LeadType] OFF
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, 1, N'Ram Bag', 1, CAST(N'2022-04-12 21:36:57.8800149' AS DateTime2), NULL)
INSERT [dbo].[Location] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (2, 0, 3, N'Mohali', 1, CAST(N'2022-04-13 11:36:21.9869391' AS DateTime2), NULL)
INSERT [dbo].[Location] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (3, 0, 1, N'Yamuna Nagar', 1, CAST(N'2022-04-13 11:37:01.9463851' AS DateTime2), NULL)
INSERT [dbo].[Location] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (4, 0, 1, N'Rohtak', 1, CAST(N'2022-04-13 11:37:19.7983724' AS DateTime2), NULL)
INSERT [dbo].[Location] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (5, 0, 4, N'Wave Mall', 1, CAST(N'2022-04-15 10:59:42.9821867' AS DateTime2), NULL)
INSERT [dbo].[Location] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (6, 0, 4, N'Bramaputra Market', 0, CAST(N'2022-04-15 11:00:44.2748742' AS DateTime2), NULL)
INSERT [dbo].[Location] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (7, 0, 5, N'Hosur Road', 1, CAST(N'2022-04-15 11:02:03.3784038' AS DateTime2), NULL)
INSERT [dbo].[Location] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (8, 0, 5, N'Whitefield', 1, CAST(N'2022-04-15 11:02:55.4079222' AS DateTime2), NULL)
INSERT [dbo].[Location] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (9, 0, 5, N'Indranagar', 1, CAST(N'2022-04-15 11:03:15.9405644' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Location] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Tid], [PropertyCategoryId], [PropertySubcategoryId], [Name], [Description], [MetaTag], [MetaDescription], [CityId], [LocationId], [SocietyId], [AddressPlain], [Address], [AddressLat], [AddressLng], [Type], [PropertyDimType], [TotalArea], [PropertyPrice], [TotalPropertyPrice], [ConstructionStatus], [Bedroom], [Parking], [Bathrooms], [MaintenanceCharges], [TotalMaintenanceCharges], [CentralizedAc], [SecurityGuard], [FireSafety], [CctvCamera], [Lift], [club], [SwimmingPool], [GardenArea], [KidsPlayArea], [Gym], [PropertyFloor], [Furnished], [MaxSaleRate], [OwnerName], [OwnerPhoneNumber], [OwnerEmailId], [Source], [ReferenceName], [ReferenceNumber], [MainImage], [EmbadVideo], [CreatedDate], [CreatedBy], [ActiveStatus], [Status], [ViewCount], [RecIdOld], [VideoLink], [UpdatedDate], [AlertDate], [ProjectId], [ImagePath1], [ImagePath2], [ImagePath3], [ImagePath4], [ImagePath5], [ImagePath6], [ImagePath7], [ImagePath8], [ImagePath9], [ImagePath10], [SubCategoryId]) VALUES (2, 0, 2, 11, N'Diamond Enclave New Delhi', NULL, NULL, NULL, 1, 3, 1, N'H.No. 158 Diamond Enclave', NULL, NULL, NULL, N'Sell', N'Sq.Ft.', CAST(800.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), N'5000000', N'Ready to move', N'4', N'Open', N'2', N'2500', N'8000', 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, NULL, N'Full Furnished', CAST(6000000.00 AS Decimal(18, 2)), N'John Carton', N'1231231232', N'jc@gmail.com', NULL, NULL, NULL, N'Uploads/Product/132957928225315011.jpg', NULL, CAST(N'2022-04-13 13:25:41.9231117' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', 2, NULL, 2, 0, NULL, CAST(N'2022-04-30 17:17:02.5850355' AS DateTime2), NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Tid], [PropertyCategoryId], [PropertySubcategoryId], [Name], [Description], [MetaTag], [MetaDescription], [CityId], [LocationId], [SocietyId], [AddressPlain], [Address], [AddressLat], [AddressLng], [Type], [PropertyDimType], [TotalArea], [PropertyPrice], [TotalPropertyPrice], [ConstructionStatus], [Bedroom], [Parking], [Bathrooms], [MaintenanceCharges], [TotalMaintenanceCharges], [CentralizedAc], [SecurityGuard], [FireSafety], [CctvCamera], [Lift], [club], [SwimmingPool], [GardenArea], [KidsPlayArea], [Gym], [PropertyFloor], [Furnished], [MaxSaleRate], [OwnerName], [OwnerPhoneNumber], [OwnerEmailId], [Source], [ReferenceName], [ReferenceNumber], [MainImage], [EmbadVideo], [CreatedDate], [CreatedBy], [ActiveStatus], [Status], [ViewCount], [RecIdOld], [VideoLink], [UpdatedDate], [AlertDate], [ProjectId], [ImagePath1], [ImagePath2], [ImagePath3], [ImagePath4], [ImagePath5], [ImagePath6], [ImagePath7], [ImagePath8], [ImagePath9], [ImagePath10], [SubCategoryId]) VALUES (3, 0, 2, 16, N'Doctor Enclave, 4 BHK Apartment, Chandigarh', NULL, NULL, NULL, 3, 2, 2, NULL, NULL, NULL, NULL, N'Sell', N'Sq.Ft.', CAST(3000.00 AS Decimal(18, 2)), CAST(25000.00 AS Decimal(18, 2)), N'60000000', N'Ready to move', N'6', N'Cover', N'5', N'2000', N'8000', 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, NULL, N'Full Furnished', CAST(65000000.00 AS Decimal(18, 2)), N'Pankaj Jain', N'1122112233', N'pj@gmail.com', NULL, NULL, NULL, N'Uploads/Product/132943195064641009.jpg', NULL, CAST(N'2022-04-13 16:01:46.5071081' AS DateTime2), N'bf7cf1d3-db92-4584-a2e1-04fbab8249d1', 2, NULL, 3, 0, NULL, CAST(N'2022-04-20 13:28:32.5264402' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Tid], [PropertyCategoryId], [PropertySubcategoryId], [Name], [Description], [MetaTag], [MetaDescription], [CityId], [LocationId], [SocietyId], [AddressPlain], [Address], [AddressLat], [AddressLng], [Type], [PropertyDimType], [TotalArea], [PropertyPrice], [TotalPropertyPrice], [ConstructionStatus], [Bedroom], [Parking], [Bathrooms], [MaintenanceCharges], [TotalMaintenanceCharges], [CentralizedAc], [SecurityGuard], [FireSafety], [CctvCamera], [Lift], [club], [SwimmingPool], [GardenArea], [KidsPlayArea], [Gym], [PropertyFloor], [Furnished], [MaxSaleRate], [OwnerName], [OwnerPhoneNumber], [OwnerEmailId], [Source], [ReferenceName], [ReferenceNumber], [MainImage], [EmbadVideo], [CreatedDate], [CreatedBy], [ActiveStatus], [Status], [ViewCount], [RecIdOld], [VideoLink], [UpdatedDate], [AlertDate], [ProjectId], [ImagePath1], [ImagePath2], [ImagePath3], [ImagePath4], [ImagePath5], [ImagePath6], [ImagePath7], [ImagePath8], [ImagePath9], [ImagePath10], [SubCategoryId]) VALUES (4, 0, 2, 11, N'Sunny Enclave', NULL, NULL, NULL, 1, 3, 1, N'H.No. 158 Diamond Enclave', NULL, NULL, NULL, N'Sell', N'Sq.Ft.', CAST(800.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), N'5000000', N'Ready to move', N'4', N'Open', N'2', N'2500', N'8000', 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, NULL, N'Full Furnished', CAST(6000000.00 AS Decimal(18, 2)), N'John Carton', N'1231231232', N'jc@gmail.com', NULL, NULL, NULL, N'Uploads/Product/132957928225315011.jpg', NULL, CAST(N'2022-04-13 13:25:41.9231117' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', 2, NULL, 4, 0, NULL, CAST(N'2022-04-30 17:17:02.5850355' AS DateTime2), NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Tid], [PropertyCategoryId], [PropertySubcategoryId], [Name], [Description], [MetaTag], [MetaDescription], [CityId], [LocationId], [SocietyId], [AddressPlain], [Address], [AddressLat], [AddressLng], [Type], [PropertyDimType], [TotalArea], [PropertyPrice], [TotalPropertyPrice], [ConstructionStatus], [Bedroom], [Parking], [Bathrooms], [MaintenanceCharges], [TotalMaintenanceCharges], [CentralizedAc], [SecurityGuard], [FireSafety], [CctvCamera], [Lift], [club], [SwimmingPool], [GardenArea], [KidsPlayArea], [Gym], [PropertyFloor], [Furnished], [MaxSaleRate], [OwnerName], [OwnerPhoneNumber], [OwnerEmailId], [Source], [ReferenceName], [ReferenceNumber], [MainImage], [EmbadVideo], [CreatedDate], [CreatedBy], [ActiveStatus], [Status], [ViewCount], [RecIdOld], [VideoLink], [UpdatedDate], [AlertDate], [ProjectId], [ImagePath1], [ImagePath2], [ImagePath3], [ImagePath4], [ImagePath5], [ImagePath6], [ImagePath7], [ImagePath8], [ImagePath9], [ImagePath10], [SubCategoryId]) VALUES (5, 0, 2, 11, N'Villa For Rent', NULL, NULL, NULL, 1, 3, 1, N'H.No. 158 Diamond Enclave', NULL, NULL, NULL, N'Sell', N'Sq.Ft.', CAST(800.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), N'5000000', N'Ready to move', N'4', N'Open', N'2', N'2500', N'8000', 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, NULL, N'Full Furnished', CAST(6000000.00 AS Decimal(18, 2)), N'John Carton', N'1231231232', N'jc@gmail.com', NULL, NULL, NULL, N'Uploads/Product/132957928225315011.jpg', NULL, CAST(N'2022-04-13 13:25:41.9231117' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', 2, NULL, 2, 0, NULL, CAST(N'2022-04-30 17:17:02.5850355' AS DateTime2), NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Tid], [PropertyCategoryId], [PropertySubcategoryId], [Name], [Description], [MetaTag], [MetaDescription], [CityId], [LocationId], [SocietyId], [AddressPlain], [Address], [AddressLat], [AddressLng], [Type], [PropertyDimType], [TotalArea], [PropertyPrice], [TotalPropertyPrice], [ConstructionStatus], [Bedroom], [Parking], [Bathrooms], [MaintenanceCharges], [TotalMaintenanceCharges], [CentralizedAc], [SecurityGuard], [FireSafety], [CctvCamera], [Lift], [club], [SwimmingPool], [GardenArea], [KidsPlayArea], [Gym], [PropertyFloor], [Furnished], [MaxSaleRate], [OwnerName], [OwnerPhoneNumber], [OwnerEmailId], [Source], [ReferenceName], [ReferenceNumber], [MainImage], [EmbadVideo], [CreatedDate], [CreatedBy], [ActiveStatus], [Status], [ViewCount], [RecIdOld], [VideoLink], [UpdatedDate], [AlertDate], [ProjectId], [ImagePath1], [ImagePath2], [ImagePath3], [ImagePath4], [ImagePath5], [ImagePath6], [ImagePath7], [ImagePath8], [ImagePath9], [ImagePath10], [SubCategoryId]) VALUES (6, 0, 2, 11, N'Block For Sale', NULL, NULL, NULL, 1, 3, 1, N'H.No. 158 Diamond Enclave', NULL, NULL, NULL, N'Sell', N'Sq.Ft.', CAST(800.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), N'5000000', N'Ready to move', N'4', N'Open', N'2', N'2500', N'8000', 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, NULL, N'Full Furnished', CAST(6000000.00 AS Decimal(18, 2)), N'John Carton', N'1231231232', N'jc@gmail.com', NULL, NULL, NULL, N'Uploads/Product/132957928225315011.jpg', NULL, CAST(N'2022-04-13 13:25:41.9231117' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', 2, NULL, 2, 0, NULL, CAST(N'2022-04-30 17:17:02.5850355' AS DateTime2), NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Tid], [PropertyCategoryId], [PropertySubcategoryId], [Name], [Description], [MetaTag], [MetaDescription], [CityId], [LocationId], [SocietyId], [AddressPlain], [Address], [AddressLat], [AddressLng], [Type], [PropertyDimType], [TotalArea], [PropertyPrice], [TotalPropertyPrice], [ConstructionStatus], [Bedroom], [Parking], [Bathrooms], [MaintenanceCharges], [TotalMaintenanceCharges], [CentralizedAc], [SecurityGuard], [FireSafety], [CctvCamera], [Lift], [club], [SwimmingPool], [GardenArea], [KidsPlayArea], [Gym], [PropertyFloor], [Furnished], [MaxSaleRate], [OwnerName], [OwnerPhoneNumber], [OwnerEmailId], [Source], [ReferenceName], [ReferenceNumber], [MainImage], [EmbadVideo], [CreatedDate], [CreatedBy], [ActiveStatus], [Status], [ViewCount], [RecIdOld], [VideoLink], [UpdatedDate], [AlertDate], [ProjectId], [ImagePath1], [ImagePath2], [ImagePath3], [ImagePath4], [ImagePath5], [ImagePath6], [ImagePath7], [ImagePath8], [ImagePath9], [ImagePath10], [SubCategoryId]) VALUES (7, 0, 2, 11, N'OpLw For Students', NULL, NULL, NULL, 1, 3, 1, N'H.No. 158 Diamond Enclave', NULL, NULL, NULL, N'Sell', N'Sq.Ft.', CAST(800.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), N'5000000', N'Ready to move', N'4', N'Open', N'2', N'2500', N'8000', 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, NULL, N'Full Furnished', CAST(6000000.00 AS Decimal(18, 2)), N'John Carton', N'1231231232', N'jc@gmail.com', NULL, NULL, NULL, N'Uploads/Product/132957928225315011.jpg', NULL, CAST(N'2022-04-13 13:25:41.9231117' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', 2, NULL, 2, 0, NULL, CAST(N'2022-04-30 17:17:02.5850355' AS DateTime2), NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Tid], [PropertyCategoryId], [PropertySubcategoryId], [Name], [Description], [MetaTag], [MetaDescription], [CityId], [LocationId], [SocietyId], [AddressPlain], [Address], [AddressLat], [AddressLng], [Type], [PropertyDimType], [TotalArea], [PropertyPrice], [TotalPropertyPrice], [ConstructionStatus], [Bedroom], [Parking], [Bathrooms], [MaintenanceCharges], [TotalMaintenanceCharges], [CentralizedAc], [SecurityGuard], [FireSafety], [CctvCamera], [Lift], [club], [SwimmingPool], [GardenArea], [KidsPlayArea], [Gym], [PropertyFloor], [Furnished], [MaxSaleRate], [OwnerName], [OwnerPhoneNumber], [OwnerEmailId], [Source], [ReferenceName], [ReferenceNumber], [MainImage], [EmbadVideo], [CreatedDate], [CreatedBy], [ActiveStatus], [Status], [ViewCount], [RecIdOld], [VideoLink], [UpdatedDate], [AlertDate], [TotalBlocks], [TotalFloors], [TotalFlats]) VALUES (2, 0, 2, 14, N'abhilesh colony new delhi', NULL, NULL, NULL, 1, 4, 1, N'         abhilesh colony new delhi', NULL, NULL, NULL, N'Sell', N'Sq.Ft.', CAST(500.00 AS Decimal(18, 2)), CAST(15000.00 AS Decimal(18, 2)), N'5000000', N'Ready to move', N'3', N'Cover', N'2', N'2000', N'8000', 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, NULL, N'Full Furnished', CAST(6000000.00 AS Decimal(18, 2)), N'Rajesh chohan', N'9874563210', N'rc@gmail.com', NULL, NULL, NULL, N'Uploads/Project/132943104236118123.jpg', NULL, CAST(N'2022-04-13 13:10:02.9189037' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', 2, NULL, 3, 0, NULL, CAST(N'2022-04-13 13:30:23.6442342' AS DateTime2), NULL, N'4', N'2', N'2')
INSERT [dbo].[Project] ([Id], [Tid], [PropertyCategoryId], [PropertySubcategoryId], [Name], [Description], [MetaTag], [MetaDescription], [CityId], [LocationId], [SocietyId], [AddressPlain], [Address], [AddressLat], [AddressLng], [Type], [PropertyDimType], [TotalArea], [PropertyPrice], [TotalPropertyPrice], [ConstructionStatus], [Bedroom], [Parking], [Bathrooms], [MaintenanceCharges], [TotalMaintenanceCharges], [CentralizedAc], [SecurityGuard], [FireSafety], [CctvCamera], [Lift], [club], [SwimmingPool], [GardenArea], [KidsPlayArea], [Gym], [PropertyFloor], [Furnished], [MaxSaleRate], [OwnerName], [OwnerPhoneNumber], [OwnerEmailId], [Source], [ReferenceName], [ReferenceNumber], [MainImage], [EmbadVideo], [CreatedDate], [CreatedBy], [ActiveStatus], [Status], [ViewCount], [RecIdOld], [VideoLink], [UpdatedDate], [AlertDate], [TotalBlocks], [TotalFloors], [TotalFlats]) VALUES (3, 0, 1, 4, N'Doctor Colony Chandigarh', NULL, NULL, NULL, 3, 2, 3, N'H.No. 152 Doctor Colony', NULL, NULL, NULL, N'Rent', N'Sq.Ft.', CAST(800.00 AS Decimal(18, 2)), CAST(12000.00 AS Decimal(18, 2)), N'6000000', N'Ready to move', N'5', N'Open', N'4', N'2500', N'10000', 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, NULL, N'Full Furnished', CAST(65000000.00 AS Decimal(18, 2)), N'Ram Parsad', N'1234567890', N'rp@gmail.com', NULL, NULL, NULL, N'Uploads/Project/132943104048602034.jpg', NULL, CAST(N'2022-04-13 13:15:50.1276405' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', 2, NULL, 6, 0, NULL, CAST(N'2022-04-13 13:30:04.8678713' AS DateTime2), NULL, N'3', N'2', N'6')
INSERT [dbo].[Project] ([Id], [Tid], [PropertyCategoryId], [PropertySubcategoryId], [Name], [Description], [MetaTag], [MetaDescription], [CityId], [LocationId], [SocietyId], [AddressPlain], [Address], [AddressLat], [AddressLng], [Type], [PropertyDimType], [TotalArea], [PropertyPrice], [TotalPropertyPrice], [ConstructionStatus], [Bedroom], [Parking], [Bathrooms], [MaintenanceCharges], [TotalMaintenanceCharges], [CentralizedAc], [SecurityGuard], [FireSafety], [CctvCamera], [Lift], [club], [SwimmingPool], [GardenArea], [KidsPlayArea], [Gym], [PropertyFloor], [Furnished], [MaxSaleRate], [OwnerName], [OwnerPhoneNumber], [OwnerEmailId], [Source], [ReferenceName], [ReferenceNumber], [MainImage], [EmbadVideo], [CreatedDate], [CreatedBy], [ActiveStatus], [Status], [ViewCount], [RecIdOld], [VideoLink], [UpdatedDate], [AlertDate], [TotalBlocks], [TotalFloors], [TotalFlats]) VALUES (4, 0, 2, 17, N'3 BHK Apartment Chandigarh', NULL, NULL, NULL, 3, 2, 2, N'Sargodha Society Chandigarh', NULL, NULL, NULL, N'Sell', N'Sq.Ft.', CAST(1000.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), N'25500000', N'Ready to move', N'4', N'Open', N'3', N'2500', N'10000', 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, NULL, N'Full Furnished', CAST(26000000.00 AS Decimal(18, 2)), N'Pk Mishra', N'1212121212', N'pk@gmail.com', NULL, NULL, NULL, N'Uploads/Project/132943103857680699.jpg', NULL, CAST(N'2022-04-13 13:20:04.1758166' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', 2, NULL, 7, 0, NULL, CAST(N'2022-04-13 13:29:45.9375819' AS DateTime2), NULL, N'8', N'2', N'10')
INSERT [dbo].[Project] ([Id], [Tid], [PropertyCategoryId], [PropertySubcategoryId], [Name], [Description], [MetaTag], [MetaDescription], [CityId], [LocationId], [SocietyId], [AddressPlain], [Address], [AddressLat], [AddressLng], [Type], [PropertyDimType], [TotalArea], [PropertyPrice], [TotalPropertyPrice], [ConstructionStatus], [Bedroom], [Parking], [Bathrooms], [MaintenanceCharges], [TotalMaintenanceCharges], [CentralizedAc], [SecurityGuard], [FireSafety], [CctvCamera], [Lift], [club], [SwimmingPool], [GardenArea], [KidsPlayArea], [Gym], [PropertyFloor], [Furnished], [MaxSaleRate], [OwnerName], [OwnerPhoneNumber], [OwnerEmailId], [Source], [ReferenceName], [ReferenceNumber], [MainImage], [EmbadVideo], [CreatedDate], [CreatedBy], [ActiveStatus], [Status], [ViewCount], [RecIdOld], [VideoLink], [UpdatedDate], [AlertDate], [TotalBlocks], [TotalFloors], [TotalFlats]) VALUES (5, 0, 1, 3, N'Commercial Office, New Delhi', NULL, NULL, NULL, 1, 4, 1, N'Arpita Heights Commercial', NULL, NULL, NULL, N'Rent', N'Sq.Ft.', CAST(8000.00 AS Decimal(18, 2)), CAST(50000.00 AS Decimal(18, 2)), NULL, N'Ready to move', N'No', N'Basement', N'Shared', N'20000', N'25000', 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, NULL, N'Full Furnished', CAST(0.00 AS Decimal(18, 2)), N'Parmod Kalia', N'1122112233', N'pk@gmail.com', NULL, NULL, NULL, N'Uploads/Project/132943209882876627.jpg', NULL, CAST(N'2022-04-13 16:26:28.3248543' AS DateTime2), N'37a00614-acf2-4475-a7b3-ffa94943e49c', 2, N'Active', 3, 0, NULL, NULL, NULL, N'20', N'16', N'120')
INSERT [dbo].[Project] ([Id], [Tid], [PropertyCategoryId], [PropertySubcategoryId], [Name], [Description], [MetaTag], [MetaDescription], [CityId], [LocationId], [SocietyId], [AddressPlain], [Address], [AddressLat], [AddressLng], [Type], [PropertyDimType], [TotalArea], [PropertyPrice], [TotalPropertyPrice], [ConstructionStatus], [Bedroom], [Parking], [Bathrooms], [MaintenanceCharges], [TotalMaintenanceCharges], [CentralizedAc], [SecurityGuard], [FireSafety], [CctvCamera], [Lift], [club], [SwimmingPool], [GardenArea], [KidsPlayArea], [Gym], [PropertyFloor], [Furnished], [MaxSaleRate], [OwnerName], [OwnerPhoneNumber], [OwnerEmailId], [Source], [ReferenceName], [ReferenceNumber], [MainImage], [EmbadVideo], [CreatedDate], [CreatedBy], [ActiveStatus], [Status], [ViewCount], [RecIdOld], [VideoLink], [UpdatedDate], [AlertDate], [TotalBlocks], [TotalFloors], [TotalFlats]) VALUES (6, 0, 2, 14, N'Nagar colony new Asr', NULL, NULL, NULL, 1, 4, 1, N'         abhilesh colony new delhi', NULL, NULL, NULL, N'Sell', N'Sq.Ft.', CAST(500.00 AS Decimal(18, 2)), CAST(15000.00 AS Decimal(18, 2)), N'5000000', N'Ready to move', N'3', N'Cover', N'2', N'2000', N'8000', 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, NULL, N'Full Furnished', CAST(6000000.00 AS Decimal(18, 2)), N'Rajesh chohan', N'9874563210', N'rc@gmail.com', NULL, NULL, NULL, N'Uploads/Project/132943104236118123.jpg', NULL, CAST(N'2022-04-13 13:10:02.9189037' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', 2, NULL, 3, 0, NULL, CAST(N'2022-04-13 13:30:23.6442342' AS DateTime2), NULL, N'4', N'2', N'2')
INSERT [dbo].[Project] ([Id], [Tid], [PropertyCategoryId], [PropertySubcategoryId], [Name], [Description], [MetaTag], [MetaDescription], [CityId], [LocationId], [SocietyId], [AddressPlain], [Address], [AddressLat], [AddressLng], [Type], [PropertyDimType], [TotalArea], [PropertyPrice], [TotalPropertyPrice], [ConstructionStatus], [Bedroom], [Parking], [Bathrooms], [MaintenanceCharges], [TotalMaintenanceCharges], [CentralizedAc], [SecurityGuard], [FireSafety], [CctvCamera], [Lift], [club], [SwimmingPool], [GardenArea], [KidsPlayArea], [Gym], [PropertyFloor], [Furnished], [MaxSaleRate], [OwnerName], [OwnerPhoneNumber], [OwnerEmailId], [Source], [ReferenceName], [ReferenceNumber], [MainImage], [EmbadVideo], [CreatedDate], [CreatedBy], [ActiveStatus], [Status], [ViewCount], [RecIdOld], [VideoLink], [UpdatedDate], [AlertDate], [TotalBlocks], [TotalFloors], [TotalFlats]) VALUES (7, 0, 2, 14, N'OWjan colony', NULL, NULL, NULL, 1, 4, 1, N'         abhilesh colony new delhi', NULL, NULL, NULL, N'Sell', N'Sq.Ft.', CAST(500.00 AS Decimal(18, 2)), CAST(15000.00 AS Decimal(18, 2)), N'5000000', N'Ready to move', N'3', N'Cover', N'2', N'2000', N'8000', 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, NULL, N'Full Furnished', CAST(6000000.00 AS Decimal(18, 2)), N'Rajesh chohan', N'9874563210', N'rc@gmail.com', NULL, NULL, NULL, N'Uploads/Project/132943104236118123.jpg', NULL, CAST(N'2022-04-13 13:10:02.9189037' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', 2, NULL, 3, 0, NULL, CAST(N'2022-04-13 13:30:23.6442342' AS DateTime2), NULL, N'4', N'2', N'2')
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[ProjectTagMapping] ON 

INSERT [dbo].[ProjectTagMapping] ([Id], [Tid], [ProjectId], [InventoryTagId], [Status], [CreatedDate], [UpdatedDate]) VALUES (6, 0, 4, 6, 1, CAST(N'2022-04-13 13:29:46.2513222' AS DateTime2), NULL)
INSERT [dbo].[ProjectTagMapping] ([Id], [Tid], [ProjectId], [InventoryTagId], [Status], [CreatedDate], [UpdatedDate]) VALUES (7, 0, 4, 4, 1, CAST(N'2022-04-13 13:29:46.3225247' AS DateTime2), NULL)
INSERT [dbo].[ProjectTagMapping] ([Id], [Tid], [ProjectId], [InventoryTagId], [Status], [CreatedDate], [UpdatedDate]) VALUES (8, 0, 3, 5, 1, CAST(N'2022-04-13 13:30:04.8783091' AS DateTime2), NULL)
INSERT [dbo].[ProjectTagMapping] ([Id], [Tid], [ProjectId], [InventoryTagId], [Status], [CreatedDate], [UpdatedDate]) VALUES (9, 0, 3, 3, 1, CAST(N'2022-04-13 13:30:04.8803262' AS DateTime2), NULL)
INSERT [dbo].[ProjectTagMapping] ([Id], [Tid], [ProjectId], [InventoryTagId], [Status], [CreatedDate], [UpdatedDate]) VALUES (10, 0, 2, 3, 1, CAST(N'2022-04-13 13:30:23.6512381' AS DateTime2), NULL)
INSERT [dbo].[ProjectTagMapping] ([Id], [Tid], [ProjectId], [InventoryTagId], [Status], [CreatedDate], [UpdatedDate]) VALUES (11, 0, 5, 3, 1, CAST(N'2022-04-13 16:26:28.5446717' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[ProjectTagMapping] OFF
SET IDENTITY_INSERT [dbo].[Slider] ON 

INSERT [dbo].[Slider] ([Id], [Tid], [ImagePath], [Url], [Status], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1, 0, N'Uploads/Slider/132943020180140940.png', N'https://simaxsys.com/', 1, CAST(N'2022-04-13 11:10:18.0360270' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Slider] ([Id], [Tid], [ImagePath], [Url], [Status], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (2, 0, N'Uploads/Slider/132943020399972933.jpg', N'https://simaxsys.com/', 1, CAST(N'2022-04-13 11:10:40.0031322' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Slider] ([Id], [Tid], [ImagePath], [Url], [Status], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (3, 0, N'Uploads/Slider/132943021356347408.jpg', N'https://simaxsys.com/', 1, CAST(N'2022-04-13 11:12:15.6400251' AS DateTime2), N'd157deb0-521e-45ac-9fce-da07b09b858c', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Slider] OFF
SET IDENTITY_INSERT [dbo].[Society] ON 

INSERT [dbo].[Society] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, 1, N'Local Hub', 1, CAST(N'2022-04-12 21:37:06.4215666' AS DateTime2), NULL)
INSERT [dbo].[Society] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (2, 0, 3, N'Sargodha Society', 1, CAST(N'2022-04-13 11:38:23.6867686' AS DateTime2), NULL)
INSERT [dbo].[Society] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (3, 0, 3, N'Laxmi Society', 1, CAST(N'2022-04-13 11:38:40.5569624' AS DateTime2), NULL)
INSERT [dbo].[Society] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (4, 0, 5, N'Brigade Gateway, Bangalore West', 1, CAST(N'2022-04-15 11:05:15.0733896' AS DateTime2), NULL)
INSERT [dbo].[Society] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (5, 0, 5, N'Tata New Haven, Bangalore', 1, CAST(N'2022-04-15 11:06:26.5795777' AS DateTime2), NULL)
INSERT [dbo].[Society] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (6, 0, 4, N'Amrapali Platinum', 1, CAST(N'2022-04-15 11:08:00.1724466' AS DateTime2), NULL)
INSERT [dbo].[Society] ([Id], [Tid], [CityId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (7, 0, 4, N'Supertech Cape Town', 1, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2022-04-15 11:08:33.4205509' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Society] OFF
SET IDENTITY_INSERT [dbo].[SubCategory] ON 

INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, 1, N'Commercial Shops', 1, CAST(N'2022-04-12 17:18:32.8543720' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (2, 0, 1, N'Commercial Showrooms', 1, CAST(N'2022-04-12 17:18:32.8762371' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (3, 0, 1, N'Commercial Office/Space', 1, CAST(N'2022-04-12 17:18:32.8778735' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (4, 0, 1, N'Commercial Land/Building', 1, CAST(N'2022-04-12 17:18:32.8790260' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (5, 0, 1, N'Industrial Lands/Plots', 1, CAST(N'2022-04-12 17:18:32.8800867' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (6, 0, 1, N'Agricultural Land', 1, CAST(N'2022-04-12 17:18:32.8817399' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (7, 0, 1, N'Hotel/Resorts', 1, CAST(N'2022-04-12 17:18:32.8829924' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (8, 0, 1, N'Guest-House/Banquet-Halls', 1, CAST(N'2022-04-12 17:18:32.8842854' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (9, 0, 1, N'Institutional Land/Building', 1, CAST(N'2022-04-12 17:18:32.8855142' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (10, 0, 1, N'Other', 1, CAST(N'2022-04-12 17:18:32.8867864' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (11, 0, 2, N'Apartment', 1, CAST(N'2022-04-12 17:18:32.8880453' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (12, 0, 2, N'Independent/Builder Floor', 1, CAST(N'2022-04-12 17:18:32.8892775' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (13, 0, 2, N'Independent House/Villa', 1, CAST(N'2022-04-12 17:18:32.8905721' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (14, 0, 2, N'Residential Land', 1, CAST(N'2022-04-12 17:18:32.8920316' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (15, 0, 2, N'Studio Apartment', 1, CAST(N'2022-04-12 17:18:32.8933850' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (16, 0, 2, N'Farm House', 1, CAST(N'2022-04-12 17:18:32.8947516' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (17, 0, 2, N'Serviced Apartments', 1, CAST(N'2022-04-12 17:18:32.8960706' AS DateTime2), NULL)
INSERT [dbo].[SubCategory] ([Id], [Tid], [CategoryId], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (18, 0, 2, N'Other', 1, CAST(N'2022-04-12 17:18:32.8974480' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[SubCategory] OFF
SET IDENTITY_INSERT [dbo].[SystemSetup] ON 

INSERT [dbo].[SystemSetup] ([Id], [Tid], [CompanyName], [AddressPlain], [Address], [AddressLat], [AddressLng], [CompanyEmail], [CompanyContact], [CompanyGstNumber], [TaxPercent], [Currency], [CurrencySymbol], [CompanyLogo], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, N'Simax Real Estate', N'#378, Abc Road, UCA', N'New York, NY, USA', N'40.7127753', N'-74.0059728', N'ng.simar@gmail.com', N'+917009431080', N'VARHJHJHJH', CAST(10.00 AS Decimal(18, 2)), N'Doller', N'$', N'Uploads/CompanyLogo/132943880603580505.png', 1, CAST(N'2022-04-14 11:04:20.3668268' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[SystemSetup] OFF
SET IDENTITY_INSERT [dbo].[UploadCategory] ON 

INSERT [dbo].[UploadCategory] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (1, 0, N'Front', 1, CAST(N'2022-04-12 21:33:51.1257456' AS DateTime2), NULL)
INSERT [dbo].[UploadCategory] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (2, 0, N'Rooms', 1, CAST(N'2022-04-12 21:33:58.9796540' AS DateTime2), NULL)
INSERT [dbo].[UploadCategory] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (3, 0, N'Bathroom', 1, CAST(N'2022-04-12 21:34:08.5663132' AS DateTime2), NULL)
INSERT [dbo].[UploadCategory] ([Id], [Tid], [Name], [Status], [CreatedDate], [UpdatedDate]) VALUES (4, 0, N'Others', 1, CAST(N'2022-04-12 21:34:18.2144275' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[UploadCategory] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 01/05/2022 01:30 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 01/05/2022 01:30 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AttachmentProductMapping_AttachmentId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_AttachmentProductMapping_AttachmentId] ON [dbo].[AttachmentProductMapping]
(
	[AttachmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AttachmentProductMapping_ProductId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_AttachmentProductMapping_ProductId] ON [dbo].[AttachmentProductMapping]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AttachmentProductMapping_UploadCategoryId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_AttachmentProductMapping_UploadCategoryId] ON [dbo].[AttachmentProductMapping]
(
	[UploadCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AttachmentProjectMapping_AttachmentId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_AttachmentProjectMapping_AttachmentId] ON [dbo].[AttachmentProjectMapping]
(
	[AttachmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AttachmentProjectMapping_ProjectId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_AttachmentProjectMapping_ProjectId] ON [dbo].[AttachmentProjectMapping]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AttachmentProjectMapping_UploadCategoryId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_AttachmentProjectMapping_UploadCategoryId] ON [dbo].[AttachmentProjectMapping]
(
	[UploadCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CallLog_LeadId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_CallLog_LeadId] ON [dbo].[CallLog]
(
	[LeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CallLog_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_CallLog_UserId] ON [dbo].[CallLog]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CallLogProduct_ProductId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_CallLogProduct_ProductId] ON [dbo].[CallLogProduct]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CallLogProduct_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_CallLogProduct_UserId] ON [dbo].[CallLogProduct]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CustomerQuery_ProductId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_CustomerQuery_ProductId] ON [dbo].[CustomerQuery]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CustomerQuery_ProjectId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_CustomerQuery_ProjectId] ON [dbo].[CustomerQuery]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CustomerQuery_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_CustomerQuery_UserId] ON [dbo].[CustomerQuery]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryTagMapping_InventoryTagId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_InventoryTagMapping_InventoryTagId] ON [dbo].[InventoryTagMapping]
(
	[InventoryTagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryTagMapping_ProductId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_InventoryTagMapping_ProductId] ON [dbo].[InventoryTagMapping]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Invoice_LeadId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Invoice_LeadId] ON [dbo].[Invoice]
(
	[LeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvoiceDetail_InvoiceId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceDetail_InvoiceId] ON [dbo].[InvoiceDetail]
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Lead_DeletedById]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Lead_DeletedById] ON [dbo].[Lead]
(
	[DeletedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Lead_LeadSourceId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Lead_LeadSourceId] ON [dbo].[Lead]
(
	[LeadSourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Lead_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Lead_UserId] ON [dbo].[Lead]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_LeadAutoAssign_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadAutoAssign_UserId] ON [dbo].[LeadAutoAssign]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadAutoAssignLog_LeadId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadAutoAssignLog_LeadId] ON [dbo].[LeadAutoAssignLog]
(
	[LeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadAutoAssignLog_LeadSourceId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadAutoAssignLog_LeadSourceId] ON [dbo].[LeadAutoAssignLog]
(
	[LeadSourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_LeadAutoAssignLog_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadAutoAssignLog_UserId] ON [dbo].[LeadAutoAssignLog]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadAutoAssignSourceMapping_LeadAutoAssignId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadAutoAssignSourceMapping_LeadAutoAssignId] ON [dbo].[LeadAutoAssignSourceMapping]
(
	[LeadAutoAssignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadAutoAssignSourceMapping_LeadSourceId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadAutoAssignSourceMapping_LeadSourceId] ON [dbo].[LeadAutoAssignSourceMapping]
(
	[LeadSourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadOrder_PaymentLogId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadOrder_PaymentLogId] ON [dbo].[LeadOrder]
(
	[PaymentLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_LeadOrder_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadOrder_UserId] ON [dbo].[LeadOrder]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadOrderDetail_LeadId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadOrderDetail_LeadId] ON [dbo].[LeadOrderDetail]
(
	[LeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadOrderDetail_LeadOrderId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadOrderDetail_LeadOrderId] ON [dbo].[LeadOrderDetail]
(
	[LeadOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadProductMapping_LeadId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadProductMapping_LeadId] ON [dbo].[LeadProductMapping]
(
	[LeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadProductMapping_ProductId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadProductMapping_ProductId] ON [dbo].[LeadProductMapping]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadProjectMapping_LeadId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadProjectMapping_LeadId] ON [dbo].[LeadProjectMapping]
(
	[LeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadProjectMapping_ProjectId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadProjectMapping_ProjectId] ON [dbo].[LeadProjectMapping]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadTagMapping_LeadId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadTagMapping_LeadId] ON [dbo].[LeadTagMapping]
(
	[LeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeadTagMapping_LeadTagId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_LeadTagMapping_LeadTagId] ON [dbo].[LeadTagMapping]
(
	[LeadTagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Message_CreatedById]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Message_CreatedById] ON [dbo].[Message]
(
	[CreatedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MessageDetail_MessageId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_MessageDetail_MessageId] ON [dbo].[MessageDetail]
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MessageDetail_SentToUserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_MessageDetail_SentToUserId] ON [dbo].[MessageDetail]
(
	[SentToUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PaymentLog_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_PaymentLog_UserId] ON [dbo].[PaymentLog]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PhoneCallLeadLog_LeadId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_PhoneCallLeadLog_LeadId] ON [dbo].[PhoneCallLeadLog]
(
	[LeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PhoneCallLeadLog_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_PhoneCallLeadLog_UserId] ON [dbo].[PhoneCallLeadLog]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PhoneCallProductLog_ProductId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_PhoneCallProductLog_ProductId] ON [dbo].[PhoneCallProductLog]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PhoneCallProductLog_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_PhoneCallProductLog_UserId] ON [dbo].[PhoneCallProductLog]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_LocationId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_LocationId] ON [dbo].[Product]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_ProjectId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_ProjectId] ON [dbo].[Product]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_SocietyId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_SocietyId] ON [dbo].[Product]
(
	[SocietyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_SubCategoryId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_SubCategoryId] ON [dbo].[Product]
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Project_LocationId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Project_LocationId] ON [dbo].[Project]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Project_SocietyId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Project_SocietyId] ON [dbo].[Project]
(
	[SocietyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectTagMapping_InventoryTagId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectTagMapping_InventoryTagId] ON [dbo].[ProjectTagMapping]
(
	[InventoryTagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectTagMapping_ProjectId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectTagMapping_ProjectId] ON [dbo].[ProjectTagMapping]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubCategory_CategoryId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubCategory_CategoryId] ON [dbo].[SubCategory]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tcf_LeadId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tcf_LeadId] ON [dbo].[Tcf]
(
	[LeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserLog_LeadId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLog_LeadId] ON [dbo].[UserLog]
(
	[LeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserLog_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLog_UserId] ON [dbo].[UserLog]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserRating_CreatedBy]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRating_CreatedBy] ON [dbo].[UserRating]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRating_ProductId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRating_ProductId] ON [dbo].[UserRating]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRating_ProjectId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRating_ProjectId] ON [dbo].[UserRating]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserRating_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRating_UserId] ON [dbo].[UserRating]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Wallet_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Wallet_UserId] ON [dbo].[Wallet]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WalletDetail_PaymentLogId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_WalletDetail_PaymentLogId] ON [dbo].[WalletDetail]
(
	[PaymentLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WalletDetail_WalletId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_WalletDetail_WalletId] ON [dbo].[WalletDetail]
(
	[WalletId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Wishlist_ProductId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Wishlist_ProductId] ON [dbo].[Wishlist]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Wishlist_ProjectId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Wishlist_ProjectId] ON [dbo].[Wishlist]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Wishlist_UserId]    Script Date: 01/05/2022 01:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Wishlist_UserId] ON [dbo].[Wishlist]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AttachmentProductMapping]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentProductMapping_Attachment_AttachmentId] FOREIGN KEY([AttachmentId])
REFERENCES [dbo].[Attachment] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AttachmentProductMapping] CHECK CONSTRAINT [FK_AttachmentProductMapping_Attachment_AttachmentId]
GO
ALTER TABLE [dbo].[AttachmentProductMapping]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentProductMapping_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AttachmentProductMapping] CHECK CONSTRAINT [FK_AttachmentProductMapping_Product_ProductId]
GO
ALTER TABLE [dbo].[AttachmentProductMapping]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentProductMapping_UploadCategory_UploadCategoryId] FOREIGN KEY([UploadCategoryId])
REFERENCES [dbo].[UploadCategory] ([Id])
GO
ALTER TABLE [dbo].[AttachmentProductMapping] CHECK CONSTRAINT [FK_AttachmentProductMapping_UploadCategory_UploadCategoryId]
GO
ALTER TABLE [dbo].[AttachmentProjectMapping]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentProjectMapping_Attachment_AttachmentId] FOREIGN KEY([AttachmentId])
REFERENCES [dbo].[Attachment] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AttachmentProjectMapping] CHECK CONSTRAINT [FK_AttachmentProjectMapping_Attachment_AttachmentId]
GO
ALTER TABLE [dbo].[AttachmentProjectMapping]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentProjectMapping_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AttachmentProjectMapping] CHECK CONSTRAINT [FK_AttachmentProjectMapping_Project_ProjectId]
GO
ALTER TABLE [dbo].[AttachmentProjectMapping]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentProjectMapping_UploadCategory_UploadCategoryId] FOREIGN KEY([UploadCategoryId])
REFERENCES [dbo].[UploadCategory] ([Id])
GO
ALTER TABLE [dbo].[AttachmentProjectMapping] CHECK CONSTRAINT [FK_AttachmentProjectMapping_UploadCategory_UploadCategoryId]
GO
ALTER TABLE [dbo].[CallLog]  WITH CHECK ADD  CONSTRAINT [FK_CallLog_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[CallLog] CHECK CONSTRAINT [FK_CallLog_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CallLog]  WITH CHECK ADD  CONSTRAINT [FK_CallLog_Lead_LeadId] FOREIGN KEY([LeadId])
REFERENCES [dbo].[Lead] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CallLog] CHECK CONSTRAINT [FK_CallLog_Lead_LeadId]
GO
ALTER TABLE [dbo].[CallLogProduct]  WITH CHECK ADD  CONSTRAINT [FK_CallLogProduct_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[CallLogProduct] CHECK CONSTRAINT [FK_CallLogProduct_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CallLogProduct]  WITH CHECK ADD  CONSTRAINT [FK_CallLogProduct_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CallLogProduct] CHECK CONSTRAINT [FK_CallLogProduct_Product_ProductId]
GO
ALTER TABLE [dbo].[CustomerQuery]  WITH CHECK ADD  CONSTRAINT [FK_CustomerQuery_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[CustomerQuery] CHECK CONSTRAINT [FK_CustomerQuery_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CustomerQuery]  WITH CHECK ADD  CONSTRAINT [FK_CustomerQuery_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[CustomerQuery] CHECK CONSTRAINT [FK_CustomerQuery_Product_ProductId]
GO
ALTER TABLE [dbo].[CustomerQuery]  WITH CHECK ADD  CONSTRAINT [FK_CustomerQuery_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[CustomerQuery] CHECK CONSTRAINT [FK_CustomerQuery_Project_ProjectId]
GO
ALTER TABLE [dbo].[InventoryTagMapping]  WITH CHECK ADD  CONSTRAINT [FK_InventoryTagMapping_InventoryTag_InventoryTagId] FOREIGN KEY([InventoryTagId])
REFERENCES [dbo].[InventoryTag] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InventoryTagMapping] CHECK CONSTRAINT [FK_InventoryTagMapping_InventoryTag_InventoryTagId]
GO
ALTER TABLE [dbo].[InventoryTagMapping]  WITH CHECK ADD  CONSTRAINT [FK_InventoryTagMapping_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InventoryTagMapping] CHECK CONSTRAINT [FK_InventoryTagMapping_Product_ProductId]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Lead_LeadId] FOREIGN KEY([LeadId])
REFERENCES [dbo].[Lead] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Lead_LeadId]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Invoice_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Invoice_InvoiceId]
GO
ALTER TABLE [dbo].[Lead]  WITH CHECK ADD  CONSTRAINT [FK_Lead_AspNetUsers_DeletedById] FOREIGN KEY([DeletedById])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Lead] CHECK CONSTRAINT [FK_Lead_AspNetUsers_DeletedById]
GO
ALTER TABLE [dbo].[Lead]  WITH CHECK ADD  CONSTRAINT [FK_Lead_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Lead] CHECK CONSTRAINT [FK_Lead_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Lead]  WITH CHECK ADD  CONSTRAINT [FK_Lead_LeadSource_LeadSourceId] FOREIGN KEY([LeadSourceId])
REFERENCES [dbo].[LeadSource] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lead] CHECK CONSTRAINT [FK_Lead_LeadSource_LeadSourceId]
GO
ALTER TABLE [dbo].[LeadAutoAssign]  WITH CHECK ADD  CONSTRAINT [FK_LeadAutoAssign_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadAutoAssign] CHECK CONSTRAINT [FK_LeadAutoAssign_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[LeadAutoAssignLog]  WITH CHECK ADD  CONSTRAINT [FK_LeadAutoAssignLog_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[LeadAutoAssignLog] CHECK CONSTRAINT [FK_LeadAutoAssignLog_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[LeadAutoAssignLog]  WITH CHECK ADD  CONSTRAINT [FK_LeadAutoAssignLog_Lead_LeadId] FOREIGN KEY([LeadId])
REFERENCES [dbo].[Lead] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadAutoAssignLog] CHECK CONSTRAINT [FK_LeadAutoAssignLog_Lead_LeadId]
GO
ALTER TABLE [dbo].[LeadAutoAssignLog]  WITH CHECK ADD  CONSTRAINT [FK_LeadAutoAssignLog_LeadSource_LeadSourceId] FOREIGN KEY([LeadSourceId])
REFERENCES [dbo].[LeadSource] ([Id])
GO
ALTER TABLE [dbo].[LeadAutoAssignLog] CHECK CONSTRAINT [FK_LeadAutoAssignLog_LeadSource_LeadSourceId]
GO
ALTER TABLE [dbo].[LeadAutoAssignSourceMapping]  WITH CHECK ADD  CONSTRAINT [FK_LeadAutoAssignSourceMapping_LeadAutoAssign_LeadAutoAssignId] FOREIGN KEY([LeadAutoAssignId])
REFERENCES [dbo].[LeadAutoAssign] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadAutoAssignSourceMapping] CHECK CONSTRAINT [FK_LeadAutoAssignSourceMapping_LeadAutoAssign_LeadAutoAssignId]
GO
ALTER TABLE [dbo].[LeadAutoAssignSourceMapping]  WITH CHECK ADD  CONSTRAINT [FK_LeadAutoAssignSourceMapping_LeadSource_LeadSourceId] FOREIGN KEY([LeadSourceId])
REFERENCES [dbo].[LeadSource] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadAutoAssignSourceMapping] CHECK CONSTRAINT [FK_LeadAutoAssignSourceMapping_LeadSource_LeadSourceId]
GO
ALTER TABLE [dbo].[LeadOrder]  WITH CHECK ADD  CONSTRAINT [FK_LeadOrder_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[LeadOrder] CHECK CONSTRAINT [FK_LeadOrder_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[LeadOrder]  WITH CHECK ADD  CONSTRAINT [FK_LeadOrder_PaymentLog_PaymentLogId] FOREIGN KEY([PaymentLogId])
REFERENCES [dbo].[PaymentLog] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadOrder] CHECK CONSTRAINT [FK_LeadOrder_PaymentLog_PaymentLogId]
GO
ALTER TABLE [dbo].[LeadOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_LeadOrderDetail_Lead_LeadId] FOREIGN KEY([LeadId])
REFERENCES [dbo].[Lead] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadOrderDetail] CHECK CONSTRAINT [FK_LeadOrderDetail_Lead_LeadId]
GO
ALTER TABLE [dbo].[LeadOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_LeadOrderDetail_LeadOrder_LeadOrderId] FOREIGN KEY([LeadOrderId])
REFERENCES [dbo].[LeadOrder] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadOrderDetail] CHECK CONSTRAINT [FK_LeadOrderDetail_LeadOrder_LeadOrderId]
GO
ALTER TABLE [dbo].[LeadProductMapping]  WITH CHECK ADD  CONSTRAINT [FK_LeadProductMapping_Lead_LeadId] FOREIGN KEY([LeadId])
REFERENCES [dbo].[Lead] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadProductMapping] CHECK CONSTRAINT [FK_LeadProductMapping_Lead_LeadId]
GO
ALTER TABLE [dbo].[LeadProductMapping]  WITH CHECK ADD  CONSTRAINT [FK_LeadProductMapping_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadProductMapping] CHECK CONSTRAINT [FK_LeadProductMapping_Product_ProductId]
GO
ALTER TABLE [dbo].[LeadProjectMapping]  WITH CHECK ADD  CONSTRAINT [FK_LeadProjectMapping_Lead_LeadId] FOREIGN KEY([LeadId])
REFERENCES [dbo].[Lead] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadProjectMapping] CHECK CONSTRAINT [FK_LeadProjectMapping_Lead_LeadId]
GO
ALTER TABLE [dbo].[LeadProjectMapping]  WITH CHECK ADD  CONSTRAINT [FK_LeadProjectMapping_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadProjectMapping] CHECK CONSTRAINT [FK_LeadProjectMapping_Project_ProjectId]
GO
ALTER TABLE [dbo].[LeadTagMapping]  WITH CHECK ADD  CONSTRAINT [FK_LeadTagMapping_Lead_LeadId] FOREIGN KEY([LeadId])
REFERENCES [dbo].[Lead] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadTagMapping] CHECK CONSTRAINT [FK_LeadTagMapping_Lead_LeadId]
GO
ALTER TABLE [dbo].[LeadTagMapping]  WITH CHECK ADD  CONSTRAINT [FK_LeadTagMapping_LeadTag_LeadTagId] FOREIGN KEY([LeadTagId])
REFERENCES [dbo].[LeadTag] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeadTagMapping] CHECK CONSTRAINT [FK_LeadTagMapping_LeadTag_LeadTagId]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_AspNetUsers_CreatedById] FOREIGN KEY([CreatedById])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_AspNetUsers_CreatedById]
GO
ALTER TABLE [dbo].[MessageDetail]  WITH CHECK ADD  CONSTRAINT [FK_MessageDetail_AspNetUsers_SentToUserId] FOREIGN KEY([SentToUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[MessageDetail] CHECK CONSTRAINT [FK_MessageDetail_AspNetUsers_SentToUserId]
GO
ALTER TABLE [dbo].[MessageDetail]  WITH CHECK ADD  CONSTRAINT [FK_MessageDetail_Message_MessageId] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MessageDetail] CHECK CONSTRAINT [FK_MessageDetail_Message_MessageId]
GO
ALTER TABLE [dbo].[PaymentLog]  WITH CHECK ADD  CONSTRAINT [FK_PaymentLog_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[PaymentLog] CHECK CONSTRAINT [FK_PaymentLog_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[PhoneCallLeadLog]  WITH CHECK ADD  CONSTRAINT [FK_PhoneCallLeadLog_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[PhoneCallLeadLog] CHECK CONSTRAINT [FK_PhoneCallLeadLog_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[PhoneCallLeadLog]  WITH CHECK ADD  CONSTRAINT [FK_PhoneCallLeadLog_Lead_LeadId] FOREIGN KEY([LeadId])
REFERENCES [dbo].[Lead] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhoneCallLeadLog] CHECK CONSTRAINT [FK_PhoneCallLeadLog_Lead_LeadId]
GO
ALTER TABLE [dbo].[PhoneCallProductLog]  WITH CHECK ADD  CONSTRAINT [FK_PhoneCallProductLog_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[PhoneCallProductLog] CHECK CONSTRAINT [FK_PhoneCallProductLog_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[PhoneCallProductLog]  WITH CHECK ADD  CONSTRAINT [FK_PhoneCallProductLog_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhoneCallProductLog] CHECK CONSTRAINT [FK_PhoneCallProductLog_Product_ProductId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Location_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Location_LocationId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Project_ProjectId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Society_SocietyId] FOREIGN KEY([SocietyId])
REFERENCES [dbo].[Society] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Society_SocietyId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_SubCategory_SubCategoryId] FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[SubCategory] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_SubCategory_SubCategoryId]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Location_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Location_LocationId]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Society_SocietyId] FOREIGN KEY([SocietyId])
REFERENCES [dbo].[Society] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Society_SocietyId]
GO
ALTER TABLE [dbo].[ProjectTagMapping]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTagMapping_InventoryTag_InventoryTagId] FOREIGN KEY([InventoryTagId])
REFERENCES [dbo].[InventoryTag] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectTagMapping] CHECK CONSTRAINT [FK_ProjectTagMapping_InventoryTag_InventoryTagId]
GO
ALTER TABLE [dbo].[ProjectTagMapping]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTagMapping_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectTagMapping] CHECK CONSTRAINT [FK_ProjectTagMapping_Project_ProjectId]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Category_CategoryId]
GO
ALTER TABLE [dbo].[Tcf]  WITH CHECK ADD  CONSTRAINT [FK_Tcf_Lead_LeadId] FOREIGN KEY([LeadId])
REFERENCES [dbo].[Lead] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tcf] CHECK CONSTRAINT [FK_Tcf_Lead_LeadId]
GO
ALTER TABLE [dbo].[UserLog]  WITH CHECK ADD  CONSTRAINT [FK_UserLog_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserLog] CHECK CONSTRAINT [FK_UserLog_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserLog]  WITH CHECK ADD  CONSTRAINT [FK_UserLog_Lead_LeadId] FOREIGN KEY([LeadId])
REFERENCES [dbo].[Lead] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLog] CHECK CONSTRAINT [FK_UserLog_Lead_LeadId]
GO
ALTER TABLE [dbo].[UserRating]  WITH CHECK ADD  CONSTRAINT [FK_UserRating_AspNetUsers_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserRating] CHECK CONSTRAINT [FK_UserRating_AspNetUsers_CreatedBy]
GO
ALTER TABLE [dbo].[UserRating]  WITH CHECK ADD  CONSTRAINT [FK_UserRating_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserRating] CHECK CONSTRAINT [FK_UserRating_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserRating]  WITH CHECK ADD  CONSTRAINT [FK_UserRating_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[UserRating] CHECK CONSTRAINT [FK_UserRating_Product_ProductId]
GO
ALTER TABLE [dbo].[UserRating]  WITH CHECK ADD  CONSTRAINT [FK_UserRating_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[UserRating] CHECK CONSTRAINT [FK_UserRating_Project_ProjectId]
GO
ALTER TABLE [dbo].[Wallet]  WITH CHECK ADD  CONSTRAINT [FK_Wallet_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Wallet] CHECK CONSTRAINT [FK_Wallet_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[WalletDetail]  WITH CHECK ADD  CONSTRAINT [FK_WalletDetail_PaymentLog_PaymentLogId] FOREIGN KEY([PaymentLogId])
REFERENCES [dbo].[PaymentLog] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WalletDetail] CHECK CONSTRAINT [FK_WalletDetail_PaymentLog_PaymentLogId]
GO
ALTER TABLE [dbo].[WalletDetail]  WITH CHECK ADD  CONSTRAINT [FK_WalletDetail_Wallet_WalletId] FOREIGN KEY([WalletId])
REFERENCES [dbo].[Wallet] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WalletDetail] CHECK CONSTRAINT [FK_WalletDetail_Wallet_WalletId]
GO
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_Wishlist_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK_Wishlist_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_Wishlist_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK_Wishlist_Product_ProductId]
GO
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_Wishlist_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK_Wishlist_Project_ProjectId]
GO
USE [master]
GO
ALTER DATABASE [SimaxRealEstate] SET  READ_WRITE 
GO
