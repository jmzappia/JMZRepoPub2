//	--------------------------------------------------------------
//	Nombre.....: cfg_ado.prg
//	Description: Configuraci�n
//	Fecha......: 17/09/2019
//  Autor......: Juli�n Marcelo Zappia
//	--------------------------------------------------------------

FUNCTION Config_Ado()

	LOCAL hCfg	:= {=>}
	
	hCfg[ 'server' ]	:= "192.0.1.1"
	hCfg[ 'db' ]		:= ""
	hCfg[ 'user' ]		:= ""
	hCfg[ 'pwd' ]		:= ""


RETU hCfg