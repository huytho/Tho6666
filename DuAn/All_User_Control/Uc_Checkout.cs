using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn.All_User_Control
{
    public partial class Uc_Checkout : UserControl
    {

        Function fn = new Function();
        String query;
        public Uc_Checkout()
        {
            InitializeComponent();
        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtcName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoom.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtCheckoutDate.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Uc_Checkout_Load(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where chekout = 'NO'";

            DataSet ds = fn.getdata(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where cname like '" + txtName.Text + "%' and chekout = 'NO'";
            DataSet ds = fn.getdata(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (txtcName.Text != "")
            {
                if (MessageBox.Show("Bạn có chăc chắn không?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    String cdate = txtCheckoutDate.Text;
                    query = "update customer set chekout = 'YES', checkout = '" + cdate + "' where cid = " + id + "update rooms set booked = 'NO' where roomNo = '" + txtRoom.Text + "'";
                    fn.setdata(query, "Thanh Toán Thành Công");
                    Uc_Checkout_Load(this, null);
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Không có Khách Hàng để lựa chọn", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtcName.Clear();
            txtName.Clear();
            txtRoom.Clear();
            txtCheckoutDate.ResetText();
        }

        private void Uc_Checkout_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void LoadData()
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where cname like '" + txtName.Text + "%' and chekout = 'NO'";
            DataSet ds = fn.getdata(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
