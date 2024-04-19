
/* seed available ATMS */

SET IDENTITY_INSERT [dbo].[ATMs] ON;
with availableATMs as (
 SELECT *
 FROM (VALUES( 1, '758bb331-e613-46bb-82c4-9191ec2ee826', 'TorontoCA',2000000.00,1,GETDATE(),0) val (ID,ATMID,Location,AvailableBalance,isActive,createdDTM,isDeleted))
 MERGE [dbo].[ATMs] AS Target
 USING avaiableATMs AS Source
 ON Source.ID = Target.ID
 WHEN NOT MATCHED BY Target THEN
 INSERT([ID],[ATMID],[location],[AvailableBalance],[isActive],[CreatedDTM],[UpdatedDTM],[isDeleted],[DeletedBy],[DeletedDTM],[RowVersion],[ModifiedBy])
 VALUES(Source.[ID],Source.[ATMID],Source.[Location],Source.[AvailableBalance],Source.[isActive],Source.[CreatedDTM],Source.[isDeleted])
 WHEN MATCHED THEN
 UPDATE
 SET Target.[ATMID] = Source.[ATMID],
	 Target.[Location] =Source.[Location],
	 Target.[AvailableBalance]    = Source.[AvailableBalance],
	 Target.[isActive]    = Source.[isActive],
	 Target.[CreatedDTM]    = Source.[CreatedDTM],
	 Target.[isDeleted] = Source.[isDeleted]
	 ;
SET IDENTITY_INSERT [dbo].[ATMs] OFF;


/* SEED  */