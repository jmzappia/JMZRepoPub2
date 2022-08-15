//	--------------------------------------------------------------
//	Nombre.....: ado.prg
//	Description: Testear WDO - ADO
//	Fecha......: 17/09/2019
//  Autor......: Julián Marcelo Zappia
//	--------------------------------------------------------------

FUNCTION Main()

	LOCAL hCfg 	:= Config_ADO()
	LOCAL o, oRs
	LOCAL n
	
		o := WDO():ADO( hCfg, .T. )
		
		? o:Version()
		
		oRs := o:Query( 'SELECT * FROM CUSTOMER' ) 
		
		? 'Count: ' , oRs:Count()
		? '<hr>'
		
		for n = 1 to oRs:FCount()
			? oRs:FieldName( n ), oRs:FieldGet( n )
		next
		
		? '<hr>'
		oRs:Next() 
		
		for n = 1 to oRs:FCount()
			? oRs:FieldName( n ), oRs:FieldGet( n )
		next 
		
		? '<hr>'
		oRs:Next()
		
		? valtochar( oRs:Row() )
		
RETU NIL


{% memoread( HB_GETENV( 'PRGPATH' ) + "/cfg_ado.prg" ) %} 
