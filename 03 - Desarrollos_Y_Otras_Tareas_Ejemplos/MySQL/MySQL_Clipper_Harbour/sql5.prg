//	--------------------------------------------------------------
//	Nombre.....: sql5.prg
//	Description: Testear WDO - ADO con SQL y MySQL
//	Fecha......: 17/09/2019
//  Autor......: Juli�n Marcelo Zappia
//	--------------------------------------------------------------


FUNCTION Main()

	LOCAL o, oRs, hRes

	
		o := WDO():Rdbms( 'MYSQL', "localhost", "harbour", "password", "dbHarbour", 3306 )		
		
		
		IF ! o:lConnect		
			RETU NIL
		ENDIF
		
		?? '<h3>Data Base Customer</h3><hr>'
		
		cSql 	:= "SELECT count(*) as total FROM customer"
		
		hRes 	:= o:Query( cSql  )
		oRs 	:= o:Fetch_Assoc( hRes )
		
		? '<b>Registros Totales: </b>', oRs[ 'total' ]		
	

		cSql := "SELECT * FROM customer c " +;
		        "LEFT JOIN states s ON s.code = c.state " +;
				"WHERE ( c.state = 'LA' OR c.state = 'AK' ) and c.age >= 58 and c.age <= 60 and c.married = 1 " +;
				"ORDER by first	"		
				
				
		? '<br><b>Sql: </b>' , cSql
		
		IF !empty( hRes := o:Query( cSql  ) )
		
			? '<br><b>Total Select: </b>', o:Count( hRes )
		
			aData := o:FetchAll( hRes )

			o:View( o:DbStruct(),	aData )
		
		ENDIF				
		
		
RETU NIL