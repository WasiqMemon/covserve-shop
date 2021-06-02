CREATE TABLE ShippingPartner (
  idShipper INTEGER IDENTITY NOT NULL,
  CompanyName VARCHAR(225) NULL,
  ContactNumber VARCHAR(20) NULL,
  VehiclesOwned INTEGER NULL,
  PRIMARY KEY(idShipper)
);

CREATE TABLE Region (
  idRegion INTEGER IDENTITY NOT NULL,
  Name VARCHAR(225) NULL,
  PRIMARY KEY(idRegion)
);

CREATE TABLE Vehicle (
  idVehicle INTEGER IDENTITY NOT NULL,
  ShippingPartner_idShipper INTEGER NOT NULL,
  Model VARCHAR(225) NULL,
  PRIMARY KEY(idVehicle),
  INDEX Vehicle_FKIndex1(ShippingPartner_idShipper),
  FOREIGN KEY(ShippingPartner_idShipper)
    REFERENCES ShippingPartner(idShipper)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE User_2 (
  idUser_2 INTEGER IDENTITY NOT NULL ,
  Region_idRegion INTEGER NOT NULL,
  FirstName VARCHAR(225) NULL,
  LastName VARCHAR(225) NULL,
  PhoneNumber VARCHAR(20) NULL,
  Login_Password VARCHAR(225) NULL,
  EmailAddress VARCHAR(225) NULL,
  ShippingAddress VARCHAR(225) NULL,
  BillingAddress VARCHAR(225) NULL,
  CreditCardNumber VARCHAR(50) NULL,
  City VARCHAR(225) NULL,
  Country VARCHAR(225) NULL,
  PRIMARY KEY(idUser_2),
  INDEX User_2_FKIndex1(Region_idRegion),
  FOREIGN KEY(Region_idRegion)
    REFERENCES Region(idRegion)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Driver (
  idDriver INTEGER IDENTITY NOT NULL,
  Vehicle_idVehicle INTEGER NOT NULL,
  FirstName VARCHAR(225) NULL,
  LastName VARCHAR(225) NULL,
  PhoneNumber VARCHAR(225) NULL,
  HomeAddress VARCHAR(225) NULL,
  PRIMARY KEY(idDriver),
  INDEX Driver_FKIndex1(Vehicle_idVehicle),
  FOREIGN KEY(Vehicle_idVehicle)
    REFERENCES Vehicle(idVehicle)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Order_2 (
  idOrder_2 INTEGER IDENTITY NOT NULL ,
  User_2_idUser_2 INTEGER NOT NULL,
  OrderDate DATETIME NULL,
  TotalAmount FLOAT NULL,
  PRIMARY KEY(idOrder_2),
  INDEX Order_2_FKIndex1(User_2_idUser_2),
  FOREIGN KEY(User_2_idUser_2)
    REFERENCES User_2(idUser_2)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);


CREATE TABLE Supplier (
  idSupplier INTEGER IDENTITY NOT NULL,
  Region_idRegion INTEGER NOT NULL,
  CompanyName VARCHAR(225) NULL,
  ContactName VARCHAR(225) NULL,
  OfficeAddress VARCHAR(225) NULL,
  EmailAddress VARCHAR(225) NULL,
  Login_Password VARCHAR(225) NULL,
  Phone VARCHAR(20) NULL,
  City VARCHAR(225) NULL,
  PRIMARY KEY(idSupplier),
  INDEX Supplier_FKIndex1(Region_idRegion),
  FOREIGN KEY(Region_idRegion)
    REFERENCES Region(idRegion)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
);

CREATE TABLE Shipment (
  idShipment INTEGER IDENTITY NOT NULL ,
  Order_2_idOrder_2 INTEGER NOT NULL,
  Driver_idDriver INTEGER NOT NULL,
  DispatchDate DATE NULL,
  DeliveryDate DATE NULL,
  PRIMARY KEY(idShipment),
  INDEX Shipment_FKIndex1(Driver_idDriver),
  INDEX Shipment_FKIndex2(Order_2_idOrder_2),
  FOREIGN KEY(Driver_idDriver)
    REFERENCES Driver(idDriver)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Order_2_idOrder_2)
    REFERENCES Order_2(idOrder_2)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Category (
  idCategory INTEGER IDENTITY NOT NULL,
  Name VARCHAR(255) NULL,
  PRIMARY KEY(idCategory),
);

CREATE TABLE Stock (
  idStock INTEGER IDENTITY NOT NULL,
  Supplier_idSupplier INTEGER NOT NULL,
  Category_idCategory INTEGER NOT NULL,
  ProductName VARCHAR(225) NULL,
  ItemsLeft INTEGER NULL,
  ItemsSold INTEGER NULL,
  Price INTEGER NULL,
  Sale_Discount FLOAT NULL,
  Picture VARCHAR(225) Null,
  PRIMARY KEY(idStock),
  INDEX Stock_FKIndex1(Supplier_idSupplier),
  INDEX Stock_FKIndex2(Category_idCategory),
  FOREIGN KEY(Supplier_idSupplier)
    REFERENCES Supplier(idSupplier)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Category_idCategory)
    REFERENCES Category(idCategory)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,	
);

CREATE TABLE Review (
  idReview INTEGER IDENTITY NOT NULL,
  User_2_idUser_2 INTEGER NOT NULL,
  Stock_idStock INTEGER NOT NULL,
  Feedback VARCHAR(225) NULL,
  Rating INTEGER NULL,
  PRIMARY KEY(idReview),
  INDEX Review_FKIndex1(Stock_idStock),
  INDEX Review_FKIndex2(User_2_idUser_2),
  FOREIGN KEY(Stock_idStock)
    REFERENCES Stock(idStock)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(User_2_idUser_2)
    REFERENCES User_2(idUser_2)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE [Shopping Cart] (
  Order_2_idOrder_2 INTEGER NOT NULL,
  Stock_idStock INTEGER NOT NULL,
  Quantity INTEGER NULL,
  PRIMARY KEY(Order_2_idOrder_2, Stock_idStock),
  INDEX Order_2_has_Stock_FKIndex1(Order_2_idOrder_2),
  INDEX Order_2_has_Stock_FKIndex2(Stock_idStock),
  FOREIGN KEY(Order_2_idOrder_2)
    REFERENCES Order_2(idOrder_2)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Stock_idStock)
    REFERENCES Stock(idStock)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

Create procedure signup @region varchar(225), @fname varchar(225), @lname varchar(225), @phone varchar(20), @pass varchar(225), @email varchar(225), @Sadd varchar(225), @Badd varchar(225), @city varchar(225), @country varchar(225)
AS 
insert into User_2(Region_idRegion,FirstName, LastName, PhoneNumber, Login_Password, EmailAddress, ShippingAddress, BillingAddress, CreditCardNumber, City, Country)
values ((select idRegion from Region where [Name] = @region),@fname, @lname, @phone, @pass, @email, @Sadd, @Badd, null ,@City, @Country)

Create procedure Update_customer @fname varchar(225), @lname varchar(225), @email varchar(225), 
@phone varchar(20), @id int, @city varchar(225), @country varchar(225), @region varchar(225), @Badd varchar(225),
@Sadd varchar(225)
as
update User_2
set FirstName=@fname, LastName=@lname, EmailAddress=@email,PhoneNumber=@phone, City=@city,Country=@country,
Region_idRegion=(select idRegion from Region where [Name]=@region),BillingAddress=@Badd,ShippingAddress=@Sadd
where idUser_2=@id
