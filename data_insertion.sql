insert into Region(Name)
values('SINDH')

insert into Region(Name)
values('PUNJAB')

insert into Region(Name)
values('BALOCHISTAN')

insert into Region(Name)
values('KP')

select * from Region


insert into User_2(Region_idRegion, FirstName, LastName)
values(1, 'Akram', 'Khan')

insert into User_2(Region_idRegion, FirstName, LastName)
values(1, 'Ahmed', 'Hassan')

insert into User_2(Region_idRegion, FirstName, LastName)
values(1, 'Ali', 'Haider')

insert into User_2(Region_idRegion, FirstName, LastName)
values(2, 'Batool', 'Syed')

insert into User_2(Region_idRegion, FirstName, LastName)
values(2, 'Basim', 'Tariq')

insert into User_2(Region_idRegion, FirstName, LastName)
values(2, 'Basit', 'Memon')

insert into User_2(Region_idRegion, FirstName, LastName)
values(2, 'Dawood', 'Khan')

insert into User_2(Region_idRegion, FirstName, LastName)
values(3, 'Sarim', 'Mehdi')

insert into User_2(Region_idRegion, FirstName, LastName)
values(3, 'Saleem', 'Khan')

insert into User_2(Region_idRegion, FirstName, LastName)
values(4, 'Tahir', 'Ahmed')

select * from User_2


insert into Supplier(Region_idRegion, CompanyName, ContactName)
values(1, 'LifeCo', 'Ahmed Ashraf')

insert into Supplier(Region_idRegion, CompanyName, ContactName)
values(1, 'MrPill', 'Hyder Ahmed')

insert into Supplier(Region_idRegion, CompanyName, ContactName)
values(3, 'HPharma', 'Nouman Ali')

insert into Supplier(Region_idRegion, CompanyName, ContactName)
values(1, 'Medico', 'Faraz Shaikh')

insert into Supplier(Region_idRegion, CompanyName, ContactName)
values(2, 'HealthIn', 'Erum Mehmood')

insert into Supplier(Region_idRegion, CompanyName, ContactName)
values(2, 'Hearts', 'Aijaz Butt')

insert into Supplier(Region_idRegion, CompanyName, ContactName)
values(4, 'HerbalCo', 'Bilal Khan')

insert into Supplier(Region_idRegion, CompanyName, ContactName)
values(1, 'NewLife', 'Nadia Syed')

insert into Supplier(Region_idRegion, CompanyName, ContactName)
values(3, 'CareMedicine', 'Sarim Raza')

insert into Supplier(Region_idRegion, CompanyName, ContactName)
values(2, 'SydMedic', 'Habib Rizvi')

select * from Supplier

insert into Category(Name)
values('Masks')

insert into Category(Name)
values('Gloves')

insert into Category(Name)
values('Coats')

insert into Category(Name)
values('Safety Glasses')

insert into Category(Name)
values('Ear Safety')

select * from Category


insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(1, 1, 'Face Mask', 200, 52, 80, 0)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(1, 1, 'Surgical Mask', 300, 150, 60, 0.25)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(2, 1, 'KN95 Mask', 250, 88, 500, 0.10)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(1, 1, 'Full Face Respirator', 30, 2, 1000, 0)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(4, 1, 'Face Shield', 120, 30, 500, 0.30)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(2, 2, 'Latex Gloves', 450, 75, 30, 0.10)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(2, 2, 'Nitrile Gloves', 250, 22, 100, 0)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(1, 2, 'Vinyl Gloves', 100, 31, 110, 0)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(1, 2, 'Insulated Gloves', 30, 2, 400, 0)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(6, 3, 'Normal Lab Coat', 70, 20, 500, 0)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(6, 3, 'Flame Resistant Coat', 30, 1, 2000, 0)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(6, 3, 'Surgical Gown', 100, 40, 300, 0.10)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(2, 4, 'General Safety Glasses', 500, 70, 200, 0)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(3, 4, 'Laser Safety Glasses', 200, 40, 500, 0)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(3, 4, 'Chemical Splash Goggles', 100, 5, 1000, 0)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(8, 5, 'Disposable Earplugs', 500, 70, 50, 0)

insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount)
values(8, 5, 'Hearing Band', 100, 7, 300, 0.10)

select * from Stock

insert into Order_2(User_2_idUser_2, OrderDate)
values(1, '2019-11-11 13:23:44')

insert into Order_2(User_2_idUser_2, OrderDate)
values(3, '2019-11-17 17:53:14')

insert into Order_2(User_2_idUser_2, OrderDate)
values(7, '2019-12-11 07:20:40')

insert into Order_2(User_2_idUser_2, OrderDate)
values(2, '2019-12-15 11:43:14')

insert into Order_2(User_2_idUser_2, OrderDate)
values(4, '2019-12-15 13:23:44')

insert into Order_2(User_2_idUser_2, OrderDate)
values(3, '2019-12-16 18:20:32')

insert into Order_2(User_2_idUser_2, OrderDate)
values(2, '2019-12-20 11:28:04')

