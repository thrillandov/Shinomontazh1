using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShinomontazhApp
{
    public class MainForm : Form
    {
        private Label lblWelcome;
        private Label lblRole;
        private Button btnAppointment;
        private Button btnMyRecords;
        private Button btnAdminPanel;
        private Button btnLogout;

        public MainForm()
        {
            BuildUI();
            LoadData();
        }

        private void BuildUI()
        {
            this.Text = "Шиномонтажка — Главное меню";
            this.ClientSize = new Size(700, 460);
            this.Font = new Font("Segoe UI", 10F);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblWelcome = new Label();
            lblWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(30, 30);
            lblWelcome.Text = "Здравствуйте!";
            this.Controls.Add(lblWelcome);

            lblRole = new Label();
            lblRole.AutoSize = true;
            lblRole.Location = new Point(33, 65);
            lblRole.Text = "Роль:";
            this.Controls.Add(lblRole);

            btnAppointment = new Button();
            btnAppointment.Text = "Записаться на шиномонтаж";
            btnAppointment.Location = new Point(30, 120);
            btnAppointment.Size = new Size(280, 45);
            btnAppointment.BackColor = Color.SteelBlue;
            btnAppointment.ForeColor = Color.White;
            btnAppointment.FlatStyle = FlatStyle.Flat;
            btnAppointment.Click += btnAppointment_Click;
            this.Controls.Add(btnAppointment);

            btnMyRecords = new Button();
            btnMyRecords.Text = "Мои записи";
            btnMyRecords.Location = new Point(30, 180);
            btnMyRecords.Size = new Size(280, 45);
            btnMyRecords.FlatStyle = FlatStyle.Flat;
            btnMyRecords.Click += btnMyRecords_Click;
            this.Controls.Add(btnMyRecords);

            btnAdminPanel = new Button();
            btnAdminPanel.Text = "Панель администратора";
            btnAdminPanel.Location = new Point(30, 240);
            btnAdminPanel.Size = new Size(280, 45);
            btnAdminPanel.BackColor = Color.SeaGreen;
            btnAdminPanel.ForeColor = Color.White;
            btnAdminPanel.FlatStyle = FlatStyle.Flat;
            btnAdminPanel.Click += btnAdminPanel_Click;
            this.Controls.Add(btnAdminPanel);

            btnLogout = new Button();
            btnLogout.Text = "Выйти";
            btnLogout.Location = new Point(30, 320);
            btnLogout.Size = new Size(120, 35);
            btnLogout.BackColor = Color.IndianRed;
            btnLogout.ForeColor = Color.White;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Click += btnLogout_Click;
            this.Controls.Add(btnLogout);
        }

        private void LoadData()
        {
            lblWelcome.Text = "Здравствуйте, " + Session.CurrentUser + "!";
            lblRole.Text = "Роль: " + (Session.IsAdmin ? "Администратор" : "Пользователь");

            btnAdminPanel.Visible = Session.IsAdmin;
            btnMyRecords.Visible = !Session.IsAdmin;
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            new AppointmentForm().ShowDialog();
        }

        private void btnMyRecords_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здесь будет список ваших записей.", "Мои записи",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            new AdminPanelForm().ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            this.Hide();
            new LoginForm().Show();
        }
    }
}