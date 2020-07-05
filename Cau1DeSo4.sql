use Northwind
go
-- Câu 1c--Nhập vào từ khóa để tìm kiếm Supplier theo Companyname, Country

alter proc DanhSachSupplier
	(@keyword nvarchar(20),
	@page int,
	@size int)
as
begin
	
	declare @begin int;
	declare @end int;

	set @begin = (@page -1) * @size + 1;
	set @end = @page *@size;
	with s as
		(select ROW_NUMBER() over(order by SupplierID) as STT , SupplierID, CompanyName, Country
		from Suppliers
		where Country like '%'+ @keyword + '%'
		or CompanyName like '%'+ @keyword + '%'
		)
		select * from s
			where STT between @begin and @end
end
go

exec  DanhSachSupplier 'New Orleans Cajun Delights','USA',1,5
go
-- Câu 1a--Thêm 1 record cho bảng Suppliers 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[ThemRecord](
	@companyName nvarchar(40),
	@contactName nvarchar(30)=null,
	@contactTitle nvarchar(30)=null,
	@address nvarchar(60)=null,
	@city nvarchar(15)=null,
	@region nvarchar(15)=null,
	@postalCode nvarchar(10)=null,
	@country nvarchar(15)=null,
	@phone nvarchar(24)=null,
	@fax nvarchar(24)=null,
	@homePage nvarchar=null
)
as
begin
	INSERT INTO [dbo].[Suppliers]
           ([CompanyName]
           ,[ContactName]
           ,[ContactTitle]
           ,[Address]
           ,[City]
           ,[Region]
           ,[PostalCode]
           ,[Country]
           ,[Phone]
           ,[Fax]
           ,[HomePage])
	values(
		@companyName, 
		@contactName,
		@contactTitle,
		@address,
		@city,
		@region,
		@postalCode,
		@country,
		@phone,
		@fax,
		@homePage);

	select*
	from Suppliers
	where SupplierID = @@IDENTITY;
end

exec ThemRecord 'sssss','ccc', 'ccc','dd','wa','a','a','a','a','a','a'

-- Câu 1b -- cập nhật 1 record cho bảng Suppliers
alter proc CapNhatSuppliers(
	@id int ,
	@companyName nvarchar(40),
	@contactName nvarchar(30)=null,
	@contactTitle nvarchar(30)=null,
	@address nvarchar(60)=null,
	@city nvarchar(15)=null,
	@region nvarchar(15)=null,
	@postalCode nvarchar(10)=null,
	@country nvarchar(15)=null,
	@phone nvarchar(24)=null,
	@fax nvarchar(24)=null,
	@homePage nvarchar=null
)
as
begin
	UPDATE [dbo].[Suppliers]
   SET [CompanyName] = @companyName
      ,[ContactName] = @contactName
      ,[ContactTitle] = @contactTitle
      ,[Address] = @address
      ,[City] = @city
      ,[Region] = @region
      ,[PostalCode] = @postalCode
      ,[Country] = @country
      ,[Phone] = @phone
      ,[Fax] = @fax
      ,[HomePage] = @homePage
	WHERE SupplierID = @id

	select *
	from Suppliers
	where SupplierID = @id
end
go

-- Update Shippers
update [Shippers] set 

exec CapNhatSuppliers '33','gf','fpt',null,null,null,null,null,null,null,null,null