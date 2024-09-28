using Guna.UI2.WinForms;
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
    public partial class Uc_Addroom : UserControl
    {

        Function fn = new Function();
        String query;
        public Uc_Addroom()
        {
            InitializeComponent();

            listRoom.DefaultCellStyle.Font = new Font("Times New Roman", 11);  // Thay "Arial" và kích thước phông chữ theo ý muốn của bạn
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Uc_Addroom_Load(object sender, EventArgs e)
        {
            query = "select * from rooms";
            DataSet ds = fn.getdata(query);
            listRoom.DataSource = ds.Tables[0];

        }


        // thêm thông tin khách hàng
        private void btnAddroom_Click(object sender, EventArgs e)
        {
            if (txtRoomnumber.Text != "" && txtRoomtype.Text != "" && txtRoombed.Text != "" && txtRoomprice.Text != "")
            {
                String roomnumber = txtRoomnumber.Text;
                String type = txtRoomtype.Text;
                String bed = txtRoombed.Text;
                Int64 price = Int64.Parse(txtRoomprice.Text);


                query = "insert into rooms (roomNo, roomType,bed,price) values ('" + roomnumber + "','" + type + "','" + bed + "'," + price + ")";

                fn.setdata(query, "Đã Thêm Phòng");


                Uc_Addroom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Xin vui lòng Điền đầy đủ thông tin", "error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        public void clearAll()
        {
            txtRoomnumber.Clear();
            txtRoomtype.SelectedIndex = 0;
            txtRoombed.SelectedIndex = -1;
            txtRoomprice.Clear();

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Uc_Addroom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void Uc_Addroom_Enter(object sender, EventArgs e)
        {
            Uc_Addroom_Load(this, null);
        }




        // xoá thông tin khách hàng
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có chọn phòng hay không
            if (txtRoomnumber.Text != "")
            {
                // Xác nhận người dùng
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    String roomnumber = txtRoomnumber.Text;
                    query = "DELETE FROM Rooms WHERE roomNo = '" + roomnumber + "'";

                    // Thực hiện xóa dữ liệu
                    fn.setdata(query, "Đã Xóa Phòng");

                    // Cập nhật lại dữ liệu hiển thị
                    Uc_Addroom_Load(this, null);

                    // Xóa thông tin trên form
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listRoom_Click(object sender, EventArgs e)
        {

        }

        private void listRoom_MouseClick(object sender, MouseEventArgs e)
        {

        }

        // danh sách khách hàng hiện lên form
        private void listRoom_SelectionChanged(object sender, EventArgs e)
        {

        }

        // sửa thông tin khách hàng
        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomnumber.Text != "" && txtRoomtype.Text != "" && txtRoombed.Text != "" && txtRoomprice.Text != "")
            {
                String roomnumber = txtRoomnumber.Text;
                String type = txtRoomtype.Text;
                String bed = txtRoombed.Text;
                Int64 price = Int64.Parse(txtRoomprice.Text);

                // Câu lệnh SQL để cập nhật thông tin phòng
                string query = "UPDATE rooms SET roomType = '" + type + "', bed = '" + bed + "', price = " + price + " WHERE roomNo = '" + roomnumber + "'";
                fn.setdata(query, "Đã Cập Nhật Phòng");

                // Cập nhật lại dữ liệu hiển thị
                Uc_Addroom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Xin vui lòng Điền đầy đủ thông tin", "error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
 
        int id;
        private void listroom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (listRoom.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                id = int.Parse(listRoom.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtRoomnumber.Text = listRoom.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoomtype.Text = listRoom.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtRoombed.Text = listRoom.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtRoomprice.Text = listRoom.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
    }
}
