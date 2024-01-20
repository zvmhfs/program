namespace praktika_PM01
{
	partial class Teams
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teams));
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.button7 = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(164, 276);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(243, 20);
			this.textBox16.TabIndex = 20;
			this.textBox16.Leave += new System.EventHandler(this.textBox16_Leave);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.label16.Location = new System.Drawing.Point(35, 282);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(123, 16);
			this.label16.TabIndex = 19;
			this.label16.Text = "Список участников";
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(164, 242);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(243, 20);
			this.textBox12.TabIndex = 18;
			this.textBox12.Leave += new System.EventHandler(this.textBox12_Leave);
			// 
			// textBox13
			// 
			this.textBox13.Location = new System.Drawing.Point(164, 211);
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(243, 20);
			this.textBox13.TabIndex = 17;
			this.textBox13.Leave += new System.EventHandler(this.textBox13_Leave);
			// 
			// textBox14
			// 
			this.textBox14.Location = new System.Drawing.Point(164, 177);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(243, 20);
			this.textBox14.TabIndex = 16;
			this.textBox14.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox14_KeyPress);
			this.textBox14.Leave += new System.EventHandler(this.textBox14_Leave);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.label12.Location = new System.Drawing.Point(38, 248);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(120, 16);
			this.label12.TabIndex = 14;
			this.label12.Text = "Кричалка команды";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.label13.Location = new System.Drawing.Point(41, 217);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(117, 16);
			this.label13.TabIndex = 12;
			this.label13.Text = "Название команды";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.label14.Location = new System.Drawing.Point(68, 183);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(90, 16);
			this.label14.TabIndex = 11;
			this.label14.Text = "Код куратора";
			// 
			// button7
			// 
			this.button7.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button7.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.button7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.button7.Location = new System.Drawing.Point(34, 333);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(373, 45);
			this.button7.TabIndex = 13;
			this.button7.Text = "Сохранить данные";
			this.button7.UseVisualStyleBackColor = false;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(275, 71);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(64, 54);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 22;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(71, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(223, 159);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 21;
			this.pictureBox1.TabStop = false;
			// 
			// Teams
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.RosyBrown;
			this.ClientSize = new System.Drawing.Size(459, 426);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.textBox16);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.textBox12);
			this.Controls.Add(this.textBox13);
			this.Controls.Add(this.textBox14);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.button7);
			this.Name = "Teams";
			this.Text = "Добавить команду";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox16;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}