using System;
using System.Security.Principal;
using System.Xml;

namespace CustomSecurity
{
	/// <summary>
	/// ����� CustomIdentity , ����������� "��������", ��������� �� ������ IIdentity
	/// </summary>
	public class CustomIdentity : IIdentity
	{
		//������ ����������  ��������������
		private bool _isAuth;
		private string _name;
		private string _authType;
		private int _id;
		/// <summary>
		/// �����������.
		/// </summary>
		public CustomIdentity()
		{
			this._isAuth = false;
			this._authType = String.Empty;
			this._name = String.Empty;
			this._id = -1;
		}
		/// <summary>
		///������� �����������, ����������� ��� ������������.
		/// </summary>
		/// <param name="userName">��� ������������.</param>
		public CustomIdentity(string userName)
		{
			this._id = this.AuthUserName(userName);
			this._name = userName;
			this._isAuth = true;
			this._authType = "������� ��� ��������������.";
		}
		/// <summary>
		/// ���������� ���������� ������������� ������������. 
		/// </summary>
		public int ID
		{
			get { return this._id; }
		}
		#region IIdentity Members
		/// <summary>
		/// �������� �������������� ������������.
		/// </summary>
		public bool IsAuthenticated
		{
			get
			{
				// ��������� �������� ����������.
				return this._isAuth;
			}
		}
		/// <summary>
		/// ���������� ��� ������������.
		/// </summary>
		public string Name
		{
			get
			{
				// ��������� �������� ����������.
				return this._name;
			}
		}
		/// <summary>
		/// ���������� ��� ��������������.
		/// </summary>
		public string AuthenticationType
		{
			get
			{
				// ��������� �������� ����������.
				return this._authType;
			}
		}

		#endregion
		/// <summary>
		/// ���������, ���������� �� ��� ������������  �  ���� ������ - ����� XML.
		/// </summary>
		/// <param name="name">��� ������������.</param>
		/// <returns>ID ������������.</returns>
		private int AuthUserName(string name)
		{		
			// ��������� � ���������� ��� ������������.
			XmlTextReader xmlReader = new XmlTextReader("Users.xml");
			xmlReader.WhitespaceHandling = WhitespaceHandling.None;
			while(xmlReader.Read())
			{
				if(xmlReader["name"] == name)
					return Int32.Parse(xmlReader["id"]);				 
			}
			// ���� ������������ �� ������, ���������� ����������.
			throw new System.Security.SecurityException(String.Format("������������ {0} �� ������ � ����  ������.", name));
		}
	}
}
