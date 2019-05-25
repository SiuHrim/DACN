create database DbBanDanGT
go
use DbBanDanGT
go
set dateformat dmy
go
create table QuyenHan(
	ID int identity(1,1) primary key,
	TenQH nvarchar(40) unique not null,
	Levels int check(Levels > 0 and Levels < 6) not null
)
go
create table NguoiDung(
	MaND int identity(1,1) primary key,
	ID int foreign key references QuyenHan(ID),
	Ho nvarchar(50) not null,
	Ten nvarchar (15) not null,
	DiaChi nvarchar(100) null,
	Email varchar(50) Unique check (Email like '[A-Za-z0-9]%@%.%') not null,
	SDT char(11) Unique check (LEN(SDT) BETWEEN 6 AND 11) not null,
	TenUser varchar(30) Unique check(LEN (TenUser) >= 4)not null,
	MatKhau varchar(30)check(LEN(MatKhau)>= 4) not null,
)
go
create table LoaiDan(
	MaLoai varchar(4) primary key check(MaLoai like '[A-Z]%'),  
	TenLoai nvarchar(50) not null
)
go
create table HieuDan(
MaHieu varchar(4) primary key check(MaHieu like '[A-Z]%'),  
TenHieu nvarchar(50) not null
)
--go


--create table HinhAnh(
	--MaIMG NVARCHAR(100) primary key,
	--Link nvarchar(100)  not null,
--) 
go
create table SanPham(
	MaSP int identity(1,1) primary key,
	TenSP nvarchar(100) Unique  not null,
	DonGia int check(DonGia > 0 ) not null,
	SoLuong int check(SoLuong > 0 )not null,
	MoTa nvarchar(max)  null,
	Lv int default 3 check(Lv > 0 and Lv <= 3) not null,
	MauSac nvarchar(20) not null,
	IMG nvarchar(100) unique not null,
	--IMG2 nvarchar(100) unique not null,
	MaLoai varchar(4) foreign key references LoaiDan(MaLoai),
	MaHieu varchar(4) foreign key references HieuDan(MaHieu),
	--MaIMG nvarchar(100) foreign key references HinhAnh(MaIMG),
) 

go
create table HoaDon(
	MaHD int identity(1,1) primary key,
	MaND int foreign key references NguoiDung(MaND),
	NgayLHD date default getdate() not null,
	NgayGiao date null,
	DiaChi nvarchar(max) not null,
	VAT varchar(100)  check(VAT >= 0) not null,
	TinhTrang char(1) default 'Y' check(TinhTrang = 'Y' or TinhTrang = 'N') not null,
	TongTien int check(TongTien > 0) not null,
)
go

create table CTHoaDon(
	MaSP int identity(1,1) foreign key references SanPham(MaSP),
	MaHD int foreign key references HoaDon(MaHD),
	SoLuong int check(SoLuong > 0) not null,
	ThanhTien int check(ThanhTien > 0) not null,
	GiamGia int check(GiamGia >= 0) not null,
	DonGia int check(DonGia > 0 ) not null,
	primary key(MaSP,MaHD)
)
go

create table NhaCungCap(
	MaNCC int identity(1,1) primary key,
	TenNCC nvarchar(100) unique not null,
	DiaChi nvarchar(100) not null,
	SDT char(11) unique check (LEN(SDT) BETWEEN 10 AND 11) not null
)
go

create table PhieuNhap(
	MaPN int identity(1,1) primary key,
	MaNCC int foreign key references NhaCungCap(MaNCC),
	MaND int foreign key references NguoiDung(MaND),
	NgayNhap date default getdate() not null,
	TongTien int  check(TongTien > 0) not null	
)
go 

create table CTPhieuNhap(
	MaPN int identity(1,1) foreign key references PhieuNhap(MaPN),
	MaSP int foreign key references SanPham(MaSP),
	SoLuong int check(SoLuong > 0)not null,
	GiaBan  int check(GiaBan > 0) not null
	primary key(MaPN, MaSP)
)
go

------------------Chèn dữ liệu vào bảng-----------------

set dateformat dmy

---------------Insert Table Loại Đàn------------------
insert into LoaiDan(MaLoai,TenLoai) values('GT',N'Guitar')
insert into LoaiDan(MaLoai,TenLoai) values('BS',N'Guitar Bass')
insert into LoaiDan(MaLoai,TenLoai) values('UK',N'Ukulee')
insert into LoaiDan(MaLoai,TenLoai) values('LD',N'Guitar Lead Elestric')
go

---------------Insert Table Hiệu Đàn------------------
insert into HieuDan(MaHieu,TenHieu) values('Ta','Taylor')
insert into HieuDan(MaHieu,TenHieu) values('Fe','FenDer')
insert into HieuDan(MaHieu,TenHieu) values('Ya','Yamaha')
insert into HieuDan(MaHieu,TenHieu) values('TD',N'Tự Do')
---------------Insert Table QuyenHan----------------
insert into QuyenHan(TenQH,Levels) values ('Admin',1)
---------------Insert Table Người Dùng----------------
insert into NguoiDung(ID,Ho,Ten,DiaChi,Email,SDT,TenUser,MatKhau) 
values(1,'Siu','Hrim',N'Chư Sê - Gia Lai','siuhrim56s@gmail.com',0385937251,'Hrim','1234')







---------------Insert Table Sản Phẩm----------------
insert into SanPham(MaSP,TenSP,MaLoai,MaHieu,MaImg,DonGia,MauSac,SoLuong,Lv)
values('1',N'Guitar Acoustic FENDER – FA-100','GT','Ta',1,15000,N'Đen bóng',10,3)
go

declare @i int =0;
while @i <=9
BEGIN
insert into SanPham(TenSP,MaLoai,MaHieu,MaImg,DonGia,MauSac,SoLuong,Lv)
values(N'GTBOSS-ST1 '+CAST(@i as nvarchar(8)),'GT','Fe',001,15000,N'Đỏ Nâu',10,2)
SET @i = @i +1
END
go


------------------Insert Table Hóa Đơn--------------------
insert into HoaDon(MaHD,MaND,NgayLHD,NgayGiao,TinhTrang,VAT,TongTien)
values('HD01','ND01','','','',10,3250)
go

------------Insert Table Chi Tiết ĐƠn Hàng------------------
insert into CTHoaDon(MaSP,MaHD,SoLuong,DonGia,GiamGia,ThanhTien)
values('SP01','HD01',10,1590,290,1300)
go

-------------Insert Table Nhà Cung Cấp---------------
insert into NhaCungCap(MaNCC,TenNCC,DiaChi,SDT)
values('NCC01',N'Hồ Chí Minh','TP-HCM',1234567891)

go
------------Insert Table Phiếu Nhập-------------------

insert into PhieuNhap(MaPN,MaNCC,MaND,TongTien,NgayNhap) values('PN01','NCC01','ND01',2000,'')
go

------------Insert Table Chi Tiết Phiếu Nhập-------------------

insert into CTPhieuNhap(MaPN,MaSP,SoLuong,GiaBan) values('PN01','SP01',11,2000)
go
