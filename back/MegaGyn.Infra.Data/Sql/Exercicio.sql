/*
   quinta-feira, 4 de abril de 202422:36:31
   User: sa
   Server: DESKTOP-JUIBHV6\SQLEXPRESS2
   Database: MEGA_GYN
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Exercicio
	(
	[dbo.Id] int NOT NULL,
	[dbo.NomeDoExercicio] nvarchar(150) NOT NULL,
	[dbo.Series] int NOT NULL,
	[dbo.Repeticoes] int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Exercicio ADD CONSTRAINT
	PK_Exercicio PRIMARY KEY CLUSTERED 
	(
	[dbo.Id]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Exercicio SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Exercicio', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Exercicio', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Exercicio', 'Object', 'CONTROL') as Contr_Per 