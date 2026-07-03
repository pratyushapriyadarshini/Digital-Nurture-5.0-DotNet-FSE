USE CognizantDB;
GO

CREATE PROCEDURE GetProductsByCategory
    @Category VARCHAR(50)
AS
BEGIN
    SELECT *
    FROM Products
    WHERE Category = @Category;
END;
GO

EXEC GetProductsByCategory 'Electronics';