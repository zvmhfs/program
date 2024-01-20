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
	public partial class Teams : Form
	{
		DataBaseConnection db = new DataBaseConnection();
		public Teams()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			db.openConnection();

			var curator = textBox14.Text;
			var name = textBox13.Text;
			var desc = textBox12.Text;
			var list = textBox16.Text;

			var addQuery = $"insert into Teams (Curator_id, Team_name, Team_description, Participants_list) values ('{curator}', '{name}', '{desc}', '{list}')";
			var command = new SqlCommand(addQuery, db.getConnection());
			command.ExecuteNonQuery();

			MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);

			db.closeConnection();
		}

		private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}

		private void textBox14_Leave(object sender, EventArgs e)
		{
			var team = (textBox14.Text);

			SqlDataAdapter adapter = new SqlDataAdapter();
			DataTable table = new DataTable();

			string querystring = $"select Curator_id from Curators where Curator_id = '{team}'";

			SqlCommand command = new SqlCommand(querystring, db.getConnection());

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count == 1) { return; }
			else { MessageBox.Show("Такого куратора не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
			if (textBox14.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}

		private void textBox13_Leave(object sender, EventArgs e)
		{
			if (textBox13.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}

		private void textBox12_Leave(object sender, EventArgs e)
		{
			if (textBox12.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}

		private void textBox16_Leave(object sender, EventArgs e)
		{
			if (textBox16.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
	}
}
