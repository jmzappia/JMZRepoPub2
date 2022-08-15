/*
 * Autor: Julián Marcelo Zappia
 * User: ?
 * Date: 26/07/2019
 * Time: 10:11 AM
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
	
	public partial class DeleteUser : Form
	{
		OleDbCommand cmd = new OleDbCommand();
		OleDbConnection accessConnection = new OleDbConnection();
		OleDbDataReader accessReader;
        
		int userId;
		
		public DeleteUser()
		{
			
			InitializeComponent();
			accessConnection.ConnectionString = Connection.getConnectionString();
			LoadUsersInList();
			//
		}

        public DeleteUser(int id)
        {
            
            InitializeComponent();
            accessConnection.ConnectionString = Connection.getConnectionString();
            LoadUsersInList();
            //
            this.userId = id;
        }
       
        void LoadUsersInList()
		{
			try
			{
				cmd = new OleDbCommand();
				accessConnection.Open();
				cmd.CommandText =  @"SELECT Username  FROM LoginTbl";
				cmd.Connection = accessConnection;
			
				accessReader =  cmd.ExecuteReader();
			  
				while(accessReader.Read())
				{
					usernameCmbBox.Items.Add(accessReader.GetString(0));
				}
			}
			catch(Exception ex)	
			{
				MessageBox.Show(""+ex);
			}
			finally
			{
				accessReader.Close();
				accessConnection.Close();
			}
		}
		
		void DeleteExisitingUser(string username)
		{
			try
			{
				DialogResult dialog =  MessageBox.Show("¿Está seguro que desea eliminar? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			    MainForm mainForm = Application.OpenForms["MainForm"] as MainForm;
				
				if(dialog == DialogResult.Yes)
				{
					accessConnection.Open();
					cmd.CommandText =  @"DELETE *  FROM LoginTbl Where Username = [0]";
					cmd.Parameters.AddWithValue("0", username);
					cmd.Connection = accessConnection;
					cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario eliminado");
                    Data_Access.DataAccess.LogAction(userId, "Deleted User: "+username);
				    usernameCmbBox.Items.Clear();
                    Utilities.GetOpenFormInstance().loadActivity();

                    passwordTxtBox.Text = "";
				}
			}

			catch(Exception)	
			{
				
			}

			finally
			{
				accessConnection.Close();
				LoadUsersInList();
			}
		}
		
		
		void DeleteBtnClick(object sender, EventArgs e)
		{
			errorlb2.Visible = false;
			errelb.Visible = false;
            int userType;
            int id = 0;
            if (usernameCmbBox.SelectedIndex < 0 || passwordTxtBox.Text == "")
			{
				errelb.Visible = true;
			}
			
			string password = XOREncryption.getInstance().EncryptPassword(passwordTxtBox.Text, XOREncryption.getInstance().key);
			if(!Utilities.getInstance().ValidateUser(usernameCmbBox.SelectedItem.ToString(),password, out userType, out id))
			{
				errorlb2.Visible = true;
				return;
			}
			
			DeleteExisitingUser(usernameCmbBox.SelectedItem.ToString());
		}
		
		void DeleteUserFormClosed(object sender, FormClosedEventArgs e)
		{
			Form form = Application.OpenForms["CreateUser"] as CreateUser;
			form.Enabled = true;
		}

        private void DeleteUser_Load(object sender, EventArgs e)
        {

        }
    }
}
