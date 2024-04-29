CREATE TABLE [dbo].[Transactions]
(
 [ID] BIGINT IDENTITY(1,1) NOT NULL,
    [TransactionID] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Accounts_TransactionID DEFAULT (NEWID()),
    [AccountID] UNIQUEIDENTIFIER NOT NULL,
    [AccountNumber] NVARCHAR(50) NOT NULL,
    [Origin_Account_Number] NVARCHAR(50) NOT NULL,
    [Destination_Account_Number] NVARCHAR(50) NOT NULL,
    [Amount] INT NOT NULL,
    [TransactionStatus] NVARCHAR(15) NOT NULL,
    [CreatedDTM] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [UpdatedDTM] DATETIME NULL,
    [IsDeleted] BIT NOT NULL CONSTRAINT DF_Transaction_IsDeleted DEFAULT (0),
    [DeletedBy] BIGINT NULL,
    [DeletedDTM] DATETIME2 NULL,
    [RowVersion] ROWVERSION,
    [ModifiedBy] NVARCHAR(255),
    CONSTRAINT PK_Transaction_ID PRIMARY KEY CLUSTERED ([ID]),
    -- Foreign key for Origin_Account_Number referencing AccountNumber in Accounts table
    CONSTRAINT FK_Transactions_OriginAccount FOREIGN KEY ([Origin_Account_Number])
        REFERENCES [dbo].[Accounts] ([AccountNumber]),
    -- Foreign key for Destination_Account_Number referencing AccountNumber in Accounts table
    CONSTRAINT FK_Transactions_DestinationAccount FOREIGN KEY ([Destination_Account_Number])
        REFERENCES [dbo].[Accounts] ([AccountNumber])
   
)
 
GO

CREATE NONCLUSTERED INDEX IX_Account_AccountNumber
    ON [dbo].[Accounts] ([AccountNumber])
GO

CREATE UNIQUE INDEX UQ_UserID
    ON [dbo].[Accounts] ([UserID])
GO