insert into Order_2(User_2_idUser_2, OrderDate)
values(9, '2019-12-24 05:20:00')

insert into Order_2(User_2_idUser_2, OrderDate)
values(1, '2019-12-25 14:43:24')

insert into Order_2(User_2_idUser_2, OrderDate)
values(2, '2019-12-29 09:13:54')

select * from Order_2

insert into [Shopping Cart]
values(1, 3, 1)

insert into [Shopping Cart]
values(1, 10, 1)

insert into [Shopping Cart]
values(2, 2, 5)

insert into [Shopping Cart]
values(3, 6, 2)

insert into [Shopping Cart]
values(3, 12, 1)

insert into [Shopping Cart]
values(4, 16, 4)

insert into [Shopping Cart]
values(4, 13, 1)

insert into [Shopping Cart]
values(5, 5, 1)

insert into [Shopping Cart]
values(6, 4, 1)

insert into [Shopping Cart]
values(7, 1, 5)

insert into [Shopping Cart]
values(7, 13, 2)

insert into [Shopping Cart]
values(7, 9, 1)

insert into [Shopping Cart]
values(7, 16, 4)

insert into [Shopping Cart]
values(8, 4, 1)

insert into [Shopping Cart]
values(9, 2, 10)

insert into [Shopping Cart]
values(9, 5, 5)

insert into [Shopping Cart]
values(10, 11, 1)

insert into [Shopping Cart]
values(10, 15, 1)

select * from [Shopping Cart]


insert into ShippingPartner(CompanyName, ContactNumber, VehiclesOwned)
values('MOVER', '+92 000 1234567', 2)

insert into ShippingPartner(CompanyName, ContactNumber, VehiclesOwned)
values('SpeedCo', '+92 000 1234567', 1)

insert into ShippingPartner(CompanyName, ContactNumber, VehiclesOwned)
values('VanMov', '+92 000 1234567', 3)

select * from ShippingPartner


insert into Vehicle(ShippingPartner_idShipper, Model)
values(1, 'X750')

insert into Vehicle(ShippingPartner_idShipper, Model)
values(1, 'X750')

insert into Vehicle(ShippingPartner_idShipper, Model)
values(2, 'GW33')

insert into Vehicle(ShippingPartner_idShipper, Model)
values(3, 'X750')

insert into Vehicle(ShippingPartner_idShipper, Model)
values(3, 'X800')

insert into Vehicle(ShippingPartner_idShipper, Model)
values(3, 'GW33')

select * from Vehicle

insert into Driver(Vehicle_idVehicle, FirstName, LastName)
values(1, 'Asif', 'Ali')

insert into Driver(Vehicle_idVehicle, FirstName, LastName)
values(2, 'Kamran', 'Raza')

insert into Driver(Vehicle_idVehicle, FirstName, LastName)
values(3, 'Yousuf', 'Khan')

insert into Driver(Vehicle_idVehicle, FirstName, LastName)
values(4, 'Imad', 'Memon')

insert into Driver(Vehicle_idVehicle, FirstName, LastName)
values(5, 'Qasim', 'Farid')

insert into Driver(Vehicle_idVehicle, FirstName, LastName)
values(6, 'Zubair', 'Shaikh')

select * from Driver

insert into Shipment(Order_2_idOrder_2, Driver_idDriver, DispatchDate, DeliveryDate)
values(1, 2, '2019-12-29', '2019-12-30')

insert into Shipment(Order_2_idOrder_2, Driver_idDriver, DispatchDate, DeliveryDate)
values(2, 4, '2019-12-29', '2019-12-30')

insert into Shipment(Order_2_idOrder_2, Driver_idDriver, DispatchDate, DeliveryDate)
values(3, 1, '2019-12-29', '2019-12-30')

insert into Shipment(Order_2_idOrder_2, Driver_idDriver, DispatchDate, DeliveryDate)
values(4, 2, '2019-12-29', '2019-12-30')

insert into Shipment(Order_2_idOrder_2, Driver_idDriver, DispatchDate, DeliveryDate)
values(5, 6, '2019-12-29', '2019-12-30')

insert into Shipment(Order_2_idOrder_2, Driver_idDriver, DispatchDate, DeliveryDate)
values(6, 2, '2019-12-29', '2019-12-30')

insert into Shipment(Order_2_idOrder_2, Driver_idDriver, DispatchDate, DeliveryDate)
values(7, 3, '2019-12-29', '2019-12-30')

insert into Shipment(Order_2_idOrder_2, Driver_idDriver, DispatchDate, DeliveryDate)
values(8, 1, '2019-12-29', '2019-12-30')

insert into Shipment(Order_2_idOrder_2, Driver_idDriver, DispatchDate, DeliveryDate)
values(9, 4, '2019-12-29', '2019-12-30')

insert into Shipment(Order_2_idOrder_2, Driver_idDriver, DispatchDate, DeliveryDate)
values(10, 1, '2019-12-29', '2019-12-30')

select * from Shipment
