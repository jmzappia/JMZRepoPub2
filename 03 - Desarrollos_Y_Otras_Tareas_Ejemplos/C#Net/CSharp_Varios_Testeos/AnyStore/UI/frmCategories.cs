/*************************************************************************************************************
* Programa: frmCategories.cs                                                                                 *
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
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        categoriesBLL c = new categoriesBLL();
        categoriesDAL dal = new categoriesDAL();
        userDAL udal = new userDAL();

        private void btnADD_Click(object sender, EventArgs e)
        {
           
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;

            
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUser);
            
            c.added_by = usr.id;

            
            bool success = dal.Insert(c);

           
            if(success==true)
            {
                
                MessageBox.Show("Nueva Categoría insertada.");
                Clear();
                //Refresh Data Grid View
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                //FAiled to Insert New Category
                MessageBox.Show("Error.");
            }
        }
        public void Clear()
        {
            txtCategoryID.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtSearch.Text = "";
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;
        }

        private void dgvCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            int RowIndex = e.RowIndex;
            txtCategoryID.Text = dgvCategories.Rows[RowIndex].Cells[0].Value.ToString();
            txtTitle.Text = dgvCategories.Rows[RowIndex].Cells[1].Value.ToString();
            txtDescription.Text = dgvCategories.Rows[RowIndex].Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            c.id = int.Parse(txtCategoryID.Text);
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;
           
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUser);
            
            c.added_by = usr.id;

            
            bool success = dal.Update(c);
            
            if(success==true)
            {
                
                MessageBox.Show("Categoría Actualizada.");
                Clear();
               
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
               
                MessageBox.Show("Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            c.id = int.Parse(txtCategoryID.Text);

           
            bool success = dal.Delete(c);

            
            if(success==true)
            {
                
                MessageBox.Show("Categoría eliminada.");
                Clear();
                
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                
                MessageBox.Show("error");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            string keywords = txtSearch.Text;

            
            if(keywords!=null)
            {
                
                DataTable dt = dal.Search(keywords);
                dgvCategories.DataSource = dt;
            }
            else
            {
                
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
        }

        private void lblTop_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
