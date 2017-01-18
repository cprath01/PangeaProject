CREATE TABLE [dbo].[RepoCopy] (
    [RowId]       INT            IDENTITY (1, 1) NOT NULL,
    [ID]          INT            NULL,
    [Name]        VARCHAR (50)   NULL,
    [URL]         VARCHAR (255)  NULL,
    [Description] VARCHAR (1024) NULL,
    PRIMARY KEY CLUSTERED ([RowId] ASC)
);