/*************************************************************************************************************
* Programa: frmInventory.cs                                                                                  *
**************************************************************************************************************
* Descripción:                                                                                               *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2022                                                                                    *
*************************************************************************************************************/

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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }
        categoriesDAL cdal = new categoriesDAL();
        productsDAL pdal = new productsDAL();
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //Activar funcionalidad para poder minimizar el form.
            this.Hide();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            //Mostrar Categorías en el ComboBox.
            DataTable cDt = cdal.Select();

            cmbCategories.DataSource = cDt;

            //Setear valores a desplegar.
            cmbCategories.DisplayMember = "title";
            cmbCategories.ValueMember = "title";

            //Mostrar los productos en el DataGrid.
            DataTable pdt = pdal.Select();
            dgvProducts.DataSource = pdt;
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Mostrar de acuerdo a la categoría seleccionada.

            string category = cmbCategories.Text;

            DataTable dt = pdal.DisplayProductsByCategory(category);
            dgvProducts.DataSource = dt;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            //Mostrar productos al hacer click en el botón.
            DataTable dt = pdal.Select();
            dgvProducts.DataSource = dt;
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
