using System;
using System.Security.Principal;
using System.Xml;

namespace CustomSecurity
{
	/// <summary>
	/// ����� CustomPrincipal, ����������� ����, ��������� �� ������ IPrincipal
	/// </summary>
	public class CustomPrincipal :IPrincipal
	{
		private CustomIdentity _indentity;
		private string _role;
		/// <summary>
		/// �����������.
		/// </summary>
		/// <param name="identity">���������� �������� ������������ ������������.</param>
		public CustomPrincipal(CustomIdentity identity)
		{ 
			// �������������� ��������
			this._indentity = identity;
			// �������������� ���������� ������ ���� ���. ���� ���� ���������� � �������� ���������� ����������, �� 
			// ��������� ������� � ���� ������ ����� ������������ ����������.
			this._role = this.GetUserRole();
		}
		#region IPrincipal Members
		/// <summary>
		/// �������� �������� ������������.
		/// </summary>
		public IIdentity Identity
		{
			get
			{
				// ��������� �������� ����������.
				return this._indentity;
			}
		}
		/// <summary>
		/// ���������, ���������� �� ������������ � �������� ����.
		/// </summary>
		/// <param name="role">����.</param>
		/// <returns></returns>
		public bool IsInRole(string role)
		{
			// ��������� ����� ����������.
			return role == this._role;


			// ���� ���������� ����������� �� ��������� ���� ��� ������������ ����������, �� ��� ����� ������� ���:
			//return role == this.GetUserRole();
		}

		#endregion
		/// <summary>
		/// ����������  ���� ������������.
		/// </summary>
		/// <returns></returns>
		private string GetUserRole()
		{
			// ��������� � ���������� ��� ������������.
			XmlTextReader xmlReader = new XmlTextReader("Users.xml");
			xmlReader.WhitespaceHandling = WhitespaceHandling.None;
			while(xmlReader.Read())
			{
				if(xmlReader["name"] == this._indentity.Name)
					return xmlReader["role"];				 
			}
			// ���� ���� ������������ �� �������, ���������� ����������.
			throw new System.Security.SecurityException(String.Format("���� ������������ {0} �� ������� � ���� ������.",
				this._indentity.Name));			
		}
	}
}
