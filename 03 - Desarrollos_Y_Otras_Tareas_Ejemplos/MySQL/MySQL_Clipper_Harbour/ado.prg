//	--------------------------------------------------------------
//	Nombre.....: ado.prg
//	Description: Testear WDO - ADO
//	Fecha......: 17/09/2019
//  Autor......: Julián Marcelo Zappia
//	--------------------------------------------------------------

FUNCTION Main()

	LOCAL o
	
		?? "<b>==> Test Error de conexion...</b><br><hr>"
		
		
		o := WDO():ADO()		
		
		? 'Version ', o:Version()
		? 'Open: ', o:Open()
		
		IF o:lConnect
		
			? 'Connected !'
			
		ELSE
		
			? 'Error: ', o:cError 
			
		ENDIF

RETU NIL
