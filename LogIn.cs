using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace praktika_PM01
{
	public partial class LogIn : Form
	{
		DataBaseConnection db = new DataBaseConnection();
		public LogIn()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
		}

		private void LogIn_Load(object sender, EventArgs e)
		{
			textBox1.MaxLength = 50;
			textBox2.MaxLength = 50;
			textBox2.UseSystemPasswordChar = true;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked) { textBox2.UseSystemPasswordChar = false; }
			else { textBox2.UseSystemPasswordChar = true; }
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			SignUp frm_sign = new SignUp();
			frm_sign.Show();
			this.Hide();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var loginUser = textBox1.Text;
			var passUser = (textBox2.Text);

			SqlDataAdapter adapter = new SqlDataAdapter();
			DataTable table = new DataTable();

			string querystring = $"select id_user, login_user, password_user from registration where login_user = '{loginUser}' and password_user = '{passUser}'";

			SqlCommand command = new SqlCommand(querystring, db.getConnection());

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count == 1)
			{
				MessageBox.Show("Вы успешно вошли!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				MainWindow frm1 = new MainWindow();
				this.Hide();
				frm1.ShowDialog();
				this.Show();
			}
			else
			{
				MessageBox.Show("Такого аккаунта не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			if (textBox1.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}

		private void textBox2_Leave(object sender, EventArgs e)
		{
			if (textBox2.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
	}
}
