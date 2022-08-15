//	--------------------------------------------------------------
//	Nombre.....: ado.prg
//	Description: Testear WDO - ADO
//	Fecha......: 17/09/2019
//  Autor......: Julián Marcelo Zappia
//	--------------------------------------------------------------

FUNCTION Main()

	LOCAL o
	LOCAL hCfg 	:= Config_ADO()
		
		//o := WDO():ADO( hCfg, .T. )
		
		o := WDO():ADO( hCfg[ 'server' ], hCfg[ 'user' ], hCfg[ 'pwd' ], hCfg[ 'db' ], .T. )	//	.T. lAutoOpen, default .F.
		
		IF o:lConnect
		
			? 'Connected !'
			
		ELSE
		
			? 'Error: ', o:cError 
			
		ENDIF		

RETU NIL

{% memoread( HB_GETENV( 'PRGPATH' ) + "/cfg_ado.prg" ) %}
