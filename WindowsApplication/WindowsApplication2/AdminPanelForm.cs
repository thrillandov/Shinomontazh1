using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShinomontazhApp
{
    public class AdminPanelForm : Form
    {
        private DataGridView dgvRecords;
        private Button btnRefresh, btnConfirm, btnDelete, btnClose;
        private Label lblStats;

        public AdminPanelForm()
        {
            BuildUI();
            LoadData();
        }

        private void BuildUI()
        {
            this.Text = "Панель администратора";
            this.ClientSize = new Size(810, 440);
            this.Font = new Font("Segoe UI", 10F);
            this.StartPosition = FormStartPosition.CenterParent;

            dgvRecords = new DataGridView();
            dgvRecords.Location = new Point(20, 20);
            dgvRecords.Size = new Size(770, 300);
            dgvRecords.ReadOnly = true;
            dgvRecords.AllowUserToAddRows = false;
            dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecords.RowHeadersVisible = false;
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(dgvRecords);

            btnRefresh = new Button();
            btnRefresh.Text = "Обновить";
            btnRefresh.Location = new Point(20, 340);
            btnRefresh.Size = new Size(150, 40);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Click += btnRefresh_Click;
            this.Controls.Add(btnRefresh);

            btnConfirm = new Button();
            btnConfirm.Text = "Подтвердить запись";
            btnConfirm.Location = new Point(190, 340);
            btnConfirm.Size = new Size(180, 40);
            btnConfirm.BackColor = Color.SeaGreen;
            btnConfirm.ForeColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Click += btnConfirm_Click;
            this.Controls.Add(btnConfirm);

            btnDelete = new Button();
            btnDelete.Text = "Удалить запись";
            btnDelete.Location = new Point(390, 340);
            btnDelete.Size = new Size(180, 40);
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Click += btnDelete_Click;
            this.Controls.Add(btnDelete);

            btnClose = new Button();
            btnClose.Text = "Закрыть";
            btnClose.Location = new Point(640, 340);
            btnClose.Size = new Size(150, 40);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += btnClose_Click;
            this.Controls.Add(btnClose);

            lblStats = new Label();
            lblStats.AutoSize = true;
            lblStats.Location = new Point(20, 400);
            lblStats.Text = "Всего записей: 0";
            this.Controls.Add(lblStats);
        }

        private void LoadData()
        {
            dgvRecords.Columns.Clear();
            dgvRecords.Columns.Add("Id", "ID");
            dgvRecords.Columns.Add("Client", "Клиент");
            dgvRecords.Columns.Add("Phone", "Телефон");
            dgvRecords.Columns.Add("Car", "Авто");
            dgvRecords.Columns.Add("Service", "Услуга");
            dgvRecords.Columns.Add("Date", "Дата");
            dgvRecords.Columns.Add("Time", "Время");
            dgvRecords.Columns.Add("Status", "Статус");

            dgvRecords.Rows.Add("1", "Иванов И.И.", "+7-900-111-22-33",
                "Lada Vesta", "Балансировка", "12.05.2025", "10:00", "Ожидает");
            dgvRecords.Rows.Add("2", "Петров П.П.", "+7-900-444-55-66",
                "Kia Rio", "Ремонт прокола", "12.05.2025", "14:00", "Подтверждена");

            lblStats.Text = "Всего записей: " + dgvRecords.Rows.Count;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Список обновлён.", "Обновление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Запись подтверждена.", "Подтверждение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Запись удалена.", "Удаление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}