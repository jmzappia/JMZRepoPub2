//	--------------------------------------------------------------
//	Nombre.....: model.prg
//	Description: Testear WDO - ADO
//	Fecha......: 17/09/2019
//  Autor......: Juli�n Marcelo Zappia
//	--------------------------------------------------------------


FUNCTION Main()

	LOCAL oUsers := TUsers():New()
	LOCAL hReg, aRows

	? valtochar( oUsers:Row() )
	
	IF  oUsers:getId( 5 )		
		? '<br>Found !'		
	ELSE	
		? 'Not found'		
	ENDIF
	
	hReg := oUsers:Row()
	
	? '<br><b>Row =></b>', valtoChar( hReg )	
	
	? '<br>Name: ' , hReg[ 'name' ]
	
	? '<hr>'
	
	? '<br><b>List Dpt == TIC</b></br>'
	
	aRows := oUsers:GetDpt( 'TIC' ) 	
	
	FOR nI := 1 TO Len( aRows )
		? valtochar( aRows[nI] )
	NEXT			
	
RETU NIL

{% memoread( HB_GETENV( 'PRGPATH' ) + "/src/model/tusers.prg" ) %} 
