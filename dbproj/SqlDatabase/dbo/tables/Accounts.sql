CREATE TABLE [dbo].[Accounts]
(
    [ID] BIGINT IDENTITY(1,1) NOT NULL,
    [AccountID] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_UserID DEFAULT (NEWID()),
    [AccountNumber] NVARCHAR(10) NOT NULL,
    [AccountType] NVARCHAR(255) NOT NULL,
    [AccountBalance] DECIMAL(10,2) NULL,
    [UpdatedDTM] DATETIME NULL,
    [DeletedBy] BIGINT NULL,
    [DeletedDTM] DATETIME2 NULL,
    [RowVersion] ROWVERSION,
    [ModifiedBy] NVARCHAR(255),
    [UserID] BIGINT NULL,
    CONSTRAINT PK_Account_ID PRIMARY KEY CLUSTERED ([ID]),
    CONSTRAINT FK_Accounnt_UserID FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID]),

)

GO