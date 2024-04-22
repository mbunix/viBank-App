BEGIN TRY

BEGIN TRAN;

-- CreateTable
CREATE TABLE [dbo].[__EFMigrationsHistory] (
    [MigrationId] NVARCHAR(150) NOT NULL,
    [ProductVersion] NVARCHAR(32) NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId])
);

-- CreateTable
CREATE TABLE [dbo].[account] (
    [ID] BIGINT NOT NULL IDENTITY(1,1),
    [AccountID] UNIQUEIDENTIFIER NOT NULL,
    [AccountNumber] NVARCHAR(max),
    [AccountType] INT NOT NULL,
    [AccountBalance] FLOAT(53) NOT NULL,
    [UserID] BIGINT NOT NULL,
    [UserEmail] NVARCHAR(max) NOT NULL,
    [CreatedDTM] DATETIME2 NOT NULL,
    [UpdatedDTM] DATETIME2 NOT NULL,
    CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED ([ID])
);

-- CreateTable
CREATE TABLE [dbo].[ATMs] (
    [ID] BIGINT NOT NULL IDENTITY(1,1),
    [ATMID] UNIQUEIDENTIFIER NOT NULL,
    [Location] NVARCHAR(max) NOT NULL,
    [AvailbleBalance] DECIMAL(18,2) NOT NULL,
    [TransactionID] UNIQUEIDENTIFIER NOT NULL,
    [isActive] BIT NOT NULL,
    [isDeleted] BIT NOT NULL,
    [CreatedDTM] DATETIME2 NOT NULL,
    [UpdatedDTM] DATETIME2 NOT NULL,
    [CreatedBy] BIGINT NOT NULL,
    [UpdatedBy] BIGINT NOT NULL,
    CONSTRAINT [PK_ATMs] PRIMARY KEY CLUSTERED ([ID])
);

-- CreateTable
CREATE TABLE [dbo].[Transactions] (
    [ID] BIGINT NOT NULL IDENTITY(1,1),
    [TransactionID] UNIQUEIDENTIFIER NOT NULL,
    [transactionType] INT NOT NULL,
    [Amount] FLOAT(53) NOT NULL,
    [OriginAccountNumber] NVARCHAR(max),
    [DestinationAccountNumber] NVARCHAR(max),
    [AccountID] UNIQUEIDENTIFIER NOT NULL,
    [TransactionDate] DATETIME2 NOT NULL,
    [ATMID] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF__Transacti__ATMID__52593CB8] DEFAULT 00000000-0000-0000-0000-000000000000,
    [ATMsID] BIGINT NOT NULL CONSTRAINT [DF__Transacti__ATMsI__534D60F1] DEFAULT CONVERT([bigint],(0)),
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([ID])
);

-- CreateTable
CREATE TABLE [dbo].[users] (
    [ID] BIGINT NOT NULL IDENTITY(1,1),
    [UserID] UNIQUEIDENTIFIER NOT NULL,
    [UserName] NVARCHAR(max) NOT NULL,
    [PasswordHash] NVARCHAR(max) NOT NULL,
    [Email] NVARCHAR(max) NOT NULL,
    [RefreshToken] NVARCHAR(max),
    [ResetToken] NVARCHAR(max),
    [email] NVARCHAR(1000),
    [email_verified] DATETIME2,
    [image] NVARCHAR(1000),
    [RefreshTokenExpiryTime] DATETIME2,
    [ResetDTMExpiry] DATETIME2,
    [ActivationToken] NVARCHAR(max),
    [ActivationDate] DATETIME2,
    [UpdatedDTM] DATETIME2,
    [RoleID] BIGINT NOT NULL,
    [AccountID] BIGINT,
    [created_at] DATETIME2 NOT NULL CONSTRAINT [users_created_at_df] DEFAULT CURRENT_TIMESTAMP,
    [IsDeleted] BIT NOT NULL,
    [DeletedBy] BIGINT,
    [DeletedDTM] DATETIME2,
    [RowVersion] timestamp,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID]),
    CONSTRAINT [users_email_key] UNIQUE NONCLUSTERED ([email])
);

