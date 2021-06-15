
--Alter PROCEDURE SELECT_RANKINFO
--(
--	@P_id int,
--	@P_name varchar(50)
--)
--AS
--BEGIN
--	Select
--		rankid,
--		rankId as '번호',
--		rankName as '직급'
--	From RankInfo
--	where 
--	((@P_id is null OR @P_id = '-1') OR rankId = @P_id) And
--	((@P_name is null OR @P_name = '') OR rankName = @P_name)	
--END
--GO

--Declare @P_id int, @P_name varchar(50)
--Set @P_id = null
--Set @P_name = ''

--BEGIN
--	Select
--		rankid,
--		rankId as '번호',
--		rankName as '직급'
--	From RankInfo
--	where 
--	((@P_id is null) OR rankId = @P_id) And
--	((@P_name is null OR @P_name = '') OR rankName = @P_name)	
--END

Declare @P_id int, @P_name varchar(50)
Set @P_id = 1
Set @P_name = ''

BEGIN
	Select
		rankid,
		rankId as '번호',
		rankName as '직급'
	From RankInfo
	where 
	((@P_id is null OR @P_id = '-1') OR rankId = @P_id) And
	((@P_name is null OR @P_name = '') OR rankName = @P_name)	
END