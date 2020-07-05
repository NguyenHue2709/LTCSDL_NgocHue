-- câu 1 a đề 1
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE DsNhanVienTrongNgay 	
	(@date datetime)
AS
BEGIN
	
	SELECT a.EmployeeID, a.LastName, a.FirstName, sum (UnitPrice*Quantity*(1-Discount)) as DoanhThuTrongNgay
	from Employees a inner join Orders b
	on a.EmployeeID = b.EmployeeID
	inner join [Order Details] c 
	on b.OrderID = c.OrderID
	where
		DAY(OrderDate) = DAY(@date) 
		and MONTH(OrderDate) = MONTH(@date)
		and YEAR(OrderDate) = YEAR(@date)
		group by  a.EmployeeID, a.LastName, a.FirstName
END
GO
exec DsNhanVienTrongNgay '1996-7-5'

--câu 1 b đề 1
alter PROCEDURE DoanhThuTrongKhoangThoiGian
	-- Add the parameters for the stored procedure here
	@dateBegin datetime,
	@dateEnd datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		select e.EmployeeID,e.FirstName, e.LastName, SUM(((c.Quantity * c.UnitPrice) * (1 - c.Discount))) as doanhThu
	from Employees e INNER JOIN Orders o ON e.EmployeeID = o.EmployeeID
		 INNER JOIN [Order Details] c ON o.OrderID = c.OrderID
	where o.OrderDate between @dateBegin and @dateEnd 
	group by e.EmployeeID,e.FirstName, e.LastName
END
GO
exec DoanhThuTrongKhoangThoiGian '1996-07-04', '1996-07-18'


