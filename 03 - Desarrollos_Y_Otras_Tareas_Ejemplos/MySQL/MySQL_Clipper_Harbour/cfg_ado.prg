//	--------------------------------------------------------------
//	Nombre.....: cfg_ado.prg
//	Description: Configuración
//	Fecha......: 17/09/2019
//  Autor......: Julián Marcelo Zappia
//	--------------------------------------------------------------

FUNCTION Config_Ado()

	LOCAL hCfg	:= {=>}
	
	hCfg[ 'server' ]	:= "192.0.1.1"
	hCfg[ 'db' ]		:= ""
	hCfg[ 'user' ]		:= ""
	hCfg[ 'pwd' ]		:= ""


RETU hCfg