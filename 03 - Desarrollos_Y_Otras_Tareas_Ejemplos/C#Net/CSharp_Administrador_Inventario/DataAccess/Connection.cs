/*
 * Autor: Julián Marcelo Zappia 
 * Date: 16/07/2019
 * Time: 08:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.OleDb;
using System.Data;

namespace Inventory_System
{
	
	public class Connection
	{
		//Connection string for access database
	    private static string  connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Database\Inventory.mdb;Persist Security Info=True";
		private Connection()
		{
			
		}
		public static string getConnectionString()
		{		
			return connectionString;
		}
	}
}
