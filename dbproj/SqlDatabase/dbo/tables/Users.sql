GO
CREATE TABLE [dbo].[Users]
(
    [ID] BIGINT IDENTITY(1,1) NOT NULL,
    [UserID] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Users_UserID DEFAULT (NEWID()),
    [UserName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL,
    [PasswordHash] NVARCHAR(255) NULL,
    [RefreshToken] NVARCHAR(MAX) NULL,
    [RefreshTokenExpiryTime] DATETIME NULL,
    [ResetToken] NVARCHAR(MAX) NULL,
    [ResetDTMExpiry] DATETIME NULL,
    [UpdatedDTM] DATETIME NULL,
    [CreatedDTM] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [IsDeleted]  BIT NOT NULL CONSTRAINT DF_Users_IsDeleted DEFAULT (0),
    [DeletedBy] BIGINT NULL,
    [DeletedDTM] DATETIME2 NULL,
    [RowVersion] ROWVERSION,
    CONSTRAINT PK_Users_ID PRIMARY KEY CLUSTERED ([ID])
);
GO

CREATE NONCLUSTERED INDEX IX_Users_UserID
    ON [dbo].[Users] ([UserID])
GO

CREATE UNIQUE INDEX UQ_Users_UserName
    ON [dbo].[Users] ([UserName])
GO

CREATE UNIQUE INDEX UQ_Users_Email
    ON [dbo].[Users] ([Email])
GO

