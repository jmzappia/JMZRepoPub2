﻿/*
 * Autor: Julián Marcelo Zappia
 * User: ?
 * Date: 20/07/2019
 * Time: 12:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Inventory_System
{

	public partial class About : Form
	{
		public About()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			productVersionlbl.Text = Application.ProductVersion;
			productNameLbl.Text = Application.ProductName;		
			/*productNameLbl.Parent = pictureBox1;
			productVersionlbl.Parent = pictureBox1;
			label1.Parent = pictureBox1;
			label2.Parent = pictureBox1;
			label4.Parent = pictureBox1;
			label5.Parent = pictureBox1;*/
			//
			
		}
		
		void AboutFormClosed(object sender, FormClosedEventArgs e)
		{
		   Form mainform = Application.OpenForms["MainForm"] as Form;
			mainform.Enabled = true;
		}	
		
	}
}
