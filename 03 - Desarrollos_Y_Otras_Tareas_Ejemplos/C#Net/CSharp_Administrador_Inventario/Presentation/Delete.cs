/*
 * Autor: Julián Marcelo Zappia
 * User: ?
 * Date: 7/17/2019
 * Time: 9:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using Inventory_System.Classes;

namespace Inventory_System
{
	
	public partial class Delete : Form
	{
		private OleDbConnection accessConnection = new OleDbConnection();
		OleDbDataAdapter adapter = new OleDbDataAdapter();
		OleDbCommand cmd = new OleDbCommand();
		OleDbDataReader accessReader ;
		Item newItem = new Item();
        int userId;
		public Delete()
		{
			
			InitializeComponent();
			accessConnection.ConnectionString = Connection.getConnectionString();
			

		}

        public Delete(int id)
        {
            
            InitializeComponent();
            accessConnection.ConnectionString = Connection.getConnectionString();
           
            this.userId = id;

        }

        void DeleteBtnClick(object sender, EventArgs e)
		{
			 DeleteItem();
		}
		public void DeleteItem()
		{
			DialogResult dialog = new DialogResult();
			if(string.IsNullOrEmpty(newItem.ItemName))
			   {
			   	return;
			   }
			dialog =  MessageBox.Show("¿Esta seguro de eliminar este ítem?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			     MainForm mainForm = Application.OpenForms["MainForm"] as MainForm;
				try
				{
					if(dialog == DialogResult.Yes)
					{
						int x = 2;
					accessConnection.Open();
			     

					 cmd.CommandText =  @"Update ItemTbl Set StatusId  = [0] WHERE ItemName = [1]";
					 cmd.Parameters.AddWithValue("0", x);
					 cmd.Parameters.AddWithValue("1", newItem.ItemName);
					 cmd.Connection = accessConnection;
				    
					 accessReader =  cmd.ExecuteReader();
					 if(accessReader.HasRows)
					 {
						while(accessReader.Read())
						{
							itemNameCmb.Items.Add(accessReader.GetString(0));
						}
					}
					 MessageBox.Show("Registro eliminado");
                     Data_Access.DataAccess.LogAction(userId, "Registro eliminado: " + newItem.ItemName);
                     mainForm.RefreshItemStatus();
					 mainForm.getNotifications();
                     Utilities.GetOpenFormInstance().loadActivity();
                }
					else
					{
						MessageBox.Show("Este ítem no puede eliminarse", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);	
					}
				}
				catch(Exception e)
				{
					MessageBox.Show("Error desconocido: " );
				}
				finally
				{
					itemNameCmb.Text = "";
					
					accessReader.Close();
					accessConnection.Close();
					refreshNames();
				}
			
		}
		
		void ItemNameCmbSelectedIndexChanged(object sender, EventArgs e)
		{
			newItem.ItemName = itemNameCmb.SelectedItem.ToString();
		}
		
		void DeleteLoad(object sender, EventArgs e)
		{
			refreshNames();
		}
		void refreshNames()
		{
			try
			{
				itemNameCmb.Items.Clear();
				accessConnection.Open();
		      

		        cmd = new OleDbCommand();
				cmd.CommandText =  @"SELECT ItemName FROM ItemTbl Where StatusId = 1";
				cmd.Connection = accessConnection;
			 
				 accessReader =  cmd.ExecuteReader();
			  
				while(accessReader.Read())
				{
					itemNameCmb.Items.Add(accessReader.GetString(0));
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Problema en la conexión...  "+ex);
			}
			finally
			{
			
				accessReader.Close();
				accessConnection.Close();
			}
		}
		
		void DeleteFormClosed(object sender, FormClosedEventArgs e)
		{
			MainForm mainForm = Application.OpenForms["MainForm"] as MainForm;
			mainForm.Enabled = true;
		}
		

		
	}
}
