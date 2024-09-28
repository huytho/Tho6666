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
    public partial class Uc_Employee : UserControl
    {

        Function fn = new Function();
        String query;
        public Uc_Employee()
        {
            InitializeComponent();
        }

        private void Uc_Employee_Load(object sender, EventArgs e)
        {
            getMaxId();

        }

        /**/
        public void getMaxId()
        {
            query = "select max(eid) from employee";
            DataSet ds = fn.getdata(query);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSet.Text = (num + 1).ToString();
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobile.Text != "" && txtGender.Text != "" && txtEmail.Text != "" && txtUserName.Text != "" && txtPassword.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String email = txtEmail.Text;
                String userName = txtUserName.Text;
                String password = txtPassword.Text;


                query = "insert into employee (ename, mobile, gender, emailid, username, pass) values ('" + name + "'," + mobile + ", '" + gender + "', '" + email + "','" + userName + "','" + password + "' )";
                fn.setdata(query, "Đăng kí Nhân Viên Thành Công");
                clearAll();


                getMaxId();
            }
        }

        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex = -1;
            txtUserName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }

        private void tabEmploy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEmploy.SelectedIndex == 1)
            {
                setEmployee(guna2DataGridView1);
            }
            else if (tabEmploy.SelectedIndex == 2)
            {
                setEmployee(guna2DataGridView2);
            }
        }
        public void setEmployee(DataGridView dgv)
        {
            query = "select * from employee";
            DataSet ds = fn.getdata(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("Bạn Có Chắc Xoá Không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from employee where eid = " + txtID.Text + "";
                    fn.setdata(query, "Đã Xoá Thông Tin Nhân Viên");
                    tabEmploy_SelectedIndexChanged(this, null);
                }
            }
        }

        private void Uc_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
