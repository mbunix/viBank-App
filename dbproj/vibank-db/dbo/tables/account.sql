CREATE TABLE [dbo].[account] (
    [ID]             BIGINT           IDENTITY (1, 1) NOT NULL,
    [AccountID]      UNIQUEIDENTIFIER NOT NULL,
    [AccountNumber]  BIGINT           NULL,
    [AccountType]    INT              NOT NULL,
    [AccountBalance] FLOAT (53)       NOT NULL,
    [UserID]         UNIQUEIDENTIFIER NOT NULL,
    [UserEmail]      NVARCHAR (MAX)   NULL,
    [CreatedDTM]     DATETIME2 (7)    NULL,
    [UpdatedDTM]     DATETIME2 (7)    NULL
);
GO

ALTER TABLE [dbo].[account]
    ADD CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED ([ID] ASC);
GO

