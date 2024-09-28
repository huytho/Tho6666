namespace DuAn
{
    public partial class DangNhap : Form
    {

        Function fn = new Function();
        String query;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {


                // Truy vấn để kiểm tra người dùng
                query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";


                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mở form chính hoặc thực hiện hành động sau khi đăng nhập thành công
                // this.Hide();
                // MainForm mainForm = new MainForm();
                // mainForm.Show();
                lbError.Visible = false;
                Dashboard ds = new Dashboard();
                this.Hide();
                ds.Show();

            }
            else
            {
                MessageBox.Show("Xin vui lòng điền đầy đủ thông tin", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lbError.Visible = true;
                txtPassword.Clear();
            }






            /*     if (txtUsername.Text == "Huytho" && txtPassword.Text == "123")
                 {
                     lbError.Visible = false;
                     Dashboard ds = new Dashboard();
                     this.Hide();
                     ds.Show();
                 }
                 else
                 {
                     lbError.Visible = true;
                     txtPassword.Clear();
                 }*/
        }


        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            // Tạo và hiển thị RegisterForm
            DangKy registerForm = new DangKy();
            registerForm.Show();
            // (Tùy chọn) Đóng Form Đăng Nhập nếu không cần giữ lại
            // this.Close();
        }
    }
}
