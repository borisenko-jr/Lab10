using System;
using System.Threading;
using System.Security.Principal;

namespace GenericIdentityandPrincipal
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{		
		[STAThread]
		static void Main(string[] args)
		{
			// ������� � ����������� ������ ����.
			CreateGenericPrincipalAndIdentity(Roles.PowerUser);
			// ������ ���� �� �������� ������������� �������� ����.
			if(Thread.CurrentPrincipal.IsInRole("User"))
			{
				Console.WriteLine("� ��� ��� ���� ��� ������ � ���� �����������");
			}
			else if(Thread.CurrentPrincipal.IsInRole("PowerUser"))
			{
				Console.WriteLine("����� ����������, {0}. ���� ���� - ����������� ������������", Thread.CurrentPrincipal.Identity.Name);
			}
			else // Administrator
			{
				Console.WriteLine("����� ����������, {0}. ���� ���� - �������������", Thread.CurrentPrincipal.Identity.Name);
			}
            Console.ReadKey();
            Console.ReadKey();
        }
	
		// �������� �������� �������� � ���� 
		
		static void CreateGenericPrincipalAndIdentity(Roles role)
		{
			// ������� � �������������� ������ ������������ 
			// ������ ������ GenericIdentity
			GenericIdentity identity = new GenericIdentity("Username");
			// ������� ��������� ������, ���������� ���� ������������.
			string[] userRoles = new string[]{role.ToString()};
			//  ������� ������ ������ GenericPrincipal � �������������� ��� 
			// �������� ������ GenericIdentity identity � ��������� �������� � ������.
			GenericPrincipal principal = new GenericPrincipal(identity, userRoles);
			// ����������� ������ ���� � �������� ��������. 
			// ���� � ��� �������� �������� ����� ����� ������ ����.
			Thread.CurrentPrincipal = principal;
		}
		enum Roles
		{
			Administrator, 
			PowerUser, 
			User
		}
	}
}
