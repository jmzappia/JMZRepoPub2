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
		
		oRs:ViewStruct()	

		? valtochar( oRs:GetFields() )		
		
RETU NIL


{% memoread( HB_GETENV( 'PRGPATH' ) + "/cfg_ado.prg" ) %} 
