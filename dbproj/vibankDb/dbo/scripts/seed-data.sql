
-- /* seed available ATMS */

SET IDENTITY_INSERT [dbo].[ATMs] ON;
;
WITH availableATMs AS (
    SELECT *
    FROM (VALUES 
        (1, '758bb331-e613-46bb-82c4-9191ec2ee826', 'TorontoCA', 2000000.00, 1, GETDATE(), 0)
    ) AS val (ID, ATMID, Location, AvailableBalance, isActive, CreatedDTM, isDeleted)
)
MERGE [dbo].[ATMs] AS Target
USING availableATMs AS Source
ON Source.ID = Target.ID
WHEN NOT MATCHED BY Target THEN
    INSERT ([ID], [ATMID], [Location], [AvailableBalance], [isActive], [CreatedDTM], [isDeleted])
    VALUES (Source.[ID], Source.[ATMID], Source.[Location], Source.[AvailableBalance], Source.[isActive], Source.[CreatedDTM], Source.[isDeleted])
WHEN MATCHED THEN
    UPDATE
    SET Target.[ATMID] = Source.[ATMID],
        Target.[Location] = Source.[Location],
        Target.[AvailableBalance] = Source.[AvailableBalance],
        Target.[isActive] = Source.[isActive],
        Target.[CreatedDTM] = Source.[CreatedDTM],
        Target.[isDeleted] = Source.[isDeleted];

SET IDENTITY_INSERT [dbo].[ATMs] OFF;


-- /* SEED  */