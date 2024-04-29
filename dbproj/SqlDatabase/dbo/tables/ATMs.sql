﻿CREATE TABLE [dbo].[ATMs]
(
    [ID] BIGINT IDENTITY(1,1) NOT NULL,
    [ATMID] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_ATM_ATMID DEFAULT (NEWID()),
    [Location] NVARCHAR(255) NOT NULL,
    [TransactionID] UNIQUEIDENTIFIER  NULL,
    [AvailableBalance] DECIMAL(10,2) NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT (1),
    [CreatedDTM] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [UpdatedDTM] DATETIME NULL,
    [IsDeleted]  BIT NOT NULL CONSTRAINT DF_ATMs_IsDeleted DEFAULT (0),
    [DeletedBy] BIGINT NULL,
    [DeletedDTM] DATETIME2 NULL,
    [RowVersion] ROWVERSION,
    [ModifiedBy] NVARCHAR(255),
  
    CONSTRAINT PK_ATMID PRIMARY KEY CLUSTERED ([ID]),
    CONSTRAINT FK_Transaction_TransactionID FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[Transactions] ([TransactionID]),
   
)
GO

CREATE NONCLUSTERED INDEX IX_ATMs_ATMID
    ON [dbo].[ATMs] ([ATMID])
GO

CREATE UNIQUE INDEX UQ_Transaction
    ON [dbo].[Transactions] ([TransactionID])
GO

