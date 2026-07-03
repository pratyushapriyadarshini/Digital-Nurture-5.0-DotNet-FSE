USE CognizantDB;
GO

CREATE FUNCTION dbo.GetDiscountPrice
(
    @Price DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Price * 0.90;
END;
GO

SELECT
    ProductName,
    Price,
    dbo.GetDiscountPrice(Price) AS DiscountPrice
FROM Products;