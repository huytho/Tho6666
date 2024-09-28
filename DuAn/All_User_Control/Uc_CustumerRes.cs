using Microsoft.Data.SqlClient;
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
    public partial class Uc_CustumerRes : UserControl
    {
        public Uc_CustumerRes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Uc_CustumerRes_Load(object sender, EventArgs e)
        {

        }


        Function fn = new Function();
        String query;

        public void setComboBox(String query, ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);

            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }
        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoom.SelectedIndex = -1;
            txtRooomNumber.Items.Clear();
            txtPrice.Clear();
        }

        private void txtRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRooomNumber.Items.Clear();
            query = "select roomNo from rooms where bed = '" + txtBed.Text + "' and roomType= '" + txtRoom.Text + "'and booked = 'NO'";
            setComboBox(query, txtRooomNumber);
        }

        int rId;
        private void txtRooomNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select price , roomid from rooms where roomNo = '" + txtRooomNumber.Text + "'";
            DataSet ds = fn.getdata(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rId = int.Parse(ds.Tables[0].Rows[0][1].ToString());

        }

        private void btnAllotCustomer_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtContact.Text != "" && txtNation.Text != "" && txtDate.Text != "" && txtIdPro.Text != "" && txtAddress.Text != "" && txtCheckin.Text != "" && txtPrice.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtContact.Text);
                String nation = txtNation.Text;
                String gender = txtGender.Text;
                String date = txtDate.Text;
                String idPro = txtIdPro.Text;
                String address = txtAddress.Text;
                String checkIn = txtCheckin.Text;

                query = "insert into customer (cname, mobile, nationality, gender, dob, idproof, address, checkin, roomid ) values ('" + name + "'," + mobile + ",'" + nation + "','" + gender + "','" + date + "','" + idPro + "','" + address + "','" + checkIn + "'," + rId + ") update rooms set booked = 'YES' where roomNo = '" + txtRooomNumber.Text + "'";
                fn.setdata(query, " Số Phòng " + txtRooomNumber.Text + "Đăng ký Khách Hàng Thành Công");
                clearAll();


            }
            else
            {
                MessageBox.Show("Xin vui lòng Nhập đầy đủ thông tin.", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        public void clearAll()
        {
            txtName.Clear();
            txtContact.Clear();
            txtNation.Clear();
            txtGender.SelectedIndex = -1;
            txtDate.ResetText();
            txtIdPro.Clear();
            txtAddress.Clear();
            txtCheckin.ResetText();
            txtBed.SelectedIndex = -1;
            txtRoom.SelectedIndex = -1;
            txtRooomNumber.Items.Clear();
            txtPrice.Clear();
        }

        private void Uc_CustumerRes_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
