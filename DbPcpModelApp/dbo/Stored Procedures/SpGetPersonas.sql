CREATE PROCEDURE [dbo].[SpGetPersonas]
	(   @IdPersona int =-1,
		@Nombres varchar(30) =''
	)
AS
begin
	select IdPersona, Nombres, Codigo, Apellido1, Apellido2  from tblPersonas
	where 
		((@idPersona<=0) or (idPersona=@idPersona)) and 
		((@nombres='') or  (nombres like '%'+@nombres+'%'))
		--
end