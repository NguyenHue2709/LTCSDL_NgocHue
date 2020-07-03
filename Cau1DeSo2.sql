--Câu 1 a đề 2
alter proc DSDonHang(
		@dateBegin datetime,
		@dateEnd datetime
)
as
begin
	select *
	from Orders
	where  OrderDate between @dateBegin and @dateEnd
end
go

exec DSDonHang '1996-07-04','1996-07-16'

--câu 1 b đề 2
alter proc ChiTietDonHang(
	@maDonHang int
)
as
begin
	select *
	from Orders
	where OrderID = @maDonHang
end
go

exec ChiTietDonhang '10250'