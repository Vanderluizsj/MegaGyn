/*
   quinta-feira, 4 de abril de 202423:02:32
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
EXECUTE sp_rename N'dbo.Exercicio.[dbo.Id]', N'Tmp_Id_2', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Exercicio.[dbo.NomeDoExercicio]', N'Tmp_NomeDoExercicio_3', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Exercicio.[dbo.Series]', N'Tmp_Series_4', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Exercicio.[dbo.Repeticoes]', N'Tmp_Repeticoes_5', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Exercicio.Tmp_Id_2', N'Id', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Exercicio.Tmp_NomeDoExercicio_3', N'NomeDoExercicio', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Exercicio.Tmp_Series_4', N'Series', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Exercicio.Tmp_Repeticoes_5', N'Repeticoes', 'COLUMN' 
GO
ALTER TABLE dbo.Exercicio SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Exercicio', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Exercicio', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Exercicio', 'Object', 'CONTROL') as Contr_Per 