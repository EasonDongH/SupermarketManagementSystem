use SMDB
go
--����Ա��Ϣ
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId)
values('11223344','������',1,1)
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId)
values('11223344','�ź�÷',1,2)
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId)
values('11223344','������',1,2)
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId)
values('11223344','���ݻ�',0,2)
--����Ա��Ϣ---����Ա�����Ա������?��
insert into  SalesPerson(SalePersonName,LoginPwd) values('������','123456')
insert into  SalesPerson(SalePersonName,LoginPwd) values('��С��','123456')
insert into  SalesPerson(SalePersonName,LoginPwd) values('������','123456')
--���л�Ա��Ϣ---MemberIdʵ�ʿ����в�ʹ�ñ�ʶ�ж���ʹ��ˢ��¼�뿨��
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('������',default,'13590856789','����Ͽ���',default,default)
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('��ȫ��',default,'13590856788','���ӱ���',default,default)
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('�Դ���',default,'13590856785','��������',default,default)
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('���Ĳ�',default,'13590856782','�������',default,default)
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('������',default,'13590856781','��������',default,default)
--��Ʒ��������
insert into ProductCategory(CategoryName) values('����')--1
insert into ProductCategory(CategoryName) values('��ʳ')--2
insert into ProductCategory(CategoryName) values('��ʳ')--3
insert into ProductCategory(CategoryName) values('����')--4
insert into ProductCategory(CategoryName) values('����')--5
insert into ProductCategory(CategoryName) values('����')--6
insert into ProductCategory(CategoryName) values('����')--7
insert into ProductCategory(CategoryName) values('�ľ�')--8
insert into ProductCategory(CategoryName) values('���')--9
insert into ProductCategory(CategoryName) values('����Ʒ')--10
--��Ʒ������λ
insert into ProductUnit values('��')
insert into ProductUnit values('ƿ')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('ֻ')
insert into ProductUnit values('��')
insert into ProductUnit values('Ͱ')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('̨')
insert into ProductUnit values('��')
--��Ʒ��Ϣ
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003001','��ʦ��ţ����',40.00,'��',0,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003002','��ʦ����±��',35.00,'��',0,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003003','��ʦ��������',38.00,'��',0,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003004','ͳһţ����',36.00,'��',8,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003005','ͳһ�����',42.00,'��',9,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003006','ѩ��ơ��',60.50,'��',0,6)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003007','�ྩơ��',60.00,'��',0,6)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003008','�ɿڿ���',6.80,'ƿ',0,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003009','���¿���',5.80,'ƿ',0,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003010','ͳһ�ʳȶ�',5.80,'ƿ',0,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003011','���򻨲�',3.50,'ƿ',0,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003012','���Ƶ���',19.80,'��',0,2)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003013','����̼�ر�',10.00,'��',0,9)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003014','��������',6.80,'��',0,10)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003015','��������',80.00,'��',0,5)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003016','���Сվ����',100.00,'��',0,5)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003017','�������',68.50,'��',0,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003018','����',68.80,'Ͱ',0,2)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003019','����ë��',8.80,'��',0,10)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003020','������ʳ����',55.80,'Ͱ',9,2)
--��Ʒ���״̬
insert into InventoryStatus(StatusId,StatusDesc)values(1,'����')
insert into InventoryStatus(StatusId,StatusDesc)values(-1,'���ڿ��')
insert into InventoryStatus(StatusId,StatusDesc)values(2,'���ڿ��')
insert into InventoryStatus(StatusId,StatusDesc)values(-2,'�����')
--��Ʒ�������
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003001',190,200,500,1)--������
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003002',350,200,500,1)--������
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003003',230,200,500,1)--������
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003004',300,200,400,1)--������
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003005',190,100,300,1)--������
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003006',1000,200,500,1)--ơ��
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003007',1000,200,300,1)--ơ��
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003008',180,200,300,1)--����
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003009',210,200,300,1)--����
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003010',150,100,200,1)--����
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003011',150,100,200,1)--����
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003012',200,100,150,1)--��
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003013',80,100,150,1)--��
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003014',50,100,150,1)--��
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003015',180,100,200,1)--��
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003016',160,100,200,1)--��
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003017',1000,100,200,1)--��
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003018',230,100,200,1)--Ͱ
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003019',150,100,200,1)--��
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003020',120,100,200,1)--Ͱ
