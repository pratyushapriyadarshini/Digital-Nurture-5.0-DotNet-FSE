USE CognizantDB;
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

INSERT INTO Products VALUES
(1,'Laptop A','Electronics',80000),
(2,'Laptop B','Electronics',90000),
(3,'Mouse','Electronics',1500),
(4,'Keyboard','Electronics',2500),
(5,'Phone A','Electronics',60000),
(6,'Shirt A','Clothing',1200),
(7,'Shirt B','Clothing',1500),
(8,'Jacket','Clothing',3500),
(9,'Jeans','Clothing',2500),
(10,'Shoes','Clothing',3500),
(11,'Rice','Grocery',60),
(12,'Oil','Grocery',180),
(13,'Sugar','Grocery',50),
(14,'Tea','Grocery',250),
(15,'Coffee','Grocery',450);