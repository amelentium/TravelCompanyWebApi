USE [TravelCompanyDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[computeFullPrice](@TourId int, @Count int)
RETURNS float
AS
BEGIN

DECLARE @total int
SELECT @total = (t.Price * @Count)
    FROM Tours AS t
    WHERE t.Id = @TourId
    IF (@total IS NULL)
            SET @total = 0;

RETURN @total
END
GO