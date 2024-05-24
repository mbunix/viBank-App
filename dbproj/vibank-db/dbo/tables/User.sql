CREATE TABLE [dbo].[User] (
    [ID]                     BIGINT           IDENTITY (1, 1) NOT NULL,
    [UserModelID]            UNIQUEIDENTIFIER NOT NULL,
    [UserName]               NVARCHAR (MAX)   NOT NULL,
    [PasswordHash]           NVARCHAR (MAX)   NOT NULL,
    [Email]                  NVARCHAR (MAX)   NULL,
    [RefreshToken]           NVARCHAR (MAX)   NULL,
    [ResetToken]             NVARCHAR (MAX)   NULL,
    [RefreshTokenExpiryTime] DATETIME2 (7)    NULL,
    [ResetDTMExpiry]         DATETIME2 (7)    NULL,
    [ActivationToken]        NVARCHAR (MAX)   NULL,
    [ActivationDate]         DATETIME2 (7)    NULL,
    [UpdatedDTM]             DATETIME2 (7)    NULL,
    [RoleID]                 BIGINT           NOT NULL,
    [AccountID]              BIGINT           NULL,
    [CreatedDTM]             DATETIME2 (7)    NOT NULL,
    [IsDeleted]              BIT              NOT NULL,
    [DeletedBy]              BIGINT           NULL,
    [DeletedDTM]             DATETIME2 (7)    NULL,
    [RowVersion]             ROWVERSION       NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_User_account_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[account] ([ID])
);
GO


ALTER TABLE [dbo].[User]
    ADD CONSTRAINT [FK_User_account_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[account] ([ID]);
GO


CREATE NONCLUSTERED INDEX [IX_User_AccountID]
    ON [dbo].[User]([AccountID] ASC);
GO

