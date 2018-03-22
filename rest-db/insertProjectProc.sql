USE [BD16185]
GO

/****** Object:  StoredProcedure [BD16185].[InsertProject]    Script Date: 21/03/2018 11:34:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [BD16185].[InsertProject]
@Name VARCHAR (30),
@Description VARCHAR (30),
@Year INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Project WHERE Name = @Name)
	BEGIN
		INSERT INTO Project VALUES (@Name, @Description, @Year)
	END
END
GO


