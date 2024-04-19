CREATE TABLE [dbo].[Transactions]
(
    [ID] BIGINT IDENTITY(1,1) NOT NULL,
    [TransactionID] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Accounts_TransactionID DEFAULT (NEWID()),
    [AccountID] UNIQUEIDENTIFIER NOT NULL,
    [Origin_Account_ID] UNIQUEIDENTIFIER NOT NULL,
    [Destination_Account_ID] UNIQUEIDENTIFIER NOT NULL,
    [Amount] INT NOT NULL,
    [TransactionStatus] NVARCHAR(15) NOT NULL,
    [CreatedDTM] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [UpdatedDTM] DATETIME NULL,
    [IsDeleted]  BIT NOT NULL CONSTRAINT DF_Transaction_IsDeleted DEFAULT (0),
    [DeletedBy] BIGINT NULL,
    [DeletedDTM] DATETIME2 NULL,
    [RowVersion] ROWVERSION,
    [ModifiedBy] NVARCHAR(255),
    CONSTRAINT PK_Transaction_ID PRIMARY KEY CLUSTERED ([ID]),
    CONSTRAINT FK_OriginAccount_AccountID FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Accounts] ([ID]),
    CONSTRAINT FK_Destination_AccountID FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Accounts] ([ID])
   
)
 
GO

CREATE NONCLUSTERED INDEX IX_Account_AccountID
    ON [dbo].[Accounts] ([AccountID])
GO

CREATE UNIQUE INDEX UQ_UserID
    ON [dbo].[Accounts] ([UserID])
GO

