using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShinomontazhApp
{
    public class LoginForm : Form
    {
        private Label lblTitle;
        private Label lblLogin;
        private Label lblPassword;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;

        public LoginForm()
        {
            BuildUI();
        }

        private void BuildUI()
        {
            this.Text = "Авторизация — Шиномонтажка";
            this.ClientSize = new Size(394, 300);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitle = new Label();
            lblTitle.Text = "Вход в систему";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(90, 20);
            this.Controls.Add(lblTitle);

            lblLogin = new Label();
            lblLogin.Text = "Логин:";
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(40, 80);
            this.Controls.Add(lblLogin);

            txtLogin = new TextBox();
            txtLogin.Location = new Point(40, 105);
            txtLogin.Size = new Size(300, 28);
            this.Controls.Add(txtLogin);

            lblPassword = new Label();
            lblPassword.Text = "Пароль:";
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(40, 145);
            this.Controls.Add(lblPassword);

            txtPassword = new TextBox();
            txtPassword.Location = new Point(40, 170);
            txtPassword.Size = new Size(300, 28);
            txtPassword.PasswordChar = '●';
            this.Controls.Add(txtPassword);

            btnLogin = new Button();
            btnLogin.Text = "Войти";
            btnLogin.Location = new Point(40, 220);
            btnLogin.Size = new Size(140, 40);
            btnLogin.BackColor = Color.SteelBlue;
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Click += btnLogin_Click;
            this.Controls.Add(btnLogin);

            btnExit = new Button();
            btnExit.Text = "Выход";
            btnExit.Location = new Point(200, 220);
            btnExit.Size = new Size(140, 40);
            btnExit.BackColor = Color.IndianRed;
            btnExit.ForeColor = Color.White;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Click += btnExit_Click;
            this.Controls.Add(btnExit);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (login == "admin" && password == "admin")
            {
                Session.CurrentUser = "admin";
                Session.Role = "Admin";
            }
            else if (login == "user" && password == "user")
            {
                Session.CurrentUser = "user";
                Session.Role = "User";
            }
            else
            {
                MessageBox.Show(
                    "Неверный логин или пароль.\n\n" +
                    "admin / admin — Администратор\n" +
                    "user / user — Пользователь",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}