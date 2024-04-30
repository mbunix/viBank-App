BEGIN TRANSACTION;

SET IDENTITY_INSERT [dbo].[ATMs] ON;

WITH AVAILABLEATMS AS (
    SELECT
    *
    FROM
    (VALUES (1,
            '758bb331-e613-46bb-82c4-9191ec2ee826',
            'TorontoCA',
            2000000.00,
            '858bb331-e613-46bb-82c4-9191ec2f826',
            1,
            GETDATE(),
            0)
        ) AS VAL (ID,
                ATMID,
                Location,
                AvailableBalance,
                TransactionID,
                IsActive,
                CreatedDTM,
                IsDeleted)
) MERGE [dbo].[ATMs] AS TARGET
USING AVAILABLEATMS AS SOURCE
ON SOURCE.ID = TARGET.ID
WHEN NOT MATCHED BY TARGET THEN
    INSERT (
                [ATMID]
                [Location]
                [AvailableBalance]
                [TransactionID]
                [IsActive]
                [CreatedDTM]
                [IsDeleted]
    )
    VALUES (
    SOURCE.[ID],
    SOURCE.[ATMID],
    SOURCE.[Location],
    SOURCE.[AvailableBalance],
    SOURCE.[TransactionID]
    SOURCE.[IsActive],
    SOURCE.[CreatedDTM],
    SOURCE.[ISDeleted]
    )
WHEN MATCHED THEN
    UPDATE
    SET TARGET.[ATMID] = SOURCE.[ATMID],
    TARGET.[Location] = SOURCE.[Location],
    TARGET.[AvailableBalance] = SOURCE.[AvailableBalance],
    TARGET.[TransactionID] = SOURCE.[TransactionID],
    TARGET.[IsActive] = SOURCE.[IsActive],
    TARGET.[CreatedDTM] = SOURCE.[CreatedDTM],
    TARGET.[IsDeleted] = SOURCE.[IsDeleted];
;
SET IDENTITY_INSERT [dbo].[ATMs] OFF;

COMMIT TRANSACTION;
