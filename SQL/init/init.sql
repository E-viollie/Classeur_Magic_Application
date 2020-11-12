drop table Card
drop table Deck
USE [Test_classeur_MTG]
GO

/****** Object:  Table [dbo].[Card]    Script Date: 12/11/2020 19:41:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/****** Object:  Table [dbo].[Deck]    Script Date: 12/11/2020 19:50:01 ******/
CREATE TABLE [dbo].[Deck](
	[DeckID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Image] [varbinary](max) NULL,
	PRIMARY KEY(DeckID)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Card](
	[CardID] [int] IDENTITY(1,1) NOT NULL,
	[DeckID] [int] NULL,
	[ExchangeDate] [date] NULL,
	[Condition] [int] NOT NULL,
	[Foil] [bit] NOT NULL,
	[Language] [int] NOT NULL,
	[CardState] [int] NOT NULL,
	[Image] [varbinary](max) NULL,
	PRIMARY KEY (CardID),
	Constraint FK_CardDeck Foreign Key (DeckId) REFERENCES Deck(DeckID)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



