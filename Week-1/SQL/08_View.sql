USE CognizantDB;
GO

CREATE VIEW ElectronicsProducts
AS
SELECT
    ProductID,
    ProductName,
    Price
FROM Products
WHERE Category = 'Electronics';
GO

SELECT * FROM ElectronicsProducts;