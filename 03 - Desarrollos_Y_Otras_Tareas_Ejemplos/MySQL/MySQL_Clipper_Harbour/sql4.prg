//	--------------------------------------------------------------
//	Nombre.....: sql4.prg
//	Description: Testear WDO - ADO con SQL y MySQL
//	Fecha......: 17/09/2019
//  Autor......: Julián Marcelo Zappia
//	--------------------------------------------------------------

FUNCTION Main()

	LOCAL o, hRes, cTag

	
		o := WDO():Rdbms( 'MYSQL', "localhost", "harbour", "password", "dbHarbour", 3306 )		
	
		
		IF ! o:lConnect		
			? 'Error : ', o:cError
			RETU NIL
		ENDIF
		
		cTag := ltrim(str(hb_milliseconds()))
		
		? "<h3>Insert 3 Registers with first = " + cTag + "</h3>"		
		
		o:Query( "INSERT INTO customer (first, age) VALUES ('" + cTag + "', '80')" ) 						
		o:Query( "INSERT INTO customer (first, age) VALUES ('" + cTag + "', '84')" ) 
		o:Query( "INSERT INTO customer (first, age) VALUES ('" + cTag + "', '83')" ) 
		
		IF !empty( hRes := o:Query( "select * from customer where first = '" + cTag + "' " ) )
		
			aData := o:FetchAll( hRes )

			o:View( o:DbStruct(),	aData )
		
		ENDIF	
	
		
		? "<h3>Delete first = '" + cTag + "' </h3>"
		
		o:Query( "delete FROM `customer` WHERE first = '" + cTag + "' " ) 
		
		IF !empty( hRes := o:Query( "select * from customer where first = '" + cTag + "' " ) )
		
			aData := o:FetchAll( hRes )

			o:View( o:DbStruct(),	aData )
		
		ENDIF						
		
		
RETU NIL