-- CreateTable
CREATE TABLE [dbo].[userAccounts] (
    [id] INT NOT NULL IDENTITY(1,1),
    [compound_id] NVARCHAR(1000) NOT NULL,
    [user_id] INT NOT NULL,
    [provider_type] NVARCHAR(1000) NOT NULL,
    [provider_id] NVARCHAR(1000) NOT NULL,
    [provider_account_id] NVARCHAR(1000) NOT NULL,
    [refresh_token] NVARCHAR(1000),
    [access_token] NVARCHAR(1000),
    [access_token_expires] DATETIME2,
    [created_at] DATETIME2 NOT NULL CONSTRAINT [userAccounts_created_at_df] DEFAULT CURRENT_TIMESTAMP,
    [updated_at] DATETIME2 NOT NULL CONSTRAINT [userAccounts_updated_at_df] DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT [userAccounts_pkey] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [userAccounts_compound_id_key] UNIQUE NONCLUSTERED ([compound_id])
);

-- CreateTable
CREATE TABLE [dbo].[sessions] (
    [id] INT NOT NULL IDENTITY(1,1),
    [user_id] INT NOT NULL,
    [expires] DATETIME2 NOT NULL,
    [session_token] NVARCHAR(1000) NOT NULL,
    [access_token] NVARCHAR(1000) NOT NULL,
    [created_at] DATETIME2 NOT NULL CONSTRAINT [sessions_created_at_df] DEFAULT CURRENT_TIMESTAMP,
    [updated_at] DATETIME2 NOT NULL CONSTRAINT [sessions_updated_at_df] DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT [sessions_pkey] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [sessions_session_token_key] UNIQUE NONCLUSTERED ([session_token]),
    CONSTRAINT [sessions_access_token_key] UNIQUE NONCLUSTERED ([access_token])
);

-- CreateTable
CREATE TABLE [dbo].[verification_requests] (
    [id] INT NOT NULL IDENTITY(1,1),
    [identifier] NVARCHAR(1000) NOT NULL,
    [token] NVARCHAR(1000) NOT NULL,
    [expires] DATETIME2 NOT NULL,
    [created_at] DATETIME2 NOT NULL CONSTRAINT [verification_requests_created_at_df] DEFAULT CURRENT_TIMESTAMP,
    [updated_at] DATETIME2 NOT NULL CONSTRAINT [verification_requests_updated_at_df] DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT [verification_requests_pkey] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [verification_requests_token_key] UNIQUE NONCLUSTERED ([token])
);

-- CreateIndex
CREATE NONCLUSTERED INDEX [IX_Transactions_ATMsID] ON [dbo].[Transactions]([ATMsID]);

-- CreateIndex
CREATE NONCLUSTERED INDEX [IX_User_AccountID] ON [dbo].[users]([AccountID]);

-- CreateIndex
CREATE NONCLUSTERED INDEX [providerAccountId] ON [dbo].[userAccounts]([provider_account_id]);

-- CreateIndex
CREATE NONCLUSTERED INDEX [providerId] ON [dbo].[userAccounts]([provider_id]);

-- CreateIndex
CREATE NONCLUSTERED INDEX [userId] ON [dbo].[userAccounts]([user_id]);

-- AddForeignKey
ALTER TABLE [dbo].[Transactions] ADD CONSTRAINT [FK_Transactions_ATMs_ATMsID] FOREIGN KEY ([ATMsID]) REFERENCES [dbo].[ATMs]([ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[users] ADD CONSTRAINT [FK_User_account_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[account]([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

COMMIT TRAN;

END TRY
BEGIN CATCH

IF @@TRANCOUNT > 0
BEGIN
    ROLLBACK TRAN;
END;
THROW

END CATCH
