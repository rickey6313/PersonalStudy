USE [ERP]
GO

/****** Object:  StoredProcedure [dbo].[SELECT_USERINFO]    Script Date: 2021-06-15 ���� 9:59:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SELECT_USERINFO]
(
	@P_id varchar(50),
	@P_name varchar(50),
	@P_part int,
	@P_rank int	
)
AS
BEGIN
	Select 
		A.uniqueId,
		A.userId as '���̵�',
		A.userName as '�̸�',
		P.partName as '�μ�',
		auth.authorityName as '����',
		Rankinfo.rankName '����',
		email as '�̸���',
		phoneNumber1 as '��ȭ��ȣ1',
		phoneNumber2 as '��ȭ��ȣ2',
		address1 as '�ּ�1',
		address2 as '�ּ�2',
		A.RegisterDate as '�����'
	From UserInfo A 
		Inner join PartInfo P On A.part = p.partId
		Inner join AuthorityInfo auth On A.authorityGrade = auth.authorityId
		Inner join RankInfo On A.rankGrade = RankInfo.rankId

	where 
	((@P_id is null OR @P_id = '') OR A.userId = @P_id)
	And ((@P_name is null OR @P_name = '') OR A.userName = @P_name)
	And ((@P_part is null OR @P_part = -1) OR A.part = @P_part)
	And ((@P_rank is null OR @P_rank = -1) OR A.rankGrade = @P_rank)
END
GO


