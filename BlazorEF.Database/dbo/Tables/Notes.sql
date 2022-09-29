CREATE TABLE [dbo].[Notes] (
    [NoteId]      NVARCHAR (450) NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [Message]     NVARCHAR (MAX) NULL,
    [CreateDate]  DATETIME2 (7)  NOT NULL,
    [UpdatedDate] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([NoteId] ASC)
);

