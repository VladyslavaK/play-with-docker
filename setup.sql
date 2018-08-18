CREATE DATABASE TEST;
GO
USE TEST;
GO

CREATE TABLE [dbo].[Tasks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[IsDone] [bit] NOT NULL);
GO