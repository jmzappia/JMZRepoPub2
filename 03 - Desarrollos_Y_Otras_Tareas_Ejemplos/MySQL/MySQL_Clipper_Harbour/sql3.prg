//	--------------------------------------------------------------
//	Nombre.....: sql1.prg
//	Description: Testear WDO - ADO con SQL y MySQL
//	Fecha......: 17/09/2019
//  Autor......: Julián Marcelo Zappia
//	--------------------------------------------------------------

FUNCTION Main()

	LOCAL o, oRs
	
		o := WDO():Rdbms( 'MYSQL', "localhost", "harbour", "password", "dbHarbour", 3306 )		

		
		IF ! o:lConnect		
			? 'Error : ', o:cError
			RETU NIL
		ENDIF

		
		IF !empty( hRes := o:Query( 'select * from sellers' ) )
		
			aData := o:FetchAll( hRes )
			
			o:View( o:DbStruct(),	aData )
		
		ENDIF			

RETU NIL