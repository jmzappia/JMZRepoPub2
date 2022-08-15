//	--------------------------------------------------------------
//	Nombre.....: sql1.prg
//	Description: Testear WDO - ADO con SQL y MySQL
//	Fecha......: 17/09/2019
//  Autor......: Julián Marcelo Zappia
//	--------------------------------------------------------------


FUNCTION Main()

	LOCAL o, oRs, a
	
		o := WDO():Rdbms( 'MYSQL', "localhost", "harbour", "password", "dbHarbour", 3306 )

		
		IF o:lConnect
		
			?? 'Version WDO', o:ClassName(), o:Version()
			
			IF !empty( hRes := o:Query( "select * from customer where age > 98 and state = 'NY' " ) )

				? 'Count(): ', o:Count( hRes )
				? 'Fields: ',  o:FCount( hRes )

				
				? '<br><b>Fields</b>'
				for n := 1 to len( o:aFields )			
					? o:aFields[n][1], o:aFields[n][2]
				next			
				
				? '<br><b>Data</b>'
				//while ( !empty( a := o:Fetch( hRes ) ) )
				//	? valtochar( a )
				//end
				
				//	Associative array
				while ( !empty( a := o:Fetch_Assoc( hRes ) ) )
					? valtochar( a )
				end	
			
			ENDIF
		
		ENDIF
		
RETU NIL
