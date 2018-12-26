using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace CustomSecurity
{
	/// <summary>
	/// ������� �����.
	/// </summary>
	public class MainForm : Form
    {
		private ToolBarButton btnViewUsers;
		private ToolBarButton btnEditUsers;
		private ImageList toolBoxIcons;
		private ToolBar toolBar;
		private ListView lstViewUsers;
		private ColumnHeader colUserName;
		private ColumnHeader colUserRole;
		private ColumnHeader colUserId;
		private IContainer components;

		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.components = new Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.toolBar = new ToolBar();
			this.btnViewUsers = new ToolBarButton();
			this.btnEditUsers = new ToolBarButton();
			this.toolBoxIcons = new ImageList(this.components);
			this.lstViewUsers = new ListView();
			this.colUserName = new ColumnHeader();
			this.colUserRole = new ColumnHeader();
			this.colUserId = new ColumnHeader();
			this.SuspendLayout();
			// 
			// toolBar
			// 
			this.toolBar.Buttons.AddRange(new ToolBarButton[] {
			                                                    this.btnViewUsers,
			                                                    this.btnEditUsers});
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.toolBoxIcons;
			this.toolBar.Location = new Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new Size(424, 28);
			this.toolBar.TabIndex = 0;
			this.toolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
			// 
			// btnViewUsers
			// 
			this.btnViewUsers.ImageIndex = 0;
			this.btnViewUsers.Tag = "view";
			this.btnViewUsers.ToolTipText = "������� ������ �������������";
			// 
			// btnEditUsers
			// 
			this.btnEditUsers.ImageIndex = 1;
			this.btnEditUsers.Tag = "edit";
			this.btnEditUsers.ToolTipText = "������������� ���� ������������";
			// 
			// toolBoxIcons
			// 
			this.toolBoxIcons.ImageSize = new Size(16, 16);
			this.toolBoxIcons.ImageStream = ((ImageListStreamer)(resources.GetObject("toolBoxIcons.ImageStream")));
			this.toolBoxIcons.TransparentColor = Color.Transparent;
			// 
			// lstViewUsers
			// 
			this.lstViewUsers.Columns.AddRange(new ColumnHeader[] {
																						   this.colUserName,
																						   this.colUserRole,
																						   this.colUserId});
			this.lstViewUsers.Cursor = Cursors.Hand;
			this.lstViewUsers.Dock = DockStyle.Fill;
			this.lstViewUsers.FullRowSelect = true;
			this.lstViewUsers.GridLines = true;
			this.lstViewUsers.Location = new Point(0, 28);
			this.lstViewUsers.MultiSelect = false;
			this.lstViewUsers.Name = "lstViewUsers";
			this.lstViewUsers.Size = new Size(424, 238);
			this.lstViewUsers.SmallImageList = this.toolBoxIcons;
			this.lstViewUsers.TabIndex = 1;
			this.lstViewUsers.View = View.Details;
			// 
			// colUserName
			// 
			this.colUserName.Text = "��� ������������";
			this.colUserName.Width = 125;
			// 
			// colUserRole
			// 
			this.colUserRole.Text = "���� ������������";
			this.colUserRole.Width = 125;
			// 
			// colUserId
			// 
			this.colUserId.Text = "���������� �������������";
			this.colUserId.Width = 175;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new Size(5, 13);
			this.ClientSize = new Size(424, 266);
			this.Controls.Add(this.lstViewUsers);
			this.Controls.Add(this.toolBar);
			this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "������� ������������";
			this.Load += new EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			// �������� ��� ������������.
			LogInForm login = new LogInForm();
			if(login.ShowDialog() != DialogResult.OK)
			{
				// ���� ������������ ������� ���� �����, ��������� ����������
				this.Close();
				return;
			}
			try
			{
				// ������� ������� IIdentity � IPrincipal
				CustomIdentity identity = new CustomIdentity(login.txbUserName.Text);
				CustomPrincipal principal = new CustomPrincipal(identity);			
				Thread.CurrentPrincipal = principal;
				this.ValidateUser();
			}
			catch(Exception ex)
			{
				// ������������ ���������� � ��������� ����������.
				MessageBox.Show("�� ����� ���������� ���������� �������� ������: "+ex.Message, "������");
				this.Close();
				return;
			}
			
		}

		/// <summary>
		/// �������� ���������������� ��������� � ����������� �� ���� ������������.
		/// </summary>
		private void ValidateUser()
		{
			CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
			if(principal.IsInRole("operator"))
			{
				// ���� ���� ������������ operator, �������� ����������������.
				btnEditUsers.Enabled = false;
				btnViewUsers.Enabled = false;
			}
			if(principal.IsInRole("manager"))
			{
				// ���  ���� ������������ manager, �������� ����������� ��������� ���� ������������.
				btnEditUsers.Enabled = false;
			}
		}

		private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			// ���������, ����� ������ ���� ������ � 
			// ��������� ��������������� ��������.
			switch(e.Button.Tag.ToString())
			{
				case "view":
					this.ViewUsers();
					break;
				case "edit":
					this.EditUser();					
					break;
			}
		}
		/// <summary>
		/// ������� ������������� �� �����.
		/// </summary>
		private void ViewUsers()
		{
			lstViewUsers.Items.Clear();
			XmlTextReader xmlReader = new XmlTextReader("Users.xml");
			xmlReader.WhitespaceHandling = WhitespaceHandling.None;
			while(xmlReader.Read())
			{
				// ��������� ������ �� XML �����, ������������ �� � ���� 
				// ������ �������� ���������� ListView
				if(xmlReader["name"] == null)
					continue;
				ListViewItem item = new ListViewItem(new 
					string[]{xmlReader["name"], xmlReader["role"], xmlReader["id"]}, 0);
				lstViewUsers.Items.Add(item);
			}
			xmlReader.Close();
		}
		/// <summary>
		/// ��������  ���������� ������������.
		/// </summary>
		private void EditUser()
		{
			if(lstViewUsers.SelectedItems.Count == 0)
			{
				MessageBox.Show("�� ����� ������� ������������.", "��������� ����������");				
			}
			else
			{
				string userName = lstViewUsers.SelectedItems[0].Text;
				EditUserForm edit = new EditUserForm(userName);
				if(edit.ShowDialog() != DialogResult.OK)
					return;
				// ��������� ����� ����.
				string newRole = edit.cmbRole.SelectedItem.ToString();
				// ��������� ���� XML  ������ �������.
				XmlDocument doc = new XmlDocument();			
				StreamReader reader = new StreamReader("Users.xml");				
				doc.LoadXml(reader.ReadToEnd());
				reader.Close();				
				XmlElement root = doc.DocumentElement;
				foreach(XmlNode child in root.ChildNodes)
				{
					if(child.Attributes["name"].Value == userName)
					{
						child.Attributes["role"].Value = newRole;						
						break;
					}
				}				
				doc.Save("Users.xml");
				this.ViewUsers();
			}
		}
	}
}
