CREATE TABLE [dbo].[User] (
    [ID]                     BIGINT           IDENTITY (1, 1) NOT NULL,
    [UserID]                 UNIQUEIDENTIFIER NOT NULL,
    [UserName]               NVARCHAR (MAX)   NULL,
    [PasswordHash]           NVARCHAR (MAX)   NULL,
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
    [CreatedDTM]             DATETIME2 (7)    NULL,
    [IsDeleted]              BIT              NOT NULL,
    [DeletedBy]              BIGINT           NULL,
    [DeletedDTM]             DATETIME2 (7)    NULL,
    [RowVersion]             ROWVERSION       NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_User_account_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[account] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_User_AccountID]
    ON [dbo].[User]([AccountID] ASC);

