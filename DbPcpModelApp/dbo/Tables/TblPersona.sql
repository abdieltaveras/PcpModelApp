CREATE TABLE [dbo].[TblPersonas]
(
	IdPersona INT NOT NULL PRIMARY KEY identity(1,1),
	Codigo varchar(20),
	Nombres varchar(40) not null,
	Apellido1 varchar(30) not null,
	Apellido2 varchar(30) not null,
	FechaNacimiento Date not null,
	InsertadoPor varchar(30),
	FechaInsertado Datetime default getdate(),
	ModificadoPor varchar(30), 
	FechaModificado Datetime, 
    [campoNuevo] VARCHAR(50) NULL,
	CONSTRAINT [FK_tblPersona_UQ_Codigo] Unique NonClustered(Codigo),
)
