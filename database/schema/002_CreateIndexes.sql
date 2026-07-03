USE NotesDb;
GO

CREATE INDEX IX_Notes_UserId
ON Notes(UserId);

CREATE INDEX IX_RefreshTokens_UserId
ON RefreshTokens(UserId);

CREATE INDEX IX_RefreshTokens_Token
ON RefreshTokens(Token);