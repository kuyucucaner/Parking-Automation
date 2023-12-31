USE [PersonelVeriTabani]
GO
/****** Object:  Table [dbo].[Tbl_Admin]    Script Date: 13.08.2023 19:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAd] [nvarchar](50) NOT NULL,
	[Sifre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Kullanici]    Script Date: 13.08.2023 19:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Kullanici](
	[No] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[Marka] [nvarchar](50) NOT NULL,
	[Plaka] [nvarchar](50) NOT NULL,
	[Telefon] [nvarchar](50) NOT NULL,
	[Tarih] [date] NOT NULL,
 CONSTRAINT [PK_Tbl_Kullanici] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Admin] ON 

INSERT [dbo].[Tbl_Admin] ([ID], [KullaniciAd], [Sifre]) VALUES (1, N'caner', N'1234')
SET IDENTITY_INSERT [dbo].[Tbl_Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Kullanici] ON 

INSERT [dbo].[Tbl_Kullanici] ([No], [Ad], [Soyad], [Marka], [Plaka], [Telefon], [Tarih]) VALUES (1, N'caner', N'kuyucu', N'Chevrolet', N'35 gd 1234', N'(444) 444-4444', CAST(N'2023-10-08' AS Date))
INSERT [dbo].[Tbl_Kullanici] ([No], [Ad], [Soyad], [Marka], [Plaka], [Telefon], [Tarih]) VALUES (2, N'casdc', N'sdcas', N'dcasdc', N'sdcasdc', N'(312) 311-2312', CAST(N'2023-10-08' AS Date))
SET IDENTITY_INSERT [dbo].[Tbl_Kullanici] OFF
GO
