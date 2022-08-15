//	--------------------------------------------------------------
//	Nombre.....: ado.prg
//	Description: Testear WDO - ADO con SQL y MySQL
//	Fecha......: 17/09/2019
//  Autor......: Julián Marcelo Zappia
//	--------------------------------------------------------------

FUNCTION Main()

	LOCAL o	
		
		//o := WDO():Rdbms( 'MYSQL', "localhost", "root", "", "dummy", 3306 )
		o := WDO():Rdbms( 'MYSQL', "localhost", "harbour", "password", "dbHarbour", 3306 )
		
		IF o:lConnect
		
			? 'Connected !', '<b>Version RDBMS MySql', o:Version()
			
		ENDIF

RETU NIL
