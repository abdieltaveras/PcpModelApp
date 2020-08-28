CREATE PROCEDURE [dbo].[SpInsUpdPersona]
(
	@idPersona int=-1,
	@Codigo varchar(20), 
	@Nombres varchar(40), 
	@Apellido1 varchar(30),  
	@Apellido2 varchar(30), 
	@FechaNacimiento  DateTime,
	@CampoNuevo  varchar(30)='', 
	@Usuario varchar (30)
)
AS
begin
	if (@idPersona<=0)
	-- Insertar
		begin
			INSERT INTO dbo.TblPersonas (Codigo, Nombres, Apellido1, Apellido2, FechaNacimiento, InsertadoPor)
			VALUES (@codigo, @nombres, @apellido1, @apellido2, @fechanacimiento, @Usuario)
			SELECT SCOPE_IDENTITY(); 
		End
	else
		begin
		UPDATE dbo.TblPersonas
		SET --Codigo = @codigo, el codigo no debe ser modificado en este stored procedure
			-- se especializara en otro
			Nombres = @nombres,
			Apellido1 = @apellido1,
			Apellido2 = @apellido2,
			FechaNacimiento = @fechanacimiento,
			ModificadoPor = @Usuario,
			-- observe que campo nuevo no esta incluido en la actualizacion
			FechaModificado =getDate()
		where idPersona = @IdPersona 
		select @idPersona
		end
end
