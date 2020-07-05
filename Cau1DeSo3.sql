-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Alter PROCEDURE DSDonHangDe3 
	(@tenNhanVien nvarchar(50),
	@dateBegin datetime,
	@dateEnd datetime,
	@page int = null,
	@size int = null)
AS
BEGIN
	
	declare @begin int;
	declare @end int;

	set @begin = (@page -1) * @size + 1;
	set @end = @page *@size;
	with s as
		
		(SELECT ROW_NUMBER() over(order by OrderDate) as STT, OrderID, a.EmployeeID, OrderDate
		from Orders a inner join Employees b
		on a.EmployeeID = b.EmployeeID
		where
			LastName = @tenNhanVien
			and OrderDate between @dateBegin and @dateEnd
			)

			select * from s
			where STT between @begin and @end
END
GO

exec DSDonHangDe3 'Peacock', '1996-07-18','1996-09-02', 1, 10
go


-- Câu 1b đề 3 
alter Proc MatHangBanChay
		(@thang int,
		@nam int,
		@page int = null,
		@size int = null,
		@isQuanity int = null)
As
begin
	declare @begin int;
	declare @end int;
	

	set @begin = (@page -1) * @size + 1;
	set @end = @page *@size;

if(@isQuanity = 1)
	begin
	with s as
	
		(SELECT ROW_NUMBER() over(order by OrderDate) as STT, a.ProductID,ProductName,c.UnitPrice,UnitsInStock,Discount,
			sum(Quantity) as SoLuong
		from [Order Details] a 
		inner join Orders b
		on a.OrderID = b.OrderID
		inner join Products c
		on a.ProductID = c.ProductID
		where MONTH(OrderDate) = @thang
		and YEAR(OrderDate) = @nam
		group by  a.ProductID, OrderDate,ProductName,c.UnitPrice,UnitsInStock,Discount)

		select * from s
		where STT between @begin and @end

		order by s.SoLuong DESC
	end
else
	begin
		with s as
			(SELECT ROW_NUMBER() over(order by OrderDate) as STT, a.ProductID,ProductName,c.UnitPrice,UnitsInStock,Discount,
			sum(a.UnitPrice * a.Quantity * (1-a.Discount))as DoanhThu
		from [Order Details] a 
		inner join Orders b
		on a.OrderID = b.OrderID
		inner join Products c
		on a.ProductID = c.ProductID
		where MONTH(OrderDate) = @thang
		and YEAR(OrderDate) = @nam
		group by  a.ProductID, OrderDate,ProductName,c.UnitPrice,UnitsInStock,Discount)

		select * from s
		where STT between @begin and @end

		order by s.DoanhThu DESC

	end

end
go

exec MatHangBanChay '7', '1996',1,11, 2
go

--Câu 1 c đề số 3
create proc DoanhThuTheoQuocGia
		(@thang int,
		@nam int)
as
begin
	select SUM(((Quantity * UnitPrice) * (1 - Discount))) as DoanhThu, ShipCountry
	from [Order Details] a inner join Orders b
	on a.OrderID = b.OrderID
	 and MONTH(OrderDate) = @thang
	 and Year(OrderDate) = @nam
	 group by ShipCountry

end
go

exec DoanhThuTheoQuocGia 9, 1996
go