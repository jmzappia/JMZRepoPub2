//	--------------------------------------------------------------
//	Nombre.....: wdo_lib.prg
//	Description: Librería de procedimientos y funciones
//	Fecha......: 17/09/2019
//  Autor......: Julián Marcelo Zappia
//	--------------------------------------------------------------


#xcommand ? [<explist,...>] => AP_RPuts( '<br>' [,<explist>] )
#xcommand ?? [<explist,...>] => AP_RPuts( [<explist>] )
#xcommand TEMPLATE [ USING <x> ] [ PARAMS [<v1>] [,<vn>] ] => #pragma __cstream | AP_RPuts( InlinePrg( %s, [@<x>] [,<(v1)>][+","+<(vn)>] [, @<v1>][, @<vn>] ) )
//	-------------------------------------------------------------------------------- 

#include "hbclass.ch" 
#include "hboo.ch"   
#include "hbhash.ch"

#include "wdo.prg" 					//	WDO
#include "rdbms.prg" 				//	Base RDBMS
#ifdef WITH_ADO
	#include "rdbms_ado.prg" 		//	ADO
#endif
#include "rdbms_dbf.prg" 			//	Dbf
#include "rdbms_mysql.prg" 			//	MySql
//#include "rdbms_pg.prg" 			//	PostgreSql
#include "tdataset.prg" 			//	Clase TDataset
//	---------------------------------------------------------------------------- //
