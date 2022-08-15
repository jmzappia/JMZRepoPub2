//	--------------------------------------------------------------
//	Nombre.....: tusers.prg
//	Description: Testear WDO - ADO con SQL y MySQL - Usuarios
//	Fecha......: 17/09/2019
//  Autor......: Julián Marcelo Zappia
//	--------------------------------------------------------------


#include "hbclass.ch" 
#include "hboo.ch" 

CLASS TUsers FROM TDataset

    METHOD  New() CONSTRUCTOR			
   
	METHOD GetDpt( cDpt )

ENDCLASS

METHOD New() CLASS TUsers

	::cPath     	:= hb_getenv( 'PRGPATH' ) + '/data/sales'	
	::cTable 		:= 'vendors.dbf'	
	::cIndex 		:= 'vendors.cdx'	
	::cFocus 		:= 'id'		

	::AddField( 'id' )
	::AddField( 'name' )
	::AddField( 'phone' )
	::AddField( 'dpt' )
	
	::Open()

RETU Self


METHOD GetDpt( cDpt ) CLASS TUsers

	LOCAL aRows := {}

	hb_default( @cDpt, '' )

	::oDb:Focus( 'DPT' )
	::oDb:Seek( cDpt )
	
	WHILE !::oDb:Eof() .AND. ::oDb:FieldGet( 'dpt' ) == cDpt
	
		Aadd( aRows, ::Load() )
		
		::oDb:next()
	
	END

RETU aRows