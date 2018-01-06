use master
go
if exists (select * from sysdatabases where name='SaleManagerDB')
drop database SaleManagerDB
go
create database SaleManagerDB
on primary
(
    name='SaleManagerDB_data',
    filename='D:\DB\SaleManagerDB_data.mdf',
    size=20MB,
    filegrowth=5MB
)
log on
(
    name='SaleManagerDB_log',
    filename='D:\DB\SaleManagerDB_log.ldf',
    size=5MB,
    filegrowth=5MB
)
go

use SaleManagerDB
go
--商品分类表
if exists (select * from sysobjects where name='ProductCategory')
drop table ProductCategory
go
create table ProductCategory
(
	CategoryId int identity(1,1) primary key ,--商品分类编号
	CategoryName varchar(20) not null--商品分类名称
)
go
--商品计量单位表
if exists (select * from sysobjects where name='ProductUnit')
drop table ProductUnit
go
create table ProductUnit
(
	Id int identity(1,1) primary key ,
	Unit varchar(20) not null--商品计量单位
)
go
--商品信息表
if exists (select * from sysobjects where name='Products')
drop table Products
go
create table Products
(
	ProductId varchar(50) primary key,--商品编号（商品条码）
	ProductName varchar(50) not null, 
	UnitPrice numeric(18,2) not null,
	Unit varchar(50) not null,--计量单位（为了提高效率，该字段并没有使用外键）
	Discount int,--折扣
	CategoryId int  references ProductCategory (CategoryId) not null --（商品分类）外键
)
go
--商品库存状态
if exists (select * from sysobjects where name='InventoryStatus')
drop table InventoryStatus
go
create table InventoryStatus
(	
    StatusId int primary key,--库存状态
    StatusDesc varchar(50) not null--（1：正常，-1：低于库存，2：高于库存；-2：已清仓）
)
go
--商品库存信息
if exists (select * from sysobjects where name='ProductInventory')
drop table ProductInventory
go
create table ProductInventory
(
	ProductId varchar(50) primary key,--商品编号
    TotalCount int not null,--总数量
    MinCount int not null,--最小库存
    MaxCount int not null,--最大库存
    StatusId int references InventoryStatus (StatusId) --库存状态（1：正常，-1：低于库存，2：高于库存；-2：已清仓）
)
go
--销售员表
if exists (select * from sysobjects where name='SalesPerson')
drop table SalesPerson
go
create table SalesPerson
(
	SalesPersonId int identity(10000,1) primary key,-- 自动标识
	SPName varchar(50) not null,
	LoginPwd varchar(50)  not null --最少6位  
)
go
--销售流水账
if exists (select * from sysobjects where name='SalesList')
drop table SalesList
go
create table SalesList
(  
	SerialNum varchar(50) primary key not null, --流水号(系统自动生成)
	TotalMoney numeric(10,2) not null,--购物总价钱
	RealReceive numeric(10,2) not null,--实际收款
	ReturnMoney  numeric(10,2) not null,--找零
	SalesPersonId int references SalesPerson (SalesPersonId), --销售员（外键）
	SaleDate smalldatetime  default(getdate()) not null --默认数据库服务器时间
)
go
--销售流水账明细
if exists (select * from sysobjects where name='SalesListDetail')
drop table SalesListDetail
go
create table SalesListDetail
(
    Id int identity(1000000,1) primary key not  null,--自动标识列
    SerialNum varchar(50) references SalesList (SerialNum), --流水号（外键）
	ProductId varchar(50) not null, --商品编号（不需要外键）
	ProductName varchar(50) not null,
	UnitPrice numeric(10,2) not null,
	Discount int,--折扣
	Quantity int not null,--销售数量	
    SubTotalMoney numeric(10,2)--小计金额
)
go
--商品入库表
if exists (select * from sysobjects where name='ProductStorage')
drop table ProductStorage
go
create table ProductStorage
(
	StorageId int identity(100000,1) primary key,--标识列
	ProductId varchar(50) references Products (ProductId),--外键
	AddedCount int not null,--入库数量
	CurrentTime smalldatetime default(getdate())  not null --默认数据库服务器时间
)
go
--登录日志
if exists (select * from sysobjects where name='LoginLogs')
drop table LoginLogs
go
create table LoginLogs
(
    LogId int identity(1,1) primary key,
	LoginId  int not null,
	SPName varchar(50),--登录人员姓名
	ServerName varchar(100),--登录的服务器名称
	LoginTime datetime default(getdate()) not null, --默认数据库服务器时间
	ExitTime datetime --退出时间
)
go
--超市会员表
if exists (select * from sysobjects where name='SMMembers')
drop table SMMembers
go
create table SMMembers
(
	MemberId int identity(100200300,1) primary key,--会员卡号
	MemberName varchar(50) not null,--会员姓名	
	Points int default(0) not null,--会员积分（消费10元，获得1个积分）
	PhoneNumber varchar(200) not null,--联系电话
	MemberAddress text not null,--联系地址
	OpenTime datetime default(getdate()),--开户时间
	MemberStatus int default(1) not null--会员卡状态（1：正常使用；0：冻结；-1：注销）
)
go
--管理员表
if exists (select * from sysobjects where name='SysAdmins')
drop table SysAdmins
go
create table SysAdmins
(
	LoginId int identity(2000,1) primary key,--登录账号
	LoginPwd varchar(20),--登录密码
	AdminName varchar(20),--管理员姓名
	AdminStatus bit, --当前状态（1：启用；0：禁用）
	RoleId int --角色编号（1：超级管理员；2：一般管理员）
)
go

--添加级联更新
if exists(select * from sysobjects where name='fk_ProductId_PI')
alter table ProductInventory drop constraint fk_ProductId_PI

alter table ProductInventory add constraint fk_ProductId_PI foreign key (ProductId) references Products (ProductId) on update cascade

--添加商品discount默认值
if exists(select * from sysobjects where name='df_ProductDiscountDefault')
alter table Products drop constraint df_ProductDiscountDefault

alter table Products add constraint df_ProductDiscountDefault default(1.0) for Discount

----添加商品Status默认值
--if exists(select * from sysobjects where name='df_ProductStatusDefault')
--alter table Products drop constraint df_ProductStatusDefault

--alter table ProductInventory add constraint df_ProductStatusDefault default(case 
--			when TotalCount=0 then -2 --清仓
--			when TotalCount between MinCount and 0 then -1 --缺货(包含最低库存)
--			when TotalCount between MaxCount and MinCount then 1 --正常（不包含最低库存）
--			when TotalCount >MaxCount then 2 --高于库存 
--			end) for StatusId