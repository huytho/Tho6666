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

namespace DuAn
{
    public partial class DangKy : Form
    {

        Function fn = new Function();
        String query;
        public DangKy()
        {
            InitializeComponent();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {

                String username = txtUsername.Text;
                String password = txtPassword.Text;

                // Hash mật khẩu
                string passwordHash = HashPassword(password);

                query = "insert into Users (Username, PasswordHash) values ('" + username + "','" + password + "')";
                fn.setdata(query, "Đăng kí Thành Công");

            }
            else
            {
                MessageBox.Show("Xin vui lòng Điền đầy đủ thông tin", "error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            this.Close();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
