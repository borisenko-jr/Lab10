using System;
//Подключаем пространства имен Threading и Principal
using System.Threading;
using System.Security.Principal;

namespace WindowsIdentityandPrincipal
{
	
	class Class1
	{		
		[STAThread]
		static void Main(string[] args)
		{
			// Создаем и инициализируем объекты 
			// WindowsPrincipal и WindowsIdentity
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			WindowsPrincipal principal = new WindowsPrincipal(identity);
			// Выводим информацию, содержащуюся в объекте класса WindowsPrincipal
			Output("Name", principal.Identity.Name);
			Output("Type", principal.Identity.AuthenticationType);
			Output("Authenticated", principal.Identity.IsAuthenticated.ToString());
			// Выводим информацию, содержащуюся в объекте класса WindowsIdentity
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
	
		//Метод Output выводит информацию на экран, причем myName - это название
		//параметра, а myValue - его значение.
		public static void Output(string myName, string myValue)
		{
			Console.WriteLine(myName + " = {0}", myValue);
		}
		//Метод для однократной проверки роли
		public static void CreateWindowsPrincipal_Once()
		{
			// Инициализируем объект класса WindowsIdentity 
			// с помощью статического метода WindowsIdentity.GetCurrent()
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			// Создаем новый объект класса WindowsPrincipal
			// и передаем в качестве параметра объект identity
			WindowsPrincipal principal = new WindowsPrincipal(identity);

		}
	//метод для постояной проверки роли.
		public static void CreateWindowsPrincipal_Repeatedly()
		{
			// Указываем домену приложения политику ролевой безопасности
			// с помощью члена WindowsPrincipal перечисления PrincipalPolicy, 
			// переданного в статический метод AppDomain.CurrentDomain. 
			// SetPrincipalPolicy.		
			AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
			// После того, как новая политика установлена вы можете использовать
			// объект из статического свойства CurrentPrincipal класса Thread.
			WindowsPrincipal principal = System.Threading.Thread.CurrentPrincipal as WindowsPrincipal;
		
		}
	}
}
