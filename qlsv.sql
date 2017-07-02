DROP DATABASE QLSV;
CREATE DATABASE QLSV;
USE QLSV;
CREATE TABLE GIANGVIEN
(
	MaGV nvarchar(10) primary key NOT NULL,
	TenGV nvarchar(10) NULL,
	NgaySinh date NULL,
)
CREATE TABLE HOCKY
(
	MaHK nvarchar(10) primary key NOT NULL,
	TenHK nvarchar(50) NULL,
)
CREATE TABLE DIEM
(
	MaSV nvarchar(10)  primary key NOT NULL,
	MaMH nvarchar(10) NOT NULL,
	DiemCC int NULL,
	DiemKT float NULL,
	DiemGK float NULL,
	DiemThi float NULL,
	DiemTB float NULL,
	MaGV nvarchar(10) NOT NULL,
	MaHK nvarchar(10) NOT NULL,
	FOREIGN KEY (MaGV) REFERENCES GIANGVIEN(MaGV),
	FOREIGN KEY (MaHK) REFERENCES HOCKY(MaHK)
 )
CREATE TABLE KHOA
(
	MaKhoa nvarchar(10) primary key NOT NULL,
	TenKhoa nvarchar(50) NULL,
)
CREATE TABLE LOP
(
	MaLop nvarchar(10) primary key NOT NULL,
	TenLop nvarchar(50) NULL,
	MaKhoa nvarchar(10) NOT NULL,
	MaGV nvarchar(10) NOT NULL,
	FOREIGN KEY (MaGV) REFERENCES GIANGVIEN(MaGV)
 )
CREATE TABLE MONHOC
(
	MaMH nvarchar(10) primary key NOT NULL,
	TenMH nvarchar(50) NULL,
	MaGV nvarchar(10) NOT NULL,
	FOREIGN KEY (MaGV) REFERENCES GIANGVIEN(MaGV)
 )


CREATE TABLE SINHVIEN
(
	MaSV nvarchar(10) primary key  NOT NULL,
	TenSV nvarchar(50) NULL,
	NgaySinh date NULL,
	MaLop nvarchar(10) NOT NULL,
	MaKhoa nvarchar(10) NOT NULL,
	FOREIGN KEY (MaLop) REFERENCES LOP(MaLop),
	FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)
)
create proc sinhvientheokhoa
@makhoa nvarchar(10)
as
begin
select ROW_NUMBER() over (order by MaSV) as STT, MaSV as [Mã Sinh Viên], TenSV as [Tên sinh viên],NgaySinh as [Ngày sinh], MaLop as [Mã lớp],MaKhoa as [Mã khoa] from SINHVIEN where MaKhoa = '@makhoa'
end

