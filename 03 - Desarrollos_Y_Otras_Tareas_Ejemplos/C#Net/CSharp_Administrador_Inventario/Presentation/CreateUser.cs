/*
 * Autor: Julián Marcelo Zappia
 * User: ?
 * Date: 25/07/2019
 * Time: 11:43 PM
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

	public partial class CreateUser : Form
	{
		OleDbCommand cmd = new OleDbCommand();
		OleDbConnection accessConnection = new OleDbConnection();
		User newUser = new User();
        int userId;
		public CreateUser()
		{
			
			InitializeComponent();
			accessConnection.ConnectionString = Connection.getConnectionString();
			
		}
        public CreateUser(int id)
        {
            
            InitializeComponent();
            accessConnection.ConnectionString = Connection.getConnectionString();
            
            this.userId = id;
        }


       
        void CreateBtnClick(object sender, EventArgs e)
		{
			newUser.Username = username.Text;
			if(Utilities.getInstance().IsEmpty(groupBox1))
			{
				MessageBox.Show("El cammpo no puede estar vacío", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if(Utilities.getInstance().CheckIfUserExist(newUser.Username))
			{
				MessageBox.Show("Usuario existente");
				return;
			}
			if(password1.Text == password2.Text)
			{
				if(password1.Text.Length >= 8 && password1.Text.Length <= 12)
				{
					errorLb1.Visible  = false;
				    newUser.Password = XOREncryption.getInstance().EncryptPassword(password1.Text,XOREncryption.getInstance().key);
				}
				else
				{
					errorLb1.Visible = true;
					return;
				}
			}
			else
			{
				return;
			}
			 
			newUser.SecretQuestion = secretQuestion.Text;
			newUser.Answer = XOREncryption.getInstance().EncryptPassword(answer.Text, XOREncryption.getInstance().key);
            newUser.UserType = privilegeCmbox.SelectedIndex+1;
			CreateNewUser(newUser);	
			Utilities.getInstance().Clear(groupBox1);
		}
		
		
		public void CreateNewUser(User newUser)
		{
			
			try
			{
				accessConnection.Open();
				cmd.Connection = accessConnection;
				cmd.CommandText = @"INSERT INTO LoginTbl(Username, UserPassword, SecretQuestion, Answer, userType)" +
					               "VALUES([0], [1], [2], [3], [4])";
				cmd.Parameters.AddWithValue("0", newUser.Username.ToLower());
				cmd.Parameters.AddWithValue("1", newUser.Password);
				cmd.Parameters.AddWithValue("2", newUser.SecretQuestion);
				cmd.Parameters.AddWithValue("3", newUser.Answer.ToLower());
				cmd.Parameters.AddWithValue("4", newUser.UserType);
                cmd.ExecuteNonQuery();
				MessageBox.Show("Created successfully");
                Data_Access.DataAccess.LogAction(userId, "Added New User: " + newUser.Username);
                Utilities.GetOpenFormInstance().loadActivity();
            }
			catch(Exception e)
			{
				MessageBox.Show(""+e);
			}
			finally{
				
				accessConnection.Close();
			}
			
		}
		
	
		public void ChangePassword(User newUser)
		{
			
		  try
			{
				accessConnection.Open();
				cmd.Connection = accessConnection;
				cmd.CommandText = @"UPDATE LoginTbl SET UserPassword = [0] WHERE Username = [1]";
				cmd.Parameters.AddWithValue("0", newUser.Password);
				cmd.Parameters.AddWithValue("1",newUser.Username);
				cmd.ExecuteNonQuery();
				MessageBox.Show("Password changed successfully");
                Data_Access.DataAccess.LogAction(userId, "Changed Password for user: " + newUser.Username);
                Utilities.GetOpenFormInstance().loadActivity();
            }
			catch(Exception e)
			{
				MessageBox.Show(""+e);
			}
			finally{
				
				accessConnection.Close();
			}
		}
		
		
		void ChangeBtnClick(object sender, EventArgs e)
		{
			errorLb3.Visible = false;
			errorLb4.Visible = false;
            int userType = 0;
            int id = 0;
			newUser.Username = username2Txtbox.Text;
			string tempPassword;
			tempPassword = XOREncryption.getInstance().EncryptPassword(oldPasswordTxtBox.Text, XOREncryption.getInstance().key);
			if(!(Utilities.getInstance().ValidateUser(username2Txtbox.Text, tempPassword, out userType, out id)))
			{
				errorLb3.Visible = true;
				return;
			}
			if(newPasswordTxtbox.Text != newPasswordTxtbox2.Text)
			{
				errorLb4.Visible = true;
				return;
			}
			newUser.Password = XOREncryption.getInstance().EncryptPassword(newPasswordTxtbox.Text, XOREncryption.getInstance().key);
			ChangePassword(newUser);
			Utilities.getInstance().Clear(groupBox2);
		}
		
		
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			DeleteUser deleteForm = new DeleteUser();
			this.Enabled = false;
			deleteForm.Show();
			
		}
		
		
		void CreateUserFormClosed(object sender, FormClosedEventArgs e)
		{
			MainForm mainForm = Application.OpenForms["MainForm"] as MainForm;
			mainForm.Enabled = true;
		}

        private void CreateUser_Load(object sender, EventArgs e)
        {

        }
    }
}
