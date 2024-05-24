CREATE TABLE [dbo].[account] (
    [ID]             BIGINT           IDENTITY (1, 1) NOT NULL,
    [AccountID]      UNIQUEIDENTIFIER NOT NULL,
    [AccountNumber]  BIGINT           NULL,
    [AccountType]    INT              NOT NULL,
    [AccountBalance] FLOAT (53)       NOT NULL,
    [UserModelID]    UNIQUEIDENTIFIER NOT NULL,
    [UserEmail]      NVARCHAR (MAX)   NOT NULL,
    [CreatedDTM]     DATETIME2 (7)    NOT NULL,
    [UpdatedDTM]     DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO

