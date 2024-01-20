using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praktika_PM01
{
	public partial class Positions : Form
	{
		DataBaseConnection db = new DataBaseConnection();
		public Positions()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			db.openConnection();

			var name = textBox2.Text;
			var salary = textBox3.Text;
			var duties = textBox4.Text;

			var addQuery = $"insert into Positions (Position_name, Position_salary, Position_duties) values ('{name}', '{salary}', '{duties}')";
			var command = new SqlCommand(addQuery, db.getConnection());
			command.ExecuteNonQuery();

			MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);

			db.closeConnection();
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}

		private void textBox2_Leave(object sender, EventArgs e)
		{
			if (textBox2.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}

		private void textBox3_Leave(object sender, EventArgs e)
		{
			if (textBox3.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}

		private void textBox4_Leave(object sender, EventArgs e)
		{
			if (textBox4.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
	}
}
