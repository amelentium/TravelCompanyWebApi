USE [TravelCompanyDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[computeFinalPrice](@PassId int, @TourId int, @Count int)
RETURNS float
AS
BEGIN
DECLARE @discount decimal(9)
SELECT @discount = (SUM(d.Value) * 0.01)
    FROM Discounts AS d
    INNER JOIN PassDiscounts ON PassDiscounts.DiscountId = d.Id
    WHERE PassDiscounts.PassId = @PassId
    IF (@discount IS NULL)
        SET @discount = 0;

DECLARE @total int
SELECT @total = (t.Price * @Count)
    FROM Tours AS t
    WHERE t.Id = @TourId
    IF (@total IS NULL)
            SET @total = 0;

RETURN ((1 - @discount) * @total)
END
GO