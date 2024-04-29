CREATE TABLE [dbo].[Transactions] (
    [ID]                       BIGINT           IDENTITY (1, 1) NOT NULL,
    [TransactionID]            UNIQUEIDENTIFIER NOT NULL,
    [transactionType]          INT              NOT NULL,
    [Amount]                   FLOAT (53)       NOT NULL,
    [OriginAccountNumber]      NVARCHAR (MAX)   NULL,
    [DestinationAccountNumber] NVARCHAR (MAX)   NULL,
    [AccountID]                BIGINT           NOT NULL,
    [TransactionDate]          DATETIME2 (7)    NOT NULL,
    [ATMID]                    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Transactions_ATMID] FOREIGN KEY ([ATMID]) REFERENCES [dbo].[ATMs] ([ATMID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Transactions_ATMID]
    ON [dbo].[Transactions]([ATMID] ASC);