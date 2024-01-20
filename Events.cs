using Microsoft.OData.Edm;
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
	public partial class Events : Form
	{
		DataBaseConnection db = new DataBaseConnection();
		public Events()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
		}

		private void button10_Click(object sender, EventArgs e)
		{
			db.openConnection();

			var staff = textBox20.Text;
			var reader = textBox19.Text;
			Date start = monthCalendar1.SelectionStart;
			Date end = monthCalendar2.SelectionStart;
			var term = textBox22.Text;

			var addQuery = $"insert into Events (Curator_id, Amount_participants, Start_date, End_date, Participation_cost) values ('{staff}', '{reader}', '{start}', '{end}', '{term}')";
			var command = new SqlCommand(addQuery, db.getConnection());
			command.ExecuteNonQuery();

			MessageBox.Show("Запись создана", "Победа!", MessageBoxButtons.OK, MessageBoxIcon.Information);

			db.closeConnection();
		}

		private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
		{
			label1.Text = monthCalendar1.SelectionStart.ToString();
		}

		private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
		{
			label2.Text = monthCalendar2.SelectionStart.ToString();
		}

		private void textBox20_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}

		private void textBox20_Leave_1(object sender, EventArgs e)
		{
			var team = (textBox20.Text);

			SqlDataAdapter adapter = new SqlDataAdapter();
			DataTable table = new DataTable();

			string querystring = $"select Curator_id from Curators where Curator_id = '{team}'";

			SqlCommand command = new SqlCommand(querystring, db.getConnection());

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count == 1) { return; }
			else { MessageBox.Show("Такого куратора не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
			if (textBox20.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}

		private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}

		private void textBox19_Leave(object sender, EventArgs e)
		{
			if (textBox19.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}

		private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}

		private void textBox22_Leave(object sender, EventArgs e)
		{
			if (textBox22.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
	}
}
