USE [master]
ƒ
/****** Object:  Database [dbAsanHesab]    Script Date: 4/8/2018 6:30:51 PM ******/
CREATE DATABASE [dbAsanHesab]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbAsanHesab', FILENAME = N':)Database_Name(:' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB)
 LOG ON 
( NAME = N'dbAsanHesab_log', FILENAME = N':)Database_Log(:' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB)
ƒ
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbAsanHesab].[dbo].[sp_fulltext_database] @action = 'enable'
end
ƒ
ALTER DATABASE [dbAsanHesab] SET ANSI_NULL_DEFAULT OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET ANSI_NULLS OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET ANSI_PADDING OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET ANSI_WARNINGS OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET ARITHABORT OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET AUTO_CLOSE ON 
ƒ
ALTER DATABASE [dbAsanHesab] SET AUTO_SHRINK ON 
ƒ
ALTER DATABASE [dbAsanHesab] SET AUTO_UPDATE_STATISTICS ON 
ƒ
ALTER DATABASE [dbAsanHesab] SET CURSOR_CLOSE_ON_COMMIT OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET CURSOR_DEFAULT  GLOBAL 
ƒ
ALTER DATABASE [dbAsanHesab] SET CONCAT_NULL_YIELDS_NULL OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET NUMERIC_ROUNDABORT OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET QUOTED_IDENTIFIER OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET RECURSIVE_TRIGGERS OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET  DISABLE_BROKER 
ƒ
ALTER DATABASE [dbAsanHesab] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET DATE_CORRELATION_OPTIMIZATION OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET TRUSTWORTHY OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET ALLOW_SNAPSHOT_ISOLATION OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET PARAMETERIZATION SIMPLE 
ƒ
ALTER DATABASE [dbAsanHesab] SET READ_COMMITTED_SNAPSHOT OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET HONOR_BROKER_PRIORITY OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET RECOVERY SIMPLE 
ƒ
ALTER DATABASE [dbAsanHesab] SET  MULTI_USER 
ƒ
ALTER DATABASE [dbAsanHesab] SET PAGE_VERIFY CHECKSUM  
ƒ
ALTER DATABASE [dbAsanHesab] SET DB_CHAINING OFF 
ƒ
ALTER DATABASE [dbAsanHesab] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
ƒ
ALTER DATABASE [dbAsanHesab] SET TARGET_RECOVERY_TIME = 60 SECONDS 
ƒ
ALTER DATABASE [dbAsanHesab] SET DELAYED_DURABILITY = DISABLED 
ƒ
USE [dbAsanHesab]
ƒ
/****** Object:  Table [dbo].[tblBankAccount]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblBankAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [nvarchar](50) NULL,
	[BranchName] [nvarchar](50) NULL,
	[AccountNum] [nvarchar](20) NULL,
	[CardNum] [nvarchar](20) NULL,
	[InitialBalance] [bigint] NULL,
	[BankDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblBankAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblFee]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblFee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentType_Id] [tinyint] NULL,
	[FeeCategory_Id] [int] NULL,
	[BankAccont_Id] [int] NULL,
	[FeeDate] [nvarchar](10) NULL,
	[FeeTime] [nvarchar](8) NULL,
	[Amount] [bigint] NULL,
	[ReceiptNumber] [nvarchar](20) NULL,
	[FeeDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblFee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblFeeCategory]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblFeeCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryGroup_Id] [int] NULL,
	[Category] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblFeeCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblFeeCategoryGroup]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblFeeCategoryGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryGroup] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblFeeCategoryGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblIncome]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblIncome](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentType_Id] [tinyint] NULL,
	[IncomeCategory_Id] [int] NULL,
	[BankAccont_Id] [int] NULL,
	[IncomeDate] [nvarchar](10) NULL,
	[IncomeTime] [nvarchar](8) NULL,
	[Amount] [bigint] NULL,
	[ReceiptNumber] [nvarchar](20) NULL,
	[IncomeDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblIncome] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblIncomeCategory]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblIncomeCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryGroup_Id] [int] NULL,
	[Category] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblIncomeCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblIncomeCategoryGroup]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblIncomeCategoryGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryGroup] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblIncomeCategoryGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblLicense]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblLicense](
	[Id] [int] NOT NULL,
	[AppLicense] [nvarchar](40) NULL,
	[AppVersion] [nvarchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblPaymentType]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblPaymentType](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[PaymentType] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblPaymentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblPostType]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblPostType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostType] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblSecurityAccess]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblSecurityAccess](
	[Id] [int] NOT NULL,
	[Time] [nvarchar](19) NULL,
	[Counter] [nvarchar](1) NULL,
 CONSTRAINT [PK_tblSecurityAccess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblSecurityQuestion]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblSecurityQuestion](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[SecurityQuestion] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblSecurityQuestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblSundry]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblSundry](
	[Id] [int] NOT NULL,
	[RegisteredAdminPassword] [bit] NULL,
 CONSTRAINT [PK_tblSundry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblUser]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_PostType_Id] [tinyint] NULL,
	[User_SecurityQuestion_Id] [tinyint] NULL,
	[UserFirstName] [nvarchar](50) NULL,
	[UserLastName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](60) NULL,
	[UserMobileNumber] [nvarchar](11) NULL,
	[UserEmail] [nvarchar](200) NULL,
	[UserAnswer] [nvarchar](100) NULL,
	[UserRegistrationDate] [nvarchar](19) NULL,
	[UserImage] [nvarchar](max) NULL,
	[UserDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

ƒ
/****** Object:  View [dbo].[viewFeeInfo]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE VIEW [dbo].[viewFeeInfo]
	AS SELECT        tblFee.Id, tblFee.FeeCategory_Id, tblFee.BankAccont_Id, tblFee.FeeDate, tblFee.FeeTime, tblFee.Amount, tblFee.ReceiptNumber, tblFee.FeeDescription, tblPaymentType.Id AS PaymentId, tblBankAccount.BankName, 
                         CONCAT(tblFeeCategoryGroup.CategoryGroup,  ' : ', tblFeeCategory.Category) AS Category
FROM            tblFee INNER JOIN
                         tblFeeCategory ON tblFee.FeeCategory_Id = tblFeeCategory.Id INNER JOIN
                         tblPaymentType ON tblFee.PaymentType_Id = tblPaymentType.Id INNER JOIN
                         tblBankAccount ON tblFee.BankAccont_Id = tblBankAccount.Id INNER JOIN
                         tblFeeCategoryGroup ON tblFeeCategory.CategoryGroup_Id = tblFeeCategoryGroup.Id
ƒ
/****** Object:  View [dbo].[viewIncomeInfo]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE VIEW [dbo].[viewIncomeInfo]
	AS SELECT        tblIncome.Id, tblIncome.IncomeCategory_Id, tblIncome.BankAccont_Id, tblIncome.IncomeDate, tblIncome.IncomeTime, tblIncome.Amount, tblIncome.ReceiptNumber, tblIncome.IncomeDescription, tblPaymentType.Id AS PaymentId, tblBankAccount.BankName, 
                         CONCAT(tblIncomeCategoryGroup.CategoryGroup, ' : ', tblIncomeCategory.Category) AS Category
FROM            tblIncome INNER JOIN
                         tblIncomeCategory ON tblIncome.IncomeCategory_Id = tblIncomeCategory.Id INNER JOIN
                         tblPaymentType ON tblIncome.PaymentType_Id = tblPaymentType.Id INNER JOIN
                         tblBankAccount ON tblIncome.BankAccont_Id = tblBankAccount.Id INNER JOIN
                         tblIncomeCategoryGroup ON tblIncomeCategory.CategoryGroup_Id = tblIncomeCategoryGroup.Id
ƒ
SET IDENTITY_INSERT [dbo].[tblBankAccount] ON 

ƒ
INSERT [dbo].[tblBankAccount] ([Id], [BankName], [BranchName], [AccountNum], [CardNum], [InitialBalance], [BankDescription]) VALUES (1, N'حساب شخصی', NULL, NULL, NULL, 0, NULL)
ƒ
SET IDENTITY_INSERT [dbo].[tblBankAccount] OFF
ƒ
SET IDENTITY_INSERT [dbo].[tblFeeCategory] ON 

ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (1, 1, N'نامشخص')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (2, 2, N'بنزین')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (3, 2, N'بیمه')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (4, 2, N'جریمه')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (5, 2, N'تعمیرگاه')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (6, 2, N'عوارض')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (7, 3, N'خانه')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (8, 3, N'شرکت')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (9, 3, N'مغازه')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (10, 4, N'لباس')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (11, 4, N'لوازم بهداشتی')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (12, 4, N'لوازم آرایشی')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (13, 4, N'لوازم خانگی')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (14, 4, N'کارت شارژ')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (15, 4, N'نشریات')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (16, 4, N'هدیه')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (17, 4, N'دارو')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (18, 4, N'سیگار')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (19, 5, N'فیلم')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (20, 5, N'موسیقی')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (21, 6, N'کرایه تاکسی')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (22, 6, N'اتوبوس')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (23, 6, N'مترو')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (24, 7, N'سینما')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (25, 7, N'تئاتر')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (26, 7, N'کنسرت')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (27, 8, N'دانشگاه')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (28, 8, N'آموزشگاه')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (29, 8, N'باشگاه')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (30, 9, N'رستوران')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (31, 9, N'کافی‌شاپ')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (32, 9, N'خواربار')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (33, 10, N'موبایل')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (34, 10, N'تلفن')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (35, 10, N'برق')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (36, 10, N'آب')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (37, 10, N'گاز')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (38, 11, N'وام')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (39, 11, N'اتومبیل')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (40, 12, N'ویزیت دکتر')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (41, 13, N'بلیت هواپیما')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (42, 13, N'بلیت قطار')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (43, 13, N'هتل')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (44, 13, N'تور')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (45, 14, N'کتاب')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (46, 14, N'مجله')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (47, 14, N'روزنامه')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (48, 14, N'لوح فشرده')
ƒ
INSERT [dbo].[tblFeeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (49, 15, N'مالیات')
ƒ
SET IDENTITY_INSERT [dbo].[tblFeeCategory] OFF
ƒ
SET IDENTITY_INSERT [dbo].[tblFeeCategoryGroup] ON 

ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (1, N'نامشخص')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (2, N'اتومبیل')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (3, N'اجاره')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (4, N'خرید')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (5, N'رسانه')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (6, N'رفت و آمد')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (7, N'سرگرمی')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (8, N'شهریه')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (9, N'غذا')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (10, N'قبض')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (11, N'قسط')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (12, N'مراقبت فردی')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (13, N'مسافرت')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (14, N'نشریات')
ƒ
INSERT [dbo].[tblFeeCategoryGroup] ([Id], [CategoryGroup]) VALUES (15, N'سایر')
ƒ
SET IDENTITY_INSERT [dbo].[tblFeeCategoryGroup] OFF
ƒ
SET IDENTITY_INSERT [dbo].[tblIncomeCategory] ON 

ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (1, 1, N'نامشخص')
ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (2, 2, N'خانه')
ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (3, 2, N'شرکت')
ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (4, 2, N'مغازه')
ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (5, 3, N'محصول 1')
ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (6, 3, N'محصول 2')
ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (7, 3, N'محصول 3')
ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (8, 4, N'انجام پروژه')
ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (9, 4, N'حقوق')
ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (10, 4, N'دستمزد')
ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (11, 4, N'سود پس‌انداز')
ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (12, 4, N'پاداش')
ƒ
INSERT [dbo].[tblIncomeCategory] ([Id], [CategoryGroup_Id], [Category]) VALUES (13, 4, N'یارانه')
ƒ
SET IDENTITY_INSERT [dbo].[tblIncomeCategory] OFF
ƒ
SET IDENTITY_INSERT [dbo].[tblIncomeCategoryGroup] ON 

ƒ
INSERT [dbo].[tblIncomeCategoryGroup] ([Id], [CategoryGroup]) VALUES (1, N'نامشخص')
ƒ
INSERT [dbo].[tblIncomeCategoryGroup] ([Id], [CategoryGroup]) VALUES (2, N'اجاره')
ƒ
INSERT [dbo].[tblIncomeCategoryGroup] ([Id], [CategoryGroup]) VALUES (3, N'فروش محصول')
ƒ
INSERT [dbo].[tblIncomeCategoryGroup] ([Id], [CategoryGroup]) VALUES (4, N'سایر')
ƒ
SET IDENTITY_INSERT [dbo].[tblIncomeCategoryGroup] OFF
ƒ
INSERT [dbo].[tblLicense] ([Id], [AppLicense], [AppVersion]) VALUES (1, NULL, NULL)
ƒ
SET IDENTITY_INSERT [dbo].[tblPaymentType] ON 

ƒ
INSERT [dbo].[tblPaymentType] ([Id], [PaymentType]) VALUES (1, N'نقدی')
ƒ
INSERT [dbo].[tblPaymentType] ([Id], [PaymentType]) VALUES (2, N'چک')
ƒ
INSERT [dbo].[tblPaymentType] ([Id], [PaymentType]) VALUES (3, N'فیش بانکی')
ƒ
INSERT [dbo].[tblPaymentType] ([Id], [PaymentType]) VALUES (4, N'کارت خوان')
ƒ
SET IDENTITY_INSERT [dbo].[tblPaymentType] OFF
ƒ
SET IDENTITY_INSERT [dbo].[tblPostType] ON 

ƒ
INSERT [dbo].[tblPostType] ([Id], [PostType]) VALUES (1, N'مدیریت')
ƒ
SET IDENTITY_INSERT [dbo].[tblPostType] OFF
ƒ
SET IDENTITY_INSERT [dbo].[tblSecurityQuestion] ON 

ƒ
INSERT [dbo].[tblSecurityQuestion] ([Id], [SecurityQuestion]) VALUES (1, N'نام اولین معلم شما چیست؟')
ƒ
INSERT [dbo].[tblSecurityQuestion] ([Id], [SecurityQuestion]) VALUES (2, N'نام گل مورد علاقه شما چیست؟')
ƒ
INSERT [dbo].[tblSecurityQuestion] ([Id], [SecurityQuestion]) VALUES (3, N'رنگ مورد علاقه شما چیست؟')
ƒ
INSERT [dbo].[tblSecurityQuestion] ([Id], [SecurityQuestion]) VALUES (4, N'نام فیلم مورد علاقه شما چیست؟')
ƒ
INSERT [dbo].[tblSecurityQuestion] ([Id], [SecurityQuestion]) VALUES (5, N'مکان مورد علاقه شما کجاست؟')
ƒ
SET IDENTITY_INSERT [dbo].[tblSecurityQuestion] OFF
ƒ
/****** Object:  StoredProcedure [dbo].[spSelectFeeInfo]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
  CREATE PROCEDURE [dbo].[spSelectFeeInfo]
  AS
    BEGIN
        SELECT  *
        FROM    dbo.viewFeeInfo
        ORDER BY FeeDate ,
                FeeTime;
    END;

ƒ
/****** Object:  StoredProcedure [dbo].[spSelectIncomeInfo]    Script Date: 4/11/2018 7:44:25 PM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
  CREATE PROCEDURE [dbo].[spSelectIncomeInfo]
  AS
    BEGIN
        SELECT  *
        FROM    dbo.viewIncomeInfo
        ORDER BY IncomeDate ,
                IncomeTime;
    END;

ƒ
USE [master]
ƒ
ALTER DATABASE [dbAsanHesab] SET  READ_WRITE 
ƒ
