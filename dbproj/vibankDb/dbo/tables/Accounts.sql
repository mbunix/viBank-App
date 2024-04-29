CREATE TABLE [dbo].[Accounts]
(
    [ID] BIGINT IDENTITY(1,1) NOT NULL,
    [AccountID] UNIQUEIDENTIFIER NOT NULL,
    [AccountNumber] NVARCHAR(50) NOT NULL PRIMARY KEY,
    [AccountType] NVARCHAR(255) NOT NULL,
    [AccountBalance] DECIMAL(10,2) NULL,
    [UpdatedDTM] DATETIME NULL,
    [DeletedDTM] DATETIME2 NULL,
    [RowVersion] ROWVERSION,
    [UserID] BIGINT NOT NULL, -- Modify to NOT NULL,
    CONSTRAINT FK_Account_UserID FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID]) -- Rename the foreign key constraint
)
