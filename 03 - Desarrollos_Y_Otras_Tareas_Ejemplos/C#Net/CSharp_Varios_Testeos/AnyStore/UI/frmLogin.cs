/*************************************************************************************************************
* Programa: frmLogin.cs                                                                                      *
**************************************************************************************************************
* Descripción:                                                                                               *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2022                                                                                    *
*************************************************************************************************************/

using AnyStore.BLL;
using AnyStore.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        loginBLL l = new loginBLL();
        loginDAL dal = new loginDAL();
        public static string loggedIn;

        private void pboxClose_Click(object sender, EventArgs e)
        {
            //Código para cerrar form.
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            l.username = txtUsername.Text.Trim();
            l.password = txtPassword.Text.Trim();
            l.user_type = cmbUserType.Text.Trim();

            //Chequeo de credenciales en Login.
            bool sucess = dal.loginCheck(l);
            if(sucess==true)
            {
                //Login correcto.
                MessageBox.Show("Bienvenido!");
                loggedIn = l.username;
                //Habilitación / Apertura de los correspondientes formularios de acuerdo al tipo de usuario.
                switch(l.user_type)
                {
                    case "Admin":
                        {
                            //Mostrar formulario de "Administración".
                            frmAdminDashboard admin = new frmAdminDashboard();
                            admin.Show();
                            this.Hide();
                        }
                        break;

                    case "User":
                        {
                            
                            frmUserDashboard user = new frmUserDashboard();
                            user.Show();
                            this.Hide();
                        }
                        break;

                    default:
                        {
                            //Mostrar error de Login.
                            MessageBox.Show("Tipo de usuario inválido.");
                        }
                        break;
                }
            }
            else
            {
                //Fallo en Login.
                MessageBox.Show("No se puede ingresar. Intente nuevamente.");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
