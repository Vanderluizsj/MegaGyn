/*
   quinta-feira, 4 de abril de 202423:00:57
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
EXECUTE sp_rename N'dbo.Treino.[dbo.Id]', N'Tmp_Id', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Treino.[dbo.NomeDoTreino]', N'Tmp_NomeDoTreino_1', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Treino.Tmp_Id', N'Id', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Treino.Tmp_NomeDoTreino_1', N'NomeDoTreino', 'COLUMN' 
GO
ALTER TABLE dbo.Treino ADD CONSTRAINT
	FK_Treino_Treino FOREIGN KEY
	(
	Id
	) REFERENCES dbo.Treino
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Treino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Treino', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Treino', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Treino', 'Object', 'CONTROL') as Contr_Per 