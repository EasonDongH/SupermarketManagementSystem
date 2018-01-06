use SMDB
go
--管理员信息
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId)
values('11223344','王永利',1,1)
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId)
values('11223344','张红梅',1,2)
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId)
values('11223344','刘丽娜',1,2)
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId)
values('11223344','王惠惠',0,2)
--销售员信息---销售员与管理员的区别？?？
insert into  SalesPerson(SalePersonName,LoginPwd) values('王丽丽','123456')
insert into  SalesPerson(SalePersonName,LoginPwd) values('王小刚','123456')
insert into  SalesPerson(SalePersonName,LoginPwd) values('王大力','123456')
--超市会员信息---MemberId实际开发中不使用标识列而是使用刷卡录入卡号
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('王晓敏',default,'13590856789','天津南开区',default,default)
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('刘全明',default,'13590856788','天津河北区',default,default)
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('赵大力',default,'13590856785','天津红桥区',default,default)
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('王文才',default,'13590856782','天津东丽区',default,default)
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('李兆新',default,'13590856781','天津河西区',default,default)
--商品分类数据
insert into ProductCategory(CategoryName) values('饮料')--1
insert into ProductCategory(CategoryName) values('副食')--2
insert into ProductCategory(CategoryName) values('面食')--3
insert into ProductCategory(CategoryName) values('肉类')--4
insert into ProductCategory(CategoryName) values('米类')--5
insert into ProductCategory(CategoryName) values('酒类')--6
insert into ProductCategory(CategoryName) values('烟类')--7
insert into ProductCategory(CategoryName) values('文具')--8
insert into ProductCategory(CategoryName) values('玩具')--9
insert into ProductCategory(CategoryName) values('日用品')--10
--商品计量单位
insert into ProductUnit values('箱')
insert into ProductUnit values('瓶')
insert into ProductUnit values('盒')
insert into ProductUnit values('本')
insert into ProductUnit values('袋')
insert into ProductUnit values('只')
insert into ProductUnit values('条')
insert into ProductUnit values('桶')
insert into ProductUnit values('打')
insert into ProductUnit values('听')
insert into ProductUnit values('罐')
insert into ProductUnit values('张')
insert into ProductUnit values('块')
insert into ProductUnit values('床')
insert into ProductUnit values('把')
insert into ProductUnit values('台')
insert into ProductUnit values('个')
--商品信息
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003001','康师傅牛肉面',40.00,'箱',0,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003002','康师傅打卤面',35.00,'箱',0,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003003','康师傅三鲜面',38.00,'箱',0,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003004','统一牛肉面',36.00,'箱',8,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003005','统一酸菜面',42.00,'箱',9,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003006','雪花啤酒',60.50,'箱',0,6)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003007','燕京啤酒',60.00,'箱',0,6)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003008','可口可乐',6.80,'瓶',0,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003009','百事可乐',5.80,'瓶',0,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003010','统一鲜橙多',5.80,'瓶',0,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003011','茉莉花茶',3.50,'瓶',0,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003012','自制蛋糕',19.80,'盒',0,2)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003013','中型碳素笔',10.00,'盒',0,9)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003014','黑妹牙膏',6.80,'盒',0,10)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003015','东北大米',80.00,'袋',0,5)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003016','天津小站大米',100.00,'袋',0,5)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003017','利达面粉',68.50,'袋',0,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003018','大豆油',68.80,'桶',0,2)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003019','纯棉毛巾',8.80,'条',0,10)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003020','金龙鱼食用油',55.80,'桶',9,2)
--商品库存状态
insert into InventoryStatus(StatusId,StatusDesc)values(1,'正常')
insert into InventoryStatus(StatusId,StatusDesc)values(-1,'低于库存')
insert into InventoryStatus(StatusId,StatusDesc)values(2,'高于库存')
insert into InventoryStatus(StatusId,StatusDesc)values(-2,'已清仓')
--商品库存数据
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003001',190,200,500,1)--方便面
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003002',350,200,500,1)--方便面
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003003',230,200,500,1)--方便面
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003004',300,200,400,1)--方便面
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003005',190,100,300,1)--方便面
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003006',1000,200,500,1)--啤酒
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003007',1000,200,300,1)--啤酒
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003008',180,200,300,1)--饮料
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003009',210,200,300,1)--饮料
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003010',150,100,200,1)--饮料
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003011',150,100,200,1)--饮料
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003012',200,100,150,1)--盒
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003013',80,100,150,1)--盒
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003014',50,100,150,1)--盒
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003015',180,100,200,1)--袋
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003016',160,100,200,1)--袋
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003017',1000,100,200,1)--袋
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003018',230,100,200,1)--桶
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003019',150,100,200,1)--条
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId)
values('6005004003020',120,100,200,1)--桶
