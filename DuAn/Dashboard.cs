using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }



        private void Dashboard_Load(object sender, EventArgs e)
        {
            uc_Addroom1.Visible = false;
            uc_CustumerRes1.Visible = false;
            uc_Checkout1.Visible = false;
            uc_CustomerDetails1.Visible = false;
            uc_Employee1.Visible = false;
            btnAddroom.PerformClick();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uc_Addroom1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddroom_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnAddroom.Left + 30;
            uc_Addroom1.Visible = true;
            uc_Addroom1.BringToFront();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelMoving_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void uc_CustumerRes1_Load(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCustomer.Left + 30;
            uc_CustumerRes1.Visible = true;
            uc_CustumerRes1.BringToFront();
        }

        private void uc_CustumerRes1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCheckout.Left + 30;
            uc_Checkout1.Visible = true;
            uc_Checkout1.BringToFront();
        }

        private void btnCustomerdetail_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCustomerdetail.Left + 30;
            uc_CustomerDetails1.Visible = true;
            uc_CustomerDetails1.BringToFront();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnEmployee.Left + 30;
            uc_Employee1.Visible = true;
            uc_Employee1.BringToFront();
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnInvoices.Left + 30;
            uc_Invoices2.Visible = true;
            uc_Invoices2.BringToFront();
        }
    }
}
