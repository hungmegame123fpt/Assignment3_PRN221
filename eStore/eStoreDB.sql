-- Create the database
CREATE DATABASE eStoreDB;
GO

USE eStoreDB;
GO

-- Create Categories table
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY,
    CategoryName VARCHAR(40) NOT NULL,
    Description NVARCHAR(MAX) NULL
);
GO

-- Create Member table
CREATE TABLE Member (
    MemberId INT PRIMARY KEY,
    Email VARCHAR(100) NOT NULL,
    CompanyName VARCHAR(40) NOT NULL,
    City VARCHAR(15) NOT NULL,
    Country VARCHAR(15) NOT NULL,
    Password VARCHAR(30) NOT NULL
);
GO

-- Create Product table
CREATE TABLE Product (
    ProductId INT PRIMARY KEY,
    CategoryId INT NOT NULL,
    ProductName VARCHAR(40) NOT NULL,
    Weight VARCHAR(20) NOT NULL,
    UnitPrice MONEY NOT NULL,
    UnitsInStock INT NOT NULL,
    CONSTRAINT FK_Product_Categories FOREIGN KEY (CategoryId)
        REFERENCES Categories (CategoryId)
);
GO

-- Create Order table
CREATE TABLE [Order] (
    OrderId INT PRIMARY KEY,
    MemberId INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    RequiredDate DATETIME NOT NULL,
    ShippedDate DATETIME NULL,
    Freight MONEY NULL,
    CONSTRAINT FK_Order_Member FOREIGN KEY (MemberId)
        REFERENCES Member (MemberId)
);
GO

-- Create OrderDetail table
CREATE TABLE OrderDetail (
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    UnitPrice MONEY NOT NULL,
    Quantity INT NOT NULL,
    Discount FLOAT NOT NULL,
    CONSTRAINT PK_OrderDetail PRIMARY KEY (OrderId, ProductId),
    CONSTRAINT FK_OrderDetail_Order FOREIGN KEY (OrderId)
        REFERENCES [Order] (OrderId),
    CONSTRAINT FK_OrderDetail_Product FOREIGN KEY (ProductId)
        REFERENCES Product (ProductId)
);
GO

-- Create indexes to improve performance
CREATE INDEX IX_Member_Email ON Member(Email);
CREATE INDEX IX_Product_CategoryId ON Product(CategoryId);
CREATE INDEX IX_Order_MemberId ON [Order](MemberId);
CREATE INDEX IX_OrderDetail_ProductId ON OrderDetail(ProductId);
GO

-- Sample INSERT statements to populate the database with test data
INSERT INTO Categories (CategoryId, CategoryName, Description)
VALUES 
    (1, 'Electronics', 'Electronic devices and accessories'),
    (2, 'Clothing', 'Apparel and fashion items'),
    (3, 'Books', 'Physical and digital books');
GO

INSERT INTO Member (MemberId, Email, CompanyName, City, Country, Password)
VALUES 
    (1, 'john@example.com', 'ABC Corp', 'New York', 'USA', 'password123'),
    (2, 'jane@example.com', 'XYZ Ltd', 'London', 'UK', 'securepass'),
    (3, 'bob@example.com', 'Tech Solutions', 'Tokyo', 'Japan', 'bobpass123');
GO

INSERT INTO Product (ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitsInStock)
VALUES 
    (1, 1, 'Smartphone', '0.2 kg', 699.99, 50),
    (2, 1, 'Laptop', '2.5 kg', 1299.99, 25),
    (3, 2, 'T-Shirt', '0.1 kg', 19.99, 100),
    (4, 3, 'Programming Guide', '0.5 kg', 39.99, 75);
GO

INSERT INTO [Order] (OrderId, MemberId, OrderDate, RequiredDate, ShippedDate, Freight)
VALUES 
    (1, 1, '2025-03-25 10:00:00', '2025-03-30 10:00:00', NULL, 15.00),
    (2, 2, '2025-03-26 14:30:00', '2025-04-01 14:30:00', '2025-03-28 09:15:00', 20.50);
GO

INSERT INTO OrderDetail (OrderId, ProductId, UnitPrice, Quantity, Discount)
VALUES 
    (1, 1, 699.99, 1, 0.0),
    (1, 3, 19.99, 2, 0.05),
    (2, 2, 1299.99, 1, 0.10),
    (2, 4, 39.99, 1, 0.0);
GO