CREATE TABLE [dbo].[ATMs] (
    [ID]              BIGINT           IDENTITY (1, 1) NOT NULL,
    [ATMID]           UNIQUEIDENTIFIER NOT NULL,
    [Location]        NVARCHAR (MAX)   NOT NULL,
    [AvailbleBalance] DECIMAL (18, 2)  NOT NULL,
    [TransactionID]   UNIQUEIDENTIFIER NOT NULL,
    [isActive]        BIT              NOT NULL,
    [isDeleted]       BIT              NOT NULL,
    [CreatedDTM]      DATETIME2 (7)    NOT NULL,
    [UpdatedDTM]      DATETIME2 (7)    NOT NULL,
    [CreatedBy]       NVARCHAR (50)    NOT NULL,
    [UpdatedBy]       NVARCHAR (50)    NOT NULL
);
GO

ALTER TABLE [dbo].[ATMs]
    ADD CONSTRAINT [PK_ATMs] PRIMARY KEY CLUSTERED ([ID] ASC);
GO

