use SMDB
go

--LoginLogs分页查询
if exists(select * from sysobjects where name='usp_LoginLogsPagingQuery')
drop procedure usp_LoginLogsPagingQuery
go

create procedure usp_LoginLogsPagingQuery
@PageSize int,--每页显示数据行数
@RecordCount int,
@BegainTime dateTime,
@EndTime dateTime
as
    declare @CurrentPage int=1--当前页数
    declare @Temp int= @PageSize*(@CurrentPage-1)
	while (@Temp<=@RecordCount)
	Begin
		 select Top (@PageSize) LoginId,LoginName, ServerName,LoginTime,ExitTime from LoginLogs 
		 where LoginId not in (select Top (@Temp) LoginId from LoginLogs where LoginTime between @BegainTime and @EndTime order by	LoginTime ASC) and LoginTime between @BegainTime and @EndTime order by LoginTime ASC
		 set @CurrentPage=@CurrentPage+1
		 set @Temp = @PageSize*(@CurrentPage-1)
	End
go 

--添加新商品
if exists(select * from sysobjects where name='usp_AddNewProduct')
drop procedure usp_AddNewProduct
go

create procedure usp_AddNewProduct
@ProductId varchar(50),
@ProductName varchar(50),
@UnitPrice numeric(8,2),
@Unit varchar(50),
@CategoryId int,
@MinCount int,
@MaxCount int
as 
	declare @@errorNum int
    begin transaction
		begin
		insert into Products (ProductId, ProductName, UnitPrice, Unit, CategoryId) values (@ProductId, @ProductName, @UnitPrice, @Unit, @CategoryId)
		set @@errorNum=@@errorNum+@@error
		insert into ProductInventory (ProductId, TotalCount, MinCount, MaxCount, StatusId) values (@ProductId, 0, @MinCount, @MaxCount, -1)
		set @@errorNum=@@errorNum+@@error
		if( @@errorNum>0)		
			rollback transaction		
		else		
			commit transaction			
	end
go


--修改商品库存
if exists(select * from sysobjects where name='usp_ModifyProductInventory')
drop procedure usp_ModifyProductInventory
go

create procedure usp_ModifyProductInventory
@AddCount int,
@TotalCount int,
--@MaxCount int,
--@MinCount int,
@ProductId varchar(50),
@LoginId int
as
	declare @errorNum int
	begin transaction
		begin
			update ProductInventory  set TotalCount=@TotalCount,StatusId=
			case 
			when @TotalCount=0 then -2 --清仓
			when @TotalCount > 0 and @TotalCount< MinCount then -1 --缺货(包含最低库存)
			when @TotalCount >= MinCount and @TotalCount<= MaxCount then 1 --正常（不包含最低库存）
			--when @TotalCount >MaxCount then 2 --高于库存 
			else 2
			end
			where ProductId=@ProductId	
			set @errorNum=@errorNum+@@ERROR

			insert 	into ProductStorage (ProductId,AddedCount,LoginId) values (@ProductId,@AddCount,@LoginId) 
			set @errorNum=@errorNum+@@ERROR

			if(@errorNum>0)
				rollback transaction
			else
				commit transaction
		end
go

--修改商品信息
if exists(select * from sysobjects where name='usp_ModifyProductInfo')
drop procedure usp_ModifyProductInfo
go

create procedure usp_ModifyProductInfo
@ProductId varchar(50),
@NewProductId varchar(50),
@ProductName varchar(50),
--@NewProductName varchar(50)
@Unit varchar(50),
@UnitPrice numeric(8,2),
@CategoryId int
as
	declare @errorNum int
	begin transaction
		begin

		if(@ProductId <> @NewProductId)
		begin
		update Products set ProductId=@NewProductId where ProductId=@ProductId
		set @errorNum=@errorNum+@@error
		--级联更新
		--update ProductInventory set ProductId=@NewProductId where ProductId=@ProductId
		--set @errorNum=@errorNum+@@error
		--商品库存表没有添加级联更新，因此需要再次更新
		update ProductStorage set ProductId=@NewProductId where ProductId=@ProductId
		set @errorNum=@errorNum+@@error
		--已销售的商品信息需不需要修改？
		--update SalesListDetail set ProductId=@NewProductId where ProductId=@ProductId
		--set @errorNum=@errorNum+@@error
		end

		update Products set ProductName=@ProductName,Unit=@Unit,UnitPrice=@UnitPrice,CategoryId=@CategoryId where ProductId=@NewProductId
		set @errorNum=@errorNum+@@error
		--if(@ProductName <> @NewProductName)
		--begin
		--update Products set ProductName=@NewProductName where ProductName=@ProductName
		--set @errorNum=@errorNum+@@error				
		----已销售的商品信息需不需要修改？
		----update SalesListDetail set ProductId=@NewProductId where ProductId=@ProductId
		----set @errorNum=@errorNum+@@error
		--end

		if(@errorNum>0)
				rollback transaction
		else
				commit transaction
		end
go

--创建销售统计存储过程
if exists(select * from sysobjects where name='usp_ProdoctSaleStat')
drop procedure usp_ProdoctSaleStat
go

create procedure usp_ProdoctSaleStat
@BeginDate smalldatetime,
@EndDate smalldatetime
as
	select ProductId,Quantity into #temp from SalesListDetail
	inner join SalesList on SalesList.SerialNum=SalesListDetail.SerialNum
	where SaleDate between @BeginDate and @EndDate  
	select #temp.ProductId,ProductName,Unit,CategoryName,SaleCount=sum(Quantity) from #temp
	inner join Products on Products.ProductId=#temp.ProductId
	inner join ProductCategory on Products.CategoryId=ProductCategory.CategoryId
	group by #temp.ProductId,ProductName,Unit,CategoryName
	order by SaleCount desc
go
