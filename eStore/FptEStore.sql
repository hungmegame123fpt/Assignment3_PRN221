CREATE DATABASE FptEStore;
USE FptEStore;

CREATE TABLE Member (
    MemberId INT PRIMARY KEY,
    Email VARCHAR(100) NOT NULL,
    CompanyName VARCHAR(40) NOT NULL,
    City VARCHAR(15) NOT NULL,
    Country VARCHAR(15) NOT NULL,
    Password VARCHAR(30) NOT NULL
);

CREATE TABLE Orders (
    OrderId INT PRIMARY KEY,
    MemberId INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    RequiredDate DATETIME NULL,
    ShippedDate DATETIME NULL,
    Freight MONEY NULL,
    FOREIGN KEY (MemberId) REFERENCES Member(MemberId)
);

CREATE TABLE Products (
    ProductId INT PRIMARY KEY,
    CategoryId INT NULL,
    ProductName VARCHAR(40) NULL,
    Weight VARCHAR(20) NULL,
    UnitPrice MONEY NULL,
    UnitsInStock INT NOT NULL
);

CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY,
    CategoryName VARCHAR(40) NULL,
    Description NVARCHAR(MAX) NULL
);

ALTER TABLE Products
ADD CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId);

CREATE TABLE OrderDetail (
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    UnitPrice MONEY NOT NULL,
    Quantity INT NOT NULL,
    Discount FLOAT NOT NULL,
    PRIMARY KEY (OrderId, ProductId),
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
