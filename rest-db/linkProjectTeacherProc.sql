USE [BD16185]
GO
/****** Object:  StoredProcedure [BD16185].[linkProjectTeacher]    Script Date: 22/03/2018 11:18:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create procedure [BD16185].[linkProjectTeacher]
	-- Add the parameters for the stored procedure here
	@ProjectId int,
	@TeacherId int
as
begin
	DECLARE @ErrorMessage varchar(2047);

	if ((select count(Id) from ProjectTeacher where ProjectId = @ProjectId) < 2)
		if exists (select * from Teacher where Id = @TeacherId)
			if exists (select * from Project where id = @ProjectId)
				insert into ProjectTeacher values (@ProjectId, @TeacherId);
			else
				SET @ErrorMessage = 'Project does not exist.';
		else
			SET @ErrorMessage = 'Teacher does not exist.';
	else
		SET @ErrorMessage = 'Too many teachers on this project.';

	IF @ErrorMessage IS NOT NULL
    RAISERROR(@ErrorMessage, 16, 1);
end