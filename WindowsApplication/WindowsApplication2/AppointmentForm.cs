using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShinomontazhApp
{
    public class AppointmentForm : Form
    {
        private Label lblFio, lblPhone, lblCar, lblService, lblDate, lblTime, lblNotes;
        private TextBox txtFio, txtPhone, txtCar, txtNotes;
        private ComboBox cmbService, cmbTime;
        private DateTimePicker dtpDate;
        private Button btnSave, btnCancel;

        public AppointmentForm()
        {
            BuildUI();
            LoadData();
        }

        private void BuildUI()
        {
            this.Text = "Запись на шиномонтаж";
            this.ClientSize = new Size(520, 430);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            int xLabel = 30;
            int xInput = 160;
            int wInput = 320;

            lblFio = MakeLabel("ФИО:", xLabel, 30);
            txtFio = MakeTextBox(xInput, 27, wInput);

            lblPhone = MakeLabel("Телефон:", xLabel, 70);
            txtPhone = MakeTextBox(xInput, 67, wInput);

            lblCar = MakeLabel("Марка авто:", xLabel, 110);
            txtCar = MakeTextBox(xInput, 107, wInput);

            lblService = MakeLabel("Тип услуги:", xLabel, 150);
            cmbService = new ComboBox();
            cmbService.Location = new Point(xInput, 147);
            cmbService.Size = new Size(wInput, 28);
            cmbService.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cmbService);

            lblDate = MakeLabel("Дата:", xLabel, 190);
            dtpDate = new DateTimePicker();
            dtpDate.Location = new Point(xInput, 187);
            dtpDate.Size = new Size(wInput, 28);
            dtpDate.Format = DateTimePickerFormat.Short;
            this.Controls.Add(dtpDate);

            lblTime = MakeLabel("Время:", xLabel, 230);
            cmbTime = new ComboBox();
            cmbTime.Location = new Point(xInput, 227);
            cmbTime.Size = new Size(wInput, 28);
            cmbTime.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cmbTime);

            lblNotes = MakeLabel("Примечания:", xLabel, 270);
            txtNotes = MakeTextBox(xInput, 267, wInput);
            txtNotes.Multiline = true;
            txtNotes.Height = 70;

            btnSave = new Button();
            btnSave.Text = "Записать";
            btnSave.Location = new Point(xInput, 360);
            btnSave.Size = new Size(150, 40);
            btnSave.BackColor = Color.SteelBlue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += btnSave_Click;
            this.Controls.Add(btnSave);

            btnCancel = new Button();
            btnCancel.Text = "Отмена";
            btnCancel.Location = new Point(xInput + 170, 360);
            btnCancel.Size = new Size(150, 40);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += btnCancel_Click;
            this.Controls.Add(btnCancel);
        }

        private Label MakeLabel(string text, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            this.Controls.Add(lbl);
            return lbl;
        }

        private TextBox MakeTextBox(int x, int y, int w)
        {
            TextBox tb = new TextBox();
            tb.Location = new Point(x, y);
            tb.Size = new Size(w, 28);
            this.Controls.Add(tb);
            return tb;
        }

        private void LoadData()
        {
            cmbService.Items.AddRange(new object[]
            {
                "Балансировка колёс",
                "Замена шины",
                "Ремонт прокола",
                "Сезонная замена"
            });
            cmbService.SelectedIndex = 0;

            cmbTime.Items.AddRange(new object[]
            {
                "09:00", "10:00", "11:00", "12:00", "13:00",
                "14:00", "15:00", "16:00", "17:00"
            });
            cmbTime.SelectedIndex = 0;

            dtpDate.MinDate = DateTime.Today;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFio.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Заполните ФИО и телефон.",
                    "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show(
                "Заявка принята.\n\n" +
                "ФИО: " + txtFio.Text + "\n" +
                "Телефон: " + txtPhone.Text + "\n" +
                "Авто: " + txtCar.Text + "\n" +
                "Услуга: " + cmbService.SelectedItem + "\n" +
                "Дата: " + dtpDate.Value.ToString("dd.MM.yyyy") + " " + cmbTime.SelectedItem,
                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}