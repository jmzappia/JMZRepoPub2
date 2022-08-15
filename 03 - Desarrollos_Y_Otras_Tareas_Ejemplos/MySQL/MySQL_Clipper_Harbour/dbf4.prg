//	--------------------------------------------------------------
//	Nombre.....: dbf4.prg
//	Description: Testear WDO - ADO
//	Fecha......: 17/09/2019
//  Autor......: Juli·n Marcelo Zappia
//	--------------------------------------------------------------

FUNCTION Main()

	LOCAL o
	
	
	//	Parametrizac√≥n para todos los objetos que crearemos. CLASSDATA
	
		o := WDO():Dbf()
			o:cDefaultPath 	:= hb_getenv( 'PRGPATH' ) + '/data'
			
			?? '<b>Version WDO</b>', o:ClassName(), o:Version(), '<hr>'
		
		
	//	Uso de tabla Dbf...
		
		o := WDO():Dbf( 'customer.dbf', 'customer.cdx' )		
		
			IF o:Append()			

				o:Fieldput( 'First', 'Test_Append' )
				o:Fieldput( 'Last' , dtos( date()) + ' ' + time() )
				
				? o:Recno(), o:FieldGet( 'first' ), o:FieldGet( 'last' )
				
			ELSE
				? 'Error Append()'
			ENDIF							
		
RETU NIL

