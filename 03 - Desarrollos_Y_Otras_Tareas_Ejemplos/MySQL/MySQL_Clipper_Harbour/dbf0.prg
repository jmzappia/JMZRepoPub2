//	--------------------------------------------------------------
//	Nombre.....: dbf0.prg
//	Description: Testear WDO 
//	Fecha......: 17/09/2019
//  Autor......: Juli�n Marcelo Zappia
//	--------------------------------------------------------------

FUNCTION Main()

	LOCAL o
	
		? "<b>==> Test Error de conexion...</b><br>"
	
		o := WDO():Dbf( 'customer.dbf' )
		
		IF o:lConnect
		
			? 'Connected !'
			
		ELSE
		
			? o:cError 
			
		ENDIF

RETU NIL
