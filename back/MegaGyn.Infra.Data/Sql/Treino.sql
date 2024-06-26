/*
   quinta-feira, 4 de abril de 202422:41:29
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
CREATE TABLE dbo.Treino
	(
	[dbo.Id] int NOT NULL,
	[dbo.NomeDoTreino] nvarchar(150) NOT NULL,
	IdExercicio int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Treino ADD CONSTRAINT
	PK_Treino PRIMARY KEY CLUSTERED 
	(
	[dbo.Id]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Treino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Treino', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Treino', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Treino', 'Object', 'CONTROL') as Contr_Per 