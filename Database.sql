USE [LancheDb]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredienteLanche](
	[idLanche] [int] NOT NULL,
	[idIngrediente] [int] NOT NULL,
	[Quantidade] [int] NOT NULL
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredientes](
	[IngredienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NULL,
	[Quantidade] [int] NULL,
	[Valor] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Ingredientes] PRIMARY KEY CLUSTERED 
(
	[IngredienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lanches](
	[LancheId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](120) NULL,
 CONSTRAINT [PK_Lanches] PRIMARY KEY CLUSTERED 
(
	[LancheId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IngredienteLanche]  WITH CHECK ADD FOREIGN KEY([idLanche])
REFERENCES [dbo].[Lanches] ([LancheId])
GO
ALTER TABLE [dbo].[IngredienteLanche]  WITH CHECK ADD FOREIGN KEY([idIngrediente])
REFERENCES [dbo].[Ingredientes] ([IngredienteId])
GO
