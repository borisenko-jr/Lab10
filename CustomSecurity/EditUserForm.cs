using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomSecurity
{
	/// <summary> 
	/// Форма изменения роли пользователя
	/// </summary>
	public class EditUserForm : Form
    {
		private Label lblName;
		private Label lblRole;
		public ComboBox cmbRole;
		private Label lblUserName;
		private Button btnCancel;
		private Button btnEdit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string UserName;
		// Обратите внимание на то, что у формы переопределен конструктор.
		// Это сделано для передаче форме имени пользователя, 
		// роль которого необходимо изменить.
		public EditUserForm(string userName)
		{
			UserName = userName;
			InitializeComponent();
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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EditUserForm));
			this.lblName = new Label();
			this.lblRole = new Label();
			this.btnCancel = new Button();
			this.btnEdit = new Button();
			this.cmbRole = new ComboBox();
			this.lblUserName = new Label();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.Location = new Point(16, 16);
			this.lblName.Name = "lblName";
			this.lblName.Size = new Size(144, 23);
			this.lblName.TabIndex = 1;
			this.lblName.Text = "Имя пользователя";
			// 
			// lblRole
			// 
			this.lblRole.Location = new Point(16, 48);
			this.lblRole.Name = "lblRole";
			this.lblRole.Size = new Size(144, 23);
			this.lblRole.TabIndex = 3;
			this.lblRole.Text = "Роль пользователя";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = DialogResult.Cancel;
			this.btnCancel.Location = new Point(192, 112);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Отмена";
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new Point(72, 112);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.TabIndex = 5;
			this.btnEdit.Text = "Изменить";
			this.btnEdit.Click += new EventHandler(this.button2_Click);
			// 
			// cmbRole
			// 
			this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbRole.Items.AddRange(new object[] {
														 "admin",
														 "manager",
														 "operator"});
			this.cmbRole.Location = new Point(176, 48);
			this.cmbRole.Name = "cmbRole";
			this.cmbRole.Size = new Size(200, 21);
			this.cmbRole.TabIndex = 6;
			// 
			// lblUserName
			// 
			this.lblUserName.Location = new Point(176, 16);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new Size(200, 23);
			this.lblUserName.TabIndex = 7;
			// 
			// EditUserForm
			// 
			this.AcceptButton = this.btnEdit;
			this.AutoScaleBaseSize = new Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new Size(386, 152);
			this.Controls.Add(this.lblUserName);
			this.Controls.Add(this.cmbRole);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblRole);
			this.Controls.Add(this.lblName);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
			this.Name = "EditUserForm";
			this.Text = "Изменение пользователя";
			this.Load += new EventHandler(this.EditUserForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, EventArgs e)
		{
			// Устанавливаем положительный результат выполнения
			// и закрываем форму.
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void EditUserForm_Load(object sender, EventArgs e)
		{
			// При загрузке формы устанавливаем имя пользователя в 
			//элемент управления lblUserName
			lblUserName.Text = UserName;
		}
	}
}
