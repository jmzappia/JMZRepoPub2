//	--------------------------------------------------------------
//	Nombre.....: ado.prg
//	Description: Testear WDO - ADO con SQL y MySQL
//	Fecha......: 17/09/2019
//  Autor......: Juli·n Marcelo Zappia
//	--------------------------------------------------------------

FUNCTION Main()

	LOCAL o
	
		? "<b>==> Test Error de conexion...</b><br>"
		
		
		o := WDO():Rdbms( 'MYSQL', "localhost", "harbour", "password", "db_zzz", 3306 )

		
		IF o:lConnect
		
			? 'Connected !', '<b>Versi√≥n RDBMS MySql', o:Version()
			
		ELSE
		
			? o:cError 
			
		ENDIF

RETU NIL
