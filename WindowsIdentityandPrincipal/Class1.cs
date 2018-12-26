using System;
//���������� ������������ ���� Threading � Principal
using System.Threading;
using System.Security.Principal;

namespace WindowsIdentityandPrincipal
{
	
	class Class1
	{		
		[STAThread]
		static void Main(string[] args)
		{
			// ������� � �������������� ������� 
			// WindowsPrincipal � WindowsIdentity
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			WindowsPrincipal principal = new WindowsPrincipal(identity);
			// ������� ����������, ������������ � ������� ������ WindowsPrincipal
			Output("Name", principal.Identity.Name);
			Output("Type", principal.Identity.AuthenticationType);
			Output("Authenticated", principal.Identity.IsAuthenticated.ToString());
			// ������� ����������, ������������ � ������� ������ WindowsIdentity
			Output("IdentName", identity.Name);
			Output("IdentType", identity.AuthenticationType);
			Output("IdentIsAuthenticated", identity.IsAuthenticated.ToString());
			Output("IsAnonymous",  identity.IsAnonymous.ToString());
			Output("IsGuest",  identity.IsGuest.ToString());
			Output("IsSystem", identity.IsSystem.ToString());
			Output("Token", identity.Token.ToString());
            Console.ReadKey();
            Console.ReadKey();
        }
	
		//����� Output ������� ���������� �� �����, ������ myName - ��� ��������
		//���������, � myValue - ��� ��������.
		public static void Output(string myName, string myValue)
		{
			Console.WriteLine(myName + " = {0}", myValue);
		}
		//����� ��� ����������� �������� ����
		public static void CreateWindowsPrincipal_Once()
		{
			// �������������� ������ ������ WindowsIdentity 
			// � ������� ������������ ������ WindowsIdentity.GetCurrent()
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			// ������� ����� ������ ������ WindowsPrincipal
			// � �������� � �������� ��������� ������ identity
			WindowsPrincipal principal = new WindowsPrincipal(identity);

		}
	//����� ��� ��������� �������� ����.
		public static void CreateWindowsPrincipal_Repeatedly()
		{
			// ��������� ������ ���������� �������� ������� ������������
			// � ������� ����� WindowsPrincipal ������������ PrincipalPolicy, 
			// ����������� � ����������� ����� AppDomain.CurrentDomain. 
			// SetPrincipalPolicy.		
			AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
			// ����� ����, ��� ����� �������� ����������� �� ������ ������������
			// ������ �� ������������ �������� CurrentPrincipal ������ Thread.
			WindowsPrincipal principal = System.Threading.Thread.CurrentPrincipal as WindowsPrincipal;
		
		}
	}
}
