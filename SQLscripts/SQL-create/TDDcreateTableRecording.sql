USE [catalog]
GO

/****** Object:  Table [dbo].[Recording]    Script Date: 04/10/2016 13:49:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Recording](
	[id] [bigint] NOT NULL,
	[title] [varchar](128) NOT NULL,
	[releasedate] [datetime] NOT NULL,
	[labelid] [bigint] NOT NULL,
	[artistid] [bigint] NOT NULL,
 CONSTRAINT [PK_Recording] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

