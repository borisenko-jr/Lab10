using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomSecurity
{
	/// <summary>
	/// Форма ввода имени пользователя.
	/// </summary>
	public class LogInForm : Form
    {
		// Обратите внимание на то, что модификатору доступа элемента
		// управления txbUserName  установлено  значение  public. Это сделано для того, чтобы
		// можно было из другой формы получить введенный в него текст.
		public TextBox txbUserName;
		private Button btnCancel;
		private Button btnOk;
		private Label lblUserName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public LogInForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
	
		private void InitializeComponent()
		{
			this.txbUserName = new TextBox();
			this.btnCancel = new Button();
			this.btnOk = new Button();
			this.lblUserName = new Label();
			this.SuspendLayout();
			// 
			// txbUserName
			// 
			this.txbUserName.Location = new Point(16, 32);
			this.txbUserName.Name = "txbUserName";
			this.txbUserName.Size = new Size(312, 20);
			this.txbUserName.TabIndex = 0;
			this.txbUserName.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = DialogResult.Cancel;
			this.btnCancel.Location = new Point(152, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Отмена";
			// 
			// btnOk
			// 
			this.btnOk.Location = new Point(248, 80);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "ОК";
			this.btnOk.Click += new EventHandler(this.btnOk_Click);
			// 
			// lblUserName
			// 
			this.lblUserName.Location = new Point(16, 8);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new Size(216, 24);
			this.lblUserName.TabIndex = 3;
			this.lblUserName.Text = "Введите имя пользователя:";
			// 
			// LogInForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new Size(342, 116);
			this.Controls.Add(this.lblUserName);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txbUserName);
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.Name = "LogInForm";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Авторизация";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, EventArgs e)
		{
			// Устанавливаем положительный  результат выполнения
			// и закрываем форму.
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
