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
	public partial class Curators : Form
	{
		DataBaseConnection db = new DataBaseConnection();
		public Curators()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			db.openConnection();

			var name = textBox7.Text;
			var age = textBox6.Text;
			var gender = textBox5.Text;
			var phone = maskedTextBox1.Text;
			var pasport = textBox10.Text;
			var id_positions = textBox9.Text;

			var addQuery = $"insert into Curators (Curator_name, Curator_age, Curator_gender, Curator_phone, Curator_passport, Position_id) " +
				$"values ('{name}', '{age}', '{gender}', '{phone}', '{pasport}', '{id_positions}')";
			var command = new SqlCommand(addQuery, db.getConnection());
			command.ExecuteNonQuery();

			MessageBox.Show("Запись создана", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);

			db.closeConnection();
		}

		private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}

		private void textBox7_Leave(object sender, EventArgs e)
		{
			if (textBox7.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}

		private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}

		private void textBox6_Leave(object sender, EventArgs e)
		{
			string age = textBox6.Text;
			int age1 = Convert.ToInt32(age);
			if (age1 >= 18 || age1 < 0) { return; }
			else { MessageBox.Show("Вам не может быть менее 18 лет!!!"); }
			if (textBox6.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}

		private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}

		private void textBox5_Leave(object sender, EventArgs e)
		{
			string age = textBox5.Text;
			if (age != "М" && age != "Муж" && age != "Мужской" && age != "Ж" && age != "Жен" && age != "Женский")
			{ MessageBox.Show("Введите одно из перечьня: М, Муж, Мужской, Ж, Жен, Женский"); }
			else { return; }
			if (textBox5.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}

		private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}

		private void maskedTextBox1_Leave(object sender, EventArgs e)
		{
			if (maskedTextBox1.TextLength != 17) { MessageBox.Show("Введите 11 чисел!"); }
			else { return; }
		}

		private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}

		private void textBox10_Leave(object sender, EventArgs e)
		{
			if (maskedTextBox1.TextLength != 10) { return; }
			else { MessageBox.Show("Введите 10 чисел!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
			if (textBox10.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}

		private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}

		private void textBox9_Leave(object sender, EventArgs e)
		{
			var pos = (textBox9.Text);

			SqlDataAdapter adapter = new SqlDataAdapter();
			DataTable table = new DataTable();

			string querystring = $"select Position_id from Positions where Position_id = '{pos}'";

			SqlCommand command = new SqlCommand(querystring, db.getConnection());

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count == 1) { return; }
			else { MessageBox.Show("Такой должности не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
			if (textBox9.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
	}
}
