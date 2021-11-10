create database lttq_buoi9;
use lttq_buoi9;

create table product
(
	productid nvarchar(20) primary key clustered,
	productname nvarchar(100) not null,
	unit nvarchar(20) not null,
	buyprice decimal(18,0) null,
	sellprice decimal(18,0) null,
	deleted bit default 0
);
insert into product (productid,productname,unit,buyprice,sellprice,deleted) values 
(N'P01',N'Sản phẩm 1', N'Cái', 10000, 12000, 0),
(N'P02',N'Sản phẩm 2', N'Cái', 20000, 24000, 0),
(N'P03',N'Sản phẩm 3', N'Hộp', 12000, 15000, 0),
(N'P04',N'Sản phẩm 4', N'Hộp', 16000, 20000, 0),
(N'P05',N'Sản phẩm 5', N'Cái', 24000, 30000, 0);

select * from product;
create table [dbo].[order]
(
	invoiceno nvarchar(20),
	productid nvarchar(20),
	no int,
	productname nvarchar(100) not null,
	unit nvarchar(20) not null,
	price decimal(18,0) null,
	quantity int,
	foreign key (productid) references product(productid),
	foreign key (invoiceno) references invoice(invoiceno)
);
drop table 
delete from [dbo].[order]
select * from [dbo].[order]
create table invoice
(
	invoiceno nvarchar(20) primary key clustered,
	orderdate datetime,
	deliverydate datetime,
	note nvarchar(100)
);
select * from invoice
delete from invoice where invoiceno = N'HDX004'
create proc sp_ThongKeTheoNgayTrongThang
(
	@thang int,
	@nam int
)
as
	begin
		select x.ngay as 'Ngay' , sum(x.thanhtien) as 'DoanhThu'
		from (
			select day(i.deliverydate) as 'ngay', month(i.deliverydate) as 'thang', year(i.deliverydate) as 'nam', (o.price * o.quantity) as 'thanhtien'
			from invoice i, [dbo].[order] o
			where i.invoiceno = o.invoiceno and month(i.deliverydate) = @thang and year(i.deliverydate) = @nam
		) as x
		group by x.thang, x.nam, x.ngay
	end
	
	execute sp_ThongKeTheoNgayTrongThang 11, 2021

create proc sp_ThongKeTheoThangTrongNam
(
	@nam int
)
as
	begin
		select x.thang as 'Thang' , sum(x.thanhtien) as 'DoanhThu'
		from (
			select month(i.deliverydate) as 'thang', year(i.deliverydate) as 'nam', (o.price * o.quantity) as 'thanhtien'
			from invoice i, [dbo].[order] o
			where i.invoiceno = o.invoiceno and  year(i.deliverydate) = @nam
		) as x
		group by x.thang, x.nam
	end

create proc sp_ThongKeTheoNam
as
	begin
		select x.nam as 'Nam' , sum(x.thanhtien) as 'DoanhThu'
		from (
			select  year(i.deliverydate) as 'nam', (o.price * o.quantity) as 'thanhtien'
			from invoice i, [dbo].[order] o
			where i.invoiceno = o.invoiceno 
		) as x
		group by x.nam
	end
create proc sp_ThongKeTheoQuy
(@nam int)
as
	begin
		select x.quy as 'Quy' , sum(x.thanhtien) as 'DoanhThu'
		from (
			select datepart(quarter,i.deliverydate) as 'quy', year(i.deliverydate) as 'nam', (o.price * o.quantity) as 'thanhtien'
			from invoice i, [dbo].[order] o
			where i.invoiceno = o.invoiceno and  year(i.deliverydate) = @nam
		) as x
		group by x.quy, x.nam
	end

create proc sp_DoanhThuTungLoaiSanPhamTheoThang
(
	@nam int
)
as
	begin
		select x.thang as 'Thang' , x.mon as 'SanPham' , sum(x.thanhtien) as 'DoanhThu'
		from (
			select month(i.deliverydate) as 'thang', o.productname as 'mon' ,(o.price * o.quantity) as 'thanhtien'
			from invoice i, [dbo].[order] o
			where i.invoiceno = o.invoiceno and year(i.deliverydate) = @nam 
		) as x
		group by x.mon, x.thang
	end

	execute sp_DoanhThuTungLoaiSanPhamTheoThang 2021

create proc sp_DoanhThuTungLoaiSanPhamTheoQuy
(
	@nam int
)
as
	begin
	select x.quy as 'Quy' , x.mon as 'SanPham' , sum(x.thanhtien) as 'DoanhThu'
		from (
			select datepart(quarter,i.deliverydate) as 'quy', o.productname as 'mon' ,(o.price * o.quantity) as 'thanhtien'
			from invoice i, [dbo].[order] o
			where i.invoiceno = o.invoiceno and year(i.deliverydate) = @nam 
		) as x
		group by x.mon, x.quy
	end
	
	execute sp_DoanhThuTungLoaiSanPhamTheoQuy 2021

create proc sp_DoanhThuTungLoaiSanPhamTheoNam
as
	begin
		select x.nam as 'Nam' , x.mon as 'SanPham' , sum(x.thanhtien) as 'DoanhThu'
		from (
			select year(i.deliverydate) as 'nam', o.productname as 'mon' ,(o.price * o.quantity) as 'thanhtien'
			from invoice i, [dbo].[order] o
			where i.invoiceno = o.invoiceno 
		) as x
		group by x.mon, x.nam
	end
	
	execute sp_DoanhThuTungLoaiSanPhamTheoNam 