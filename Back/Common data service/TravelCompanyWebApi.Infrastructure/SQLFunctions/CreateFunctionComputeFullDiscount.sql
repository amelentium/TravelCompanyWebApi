USE [TravelCompanyDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[computeFullDiscount](@PassId int)
RETURNS float
AS
BEGIN

DECLARE @discount float
SELECT @discount = SUM(d.Value)
    FROM Discounts AS d
    INNER JOIN PassDiscounts ON PassDiscounts.DiscountId = d.Id
    WHERE PassDiscounts.PassId = @PassId
    IF (@discount IS NULL)
        SET @discount = 0;

RETURN @discount
END
GO