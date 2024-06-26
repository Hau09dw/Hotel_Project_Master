USE [master]
GO
/****** Object:  Database [QuanLyKhachSan]    Script Date: 4/3/2024 11:06:34 AM ******/
CREATE DATABASE [QuanLyKhachSan]
ALTER DATABASE [QuanLyKhachSan] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyKhachSan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyKhachSan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyKhachSan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyKhachSan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyKhachSan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyKhachSan] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyKhachSan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyKhachSan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyKhachSan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyKhachSan] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyKhachSan', N'ON'
GO
ALTER DATABASE [QuanLyKhachSan] SET QUERY_STORE = OFF
GO
USE [QuanLyKhachSan]
GO
/****** Object:  Table [dbo].[ChiTietHoaDonDichVu]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonDichVu](
	[MaDichVu] [varchar](10) NOT NULL,
	[MaHoaDon] [varchar](10) NOT NULL,
	[SoLuong] [int] NULL,
	[Gia] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC,
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietLoaiPhong]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietLoaiPhong](
	[MaPhieuDK] [varchar](10) NOT NULL,
	[MaLoaiPhong] [varchar](10) NOT NULL,
	[SoLuong] [int] NULL,
	[Gia] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuDK] ASC,
	[MaLoaiPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [varchar](10) NOT NULL,
	[TenChucVu] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[MaNV] [varchar](10) NOT NULL,
	[MatKhau] [nvarchar](200) NULL,
 CONSTRAINT [PK__DangNhap__55F68FC14262442D] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDichVu] [varchar](10) NOT NULL,
	[TenDichVu] [nvarchar](20) NULL,
	[GiaDichVu] [money] NULL,
	[DonViTinh] [int] NULL,
	[MaLoaiDichVu] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [varchar](10) NOT NULL,
	[TenHoaDon] [nvarchar](20) NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[TienPhong] [money] NULL,
	[ChiPhiPhatSinh] [money] NULL,
	[TongTienHoaDon] [money] NULL,
	[TienCoc] [money] NULL,
	[MaNV] [varchar](10) NULL,
	[MaPhieuDK] [varchar](10) NULL,
	[MaPhong] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [varchar](10) NOT NULL,
	[TenKH] [nvarchar](30) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[CMND] [varchar](10) NULL,
	[DiaChi] [nvarchar](40) NULL,
	[SDT] [varchar](12) NULL,
	[QuocTich] [nvarchar](15) NULL,
 CONSTRAINT [PK__KhachHan__2725CF1EFDA0943D] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiDichVu]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiDichVu](
	[MaLoaiDichVu] [varchar](10) NOT NULL,
	[TenLoaiDichVu] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[MaLoaiPhong] [varchar](10) NOT NULL,
	[TenLoaiPhong] [nvarchar](20) NULL,
	[TrangThietBi] [nvarchar](100) NULL,
	[GiaLoaiPhong] [money] NULL,
	[MoTa] [nvarchar](100) NULL,
 CONSTRAINT [PK__LoaiPhon__23021217B12F1B48] PRIMARY KEY CLUSTERED 
(
	[MaLoaiPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [varchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](30) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[SDT] [varchar](12) NULL,
	[MaChucVu] [varchar](10) NULL,
 CONSTRAINT [PK__NhanVien__2725D70A0A51A81D] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuDangKy]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuDangKy](
	[MaPhieuDK] [varchar](10) NOT NULL,
	[NgayDen] [date] NULL,
	[NgayDi] [date] NULL,
	[GioDen] [time](7) NULL,
	[GioDi] [time](7) NULL,
	[SoLuongNguoiLon] [int] NULL,
	[SoLuongTreEm] [int] NULL,
	[TienDatCoc] [money] NULL,
	[MaNV] [varchar](10) NULL,
	[MaKH] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuDK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[MaPhong] [varchar](10) NOT NULL,
	[TenPhong] [nvarchar](20) NULL,
	[TinhTrangPhong] [bit] NULL,
	[MaLoaiPhong] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietLoaiPhong] ([MaPhieuDK], [MaLoaiPhong], [SoLuong], [Gia]) VALUES (N'PDK01', N'LP01', 1, 1100000.0000)
INSERT [dbo].[ChiTietLoaiPhong] ([MaPhieuDK], [MaLoaiPhong], [SoLuong], [Gia]) VALUES (N'PDK02', N'LP01', 1, 500000.0000)
INSERT [dbo].[ChiTietLoaiPhong] ([MaPhieuDK], [MaLoaiPhong], [SoLuong], [Gia]) VALUES (N'PDK03', N'LP02', 2, 1000000.0000)
INSERT [dbo].[ChiTietLoaiPhong] ([MaPhieuDK], [MaLoaiPhong], [SoLuong], [Gia]) VALUES (N'PDK04', N'LP03', 1, 800000.0000)
INSERT [dbo].[ChiTietLoaiPhong] ([MaPhieuDK], [MaLoaiPhong], [SoLuong], [Gia]) VALUES (N'PDK05', N'LP04', 2, 12000000.0000)
INSERT [dbo].[ChiTietLoaiPhong] ([MaPhieuDK], [MaLoaiPhong], [SoLuong], [Gia]) VALUES (N'PDK06', N'LP02', 1, 900000.0000)
INSERT [dbo].[ChiTietLoaiPhong] ([MaPhieuDK], [MaLoaiPhong], [SoLuong], [Gia]) VALUES (N'PDK07', N'LP03', 1, 1100000.0000)
INSERT [dbo].[ChiTietLoaiPhong] ([MaPhieuDK], [MaLoaiPhong], [SoLuong], [Gia]) VALUES (N'PDK08', N'LP04', 3, 2500000.0000)
GO
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV01', N'Lễ Tân')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV02', N'Kế toán')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV03', N'Nhân viên phục vụ')
GO
INSERT [dbo].[DangNhap] ([MaNV], [MatKhau]) VALUES (N'NV01', N'1')
INSERT [dbo].[DangNhap] ([MaNV], [MatKhau]) VALUES (N'NV02', N'2')
INSERT [dbo].[DangNhap] ([MaNV], [MatKhau]) VALUES (N'NV03', N'3')
INSERT [dbo].[DangNhap] ([MaNV], [MatKhau]) VALUES (N'NV04', N'4')
INSERT [dbo].[DangNhap] ([MaNV], [MatKhau]) VALUES (N'NV05', N'5')
INSERT [dbo].[DangNhap] ([MaNV], [MatKhau]) VALUES (N'NV06', N'6')
INSERT [dbo].[DangNhap] ([MaNV], [MatKhau]) VALUES (N'NV07', N'7')
INSERT [dbo].[DangNhap] ([MaNV], [MatKhau]) VALUES (N'NV08', N'8')
INSERT [dbo].[DangNhap] ([MaNV], [MatKhau]) VALUES (N'NV09', N'9')
GO
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [GiaDichVu], [DonViTinh], [MaLoaiDichVu]) VALUES (N'DV01', N'Spa', 100000.0000, 1, N'LDV01')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [GiaDichVu], [DonViTinh], [MaLoaiDichVu]) VALUES (N'DV02', N'Giặt Ủi', 250000.0000, 1, N'LDV04')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [GiaDichVu], [DonViTinh], [MaLoaiDichVu]) VALUES (N'DV03', N'Tham Quan', 500000.0000, 1, N'LDV05')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [GiaDichVu], [DonViTinh], [MaLoaiDichVu]) VALUES (N'DV04', N'Phục Vụ Thức Ăn', 130000.0000, 1, N'LDV03')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [GiaDichVu], [DonViTinh], [MaLoaiDichVu]) VALUES (N'DV05', N'Sử Dụng Internet', 20000.0000, 1, N'LDV06')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [GiaDichVu], [DonViTinh], [MaLoaiDichVu]) VALUES (N'DV06', N'Đãi Tiệc', 1000000.0000, 1, N'LDV07')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [GiaDichVu], [DonViTinh], [MaLoaiDichVu]) VALUES (N'DV07', N'Dọn Phòng', 50000.0000, 1, N'LDV04')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [GiaDichVu], [DonViTinh], [MaLoaiDichVu]) VALUES (N'DV08', N'Tắm Hồ Bơi', 430000.0000, 1, N'LDV08')
GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [TenHoaDon], [NgayBatDau], [NgayKetThuc], [TienPhong], [ChiPhiPhatSinh], [TongTienHoaDon], [TienCoc], [MaNV], [MaPhieuDK], [MaPhong]) VALUES (N'HD01', N'Hóa Đơn Bán Lẻ', CAST(N'2017-11-01' AS Date), CAST(N'2017-11-03' AS Date), 600000.0000, NULL, 500000.0000, 100000.0000, N'NV09', N'PDK01', N'P01')
INSERT [dbo].[HoaDon] ([MaHoaDon], [TenHoaDon], [NgayBatDau], [NgayKetThuc], [TienPhong], [ChiPhiPhatSinh], [TongTienHoaDon], [TienCoc], [MaNV], [MaPhieuDK], [MaPhong]) VALUES (N'HD02', N'Hoá Đơn Bán Lẻ', CAST(N'2017-11-03' AS Date), CAST(N'2017-11-04' AS Date), 600000.0000, NULL, 450000.0000, 150000.0000, N'NV09', N'PDK02', N'P03')
INSERT [dbo].[HoaDon] ([MaHoaDon], [TenHoaDon], [NgayBatDau], [NgayKetThuc], [TienPhong], [ChiPhiPhatSinh], [TongTienHoaDon], [TienCoc], [MaNV], [MaPhieuDK], [MaPhong]) VALUES (N'HD03', N'Hóa Đơn Bán Lẻ', CAST(N'2017-11-05' AS Date), CAST(N'2017-11-06' AS Date), 9000000.0000, NULL, 600000.0000, 300000.0000, N'NV02', N'PDK03', N'P05')
INSERT [dbo].[HoaDon] ([MaHoaDon], [TenHoaDon], [NgayBatDau], [NgayKetThuc], [TienPhong], [ChiPhiPhatSinh], [TongTienHoaDon], [TienCoc], [MaNV], [MaPhieuDK], [MaPhong]) VALUES (N'HD04', N'Hóa Đơn Bán Lẻ', CAST(N'2017-11-07' AS Date), CAST(N'2017-11-08' AS Date), 900000.0000, NULL, 800000.0000, 100000.0000, N'NV02', N'PDK04', N'P06')
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [SDT], [QuocTich]) VALUES (N'KH01', N'ABCD', CAST(N'1996-08-10' AS Date), N'Nam', N'1234', N'669', N'123', N'Vietnam')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [SDT], [QuocTich]) VALUES (N'KH02', N'Nam Diiiia', CAST(N'1996-08-07' AS Date), N'Nam', N'025385712', N'69 Dĩ An', N'01998270136', N'Vietnam')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [SDT], [QuocTich]) VALUES (N'KH03', N'Min Di', CAST(N'1996-05-07' AS Date), N'Nam', N'023123853', N'123 Bình Dương', N'01239482382', N'Vietnam')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [SDT], [QuocTich]) VALUES (N'KH04', N'John Cena', CAST(N'1993-08-12' AS Date), N'Nam', N'012398482', N'123 New York', N'0983287123', N'US')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [SDT], [QuocTich]) VALUES (N'KH05', N'Leonard', CAST(N'1992-12-12' AS Date), N'Nam', N'083823812', N'34/12 California', N'01293293282', N'US')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [SDT], [QuocTich]) VALUES (N'KH06', N'Ruby', CAST(N'1998-05-20' AS Date), N'Nữ', N'021932318', N'31/23/12 Little', N'0987723172', N'Canada')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [SDT], [QuocTich]) VALUES (N'KH07', N'Nguyễn Thị Nở', CAST(N'2017-06-13' AS Date), N'Nữ', N'025386543', N'69 Chương Dươnggg', N'0912456789', N'Saint Martin')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [GioiTinh], [CMND], [DiaChi], [SDT], [QuocTich]) VALUES (N'KH08', N'Lựu Đạn', CAST(N'2017-11-07' AS Date), N'Nam', N'09876543', N'567 Linh Chiểu', N'09876542', N'Afghanistan')
GO
INSERT [dbo].[LoaiDichVu] ([MaLoaiDichVu], [TenLoaiDichVu]) VALUES (N'LDV01', N'Làm Đẹp')
INSERT [dbo].[LoaiDichVu] ([MaLoaiDichVu], [TenLoaiDichVu]) VALUES (N'LDV02', N'Đưa Đón')
INSERT [dbo].[LoaiDichVu] ([MaLoaiDichVu], [TenLoaiDichVu]) VALUES (N'LDV03', N'Chăm Sóc')
INSERT [dbo].[LoaiDichVu] ([MaLoaiDichVu], [TenLoaiDichVu]) VALUES (N'LDV04', N'Phòng')
INSERT [dbo].[LoaiDichVu] ([MaLoaiDichVu], [TenLoaiDichVu]) VALUES (N'LDV05', N'Cho Thuê Xe Tự Lái')
INSERT [dbo].[LoaiDichVu] ([MaLoaiDichVu], [TenLoaiDichVu]) VALUES (N'LDV06', N'Văn Phòng')
INSERT [dbo].[LoaiDichVu] ([MaLoaiDichVu], [TenLoaiDichVu]) VALUES (N'LDV07', N'Hội Họp')
INSERT [dbo].[LoaiDichVu] ([MaLoaiDichVu], [TenLoaiDichVu]) VALUES (N'LDV08', N'Giải Trí')
GO
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [TrangThietBi], [GiaLoaiPhong], [MoTa]) VALUES (N'LP01', N'Standard', N'Giường đơn, máy lạnh, tivi,bồn tắm đứng', 600000.0000, N'Diện tích nhỏ, tầng thấp, không có view')
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [TrangThietBi], [GiaLoaiPhong], [MoTa]) VALUES (N'LP02', N'Superior', N'Giường đôi, máy lạnh, tivi LCD, bồn tắm nằm, két sắt, máy sấy tóc', 900000.0000, N'Diện tích lớn, view đẹp')
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [TrangThietBi], [GiaLoaiPhong], [MoTa]) VALUES (N'LP03', N'Deluxe', N'Giường đôi, 2 máy lạnh, truyền hình vệ tinh,bàn ủi,bàn làm việc', 1500000.0000, N'Diện tích phòng thoải mái, tầng cao, view đẹp')
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [TrangThietBi], [GiaLoaiPhong], [MoTa]) VALUES (N'LP04', N'Suite', N'Giường đôi, máy lạnh, két sắt, bàn trang điểm, bồn tắm nằm', 2000000.0000, N'Diện tích phòng lớn, phòng ngủ riêng biệt, tầng thượng')
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNhanVien], [NgaySinh], [GioiTinh], [SDT], [MaChucVu]) VALUES (N'NV01', N'Nguyễn Min Di', CAST(N'1996-12-01' AS Date), N'Nam', N'0987123456', N'CV01')
INSERT [dbo].[NhanVien] ([MaNV], [TenNhanVien], [NgaySinh], [GioiTinh], [SDT], [MaChucVu]) VALUES (N'NV02', N'Vũ Hà Anh', CAST(N'1992-05-09' AS Date), N'Nam', N'0981234631', N'CV02')
INSERT [dbo].[NhanVien] ([MaNV], [TenNhanVien], [NgaySinh], [GioiTinh], [SDT], [MaChucVu]) VALUES (N'NV03', N'Phương Nam', CAST(N'1998-09-12' AS Date), N'Nam', N'0913256823', N'CV03')
INSERT [dbo].[NhanVien] ([MaNV], [TenNhanVien], [NgaySinh], [GioiTinh], [SDT], [MaChucVu]) VALUES (N'NV04', N'Nghĩa Hữu', CAST(N'1992-12-23' AS Date), N'Nam', N'0912332135', N'CV03')
INSERT [dbo].[NhanVien] ([MaNV], [TenNhanVien], [NgaySinh], [GioiTinh], [SDT], [MaChucVu]) VALUES (N'NV05', N'Hân Hoàng', CAST(N'1996-08-07' AS Date), N'Nữ', N'01998270136', N'CV03')
INSERT [dbo].[NhanVien] ([MaNV], [TenNhanVien], [NgaySinh], [GioiTinh], [SDT], [MaChucVu]) VALUES (N'NV06', N'Vinh Lý', CAST(N'1993-09-15' AS Date), N'Nam', N'0982358623', N'CV03')
INSERT [dbo].[NhanVien] ([MaNV], [TenNhanVien], [NgaySinh], [GioiTinh], [SDT], [MaChucVu]) VALUES (N'NV07', N'Nguyễn Khoa', CAST(N'1997-02-03' AS Date), N'Nam', N'0898543857', N'CV03')
INSERT [dbo].[NhanVien] ([MaNV], [TenNhanVien], [NgaySinh], [GioiTinh], [SDT], [MaChucVu]) VALUES (N'NV08', N'Ân Huỳnh', CAST(N'1996-09-14' AS Date), N'Nữ', N'0912382182', N'CV03')
INSERT [dbo].[NhanVien] ([MaNV], [TenNhanVien], [NgaySinh], [GioiTinh], [SDT], [MaChucVu]) VALUES (N'NV09', N'Thiên Ân', CAST(N'1996-09-15' AS Date), N'Nữ', N'0989007511', N'CV03')
GO
INSERT [dbo].[PhieuDangKy] ([MaPhieuDK], [NgayDen], [NgayDi], [GioDen], [GioDi], [SoLuongNguoiLon], [SoLuongTreEm], [TienDatCoc], [MaNV], [MaKH]) VALUES (N'PDK01', CAST(N'2017-11-01' AS Date), CAST(N'2017-11-03' AS Date), CAST(N'12:00:00' AS Time), CAST(N'11:00:00' AS Time), 2, NULL, 100000.0000, N'NV09', N'KH01')
INSERT [dbo].[PhieuDangKy] ([MaPhieuDK], [NgayDen], [NgayDi], [GioDen], [GioDi], [SoLuongNguoiLon], [SoLuongTreEm], [TienDatCoc], [MaNV], [MaKH]) VALUES (N'PDK02', CAST(N'2017-11-03' AS Date), CAST(N'2017-11-04' AS Date), CAST(N'12:00:00' AS Time), CAST(N'10:00:00' AS Time), 2, 1, 150000.0000, N'NV09', N'KH02')
INSERT [dbo].[PhieuDangKy] ([MaPhieuDK], [NgayDen], [NgayDi], [GioDen], [GioDi], [SoLuongNguoiLon], [SoLuongTreEm], [TienDatCoc], [MaNV], [MaKH]) VALUES (N'PDK03', CAST(N'2017-11-05' AS Date), CAST(N'2017-11-06' AS Date), CAST(N'12:00:00' AS Time), CAST(N'12:00:00' AS Time), 4, NULL, 300000.0000, N'NV02', N'KH03')
INSERT [dbo].[PhieuDangKy] ([MaPhieuDK], [NgayDen], [NgayDi], [GioDen], [GioDi], [SoLuongNguoiLon], [SoLuongTreEm], [TienDatCoc], [MaNV], [MaKH]) VALUES (N'PDK04', CAST(N'2017-11-07' AS Date), CAST(N'2017-11-08' AS Date), CAST(N'12:00:00' AS Time), CAST(N'09:00:00' AS Time), 2, 1, 100000.0000, N'NV02', N'KH04')
INSERT [dbo].[PhieuDangKy] ([MaPhieuDK], [NgayDen], [NgayDi], [GioDen], [GioDi], [SoLuongNguoiLon], [SoLuongTreEm], [TienDatCoc], [MaNV], [MaKH]) VALUES (N'PDK05', CAST(N'2017-11-08' AS Date), CAST(N'2017-11-10' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), 3, 1, 200000.0000, N'NV09', N'KH05')
INSERT [dbo].[PhieuDangKy] ([MaPhieuDK], [NgayDen], [NgayDi], [GioDen], [GioDi], [SoLuongNguoiLon], [SoLuongTreEm], [TienDatCoc], [MaNV], [MaKH]) VALUES (N'PDK06', CAST(N'2017-11-11' AS Date), CAST(N'2017-11-15' AS Date), CAST(N'12:00:00' AS Time), CAST(N'11:00:00' AS Time), 4, 2, 300000.0000, N'NV02', N'KH06')
INSERT [dbo].[PhieuDangKy] ([MaPhieuDK], [NgayDen], [NgayDi], [GioDen], [GioDi], [SoLuongNguoiLon], [SoLuongTreEm], [TienDatCoc], [MaNV], [MaKH]) VALUES (N'PDK07', CAST(N'2017-11-16' AS Date), CAST(N'2017-11-18' AS Date), CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), 2, 1, 100000.0000, N'NV02', N'KH07')
INSERT [dbo].[PhieuDangKy] ([MaPhieuDK], [NgayDen], [NgayDi], [GioDen], [GioDi], [SoLuongNguoiLon], [SoLuongTreEm], [TienDatCoc], [MaNV], [MaKH]) VALUES (N'PDK08', CAST(N'2017-11-18' AS Date), CAST(N'2017-11-19' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), 1, NULL, 50000.0000, N'NV09', N'KH08')
GO
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P01', N'P_SD01', 1, N'LP01')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P02', N'P_SD02', 0, N'LP01')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P03', N'P_SD03', 1, N'LP01')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P04', N'P_SD04', 0, N'LP01')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P05', N'P_SP01', 1, N'LP02')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P06', N'P_SP02', 1, N'LP02')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P07', N'P_SP03', 0, N'LP02')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P08', N'P_SP04', 0, N'LP02')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P09', N'P_DL01', 1, N'LP03')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P10', N'P_DL02', 1, N'LP03')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P11', N'P_DL03', 0, N'LP03')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P12', N'P_DL04', 1, N'LP03')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P13', N'P_DL05', 0, N'LP03')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P14', N'P_SU01', 1, N'LP04')
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [TinhTrangPhong], [MaLoaiPhong]) VALUES (N'P15', N'P_SU02', 0, N'LP04')
GO
ALTER TABLE [dbo].[ChiTietHoaDonDichVu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDonDichVu_DichVu] FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DichVu] ([MaDichVu])
GO
ALTER TABLE [dbo].[ChiTietHoaDonDichVu] CHECK CONSTRAINT [FK_ChiTietHoaDonDichVu_DichVu]
GO
ALTER TABLE [dbo].[ChiTietHoaDonDichVu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDonDichVu_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDonDichVu] CHECK CONSTRAINT [FK_ChiTietHoaDonDichVu_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietLoaiPhong]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietLoaiPhong_LoaiPhong] FOREIGN KEY([MaLoaiPhong])
REFERENCES [dbo].[LoaiPhong] ([MaLoaiPhong])
GO
ALTER TABLE [dbo].[ChiTietLoaiPhong] CHECK CONSTRAINT [FK_ChiTietLoaiPhong_LoaiPhong]
GO
ALTER TABLE [dbo].[ChiTietLoaiPhong]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietLoaiPhong_PhieuDangKy] FOREIGN KEY([MaPhieuDK])
REFERENCES [dbo].[PhieuDangKy] ([MaPhieuDK])
GO
ALTER TABLE [dbo].[ChiTietLoaiPhong] CHECK CONSTRAINT [FK_ChiTietLoaiPhong_PhieuDangKy]
GO
ALTER TABLE [dbo].[DichVu]  WITH CHECK ADD  CONSTRAINT [FK_DichVu_LoaiDichVu] FOREIGN KEY([MaLoaiDichVu])
REFERENCES [dbo].[LoaiDichVu] ([MaLoaiDichVu])
GO
ALTER TABLE [dbo].[DichVu] CHECK CONSTRAINT [FK_DichVu_LoaiDichVu]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_PhieuDangKy] FOREIGN KEY([MaPhieuDK])
REFERENCES [dbo].[PhieuDangKy] ([MaPhieuDK])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_PhieuDangKy]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_Phong] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[Phong] ([MaPhong])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_Phong]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu] FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_ChucVu]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_DangNhap] FOREIGN KEY([MaNV])
REFERENCES [dbo].[DangNhap] ([MaNV])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_DangNhap]
GO
ALTER TABLE [dbo].[PhieuDangKy]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDangKy_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[PhieuDangKy] CHECK CONSTRAINT [FK_PhieuDangKy_KhachHang]
GO
ALTER TABLE [dbo].[PhieuDangKy]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDangKy_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuDangKy] CHECK CONSTRAINT [FK_PhieuDangKy_NhanVien]
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK_Phong_LoaiPhong] FOREIGN KEY([MaLoaiPhong])
REFERENCES [dbo].[LoaiPhong] ([MaLoaiPhong])
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK_Phong_LoaiPhong]
GO
/****** Object:  StoredProcedure [dbo].[spCheckDangNhap]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spCheckDangNhap]
(
	@TenDangNhap	varchar(100),
	@MatKhau		nvarchar(200)
)
as
Begin
	select * from DangNhap DN
	where DN.MaNV = @TenDangNhap
	and DN.MatKhau = @MatKhau
End
GO
/****** Object:  StoredProcedure [dbo].[spCheckTrangThai]    Script Date: 4/3/2024 11:06:34 AM ******/

/****** Object:  StoredProcedure [dbo].[spDeleteDangNhapByTenDangNhap]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeleteDangNhapByTenDangNhap]
(
	@TenDangNhap	varchar(100)
)
as
Begin
	delete from DangNhap
	where MaNV = @TenDangNhap
End
GO
/****** Object:  StoredProcedure [dbo].[spInsertDangNhap]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spInsertDangNhap]
(
	@TenDangNhap	varchar(100),
	@MatKhau	nvarchar(200)
)
as
Begin
	insert into DangNhap(MaNV,MatKhau) values(@TenDangNhap,@MatKhau)
End
GO
/****** Object:  StoredProcedure [dbo].[spUpdateDangNhap_MatKhau]    Script Date: 4/3/2024 11:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spUpdateDangNhap_MatKhau]
(
	@TenDangNhap	varchar(100),
	@MatKhau	nvarchar(200)
)
as
Begin
	update DangNhap set MatKhau = @MatKhau
	where MaNV = @TenDangNhap
End
GO
USE [master]
GO
ALTER DATABASE [QuanLyKhachSan] SET  READ_WRITE 
GO
