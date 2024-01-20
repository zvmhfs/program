using Microsoft.VisualBasic;
using praktika_PM01;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace praktika_PM01
{
	enum RowState
	{
		Existed,
		New,
		Modified,
		ModifiedNew,
		Deleted
	}
	public partial class MainWindow : Form
	{
		DataBaseConnection db = new DataBaseConnection();
		int selectedRow;

		public MainWindow()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			CreateColumnsPositions();
			CreateColumnsCurators();
			CreateColumnsTeams();
			CreateColumnsEvents();
			RefreshDataGridPositions(dataGridViewPositions);
			RefreshDataGridCurators(dataGridViewCurators);
			RefreshDataGridTeams(dataGridViewTeams);
			RefreshDataGridEvents(dataGridViewEvents);

			System.Windows.Forms.ToolTip t = new System.Windows.Forms.ToolTip();
			t.SetToolTip(textBox18, "маска ввода: мм.дд.гг чч.мм.сс");
			t.SetToolTip(textBox17, "маска ввода: мм.дд.гг чч.мм.сс");
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// создание строк и столбцов в dataGridView
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void CreateColumnsPositions()
		{
			dataGridViewPositions.Columns.Add("Position_id", "Id должности");
			dataGridViewPositions.Columns.Add("Position_name", "Название должности");
			dataGridViewPositions.Columns.Add("Position_salary", "Зарплата");
			dataGridViewPositions.Columns.Add("Position_duties", "Обязанности");

			dataGridViewPositions.Columns.Add("IsNew", String.Empty);
			this.dataGridViewPositions.Columns["IsNew"].Visible = false;
		}
		private void CreateColumnsCurators()
		{
			dataGridViewCurators.Columns.Add("Curator_id", "Id куратора");
			dataGridViewCurators.Columns.Add("Curator_name", "ФИО куратора");
			dataGridViewCurators.Columns.Add("Curator_age", "Возраст куратора");
			dataGridViewCurators.Columns.Add("Curator_gender", "Пол куратора");
			dataGridViewCurators.Columns.Add("Curator_phone", "Телефон куратора");
			dataGridViewCurators.Columns.Add("Curator_passport", "Паспорт куратора");
			dataGridViewCurators.Columns.Add("Position_id", "Id должности");

			dataGridViewCurators.Columns.Add("IsNew", String.Empty);
			this.dataGridViewCurators.Columns["IsNew"].Visible = false;
		}
		private void CreateColumnsTeams()
		{
			dataGridViewTeams.Columns.Add("Team_id", "Id команды");
			dataGridViewTeams.Columns.Add("Curator_id", "Id куратора");
			dataGridViewTeams.Columns.Add("Team_name", "Название команды");
			dataGridViewTeams.Columns.Add("Team_description", "Кричалка команды");
			dataGridViewTeams.Columns.Add("Participants_list", "Список участников");

			dataGridViewTeams.Columns.Add("IsNew", String.Empty);
			this.dataGridViewTeams.Columns["IsNew"].Visible = false;
		}
		private void CreateColumnsEvents()
		{
			dataGridViewEvents.Columns.Add("Event_id", "Id события");
			dataGridViewEvents.Columns.Add("Position_id", "Id куратора");
			dataGridViewEvents.Columns.Add("Amount_participants", "Число участников");
			dataGridViewEvents.Columns.Add("Start_date", "Дата начала");
			dataGridViewEvents.Columns.Add("End_date", "Дата окончания");
			dataGridViewEvents.Columns.Add("Participation_cost", "Стоимость участия");

			dataGridViewEvents.Columns.Add("IsNew", String.Empty);
			this.dataGridViewEvents.Columns["IsNew"].Visible = false;
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// обработка функции обновления данных в таблице
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void RefreshDataGridPositions(DataGridView dgw)
		{
			dgw.Rows.Clear();
			string querystring = $"select * from Positions";
			SqlCommand command = new SqlCommand(querystring, db.getConnection());
			db.openConnection();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				ReadSingleRowPositions(dgw, reader);
			}
			reader.Close();
		}
		private void RefreshDataGridCurators(DataGridView dgw)
		{
			dgw.Rows.Clear();
			string querystring = $"select * from Curators";
			SqlCommand command = new SqlCommand(querystring, db.getConnection());
			db.openConnection();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				ReadSingleRowCurators(dgw, reader);
			}
			reader.Close();
		}
		private void RefreshDataGridTeams(DataGridView dgw)
		{
			dgw.Rows.Clear();
			string querystring = $"select * from Teams";
			SqlCommand command = new SqlCommand(querystring, db.getConnection());
			db.openConnection();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				ReadSingleRowTeams(dgw, reader);
			}
			reader.Close();
		}
		private void RefreshDataGridEvents(DataGridView dgw)
		{
			dgw.Rows.Clear();
			string querystring = $"select * from Events";
			SqlCommand command = new SqlCommand(querystring, db.getConnection());
			db.openConnection();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				ReadSingleRowEvents(dgw, reader);
			}
			reader.Close();
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// обработка функции добавления строк и стобцов в dataGridView
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void ReadSingleRowPositions(DataGridView dgw, IDataRecord record)
		{
			dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDecimal(2), record.GetString(3), RowState.ModifiedNew);
		}
		private void ReadSingleRowCurators(DataGridView dgw, IDataRecord record)
		{
			dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetInt32(6), RowState.ModifiedNew);
		}
		private void ReadSingleRowTeams(DataGridView dgw, IDataRecord record)
		{
			dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetString(3), record.GetString(4), RowState.ModifiedNew);
		}
		private void ReadSingleRowEvents(DataGridView dgw, IDataRecord record)
		{
			dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetDateTime(3), record.GetDateTime(4), record.GetDecimal(5), RowState.ModifiedNew);
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// обработка функции извлечения данных из строк и стобцов в dataGridView
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void dataGridViewPositions_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			selectedRow = e.RowIndex;

			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataGridViewPositions.Rows[selectedRow];

				textBox1.Text = row.Cells[0].Value.ToString();
				textBox2.Text = row.Cells[1].Value.ToString();
				textBox3.Text = row.Cells[2].Value.ToString();
				textBox4.Text = row.Cells[3].Value.ToString();
			}
		}
		private void dataGridViewCurators_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			selectedRow = e.RowIndex;

			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataGridViewCurators.Rows[selectedRow];

				textBox8.Text = row.Cells[0].Value.ToString();
				textBox7.Text = row.Cells[1].Value.ToString();
				textBox6.Text = row.Cells[2].Value.ToString();
				textBox5.Text = row.Cells[3].Value.ToString();
				maskedTextBox1.Text = row.Cells[4].Value.ToString();
				textBox10.Text = row.Cells[5].Value.ToString();
				textBox9.Text = row.Cells[6].Value.ToString();
			}
		}
		private void dataGridViewTeams_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			selectedRow = e.RowIndex;

			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataGridViewTeams.Rows[selectedRow];

				textBox15.Text = row.Cells[0].Value.ToString();
				textBox14.Text = row.Cells[1].Value.ToString();
				textBox13.Text = row.Cells[2].Value.ToString();
				textBox12.Text = row.Cells[3].Value.ToString();
				textBox16.Text = row.Cells[4].Value.ToString();
			}
		}
		private void dataGridViewEvents_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			selectedRow = e.RowIndex;

			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataGridViewEvents.Rows[selectedRow];

				textBox21.Text = row.Cells[0].Value.ToString();
				textBox20.Text = row.Cells[1].Value.ToString();
				textBox19.Text = row.Cells[2].Value.ToString();
				textBox18.Text = row.Cells[3].Value.ToString();
				textBox17.Text = row.Cells[4].Value.ToString();
				textBox22.Text = row.Cells[5].Value.ToString();
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// обработка кнопки создания новой записи
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void button1_Click(object sender, EventArgs e)
		{
			Positions p = new Positions();
			p.Show();
		}
		private void button6_Click(object sender, EventArgs e)
		{
			Curators c = new Curators();
			c.Show();
		}
		private void button9_Click(object sender, EventArgs e)
		{
			Teams t = new Teams();
			t.Show();
		}
		private void button12_Click(object sender, EventArgs e)
		{
			Events ev = new Events();
			ev.Show();
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// обработка кнопки обновления данных
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void button2_Click(object sender, EventArgs e)
		{
			RefreshDataGridPositions(dataGridViewPositions);
		}
		private void button5_Click(object sender, EventArgs e)
		{
			RefreshDataGridCurators(dataGridViewCurators);
		}
		private void button8_Click(object sender, EventArgs e)
		{
			RefreshDataGridTeams(dataGridViewTeams);
		}
		private void button11_Click(object sender, EventArgs e)
		{
			RefreshDataGridEvents(dataGridViewEvents);
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// обработка функции обновления данных в таблице
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void UpdatePositions()
		{
			db.openConnection();

			for (int index = 0; index < dataGridViewPositions.Rows.Count; index++)
			{
				var rowState = (RowState)dataGridViewPositions.Rows[index].Cells[4].Value;

				if (rowState == RowState.Existed) continue;
				if (rowState == RowState.Modified)
				{
					var id = dataGridViewPositions.Rows[index].Cells[0].Value.ToString();
					var name = dataGridViewPositions.Rows[index].Cells[1].Value.ToString();
					var description = dataGridViewPositions.Rows[index].Cells[2].Value.ToString();
					var cost = dataGridViewPositions.Rows[index].Cells[3].Value.ToString();

					var changeQuery = $"update Positions set Position_name = '{name}', Position_salary = '{description}', Position_duties = '{cost}' where Position_id = '{id}'";

					var command = new SqlCommand(changeQuery, db.getConnection());
					command.ExecuteNonQuery();
				}
			}

			db.closeConnection();
		}
		private void UpdateCurators()
		{
			db.openConnection();

			for (int index = 0; index < dataGridViewCurators.Rows.Count; index++)
			{
				var rowState = (RowState)dataGridViewCurators.Rows[index].Cells[7].Value;

				if (rowState == RowState.Existed) continue;
				if (rowState == RowState.Modified)
				{
					var id = dataGridViewCurators.Rows[index].Cells[0].Value.ToString();
					var name = dataGridViewCurators.Rows[index].Cells[1].Value.ToString();
					var age = dataGridViewCurators.Rows[index].Cells[2].Value.ToString();
					var gender = dataGridViewCurators.Rows[index].Cells[3].Value.ToString();
					var phone = dataGridViewCurators.Rows[index].Cells[4].Value.ToString();
					var passport = dataGridViewCurators.Rows[index].Cells[5].Value.ToString();
					var position = dataGridViewCurators.Rows[index].Cells[6].Value.ToString();

					var changeQuery = $"update Curators set Curator_name = '{name}', Curator_age = '{age}', Curator_gender = '{gender}', Curator_phone = '{phone}', Curator_passport = '{passport}', Position_id = '{position}' where Curator_id = '{id}'";

					var command = new SqlCommand(changeQuery, db.getConnection());
					command.ExecuteNonQuery();
				}
			}

			db.closeConnection();
		}
		private void UpdateTeams()
		{
			db.openConnection();

			for (int index = 0; index < dataGridViewTeams.Rows.Count; index++)
			{
				var rowState = (RowState)dataGridViewTeams.Rows[index].Cells[5].Value;

				if (rowState == RowState.Existed) continue;
				if (rowState == RowState.Modified)
				{
					var id = dataGridViewTeams.Rows[index].Cells[0].Value.ToString();
					var curator = dataGridViewTeams.Rows[index].Cells[1].Value.ToString();
					var name = dataGridViewTeams.Rows[index].Cells[2].Value.ToString();
					var desc = dataGridViewTeams.Rows[index].Cells[3].Value.ToString();
					var list = dataGridViewTeams.Rows[index].Cells[4].Value.ToString();

					var changeQuery = $"update Teams set Curator_id = '{curator}', Team_name = '{name}', Team_description = '{desc}', Participants_list = '{list}' where Team_id = '{id}'";

					var command = new SqlCommand(changeQuery, db.getConnection());
					command.ExecuteNonQuery();
				}
			}

			db.closeConnection();
		}
		private void UpdateEvents()
		{
			db.openConnection();

			for (int index = 0; index < dataGridViewEvents.Rows.Count; index++)
			{
				var rowState = (RowState)dataGridViewEvents.Rows[index].Cells[6].Value;

				if (rowState == RowState.Existed) continue;
				if (rowState == RowState.Modified)
				{
					var id = dataGridViewEvents.Rows[index].Cells[0].Value.ToString();
					var id_b = dataGridViewEvents.Rows[index].Cells[1].Value.ToString();
					var issue = dataGridViewEvents.Rows[index].Cells[2].Value.ToString();
					var staff = dataGridViewEvents.Rows[index].Cells[3].Value.ToString();
					var reader = dataGridViewEvents.Rows[index].Cells[4].Value.ToString();
					var term = dataGridViewEvents.Rows[index].Cells[5].Value.ToString();

					var changeQuery = $"update Events set Curator_id = '{id_b}', Amount_participants = '{issue}', Start_date = '{staff}', End_date = '{reader}', Participation_cost = '{term}' where Event_id = '{id}'";

					var command = new SqlCommand(changeQuery, db.getConnection());
					command.ExecuteNonQuery();
				}
			}

			db.closeConnection();
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// обработка функции изменения данных в таблице
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void ChangePositions()
		{
			var selectedRowIndex = dataGridViewPositions.CurrentCell.RowIndex;

			var id = textBox1.Text;
			var name = textBox2.Text;
			var description = textBox3.Text;
			var cost = textBox4.Text;
			
			if (dataGridViewPositions.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
			{
				dataGridViewPositions.Rows[selectedRowIndex].SetValues(id, name, description, cost);
				dataGridViewPositions.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
			}
		}
		private void ChangeCurators()
		{
			var selectedRowIndex = dataGridViewCurators.CurrentCell.RowIndex;

			var id = textBox8.Text;
			var name = textBox7.Text;
			var age = textBox6.Text;
			var gender = textBox5.Text;
			var phone = maskedTextBox1.Text;
			var passport = textBox10.Text;
			var position = textBox9.Text;

			if (dataGridViewCurators.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
			{
				dataGridViewCurators.Rows[selectedRowIndex].SetValues(id, name, age, gender, phone, passport, position);
				dataGridViewCurators.Rows[selectedRowIndex].Cells[7].Value = RowState.Modified;
			}
		}
		private void ChangeTeams()
		{
			var selectedRowIndex = dataGridViewTeams.CurrentCell.RowIndex;

			var id = textBox15.Text;
			var curator = textBox14.Text;
			var team = textBox13.Text;
			var desc = textBox12.Text;
			var list = textBox16.Text;

			if (dataGridViewTeams.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
			{
				dataGridViewTeams.Rows[selectedRowIndex].SetValues(id, curator, team, desc, list);
				dataGridViewTeams.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
			}
		}
		private void ChangeEvents()
		{
			var selectedRowIndex = dataGridViewEvents.CurrentCell.RowIndex;

			var id = textBox21.Text;
			var id_b = textBox20.Text;
			var issue = textBox19.Text;
			var staff = textBox18.Text;
			var reader = textBox17.Text;
			var term = textBox22.Text;

			if (dataGridViewEvents.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
			{
				dataGridViewEvents.Rows[selectedRowIndex].SetValues(id, id_b, issue, staff, reader, term);
				dataGridViewEvents.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// обработка кнопки сохранить данные
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void button3_Click(object sender, EventArgs e)
		{
			ChangePositions();
			UpdatePositions();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ChangeCurators();
			UpdateCurators();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			ChangeTeams();
			UpdateTeams();
		}
		private void button10_Click(object sender, EventArgs e)
		{
			ChangeEvents();
			UpdateEvents();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			int number;
			if (int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Введите id события"), out number))
			{
				string search = $"SELECT DATEDIFF(dd, (SELECT Start_date FROM Events WHERE Event_id = {number}), (SELECT End_date FROM Events WHERE Event_id = {number}));";
				SqlCommand con = new SqlCommand(search, db.getConnection());
				db.openConnection();
				int count = (int)con.ExecuteScalar();
				MessageBox.Show("Разница между датами " + count + "", "Успешно");
				db.closeConnection();
			}
			else
			{
				MessageBox.Show("Неверный ввод!");
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// обработка ошибок
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//вкладка Дожности
		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}
		private void textBox2_Leave(object sender, EventArgs e)
		{
			if (textBox2.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
		///
		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}
		private void textBox3_Leave(object sender, EventArgs e)
		{
			if (textBox3.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
		/// 
		private void textBox4_Leave(object sender, EventArgs e)
		{
			if (textBox4.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
		//вкладка Кураторы
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
		///
		private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}
		private void textBox7_Leave(object sender, EventArgs e)
		{
			if (textBox7.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
		///
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
		///
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
		///
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

		private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}
		///вкладка Команды
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
		///
		private void textBox13_Leave(object sender, EventArgs e)
		{
			if (textBox13.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
		///
		private void textBox12_Leave(object sender, EventArgs e)
		{
			if (textBox12.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
		///
		private void textBox16_Leave(object sender, EventArgs e)
		{
			if (textBox16.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
		///
		private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}
		private void textBox20_Leave(object sender, EventArgs e)
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
		///
		private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}
		private void textBox19_Leave(object sender, EventArgs e)
		{
			if (textBox19.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
		///
		private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
			if (e.Handled == true) { MessageBox.Show("Неверный ввод!"); }
		}
		private void textBox22_Leave(object sender, EventArgs e)
		{
			if (textBox22.Text.Length < 1) { MessageBox.Show("Заполните поле данными"); }
		}
		///
	}
}