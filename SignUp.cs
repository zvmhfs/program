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
	public partial class SignUp : Form
	{
		DataBaseConnection db = new DataBaseConnection();
		public SignUp()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
		}

		private void SignUp_Load(object sender, EventArgs e)
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

		private Boolean check_user()
		{
			var login_user = textBox1.Text;

			SqlDataAdapter adapter = new SqlDataAdapter();
			DataTable table = new DataTable();
			string querystring = $"select id_user, login_user, password_user from registration where login_user = '{login_user}'";

			SqlCommand command = new SqlCommand(querystring, db.getConnection());

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
			{
				MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка!");
				return true;
			}
			else
			{
				return false;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (check_user())
			{
				return;
			}

			var login = textBox1.Text;
			var password = textBox2.Text;
			string querystring = $"insert into registration(login_user, password_user) values ('{login}', '{password}')";
			SqlCommand command = new SqlCommand(querystring, db.getConnection());

			db.openConnection();
			if (command.ExecuteNonQuery() == 1)
			{
				MessageBox.Show("Аккаунт успешно создан!", "Успешно!");
				LogIn frm_login = new LogIn();
				this.Hide();
				frm_login.ShowDialog();
			}
			else
			{
				MessageBox.Show("Пользователь уже существует!", "Ошибка!");
			}
			db.closeConnection();
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
