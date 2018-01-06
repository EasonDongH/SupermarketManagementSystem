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
--��Ʒ�����
if exists (select * from sysobjects where name='ProductCategory')
drop table ProductCategory
go
create table ProductCategory
(
	CategoryId int identity(1,1) primary key ,--��Ʒ������
	CategoryName varchar(20) not null--��Ʒ��������
)
go
--��Ʒ������λ��
if exists (select * from sysobjects where name='ProductUnit')
drop table ProductUnit
go
create table ProductUnit
(
	Id int identity(1,1) primary key ,
	Unit varchar(20) not null--��Ʒ������λ
)
go
--��Ʒ��Ϣ��
if exists (select * from sysobjects where name='Products')
drop table Products
go
create table Products
(
	ProductId varchar(50) primary key,--��Ʒ��ţ���Ʒ���룩
	ProductName varchar(50) not null, 
	UnitPrice numeric(18,2) not null,
	Unit varchar(50) not null,--������λ��Ϊ�����Ч�ʣ����ֶβ�û��ʹ�������
	Discount int,--�ۿ�
	CategoryId int  references ProductCategory (CategoryId) not null --����Ʒ���ࣩ���
)
go
--��Ʒ���״̬
if exists (select * from sysobjects where name='InventoryStatus')
drop table InventoryStatus
go
create table InventoryStatus
(	
    StatusId int primary key,--���״̬
    StatusDesc varchar(50) not null--��1��������-1�����ڿ�棬2�����ڿ�棻-2������֣�
)
go
--��Ʒ�����Ϣ
if exists (select * from sysobjects where name='ProductInventory')
drop table ProductInventory
go
create table ProductInventory
(
	ProductId varchar(50) primary key,--��Ʒ���
    TotalCount int not null,--������
    MinCount int not null,--��С���
    MaxCount int not null,--�����
    StatusId int references InventoryStatus (StatusId) --���״̬��1��������-1�����ڿ�棬2�����ڿ�棻-2������֣�
)
go
--����Ա��
if exists (select * from sysobjects where name='SalesPerson')
drop table SalesPerson
go
create table SalesPerson
(
	SalesPersonId int identity(10000,1) primary key,-- �Զ���ʶ
	SPName varchar(50) not null,
	LoginPwd varchar(50)  not null --����6λ  
)
go
--������ˮ��
if exists (select * from sysobjects where name='SalesList')
drop table SalesList
go
create table SalesList
(  
	SerialNum varchar(50) primary key not null, --��ˮ��(ϵͳ�Զ�����)
	TotalMoney numeric(10,2) not null,--�����ܼ�Ǯ
	RealReceive numeric(10,2) not null,--ʵ���տ�
	ReturnMoney  numeric(10,2) not null,--����
	SalesPersonId int references SalesPerson (SalesPersonId), --����Ա�������
	SaleDate smalldatetime  default(getdate()) not null --Ĭ�����ݿ������ʱ��
)
go
--������ˮ����ϸ
if exists (select * from sysobjects where name='SalesListDetail')
drop table SalesListDetail
go
create table SalesListDetail
(
    Id int identity(1000000,1) primary key not  null,--�Զ���ʶ��
    SerialNum varchar(50) references SalesList (SerialNum), --��ˮ�ţ������
	ProductId varchar(50) not null, --��Ʒ��ţ�����Ҫ�����
	ProductName varchar(50) not null,
	UnitPrice numeric(10,2) not null,
	Discount int,--�ۿ�
	Quantity int not null,--��������	
    SubTotalMoney numeric(10,2)--С�ƽ��
)
go
--��Ʒ����
if exists (select * from sysobjects where name='ProductStorage')
drop table ProductStorage
go
create table ProductStorage
(
	StorageId int identity(100000,1) primary key,--��ʶ��
	ProductId varchar(50) references Products (ProductId),--���
	AddedCount int not null,--�������
	CurrentTime smalldatetime default(getdate())  not null --Ĭ�����ݿ������ʱ��
)
go
--��¼��־
if exists (select * from sysobjects where name='LoginLogs')
drop table LoginLogs
go
create table LoginLogs
(
    LogId int identity(1,1) primary key,
	LoginId  int not null,
	SPName varchar(50),--��¼��Ա����
	ServerName varchar(100),--��¼�ķ���������
	LoginTime datetime default(getdate()) not null, --Ĭ�����ݿ������ʱ��
	ExitTime datetime --�˳�ʱ��
)
go
--���л�Ա��
if exists (select * from sysobjects where name='SMMembers')
drop table SMMembers
go
create table SMMembers
(
	MemberId int identity(100200300,1) primary key,--��Ա����
	MemberName varchar(50) not null,--��Ա����	
	Points int default(0) not null,--��Ա���֣�����10Ԫ�����1�����֣�
	PhoneNumber varchar(200) not null,--��ϵ�绰
	MemberAddress text not null,--��ϵ��ַ
	OpenTime datetime default(getdate()),--����ʱ��
	MemberStatus int default(1) not null--��Ա��״̬��1������ʹ�ã�0�����᣻-1��ע����
)
go
--����Ա��
if exists (select * from sysobjects where name='SysAdmins')
drop table SysAdmins
go
create table SysAdmins
(
	LoginId int identity(2000,1) primary key,--��¼�˺�
	LoginPwd varchar(20),--��¼����
	AdminName varchar(20),--����Ա����
	AdminStatus bit, --��ǰ״̬��1�����ã�0�����ã�
	RoleId int --��ɫ��ţ�1����������Ա��2��һ�����Ա��
)
go

--��Ӽ�������
if exists(select * from sysobjects where name='fk_ProductId_PI')
alter table ProductInventory drop constraint fk_ProductId_PI

alter table ProductInventory add constraint fk_ProductId_PI foreign key (ProductId) references Products (ProductId) on update cascade

--�����ƷdiscountĬ��ֵ
if exists(select * from sysobjects where name='df_ProductDiscountDefault')
alter table Products drop constraint df_ProductDiscountDefault

alter table Products add constraint df_ProductDiscountDefault default(1.0) for Discount

----�����ƷStatusĬ��ֵ
--if exists(select * from sysobjects where name='df_ProductStatusDefault')
--alter table Products drop constraint df_ProductStatusDefault

--alter table ProductInventory add constraint df_ProductStatusDefault default(case 
--			when TotalCount=0 then -2 --���
--			when TotalCount between MinCount and 0 then -1 --ȱ��(������Ϳ��)
--			when TotalCount between MaxCount and MinCount then 1 --��������������Ϳ�棩
--			when TotalCount >MaxCount then 2 --���ڿ�� 
--			end) for StatusId