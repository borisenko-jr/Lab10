using System;
using System.Threading;
using System.Security.Principal;

namespace AccessControl
{	
	class Class1
	{		
		[STAThread]
		static void Main(string[] args)
		{
			GenericIdentity identity = new GenericIdentity("MANAGER");
			string[] userRoles = new string[]{"Administrator"};
			GenericPrincipal principal = new GenericPrincipal(identity, userRoles);
			Thread.CurrentPrincipal = principal;

			ValidateUserName();
			ValidateRole();
            Console.ReadKey();
            Console.ReadKey();
        }
		//��������� ������������ �� ��������
		static void ValidateUserName()
		{
			if (String.Compare(Thread.CurrentPrincipal.Identity.Name, "manager", true) == 0)
			{
				Console.WriteLine("����� ����������, ������������ Manager");
			}
			else
			{
				throw new System.Security.SecurityException("� ��� ��� ���� ��� ���������� ������� ��������");
			}
		}
		//��������� ������������ �� ����
		static void ValidateRole()
		{
			if (Thread.CurrentPrincipal.IsInRole("Administrator"))
			{
			Console.WriteLine("����� ����������, ������������ Manager");
			}
			else
			{
				throw new System.Security.SecurityException("� ��� ��� ���� ��� ���������� ������� ��������");
			}
		}
	}
}
