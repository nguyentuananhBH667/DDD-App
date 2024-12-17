CREATE DATABASE GLOCERY
GO
USE GLOCERY
GO
CREATE TABLE Category (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL
);

CREATE TABLE Figure (
    FigureID INT PRIMARY KEY IDENTITY(1,1),
    FigureCode NVARCHAR(50) NOT NULL,
    FigureName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    InventoryQuantity INT NOT NULL,
    FigureImage NVARCHAR(MAX),
    CategoryID INT,
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
);

CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeCode NVARCHAR(50) NOT NULL,
    EmployeeName NVARCHAR(100) NOT NULL,
    Position NVARCHAR(50),
    AuthorityLevel NVARCHAR(50),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
	PasswordChanged Bit Default 0
);
ALTER TABLE Employee ADD PasswordChanged BIT NOT NULL
Insert into [dbo].[Employee]
Values ('emp11', 'Nguyen Van A' ,'Manager' ,'Admin', 'admin1','123456', 1);

Insert into [dbo].[Employee]
Values ('emp2', 'Nguyen Van B' ,'Warehouse Manager' ,'Warehouse manager', 'warehouse manager1','123456', 1),
       ('emp3', 'Nguyen Van C' ,'Sale' ,'Sale', 'sale1','123456', 1);

Select * from [dbo].[Sale]

Update Employee set Password = '6677038' where EmployeeID = 3
Update Employee set Position = 'Admin' where EmployeeID = 1

Delete from Employee Where EmployeeCode = 'emp2'

Select EmployeeCode As Ma_NV from Employee 

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerCode NVARCHAR(50) NOT NULL,
    CustomerName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(255)
);

CREATE TABLE Sale (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    SaleDate DATETIME NOT NULL,
    EmployeeID INT,
    CustomerID INT,
    TotalAmount DECIMAL(10, 2),
    Profit DECIMAL(10, 2),
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE SaleDetail (
    SaleDetailID INT PRIMARY KEY IDENTITY(1,1),
    SaleID INT,
    FigureID INT,
    QuantitySold INT NOT NULL,
    FOREIGN KEY (SaleID) REFERENCES Sale(SaleID),
    FOREIGN KEY (FigureID) REFERENCES Figure(FigureID)
);

CREATE TABLE Import (
    ImportID INT PRIMARY KEY IDENTITY(1,1),
    ImportDate DATETIME NOT NULL,
    EmployeeID INT,
    TotalQuantity INT,
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
);
CREATE TABLE ImportDetail (
    ImportDetailID INT PRIMARY KEY IDENTITY(1,1),
    ImportID INT,
    FigureID INT,
    QuantityImported INT NOT NULL,
    ImportCost DECIMAL(10, 2),
    FOREIGN KEY (ImportID) REFERENCES Import(ImportID),
    FOREIGN KEY (FigureID) REFERENCES Figure(FigureID)
);

INSERT INTO Category (CategoryName) VALUES 
('Historical Figures'),
('Mythological Figures'),
('Fantasy Figures'),
('Superheroes'),
('Villains'),
('Animals'),
('Robots'),
('Celebrities'),
('Athletes'),
('Musicians'),
('Political Figures');

Select * from Category 

INSERT INTO Figure (FigureCode, FigureName, Price, InventoryQuantity, FigureImage, CategoryID)
VALUES
('FIG001', 'Superman', 29.99, 100, 'Superman.jpg', 1),
('FIG002', 'Batman', 49.99, 50, 'Batman.jpg', 1),
('FIG003', 'Iron Man', 39.99, 150, 'Iron Man.webp', 2),
('FIG004', 'Wonder Woman', 34.99, 200, 'Wonder Woman.webp', 1),
('FIG005', 'Hulk', 24.99, 120, 'Hulk.webp', 3);

Select * from Figure

update Figure set FigureName = 'Black Window' where FigureID = 5 ;
delete from Figure
DBCC CHECKIDENT ('Figure', RESEED, 0);

SELECT 
    s.SaleDate,
    e.EmployeeName,
    c.CustomerName
FROM 
    Sale s
JOIN 
    Employee e ON s.EmployeeID = e.EmployeeID
JOIN 
    Customer c ON s.CustomerID = c.CustomerID
ORDER BY 
    s.SaleDate DESC;

INSERT INTO Customer (CustomerCode, CustomerName, PhoneNumber, Address)
VALUES ('004', 'Sunday', '0987456321', 'maver');

SELECT * FROM Customer

-- Insert into Sale (make sure EmployeeID and CustomerID exist)
INSERT INTO Sale (SaleDate, EmployeeID, CustomerID, TotalAmount, Profit)
VALUES ('2024-12-15', 5, 003, 120.00, 200.00);

-- Insert into SaleDetail (make sure SaleID and SmartphoneID exist)
INSERT INTO SaleDetail (SaleID, FigureID, QuantitySold)
VALUES (3, 1, 2);  -- SaleID = 1, SmartphoneID = 1, 2 items sold

SELECT * FROM Sale

ALTER TABLE Sale
ADD TotalAmount DECIMAL(10, 2),
    Profit DECIMAL(10, 2);

-- Check if EmployeeID = 5 exists in the Employee table
SELECT * FROM Employee WHERE EmployeeID = 5;


