--Câu 1 a đề 5
use NorthWind
go
create proc DSSanPhamKhongCoTrongNgay(
	@date datetime,
	@page int,
	@size int
)
as
begin
	declare @begin int;
	declare @end int;

	set @begin = (@page -1) * @size + 1;
	set @end = @begin +@size;
	with s as
		(SELECT ROW_NUMBER() over(order by ProductID) as STT, *
		FROM Products
		where ProductID not in (
			select ProductID 
			from [Order Details] a 
			inner join Orders b on a.OrderID = b.OrderID
			where Day(OrderDate) = day(@date) and 
			Month(OrderDate) = month(@date) and
			year(OrderDate) = year(@date)
		))

		select * from s
			where STT between @begin and @end
end
go


exec DSSanPhamKhongCoTrongNgay '1996-07-05', 1,5
go


--Câu 1 c đề 5
create  proc TimKiemOrder(
		@keyWord nvarchar(20),
		@page int,
		@size int
)
as
begin
	declare @begin int;
	declare @end int;

	set @begin = (@page -1) * @size + 1;
	set @end = @page *@size;
	with s as
		(SELECT ROW_NUMBER() over(order by OrderID) as STT, OrderID ,a.CustomerID, a.EmployeeID, LastName, CompanyName
			from Orders a inner join Employees b
			on a.EmployeeID = b.EmployeeID
			inner join Customers c 
			on a.CustomerID = c.CustomerID
			where  b.LastName like '%' + @keyWord + '%'
				or c.CompanyName like '%' + @keyWord + '%'

				)

		select * from s
			where STT between @begin and @end
end
go


exec TimKiemOrder 'Vins et alcools Chevalier', 'Buchanan', 1,5

--Câu 1 b đề 5
alter proc SPKhongTonKho(
		@page int,
		@size int)
as
begin
	declare @begin int;
	declare @end int;

	set @begin = (@page -1) * @size + 1;
	set @end = @page *@size;
	with s as
		(SELECT ROW_NUMBER() over(Order by ProductID) as STT,ProductID, ProductName, UnitsInStock
			from Products
			where UnitsInStock = 0
		)
	select * from s
	where STT between @begin and @end
end
go

exec SPKhongTonKho 1,5

